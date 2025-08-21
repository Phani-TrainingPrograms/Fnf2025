using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormsApp
{
    public partial class Ex02BasicInputExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Event handler for the Button's Click. 
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Take the values and place it in a string. 
            string content = $"The Name: {txtName.Text}<br/>The Email Address: {txtEmail.Text}<br/>The Salary: {txtSalary.Text:C}";
            lblDisplay.Text = content ;
        }

     
    }
}