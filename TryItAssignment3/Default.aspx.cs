using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;
        foreach (TableRow tRow in SvcTable.Rows)
        {
            if (i == 1)
            {
                TableCell btnCell = new TableCell();
                Button btn = new Button();
                btn.Text = "Try It";
                btn.Click += new EventHandler(InvokeTop10WordsSvc);
                btnCell.Controls.Add(btn);
                tRow.Cells.Add(btnCell);
            }
            if(i == 2)
            {
                TableCell btnCell = new TableCell();
                Button btn = new Button();
                btn.Text = "Try It";
                btn.Click += new EventHandler(InvokeWordFilter);
                btnCell.Controls.Add(btn);
                tRow.Cells.Add(btnCell);
            }
            if (i == 3)
            {
                TableCell btnCell = new TableCell();
                Button btn = new Button();
                btn.Text = "Try It";
                btn.Click += new EventHandler(InvokeTopUsedWords);
                btnCell.Controls.Add(btn);
                tRow.Cells.Add(btnCell);
            }
            if (i == 4)
            {
                TableCell btnCell = new TableCell();
                Button btn = new Button();
                btn.Text = "Try It";
                btn.Click += new EventHandler(InvokeTransactionSummary);
                btnCell.Controls.Add(btn);
                tRow.Cells.Add(btnCell);
            }
            if (i == 5)
            {
                TableCell btnCell = new TableCell();
                Button btn = new Button();
                btn.Text = "Try It";
                btn.Click += new EventHandler(InvokeTopNearByPlaceFinder);
                btnCell.Controls.Add(btn);
                tRow.Cells.Add(btnCell);
            }
            if (i == 6)
            {
                TableCell btnCell = new TableCell();
                Button btn = new Button();
                btn.Text = "Try It";
                btn.Click += new EventHandler(InvokeImageVerifier);
                btnCell.Controls.Add(btn);
                tRow.Cells.Add(btnCell);
            }
            i++;
        }
    }

    private void InvokeImageVerifier(object sender, EventArgs e)
    {
        Response.Redirect("ImageVerifier.aspx");
    }

    private void InvokeTopNearByPlaceFinder(object sender, EventArgs e)
    {
        Response.Redirect("TopNearbyPlaceFinder.aspx");
    }

    private void InvokeTransactionSummary(object sender, EventArgs e)
    {
        Response.Redirect("TransactionSummarizer.aspx");
    }

    private void InvokeTopUsedWords(object sender, EventArgs e)
    {
        Response.Redirect("TopUsedWords.aspx");
    }

    /// <summary>
    /// Funtion to Invoke Service: to find out top 10 most used words
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void InvokeTop10WordsSvc(object sender, EventArgs e)
    {
        Response.Redirect("Top10Words.aspx");
    }
    /// <summary>
    /// Function to invoke service  : word filter
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void InvokeWordFilter(object sender, EventArgs e)
    {
        Response.Redirect("WordFilter.aspx");
    }
}