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

public partial class myadmin_RCategory : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ToString());
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        formy.Visible = false;
        if (!IsPostBack)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Category_Id,Category_Name From Category Where Active=@ac";
            cmd.Parameters.AddWithValue("@ac", "yes");
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
           cmd.CommandText = "Update Category set Active=@ac Where Category_Id=@id";
           cmd.Parameters.AddWithValue("@ac", "no");
           cmd.Parameters.AddWithValue("@id", i);
           SqlCommand com = con.CreateCommand();
           com.CommandText = "Update Item set Active=@ac Where Category_Id=@id";
           com.Parameters.AddWithValue("@ac", "no");
           com.Parameters.AddWithValue("@id", i);
           com.ExecuteNonQuery();
           cmd.ExecuteNonQuery();
           con.Close();
           Response.Redirect("RCategory.aspx");
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = sender as ImageButton;
        if (b != null)
        {
            id = b.CommandArgument;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * From Category Where Category_Id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                TextBox1.Text = dr["Category_Name"].ToString();
                formy.Visible = true;
            }
            ViewState["Id"] = id;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        id = (string)ViewState["Id"];
        con.Open();
        SqlCommand com = con.CreateCommand();
        com.CommandText = "Update Category Set Name=@Name Where Category_Id=@Admin_Id";
        com.Parameters.AddWithValue("@Admin_Id", id);
        com.Parameters.AddWithValue("@Name", TextBox1.Text);
        com.ExecuteNonQuery();
        con.Close();
        Response.Redirect("RCategory.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        formy.Visible = false;
    }
}