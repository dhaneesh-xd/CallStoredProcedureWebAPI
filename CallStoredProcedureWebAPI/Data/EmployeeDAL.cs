using CallStoredProcedureWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CallStoredProcedureWebAPI.Data
{
    public class EmployeeDAL
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["EmployeeDBConnectionString"].ConnectionString;

        public void InsertEmployee(Employee emp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("InsertEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@empName", emp.Name);
                command.Parameters.AddWithValue("@empDescription", emp.Description);
                command.Parameters.AddWithValue("@empSalary", emp.Salary);
                command.Parameters.AddWithValue("@empAddress", emp.Address);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}