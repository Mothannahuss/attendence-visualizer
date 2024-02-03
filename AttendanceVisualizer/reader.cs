using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Interop.Excel;
class reader
{
    private Workbook wb;
    private Worksheet ws;
    public reader(Workbook wb, Worksheet ws)
    {
        this.wb = wb;
        this.ws = ws;
    }
    // Reads the data from the excel file and returns it in the form of "Employee id": [employee object, attendencecalc object]
    public Dictionary<Employee,AttendenceCalc> read()
    {
        Dictionary<Employee, AttendenceCalc> map = new Dictionary<Employee, AttendenceCalc>();
        LinkedList<string> explored_ids = new LinkedList<string>();

        Boolean first = true;
        foreach (Microsoft.Office.Interop.Excel.Range row in ws.UsedRange.Rows)
        {
            if (first)
            {
                first = false;
                continue;
            }
            String[] rowData = new String[row.Columns.Count];


            for (int i = 0; i < row.Columns.Count; i++)
             {
                rowData[i] = Convert.ToString(row.Cells[1, i + 1].Text);
                if (rowData[i] == "-")
                {
                    rowData[i] = null; 
                }
             }

            string id = rowData[0];
            string date = rowData[1];
            string time_in = rowData[2];
            string time_out = rowData[3];

            Attendence att = new Attendence(time_in, time_out, date);

            Employee e = employeeFinder.findEmployee(map, id);

            if (e == null)
            { 
                AttendenceCalc calc = new AttendenceCalc();

                e = new Employee(id,calc);

                calc.addAtt(att);

                map.Add(e, calc);
                explored_ids.AddLast(id);
            }
            else
            {
                AttendenceCalc calc = map[e];
                calc.addAtt(att);
            }
        }

        return map;
    }
    
}