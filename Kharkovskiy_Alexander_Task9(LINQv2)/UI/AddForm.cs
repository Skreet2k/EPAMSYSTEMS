using System;
using System.Windows.Forms;

namespace UI
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Добавление в таблицу ClientTable новой строки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var form = Owner;
            var table = (DataGridView)((Panel)form.Controls["panel2"]).Controls["ClientsTable"];
            table.Rows.Add(SurnameTB.Text, NameTB.Text, PatronymicTB.Text, BirthDate.Text, BankNameTB.Text);
            Close();
        }
    }
}
