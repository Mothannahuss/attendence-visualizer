using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using  Excel = Microsoft.Office.Interop.Excel;
namespace AttendanceVisualizer
{
    public partial class AttendanceVisulizerForm : Form
    {
        private int clicks = 0;
        private Dictionary<Employee, AttendenceCalc> map = new Dictionary<Employee, AttendenceCalc>();

        private String[] HOURS = {"12AM", "1AM","2AM","3AM","4AM","5AM","6AM","7AM"
                        ,"8AM","9AM","10AM","11AM","12PM","1PM","2PM","3PM"
                        ,"4PM","5PM","6PM","7PM","8PM","9PM","10PM","11PM","12AM"};


        public AttendanceVisulizerForm()
        { 
            InitializeComponent();
            TimeLineDrawingPanel.AutoScroll = true;
            TimeLineDrawingPanel.AutoSize = false;
            TimeLineDrawingPanel.VerticalScroll.SmallChange = 100;

            TimeLineDrawingPanel.VerticalScroll.LargeChange = 600;

            TimeLineDrawingPanel.HorizontalScroll.SmallChange = 1000;

            TimeLineDrawingPanel.HorizontalScroll.LargeChange = 600;
        }
        private void ReadSheet_Button_Click(object sender, EventArgs e)
        {                 
            Excel.Workbook xWorkBook = Globals.ThisAddIn.Application.ActiveWorkbook;

                Excel.Worksheet xWorksheet = xWorkBook.Worksheets.Item[1];
                Excel.Range usedRng;
                usedRng = xWorksheet.UsedRange;
                int numberOfRows = usedRng.Rows.Count;
                int row = 1;
                reader dataReader = new reader(xWorkBook, xWorksheet);

                Dictionary<Employee, AttendenceCalc> dic = dataReader.read();

                map = dic;

                SheetContents_ListBox.Items.Clear();

                foreach (Employee emp in dic.Keys)
                {
                    SheetContents_ListBox.Items.Add(emp.getId());
                }

        }



        // This method draws the lines indicting the time period in which an employee attended in the company
        private void drawAttendenceLines(LinkedList<String[]> hours, 
            LinkedList<SolidBrush> colors, LinkedList<double> durations)
        {
            
            int offsetX = TimeLineDrawingPanel.AutoScrollPosition.X;
            int offsetY = -TimeLineDrawingPanel.AutoScrollPosition.Y;
            int x = 85;
            int y = 25;

            Brush txtBrush = new SolidBrush(Color.Black);
            Font f = new Font("Arial", 7, FontStyle.Regular);
            int i = 0;
            int j = 0;
            using (Graphics g = TimeLineDrawingPanel.CreateGraphics())
            {
                foreach (string[] hour in hours)
                {
                    if ((y + 7) > (TimeLineDrawingPanel.Height + offsetY))
                        break;

                    SolidBrush b = colors.ElementAt(i);

                    double duration = durations.ElementAt(j);
                    //MessageBox.Show(b.Color + "");
                    if (b.Color != Color.Blue && b.Color != Color.Red)
                    {

                        string time_in = hour[0];

                        int min_in = int.Parse(hour[1]);

                        string time_out = hour[2];

                        int min_out = int.Parse(hour[3]);

                        int index_in = Array.IndexOf(HOURS, time_in);

                        int index_out = Array.IndexOf(HOURS, time_out);

                        int x_loc = (x + 40 * index_in + 40 * min_in / 60) + offsetX;

                        float y_loc = y;

                        float width = (x + 40 * index_out + min_out * 40 / 60) + offsetX;

                        Pen p = new Pen(b, 5);

                        Point p1 = new Point(x_loc, y+2 - offsetY);

                        Point p2 = new Point((x + 40 * index_out + min_out * 40 / 60) + offsetX, y+2 - offsetY);

                        g.DrawLine(p, p1, p2);


                        double locString = x + 40 * index_out + min_out * 40 / 60 + offsetX + 10;

                        if (locString <= TimeLineDrawingPanel.Width)
                        {
                            int hour_part = (int)duration;
                            double minute_part = (int)((duration - hour_part) * 60);
                            g.DrawString(hour_part + ":" + minute_part, f, txtBrush, (x + 40 * index_out + min_out * 40 / 60) + offsetX + 10, y-3 - offsetY);
                        }



                    }
                    else if (b.Color == Color.Blue)
                    {
                        g.DrawString("Data Error", f, b, x + 2 + offsetX, y - offsetY);
                    }
                    else
                    {
                        g.DrawString("Absent", f, b, x + 2+ offsetX, y - offsetY);
                    }
                    i += 1;
                    j += 1;
                    y += 25;

                }
            }

        }
       
        // Draws data for the silicted employee
        private void listBox_doubleClick(object sender, EventArgs e)
        {
            clicks += 1;
            TimeLineDrawingPanel.Controls.Clear();

            using (Graphics g = TimeLineDrawingPanel.CreateGraphics())
            {
                
                drawDays(g);
                drawHours();
                drawLines(g);
                drawRecs(g);
            }

        }


