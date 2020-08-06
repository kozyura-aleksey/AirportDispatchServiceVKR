namespace AirportDispatchServiceVKR
{
    partial class ReportForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Day_PlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DayPlanDataSet = new AirportDispatchServiceVKR.DayPlanDataSet();
            this.Preparatory_shreduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Prepatory_ShreduleDataSet = new AirportDispatchServiceVKR.Prepatory_ShreduleDataSet();
            this.JournalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.JournalDataSet = new AirportDispatchServiceVKR.JournalDataSet();
            this.weatherReportDataSet1 = new AirportDispatchServiceVKR.WeatherReportDataSet();
            this.JournalTableAdapter = new AirportDispatchServiceVKR.JournalDataSetTableAdapters.JournalTableAdapter();
            this.reportViewerDayPlan = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Preparatory_shreduleTableAdapter = new AirportDispatchServiceVKR.Prepatory_ShreduleDataSetTableAdapters.Preparatory_shreduleTableAdapter();
            this.Day_PlanTableAdapter = new AirportDispatchServiceVKR.DayPlanDataSetTableAdapters.Day_PlanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Day_PlanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayPlanDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preparatory_shreduleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prepatory_ShreduleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JournalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JournalDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherReportDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Day_PlanBindingSource
            // 
            this.Day_PlanBindingSource.DataMember = "Day_Plan";
            this.Day_PlanBindingSource.DataSource = this.DayPlanDataSet;
            // 
            // DayPlanDataSet
            // 
            this.DayPlanDataSet.DataSetName = "DayPlanDataSet";
            this.DayPlanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Preparatory_shreduleBindingSource
            // 
            this.Preparatory_shreduleBindingSource.DataMember = "Preparatory_shredule";
            this.Preparatory_shreduleBindingSource.DataSource = this.Prepatory_ShreduleDataSet;
            // 
            // Prepatory_ShreduleDataSet
            // 
            this.Prepatory_ShreduleDataSet.DataSetName = "Prepatory_ShreduleDataSet";
            this.Prepatory_ShreduleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // JournalBindingSource
            // 
            this.JournalBindingSource.DataMember = "Journal";
            this.JournalBindingSource.DataSource = this.JournalDataSet;
            // 
            // JournalDataSet
            // 
            this.JournalDataSet.DataSetName = "JournalDataSet";
            this.JournalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // weatherReportDataSet1
            // 
            this.weatherReportDataSet1.DataSetName = "WeatherReportDataSet";
            this.weatherReportDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // JournalTableAdapter
            // 
            this.JournalTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewerDayPlan
            // 
            this.reportViewerDayPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetDayPlan";
            reportDataSource1.Value = this.Day_PlanBindingSource;
            this.reportViewerDayPlan.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerDayPlan.LocalReport.ReportEmbeddedResource = "AirportDispatchServiceVKR.ReportDayPlan.rdlc";
            this.reportViewerDayPlan.Location = new System.Drawing.Point(0, 0);
            this.reportViewerDayPlan.Name = "reportViewerDayPlan";
            this.reportViewerDayPlan.ServerReport.BearerToken = null;
            this.reportViewerDayPlan.Size = new System.Drawing.Size(800, 450);
            this.reportViewerDayPlan.TabIndex = 0;
            // 
            // Preparatory_shreduleTableAdapter
            // 
            this.Preparatory_shreduleTableAdapter.ClearBeforeFill = true;
            // 
            // Day_PlanTableAdapter
            // 
            this.Day_PlanTableAdapter.ClearBeforeFill = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerDayPlan);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Day_PlanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayPlanDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preparatory_shreduleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Prepatory_ShreduleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JournalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JournalDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weatherReportDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WeatherReportDataSet weatherReportDataSet1;
        private System.Windows.Forms.BindingSource JournalBindingSource;
        private JournalDataSet JournalDataSet;
        private JournalDataSetTableAdapters.JournalTableAdapter JournalTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerDayPlan;
        private System.Windows.Forms.BindingSource Preparatory_shreduleBindingSource;
        private Prepatory_ShreduleDataSet Prepatory_ShreduleDataSet;
        private Prepatory_ShreduleDataSetTableAdapters.Preparatory_shreduleTableAdapter Preparatory_shreduleTableAdapter;
        private System.Windows.Forms.BindingSource Day_PlanBindingSource;
        private DayPlanDataSet DayPlanDataSet;
        private DayPlanDataSetTableAdapters.Day_PlanTableAdapter Day_PlanTableAdapter;
    }
}