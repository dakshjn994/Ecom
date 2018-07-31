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

public partial class myadmin_Subcategory : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ToString());
    int c;
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "Select Category_Id,Category_Name from Category Where Active!=@a";
        cmd.Parameters.AddWithValue("@a","no");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if(!IsPostBack)
        {
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Category_Name";
            DropDownList1.DataValueField = "Category_Id";
            DropDownList1.DataBind();
            ListItem Category = new ListItem("Select Category", "-1");
            DropDownList1.Items.Insert(0, Category);
        }
        if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
        {
            if (!IsPostBack)
            {
                id=Request.QueryString["Id"].ToString();
                subcat.InnerText = "Edit Sub-Category";
                SqlCommand cm = conn.CreateCommand();
                cm.CommandText = "Select Category_Id from MinorCategory Where Sub_Category_Id=@a";
                cm.Parameters.AddWithValue("@a",id);
                conn.Open();
                c=Convert.ToInt32(cm.ExecuteScalar());
                conn.Close();
                DropDownList1.SelectedValue=c.ToString();
                TextBox1.Enabled = true;
                TextBox1.Text = Request.QueryString["Name"].ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex != 0 && TextBox1.Text != "")
        {
            if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
            {
                SqlCommand cd = conn.CreateCommand();
                cd.CommandText = "Update Category Set Active=@a Where Category_Id=@b";
                cd.Parameters.AddWithValue("@a", "yes");
                cd.Parameters.AddWithValue("@b", DropDownList1.SelectedValue);
                conn.Open();
                cd.ExecuteNonQuery();
                conn.Close();
                id = Request.QueryString["Id"].ToString();
                int i = Convert.ToInt32(id.ToString());
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Update MinorCategory Set Category_Id=@b,Sub_Category_Name=@c,Active=@d where Sub_Category_Id=@a";
                cmd.Parameters.AddWithValue("@a", i);
                cmd.Parameters.AddWithValue("@b", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@c", TextBox1.Text);
                cmd.Parameters.AddWithValue("@d", "yes");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("CatAnd Sub.aspx");
            }
            else
            {
            SqlCommand cd = conn.CreateCommand();
            cd.CommandText = "Update Category Set Active=@a Where Category_Id=@b";
            cd.Parameters.AddWithValue("@a","yes");
            cd.Parameters.AddWithValue("@b",DropDownList1.SelectedValue);
            conn.Open();
            cd.ExecuteNonQuery();
            conn.Close();
            SqlCommand cm=conn.CreateCommand();
            cm.CommandText="Select Count(*) From MinorCategory Where Active=@a";
            cm.Parameters.AddWithValue("@a","yes");
            conn.Open();
            int i=Convert.ToInt32(cm.ExecuteScalar().ToString());
            conn.Close();
            i=i+1000001;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Insert into MinorCategory(Sub_Category_Id,Category_Id,Sub_Category_Name,Active) Values(@a,@b,@c,@d)";
            cmd.Parameters.AddWithValue("@a",i);
            cmd.Parameters.AddWithValue("@b", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@c",TextBox1.Text);
            cmd.Parameters.AddWithValue("@d","yes");
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            SqlCommand cf = conn.CreateCommand();
            cf.CommandText = "Update Item Set Sub_Category_Id=@a Where Category_Id=@b";
            cf.Parameters.AddWithValue("@a", i);
            cf.Parameters.AddWithValue("@b", DropDownList1.SelectedValue);
            conn.Open();
            cf.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("CatAnd Sub.aspx");
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
        {
        }
        else
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                ViewState["val"] = DropDownList1.SelectedValue;
                TextBox1.Text = null;
                TextBox1.Enabled = true;
            }
            else
            {
                TextBox1.Text = null;
                TextBox1.Enabled = false;
            }
        }
    }
}