using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class nameDate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public String EmpName
    {
        get
        {
            return nameTextBox.Text;
        }
        set
        {
            nameTextBox.Text = value;
        }

    }
    public DateTime EmpDOB
    {
        get
        {
            return Convert.ToDateTime(birthTextBox.Text);
        }
        set 
        {
            birthTextBox.Text = value.ToString();
        }
    }
}