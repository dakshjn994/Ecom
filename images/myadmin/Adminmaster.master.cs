using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class myadmin_Adminmaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"]!= null)
        {
            name.InnerText = " Hello, " + Session["AdminName"].ToString();
        }
        else
        {
            Response.Redirect("Index.aspx");
        }
    }
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Index.aspx");
    }
}