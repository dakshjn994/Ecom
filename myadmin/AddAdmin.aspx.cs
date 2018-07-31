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

public partial class myadmin_AddAdmin : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ToString());
    string a="no",b="no";
    int no;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != null)
        {
            if (TextBox2.Text != null)
            {
                if (TextBox2.Text == TextBox3.Text)
                {
                    conn.Open();
                    SqlCommand co = conn.CreateCommand();
                    co.CommandText = "Select Name,Admin_Id From Admin Where Active=@y";
                    co.Parameters.AddWithValue("@y","yes");
                    DataTable tab = new DataTable();
                    SqlDataAdapter adap = new SqlDataAdapter(co);
                    adap.Fill(tab);
                    conn.Close();
                    foreach(DataRow dr in tab.Rows)
                    {
                        if(a=="no")
                        {      
                            string name=dr["Name"].ToString();
                            if(name==TextBox1.Text)
                            {
                                a = "yes";
                            }
                        }
                    }
                    if (a == "no")
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "Select Count(*) From Admin";
                        no = Convert.ToInt32(cmd.ExecuteScalar());
                        no = no + 101;
                        conn.Close();
                        foreach (DataRow dr in tab.Rows)
                        {
                            if (b == "no")
                            {
                                if (Convert.ToInt32(dr["Admin_Id"]) == no)
                                {
                                    b = "yes";
                                }
                            }
                        }
                        if(b=="yes")
                        {
                            no++;
                        }
                        conn.Open();
                        SqlCommand com = conn.CreateCommand();
                        com.CommandText = "Insert into Admin(Admin_Id,Name,Active,Password) values(@Admin_Id,@Name,@Active,@Password)";
                        com.Parameters.AddWithValue("@Admin_Id", no);
                        com.Parameters.AddWithValue("@Name", TextBox1.Text);
                        com.Parameters.AddWithValue("@Active", "yes");
                        com.Parameters.AddWithValue("@Password", TextBox2.Text);
                        com.ExecuteNonQuery();
                        conn.Close();
                        Response.Redirect("EditAdmin.aspx");
                    }
                    else
                    {
                        string var = "Name Exists(Please Use a New Name)";
                        Response.Write("<script language=javascript>alert('" + var + "');</script>");
                        TextBox1.Text = "";
                    }
                }
                else
                {
                    string var = "Passwords Dont Match";
                    Response.Write("<script language=javascript>alert('" + var + "');</script>");
                    TextBox1.Text = "";
                }
            }
            else
            {
                string var = "Please Enter Password";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
                TextBox1.Text = "";
            }
        }
        else
        {
            string var = "Please Enter Name";
            Response.Write("<script language=javascript>alert('" + var + "');</script>");
            TextBox1.Text = "";
        }
    }
}