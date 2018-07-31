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
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "Select Category_Id,Category_Name from Category Where Active=@a";
        cmd.Parameters.AddWithValue("@a","yes");
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
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex != 0 && TextBox1.Text != "")
        {
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
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
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