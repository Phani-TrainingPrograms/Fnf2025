using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Todo: Add 2 Buttons for Update and Delete and implement the logic to update and delete the data in the database respectively. 
namespace SampleWebFormsApp
{
    public partial class Ex04DatabaseAccess : System.Web.UI.Page
    {
        public readonly string STRCON = ConfigurationManager.ConnectionStrings["FnfTrainingConnectionString1"].ConnectionString;
        //Triggered before the Page is displayed on the Browser, ideal for initializing the values for the controls...
        protected void Page_Load(object sender, EventArgs e)
        {
            using(var con = new SqlConnection(STRCON)) 
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "Select * from DeptTable";
                try
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        lstDepartments.Items.Add(new ListItem { Text = reader[1].ToString(), Value = reader[0].ToString() });

                    }

                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //create the query...
            const string STRINSERT = "Insert into Employee values(@name, @email, @salary, @dept)";
            //Connect to the database
            using(var con = new SqlConnection(STRCON))
            {
                //Create the Command object
                var cmd = new SqlCommand(STRINSERT, con);
                //Set Parameters to it.
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@salary", txtSalary.Text);
                cmd.Parameters.AddWithValue("@dept", lstDepartments.SelectedItem.Value);
                con.Open() ; 
                //Call the NonQuery
                cmd.ExecuteNonQuery();
                con.Close() ;
                Response.Write("Employee inserted successfully");
            }
            //Close the connection. 
        }
    }
}