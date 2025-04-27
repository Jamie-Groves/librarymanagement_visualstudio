// Disclaimer: Original code was written in Python, and debugging the C# conversion was assisted by A.I.
// See "q32b-log-barcode.pdf" for details.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace WindowsFormsApp1
{
	/// <summary>
	/// Encapsulates ISBN-13 barcode scanning logic using Emgu.CV.
	/// </summary>
	public class BarcodeScanner
	{
		private static readonly Dictionary<char, string> PARITY_PATTERNS = new Dictionary<char, string>
		{
			{ '0', "AAAAAA" }, { '1', "AABABB" }, { '2', "AABBAB" }, { '3', "AABBBA" },
			{ '4', "ABAABB" }, { '5', "ABBAAB" }, { '6', "ABBBAA" }, { '7', "ABABAB" },
			{ '8', "ABABBA" }, { '9', "ABBABA" }
		};

		private const string START_GUARD = "101";
		private const string MID_GUARD = "01010";
		private const string END_GUARD = "101";

		private static readonly Dictionary<char, List<string>> ISBN_13_PATTERNS = new Dictionary<char, List<string>>
		{
			{ '0', new List<string> { "0001101", "0100111", "1110010" } },
			{ '1', new List<string> { "0011001", "0110011", "1100110" } },
			{ '2', new List<string> { "0010011", "0011011", "1101100" } },
			{ '3', new List<string> { "0111101", "0100001", "1000010" } },
			{ '4', new List<string> { "0100011", "0011101", "1011100" } },
			{ '5', new List<string> { "0110001", "0111001", "1001110" } },
			{ '6', new List<string> { "0101111", "0000101", "1010000" } },
			{ '7', new List<string> { "0111011", "0010001", "1000100" } },
			{ '8', new List<string> { "0110111", "0001001", "1001000" } },
			{ '9', new List<string> { "0001011", "0010111", "1110100" } }
		};

		/// <summary>
		/// Scans the specified image file for an ISBN-13 barcode and returns the decoded string.
		/// </summary>
		/// <param name="imagePath">Path to the barcode image.</param>
		/// <returns>Decoded ISBN-13 string.</returns>
		public string Scan(string imagePath)
		{
			// 1. Load image in grayscale
			Mat mat = CvInvoke.Imread(imagePath, ImreadModes.Grayscale);
			if (mat == null || mat.IsEmpty)
				throw new ArgumentException($"Cannot load image: {imagePath}");

			// 2. Convert to Image<Gray, byte>
			Image<Gray, byte> img = mat.ToImage<Gray, byte>();

			// 2. Preprocess: blur, threshold, morph
			var blurred = img.SmoothGaussian(5);
			CvInvoke.Threshold(blurred, blurred, 0, 255, ThresholdType.BinaryInv | ThresholdType.Otsu);
			var kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
			var morphed = blurred.MorphologyEx(MorphOp.Open, kernel, new Point(-1,-1), 1, BorderType.Default, new MCvScalar(0));

			// 3. Detect bar rectangles
			var bars = DetectBarRectangles(morphed);

			// 4. Build the binary module string
			string bitString = BuildBinaryString(bars);

			// 5. Decode bits to ISBN-13
			return DecodeBitsToIsbn(bitString);
		}

		private List<Rectangle> DetectBarRectangles(Image<Gray, byte> morphedImg)
		{
			var contours = new VectorOfVectorOfPoint();
			CvInvoke.FindContours(morphedImg, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

			var rects = new List<Rectangle>();
			for (int i = 0; i < contours.Size; i++)
			{
				using (var approx = new VectorOfPoint())
				{
					double eps = 0.0009 * CvInvoke.ArcLength(contours[i], true);
					CvInvoke.ApproxPolyDP(contours[i], approx, eps, true);

					if (approx.Size == 4)
					{
						var r = CvInvoke.BoundingRectangle(approx);
						if (r.Height > 50)
							rects.Add(r);
					}
				}
				
			}

			if (rects.Count == 0)
				throw new InvalidOperationException("No barcode bars detected.");

			// Sort bars left-to-right
			return rects.OrderBy(r => r.X).ToList();
		}

		private string BuildBinaryString(List<Rectangle> bars)
		{
			// Estimate module width as smallest bar width
			int moduleWidth = bars.Min(r => r.Width);

			// Build bar/space sequence
			var sequence = new List<(Rectangle rect, bool isBar)>();
			for (int i = 0; i < bars.Count; i++)
			{
				sequence.Add((bars[i], true));
				if (i < bars.Count - 1)
				{
					int spaceWidth = bars[i + 1].X - (bars[i].X + bars[i].Width);
					var spaceRect = new Rectangle(bars[i].X + bars[i].Width, bars[i].Y, spaceWidth, bars[i].Height);
					sequence.Add((spaceRect, false));
				}
			}

			// Convert to bits
			var sb = new StringBuilder();
			foreach (var (rect, isBar) in sequence)
			{
				int count = (int)Math.Round((double)rect.Width / moduleWidth);
				sb.Append(new string(isBar ? '1' : '0', count));
			}
			return sb.ToString();
		}

		private string DecodeBitsToIsbn(string binaryBarcode)
		{
			if (!binaryBarcode.StartsWith(START_GUARD))
				throw new InvalidOperationException("Start guard not found.");
			if (!binaryBarcode.EndsWith(END_GUARD))
				throw new InvalidOperationException("End guard not found.");

			int midIndex = 3 + 42;
			if (binaryBarcode.Substring(midIndex, MID_GUARD.Length) != MID_GUARD)
				throw new InvalidOperationException("Middle guard not found.");

			string leftBits = binaryBarcode.Substring(3, 42);
			string rightBits = binaryBarcode.Substring(midIndex + MID_GUARD.Length, 42);

			var leftChunks = SplitString(leftBits, 6);
			var rightChunks = SplitString(rightBits, 6);

			var paritySeq = new StringBuilder();
			var digitsLeft = new StringBuilder();

			// Decode left side (L/G)
			foreach (var chunk in leftChunks)
			{
				bool matched = false;
				foreach (var kvp in ISBN_13_PATTERNS)
				{
					if (kvp.Value[0] == chunk)
					{
						digitsLeft.Append(kvp.Key);
						paritySeq.Append('A');
						matched = true;
						break;
					}
					else if (kvp.Value[1] == chunk)
					{
						digitsLeft.Append(kvp.Key);
						paritySeq.Append('B');
						matched = true;
						break;
					}
				}
				if (!matched)
					throw new InvalidOperationException($"Unknown left pattern: {chunk}");
			}

			// Infer first digit from parity pattern
			char firstDigit = PARITY_PATTERNS.First(p => p.Value == paritySeq.ToString()).Key;
			var isbn = new StringBuilder();
			isbn.Append(firstDigit).Append(digitsLeft);

			// Decode right side (R)
			foreach (var chunk in rightChunks)
			{
				bool matched = false;
				foreach (var kvp in ISBN_13_PATTERNS)
				{
					if (kvp.Value[2] == chunk)
					{
						isbn.Append(kvp.Key);
						matched = true;
						break;
					}
				}
				if (!matched)
					throw new InvalidOperationException($"Unknown right pattern: {chunk}");
			}

			return isbn.ToString();
		}

		private List<string> SplitString(string str, int parts)
		{
			int length = str.Length / parts;
			var list = new List<string>();
			for (int i = 0; i < parts; i++)
				list.Add(str.Substring(i * length, length));
			return list;
		}
	}
}

