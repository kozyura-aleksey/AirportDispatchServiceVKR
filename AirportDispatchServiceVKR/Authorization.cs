using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AirportDispatchServiceVKR
{
    //Тема ВКР: Разработка клиент-серверного приложения для управления диспетчерской службы аэропорта
    //Студент: Козюра А.А., 09.03.04, 6413
    //Руководитель: Каширин И. Ю., профессор кафедры ВПМ РГРТУ, д.т.н.
    /// <summary>
    /// Класс для работы с формой авторизации
    /// </summary>
    public partial class Authorization : Form
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Authorization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие на нажатие кнопки "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Событие на нажатие кнопки "Найти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-2KT3E73;Initial Catalog=AiportVKR;Integrated Security=True;");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Count(*) FROM Administrators where Login= '" + textBox1.Text + "' and Password ='" + textBox2.Text + "'", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            QueryGenerator.nameLogin = textBox1.Text.ToString();
            if (dataTable.Rows[0][0].ToString() == "1") {
                this.Hide();
                Main main = new Main();
                main.Show();
            } else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            textBox2.UseSystemPasswordChar = true;            
        }
    }
}
