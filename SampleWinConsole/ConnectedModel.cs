using SampleWinConsole.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWinConsole
{

    internal class ConnectedModel
    {


        //info about UR server, its database and credentials..
        const string strConnectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=FnfTraining;Integrated Security=True";
        const string STRGETALL = "SELECT * FRom EMPLOYEE";
        static void Main(string[] args)
        {
            //firstExample();
            IDBLayer db = new EmployeeDB();
            var records = db.GetAllEmployees();
            foreach(var record in records)
            {
                Console.WriteLine($"Name: {record.EmpName} from {record.EmpAddress} with DeptId: {record.DeptId}");
            }

        }

        private static void firstExample()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = strConnectionString;
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandText = STRGETALL;
            try
            {
                sqlCon.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    //U shall display all the details in the Console.WriteLine.
                    Console.WriteLine($"Name: {reader["EmpName"]}\nAddress: {reader[2]}\nEmpSalary: {reader[3]}\n");

                }
            }
            catch(SqlException sqlEx)
            {
                Console.WriteLine($"Exception while reading the records: {sqlEx.Message}");
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
