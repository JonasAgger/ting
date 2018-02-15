using System;

namespace ReportGenerator
{
    internal class ReportGeneratorClient
    {
        private static void Main()
        {
            var db = new EmployeeDB();

            // Add some employees
            db.AddEmployee(new Employee("Anne", 3000, 25));
            db.AddEmployee(new Employee("Berit", 2000, 74));
            db.AddEmployee(new Employee("Christel", 1000, 15));

            var reportGenerator = new ReportGenerator(db);

            // Create a default (name-first) report
            reportGenerator.CompileReport();

            Console.WriteLine("");
            Console.WriteLine("");

            // Create a salary-first report
            reportGenerator.SetOutputFormat(new ReportSalaryFirst());
            reportGenerator.CompileReport();

            Console.WriteLine("");
            Console.WriteLine("");

            reportGenerator.SetOutputFormat(new ReportAgeFirst());
            reportGenerator.CompileReport();
        }
    }
}