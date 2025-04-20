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
            this.ScanButton = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.titlesearch_tb = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.search_lbl = new System.Windows.Forms.Label();
            this.loadall_btn = new System.Windows.Forms.Button();
            this.exportoverdue_btn = new System.Windows.Forms.Button();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // books_listbox
            // 
            this.books_listbox.FormattingEnabled = true;
            this.books_listbox.Location = new System.Drawing.Point(61, 49);
            this.books_listbox.Name = "books_listbox";
            this.books_listbox.Size = new System.Drawing.Size(210, 264);
            this.books_listbox.TabIndex = 1;
            this.books_listbox.SelectedIndexChanged += new System.EventHandler(this.books_listbox_SelectedIndexChanged);
            // 
            // bookCover_picturebox
            // 
            this.bookCover_picturebox.Location = new System.Drawing.Point(277, 49);
            this.bookCover_picturebox.Name = "bookCover_picturebox";
            this.bookCover_picturebox.Size = new System.Drawing.Size(199, 264);
            this.bookCover_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bookCover_picturebox.TabIndex = 2;
            this.bookCover_picturebox.TabStop = false;
            // 
            // author_tb
            // 
            this.author_tb.Location = new System.Drawing.Point(558, 49);
            this.author_tb.Multiline = true;
            this.author_tb.Name = "author_tb";
            this.author_tb.Size = new System.Drawing.Size(195, 24);
            this.author_tb.TabIndex = 3;
            // 
            // genre_tb
            // 
            this.genre_tb.Location = new System.Drawing.Point(558, 79);
            this.genre_tb.Multiline = true;
            this.genre_tb.Name = "genre_tb";
            this.genre_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.genre_tb.Size = new System.Drawing.Size(195, 50);
            this.genre_tb.TabIndex = 4;
            // 
            // description_tb
            // 
            this.description_tb.Location = new System.Drawing.Point(558, 135);
            this.description_tb.Multiline = true;
            this.description_tb.Name = "description_tb";
            this.description_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.description_tb.Size = new System.Drawing.Size(194, 136);
            this.description_tb.TabIndex = 6;
            // 
            // viewCheckedOut_button
            // 
            this.viewCheckedOut_button.Location = new System.Drawing.Point(588, 346);
            this.viewCheckedOut_button.Name = "viewCheckedOut_button";
            this.viewCheckedOut_button.Size = new System.Drawing.Size(121, 22);
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
            this.library_tabs.Location = new System.Drawing.Point(1, 6);
            this.library_tabs.Name = "library_tabs";
            this.library_tabs.SelectedIndex = 0;
            this.library_tabs.Size = new System.Drawing.Size(798, 444);
            this.library_tabs.TabIndex = 9;
            this.library_tabs.SelectedIndexChanged += new System.EventHandler(this.librarytabs_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.loadall_btn);
            this.tabPage1.Controls.Add(this.search_lbl);
            this.tabPage1.Controls.Add(this.search_button);
            this.tabPage1.Controls.Add(this.titlesearch_tb);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.checkout_button);
            this.tabPage1.Controls.Add(this.member_combobox);
            this.tabPage1.Controls.Add(this.books_listbox);
            this.tabPage1.Controls.Add(this.viewCheckedOut_button);
            this.tabPage1.Controls.Add(this.bookCover_picturebox);
            this.tabPage1.Controls.Add(this.author_tb);
            this.tabPage1.Controls.Add(this.description_tb);
            this.tabPage1.Controls.Add(this.genre_tb);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(790, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Book List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(514, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Genres";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Author";
            // 
            // checkout_button
            // 
            this.checkout_button.Location = new System.Drawing.Point(81, 348);
            this.checkout_button.Name = "checkout_button";
            this.checkout_button.Size = new System.Drawing.Size(154, 21);
            this.checkout_button.TabIndex = 10;
            this.checkout_button.Text = "Click To Check Out For:";
            this.checkout_button.UseVisualStyleBackColor = true;
            this.checkout_button.Click += new System.EventHandler(this.checkout_button_Click);
            // 
            // member_combobox
            // 
            this.member_combobox.FormattingEnabled = true;
            this.member_combobox.Location = new System.Drawing.Point(252, 348);
            this.member_combobox.Name = "member_combobox";
            this.member_combobox.Size = new System.Drawing.Size(224, 21);
            this.member_combobox.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.exportoverdue_btn);
            this.tabPage2.Controls.Add(this.overduebooks_btn);
            this.tabPage2.Controls.Add(this.checkIn_button);
            this.tabPage2.Controls.Add(this.loadcheckedout_button);
            this.tabPage2.Controls.Add(this.checkedoutBooks_list);
            this.tabPage2.Controls.Add(this.email_lbl);
            this.tabPage2.Controls.Add(this.email_tb);
            this.tabPage2.Controls.Add(this.members_listbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(790, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Members";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // overduebooks_btn
            // 
            this.overduebooks_btn.Location = new System.Drawing.Point(334, 145);
            this.overduebooks_btn.Name = "overduebooks_btn";
            this.overduebooks_btn.Size = new System.Drawing.Size(144, 31);
            this.overduebooks_btn.TabIndex = 11;
            this.overduebooks_btn.Text = "Get Overdue Books";
            this.overduebooks_btn.UseVisualStyleBackColor = true;
            this.overduebooks_btn.Click += new System.EventHandler(this.overduebooks_btn_Click);
            // 
            // checkIn_button
            // 
            this.checkIn_button.Location = new System.Drawing.Point(334, 346);
            this.checkIn_button.Name = "checkIn_button";
            this.checkIn_button.Size = new System.Drawing.Size(144, 31);
            this.checkIn_button.TabIndex = 10;
            this.checkIn_button.Text = "Check In Book For User";
            this.checkIn_button.UseVisualStyleBackColor = true;
            this.checkIn_button.Click += new System.EventHandler(this.checkIn_button_Click);
            // 
            // loadcheckedout_button
            // 
            this.loadcheckedout_button.Location = new System.Drawing.Point(359, 37);
            this.loadcheckedout_button.Name = "loadcheckedout_button";
            this.loadcheckedout_button.Size = new System.Drawing.Size(119, 42);
            this.loadcheckedout_button.TabIndex = 9;
            this.loadcheckedout_button.Text = "Load Checked Out Books";
            this.loadcheckedout_button.UseVisualStyleBackColor = true;
            this.loadcheckedout_button.Click += new System.EventHandler(this.loadcheckedout_button_Click);
            // 
            // checkedoutBooks_list
            // 
            this.checkedoutBooks_list.FormattingEnabled = true;
            this.checkedoutBooks_list.Location = new System.Drawing.Point(484, 22);
            this.checkedoutBooks_list.Name = "checkedoutBooks_list";
            this.checkedoutBooks_list.Size = new System.Drawing.Size(299, 355);
            this.checkedoutBooks_list.TabIndex = 8;
            // 
            // email_lbl
            // 
            this.email_lbl.AutoSize = true;
            this.email_lbl.Location = new System.Drawing.Point(181, 29);
            this.email_lbl.Name = "email_lbl";
            this.email_lbl.Size = new System.Drawing.Size(32, 13);
            this.email_lbl.TabIndex = 7;
            this.email_lbl.Text = "Email";
            // 
            // email_tb
            // 
            this.email_tb.Location = new System.Drawing.Point(182, 49);
            this.email_tb.Name = "email_tb";
            this.email_tb.Size = new System.Drawing.Size(171, 20);
            this.email_tb.TabIndex = 1;
            // 
            // members_listbox
            // 
            this.members_listbox.FormattingEnabled = true;
            this.members_listbox.Location = new System.Drawing.Point(7, 27);
            this.members_listbox.Name = "members_listbox";
            this.members_listbox.Size = new System.Drawing.Size(126, 173);
            this.members_listbox.TabIndex = 0;
            this.members_listbox.SelectedIndexChanged += new System.EventHandler(this.members_listbox_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ScanButton);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(790, 418);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Barcode Scanner";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(316, 327);
            this.ScanButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(98, 43);
            this.ScanButton.TabIndex = 0;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // titlesearch_tb
            // 
            this.titlesearch_tb.Location = new System.Drawing.Point(167, 13);
            this.titlesearch_tb.Name = "titlesearch_tb";
            this.titlesearch_tb.Size = new System.Drawing.Size(212, 20);
            this.titlesearch_tb.TabIndex = 15;
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(385, 13);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(54, 20);
            this.search_button.TabIndex = 16;
            this.search_button.Text = "Search";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // search_lbl
            // 
            this.search_lbl.AutoSize = true;
            this.search_lbl.Location = new System.Drawing.Point(70, 17);
            this.search_lbl.Name = "search_lbl";
            this.search_lbl.Size = new System.Drawing.Size(91, 13);
            this.search_lbl.TabIndex = 17;
            this.search_lbl.Text = "Search for a Title:";
            // 
            // loadall_btn
            // 
            this.loadall_btn.Location = new System.Drawing.Point(445, 13);
            this.loadall_btn.Name = "loadall_btn";
            this.loadall_btn.Size = new System.Drawing.Size(94, 19);
            this.loadall_btn.TabIndex = 18;
            this.loadall_btn.Text = "Load All Books";
            this.loadall_btn.UseVisualStyleBackColor = true;
            this.loadall_btn.Click += new System.EventHandler(this.loadall_btn_Click);
            // 
            // exportoverdue_btn
            // 
            this.exportoverdue_btn.Location = new System.Drawing.Point(334, 182);
            this.exportoverdue_btn.Name = "exportoverdue_btn";
            this.exportoverdue_btn.Size = new System.Drawing.Size(144, 31);
            this.exportoverdue_btn.TabIndex = 12;
            this.exportoverdue_btn.Text = "Export Overdue Books";
            this.exportoverdue_btn.UseVisualStyleBackColor = true;
            this.exportoverdue_btn.Click += new System.EventHandler(this.exportoverdue_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.library_tabs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
        private System.Windows.Forms.Button overduebooks_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.Label search_lbl;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox titlesearch_tb;
        private System.Windows.Forms.Button loadall_btn;
        private System.Windows.Forms.Button exportoverdue_btn;
    }
}

