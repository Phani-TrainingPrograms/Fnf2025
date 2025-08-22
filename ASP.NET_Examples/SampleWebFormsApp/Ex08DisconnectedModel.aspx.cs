using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace SampleWebFormsApp
{
    public partial class Ex08DisconnectedModel : System.Web.UI.Page
    {
        static DataSet dataSet = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Disconnected Model is a architecture where the data is retrieved from the database, manipulated in memory, and then updated back to the database.
            //Data is not continuously connected to the database. Data is stored in a dataset.
            //DataSet is an object that contains data that can hold multiple tables and relationships between them.
            //DataSet is a collection of DataTables. Each DataTable represents a table in the database created based on the SELECT Query of the Command.
            if(!IsPostBack)
            {
                try
                {
                    getAllRecords();
                    rpEmployees.DataSource = dataSet.Tables["Employees"];
                    rpEmployees.DataBind();//For ASP.NET Web Forms, DataBind() method is used to bind the data source to the control.
                }
                catch(Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }

        }

        private void getAllRecords()
        {
            const string selectQuery = "SELECT * FROM Employee";
            string connectionString = ConfigurationManager.ConnectionStrings["FnfTrainingConnectionString1"].ConnectionString;
            using(var adapter = new SqlDataAdapter(selectQuery, connectionString))
            {
                adapter.Fill(dataSet, "Employees");//Fill is a smart method that opens the connection, executes the command, and closes the connection. First arg is the DataSet object, second arg is the name of the DataTable to be created in the DataSet.
            }
        }

        protected void rpEmployees_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "Edit")
            {
                //lblError.Text = "Edit command triggered for EmployeeID: " + e.CommandArgument;
                Response.Redirect("Ex09EditEmployee.aspx?EmpID=" + e.CommandArgument);
            }
            else if(e.CommandName == "Delete")
            {
                lblError.Text = "Delete command triggered for EmployeeID: " + e.CommandArgument;
            }
        }
    }
}