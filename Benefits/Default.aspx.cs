using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Trace.Warn("2310", "Beginning of Page_Load");
        //Trace.Warn("2310", "IsPostBack=" + Page.IsPostBack);
        Benefits benefitsList = new Benefits();
        if (!Page.IsPostBack)
        {
            foreach (Benefits.BenefitInfo benefit in benefitsList.GetBenefitsList())
            {
                listBenefitsCheckBoxList.Items.Add("<a href=" + benefit.benefitPage + ">" + benefit.benefitName + "</a>");
            }
        }
    }
    protected void listBenefitsCheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void submitButton_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < listBenefitsCheckBoxList.Items.Count; i++)
        {
            if (listBenefitsCheckBoxList.Items[i].Selected)
                selectionsLabel.Text += listBenefitsCheckBoxList.Items[i].Text + "  ";
        }
    }
}
