using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;

public partial class Default2 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Email"]==null)
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void rdbtnExi_CheckedChanged(object sender, EventArgs e)
    {
        txtAddress.Enabled = false;
        txtAddress.Visible = false;
        txtAddress.Text = "";
    }
    protected void rdbtnNew_CheckedChanged(object sender, EventArgs e)
    {
        txtAddress.Enabled = true;
        txtAddress.Visible = true;
    }
    protected void btnShip_Click(object sender, EventArgs e)
    {
        if(rdbtnExi.Checked==true)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select Address from Customer Where Email=@e";
            cmd.Parameters.AddWithValue("@e",Session["Email"].ToString());
            conn.Open();
            Session["Add"]=cmd.ExecuteScalar().ToString();
            conn.Close();
            Response.Redirect("Billing.aspx");
        }
        if(rdbtnNew.Checked==true)
        {
            if(txtAddress.Text!="")
            {
                Session["Add"] = txtAddress.Text;
                Response.Redirect("Billing.aspx");
            }
        }
    }
}