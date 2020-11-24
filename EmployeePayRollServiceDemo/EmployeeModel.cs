using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayRollServiceDemo
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Emp_Name { get; set; }
        public decimal Emp_Salary { get; set; }
        public DateTime Emp_Start_Date { get; set; }
        public char Gender { get; set; }
        public string Emp_Phone_Number { get; set; }
        public string Emp_Address { get; set; }
        public string Department { get; set; }
        public decimal Basic_Pay { get; set; }
        public decimal Deductions { get; set; }
        public decimal Taxable_Pay { get; set; }
        public decimal Income_Tax { get; set; }
        public decimal Net_Pay { get; set; }
    }
}
