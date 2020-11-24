using System;

namespace EmployeePayRollServiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Database");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.EnsureDatabaseConnection();
            //Console.WriteLine("---------------------------------------------RETRIEVE DATA--------------------------------------------------------");
            //employeeRepo.GetAllEmployees_NewTableStructure();
            //Console.WriteLine("---------------------------------------------AGGREGATE FUNCTIONS--------------------------------------------------------");
            //employeeRepo.GetAggregateSalaryForEachGender_NewTable();
            Console.WriteLine("---------------------------------------------EMPLOYEES WIHTIN GIVEN DATE RANGE--------------------------------------------------------");
            employeeRepo.GetEmployeesWithinGivenDateRange_NewTable();
        }
    }
}
