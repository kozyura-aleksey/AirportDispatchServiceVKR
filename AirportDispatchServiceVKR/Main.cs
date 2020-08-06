using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    /// Класс для работы с главной формой 
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Вспомогательный элемент - календарь
        /// </summary>
        DateTimePicker dataTimePicker2 = new DateTimePicker();
        /// <summary>
        /// Вспомогательный элемент - прямоугольник
        /// </summary>
        Rectangle rectangle2;
        /// <summary>
        /// Вспомогательный элемент - календарь
        /// </summary>
        DateTimePicker dataTimePicker3 = new DateTimePicker();
        /// <summary>
        /// Вспомогательный элемент - прямоугольник
        /// </summary>
        Rectangle rectangle3;

        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        public static SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-2KT3E73;Initial Catalog=AiportVKR;Integrated Security=True;");

        /// <summary>
        /// Конструктор
        /// </summary>
        public Main()
        {
            InitializeComponent();
            dataGridViewDayPlan.Controls.Add(dataTimePicker2);
            dataGridViewJournal.Controls.Add(dataTimePicker3);
            dataTimePicker2.Visible = false;
            dataTimePicker2.Format = DateTimePickerFormat.Custom;
            dataTimePicker3.Visible = false;
            dataTimePicker3.Format = DateTimePickerFormat.Custom;
            dataTimePicker2.TextChanged += new EventHandler(dataTimePicker1_TextChange);
            dataTimePicker3.TextChanged += new EventHandler(dataTimePicker2_TextChange);
        }

        /// <summary>
        /// Событие при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            DateTime t1 = new DateTime(2020, 5, 16);
            DateTime t2 = new DateTime(2020, 5, 14);
            DateTime t3 = new DateTime(2020, 5, 17);
            DateTime t4 = new DateTime(2020, 5, 18);
            DateTime t5 = new DateTime(2020, 5, 19);
            DateTime t6 = new DateTime(2020, 5, 20);
            monthCalendar2.AddBoldedDate(t1);
            monthCalendar2.AddBoldedDate(t2);
            monthCalendar2.AddBoldedDate(t3);
            monthCalendar2.AddBoldedDate(t4);
            monthCalendar2.AddBoldedDate(t5);
            monthCalendar2.AddBoldedDate(t6);
            textBoxLogin.Text = QueryGenerator.nameLogin.ToString();
        }

        /// <summary>
        /// Событие при выборе даты из календаря
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            dataGridViewPlanApplicationPlan.Rows.Clear();
            textBox2.Text = monthCalendar2.SelectionStart.ToShortDateString().ToString();
            myConnection.Open();
            String date = monthCalendar2.SelectionStart.ToShortDateString().ToString();

            string query = "SELECT PlanApplicationFlight.Date, Runways.Nimber, NumberFlight.NumberFlight, Weather_Report.Forecast, Weather_Report.Verdict, Airplanes.Airplanes_Name,  Airplanes.Pilot, Airplanes.Serial_Number FROM PlanApplicationFlight JOIN Runways ON PlanApplicationFlight.Runways_ID = Runways.ID JOIN NumberFlight ON PlanApplicationFlight.NumberFlight_ID = NumberFlight.ID JOIN Weather_Report ON PlanApplicationFlight.Wea_Id = Weather_Report.ID JOIN Airplanes ON PlanApplicationFlight.Airplanes_ID = Airplanes.ID WHERE(PlanApplicationFlight.Date = @date)";
            SqlCommand commandShredule = new SqlCommand(query, myConnection);
            // создаем параметр для имени
            SqlParameter nameParam = new SqlParameter("@date", date);
            // добавляем параметр к команде
            commandShredule.Parameters.Add(nameParam);
            SqlDataReader readerShredule = commandShredule.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (readerShredule.Read())
            {
                data.Add(new string[8]);
                data[data.Count - 1][0] = readerShredule[0].ToString();
                data[data.Count - 1][1] = readerShredule[1].ToString();
                data[data.Count - 1][2] = readerShredule[2].ToString();
                data[data.Count - 1][3] = readerShredule[3].ToString();
                data[data.Count - 1][4] = readerShredule[4].ToString();
                data[data.Count - 1][5] = readerShredule[5].ToString();
                data[data.Count - 1][6] = readerShredule[6].ToString();
                data[data.Count - 1][7] = readerShredule[7].ToString();
            }
            readerShredule.Close();
            foreach (string[] s in data)
            {
                dataGridViewPlanApplicationPlan.Rows.Add(s);
            }
            myConnection.Close();
        }

        /// <summary>
        /// Шифровать пароль сепциальными знаками
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox t = e.Control as TextBox;
            if (t != null)
            {
                t.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// Событие при нажатии кнопки "Показать данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonbuttonShowDataAdministrators_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "passengersDataSet.Passengers". При необходимости она может быть перемещена или удалена.
            this.administratorsTableAdapter.Fill(this.administratorsDataSet.Administrators);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Показать данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "passengersDataSet.Passengers". При необходимости она может быть перемещена или удалена.
            this.weather_ReportTableAdapter.Fill(this.weatherReportDataSet.Weather_Report);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Показать данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "airplanesDataSet2.Airplanes". При необходимости она может быть перемещена или удалена.
            this.airplanesTableAdapter.Fill(this.airplanesDataSet2.Airplanes);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Показать данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "passengersDataSet.Passengers". При необходимости она может быть перемещена или удалена.
            this.journalTableAdapter.Fill(this.journalDataSet.Journal);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Показать данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridViewPassengers.Rows.Clear();
            myConnection.Open();
           
            string query = "SELECT Passengers.ID, NumberFlight, Name, Surname, Age, Phone FROM Passengers JOIN NumberFlight ON Passengers.Num_ID = NumberFlight.ID";
            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[6]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
            }
            reader.Close();
            foreach (string[] s in data)
            {
                dataGridViewPassengers.Rows.Add(s);
            }
            myConnection.Close();
        }

        /// <summary>
        /// Событие при нажатии кнопки "Показать данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            this.runwaysTableAdapter.Fill(this.runwaysDataSet.Runways);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Показать данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dayPlanDataSet.Day_Plan". При необходимости она может быть перемещена или удалена.
            this.day_PlanTableAdapter.Fill(this.dayPlanDataSet.Day_Plan);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            this.administratorsTableAdapter.Update(this.administratorsDataSet.Administrators);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            this.airplanesTableAdapter.Update(this.airplanesDataSet2.Airplanes);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            this.journalTableAdapter.Update(this.journalDataSet.Journal);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            this.passengersTableAdapter.Update(this.passengersDataSet.Passengers);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            this.runwaysTableAdapter.Update(this.runwaysDataSet.Runways);
        }

        /// <summary>
        /// Событие при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {           
            this.day_PlanTableAdapter.Update(this.dayPlanDataSet.Day_Plan);
        }

        /// <summary>
        /// Событие на подтверждение удаления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Событие на подтверждение удаления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Событие на подтверждение удаления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Событие на подтверждение удаления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView4_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Событие на подтверждение удаления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView5_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Событие на подтверждение удаления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView6_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Событие на подтверждение удаления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView7_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Событие на подтверждение удаления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView8_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Событие на подтверждение удаления строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView9_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Событие на выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Событие на открытие формы "Авторизация"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void главнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Authorization autorization = new Authorization();
            autorization.Show();
        }

        /// <summary>
        /// Событие на формирование отчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        /// <summary>
        /// Событие на открытие формы поиска самолетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            AirplanesSearchForm airplanesSearchForm = new AirplanesSearchForm();
            airplanesSearchForm.Owner = this;
            airplanesSearchForm.Show();
        }

        /// <summary>
        /// Событие на открытие формы поиска пассажиров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button16_Click(object sender, EventArgs e)
        {
            PassengerSearchForm passengerSearchForm = new PassengerSearchForm();
            passengerSearchForm.Owner = this;
            passengerSearchForm.Show();
        }

        /// <summary>
        /// Событие на открытие формы поиска прогноза погоды
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click(object sender, EventArgs e)
        {
            WeatherReportSearchForm weatherReportSearchForm = new WeatherReportSearchForm();
            weatherReportSearchForm.Owner = this;
            weatherReportSearchForm.Show();
        }
  

        /// <summary>
        /// Событие на подстановку календаря в ячейку "дата" 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridViewDayPlan.Columns[e.ColumnIndex].Name)
            {
                case "dateDataGridViewTextBoxColumn1":
                    rectangle2 = dataGridViewDayPlan.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dataTimePicker2.Size = new Size(rectangle2.Width, rectangle2.Height);
                    dataTimePicker2.Location = new Point(rectangle2.X, rectangle2.Y);
                    dataTimePicker2.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Событие на изменение значения в ячейке "Дата"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataTimePicker1_TextChange(object sender, EventArgs e)
        {
            dataGridViewDayPlan.CurrentCell.Value = dataTimePicker2.Text.ToString();
        }

        /// <summary>
        /// Событие на изменение ширины столбца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView9_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dataTimePicker2.Visible = false;
        }

        /// <summary>
        /// Полоса прокрутки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView9_Scroll(object sender, ScrollEventArgs e)
        {
            dataTimePicker2.Visible = false;
        }

        /// <summary>
        /// Событие на подстановку календаря в ячейку "дата"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridViewJournal.Columns[e.ColumnIndex].Name)
            {
                case "dateDataGridViewTextBoxColumn":
                    rectangle3 = dataGridViewJournal.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dataTimePicker3.Size = new Size(rectangle3.Width, rectangle3.Height);
                    dataTimePicker3.Location = new Point(rectangle3.X, rectangle3.Y);
                    dataTimePicker3.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Событие на изменение значения в ячейке "Дата"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataTimePicker2_TextChange(object sender, EventArgs e)
        {
            dataGridViewJournal.CurrentCell.Value = dataTimePicker3.Text.ToString();
        }

        /// <summary>
        /// Полоса прокрутки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView4_Scroll(object sender, ScrollEventArgs e)
        {
            dataTimePicker3.Visible = false;
        }

        /// <summary>
        /// Событие на изменение ширины столбца
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView4_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dataTimePicker3.Visible = false;
        }

        /// <summary>
        /// Событие на обработку ошибки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView5_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show("Error happened " + e.Context.ToString());            
            object value = dataGridViewNumberFlight.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (!((DataGridViewComboBoxColumn)dataGridViewNumberFlight.Columns[e.ColumnIndex]).Items.Contains(value))
            {
                //((DataGridViewComboBoxColumn)dataGridView6.Columns[e.ColumnIndex]).Items.Add(value);
                e.ThrowException = false;
            }
        }

        /// <summary>
        /// Событие на обработку ошибки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView6_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            object value = dataGridViewPlanApplicationPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (!((DataGridViewComboBoxColumn)dataGridViewPlanApplicationPlan.Columns[e.ColumnIndex]).Items.Contains(value))
            {
                //((DataGridViewComboBoxColumn)dataGridView6.Columns[e.ColumnIndex]).Items.Add(value);
                e.ThrowException = false;
            }
        }

        /// <summary>
        /// Событие при нажатии кнопки "Показать данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "numberFlightDataSet.NumberFlight". При необходимости она может быть перемещена или удалена.
            this.numberFlightTableAdapter.Fill(this.numberFlightDataSet.NumberFlight);
        }

        /// <summary>
        /// Событие на открытие формы поиска по журналу диспетчера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearchJournal_Click(object sender, EventArgs e)
        {
            JournalSearchForm journalSearchForm = new JournalSearchForm();
            journalSearchForm.Owner = this;
            journalSearchForm.Show();
        }

        /// <summary>
        /// Обработка ошибки ввода данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewJournal_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введите данные соответствующих типов");                      
        }

        /// <summary>
        /// Обработка ошибки ввода данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewDayPlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введите данные соответствующих типов");
        }
    }
}
