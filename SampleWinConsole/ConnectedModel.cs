using SampleLib.DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SampleWinConsole
{

    internal class ConnectedModel
    {


        //info about UR server, its database and credentials..
        const string strConnectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=FnfTraining;Integrated Security=True";
        const string STRGETALL = "SELECT * FRom EMPLOYEE";
        const string INSERTCOMMAND = "INSERT INTO EMPLOYEE (EmpName, EmpAddress, EmpSalary, DeptId) VALUES (@EmpName, @EmpAddress, @EmpSalary, @DeptId)";
        static void Main(string[] args)
        {
            //firstExample();
            //getEmployeesDemo();
            secondExample();
            //insertingrecordExample();
            //insertUsingStoredProc();
            //deleteEmployeeExample();
        }

        private static void deleteEmployeeExample()
        {
            var dl = new EmployeeDB();
            try
            {
                dl.DeleteEmployee(1012);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Uses a Stored proc and Employee object to insert a record.
        /// </summary>
        private static void insertUsingStoredProc()
        {
            var emp = new SampleLib.Entities.Employee()
            {
                EmpName = "Jane Doe",
                EmpAddress = "New York",
                EmpSalary = 60000,
                DeptId = 2
            };
            IDBLayer db = new EmployeeDB();
            try
            {
                db.AddEmployee(emp);
                Console.WriteLine("Record inserted successfully. The Generated Id was " + emp.EmpId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while inserting the record: {ex.Message}");
            }
        }

        private static void insertingrecordExample()
        {
            //todo: Take inputs from the user. 
            var con = new SqlConnection(strConnectionString);
            var cmd = new SqlCommand(INSERTCOMMAND, con);
            cmd.Parameters.AddWithValue("@EmpName", "John Doe");
            cmd.Parameters.AddWithValue("@EmpAddress", "Chicago");
            cmd.Parameters.AddWithValue("@EmpSalary", 50000);
            cmd.Parameters.AddWithValue("@DeptId", 1);
            try
            {
                con.Open();
                _ = cmd.ExecuteNonQuery();//Insert, delete, update commands are executed using ExecuteNonQuery.
            }
            catch(SqlException sqlEx)
            {
                Console.WriteLine($"Exception while inserting the record: {sqlEx.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception while inserting the record: {ex.Message}");
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Gets the Employee based on Id taken from the user.  
        /// </summary>
        private static void secondExample()
        {
            Console.WriteLine("Enter the Id to search");
            int empId = int.Parse(Console.ReadLine());

            DataTable data  = SqlData.ExecuteQuery("SELECT * FROM EMPLOYEE WHERE EMPID = @id", new SqlParameter("@id", empId));
            foreach(DataRow rec in data.Rows)
            {
                Console.WriteLine(rec["EmpName"]);
            }
            }
          

        private static void getEmployeesDemo()
        {
            IDBLayer db = new EmployeeDB();
            var records = db.GetAllEmployees();
            foreach(var record in records)
            {
                Console.WriteLine($"Name: {record.EmpName} from {record.EmpAddress} with DeptId: {record.DeptId}");
            }
        }

        /// <summary>
        /// Gets all the records directly from the database and displays them in the Console.
        /// </summary>
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
                    Console.WriteLine($"Name: {reader["EmpName"]}\nID: {reader[0]}\nAddress: {reader[2]}\nEmpSalary: {reader[3]}\n");

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
