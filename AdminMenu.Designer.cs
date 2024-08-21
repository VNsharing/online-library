namespace Online_Library_Test
{
    partial class AdminMenu
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
            this.lblcustomer = new System.Windows.Forms.LinkLabel();
            this.lblBooks = new System.Windows.Forms.LinkLabel();
            this.lblAuthors = new System.Windows.Forms.LinkLabel();
            this.lblCategory = new System.Windows.Forms.LinkLabel();
            this.lblBookAuthor = new System.Windows.Forms.LinkLabel();
            this.lblBookCategory = new System.Windows.Forms.LinkLabel();
            this.lblBookBorrow = new System.Windows.Forms.LinkLabel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblcustomer
            // 
            this.lblcustomer.AutoSize = true;
            this.lblcustomer.LinkColor = System.Drawing.Color.Blue;
            this.lblcustomer.Location = new System.Drawing.Point(57, 55);
            this.lblcustomer.Name = "lblcustomer";
            this.lblcustomer.Size = new System.Drawing.Size(146, 16);
            this.lblcustomer.TabIndex = 1;
            this.lblcustomer.TabStop = true;
            this.lblcustomer.Text = "Customer Management";
            this.lblcustomer.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblcustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblcustomer_LinkClicked);
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Location = new System.Drawing.Point(57, 90);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(46, 16);
            this.lblBooks.TabIndex = 2;
            this.lblBooks.TabStop = true;
            this.lblBooks.Text = "Books";
            this.lblBooks.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblBooks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBooks_LinkClicked);
            // 
            // lblAuthors
            // 
            this.lblAuthors.AutoSize = true;
            this.lblAuthors.Location = new System.Drawing.Point(57, 125);
            this.lblAuthors.Name = "lblAuthors";
            this.lblAuthors.Size = new System.Drawing.Size(52, 16);
            this.lblAuthors.TabIndex = 3;
            this.lblAuthors.TabStop = true;
            this.lblAuthors.Text = "Authors";
            this.lblAuthors.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblAuthors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAuthors_LinkClicked);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(57, 161);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(62, 16);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.TabStop = true;
            this.lblCategory.Text = "Category";
            this.lblCategory.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCategory_LinkClicked);
            // 
            // lblBookAuthor
            // 
            this.lblBookAuthor.AutoSize = true;
            this.lblBookAuthor.Location = new System.Drawing.Point(57, 204);
            this.lblBookAuthor.Name = "lblBookAuthor";
            this.lblBookAuthor.Size = new System.Drawing.Size(80, 16);
            this.lblBookAuthor.TabIndex = 5;
            this.lblBookAuthor.TabStop = true;
            this.lblBookAuthor.Text = "Book Author";
            this.lblBookAuthor.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblBookAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBookAuthor_LinkClicked);
            // 
            // lblBookCategory
            // 
            this.lblBookCategory.AutoSize = true;
            this.lblBookCategory.Location = new System.Drawing.Point(57, 246);
            this.lblBookCategory.Name = "lblBookCategory";
            this.lblBookCategory.Size = new System.Drawing.Size(97, 16);
            this.lblBookCategory.TabIndex = 6;
            this.lblBookCategory.TabStop = true;
            this.lblBookCategory.Text = "Book Category";
            this.lblBookCategory.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblBookCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBookCategory_LinkClicked);
            // 
            // lblBookBorrow
            // 
            this.lblBookBorrow.AutoSize = true;
            this.lblBookBorrow.Location = new System.Drawing.Point(57, 289);
            this.lblBookBorrow.Name = "lblBookBorrow";
            this.lblBookBorrow.Size = new System.Drawing.Size(95, 16);
            this.lblBookBorrow.TabIndex = 7;
            this.lblBookBorrow.TabStop = true;
            this.lblBookBorrow.Text = "Borrow a Book";
            this.lblBookBorrow.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lblBookBorrow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBookBorrow_LinkClicked);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(60, 354);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(101, 40);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblUser.Location = new System.Drawing.Point(462, 28);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 24);
            this.lblUser.TabIndex = 9;
            this.lblUser.Text = "User: ";
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblBookBorrow);
            this.Controls.Add(this.lblBookCategory);
            this.Controls.Add(this.lblBookAuthor);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblAuthors);
            this.Controls.Add(this.lblBooks);
            this.Controls.Add(this.lblcustomer);
            this.Name = "AdminMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.AdminMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblcustomer;
        private System.Windows.Forms.LinkLabel lblBooks;
        private System.Windows.Forms.LinkLabel lblAuthors;
        private System.Windows.Forms.LinkLabel lblCategory;
        private System.Windows.Forms.LinkLabel lblBookAuthor;
        private System.Windows.Forms.LinkLabel lblBookCategory;
        private System.Windows.Forms.LinkLabel lblBookBorrow;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblUser;
    }
}