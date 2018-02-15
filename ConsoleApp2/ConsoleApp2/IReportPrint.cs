using System;
using System.Collections.Generic;

namespace ReportGenerator
{
	interface IReportPrint
	{
	    void print(List<Employee> employees);
	}

	public class ReportNameFirst : IReportPrint
	{
		public void print(List<Employee> employees)
		{
			foreach(var e in employees)
			{
				{
					Console.WriteLine("------------------");
					Console.WriteLine("Name: {0}", e.Name);
					Console.WriteLine("Salary: {0}", e.Salary);
				    Console.WriteLine("Age: {0}", e.Age);
                    Console.WriteLine("------------------");
				}
			}
		}
	}

	public class ReportSalaryFirst : IReportPrint
	{
		public void print(List<Employee> employees)
		{
			foreach(var e in employees)
			{
				{
					Console.WriteLine("------------------");
					Console.WriteLine("Salary: {0}", e.Salary);
					Console.WriteLine("Name: {0}", e.Name);
                    Console.WriteLine("Age: {0}", e.Age);
					Console.WriteLine("------------------");
		        }
			}
		}
	}

    public class ReportAgeFirst : IReportPrint
    {
        public void print(List<Employee> employees)
        {
            foreach (var e in employees)
            {
                {
                    Console.WriteLine("------------------");
                    Console.WriteLine("Age: {0}", e.Age);
                    Console.WriteLine("Salary: {0}", e.Salary);
                    Console.WriteLine("Name: {0}", e.Name);
                    Console.WriteLine("------------------");
                }
            }
        }
    }
}
