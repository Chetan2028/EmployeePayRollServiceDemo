using System;

namespace EmployeePayRollServiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Database");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            EmployeeModel model = new EmployeeModel();
            employeeRepo.EnsureDatabaseConnection();
            model.Emp_Name = "Laxmi";
            model.Emp_Salary = 489700;
            model.Gender = 'F';
            model.Emp_Start_Date = Convert.ToDateTime("02-10-2019");
            model.Emp_Phone_Number = "8523146798";
            model.Emp_Address = "London";
            model.Department = "FrontEnd";
            model.Basic_Pay = 350700;
            model.Deductions = 18000;
            model.Taxable_Pay = 4000;
            model.Income_Tax = 140000;
            model.Net_Pay = 430000;
            var result = employeeRepo.AddEmployee(model);
            Console.WriteLine("Data inserted in the table : " + result);
        }
    }
}
