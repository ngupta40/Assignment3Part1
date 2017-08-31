using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TopUsedWords : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string url = TextBox1.Text;
        string completeRestCall = "http://webstrar29.fulton.asu.edu/Page0/Service1.svc/TopUsedWords?URLs=" + url;
        Response.Redirect(completeRestCall);
    }
}