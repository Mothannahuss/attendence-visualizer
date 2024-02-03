using System;
using System.Collections.Generic;
using System.Linq;

public class AttendenceCalc
{
	private LinkedList<Attendence> attendences = new LinkedList<Attendence>();
	private LinkedList<double> attendences_duration = new LinkedList<double>();
	public AttendenceCalc()
	{
	}

	// Adds an attendence
	public void addAtt(Attendence att)
	{
		this.attendences.AddLast(att);
	}

	// Computes the total attendence hours of the 90 day period
	public double calcTotal()
	{
		return attendences_duration.Sum();
	}

	// Get the duration of every recorded attendence of the associated employee
	public LinkedList<Double> getDurations()
	{
        attendences_duration.Clear();
		foreach (Attendence att in this.attendences)
		{
			attendences_duration.AddLast((double)att.calcDiff());

		}
		return attendences_duration;
	}


	// returns the time_in and time_out attributes of every recorded attendence of the associated employee
	public LinkedList<string[]> getTinTout()
	{
		LinkedList<string[]> strings = new LinkedList<string[]>();

		foreach (Attendence att in this.attendences)
		{
			string[] x = { att.getTin(), att.getTout() };
            strings.AddLast(x);
		}

		return strings;
	}
}
