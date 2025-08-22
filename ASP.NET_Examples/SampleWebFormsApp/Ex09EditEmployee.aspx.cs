using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormsApp
{
    public partial class Ex09EditEmployee : System.Web.UI.Page
    {
        const string selectQuery = "SELECT * FROM Employee Where EmpId = @id";
        const string updateQuery = "Update Employee set EmpName = @name, EmpAddress = @address, EmpSalary = @salary, DeptId = @deptId Where EmpId = @id";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var empID = Request.QueryString["EmpID"];
                var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FnfTrainingConnectionString1"].ConnectionString);
                var command = new SqlCommand(selectQuery, connection);
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@id", empID);
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        txtId.Text = reader["EmpId"].ToString();
                        txtName.Text = reader["EmpName"].ToString();
                        txtAddress.Text = reader["EmpAddress"].ToString();
                        txtSalary.Text = reader["EmpSalary"].ToString();
                        txtDept.Text = reader["DeptId"].ToString();
                    }
                    connection.Close();
                }
                catch(Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FnfTrainingConnectionString1"].ConnectionString);
            var command = new SqlCommand(updateQuery, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", txtId.Text);
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@address", txtAddress.Text);
                command.Parameters.AddWithValue("@salary", txtSalary.Text);
                command.Parameters.AddWithValue("@deptId", txtDept.Text);
                command.ExecuteNonQuery();
                connection.Close();
                lblError.Text = "Record Updated Successfully. Press back button to view the master list";
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ex08DisconnectedModel.aspx");
        }
    }
}