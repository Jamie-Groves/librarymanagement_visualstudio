using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private MySqlConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadBookTitles();
            LoadUsersIntoComboBox();
        }

        //Connect to the mySQL database
        private void InitializeDatabaseConnection()
        {
            string myConnectionString = "server=localhost;uid=root;pwd=hd9T7K5Se1KK4kIO;database=library_database";

            try
            {
                myConnection = new MySqlConnection(myConnectionString);
                myConnection.Open();

                MessageBox.Show("Database connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //LoadBookTitles for the start of the application
        private void LoadBookTitles()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Database connection is not open!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT title FROM books"; // Adjust table/column name based on DB

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, myConnection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    books_listbox.Items.Clear(); // Clear existing items

                    while (reader.Read())
                    {
                        books_listbox.Items.Add(reader.GetString("title")); // Add book title to ListBox
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error loading book titles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Close connection when the form is closing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (myConnection != null && myConnection.State == System.Data.ConnectionState.Open)
            {
                myConnection.Close();
            }
            base.OnFormClosing(e);
        }


        //Loading methods based on the tab selected
        private void librarytabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (library_tabs.SelectedTab.Text == "Members") // Ensure the tab name matches
            {
                LoadUsers();
            }
            if (library_tabs.SelectedTab.Text == "Book List")
            {
                LoadUsersIntoComboBox();
            }
        }

        private void LoadUsersIntoComboBox()
        {
            string query = "SELECT username FROM users";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, myConnection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    member_combobox.Items.Clear(); // Clear existing items
                    while (reader.Read())
                    {
                        member_combobox.Items.Add(reader.GetString("username"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void books_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (books_listbox.SelectedItem == null) return;

            string selectedBook = books_listbox.SelectedItem.ToString();
            string searchUrl = $"https://openlibrary.org/search.json?title={Uri.EscapeDataString(selectedBook)}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage searchResponse = await client.GetAsync(searchUrl);
                    searchResponse.EnsureSuccessStatusCode();
                    string searchJson = await searchResponse.Content.ReadAsStringAsync();
                    JObject searchResult = JObject.Parse(searchJson);

                    JToken firstBook = searchResult["docs"]?.First;
                    if (firstBook != null)
                    {
                        string author = firstBook["author_name"]?.First?.ToString() ?? "Unknown";
                        string pages = firstBook["number_of_pages_median"]?.ToString() ?? "N/A";
                        string coverUrl = firstBook["cover_i"] != null
                            ? $"https://covers.openlibrary.org/b/id/{firstBook["cover_i"]}-L.jpg"
                            : null;

                        // Get Work ID for full book details
                        string workId = firstBook["key"]?.ToString(); // Example: "/works/OL12345W"
                        string workDetailsUrl = $"https://openlibrary.org{workId}.json";

                        string description = "No description available";
                        string genre = "Unknown";

                        // Fetch full book details
                        HttpResponseMessage workResponse = await client.GetAsync(workDetailsUrl);
                        if (workResponse.IsSuccessStatusCode)
                        {
                            string workJson = await workResponse.Content.ReadAsStringAsync();
                            JObject workDetails = JObject.Parse(workJson);

                            // Extract description
                            if (workDetails["description"] != null)
                            {
                                description = workDetails["description"].Type == JTokenType.Object
                                    ? workDetails["description"]["value"]?.ToString()
                                    : workDetails["description"].ToString();
                            }

                            // Extract genre (subject)
                            // Extract genre (mainstream only)
                            if (workDetails["subjects"] != null)
                            {
                                var allowedGenres = new List<string>
                                    {
                                        "fiction", "non-fiction", "science fiction", "fantasy", "horror", "romance",
                                        "mystery", "historical", "biography", "poetry", "thriller", "children",
                                        "young adult", "classics", "drama", "adventure"
                                    };

                                var rawSubjects = workDetails["subjects"]
                                    .Select(s => s.ToString().ToLowerInvariant().Trim());

                                var matchingGenres = allowedGenres
                                    .Where(g => rawSubjects.Any(s => s.Contains(g)))
                                    .Distinct()
                                    .ToList();

                                genre = matchingGenres.Count > 0 ? string.Join(", ", matchingGenres) : "Unknown";
                            }

                        }

                        // Update UI elements
                        author_tb.Text = author;
                        description_tb.Text = description;
                        genre_tb.Text = genre;

                        // Load book cover
                        if (!string.IsNullOrEmpty(coverUrl))
                        {
                            using (WebClient webClient = new WebClient())
                            {
                                byte[] imageData = await webClient.DownloadDataTaskAsync(coverUrl);
                                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageData))
                                {
                                    bookCover_picturebox.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        else
                        {
                            bookCover_picturebox.Image = null; // Clear if no cover found
                        }
                    }
                    else
                    {
                        MessageBox.Show("No book found on Open Library.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching book details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewCheckedOut_button_Click(object sender, EventArgs e)
        {
            if (books_listbox.SelectedItem == null)
            {
                MessageBox.Show("Please select a book from the list.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedBook = books_listbox.SelectedItem.ToString();
            string query = @"
        SELECT users.username, checked_out.checkout_date 
        FROM checked_out
        INNER JOIN books ON checked_out.book_id = books.id
        INNER JOIN users ON checked_out.user_id = users.user_id
        WHERE books.title = @title";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@title", selectedBook);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> checkedOutUsers = new List<string>(); // List to store multiple users

                        while (reader.Read()) // Loop through all records
                        {
                            string borrowerName = reader.GetString("username");
                            string checkoutDate = reader.GetDateTime("checkout_date").ToString("yyyy-MM-dd");

                            checkedOutUsers.Add($"{borrowerName} (Checked out on: {checkoutDate})");
                        }

                        if (checkedOutUsers.Count > 0)
                        {
                            string allBorrowers = string.Join("\n", checkedOutUsers);
                            MessageBox.Show($"This book is checked out by:\n{allBorrowers}", "Checked Out Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("This book is currently available.", "Not Checked Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving checkout details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadUsers()
        {
            string query = "SELECT username FROM users"; // Fetch all usernames from users table
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, myConnection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    members_listbox.Items.Clear(); // Clear previous entries

                    while (reader.Read())
                    {
                        members_listbox.Items.Add(reader.GetString("username")); // Add each username to ListBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void members_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (members_listbox.SelectedItem == null) return;

            string selectedUser = members_listbox.SelectedItem.ToString();
            string query = "SELECT email FROM users WHERE username = @username";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@username", selectedUser);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("email")))
                        {
                            email_tb.Text = reader.GetString("email"); // Populate email textbox
                        }
                        else
                        {
                            email_tb.Text = "No email available"; // Default text if email is missing
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadcheckedout_button_Click(object sender, EventArgs e)
        {
            if (members_listbox.SelectedItem == null)
            {
                MessageBox.Show("Please select a user before loading books.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedUser = members_listbox.SelectedItem.ToString();
            string getUserQuery = "SELECT user_id FROM users WHERE username = @username";
            int userId = -1; //default if user is not found

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(getUserQuery, myConnection))
                {
                    cmd.Parameters.AddWithValue("@username", selectedUser);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32("user_id");
                        }
                    }
                }
                if (userId == -1)
                {
                    MessageBox.Show("User not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving user ID: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string getBooksQuery = @"
        SELECT books.title 
        FROM checked_out 
        INNER JOIN books ON checked_out.book_id = books.id 
        WHERE checked_out.user_id = @userId";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(getBooksQuery, myConnection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        checkedoutBooks_list.Items.Clear(); // Clear previous entries

                        while (reader.Read())
                        {
                            checkedoutBooks_list.Items.Add(reader.GetString("title")); // Add book titles to the list
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading checked-out books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkout_button_Click(object sender, EventArgs e)
        {
            if (books_listbox.SelectedItem == null)
            {
                MessageBox.Show("Please select a book to check out.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (member_combobox.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to check out the book.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedBook = books_listbox.SelectedItem.ToString();
            string selectedUser = member_combobox.SelectedItem.ToString();

            // Step 1: Get book_id from books table
            string getBookIdQuery = "SELECT id FROM books WHERE title = @title";
            int bookId = -1;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(getBookIdQuery, myConnection))
                {
                    cmd.Parameters.AddWithValue("@title", selectedBook);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bookId = reader.GetInt32("id");
                        }
                    }
                }

                if (bookId == -1)
                {
                    MessageBox.Show("Book not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving book ID: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 2: Get user_id from users table
            string getUserIdQuery = "SELECT user_id FROM users WHERE username = @username";
            int userId = -1;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(getUserIdQuery, myConnection))
                {
                    cmd.Parameters.AddWithValue("@username", selectedUser);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32("user_id");
                        }
                    }
                }

                if (userId == -1)
                {
                    MessageBox.Show("User not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving user ID: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 3: Insert into checked_out table
            string checkoutQuery = "INSERT INTO checked_out (user_id, book_id, checkout_date) VALUES (@userId, @bookId, NOW())";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(checkoutQuery, myConnection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@bookId", bookId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"'{selectedBook}' has been checked out to {selectedUser}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Book checkout failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking out book: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkIn_button_Click(object sender, EventArgs e)
        {
            if (members_listbox.SelectedItem == null)
            {
                MessageBox.Show("Please select a user.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkedoutBooks_list.SelectedItem == null)
            {
                MessageBox.Show("Please select a book to check in.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedUser = members_listbox.SelectedItem.ToString();
            string selectedBook = checkedoutBooks_list.SelectedItem.ToString();

            // Step 1: Get user_id from the users table
            string getUserIdQuery = "SELECT user_id FROM users WHERE username = @username";
            int userId = -1;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(getUserIdQuery, myConnection))
                {
                    cmd.Parameters.AddWithValue("@username", selectedUser);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32("user_id");
                        }
                    }
                }

                if (userId == -1)
                {
                    MessageBox.Show("User not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving user ID: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 2: Get book_id from the books table
            string getBookIdQuery = "SELECT id FROM books WHERE title = @title";
            int bookId = -1;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(getBookIdQuery, myConnection))
                {
                    cmd.Parameters.AddWithValue("@title", selectedBook);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bookId = reader.GetInt32("id");
                        }
                    }
                }

                if (bookId == -1)
                {
                    MessageBox.Show("Book not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving book ID: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 3: Remove the record from the checked_out table (Check In)
            string checkInQuery = "DELETE FROM checked_out WHERE user_id = @userId AND book_id = @bookId";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(checkInQuery, myConnection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@bookId", bookId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"'{selectedBook}' has been checked in for {selectedUser}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh checked-out books list for the selected user
                        loadcheckedout_button_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Check-in failed. The book may not be checked out to this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking in book: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void overduebooks_btn_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT books.title, users.username, checked_out.checkout_date 
        FROM checked_out
        INNER JOIN books ON checked_out.book_id = books.id
        INNER JOIN users ON checked_out.user_id = users.user_id
        WHERE DATEDIFF(NOW(), checked_out.checkout_date) > 14";  // Overdue books

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, myConnection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    checkedoutBooks_list.Items.Clear(); // Clear previous entries

                    while (reader.Read())
                    {
                        string bookTitle = reader.GetString("title");
                        string borrower = reader.GetString("username");
                        string checkoutDate = reader.GetDateTime("checkout_date").ToString("yyyy-MM-dd");

                        checkedoutBooks_list.Items.Add($"{bookTitle} - {borrower} (Checked out: {checkoutDate})");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading overdue books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

		private void ScanButton_Click(object sender, EventArgs e)
		{
			 try
			{
				using (OpenFileDialog dlg = new OpenFileDialog())
				{
					dlg.Filter = "PNG files|*.png|All images|*.jpg;*.bmp;*.png";
					dlg.Title = "Select an ISBN‑13 barcode image";

					if (dlg.ShowDialog() != DialogResult.OK)
						return;

					// Instantiate and call your BarcodeScanner
					BarcodeScanner scanner = new BarcodeScanner();
					string isbn = scanner.Scan(dlg.FileName);

					MessageBox.Show(
						"Scanned ISBN: " + isbn,
						"Success",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error: " + ex.Message,
					"Scan Failed",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}

        private void search_button_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT * 
        FROM books
        WHERE  title LIKE @searchText";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@searchText", "%" + titlesearch_tb.Text + "%");
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        books_listbox.Items.Clear(); // Clear previous entries
                        while (reader.Read())
                        {
                            string bookTitle = reader.GetString("title");
                            books_listbox.Items.Add(bookTitle); // Add book title to ListBox
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadall_btn_Click(object sender, EventArgs e)
        {
            LoadBookTitles(); // Reload all book titles
        }

        private void exportoverdue_btn_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT books.title, users.username, checked_out.checkout_date 
                FROM checked_out
                INNER JOIN books ON checked_out.book_id = books.id
                INNER JOIN users ON checked_out.user_id = users.user_id
                WHERE DATEDIFF(NOW(), checked_out.checkout_date) > 14";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, myConnection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("No overdue books to export.");
                        return;
                    }

                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveDialog.FileName = "OverdueBooks.csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                        {
                            writer.WriteLine("Title,Username,Checkout Date");

                            while (reader.Read())
                            {
                                string bookTitle = reader.GetString("title").Replace(",", " ");
                                string borrower = reader.GetString("username").Replace(",", " ");
                                string checkoutDate = reader.GetDateTime("checkout_date").ToString("yyyy-MM-dd");

                                writer.WriteLine($"{bookTitle},{borrower},{checkoutDate}");
                            }
                        }

                        MessageBox.Show("Overdue books exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting overdue books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}