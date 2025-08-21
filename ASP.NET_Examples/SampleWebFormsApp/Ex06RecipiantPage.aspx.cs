using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormsApp
{
    public partial class Ex06RecipiantPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*********QueryString Example*********************
            Limits: Only strings can be sent thru the URL. Text is visible to all the users and they can be modified and viewe in History also. Not good for sending Sensitive information. Certain browsers restrict the URL length to be not more than 255 charecters. 
            if(Request.QueryString.Count == 0)
            {
                lblDisplay.Text = "No Information was posted to this page";
                return;
            }
            var info = $"Name: {Request.QueryString["Name"]}<br/>The Email Address: {Request.QueryString["Email"]}<br/>Date Of birth: {Request.QueryString["Dob"]}";
            lblDisplay.Text = info ;
            ****************Cookies Example*******************************************/
            var cookie = Request.Cookies["UserInfo"];
            if((cookie == null))
            {
                lblDisplay.Text = "No Information was posted to this page";
                return;
            }
            var info = $"Name: {cookie.Values["name"]}<br/>The Email Address: {cookie.Values["email"]}<br/>Date Of birth: {cookie.Values["dob"]}";
            lblDisplay.Text = info;
            //Limits: Cookies store text data only. Users can disable the Cookies if they want,and due to copyrights, U should ask the User permission before setting the cookies.
            Request.Cookies.Remove("UserInfo");
        }
    }
}