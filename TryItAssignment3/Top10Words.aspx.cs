using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Top10Words : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Top10WordList.Visible = false;
    }
    /// <summary>
    /// Event to triggr service call and get output
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTopTen_Click(object sender, EventArgs e)
    {
        Regex R =new Regex(@"https://([A-Za-z0-9\-]+).[A-Za-z0-9\-]+");
        if (R.Match(urlInput.Text).Success)
        {
            if (urlInput.Text != "")
            {

                String[] words = new String[10];
                ServiceSubscription.Service1Client subscribe = new ServiceSubscription.Service1Client();
                words = subscribe.Top10Words(urlInput.Text);
                foreach (string word in words)
                {
                    Top10WordList.Items.Add(word);
                }
                Top10WordList.Visible = true;
            }
        }
        else
            Console.WriteLine("Incorrect URL");
    }
}