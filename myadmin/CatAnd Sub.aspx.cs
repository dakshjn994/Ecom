using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class myadmin_CatAnd_Sub : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand myCommand = new SqlCommand("usp_GetProductsForCategories", con);
        myCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter ad = new SqlDataAdapter(myCommand);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ds.Relations.Add(new DataRelation("CategoriesRelation", ds.Tables[0].Columns["Category_Id"], ds.Tables[1].Columns["Category_Id"]));
        outerDataList.DataSource = ds.Tables[0];
        outerDataList.DataBind();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select Category_Id,Category_Name From Category Where Active=@ac";
        cmd.Parameters.AddWithValue("@ac", "sub");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
    protected void outerDataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            DataRowView drv = e.Item.DataItem as DataRowView;
            DataList innerDataList = e.Item.FindControl("innerDataList") as DataList;
            innerDataList.DataSource = drv.CreateChildView("CategoriesRelation");
            innerDataList.DataBind();
        }
        else
        {
            DataRowView drv = e.Item.DataItem as DataRowView;
            DataList innerDataList = e.Item.FindControl("innerDataList") as DataList;
            innerDataList.DataSource = drv.CreateChildView("CategoriesRelation");
            innerDataList.DataBind();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //sub
        ImageButton b=sender as ImageButton;
        if (b != null)
        {
            string id = b.CommandArgument;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update Item SET Active=@a,Sub_Category_Id=@c Where Sub_Category_Id=@b";
            cmd.Parameters.AddWithValue("@a","no");
            cmd.Parameters.AddWithValue("@b", id);
            cmd.Parameters.AddWithValue("@c",DBNull.Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SqlCommand g = con.CreateCommand();
            g.CommandText = "Select Category_Id From MinorCategory Where Sub_Category_Id=@a AND Active=@b";
            g.Parameters.AddWithValue("@a", id);
            g.Parameters.AddWithValue("@b", "yes");
            con.Open();
            int s = Convert.ToInt32(g.ExecuteScalar().ToString());
            con.Close();
            SqlCommand d = con.CreateCommand();
            d.CommandText = "Select Count(*) From MinorCategory Where Active=@a AND Category_Id=@b";
            d.Parameters.AddWithValue("@a","yes");
            d.Parameters.AddWithValue("@b",s);
            con.Open(); int a = Convert.ToInt32(d.ExecuteScalar().ToString()); con.Close();
            if (a == 1)
            {
                SqlCommand cm = con.CreateCommand();
                cm.CommandText = "Update MinorCategory Set Active=@a Where Sub_Category_Id=@b";
                cm.Parameters.AddWithValue("@a", "no");
                cm.Parameters.AddWithValue("@b", id);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
                SqlCommand q = con.CreateCommand();
                q.CommandText = "Update Category Set Active=@a Where Category_Id=@b";
                q.Parameters.AddWithValue("@a", "sub");
                q.Parameters.AddWithValue("@b", s);
                con.Open();
                q.ExecuteNonQuery();
                con.Close();
                Response.Redirect("CatAnd Sub.aspx");
            }
            else
            {
                SqlCommand cm = con.CreateCommand();
                cm.CommandText = "Update MinorCategory Set Active=@a Where Sub_Category_Id=@b";
                cm.Parameters.AddWithValue("@a", "no");
                cm.Parameters.AddWithValue("@b", id);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
                Response.Redirect("CatAnd Sub.aspx");
            }
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        //categorywithsubs
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        //categorywithoutsubs
    }
}