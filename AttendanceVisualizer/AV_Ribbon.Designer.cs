namespace AttendanceVisualizer
{
    partial class AV_Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AV_Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AV_Tab = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.AttendanceVisulizerButton = this.Factory.CreateRibbonButton();
            this.AV_Tab.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AV_Tab
            // 
            this.AV_Tab.Groups.Add(this.group1);
            this.AV_Tab.Label = "Attendance Visualiser";
            this.AV_Tab.Name = "AV_Tab";
            // 
            // group1
            // 
            this.group1.Items.Add(this.AttendanceVisulizerButton);
            this.group1.Label = "Attendance";
            this.group1.Name = "group1";
            // 
            // AttendanceVisulizerButton
            // 
            this.AttendanceVisulizerButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AttendanceVisulizerButton.Label = "Attendance Visulizer";
            this.AttendanceVisulizerButton.Name = "AttendanceVisulizerButton";
            this.AttendanceVisulizerButton.ShowImage = true;
            this.AttendanceVisulizerButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AttendanceVisulizerButton_Click);
            // 
            // AV_Ribbon
            // 
            this.Name = "AV_Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.AV_Tab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.AV_Ribbon_Load);
            this.AV_Tab.ResumeLayout(false);
            this.AV_Tab.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab AV_Tab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AttendanceVisulizerButton;
    }

    partial class ThisRibbonCollection
    {
        internal AV_Ribbon AV_Ribbon
        {
            get { return this.GetRibbon<AV_Ribbon>(); }
        }
    }
}
