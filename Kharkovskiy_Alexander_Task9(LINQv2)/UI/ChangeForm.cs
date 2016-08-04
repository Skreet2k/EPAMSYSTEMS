using System;
using System.Windows.Forms;

namespace UI
{
    public partial class ChangeForm : Form
    {
        public ChangeForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Загрузка полей для изменения из строки таблицы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeForm_Load(object sender, EventArgs e)
        {
            var form = Owner;
            var table = (DataGridView)((Panel) form.Controls["panel2"]).Controls["ClientsTable"];
                SurnameTB.Text = table.SelectedRows[0].Cells[0].Value.ToString();
                NameTB.Text = table.SelectedRows[0].Cells[1].Value.ToString();
               PatronymicTB.Text = table.SelectedRows[0].Cells[2].Value.ToString();

            try
            {
                DateOfBirth.Text = table.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"У клиента была установленная некоректная дата рождения! {ex.Message}");
                DateOfBirth.Value = DateTime.Now;
            }
            BankNameTB.Text = table.SelectedRows[0].Cells[4].Value.ToString();
            
        }
        /// <summary>
        /// Изменение строки на новые значения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SafeButton_Click(object sender, EventArgs e)
        {
            var form = Owner;
            var table = (DataGridView)((Panel)form.Controls["panel2"]).Controls["ClientsTable"];
            table.SelectedRows[0].SetValues(SurnameTB.Text, NameTB.Text, PatronymicTB.Text, DateOfBirth.Text, BankNameTB.Text);
            Close();
        }
    }
}
