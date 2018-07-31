using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Account : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ConnectionString);
    double a;
    string b,c;
    DataTable dable;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] != null && Session["Name"] != null)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Customer_Name,Address,Mobile_No from Customer Where Active = 'yes' And Email = @y";
            cmd.Parameters.AddWithValue("@y",(string)Session["Email"]);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                b= (string)dr["Address"];
                c = (string)dr["Customer_Name"];
                a = Convert.ToInt64(dr["Mobile_No"]);
            }
            add.InnerText = b;
            mob.InnerText = a.ToString();
            nam.InnerText = c;
            email.InnerText = (string)Session["Email"];
            SqlCommand com = con.CreateCommand();
            com.CommandText = "Select Bill_Id,Product_Name,Product_Quantity,Constraints,Address,Status from [Order] Where Customer_Email=@y";
            com.Parameters.AddWithValue("@y",(string)Session["Email"]);
            dable = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(com);
            ds.Fill(dable);
            if(dable.Rows.Count==0 || dable==null)
            {
                noor.Visible = true;
                DataList1.Visible = false;
            }
            else
            {
                DataList1.DataSource = dable;
                DataList1.DataBind();
            }

        }
        else
        {
            Response.Redirect("index.aspx");
        }
    }
}