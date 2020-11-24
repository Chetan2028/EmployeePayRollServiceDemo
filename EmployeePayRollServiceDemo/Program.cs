using System;

namespace EmployeePayRollServiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Database");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            bool result = employeeRepo.UpdateDataUsingPreparedStatement();
            Console.WriteLine("Updated data in table : " + result);
        }
    }
}
