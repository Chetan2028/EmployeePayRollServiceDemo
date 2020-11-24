using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRollServiceDemo
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);


        /// <summary>
        /// Ensures the database connection.
        /// </summary>
        public void EnsureDatabaseConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("Connection established successfully");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void GetAllEmployees()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    string query = "Select * from Employee_Payroll";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    //Check for rows
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.Id = dr.GetInt32(0);
                            employeeModel.Emp_Name = dr.GetString(1);
                            employeeModel.Emp_Salary = dr.GetDecimal(2);
                            employeeModel.Emp_Start_Date = dr.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dr.GetString(4));
                            employeeModel.Emp_Phone_Number = dr.GetString(5);
                            employeeModel.Emp_Address = dr.GetString(6);
                            employeeModel.Department = dr.GetString(7);
                            employeeModel.Basic_Pay = dr.GetDecimal(8);
                            employeeModel.Deductions = dr.GetDecimal(9);
                            employeeModel.Taxable_Pay = dr.GetDecimal(10);
                            employeeModel.Income_Tax = dr.GetDecimal(11);
                            employeeModel.Net_Pay = dr.GetDecimal(12);

                            Console.WriteLine(employeeModel.Id + "  " + employeeModel.Emp_Name + "  " + employeeModel.Emp_Salary
                                + "  " + employeeModel.Emp_Start_Date + "  " + employeeModel.Gender + "  " + employeeModel.Emp_Phone_Number
                                + "  " + employeeModel.Emp_Address + "  " + employeeModel.Department + "  " + employeeModel.Basic_Pay + "  " +
                                employeeModel.Deductions + "  " + employeeModel.Taxable_Pay + "  " + employeeModel.Income_Tax + "  " + employeeModel.Net_Pay);

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data found");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
