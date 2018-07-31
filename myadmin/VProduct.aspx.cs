using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class myadmin_VProduct : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select Item_Id,Item_Name,Image,NoOfConstraints,MRP,SalePrice,In_Stock,Out_Stock,Sales,Featured,Category_Id,Sub_Category_Id From Item Where Active=@ac";
        cmd.Parameters.AddWithValue("@ac", "yes");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = sender as ImageButton;
        if (b != null)
        {
                string a = b.CommandArgument;
                SqlCommand com = con.CreateCommand();
                com.CommandText = "Delete from Item Where Item_Id=@a";
                com.Parameters.AddWithValue("@a",a);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                Response.Redirect("VProduct.aspx");
        }
    }
}