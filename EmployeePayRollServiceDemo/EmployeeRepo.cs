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
    }
}
