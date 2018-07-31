using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Cart : System.Web.UI.Page
{
    DataTable dtCart;
    int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable d=(DataTable)Session["Cart"];
        if (Session["Cart"] != null)
        {
            if (d.Rows.Count != 0)
            {
                abc.Visible = false;
            }
            else
            {
                abc.InnerText = "No Products In Cart";
                Checkout.Enabled = false;
            }
        }
        else
        {
            abc.InnerText = "No Products In Cart";
            Checkout.Enabled = false;
        }
        if (!IsPostBack)
        {
            Cool();
        }
    }
    public void Cool()
    {

        if (Session["Cart"] != null)
        {
            FillCart();
        }
        else
        {
            CreateCart();
            FillCart();
        }

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
            //DataTable dtSelMaterial = (DataTable)Session["dtSelectedMaterial"];
            if (Session["dtSelectedProduct"] != null)
            {
                foreach (DataRow dr in dtSelProduct.Rows)
                {
                    dtCart.Rows.Add(Convert.ToInt32(dtCart.Rows.Count + 1), Convert.ToInt32(dr["Item_Id"]), Convert.ToString(dr["Item_Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["SalePrice"]), Convert.ToString(dr["Constraint"]), 1, Convert.ToInt32(dr["SalePrice"]));
                }
                Session["dtSelectedProduct"] = null;
            }
            //if (Session["dtSelectedMaterial"] != null)
            //{
            //    foreach (DataRow dr in dtSelMaterial.Rows)
            //    {
            //        dtCart.Rows.Add((dtCart.Rows.Count + 1), Convert.ToInt32(dr["Id"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["Money"]), 1, Convert.ToInt32(dr["Money"]));
            //    }
            //    Session["dtSelectedMaterial"] = null;

            //}
            Session["Cart"] = dtCart;
            DataList1.DataSource = dtCart;
            DataList1.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    protected void imgDeleteProduct_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dtCart = (DataTable)Session["Cart"];
            int SrNo = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            dtCart.Rows.RemoveAt((SrNo - 1));
            dtCart = RegenerateDataTable(dtCart);
            DataList1.DataSource = dtCart;
            DataList1.DataBind();
            Session["Cart"] = dtCart;
            if (dtCart.Rows.Count == 0)
            {
                Checkout.Enabled = false;
            }
            else
            {
                Checkout.Enabled = true;
            }
            Response.Redirect("Cart.aspx");
        }
        catch (Exception ex)
        {
         
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
           Button b = sender as Button;
        if (b != null)
        {
            string a = b.CommandArgument;
            DataTable dtCart = (DataTable)Session["Cart"];
            DataListItem row = (DataListItem)b.NamingContainer;
            if (row != null)
            {
                int quantity = Convert.ToInt32(((TextBox)(row.FindControl("ddlQuantity"))).Text);
                if(quantity!=1000)
                {
                quantity++;
                }
                int index = Convert.ToInt32(a);
                int price = Convert.ToInt32(dtCart.Rows[row.ItemIndex]["SalePrice"]);
                dtCart.Rows[row.ItemIndex].SetField("quantity", (quantity));
                dtCart.Rows[row.ItemIndex].SetField("total", (quantity * price));
                DataList1.DataSource = dtCart;
                DataList1.DataBind();
                Session["Cart"] = dtCart;
            }
        }
        Response.Redirect("Cart.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        Button b = sender as Button;
        if (b != null)
        {
            string a = b.CommandArgument;
            DataTable dtCart = (DataTable)Session["Cart"];
            DataListItem row = (DataListItem)b.NamingContainer;
            if (row != null)
            {
                int quantity = Convert.ToInt32(((TextBox)(row.FindControl("ddlQuantity"))).Text);
                if (quantity != 1)
                {
                    quantity--;
                }
                int index = Convert.ToInt32(a);
                int price = Convert.ToInt32(dtCart.Rows[row.ItemIndex]["SalePrice"]);
                dtCart.Rows[row.ItemIndex].SetField("quantity", (quantity));
                dtCart.Rows[row.ItemIndex].SetField("total", (quantity * price));
                DataList1.DataSource = dtCart;
                DataList1.DataBind();
                Session["Cart"] = dtCart;
            }
        }
        Response.Redirect("Cart.aspx");
    }
        private DataTable RegenerateDataTable(DataTable dt)
    {
        int srno = 0;
        DataTable dtDup = dt.Clone();
        try
        {
            foreach (DataRow row in dt.Rows)
            {
                DataRow drNew = dtDup.NewRow();
                srno += 1;
                drNew[0] = srno;
                drNew[1] = row[1];
                drNew[2] = row[2];
                drNew[3] = row[3];
                drNew[4] = row[4];
                drNew[5] = row[5];
                drNew[6] = row[6];
                drNew[7] = row[7];
                dtDup.Rows.Add(drNew);
            }
        }
        catch (Exception ex)
        {
            
        }
        return dtDup;
        }
        protected void Checkout_Click(object sender, EventArgs e)
        {
            if (Session["Name"] == null || Session["Email"] == null)
            {

                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["Email"] != null)
                {
                    //string str=Convert.ToString(Session["Email"]);
                    Response.Redirect("Shipping.aspx");
                    //string data = "Hello Sir" ;
                    //Email(str,data);
                }
            }
        }
}
//Button b = sender as Button;
//        if(b!=null)
//        {
//            string a=b.CommandArgument;
//            DataTable dtCart = (DataTable)Session["Cart"];
//            foreach(DataRow dr in dtCart.Rows)
//            {
//                if(dr["SrNo"]==a)
//                {
//                    int quantity=Convert.ToInt32(dr["quantity"]);
//                    quantity++;
//                    dr["quantity"]=quantity;
//                    dr["total"] = Convert.ToInt32(dr["quantity"]) * Convert.ToInt32(dr["SalePrice"]);
//                }
//            }
//            DataList1.DataSource = dtCart;
//            DataList1.DataBind();
//            Session["Cart"] = dtCart;
//            Response.Redirect("Cart.aspx");
//        }