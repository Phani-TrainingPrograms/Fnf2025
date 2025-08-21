using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SampleWebFormsApp
{
    public partial class Ex07DisplayProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //This piece of code shall execute only when the Page is loaded, not posted. 
                var products = Application["AllProducts"] as List<ProductInfo>;
                lstItems.DataSource = products;
                lstItems.DataTextField = "ProductName";
                lstItems.DataValueField = "ProductId";
                lstItems.DataBind();//internally iterates thru the DataSource and adds them to the Control.
            }
        }

        protected void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Extract the product Id from the selected Item.
            var productId = int.Parse(lstItems.SelectedItem.Value);
            //Find the Product from the Application object.
            var products = Application["AllProducts"] as List<ProductInfo>;
            var foundProduct = products.Find(x => x.ProductId == productId);
            //Set the Controls with the product details....
            lblCost.Text = foundProduct.ProductCost.ToString();
            lblName.Text = foundProduct.ProductName;
            lblID.Text = foundProduct.ProductId.ToString();
            imgImage.ImageUrl = $"~/Images/{foundProduct.ProductImage}";

            //Get the recent items from the Session object
            var recentItems = Session["recentItems"] as Queue<ProductInfo>;
            //Add the found product to the recent items queue
            if (recentItems.Count >= 5)
            {
                recentItems.Dequeue(); //Remove the oldest item if the queue is full
            }
            recentItems.Enqueue(foundProduct); //Add the new product to the queue
            //Display the recent items in a control
            var reverseList = recentItems.Reverse().ToList(); // Reverse the queue to show the most recent items first
            dtList.DataSource = reverseList;
            dtList.DataBind(); // Bind the data to the control
            //Update the Session object with the modified queue
            Session["recentItems"] = recentItems;
        }
    }
}