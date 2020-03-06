namespace NoteApp.UI
{
    partial class AddEditNoteForm
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
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.ChangedDateNote = new System.Windows.Forms.DateTimePicker();
            this.CreatedDateNote = new System.Windows.Forms.DateTimePicker();
            this.Changed = new System.Windows.Forms.Label();
            this.Created = new System.Windows.Forms.Label();
            this.Category = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.TextBoxNote = new System.Windows.Forms.TextBox();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.ComboBoxCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(263, 429);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 3;
            this.OK.Text = "Ok";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(344, 429);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ChangedDateNote
            // 
            this.ChangedDateNote.Enabled = false;
            this.ChangedDateNote.Location = new System.Drawing.Point(296, 65);
            this.ChangedDateNote.Name = "ChangedDateNote";
            this.ChangedDateNote.Size = new System.Drawing.Size(121, 20);
            this.ChangedDateNote.TabIndex = 35;
            // 
            // CreatedDateNote
            // 
            this.CreatedDateNote.Enabled = false;
            this.CreatedDateNote.Location = new System.Drawing.Point(76, 65);
            this.CreatedDateNote.Name = "CreatedDateNote";
            this.CreatedDateNote.Size = new System.Drawing.Size(111, 20);
            this.CreatedDateNote.TabIndex = 34;
            // 
            // Changed
            // 
            this.Changed.AutoSize = true;
            this.Changed.Location = new System.Drawing.Point(237, 68);
            this.Changed.Name = "Changed";
            this.Changed.Size = new System.Drawing.Size(53, 13);
            this.Changed.TabIndex = 33;
            this.Changed.Text = "Changed:";
            // 
            // Created
            // 
            this.Created.AutoSize = true;
            this.Created.Location = new System.Drawing.Point(12, 67);
            this.Created.Name = "Created";
            this.Created.Size = new System.Drawing.Size(47, 13);
            this.Created.TabIndex = 32;
            this.Created.Text = "Created:";
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(12, 41);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(52, 13);
            this.Category.TabIndex = 31;
            this.Category.Text = "Category:";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(12, 15);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(30, 13);
            this.Title.TabIndex = 30;
            this.Title.Text = "Title:";
            // 
            // TextBoxNote
            // 
            this.TextBoxNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxNote.Location = new System.Drawing.Point(12, 91);
            this.TextBoxNote.Multiline = true;
            this.TextBoxNote.Name = "TextBoxNote";
            this.TextBoxNote.Size = new System.Drawing.Size(405, 332);
            this.TextBoxNote.TabIndex = 29;
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(76, 12);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(341, 20);
            this.TextBoxName.TabIndex = 27;
            this.TextBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // ComboBoxCategory
            // 
            this.ComboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCategory.FormattingEnabled = true;
            this.ComboBoxCategory.Location = new System.Drawing.Point(76, 38);
            this.ComboBoxCategory.Name = "ComboBoxCategory";
            this.ComboBoxCategory.Size = new System.Drawing.Size(111, 21);
            this.ComboBoxCategory.TabIndex = 28;
            // 
            // AddEditNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(429, 465);
            this.Controls.Add(this.ChangedDateNote);
            this.Controls.Add(this.CreatedDateNote);
            this.Controls.Add(this.Changed);
            this.Controls.Add(this.Created);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.TextBoxNote);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.ComboBoxCategory);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.MinimumSize = new System.Drawing.Size(445, 503);
            this.Name = "AddEditNoteForm";
            this.Text = "Add/Edit-Note";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.DateTimePicker ChangedDateNote;
        private System.Windows.Forms.DateTimePicker CreatedDateNote;
        private System.Windows.Forms.Label Changed;
        private System.Windows.Forms.Label Created;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox TextBoxNote;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.ComboBox ComboBoxCategory;
    }
}