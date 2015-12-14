﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class prospectus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String prospID = Request.QueryString["ProspID"];
        if (prospID != null)
        {
            prospectusXml.DocumentSource = prospID + ".xml";
        }
    }
}
