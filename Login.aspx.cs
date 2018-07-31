using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string sas = "yes";
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select Count(*) from Customer where Email=@Email and  Password=@Password", conn);
        cmd.Parameters.AddWithValue("@Email", txtemail.Text.TrimEnd());
        cmd.Parameters.AddWithValue("@Password", txtpswd.Text.TrimEnd());
        cmd.Parameters.AddWithValue("@Active", sas.TrimEnd());
        int noOfUser = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        if (noOfUser == 1)
        {
            SqlCommand com = new SqlCommand("Select Password from Customer where Email=@Email and  Password=@Password", conn);
            com.Parameters.AddWithValue("@Email", txtemail.Text.TrimEnd());
            com.Parameters.AddWithValue("@Password", txtpswd.Text.TrimEnd());
            com.Parameters.AddWithValue("@Active", sas.TrimEnd());
            string pass = Convert.ToString(com.ExecuteScalar().ToString());
            if (txtpswd.Text == pass)
            {
                SqlCommand cmm = new SqlCommand("Select Customer_Name from Customer where Email=@Email and  Password=@Password", conn);
                cmm.Parameters.AddWithValue("@Email", txtemail.Text.TrimEnd());
                cmm.Parameters.AddWithValue("@Password", txtpswd.Text.TrimEnd());
                cmm.Parameters.AddWithValue("@Active", sas.TrimEnd());
                string name = Convert.ToString(cmm.ExecuteScalar().ToString());
                string[] nam = name.Split(' ');
                Session["Name"] = nam[0];
                Session["Email"] = txtemail.Text;
                Response.Redirect("Index.aspx");
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