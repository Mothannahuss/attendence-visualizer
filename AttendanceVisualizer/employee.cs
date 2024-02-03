using System;
using System.Collections.Generic;

public class Employee 
{
	private string id;
	private AttendenceCalc calc;
	public Employee(string id,AttendenceCalc calc)
	{
		this.id = id;
		this.calc = calc;
	}
	public string getId()
	{
		return this.id;
	}

    // Calls the calcTotal method of the associated AttendenceCalc object
    public double totalHours()
	{
		return this.calc.calcTotal();
	}
}
