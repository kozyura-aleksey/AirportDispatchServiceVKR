using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportDispatchServiceVKR
{
    //Тема ВКР: Разработка клиент-серверного приложения для управления диспетчерской службы аэропорта
    //Студент: Козюра А.А., 09.03.04, 6413
    //Руководитель: Каширин И. Ю., профессор кафедры ВПМ РГРТУ, д.т.н.
    /// <summary>
    /// Класс для работы с формой поиска пассажиров
    /// </summary>
    public partial class PassengerSearchForm : Form
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PassengerSearchForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие на нажатие кнопки "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Событие на нажатие кнопки "Найти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Main main = this.Owner as Main;
            if (main != null)
            {
                for (int i = 0; i < main.dataGridViewPassengers.RowCount; i++)
                {
                    main.dataGridViewPassengers.Rows[i].Selected = false;
                    for (int j = 0; j < main.dataGridViewPassengers.ColumnCount; j++)
                        if (main.dataGridViewPassengers.Rows[i].Cells[j].Value != null)
                            if (main.dataGridViewPassengers.Rows[i].Cells[j].Value.ToString().Contains(textBoxSearchPassenger.Text))
                            {
                                main.dataGridViewPassengers.Rows[i].Selected = true;
                                break;
                            }
                }
            }
        }
    }
}
