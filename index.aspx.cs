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
    string id,a,c,unit,unit1;
    string[] st, str;
    DataTable dtCart=null,ds;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ConnectionString);
    int pos,pos1,pos2;
    PagedDataSource adsource, adsource1, adsource2;
    SqlDataAdapter dadapter, dadapter1, dadapter2;
    DataSet dset,dset1,dset2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ViewState["vs2"] = 0;
            this.ViewState["vs1"] = 0;
            this.ViewState["vs"] = 0;
        }
        pos = (int)this.ViewState["vs"];
        pos1 = (int)this.ViewState["vs1"];
        pos2 = (int)this.ViewState["vs2"];
        if(Request.QueryString["Id"]!=null && Request.QueryString["Name"]!=null)
        {
            string name = Request.QueryString["Name"].ToString();
            string id = Request.QueryString["Id"].ToString();
            Typepro.InnerText = name;
            dbind(id);
            databind();
            Databind();
            BindData();
            BData();
        }
        else if (Request.QueryString["UId"]!= null && Request.QueryString["UName"]!=null)
        {
            string name = Request.QueryString["UName"].ToString();
            string id = Request.QueryString["UId"].ToString();
            Typepro.InnerText = name;
            databind(id);
            Databind();
            databind();
            BindData();
            BData();
        }
        else
        {
            Typepro.Visible=false;
            DataList2.Visible = false;
            btnfirst.Visible = false;
            btnlast.Visible = false;
            btnnext.Visible = false;
            btnprevious.Visible = false;
            databind();
            Databind();
            BindData();
            BData();
        }
    }
    public void databind(string id)
    {
        con.Open();
        SqlCommand com = con.CreateCommand();
        com.CommandText = "Select Item_Id,Image,MRP,SalePrice,Item_Name from dbo.Item Where Sub_Category_Id=@Id and Active=@ac and In_Stock-Out_Stock > 0";
        com.Parameters.AddWithValue("@Id", id);
        com.Parameters.AddWithValue("@ac", "yes");
        dadapter = new SqlDataAdapter(com);
        dset = new DataSet();
        adsource = new PagedDataSource();
        dadapter.Fill(dset);
        adsource.DataSource = dset.Tables[0].DefaultView;
        adsource.PageSize = 4;
        adsource.AllowPaging = true;
        adsource.CurrentPageIndex = pos;
        btnfirst.Visible = !adsource.IsFirstPage;
        btnprevious.Visible = !adsource.IsFirstPage;
        btnlast.Visible = !adsource.IsLastPage;
        btnnext.Visible = !adsource.IsLastPage;
        DataList2.DataSource = adsource;
        DataList2.DataBind();
        con.Close();
    }
    public void dbind(string id)
    {
        con.Open();
        SqlCommand com = con.CreateCommand();
        com.CommandText = "Select Item_Id,Image,MRP,SalePrice,Item_Name from dbo.Item Where Category_Id=@Id and Active=@ac and In_Stock-Out_Stock > 0";
        com.Parameters.AddWithValue("@Id", id);
        com.Parameters.AddWithValue("@ac", "yes");
        dadapter = new SqlDataAdapter(com);
        dset = new DataSet();
        if (dset.Tables[0].Rows.Count != 0)
        {
            adsource = new PagedDataSource();
            dadapter.Fill(dset);
            adsource.DataSource = dset.Tables[0].DefaultView;
            adsource.PageSize = 4;
            adsource.AllowPaging = true;
            adsource.CurrentPageIndex = pos;
            btnfirst.Visible = !adsource.IsFirstPage;
            btnprevious.Visible = !adsource.IsFirstPage;
            btnlast.Visible = !adsource.IsLastPage;
            btnnext.Visible = !adsource.IsLastPage;
            DataList2.DataSource = adsource;
            DataList2.DataBind();
            con.Close();
        }
        else
        {
            DataList2.Visible = false;
            Pro.Visible = true;
            Pro.InnerText = "No Products Available";
        }
    }
    public void databind()
    {
        con.Open();
        SqlCommand com2 = con.CreateCommand();
        com2.CommandText = "Select Item_Id,Image,MRP,SalePrice,Item_Name from dbo.Item Where Featured = @y and Active = @y and In_Stock-Out_Stock > 0";
        com2.Parameters.AddWithValue("@y", "yes");
        dadapter1 = new SqlDataAdapter(com2);
        dset1 = new DataSet();
        adsource1 = new PagedDataSource();
        dadapter1.Fill(dset1);
        con.Close();
        if (dset1.Tables[0].Rows.Count != 0)
        {
            adsource1.DataSource = dset1.Tables[0].DefaultView;
            adsource1.PageSize = 2;
            adsource1.AllowPaging = true;
            adsource1.CurrentPageIndex = pos1;
            btnPrevious1.Visible = !adsource1.IsFirstPage;
            btnNext1.Visible = !adsource1.IsLastPage;
            DataList3.DataSource = adsource1;
            DataList3.DataBind();
        }
        else
        {
            fea.Visible = false;
            //H2.Visible = false;
            //btnNext1.Visible = false;
            //btnPrevious1.Visible = false;
            //DataList3.Visible = false;
        }
    }
    private void Databind()
    {
        con.Open();
        SqlCommand com2 = con.CreateCommand();
        com2.CommandText = "Select Item_Id,Image,MRP,SalePrice,Item_Name from dbo.Item Where Sales = @y and Active = @y and In_Stock-Out_Stock > 0";
        com2.Parameters.AddWithValue("y", "yes");
        dadapter2 = new SqlDataAdapter(com2);
        dset2 = new DataSet();
        adsource2 = new PagedDataSource();
        dadapter2.Fill(dset2);
        con.Close();
        if (dset2.Tables[0].Rows.Count != 0 )
        {
            adsource2.DataSource = dset2.Tables[0].DefaultView;
            adsource2.PageSize = 2;
            adsource2.AllowPaging = true;
            adsource2.CurrentPageIndex = pos2;
            btnPrevious2.Visible = !adsource2.IsFirstPage;
            btnNext2.Visible = !adsource2.IsLastPage;
            DataList4.DataSource = adsource2;
            DataList4.DataBind();
        }
        else
        {
            sal.Visible = false;
            //btnPrevious2.Visible = false;
            //btnNext2.Visible = false;
            //DataList4.Visible = false;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        if(b!=null)
        {
            id=b.CommandArgument;
            int i = Convert.ToInt32(id);
            con.Open();
            SqlCommand cm = con.CreateCommand();
            cm.CommandText = "Select Constraint_Options,Constraint_Options1,Constraint_Unit,Constraint_Unit From dbo.Item Where Item_Id=@I and Active=@a";
            cm.Parameters.AddWithValue("@a","yes");
            cm.Parameters.AddWithValue("@I", i);
            DataTable ad = new DataTable();
            SqlDataAdapter sda=new SqlDataAdapter(cm);
            sda.Fill(ad);
            foreach(DataRow dr in ad.Rows)
            {
                a= dr["Constraint_Options"].ToString();
                c = dr["Constraint_Options1"].ToString();
                unit = dr["Constraint_Unit"].ToString();
                unit1 = dr["Constraint_Unit1"].ToString();
            }
            st=a.Split(',');
            str=c.Split(',');
            SqlCommand com = con.CreateCommand();
            com.CommandText = "Select Item_Id,Item_Name,Image,Description,SalePrice from dbo.Item Where Item_Id=@I";
            com.Parameters.AddWithValue("@I",i);
            ds=new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(com);
            dap.Fill(ds);
            con.Close();
            Session["dtSelectedProduct"] = ds;
            if(Session["Cart"]!=null)
            {
                FillCart();
            }
            else
            {
                CreateCart();
                FillCart();
            }
            }
        Response.Redirect(Request.Url.ToString());
        }
    private void CreateCart()
    {
        dtCart = new DataTable();
        dtCart.Columns.Add("SrNo", typeof(int));
        dtCart.Columns.Add("Item_Id", typeof(int));
        dtCart.Columns.Add("Item_Name", typeof(string));
        dtCart.Columns.Add("Image", typeof(string));
        dtCart.Columns.Add("Description", typeof(string));
        dtCart.Columns.Add("SalePrice", typeof(int));
        dtCart.Columns.Add("Constraint", typeof(string));
        dtCart.Columns.Add("quantity", typeof(int));
        dtCart.Columns.Add("total", typeof(int));
    }
    private void FillCart()
    {
        try
        {
            if (Session["Cart"] != null)
            {
                dtCart = (DataTable)Session["Cart"];
            }
            DataTable dtSelProduct = (DataTable)Session["dtSelectedProduct"];
            if (Session["dtSelectedProduct"] != null)
            {
                foreach (DataRow dr in dtSelProduct.Rows)
                {
                    dtCart.Rows.Add(Convert.ToInt32(dtCart.Rows.Count + 1), Convert.ToInt32(dr["Item_Id"]), Convert.ToString(dr["Item_Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["SalePrice"]), Convert.ToString(st[0]+unit+"," +str[0]+unit1), 1, Convert.ToInt32(dr["SalePrice"]));
                }
                Session["dtSelectedProduct"] = null;
            }
            //if (Session["dtSelectedMaterial"] != null)
            //{
            //    foreach (DataRow dr in dtSelMaterial.Rows)
            //    {
            //        dtCart.Rows.Add((dtCart.Rows.Count + 1), Convert.ToInt32(dr["Id"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["Money"]), 1, Convert.ToInt32(dr["Money"]));
            //    }
            Session["dtSelectedMaterial"] = null;
            Session["Cart"] = dtCart;
        }
        catch (Exception ex)
        {
            Response.Redirect("Index.aspx" + ex.Message);
        }
    }
    protected void btnfirst_Click(object sender, EventArgs e)
    {
        pos = 0;
        if(Request.QueryString["UId"]!=null && Request.QueryString["UName"]!=null)
        {
            string id = Request.QueryString["UId"].ToString();
            databind();
            Databind();
            databind(id);
        }
        else if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
        {
            string id = Request.QueryString["Id"].ToString();
            databind();
            Databind();
            dbind(id);
        }
        else
        {
        databind();
        Databind();
        }
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        pos = (int)this.ViewState["vs"];
        pos -= 1;
        this.ViewState["vs"] = pos;
        if(Request.QueryString["UId"]!=null && Request.QueryString["UName"]!=null)
        {
            string id = Request.QueryString["UId"].ToString();
            databind();
            Databind();
            databind(id);
        }
        else if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
        {
            string id = Request.QueryString["Id"].ToString();
            databind();
            Databind();
            dbind(id);
        }
        else
        {
        databind();
        Databind();
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        pos = (int)this.ViewState["vs"];
        pos += 1;
        this.ViewState["vs"] = pos;
        if (Request.QueryString["UId"] != null && Request.QueryString["UName"] != null)
        {
            string id = Request.QueryString["UId"].ToString();
            databind();
            Databind();
            databind(id);
        }
        else if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
        {
            string id = Request.QueryString["Id"].ToString();
            databind();
            Databind();
            dbind(id);
        }
        else
        {
            databind();
            Databind();
        }
    }

    protected void btnlast_Click(object sender, EventArgs e)
    {
        pos = adsource.PageCount - 1;
        if (Request.QueryString["UId"] != null && Request.QueryString["UName"] != null)
        {
            string id = Request.QueryString["UId"].ToString();
            databind();
            Databind();
            databind(id);
        }
        else if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
        {
            string id = Request.QueryString["Id"].ToString();
            databind();
            Databind();
            dbind(id);
        }
        else
        {
            databind();
            Databind();
        }
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
        SqlCommand myCommand = new SqlCommand("usp_GetProductsForCategories", con);
        myCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter ad = new SqlDataAdapter(myCommand);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        ds.Relations.Add(new DataRelation("CategoriesRelation", ds.Tables[0].Columns["Category_Id"], ds.Tables[1].Columns["Category_Id"]));
        outerDataList.DataSource = ds.Tables[0];
        outerDataList.DataBind();
    }
    private void BData()
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select Category_Id,Category_Name From Category Where Active=@ac";
        cmd.Parameters.AddWithValue("@ac","sub");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
    protected void btnNext1_Click(object sender, EventArgs e)
    {
        pos1 = (int)this.ViewState["vs1"];
        pos1 += 1;
        this.ViewState["vs1"] = pos1;
        if (Request.QueryString["UId"] != null && Request.QueryString["UName"] != null)
        {
            string id = Request.QueryString["UId"].ToString();
            databind();
            Databind();
            databind(id);
        }
        else if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
        {
            string id = Request.QueryString["Id"].ToString();
            databind();
            Databind();
            dbind(id);
        }
        else
        {
            databind();
            Databind();
        }
    }
    protected void btnPrevious1_Click(object sender, EventArgs e)
    {
        pos1 = (int)this.ViewState["vs1"];
        pos1 -= 1;
        this.ViewState["vs1"] = pos1;
        if (Request.QueryString["UId"] != null && Request.QueryString["UName"] != null)
        {
            string id = Request.QueryString["UId"].ToString();
            databind();
            Databind();
            databind(id);
        }
        else if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
        {
            string id = Request.QueryString["Id"].ToString();
            databind();
            Databind();
            dbind(id);
        }
        else
        {
            databind();
            Databind();
        }
    }
    protected void btnPrevious2_ServerClick(object sender, EventArgs e)
    {
        pos2 = (int)this.ViewState["vs2"];
        pos2 -= 1;
        this.ViewState["vs2"] = pos2;
        if (Request.QueryString["UId"] != null && Request.QueryString["UName"] != null)
        {
            string id = Request.QueryString["UId"].ToString();
            databind();
            Databind();
            databind(id);
        }
        else if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
        {
            string id = Request.QueryString["Id"].ToString();
            databind();
            Databind();
            dbind(id);
        }
        else
        {
            databind();
            Databind();
        }
    }
    protected void btnNext2_ServerClick(object sender, EventArgs e)
    {
        pos2 = (int)this.ViewState["vs2"];
        pos2 += 1;
        this.ViewState["vs2"] = pos2;
        if (Request.QueryString["UId"] != null && Request.QueryString["UName"] != null)
        {
            string id = Request.QueryString["UId"].ToString();
            databind();
            Databind();
            databind(id);
        }
        else if (Request.QueryString["Id"] != null && Request.QueryString["Name"] != null)
        {
            string id = Request.QueryString["Id"].ToString();
            databind();
            Databind();
            dbind(id);
        }
        else
        {
            databind();
            Databind();
        }
    }
}