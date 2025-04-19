namespace WindowsFormsApp1
{
    partial class Form1
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.books_listbox = new System.Windows.Forms.ListBox();
			this.bookCover_picturebox = new System.Windows.Forms.PictureBox();
			this.author_tb = new System.Windows.Forms.TextBox();
			this.genre_tb = new System.Windows.Forms.TextBox();
			this.description_tb = new System.Windows.Forms.TextBox();
			this.viewCheckedOut_button = new System.Windows.Forms.Button();
			this.library_tabs = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.bookfilter_combo = new System.Windows.Forms.ComboBox();
			this.checkout_button = new System.Windows.Forms.Button();
			this.member_combobox = new System.Windows.Forms.ComboBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.overduebooks_btn = new System.Windows.Forms.Button();
			this.checkIn_button = new System.Windows.Forms.Button();
			this.loadcheckedout_button = new System.Windows.Forms.Button();
			this.checkedoutBooks_list = new System.Windows.Forms.ListBox();
			this.email_lbl = new System.Windows.Forms.Label();
			this.email_tb = new System.Windows.Forms.TextBox();
			this.members_listbox = new System.Windows.Forms.ListBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.ScanButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.bookCover_picturebox)).BeginInit();
			this.library_tabs.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1067, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// books_listbox
			// 
			this.books_listbox.FormattingEnabled = true;
			this.books_listbox.ItemHeight = 16;
			this.books_listbox.Location = new System.Drawing.Point(81, 60);
			this.books_listbox.Margin = new System.Windows.Forms.Padding(4);
			this.books_listbox.Name = "books_listbox";
			this.books_listbox.Size = new System.Drawing.Size(279, 324);
			this.books_listbox.TabIndex = 1;
			this.books_listbox.SelectedIndexChanged += new System.EventHandler(this.books_listbox_SelectedIndexChanged);
			// 
			// bookCover_picturebox
			// 
			this.bookCover_picturebox.Location = new System.Drawing.Point(369, 60);
			this.bookCover_picturebox.Margin = new System.Windows.Forms.Padding(4);
			this.bookCover_picturebox.Name = "bookCover_picturebox";
			this.bookCover_picturebox.Size = new System.Drawing.Size(265, 325);
			this.bookCover_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.bookCover_picturebox.TabIndex = 2;
			this.bookCover_picturebox.TabStop = false;
			// 
			// author_tb
			// 
			this.author_tb.Location = new System.Drawing.Point(744, 60);
			this.author_tb.Margin = new System.Windows.Forms.Padding(4);
			this.author_tb.Multiline = true;
			this.author_tb.Name = "author_tb";
			this.author_tb.Size = new System.Drawing.Size(259, 29);
			this.author_tb.TabIndex = 3;
			// 
			// genre_tb
			// 
			this.genre_tb.Location = new System.Drawing.Point(744, 97);
			this.genre_tb.Margin = new System.Windows.Forms.Padding(4);
			this.genre_tb.Multiline = true;
			this.genre_tb.Name = "genre_tb";
			this.genre_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.genre_tb.Size = new System.Drawing.Size(259, 112);
			this.genre_tb.TabIndex = 4;
			// 
			// description_tb
			// 
			this.description_tb.Location = new System.Drawing.Point(745, 218);
			this.description_tb.Margin = new System.Windows.Forms.Padding(4);
			this.description_tb.Multiline = true;
			this.description_tb.Name = "description_tb";
			this.description_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.description_tb.Size = new System.Drawing.Size(257, 166);
			this.description_tb.TabIndex = 6;
			// 
			// viewCheckedOut_button
			// 
			this.viewCheckedOut_button.Location = new System.Drawing.Point(784, 426);
			this.viewCheckedOut_button.Margin = new System.Windows.Forms.Padding(4);
			this.viewCheckedOut_button.Name = "viewCheckedOut_button";
			this.viewCheckedOut_button.Size = new System.Drawing.Size(161, 27);
			this.viewCheckedOut_button.TabIndex = 8;
			this.viewCheckedOut_button.Text = "View Checked Out By";
			this.viewCheckedOut_button.UseVisualStyleBackColor = true;
			this.viewCheckedOut_button.Click += new System.EventHandler(this.viewCheckedOut_button_Click);
			// 
			// library_tabs
			// 
			this.library_tabs.Controls.Add(this.tabPage1);
			this.library_tabs.Controls.Add(this.tabPage2);
			this.library_tabs.Controls.Add(this.tabPage3);
			this.library_tabs.Location = new System.Drawing.Point(1, 7);
			this.library_tabs.Margin = new System.Windows.Forms.Padding(4);
			this.library_tabs.Name = "library_tabs";
			this.library_tabs.SelectedIndex = 0;
			this.library_tabs.Size = new System.Drawing.Size(1064, 546);
			this.library_tabs.TabIndex = 9;
			this.library_tabs.SelectedIndexChanged += new System.EventHandler(this.librarytabs_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.bookfilter_combo);
			this.tabPage1.Controls.Add(this.checkout_button);
			this.tabPage1.Controls.Add(this.member_combobox);
			this.tabPage1.Controls.Add(this.books_listbox);
			this.tabPage1.Controls.Add(this.viewCheckedOut_button);
			this.tabPage1.Controls.Add(this.bookCover_picturebox);
			this.tabPage1.Controls.Add(this.author_tb);
			this.tabPage1.Controls.Add(this.description_tb);
			this.tabPage1.Controls.Add(this.genre_tb);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage1.Size = new System.Drawing.Size(1056, 517);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Book List";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(656, 222);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 16);
			this.label3.TabIndex = 14;
			this.label3.Text = "Description";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(685, 101);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "Genres";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(685, 64);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "Author";
			// 
			// bookfilter_combo
			// 
			this.bookfilter_combo.FormattingEnabled = true;
			this.bookfilter_combo.Location = new System.Drawing.Point(81, 18);
			this.bookfilter_combo.Margin = new System.Windows.Forms.Padding(4);
			this.bookfilter_combo.Name = "bookfilter_combo";
			this.bookfilter_combo.Size = new System.Drawing.Size(277, 24);
			this.bookfilter_combo.TabIndex = 11;
			this.bookfilter_combo.Text = "Book Filters";
			// 
			// checkout_button
			// 
			this.checkout_button.Location = new System.Drawing.Point(108, 428);
			this.checkout_button.Margin = new System.Windows.Forms.Padding(4);
			this.checkout_button.Name = "checkout_button";
			this.checkout_button.Size = new System.Drawing.Size(205, 26);
			this.checkout_button.TabIndex = 10;
			this.checkout_button.Text = "Click To Check Out For:";
			this.checkout_button.UseVisualStyleBackColor = true;
			this.checkout_button.Click += new System.EventHandler(this.checkout_button_Click);
			// 
			// member_combobox
			// 
			this.member_combobox.FormattingEnabled = true;
			this.member_combobox.Location = new System.Drawing.Point(336, 428);
			this.member_combobox.Margin = new System.Windows.Forms.Padding(4);
			this.member_combobox.Name = "member_combobox";
			this.member_combobox.Size = new System.Drawing.Size(297, 24);
			this.member_combobox.TabIndex = 9;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.overduebooks_btn);
			this.tabPage2.Controls.Add(this.checkIn_button);
			this.tabPage2.Controls.Add(this.loadcheckedout_button);
			this.tabPage2.Controls.Add(this.checkedoutBooks_list);
			this.tabPage2.Controls.Add(this.email_lbl);
			this.tabPage2.Controls.Add(this.email_tb);
			this.tabPage2.Controls.Add(this.members_listbox);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage2.Size = new System.Drawing.Size(1056, 517);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Members";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// overduebooks_btn
			// 
			this.overduebooks_btn.Location = new System.Drawing.Point(445, 380);
			this.overduebooks_btn.Margin = new System.Windows.Forms.Padding(4);
			this.overduebooks_btn.Name = "overduebooks_btn";
			this.overduebooks_btn.Size = new System.Drawing.Size(192, 38);
			this.overduebooks_btn.TabIndex = 11;
			this.overduebooks_btn.Text = "Get Overdue Books";
			this.overduebooks_btn.UseVisualStyleBackColor = true;
			this.overduebooks_btn.Click += new System.EventHandler(this.overduebooks_btn_Click);
			// 
			// checkIn_button
			// 
			this.checkIn_button.Location = new System.Drawing.Point(445, 426);
			this.checkIn_button.Margin = new System.Windows.Forms.Padding(4);
			this.checkIn_button.Name = "checkIn_button";
			this.checkIn_button.Size = new System.Drawing.Size(192, 38);
			this.checkIn_button.TabIndex = 10;
			this.checkIn_button.Text = "Check In Book For User";
			this.checkIn_button.UseVisualStyleBackColor = true;
			this.checkIn_button.Click += new System.EventHandler(this.checkIn_button_Click);
			// 
			// loadcheckedout_button
			// 
			this.loadcheckedout_button.Location = new System.Drawing.Point(479, 46);
			this.loadcheckedout_button.Margin = new System.Windows.Forms.Padding(4);
			this.loadcheckedout_button.Name = "loadcheckedout_button";
			this.loadcheckedout_button.Size = new System.Drawing.Size(159, 52);
			this.loadcheckedout_button.TabIndex = 9;
			this.loadcheckedout_button.Text = "Load Checked Out Books";
			this.loadcheckedout_button.UseVisualStyleBackColor = true;
			this.loadcheckedout_button.Click += new System.EventHandler(this.loadcheckedout_button_Click);
			// 
			// checkedoutBooks_list
			// 
			this.checkedoutBooks_list.FormattingEnabled = true;
			this.checkedoutBooks_list.ItemHeight = 16;
			this.checkedoutBooks_list.Location = new System.Drawing.Point(645, 27);
			this.checkedoutBooks_list.Margin = new System.Windows.Forms.Padding(4);
			this.checkedoutBooks_list.Name = "checkedoutBooks_list";
			this.checkedoutBooks_list.Size = new System.Drawing.Size(397, 436);
			this.checkedoutBooks_list.TabIndex = 8;
			// 
			// email_lbl
			// 
			this.email_lbl.AutoSize = true;
			this.email_lbl.Location = new System.Drawing.Point(241, 36);
			this.email_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.email_lbl.Name = "email_lbl";
			this.email_lbl.Size = new System.Drawing.Size(41, 16);
			this.email_lbl.TabIndex = 7;
			this.email_lbl.Text = "Email";
			// 
			// email_tb
			// 
			this.email_tb.Location = new System.Drawing.Point(243, 60);
			this.email_tb.Margin = new System.Windows.Forms.Padding(4);
			this.email_tb.Name = "email_tb";
			this.email_tb.Size = new System.Drawing.Size(227, 22);
			this.email_tb.TabIndex = 1;
			// 
			// members_listbox
			// 
			this.members_listbox.FormattingEnabled = true;
			this.members_listbox.ItemHeight = 16;
			this.members_listbox.Location = new System.Drawing.Point(9, 33);
			this.members_listbox.Margin = new System.Windows.Forms.Padding(4);
			this.members_listbox.Name = "members_listbox";
			this.members_listbox.Size = new System.Drawing.Size(167, 212);
			this.members_listbox.TabIndex = 0;
			this.members_listbox.SelectedIndexChanged += new System.EventHandler(this.members_listbox_SelectedIndexChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.ScanButton);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(1056, 517);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Barcode Scanner";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// printDialog1
			// 
			this.printDialog1.UseEXDialog = true;
			// 
			// ScanButton
			// 
			this.ScanButton.Location = new System.Drawing.Point(421, 403);
			this.ScanButton.Name = "ScanButton";
			this.ScanButton.Size = new System.Drawing.Size(131, 53);
			this.ScanButton.TabIndex = 0;
			this.ScanButton.Text = "Scan";
			this.ScanButton.UseVisualStyleBackColor = true;
			this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1067, 554);
			this.Controls.Add(this.library_tabs);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Library Management System";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.bookCover_picturebox)).EndInit();
			this.library_tabs.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListBox books_listbox;
        private System.Windows.Forms.PictureBox bookCover_picturebox;
        private System.Windows.Forms.TextBox author_tb;
        private System.Windows.Forms.TextBox genre_tb;
        private System.Windows.Forms.TextBox description_tb;
        private System.Windows.Forms.Button viewCheckedOut_button;
        private System.Windows.Forms.TabControl library_tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox members_listbox;
        private System.Windows.Forms.TextBox email_tb;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label email_lbl;
        private System.Windows.Forms.Button loadcheckedout_button;
        private System.Windows.Forms.ListBox checkedoutBooks_list;
        private System.Windows.Forms.ComboBox member_combobox;
        private System.Windows.Forms.Button checkout_button;
        private System.Windows.Forms.Button checkIn_button;
        private System.Windows.Forms.ComboBox bookfilter_combo;
        private System.Windows.Forms.Button overduebooks_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button ScanButton;
	}
}

