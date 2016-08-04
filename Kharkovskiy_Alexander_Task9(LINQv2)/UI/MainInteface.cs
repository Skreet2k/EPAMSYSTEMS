using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class MainInteface : Form
    {
        public string Path { get; private set; }
        public List<List<string>> Clients { get; private set; }


        public MainInteface()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Открытие текстовго файла и добавление данных в таблицу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileDialogButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog {Filter = @"Текстовые файлы|*.txt"};
            if (ofd.ShowDialog() != DialogResult.OK) return;
            Path = ofd.FileName;
            PathTB.Text = Path;
            Clients = ClientService.ParseClientFromTxt(Path);
            TableService.ListToTable(Clients, ClientsTable);
        }
        /// <summary>
        /// Получение отфильтрованных клиентов в таблице.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptFilterButton_Click(object sender, EventArgs e)
        {
            var clients = ClientService.ClientFilter(Clients, SurnameTB.Text, NameTB.Text, PatronymicTB.Text, BankNameTB.Text);
            TableService.ListToTable(clients, ClientsTable);
        }
        /// <summary>
        /// Изменение строки таблицы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            var selectedRows = ClientsTable.SelectedRows;
            if (selectedRows.Count > 0)
            {
                var form = new ChangeForm
                {
                    Owner = this
                };
                form.Show();
            }

        }
        /// <summary>
        /// Удаление строки таблицы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var selectedRows = ClientsTable.SelectedRows;
            if(selectedRows.Count > 0)
            ClientsTable.Rows.Remove(selectedRows[0]);
        }
        /// <summary>
        /// Добавление строки таблицы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var form = new AddForm()
            {
                Owner = this
            };

            form.Show();
            
        }
        /// <summary>
        /// Сохранение таблицы в файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SafeButton_Click(object sender, EventArgs e)
        {
            var form = new SafeForm
            {
                Owner = this
            };

            form.Show();
        }
    }
}
