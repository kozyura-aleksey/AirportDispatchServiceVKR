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
    /// Класс для работы с формой формирования отчета
    /// </summary>
    public partial class ReportForm : Form
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ReportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие на загрузку отчета в форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "DayPlanDataSet.Day_Plan". При необходимости она может быть перемещена или удалена.
            this.Day_PlanTableAdapter.Fill(this.DayPlanDataSet.Day_Plan);   
            this.reportViewerDayPlan.RefreshReport();
        }
    }
}
