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

public partial class Testing : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
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
    private void BindData()
    {
        SqlCommand myCommand = new SqlCommand("usp_GetProductsForCategories", conn);
        myCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter ad = new SqlDataAdapter(myCommand);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ds.Relations.Add(new DataRelation("CategoriesRelation", ds.Tables[0].Columns["Category_Id"],ds.Tables[1].Columns["Category_Id"]));
        outerDataList.DataSource = ds.Tables[0];
        outerDataList.DataBind();
    }
}