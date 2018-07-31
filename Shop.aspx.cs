using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Shop : System.Web.UI.Page
{
    string id;
    DataTable dtCart=null;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"]!= null && Request.QueryString["Name"]!=null)
        {
            string name = Request.QueryString["Name"].ToString();
            string id = Request.QueryString["Id"].ToString();
            Typepro.InnerText = name;
            con.Open();
            SqlCommand com = con.CreateCommand();
            com.CommandText = "Select Item_Id,Image,MRP,SalePrice,Item_Name from Item Where Category_Id=@Id";
            com.Parameters.AddWithValue("Id",id);
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(table);
            DataList2.DataSource = table;
            DataList2.DataBind();
            con.Close();
        }
        else
        {
            Typepro.InnerText = "Sales and Featured Items";
            con.Open();
            SqlCommand com1 = con.CreateCommand();
            com1.CommandText = "Select Item_Id,Image,MRP,SalePrice,Item_Name from Item Where Featured=@y or Sales=@y";
            com1.Parameters.AddWithValue("y", "yes");
            DataTable table1 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter(com1);
            adapter1.Fill(table1);
            DataList2.DataSource = table1;
            DataList2.DataBind();
            con.Close();
        }
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select Category_Name,Category_Id from Category where Active='yes'";
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        DataList1.DataSource = dt;
        DataList1.DataBind();
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        if(b!=null)
        {
            id=b.CommandArgument;
            int i = Convert.ToInt32(id);
            //if (id != null)
            //{
            //    con.Open();
            //    SqlCommand co = con.CreateCommand();
            //    co.CommandText = "Select Item_Id,Image,SalePrice,Item_Name from Item Where Item_Id=@y";
            //    co.Parameters.AddWithValue("@y", i);
            //    DataTable tab = new DataTable();
            //    SqlDataAdapter adap = new SqlDataAdapter(co);
            //    adap.Fill(tab);
            //    Session["dtSelectedProduct"] = tab;
            //    con.Close();
                Response.Redirect("Details.aspx?Id="+i);
            }
        }
     protected void Button4_Click(object sender, EventArgs e)
{
         string id;
        Button b = sender as Button;
        if (b != null)
        {
            id = b.CommandArgument;
            Response.Redirect("Details.aspx?Id="+id);
        }
}
}
    //if (Session["Cart"] != null)
    //            {
    //                FillCart();
    //            }
    //            else
    //            {
    //                CreateCart();
    //                FillCart();
    //            }
    //private void CreateCart()
    //{
    //    dtCart = new DataTable();
    //    dtCart.Columns.Add("SrNo", typeof(int));
    //    dtCart.Columns.Add("Item_Id", typeof(int));
    //    dtCart.Columns.Add("Item_Name", typeof(string));
    //    dtCart.Columns.Add("Image", typeof(string));
    //    dtCart.Columns.Add("SalePrice", typeof(int));
    //    dtCart.Columns.Add("quantity", typeof(int));
    //    dtCart.Columns.Add("total", typeof(int));
    //}
    ////private void FillCart()
    //{
    //    try
    //    {
    //        if (Session["Cart"] != null)
    //        {
    //            dtCart = (DataTable)Session["Cart"];
    //        }
    //        DataTable dtSelProduct = (DataTable)Session["dtSelectedProduct"];
    //        //DataTable dtSelMaterial = (DataTable)Session["dtSelectedMaterial"];
    //        if (Session["dtSelectedProduct"] != null)
    //        {
    //            foreach (DataRow dr in dtSelProduct.Rows)
    //            {
    //                dtCart.Rows.Add(Convert.ToInt32(dtCart.Rows.Count + 1), Convert.ToInt32(dr["Item_Id"]), Convert.ToString(dr["Item_Name"]), Convert.ToString(dr["Image"]), Convert.ToInt32(dr["SalePrice"]), 1, Convert.ToInt32(dr["SalePrice"]));
    //            }
    //            Session["dtSelectedProduct"] = null;
    //        }
    //        //if (Session["dtSelectedMaterial"] != null)
    //        //{
    //        //    foreach (DataRow dr in dtSelMaterial.Rows)
    //        //    {
    //        //        dtCart.Rows.Add((dtCart.Rows.Count + 1), Convert.ToInt32(dr["Id"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["Money"]), 1, Convert.ToInt32(dr["Money"]));
    //        //    }
    //        //    Session["dtSelectedMaterial"] = null;

    //        //}
    //        Session["Cart"] = dtCart;
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Redirect("Shop.aspx" + ex.Message);
    //    }
    //}