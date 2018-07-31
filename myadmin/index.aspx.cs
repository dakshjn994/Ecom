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

public partial class myadmin_index : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] != null)
        {
            Response.Redirect("Home.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string sas = "yes";
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select Count(*) from Admin where Name=@Email and  Password=@Password and Active=@Active", conn);
        cmd.Parameters.AddWithValue("@Email", txtName.Text.TrimEnd());
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.TrimEnd());
        cmd.Parameters.AddWithValue("@Active", sas.TrimEnd());
        int noOfUser = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        if (noOfUser == 1)
        {
            SqlCommand com = new SqlCommand("Select Password from Admin where Name=@Email and  Password=@Password", conn);
            com.Parameters.AddWithValue("@Email", txtName.Text.TrimEnd());
            com.Parameters.AddWithValue("@Password", txtPassword.Text.TrimEnd());
            com.Parameters.AddWithValue("@Active", sas.TrimEnd());
            string pass = Convert.ToString(com.ExecuteScalar().ToString());
            if (txtPassword.Text==pass)
            {
                string name = txtName.Text;
                Session["AdminName"] = name;
                Response.Redirect("Home.aspx");
            }
            else
            {
                string var = "Wrong Username/Password";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
        }
        else
        {
            string var = "Wrong Username/Password";
            Response.Write("<script language=javascript>alert('" + var + "');</script>");
        }
    }
}