        // This method draws the rectangles that indicates weather an employee was present, absent or had no data
        private void drawRecs(Graphics g)
        {
            int x = 60;
            int offsetY = -TimeLineDrawingPanel.AutoScrollPosition.Y;
            int offsetX = -TimeLineDrawingPanel.AutoScrollPosition.X;
            int y = 25;
            try
            {
                string id = (string)SheetContents_ListBox.SelectedItem;

                // Throw new Exception when the map is empty
                // It will only be empty if the user did not click the read button
                if (map.Count == 0)
                {
                    throw new Exception();
                }

                AttendenceCalc calc = map[employeeFinder.findEmployee(map,id)];

                LinkedList<double> sep_att = calc.getDurations();

                LinkedList<SolidBrush> categorizedData = organizer.categorizeColors(sep_att);

                int elementsToKeep = 0;

                foreach (SolidBrush brush in categorizedData)
                {
                    // Stop drawing when panel visible limit is reached
                    if ((y + 15) > (TimeLineDrawingPanel.Height + offsetY))
                        break;

                    // Update the counter to determine how many elements to slice
                    elementsToKeep += 1;
                    g.FillRectangle(brush, x - offsetX, y - offsetY, 15, 15);
                    y += 25;
                }

                Object[] attLinesData = organizer.organizeAttLines(elementsToKeep, calc.getTinTout(), categorizedData, sep_att);

                LinkedList<string[]> hours = (LinkedList<string[]>)attLinesData[0];

                LinkedList<SolidBrush> cols = (LinkedList<SolidBrush>)attLinesData[1];

                LinkedList<Double> durs = (LinkedList<double>)attLinesData[2];

                // Draw the lines associated with every attendence
                drawAttendenceLines(hours, cols, durs);
            }
            // Handle the exception when none of the shown ids in the listbox is clicked
            catch(ArgumentNullException e)
            {
                TimeLineDrawingPanel.Controls.Clear();
                MessageBox.Show("Please chose one of the shown Ids");
                    
            }
            catch (Exception e)
            {
                TimeLineDrawingPanel.Controls.Clear();
                MessageBox.Show("Please click the read sheet button first");
            }
        }

        // This method draws the days vertically from day1 up to day 90
        private void drawDays(Graphics g)
        {
            //Graphics g = TimeLineDrawingPanel.CreateGraphics();
            Pen timeLinePen = new Pen(Color.Gray);
            int x = 5;
            int y = 25 ;
            for (int i = 1; i <= 90; i++)
            {
                Label label = new Label
                {
                    Text = "Day " + i,
                    Location = new System.Drawing.Point(x + +TimeLineDrawingPanel.AutoScrollPosition.X
                    , y  + TimeLineDrawingPanel.AutoScrollPosition.Y), // Adjust the Y position
                    AutoSize = true // AutoSize to fit content
                };
                TimeLineDrawingPanel.Controls.Add(label);
                y += 25;
            }
        }


        // This method draws horizontal lines indicating a week has ended
        private void drawLines(Graphics g)
        {
            //Graphics g = TimeLineDrawingPanel.CreateGraphics();
            Pen timeLinePen = new Pen(Color.Gray);
            int x = 5;
            int y = 25;
            int offsetY = -TimeLineDrawingPanel.AutoScrollPosition.Y;
            for (int i = 1; i <= 90; i++)
            {

                if (i % 5 == 0)
                {
                    g.DrawLine(timeLinePen, x + TimeLineDrawingPanel.AutoScrollPosition.X,
                        y + 20 + TimeLineDrawingPanel.AutoScrollPosition.Y,
                        TimeLineDrawingPanel.Width, y + 20 + TimeLineDrawingPanel.AutoScrollPosition.Y);
                }
                y += 25;
            }
        }


        // This method draws the hours of the day horizontally on top of the page
        private void drawHours()
        {
            int x = 85;
            int y = 5;

            foreach (String s in HOURS)
            {
                Label label = new Label
                {
                    Text = s,
                    Location = new System.Drawing.Point(x, y + TimeLineDrawingPanel.AutoScrollPosition.Y), // Adjust the Y position
                    AutoSize = true // AutoSize to fit content
                };
                TimeLineDrawingPanel.Controls.Add(label);
                x += 40;
            }
            
        }

        // This method repaints the panel when the user scrolls
        private void rePaint(object sender, ScrollEventArgs e)
        {
            if (clicks > 0)
            {
                //TimeLineDrawingPanel.Invalidate();
                using (Graphics g = TimeLineDrawingPanel.CreateGraphics())
                {
                    drawDays(g);
                    //drawHours();
                    drawLines(g);
                    drawRecs(g);
                }
            }
            
        }

        private void AttendanceVisulizerForm_Load(object sender, EventArgs e)
        {

        }

        private void enterPressed(object sender, KeyPressEventArgs e)
        {
            clicks += 1;
            TimeLineDrawingPanel.Controls.Clear();

            using (Graphics g = TimeLineDrawingPanel.CreateGraphics())
            {

                drawDays(g);
                drawHours();
                drawLines(g);
                drawRecs(g);
            }
        }
    }
}
