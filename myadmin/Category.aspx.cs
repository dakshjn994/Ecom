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
public partial class myadmin_Category : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
        if (Request.QueryString["Id"] != null && Request.QueryString["Name"]!=null)
        {
            cat.InnerText = "Edit Category";
            TextBox1.Text = Request.QueryString["Name"];
        }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] != null && Request.QueryString["Name"]!=null)
        {
            string id=Request.QueryString["Id"].ToString();
            con.Open();
            SqlCommand com = con.CreateCommand();
            com.CommandText = "Update Category Set Category_Name=@ac Where Category_Id=@bc";
            com.Parameters.AddWithValue("@ac", TextBox1.Text);
            com.Parameters.AddWithValue("@bc",id);
            com.ExecuteNonQuery();
            con.Close();
            Response.Redirect("CatAnd Sub.aspx");
        }
        else
        {
        bool a=false;
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select Count(*) From Category";
        int n = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        con.Close();
        n = n + 1001;
        con.Open();
        SqlCommand com = con.CreateCommand();
        com.CommandText = "Select Category_Name From Category Where Active!=@ac";
        com.Parameters.AddWithValue("@ac","no");
        DataTable dt = new DataTable();
        SqlDataAdapter sd = new SqlDataAdapter(com);
        sd.Fill(dt);
        con.Close();
        foreach(DataRow dr in dt.Rows)
        {
            if (a == false)
            {
                if (dr["Category_Name"].ToString() == TextBox1.Text)
                {
                    a = true;
                }
            }
        }
        if(a==false)
        {
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandText = "Insert into Category(Category_Id,Category_Name,Active) values(@Category_Id,@Category_Name,@Active)";
            cm.Parameters.AddWithValue("@Category_Id", n);
            cm.Parameters.AddWithValue("@Category_Name",TextBox1.Text);
            cm.Parameters.AddWithValue("@Active", "sub");
            cm.ExecuteNonQuery();
            con.Close();
            TextBox1.Text = "";
            Response.Redirect("Product.aspx");
        }
        else
        {
            string var = "Category Name Already Exists(Please Enter a new Name)";
            Response.Write("<script language=javascript>alert('" + var + "');</script>");
            TextBox1.Text = "";
        }
        }
    }
}