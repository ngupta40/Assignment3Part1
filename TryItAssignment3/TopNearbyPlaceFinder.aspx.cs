using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TopNearbyPlaceFinder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListBox1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        ServiceSubscription.Service1Client svc = new ServiceSubscription.Service1Client();
        String[] reply = svc.TopNearByPlaceFinder(TextBox1.Text);
        foreach (string r in reply)
            ListBox1.Items.Add(r);
        ListBox1.Visible = true;

    }
}