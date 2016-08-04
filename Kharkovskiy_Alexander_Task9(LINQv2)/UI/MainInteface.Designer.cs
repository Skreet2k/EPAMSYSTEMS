namespace UI
{
    partial class MainInteface
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OpenFileDialogButton = new System.Windows.Forms.Button();
            this.PathTB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FiltersGroup = new System.Windows.Forms.GroupBox();
            this.AcceptFilterButton = new System.Windows.Forms.Button();
            this.SurnameTB = new System.Windows.Forms.TextBox();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.PatronymicTB = new System.Windows.Forms.TextBox();
            this.BankNameTB = new System.Windows.Forms.TextBox();
            this.FileFilterGroup = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SafeButton = new System.Windows.Forms.Button();
            this.ClientsTable = new System.Windows.Forms.DataGridView();
            this.ClientSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPatronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.SurnameLB = new System.Windows.Forms.Label();
            this.NameLB = new System.Windows.Forms.Label();
            this.BankLB = new System.Windows.Forms.Label();
            this.PatrinymicLB = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.FiltersGroup.SuspendLayout();
            this.FileFilterGroup.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFileDialogButton
            // 
            this.OpenFileDialogButton.Location = new System.Drawing.Point(174, 33);
            this.OpenFileDialogButton.Name = "OpenFileDialogButton";
            this.OpenFileDialogButton.Size = new System.Drawing.Size(78, 23);
            this.OpenFileDialogButton.TabIndex = 0;
            this.OpenFileDialogButton.Text = "Открыть";
            this.OpenFileDialogButton.UseVisualStyleBackColor = true;
            this.OpenFileDialogButton.Click += new System.EventHandler(this.OpenFileDialogButton_Click);
            // 
            // PathTB
            // 
            this.PathTB.Location = new System.Drawing.Point(12, 33);
            this.PathTB.Name = "PathTB";
            this.PathTB.Size = new System.Drawing.Size(156, 20);
            this.PathTB.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FiltersGroup);
            this.panel1.Controls.Add(this.FileFilterGroup);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 274);
            this.panel1.TabIndex = 2;
            // 
            // FiltersGroup
            // 
            this.FiltersGroup.Controls.Add(this.PatrinymicLB);
            this.FiltersGroup.Controls.Add(this.BankLB);
            this.FiltersGroup.Controls.Add(this.NameLB);
            this.FiltersGroup.Controls.Add(this.SurnameLB);
            this.FiltersGroup.Controls.Add(this.AcceptFilterButton);
            this.FiltersGroup.Controls.Add(this.SurnameTB);
            this.FiltersGroup.Controls.Add(this.NameTB);
            this.FiltersGroup.Controls.Add(this.PatronymicTB);
            this.FiltersGroup.Controls.Add(this.BankNameTB);
            this.FiltersGroup.Location = new System.Drawing.Point(12, 78);
            this.FiltersGroup.Name = "FiltersGroup";
            this.FiltersGroup.Size = new System.Drawing.Size(258, 185);
            this.FiltersGroup.TabIndex = 12;
            this.FiltersGroup.TabStop = false;
            this.FiltersGroup.Text = "Фильтры";
            // 
            // AcceptFilterButton
            // 
            this.AcceptFilterButton.Location = new System.Drawing.Point(149, 150);
            this.AcceptFilterButton.Name = "AcceptFilterButton";
            this.AcceptFilterButton.Size = new System.Drawing.Size(103, 23);
            this.AcceptFilterButton.TabIndex = 2;
            this.AcceptFilterButton.Text = "Отфильтровать";
            this.AcceptFilterButton.UseVisualStyleBackColor = true;
            this.AcceptFilterButton.Click += new System.EventHandler(this.AcceptFilterButton_Click);
            // 
            // SurnameTB
            // 
            this.SurnameTB.Location = new System.Drawing.Point(72, 37);
            this.SurnameTB.Name = "SurnameTB";
            this.SurnameTB.Size = new System.Drawing.Size(180, 20);
            this.SurnameTB.TabIndex = 6;
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(72, 63);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(180, 20);
            this.NameTB.TabIndex = 7;
            // 
            // PatronymicTB
            // 
            this.PatronymicTB.Location = new System.Drawing.Point(72, 89);
            this.PatronymicTB.Name = "PatronymicTB";
            this.PatronymicTB.Size = new System.Drawing.Size(180, 20);
            this.PatronymicTB.TabIndex = 8;
            // 
            // BankNameTB
            // 
            this.BankNameTB.Location = new System.Drawing.Point(72, 115);
            this.BankNameTB.Name = "BankNameTB";
            this.BankNameTB.Size = new System.Drawing.Size(180, 20);
            this.BankNameTB.TabIndex = 9;
            // 
            // FileFilterGroup
            // 
            this.FileFilterGroup.Controls.Add(this.PathTB);
            this.FileFilterGroup.Controls.Add(this.OpenFileDialogButton);
            this.FileFilterGroup.Location = new System.Drawing.Point(12, 4);
            this.FileFilterGroup.Name = "FileFilterGroup";
            this.FileFilterGroup.Size = new System.Drawing.Size(258, 68);
            this.FileFilterGroup.TabIndex = 11;
            this.FileFilterGroup.TabStop = false;
            this.FileFilterGroup.Text = "Файл для фильтрации";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SafeButton);
            this.panel2.Controls.Add(this.ClientsTable);
            this.panel2.Controls.Add(this.AddButton);
            this.panel2.Controls.Add(this.DeleteButton);
            this.panel2.Controls.Add(this.ChangeButton);
            this.panel2.Location = new System.Drawing.Point(300, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 274);
            this.panel2.TabIndex = 3;
            // 
            // SafeButton
            // 
            this.SafeButton.Location = new System.Drawing.Point(437, 240);
            this.SafeButton.Name = "SafeButton";
            this.SafeButton.Size = new System.Drawing.Size(78, 23);
            this.SafeButton.TabIndex = 6;
            this.SafeButton.Text = "Сохранить";
            this.SafeButton.UseVisualStyleBackColor = true;
            this.SafeButton.Click += new System.EventHandler(this.SafeButton_Click);
            // 
            // ClientsTable
            // 
            this.ClientsTable.AllowUserToAddRows = false;
            this.ClientsTable.AllowUserToDeleteRows = false;
            this.ClientsTable.AllowUserToResizeColumns = false;
            this.ClientsTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ClientsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ClientsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientsTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ClientsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.ClientsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientSurname,
            this.ClientName,
            this.ClientPatronymic,
            this.ClientBirthday,
            this.BankName});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ClientsTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.ClientsTable.GridColor = System.Drawing.SystemColors.Control;
            this.ClientsTable.Location = new System.Drawing.Point(10, 20);
            this.ClientsTable.MultiSelect = false;
            this.ClientsTable.Name = "ClientsTable";
            this.ClientsTable.ReadOnly = true;
            this.ClientsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ClientsTable.RowHeadersVisible = false;
            this.ClientsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientsTable.Size = new System.Drawing.Size(505, 214);
            this.ClientsTable.TabIndex = 5;
            // 
            // ClientSurname
            // 
            this.ClientSurname.Frozen = true;
            this.ClientSurname.HeaderText = "Фамилия";
            this.ClientSurname.Name = "ClientSurname";
            this.ClientSurname.ReadOnly = true;
            // 
            // ClientName
            // 
            this.ClientName.Frozen = true;
            this.ClientName.HeaderText = "Имя";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // ClientPatronymic
            // 
            this.ClientPatronymic.Frozen = true;
            this.ClientPatronymic.HeaderText = "Отчество";
            this.ClientPatronymic.Name = "ClientPatronymic";
            this.ClientPatronymic.ReadOnly = true;
            // 
            // ClientBirthday
            // 
            this.ClientBirthday.Frozen = true;
            this.ClientBirthday.HeaderText = "Дата рождения";
            this.ClientBirthday.Name = "ClientBirthday";
            this.ClientBirthday.ReadOnly = true;
            this.ClientBirthday.Width = 102;
            // 
            // BankName
            // 
            this.BankName.Frozen = true;
            this.BankName.HeaderText = "Банк";
            this.BankName.Name = "BankName";
            this.BankName.ReadOnly = true;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(213, 240);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(78, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(10, 240);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(78, 23);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.Location = new System.Drawing.Point(111, 240);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(78, 23);
            this.ChangeButton.TabIndex = 2;
            this.ChangeButton.Text = "Изменить";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // SurnameLB
            // 
            this.SurnameLB.AutoSize = true;
            this.SurnameLB.Location = new System.Drawing.Point(6, 40);
            this.SurnameLB.Name = "SurnameLB";
            this.SurnameLB.Size = new System.Drawing.Size(59, 13);
            this.SurnameLB.TabIndex = 10;
            this.SurnameLB.Text = "Фамилия:";
            // 
            // NameLB
            // 
            this.NameLB.AutoSize = true;
            this.NameLB.Location = new System.Drawing.Point(6, 66);
            this.NameLB.Name = "NameLB";
            this.NameLB.Size = new System.Drawing.Size(32, 13);
            this.NameLB.TabIndex = 11;
            this.NameLB.Text = "Имя:";
            // 
            // BankLB
            // 
            this.BankLB.AutoSize = true;
            this.BankLB.Location = new System.Drawing.Point(6, 118);
            this.BankLB.Name = "BankLB";
            this.BankLB.Size = new System.Drawing.Size(35, 13);
            this.BankLB.TabIndex = 12;
            this.BankLB.Text = "Банк:";
            // 
            // PatrinymicLB
            // 
            this.PatrinymicLB.AutoSize = true;
            this.PatrinymicLB.Location = new System.Drawing.Point(6, 92);
            this.PatrinymicLB.Name = "PatrinymicLB";
            this.PatrinymicLB.Size = new System.Drawing.Size(57, 13);
            this.PatrinymicLB.TabIndex = 13;
            this.PatrinymicLB.Text = "Отчество:";
            // 
            // MainInteface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 298);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainInteface";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.FiltersGroup.ResumeLayout(false);
            this.FiltersGroup.PerformLayout();
            this.FileFilterGroup.ResumeLayout(false);
            this.FileFilterGroup.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClientsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenFileDialogButton;
        private System.Windows.Forms.TextBox PathTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox FiltersGroup;
        private System.Windows.Forms.TextBox SurnameTB;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox PatronymicTB;
        private System.Windows.Forms.TextBox BankNameTB;
        private System.Windows.Forms.GroupBox FileFilterGroup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button AcceptFilterButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView ClientsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientPatronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankName;
        private System.Windows.Forms.Button SafeButton;
        private System.Windows.Forms.Label PatrinymicLB;
        private System.Windows.Forms.Label BankLB;
        private System.Windows.Forms.Label NameLB;
        private System.Windows.Forms.Label SurnameLB;
    }
}

