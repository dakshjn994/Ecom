using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Mainmaster : System.Web.UI.MasterPage
{
    int i=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Title == "Bill" || Page.Title == "Shipping")
        {
            Car.Visible = false;
            colo.Visible = false;
        }
        if(Session["Email"]!=null && Session["Name"]!=null)
        {
            Login.Visible = false;
            Registration.Visible = false;
            Nam.Visible = true;
            Name.InnerText = "Hello, "+Session["Name"].ToString();
        }
        else
        {
            Nam.Visible = false;
            Logout.Visible = false;
        }
        if(Session["Cart"]!=null)
        {
            DataTable dt=(DataTable)Session["Cart"];
            foreach(DataRow dr in dt.Rows)
            {
                i+=Convert.ToInt32(dr["quantity"]);
            }
            Cart.InnerText = "Cart("+i+")";
        }
        switch (Page.Title)
        {
            case "Home":
                Homebutton.Attributes.Add("class", "active");
                break;
            case "About Us":
                Aboutbutton.Attributes.Add("class", "active");
                break;
            case "Services":
                Servicesbutton.Attributes.Add("class", "active");
                break;
            case "Customization":
                Custombutton.Attributes.Add("class", "active");
                break;
            case "PCB_Fabrication":
                Fabrication.Attributes.Add("class", "active");
                break;
            case "Contact":
                Contactbutton.Attributes.Add("class", "active");
                break;
            default:
                Homebutton.Attributes.Add("class", "active");
                break;
        }
    }
    protected void log_ServerClick(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("Index.aspx");
    }
}