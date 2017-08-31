using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TransactionSummarizer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Visible = false;
        ServiceSubscription.Service1Client svc = new ServiceSubscription.Service1Client();
        string response = svc.TransactionSummary(TextBox1.Text);
        Label2.Text = response;
        Label2.Visible = true;

    }
}