using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mime;

public partial class ImageVerifier : System.Web.UI.Page
{
    private static string verifyString = "";
    private static bool pageloaded = false; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (pageloaded == false)
        {
            pageloaded = true;
            reload(sender, e);

        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if(verifyString == TextBox1.Text)
        {
            Label1.Text = "Successful";
        }
        else
        {
            Label1.Text = "Unsuccessful";
        }
    }

    private void reload(object sender, EventArgs e)
    {
        ImageVS.ServiceClient ImgVfr = new ImageVS.ServiceClient();
        string capchavalue = "";
        capchavalue = ImgVfr.GetVerifierString("5");
        Image1.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc//GetImage/" + capchavalue;
        verifyString = capchavalue;
    }

    protected void refreshImage_Click(object sender, EventArgs e)
    {
        reload(sender, e);
    }
}