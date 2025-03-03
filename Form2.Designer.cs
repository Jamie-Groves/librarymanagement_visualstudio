namespace WindowsFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.book_listbox = new System.Windows.Forms.ListBox();
            this.bookCover_picturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bookCover_picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Books";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // book_listbox
            // 
            this.book_listbox.BackColor = System.Drawing.SystemColors.Menu;
            this.book_listbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.book_listbox.FormattingEnabled = true;
            this.book_listbox.Items.AddRange(new object[] {
            "A book"});
            this.book_listbox.Location = new System.Drawing.Point(56, 146);
            this.book_listbox.Name = "book_listbox";
            this.book_listbox.Size = new System.Drawing.Size(213, 236);
            this.book_listbox.TabIndex = 1;
            // 
            // bookCover_picturebox
            // 
            this.bookCover_picturebox.Location = new System.Drawing.Point(315, 146);
            this.bookCover_picturebox.Name = "bookCover_picturebox";
            this.bookCover_picturebox.Size = new System.Drawing.Size(208, 235);
            this.bookCover_picturebox.TabIndex = 2;
            this.bookCover_picturebox.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 639);
            this.Controls.Add(this.bookCover_picturebox);
            this.Controls.Add(this.book_listbox);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.bookCover_picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox book_listbox;
        private System.Windows.Forms.PictureBox bookCover_picturebox;
    }
}