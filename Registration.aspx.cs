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

public partial class Registration : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (txtfname.Text != null && txtmname.Text != null && txtlname.Text != null)
        //{
        //    if (txtadd1.Text != null && txtadd2.Text != null)
        //    {
        //        if (txtpswd!=null)
        //        {
        if (txtpswd.Text == txtrpswd.Text)
        {
            if (CheckBox1.Checked==true)
            {
                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert into Customer(Email,Customer_Name,Address,Password,Mobile_No,Active) values(@Email,@Name,@Address,@Password,@Mobile,@Active)";
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Name", txtfname.Text +" "+ txtmname.Text +" "+ txtlname.Text);
                    cmd.Parameters.AddWithValue("@Address", txtadd1.Text + ddltown.SelectedItem.Text+" - "+txtpin.Text+","+txtstate.Text+","+txtcountry.Text);
                    cmd.Parameters.AddWithValue("@Password", txtpswd.Text);
                    cmd.Parameters.AddWithValue("@Mobile", txtcontact.Text);
                    cmd.Parameters.AddWithValue("@Active", "yes");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    SendEmail123 s = new SendEmail123();
                    s.sendEMail(txtemail.Text, "You Have Been Successfully Registered With Digitronicarts");
                    Response.Redirect("Login.aspx");
                }
                catch(SqlException se)
                {
                    string var = "Email Already Exists";
                    Response.Write("<script language=javascript>alert('" + var + "');</script>");
                }
            }
            else
            {
                string var = "Please Accept Terms And Conditions";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
        }
        else
        {
            string var = "Passwords Do Not Match";
            Response.Write("<script language=javascript>alert('" + var + "');</script>");
        }
            //        }
            //        else
            //        {

            //        }
            //    }
            //    else
            //    {

            //    }
            //}
            //else
            //{

            //}
        }
    }