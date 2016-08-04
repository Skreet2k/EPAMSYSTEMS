namespace UI
{
    partial class AddForm
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
            this.AddButton = new System.Windows.Forms.Button();
            this.ClientGroup = new System.Windows.Forms.GroupBox();
            this.SurnameTB = new System.Windows.Forms.TextBox();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.PatronymicTB = new System.Windows.Forms.TextBox();
            this.BankNameTB = new System.Windows.Forms.TextBox();
            this.BirthDate = new System.Windows.Forms.DateTimePicker();
            this.DateOfBirthLB = new System.Windows.Forms.Label();
            this.PatrinymicLB = new System.Windows.Forms.Label();
            this.BankLB = new System.Windows.Forms.Label();
            this.NameLB = new System.Windows.Forms.Label();
            this.SurnameLB = new System.Windows.Forms.Label();
            this.ClientGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(197, 192);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ClientGroup
            // 
            this.ClientGroup.Controls.Add(this.DateOfBirthLB);
            this.ClientGroup.Controls.Add(this.PatrinymicLB);
            this.ClientGroup.Controls.Add(this.BankLB);
            this.ClientGroup.Controls.Add(this.NameLB);
            this.ClientGroup.Controls.Add(this.SurnameLB);
            this.ClientGroup.Controls.Add(this.BirthDate);
            this.ClientGroup.Controls.Add(this.SurnameTB);
            this.ClientGroup.Controls.Add(this.NameTB);
            this.ClientGroup.Controls.Add(this.PatronymicTB);
            this.ClientGroup.Controls.Add(this.BankNameTB);
            this.ClientGroup.Location = new System.Drawing.Point(13, 13);
            this.ClientGroup.Name = "ClientGroup";
            this.ClientGroup.Size = new System.Drawing.Size(259, 173);
            this.ClientGroup.TabIndex = 1;
            this.ClientGroup.TabStop = false;
            this.ClientGroup.Text = "Добавление клиента";
            // 
            // SurnameTB
            // 
            this.SurnameTB.Location = new System.Drawing.Point(101, 28);
            this.SurnameTB.Name = "SurnameTB";
            this.SurnameTB.Size = new System.Drawing.Size(152, 20);
            this.SurnameTB.TabIndex = 14;
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(101, 54);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(152, 20);
            this.NameTB.TabIndex = 15;
            // 
            // PatronymicTB
            // 
            this.PatronymicTB.Location = new System.Drawing.Point(101, 80);
            this.PatronymicTB.Name = "PatronymicTB";
            this.PatronymicTB.Size = new System.Drawing.Size(152, 20);
            this.PatronymicTB.TabIndex = 16;
            // 
            // BankNameTB
            // 
            this.BankNameTB.Location = new System.Drawing.Point(101, 133);
            this.BankNameTB.Name = "BankNameTB";
            this.BankNameTB.Size = new System.Drawing.Size(152, 20);
            this.BankNameTB.TabIndex = 17;
            // 
            // BirthDate
            // 
            this.BirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BirthDate.Location = new System.Drawing.Point(101, 108);
            this.BirthDate.MaxDate = new System.DateTime(2016, 8, 31, 0, 0, 0, 0);
            this.BirthDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.Size = new System.Drawing.Size(152, 20);
            this.BirthDate.TabIndex = 20;
            this.BirthDate.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // DateOfBirthLB
            // 
            this.DateOfBirthLB.AutoSize = true;
            this.DateOfBirthLB.Location = new System.Drawing.Point(7, 111);
            this.DateOfBirthLB.Name = "DateOfBirthLB";
            this.DateOfBirthLB.Size = new System.Drawing.Size(89, 13);
            this.DateOfBirthLB.TabIndex = 29;
            this.DateOfBirthLB.Text = "Дата рождения:";
            // 
            // PatrinymicLB
            // 
            this.PatrinymicLB.AutoSize = true;
            this.PatrinymicLB.Location = new System.Drawing.Point(7, 83);
            this.PatrinymicLB.Name = "PatrinymicLB";
            this.PatrinymicLB.Size = new System.Drawing.Size(57, 13);
            this.PatrinymicLB.TabIndex = 28;
            this.PatrinymicLB.Text = "Отчество:";
            // 
            // BankLB
            // 
            this.BankLB.AutoSize = true;
            this.BankLB.Location = new System.Drawing.Point(6, 136);
            this.BankLB.Name = "BankLB";
            this.BankLB.Size = new System.Drawing.Size(35, 13);
            this.BankLB.TabIndex = 27;
            this.BankLB.Text = "Банк:";
            // 
            // NameLB
            // 
            this.NameLB.AutoSize = true;
            this.NameLB.Location = new System.Drawing.Point(7, 57);
            this.NameLB.Name = "NameLB";
            this.NameLB.Size = new System.Drawing.Size(32, 13);
            this.NameLB.TabIndex = 26;
            this.NameLB.Text = "Имя:";
            // 
            // SurnameLB
            // 
            this.SurnameLB.AutoSize = true;
            this.SurnameLB.Location = new System.Drawing.Point(7, 31);
            this.SurnameLB.Name = "SurnameLB";
            this.SurnameLB.Size = new System.Drawing.Size(59, 13);
            this.SurnameLB.TabIndex = 25;
            this.SurnameLB.Text = "Фамилия:";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 221);
            this.Controls.Add(this.ClientGroup);
            this.Controls.Add(this.AddButton);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.ClientGroup.ResumeLayout(false);
            this.ClientGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.GroupBox ClientGroup;
        private System.Windows.Forms.TextBox SurnameTB;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox PatronymicTB;
        private System.Windows.Forms.TextBox BankNameTB;
        private System.Windows.Forms.DateTimePicker BirthDate;
        private System.Windows.Forms.Label DateOfBirthLB;
        private System.Windows.Forms.Label PatrinymicLB;
        private System.Windows.Forms.Label BankLB;
        private System.Windows.Forms.Label NameLB;
        private System.Windows.Forms.Label SurnameLB;
    }
}