using System;
using System.Windows.Forms;

public class Attendence

{
	private string t_in = null;
	private string t_out = null;
	private string date = null;
	private string attStatus = "Present";

    public Attendence(string t_in, string t_out, string date)
	{
		this.t_in = t_in;
		this.t_out = t_out;
		this.date = date;
        updateStatus();
	}

	// set the status of an attendencde based on the obtained time_in and time_out
	private void updateStatus()
	{
		if (t_in == null && t_out == null) { attStatus = "Absent"; }
		else if (t_in == null || t_out == null || 
			t_in.Contains("(+1)") || t_out.Contains("(+1)")) { attStatus = "Data Error"; }

	}

	public string getTin()
	{
		return t_in;
	}
	public string getTout()
	{
		return t_out;
	}

	// This method computes the attendence time of an employee in a given day
	public double calcDiff()
	{
		if (attStatus == "Present")
		{
			string[] timeIn_components = t_in.Split(':');
			string[] timeOut_components = t_out.Split(':');

            int H_in = int.Parse(timeIn_components[0]);
			int M_in = int.Parse(timeIn_components[1]);
			int S_in = int.Parse((timeIn_components[2]));

			int H_out = int.Parse(timeOut_components[0]);
			int M_out = int.Parse(timeOut_components[1]);
			int S_out = int.Parse((timeOut_components[2]));

			TimeSpan timeIn = new TimeSpan(H_in, M_in, S_in);
			TimeSpan timeOut = new TimeSpan(H_out, M_out, S_out);

			return Math.Round(timeOut.Subtract(timeIn).TotalMinutes / 60.0,2);
		}
		else if (attStatus == "Data Error")
			return -1;
		return 0;

    }
}
