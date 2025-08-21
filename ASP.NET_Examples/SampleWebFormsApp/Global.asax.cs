using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SampleWebFormsApp
{
    public class Global : System.Web.HttpApplication
    {
        //Event that is triggered when the Application starts. (First time)
        protected void Application_Start(object sender, EventArgs e)
        {
            var path = Server.MapPath("//Images");
            var data = new ProductDatabase().GetAllProducts(path);
            //Application object is a State Management object that will be available across the Application. It will be common for all the Users of the Application as it is a singleton object. 
            Application["AllProducts"] = data;//Add the data to the Application object. 
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //This event is triggered when a new User starts a Session with the Application.
            //You can initialize the Session object here if needed.
            Session["recentItems"] = new Queue<ProductInfo>(); //Initialize a shopping cart for the user.
        }
    }
}