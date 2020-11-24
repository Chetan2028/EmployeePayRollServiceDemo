using System;
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// Gets all employees.
        /// </summary>
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

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Emp_Name", model.Emp_Name);
                    command.Parameters.AddWithValue("@Emp_Salary", model.Emp_Salary);
                    command.Parameters.AddWithValue("@Emp_Start_Date", model.Emp_Start_Date);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@Emp_Phone_Number", model.Emp_Phone_Number);
                    command.Parameters.AddWithValue("@Emp_Address", model.Emp_Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@Taxable_Pay", model.Taxable_Pay);
                    command.Parameters.AddWithValue("@Income_Tax", model.Income_Tax);
                    command.Parameters.AddWithValue("@Net_Pay", model.Net_Pay);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Updates the data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateData()
        {
            try
            {
                string updateQuery = "update Employee_Payroll set Basic_Pay = 1000745000 where Id = 1";
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand(updateQuery, this.connection);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Updates the data using prepared statement.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateDataUsingPreparedStatement()
        {
            try
            {
                string updateQuery = "update Employee_Payroll set Emp_Name = @empName where Id = @id";
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand(updateQuery, this.connection);
                    command.Prepare();
                    command.Parameters.AddWithValue("@empName", "Apoorva");
                    command.Parameters.AddWithValue("@id", 9);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
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

        /// <summary>
        /// Retrieves the employees within date range.
        /// </summary>
        public void RetrieveEmployeesWithinDateRange()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                string query = "Select * from Employee_Payroll where Emp_Start_Date between cast('01-01-2018' as date) and SYSDATETIME()";
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    //Check for data presence
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employeeModel.Id = reader.GetInt32(0);
                            employeeModel.Emp_Name = reader.GetString(1);
                            employeeModel.Emp_Salary = reader.GetDecimal(2);
                            employeeModel.Emp_Start_Date = reader.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(reader.GetString(4));
                            employeeModel.Emp_Phone_Number = reader.GetString(5);
                            employeeModel.Emp_Address = reader.GetString(6);
                            employeeModel.Department = reader.GetString(7);
                            employeeModel.Basic_Pay = reader.GetDecimal(8);
                            employeeModel.Deductions = reader.GetDecimal(9);
                            employeeModel.Taxable_Pay = reader.GetDecimal(10);
                            employeeModel.Income_Tax = reader.GetDecimal(11);
                            employeeModel.Net_Pay = reader.GetDecimal(12);

                            Console.WriteLine(employeeModel.Id + "  " + employeeModel.Emp_Name + "  " + employeeModel.Emp_Salary
                                + "  " + employeeModel.Emp_Start_Date + "  " + employeeModel.Gender + "  " + employeeModel.Emp_Phone_Number
                                + "  " + employeeModel.Emp_Address + "  " + employeeModel.Department + "  " + employeeModel.Basic_Pay + "  " +
                                employeeModel.Deductions + "  " + employeeModel.Taxable_Pay + "  " + employeeModel.Income_Tax + "  " + employeeModel.Net_Pay);

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    reader.Close();
                    this.connection.Close();
                }
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

        public void GetAggregateFunctions()
        {
            try
            {
                string query = "Select Gender , Sum(Net_Pay),Avg(Net_Pay),Max(Net_Pay),Min(Net_Pay),Count(Gender)" +
                    " from Employee_Payroll group by Gender";
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Gender\t" + "Sum\t"+"Avg\t"+"Max\t"+"Min\t"+"GenderCount\t");
                        while (reader.Read())
                        {
                            string gender = reader.GetString(0);
                            decimal sum = reader.GetDecimal(1);
                            decimal avg = reader.GetDecimal(2);
                            decimal max = reader.GetDecimal(3);
                            decimal min = reader.GetDecimal(4);
                            int genderCount = reader.GetInt32(5);

                            Console.WriteLine(gender + "   " + sum + "   " + avg + "   " + max + "   " + min + "   " + genderCount);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO Data Found");
                    }
                    reader.Close();
                    this.connection.Close();
                }
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
    }
}
