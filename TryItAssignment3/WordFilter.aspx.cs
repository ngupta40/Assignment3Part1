using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WordFilter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblOutput.Visible = false;
    }
    /// <summary>
    /// Event to trigger Word Filter service and retrieve output
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        if(inputTxt.Text != "")
        {
            ServiceSubscription.Service1Client wordFilter = new ServiceSubscription.Service1Client();
            string filtered = wordFilter.WordFilter(inputTxt.Text);
            lblOutput.Visible = true;
            lblOutput.Text = filtered;
        }
        else
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Url')", true);
    }
}