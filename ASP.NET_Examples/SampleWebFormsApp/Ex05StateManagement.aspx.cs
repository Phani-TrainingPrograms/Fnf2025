using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
 * Notes on State Management:
 * ASP.NET gives client side and server side state management. 
 * Client side is where the data is visible from the Browser and accessed. 
 * QueryString, Cookies, ViewState are the examples of Client side state Management. 
 * Session, Application, CrossPagePostBack are the examples of Server side State Management. 
 */
namespace SampleWebFormsApp
{
    public partial class Ex05StateManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Take the inputs from the user
            var name = txtName.Text;
            var email = txtEmail.Text;
            var dob = DateTime.Parse(txtDob.Text);//null means ENG...

            /********************QueryString Example*************************************
             * QueryString is a text that is shared thru' an URL of the Page. It contains the data that U want to share in the form of key-values each seperated by an &.
                var queryString = $"Ex06RecipiantPage.aspx?Name={name}&Email={email}&Dob={dob}";
                Response.Redirect(queryString);
             ******************Cookies Example*************************/
            //Cookies are small text based information that is stored in the browser. 
            //In ASP.NET, cookies are objects of a class HttpCookie. U can add the Cookie in the response object and view them in the request object. 
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Values.Add("name", name);
            cookie.Values.Add("email", email);
            cookie.Values.Add("dob", dob.ToLongDateString());
            //SEnd the information as Response. 
            Response.Cookies.Add(cookie);
            Response.Redirect("Ex06RecipiantPage.aspx");
        }
    }
}