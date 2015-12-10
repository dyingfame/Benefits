using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class life : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Trace.Write("Look at Here!","Trace success!");

    }
    protected void saveButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
            messageLabel.Text = "This page is validated.";
    }
}
