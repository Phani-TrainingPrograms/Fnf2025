using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebFormsApp
{
    public partial class Ex03CalcProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            var result = 0.0;
            //Get the values from the controls.
            var fValue = Convert.ToDouble(txtFirstValue.Text);
            var sValue = Convert.ToDouble(txtSecondValue.Text);
            var option = dpOptions.Text;
            //switch case based on dp selection
            if(string.IsNullOrEmpty(option))
            {
                Response.Write("No option was selected, Did U check for AutoPostBack?");
                return;
            }
            switch(option)
            {
                case "Add": result = fValue + sValue; break;
                case "Subtract": result = fValue - sValue; break;
                case "Multiply": result = fValue * sValue; break;
                case "Divide": result = fValue / sValue; break;
                default:
                    break;
            }
            //set the computed value to the lblDisplay
            lblDisplay.Text = result.ToString();
        }


        //Certain controls have a capability of posting the data to the server when an event occurs. Button control has this feature automatically enabled. For DropDownListBox or ListBox which has a property calle EnableAutoPostBack which when set, shall allow event handlers to post the data to the server without a need of an explicit button. 
        protected void dpOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnResult_Click(sender, e);
        }
    }
}