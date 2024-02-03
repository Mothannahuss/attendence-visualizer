namespace AttendanceVisualizer
{
    partial class AttendanceVisulizerForm
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
            this.ReadSheet_Button = new System.Windows.Forms.Button();
            this.SheetContents_ListBox = new System.Windows.Forms.ListBox();
            this.TimeLineDrawingPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ReadSheet_Button
            // 
            this.ReadSheet_Button.Location = new System.Drawing.Point(48, 92);
            this.ReadSheet_Button.Margin = new System.Windows.Forms.Padding(4);
            this.ReadSheet_Button.Name = "ReadSheet_Button";
            this.ReadSheet_Button.Size = new System.Drawing.Size(184, 50);
            this.ReadSheet_Button.TabIndex = 1;
            this.ReadSheet_Button.Text = "Read Sheet";
            this.ReadSheet_Button.UseVisualStyleBackColor = true;
            this.ReadSheet_Button.Click += new System.EventHandler(this.ReadSheet_Button_Click);
            // 
            // SheetContents_ListBox
            // 
            this.SheetContents_ListBox.FormattingEnabled = true;
            this.SheetContents_ListBox.ItemHeight = 16;
            this.SheetContents_ListBox.Location = new System.Drawing.Point(48, 150);
            this.SheetContents_ListBox.Margin = new System.Windows.Forms.Padding(4);
            this.SheetContents_ListBox.Name = "SheetContents_ListBox";
            this.SheetContents_ListBox.Size = new System.Drawing.Size(255, 388);
            this.SheetContents_ListBox.TabIndex = 120;
            this.SheetContents_ListBox.DoubleClick += new System.EventHandler(this.listBox_doubleClick);
            this.SheetContents_ListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enterPressed);
            // 
            // TimeLineDrawingPanel
            // 
            this.TimeLineDrawingPanel.AutoScroll = true;
            this.TimeLineDrawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeLineDrawingPanel.Location = new System.Drawing.Point(341, 150);
            this.TimeLineDrawingPanel.Margin = new System.Windows.Forms.Padding(4);
            this.TimeLineDrawingPanel.Name = "TimeLineDrawingPanel";
            this.TimeLineDrawingPanel.Size = new System.Drawing.Size(835, 388);
            this.TimeLineDrawingPanel.TabIndex = 121;
            this.TimeLineDrawingPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.rePaint);
            // 
            // AttendanceVisulizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 679);
            this.Controls.Add(this.TimeLineDrawingPanel);
            this.Controls.Add(this.SheetContents_ListBox);
            this.Controls.Add(this.ReadSheet_Button);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AttendanceVisulizerForm";
            this.Text = "AttendanceVisulizerForm";
            this.Load += new System.EventHandler(this.AttendanceVisulizerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ReadSheet_Button;
        internal System.Windows.Forms.ListBox SheetContents_ListBox;
        internal System.Windows.Forms.Panel TimeLineDrawingPanel;
    }
}