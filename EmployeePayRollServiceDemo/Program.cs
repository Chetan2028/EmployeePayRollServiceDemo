using System;

namespace EmployeePayRollServiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Database");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.RetrieveEmployeesWithinDateRange();
        }
    }
}
