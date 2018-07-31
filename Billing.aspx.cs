using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Printing;

public partial class Billing : System.Web.UI.Page
{
    int a=0,b=0,order=0,d=0;
    DataTable dt;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Cart"]!=null)
        {
            dt=(DataTable)Session["Cart"];
            DataList1.DataSource = dt;
            DataList1.DataBind();
            foreach(DataRow dr in dt.Rows)
            {
                b += (int)dr["quantity"];
                a += (int)dr["total"];
            }
            total.InnerText = "₹ " + a.ToString();
            qua.InnerText = b.ToString();
        }
        else
        {
            Response.Redirect("index.aspx");
        }
        if (Session["Name"]!=null && Session["Email"]!=null)
        {
            name.InnerText = (string)Session["Name"];
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
        if(Session["Add"]!=null)
        {
            add.InnerText = (string)Session["Add"];
        }
        else
        {
            Response.Redirect("Shipping.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cm = new SqlCommand("Select Count(*) from [Order]",con);
        con.Open();
        string x = cm.ExecuteScalar().ToString();
        con.Close();
        //if (x == null)
        //{
        //    order = 0;
        //}
        //else
        //{
           order = Convert.ToInt32(x);
        //}
        order++;
        SqlCommand cd = con.CreateCommand();
        cd.CommandText = "Select Count(DISTINCT Bill_Id ) from dbo.[Order]";
        con.Open();
        string z = cd.ExecuteScalar().ToString();
        con.Close();
        //if (z == null)
        //{
        //    d = 0;
        //}
        //else
        //{
            d = Convert.ToInt32(z);
        //}
        d = d + 100001;
        string ab = "DG" + d.ToString();
        foreach(DataRow dr in dt.Rows)
        {
            string i=dr["Item_Id"].ToString()+dr["quantity"].ToString()+order.ToString();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Insert into [Order](Order_Id,Bill_Id,Customer_Email,Product_Id,Product_Name,Product_Quantity,Total,Constraints,Date,Address,Status) values(@Order_Id,@Bill_Id,@Customer_Email,@Product_Id,@Product_Name,@Product_Quantity,@Total,@Constraints,@Date,@Address,@Status)";
        cmd.Parameters.AddWithValue("@Order_Id",i.ToString());
        cmd.Parameters.AddWithValue("@Bill_Id", ab);
        cmd.Parameters.AddWithValue("@Customer_Email", (string)Session["Email"]);
        cmd.Parameters.AddWithValue("@Product_Id", (int)dr["Item_Id"]);
        cmd.Parameters.AddWithValue("@Product_Name", (string)dr["Item_Name"]);
        cmd.Parameters.AddWithValue("@Product_Quantity", (int)dr["quantity"]);
        cmd.Parameters.AddWithValue("@Constraints", (string)dr["Constraint"]);
        cmd.Parameters.AddWithValue("@Total", (string)dr["total"]);
        cmd.Parameters.AddWithValue("@Date", (string)DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@Address", (string)Session["Add"]);
        cmd.Parameters.AddWithValue("@Status", "pending");
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        SqlCommand sd =con.CreateCommand();
        sd.CommandText = "Select Out_Stock From Item Where Item_Id=@Product_Id";
        sd.Parameters.AddWithValue("@Product_Id", (int)dr["Item_Id"]);
        con.Open();
        int a = Int32.Parse(sd.ExecuteScalar().ToString());
        con.Close();
        a = a + (int)dr["quantity"];
        SqlCommand sql = con.CreateCommand();
        sql.CommandText = "Update Item Set Out_Stock=@a Where Item_Id=@Product_Id";
        sql.Parameters.AddWithValue("@Product_Id", (int)dr["Item_Id"]);
        sql.Parameters.AddWithValue("@a", a);
        con.Open();
        sql.ExecuteNonQuery();
        con.Close();
        }
        Session["Cart"] = null;
        Response.Redirect("/index.aspx");
    }
}