using System;
using System.Windows.Forms;

namespace UI
{
    public partial class SafeForm : Form
    {
        public SafeForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Сохранение таблицы в XML файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SafeFileXmlButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PathXmlTB.Text))
            {
                var form = Owner;
                var table = (DataGridView) ((Panel) form.Controls["panel2"]).Controls["ClientsTable"];
                var cl = new BL.ClientsLogic();
                cl.SafeListOfClientToXml(TableService.TableToList(table), PathXmlTB.Text);
                MessageBox.Show(@"Успешно сохранено!");
            }
            else
                MessageBox.Show(@"Некорректный путь до файла .xml");
        }
        /// <summary>
        /// Сохранение таблицы в TXT файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SafeFileTxtButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PathXmlTB.Text))
            {
                var form = Owner;
                var table = (DataGridView) ((Panel) form.Controls["panel2"]).Controls["ClientsTable"];
                var cl = new BL.ClientsLogic();
                cl.SafeListOfClientToTxt(TableService.TableToList(table), PathTxtTB.Text);
                MessageBox.Show(@"Успешно сохранено!");
            }
            else
                MessageBox.Show(@"Некорректный путь до файла .txt");

        }
        /// <summary>
        /// Получение пути к файлу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathXmlTB_Enter(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Filter = @"XML файл|*.xml" };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            PathXmlTB.Text = ofd.FileName;
        }
        /// <summary>
        /// Получение пути к файлу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PathTxtTB_Enter(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Filter = @"Текстовый файл|*.txt" };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            PathTxtTB.Text = ofd.FileName;
        }
        /// <summary>
        /// Закрытие формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
