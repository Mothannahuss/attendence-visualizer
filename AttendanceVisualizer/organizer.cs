using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class organizer
{
    public organizer()
    {
    }

    // This method takes the time_in and time_out strings and obtains the the hour, minute and
    // which part of the day is associated with the time (am or pm)
    private static string[] tInOut_data(string[] hour)
    {
        DateTime d = Convert.ToDateTime(hour[0]);
        string[] v = d.ToString().Split(' ');
        string partOfTheDay_in = v[2];
        string[] splitted_time_in = v[1].Split(':');
        string hour_in = splitted_time_in[0];
        int min_in = int.Parse(splitted_time_in[1]);


        d = Convert.ToDateTime(hour[1]);
        v = d.ToString().Split(' ');
        string[] splitted_time_out = v[1].Split(':');
        string partOfTheday_out = v[2];
        string hour_out = splitted_time_out[0];
        int min_out = int.Parse(splitted_time_out[1]);

        string[] result = { hour_in + partOfTheDay_in, min_in.ToString(), hour_out + partOfTheday_out, min_out.ToString() };
        return result;
    }


    // This method organizes the data to draw the attendece duration lines
    // slices the data based on the number of visible days
    public static Object[] organizeAttLines(int elementsToKeep, LinkedList<string[]> tin_tout
        , LinkedList<SolidBrush> colors, LinkedList<double> durations)
    {
        LinkedList<string[]> sliced_ts = new LinkedList<string[]> ();

        LinkedList<SolidBrush> slicedColors = new LinkedList<SolidBrush> ();

        LinkedList<Double> sliced_durations = new LinkedList<Double> (); 

        for (int i = 0; i < elementsToKeep; i++)
        {
            sliced_ts.AddLast(tin_tout.ElementAt(i));

            slicedColors.AddLast(colors.ElementAt(i));

            sliced_durations.AddLast(durations.ElementAt(i));
        }

        LinkedList<string[]> converted_ts = new LinkedList<string[]> ();

        foreach (string[] ts in sliced_ts)
        {
            // Gets the needed data for time_in and time_out
            string[] res = tInOut_data(ts);
            converted_ts.AddLast(res);
        }

        Object[] arr = {converted_ts, slicedColors, sliced_durations};

        return arr;
    }
    // Takes the seperate duration of employee's attendences and categorizes them based on the duration
    // return blue solid brush of the duration is -1 (Data error)
    // returns a red solid brush for zero duration attendence (Absence)
    // returns a greeen solid brush form 8 hour or more attendence
    // return an orange solid brush for a present attendence with less than 8 hour duration

    public static LinkedList<SolidBrush> categorizeColors(LinkedList<double> durations)
    {
        LinkedList<SolidBrush> list = new LinkedList<SolidBrush>();
        foreach (double duration in durations)
        {
            if (duration < 0)
                list.AddLast(new SolidBrush(Color.Blue));
            else if (duration == 0)
                list.AddLast(new SolidBrush(Color.Red));
            else if (duration >= 8)
                list.AddLast(new SolidBrush(Color.Green));
            else
                list.AddLast(new SolidBrush(Color.Orange));

        }
        return list;
    }
}
