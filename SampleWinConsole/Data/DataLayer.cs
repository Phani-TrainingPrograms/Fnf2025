using SampleWinConsole.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SampleWinConsole.DataLayer
{
    interface IDBLayer
    {
        List<Employee> GetAllEmployees();
    }

    class EmployeeDB : IDBLayer 
    {
        readonly string STRCONNECTION = ConfigurationManager.ConnectionStrings["connectionConfig"].ConnectionString;
        const string STRSELECTALL = "SELECT * FROM EMPLOYEE";
        public List<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            var con = new SqlConnection(STRCONNECTION);
            var cmd = new SqlCommand(STRSELECTALL, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                if(!reader.HasRows)
                {
                    throw new System.Exception("No records found");
                }
                while(reader.Read())
                {
                    var temp = new Employee();
                    temp.EmpId = Convert.ToInt32(reader[0]);
                    temp.EmpName = reader[1].ToString();
                    temp.EmpAddress = reader[2].ToString();
                    temp.EmpSalary = Convert.ToDouble(reader[3]);
                    temp.DeptId = reader[4] is DBNull ? 0 : Convert.ToInt32(reader[4]);
                    list.Add(temp);
                }
                return list;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
    }
}