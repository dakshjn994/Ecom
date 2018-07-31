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

public partial class myadmin_EditAdmin : System.Web.UI.Page
{
    int no;
    string id,a,b,id1;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        form.Visible = false;
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select Admin_Id,Name From Admin Where Active=@ac";
        cmd.Parameters.AddWithValue("@ac","yes");
        DataTable dt = new DataTable();
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        adap.Fill(dt);
        con.Close();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    } 
    protected void Button3_Click(object sender, EventArgs e)
    {
                if (TextBox2.Text == TextBox3.Text)
                {
                    con.Open();
                    SqlCommand co = con.CreateCommand();
                    co.CommandText = "Select Name,Admin_Id From Admin";
                    DataTable tab = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter(co);
                    adap.Fill(tab);
                    con.Close();
                    //foreach (DataRow dr in tab.Rows)
                    //{
                    //    if (a == "no")
                    //    {
                    //        string name = dr["Name"].ToString();
                    //        if (name == TextBox1.Text)
                    //        {
                    //            a = "yes";
                    //        }
                    //    }
                    //}
                    //if (a == "no")
                    //{
                    id = (string)ViewState["Id"];
                        con.Open();
                        SqlCommand com = con.CreateCommand();
                        com.CommandText = "Update Admin Set Name=@Name,Active=@Active,Password=@Password Where Admin_Id=@Admin_Id";
                        com.Parameters.AddWithValue("@Admin_Id", id);
                        com.Parameters.AddWithValue("@Name", TextBox1.Text);
                        com.Parameters.AddWithValue("@Active", "yes");
                        com.Parameters.AddWithValue("@Password", TextBox2.Text);
                        com.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("EditAdmin.aspx");
                    }
                //    else
                //    {
                //        string var = "Name Exists(Please Use a New Name)";
                //        Response.Write("<script language=javascript>alert('" + var + "');</script>");
                //        TextBox1.Text = "";
                //    }
                //}
                else
                {
                    string var = "Passwords Dont Match";
                    Response.Write("<script language=javascript>alert('" + var + "');</script>");
                    TextBox1.Text = "";
                }
            }
    protected void Button4_Click(object sender, EventArgs e)
    {
        form.Visible = false;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = sender as ImageButton;
        if (b != null)
        {
            id = b.CommandArgument;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * From Admin Where Admin_Id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                TextBox1.Text = dr["Name"].ToString();
                form.Visible = true;
            }
            ViewState["Id"] = id;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
string i;
ImageButton b = sender as ImageButton;
        if(b!=null)
        {
           i=b.CommandArgument;
           con.Open();
           SqlCommand cmd = con.CreateCommand();
           cmd.CommandText = "Update Admin set Active=@ac Where Admin_Id=@id";
           cmd.Parameters.AddWithValue("@ac", "no");
           cmd.Parameters.AddWithValue("@id", i);
           cmd.ExecuteNonQuery();
           con.Close();
           Response.Redirect("EditAdmin.aspx");
        }
    }
}