using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceVisualizer
{
    public partial class AV_Ribbon
    {
        private void AV_Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void AttendanceVisulizerButton_Click(object sender, RibbonControlEventArgs e)
        {
            AttendanceVisulizerForm frm =new AttendanceVisulizerForm();
            frm.Show();
        }
    }
}
