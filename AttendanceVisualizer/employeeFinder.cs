using System.Collections.Generic;

public class employeeFinder
{
    public static Employee findEmployee(Dictionary<Employee, AttendenceCalc> employeeDictionary, string id)
    {
        foreach (var employee in employeeDictionary.Keys)
        {
            if (employee.getId().Equals(id))
            { return employee; }
        }
        return null;
    }
}