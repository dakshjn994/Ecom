using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class myadmin_SampleImage : System.Web.UI.Page
{
    DataTable dtCart = null,dt1,dt2;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ConnectionString);
    string a;
    int id,b;
    string d,d1,d2,d3,d4;
    string[] options, options1, options2, options3, options4;
    string unit, unit1, unit2, unit3, unit4;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select * from Category Where Active!=@a";
        cmd.Parameters.AddWithValue("@a","no");
        dtCart = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dtCart);
        if(Label1.Visible==true)
        {
            photo.Visible = true;
        }
        else
        {
            photo.Visible = false;
        }
        if (!IsPostBack)
        {
            DropDownList1.DataSource = dtCart;
            DropDownList1.DataTextField = "Category_Name";
            DropDownList1.DataValueField = "Category_Id";
            DropDownList1.DataBind();
            ListItem Category = new ListItem("Select Category","-1");
            DropDownList1.Items.Insert(0, Category);
            DropDownList2.Visible = false;
            DropDownList3.Visible = false;
            DropDownList5.Visible = false;
            DropDownList6.Visible = false;
            DropDownList7.Visible = false;
            DropDownList8.Visible = false;
            DropDownList9.Visible = false;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex != 0)
        {
            foreach (DataRow dr in dtCart.Rows)
            {
                if (dr["Category_Id"].ToString() == DropDownList1.SelectedItem.Value)
                {
                    a = dr["Active"].ToString();
                }
            }
            if (a == "yes")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select Sub_Category_Id,Sub_Category_Name from MinorCategory where Category_Id=@a And Active=@b";
                cmd.Parameters.AddWithValue("@a", DropDownList1.SelectedItem.Value.ToString());
                cmd.Parameters.AddWithValue("@b", "yes");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.Visible = false;
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "Sub_Category_Name";
                DropDownList2.DataValueField = "Sub_Category_Id";
                DropDownList2.DataBind();
                ListItem Subcategory = new ListItem("Select Sub-Category", "-1");
                DropDownList2.Items.Insert(0, Subcategory);
                DropDownList2.Visible = true;
                DropDownList5.Visible = false;
                DropDownList6.Visible = false;
                DropDownList7.Visible = false;
                DropDownList8.Visible = false;
                DropDownList9.Visible = false;
                photo.Visible = false;
                Label1.Visible = false;
                Label1.Text = null;
                ViewState["a"] = a;
            }
            if (a == "sub")
            {
                id = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select Item_Id,Item_Name,NoOfConstraints from Item where Category_Id=@a And Active=@b";
                cmd.Parameters.AddWithValue("@a", DropDownList1.SelectedItem.Value.ToString());
                cmd.Parameters.AddWithValue("@b", "yes");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.Visible = false;
                DropDownList3.DataSource = dt;
                DropDownList3.DataTextField = "Item_Name";
                DropDownList3.DataValueField = "Item_Id";
                DropDownList3.DataBind();
                ListItem Item = new ListItem("Select Product", "-1");
                DropDownList3.Items.Insert(0, Item);
                DropDownList3.Visible = true;
                DropDownList5.Visible = false;
                DropDownList6.Visible = false;
                DropDownList7.Visible = false;
                DropDownList8.Visible = false;
                DropDownList9.Visible = false;
                photo.Visible = false;
                Label1.Visible = false;
                Label1.Text = null;
                ViewState["id"] = id;
                ViewState["a"] = a;
            }
        }
        else
        {
            photo.Visible = false;
            DropDownList2.Visible = false;
            DropDownList3.Visible = false;
            DropDownList5.Visible = false;
            DropDownList6.Visible = false;
            DropDownList7.Visible = false;
            DropDownList8.Visible = false;
            DropDownList9.Visible = false;
            Label1.Visible = false;
            Label1.Text = null;
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedIndex != 0)
        {
            id = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Item_Id,Item_Name from Item where Sub_Category_Id=@a And Active=@b";
            cmd.Parameters.AddWithValue("@a", DropDownList2.SelectedItem.Value.ToString());
            cmd.Parameters.AddWithValue("@b", "yes");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt1 = new DataTable();
            da.Fill(dt1);
            DropDownList3.DataSource = dt1;
            DropDownList3.DataTextField = "Item_Name";
            DropDownList3.DataValueField = "Item_Id";
            DropDownList3.DataBind();
            ListItem Item = new ListItem("Select Product", "-1");
            DropDownList3.Items.Insert(0, Item);
            DropDownList3.Visible = true;
            DropDownList5.Visible = false;
            DropDownList6.Visible = false;
            DropDownList7.Visible = false;
            DropDownList8.Visible = false;
            DropDownList9.Visible = false;
            Label1.Visible = false;
            Label1.Text = null;
            photo.Visible = false;
            ViewState["id"] = id;
            ViewState["dt1"] = dt1;
        }
        else
        {
            photo.Visible = false;
            DropDownList3.Visible = false;
            DropDownList5.Visible = false;
            DropDownList6.Visible = false;
            DropDownList7.Visible = false;
            DropDownList8.Visible = false;
            DropDownList9.Visible = false;
            Label1.Visible = false;
            Label1.Text = null;
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedIndex != 0)
        {
            //int b=new int();
            //DataTable ds=(DataTable)ViewState["dt1"];
            //foreach(DataRow dr in ds.Rows)
            //{
            //    if (DropDownList3.SelectedValue==dr["Item_Id"].ToString())
            //{
            //    b = Convert.ToInt32(dr["NoOfConstraints"]);
            //}
            //}
            SqlCommand cmd = con.CreateCommand();
            //if (a == "yes")
            //{
            //    if (b == 1)
            //    {
            //        cmd.CommandText = "Select Constraint_Unit,Constraint_Options from Item Where Category_Id=@a and Item_Id=@c and Active=@b";
            //        cmd.Parameters.AddWithValue("@a",id);
            //        cmd.Parameters.AddWithValue("@b", "yes");
            //        cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
            //    }
            //    if (b == 2)
            //    {
            //        cmd.CommandText = "Select Constraint_Unit,Constraint_Unit1,Constraint_Options,Constraint_Options1 from Item Where Category_Id=@a and Item_Id=@c and Active=@b";
            //        cmd.Parameters.AddWithValue("@a", id);
            //        cmd.Parameters.AddWithValue("@b", "yes");
            //        cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
            //    }
            //    if (b == 3)
            //    {
            //        cmd.CommandText = "Select Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Options,Constraint_Options1,Constraint_Options2 from Item Where Category_Id=@a and Item_Id=@c and Active=@b";
            //        cmd.Parameters.AddWithValue("@a", id);
            //        cmd.Parameters.AddWithValue("@b", "yes");
            //        cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
            //    }
            //    if (b == 4)
            //    {
            //        cmd.CommandText = "Select Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Unit3,Constraint_Options,Constraint_Options1,Constraint_Options2,Constraint_Options3 from Item Where Category_Id=@a and Item_Id=@c and Active=@b";
            //        cmd.Parameters.AddWithValue("@a", id);
            //        cmd.Parameters.AddWithValue("@b", "yes");
            //        cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
            //    }
            //    if (b == 5)
            //    {
            //        cmd.CommandText = "Select Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Unit3,Constraint_Unit4,Constraint_Options,Constraint_Options1,Constraint_Options2,Constraint_Options3,Constraint_Options4 from Item Where Category_Id=@a and Item_Id=@c and Active=@b";
            //        cmd.Parameters.AddWithValue("@a", id);
            //        cmd.Parameters.AddWithValue("@b", "yes");
            //        cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
            //    }
            //}
            //if (a == "sub")
            //{
            //    if (b == 1)
            //    {
            //        cmd.CommandText = "Select Constraint_Unit,Constraint_Options from Item Where Sub_Category_Id=@a and Item_Id=@c and Active=@b";
            //        cmd.Parameters.AddWithValue("@a", id);
            //        cmd.Parameters.AddWithValue("@b", "yes");
            //        cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
            //    }
            //    if (b == 2)
            //    {
            //        cmd.CommandText = "Select Constraint_Unit,Constraint_Unit1,Constraint_Options,Constraint_Options1 from Item Where Sub_Category_Id=@a and Item_Id=@c and Active=@b";
            //        cmd.Parameters.AddWithValue("@a", id);
            //        cmd.Parameters.AddWithValue("@b", "yes");
            //        cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
            //    }
            //    if (b == 3)
            //    {
            //        cmd.CommandText = "Select Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Options,Constraint_Options1,Constraint_Options2 from Item Where Sub_Category_Id=@a and Item_Id=@c and Active=@b";
            //        cmd.Parameters.AddWithValue("@a", id);
            //        cmd.Parameters.AddWithValue("@b", "yes");
            //        cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
            //    }
            //    if (b == 4)
            //    {
            //        cmd.CommandText = "Select Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Unit3,Constraint_Options,Constraint_Options1,Constraint_Options2,Constraint_Options3 from Item Where Sub_Category_Id=@a and Item_Id=@c and Active=@b";
            //        cmd.Parameters.AddWithValue("@a", id);
            //        cmd.Parameters.AddWithValue("@b", "yes");
            //        cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
            //    }
            //    if (b == 5)
            //    {
            //        cmd.CommandText = "Select Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Unit3,Constraint_Unit4,Constraint_Options,Constraint_Options1,Constraint_Options2,Constraint_Options3,Constraint_Options4 from Item Where Sub_Category_Id=@a and Item_Id=@c and Active=@b";
            //        cmd.Parameters.AddWithValue("@a", id);
            //        cmd.Parameters.AddWithValue("@b", "yes");
            //        cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
            //    }
            //}
            a = ViewState["a"].ToString();
            if (a == "yes")
            {
                cmd.CommandText = "Select NoOfConstraints,Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Unit3,Constraint_Unit4,Constraint_Options,Constraint_Options1,Constraint_Options2,Constraint_Options3,Constraint_Options4 from Item Where Item_Id=@c and Active=@b";
                cmd.Parameters.AddWithValue("@b", "yes");
                cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
                ViewState["Item"] = DropDownList3.SelectedValue;
            }
            if (a == "sub")
            {
                cmd.CommandText = "Select NoOfConstraints,Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Unit3,Constraint_Unit4,Constraint_Options,Constraint_Options1,Constraint_Options2,Constraint_Options3,Constraint_Options4 from Item Where Item_Id=@c and Active=@b";
                cmd.Parameters.AddWithValue("@b", "yes");
                cmd.Parameters.AddWithValue("@c", DropDownList3.SelectedValue);
                ViewState["Item"] = DropDownList3.SelectedValue;
            }
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt2 = new DataTable();
            da.Fill(dt2);
            con.Close();
            b = new int();
            foreach (DataRow dr in dt2.Rows)
            {
                b = Convert.ToInt32(dr["NoOfConstraints"]);
            }
            if (b == 1)
            {
                foreach (DataRow dr in dt2.Rows)
                {
                    d = (dr["Constraint_Options"]).ToString();
                    options = d.Split(',');
                    unit = dr["Constraint_Unit"].ToString();
                    int i = 0;
                    foreach (string s in options)
                    {
                        options[i] = s + unit;
                        i++;
                    }
                }
                DropDownList5.DataSource = options;
                DropDownList5.DataBind();
                ListItem Item = new ListItem("Select Constraint", "-1");
                DropDownList5.Items.Insert(0, Item);
                DropDownList5.Visible = true;
                DropDownList6.Visible = false;
                DropDownList7.Visible = false;
                DropDownList8.Visible = false;
                DropDownList9.Visible = false;
                ViewState["b"] = b;
            }
            if (b == 2)
            {
                foreach (DataRow dr in dt2.Rows)
                {
                    d = dr["Constraint_Options"].ToString();
                    options = d.Split(',');
                    unit = dr["Constraint_Unit"].ToString();
                    int i = 0;
                    foreach (string s in options)
                    {
                        options[i] = s + unit;
                        i++;
                    }
                    d = dr["Constraint_Options1"].ToString();
                    options1 = d.Split(',');
                    unit1 = dr["Constraint_Unit1"].ToString();
                    i = 0;
                    foreach (string s in options1)
                    {
                        options1[i] = s + unit1;
                        i++;
                    }
                }
                DropDownList5.DataSource = options;
                DropDownList5.DataBind();
                ListItem Item = new ListItem("Select Constraint", "-1");
                DropDownList5.Items.Insert(0, Item);
                DropDownList5.Visible = true;
                DropDownList6.DataSource = options1;
                DropDownList6.DataBind();
                DropDownList6.Items.Insert(0, Item);
                DropDownList6.Visible = true;
                DropDownList7.Visible = false;
                DropDownList8.Visible = false;
                DropDownList9.Visible = false;
                ViewState["b"] = b;
            }
            if (b == 3)
            {
                foreach (DataRow dr in dt2.Rows)
                {
                    d = dr["Constraint_Options"].ToString();
                    options = d.Split(',');
                    unit = dr["Constraint_Unit"].ToString();
                    int i = 0;
                    foreach (string s in options)
                    {
                        options[i] = options[i] + unit;
                        i++;
                    }
                    d = dr["Constraint_Options1"].ToString();
                    options1 = d.Split(',');
                    unit1 = dr["Constraint_Unit1"].ToString();
                    i = 0;
                    foreach (string s in options1)
                    {
                        options1[i] = s + unit1;
                        i++;
                    }
                    d = dr["Constraint_Options2"].ToString();
                    options2 = d.Split(',');
                    unit2 = dr["Constraint_Unit2"].ToString();
                    i = 0;
                    foreach (string s in options2)
                    {
                        options2[i] = s + unit2;
                        i++;
                    }
                }
                DropDownList5.DataSource = options;
                DropDownList5.DataBind();
                ListItem Item = new ListItem("Select Constraint", "-1");
                DropDownList5.Items.Insert(0, Item);
                DropDownList5.Visible = true;
                DropDownList6.DataSource = options1;
                DropDownList6.DataBind();
                DropDownList6.Items.Insert(0, Item);
                DropDownList6.Visible = true;
                DropDownList7.DataSource = options2;
                DropDownList7.DataBind();
                DropDownList7.Items.Insert(0, Item);
                DropDownList7.Visible = true;
                DropDownList8.Visible = false;
                DropDownList9.Visible = false;
                ViewState["b"] = b;
            }
            if (b == 4)
            {
                foreach (DataRow dr in dt2.Rows)
                {
                    d = dr["Constraint_Options"].ToString();
                    options = d.Split(',');
                    unit = dr["Constraint_Unit"].ToString();
                    int i = 0;
                    foreach (string s in options)
                    {
                        options[i] = s + unit;
                        i++;
                    }
                    d = dr["Constraint_Options1"].ToString();
                    options1 = d.Split(',');
                    unit1 = dr["Constraint_Unit1"].ToString();
                    i = 0;
                    foreach (string s in options1)
                    {
                        options1[i] = s + unit1;
                        i++;
                    }
                    d = dr["Constraint_Options2"].ToString();
                    options2 = d.Split(',');
                    unit2 = dr["Constraint_Unit2"].ToString();
                    i = 0;
                    foreach (string s in options2)
                    {
                        options2[i] = s + unit2;
                        i++;
                    }
                    d = dr["Constraint_Options3"].ToString();
                    options3 = d.Split(',');
                    unit3 = dr["Constraint_Unit3"].ToString();
                    i = 0;
                    foreach (string s in options3)
                    {
                        options3[i] = s + unit3;
                        i++;
                    }
                }
                DropDownList5.DataSource = options;
                DropDownList5.DataBind();
                ListItem Item = new ListItem("Select Constraint", "-1");
                DropDownList5.Items.Insert(0, Item);
                DropDownList5.Visible = true;
                DropDownList6.DataSource = options1;
                DropDownList6.DataBind();
                DropDownList6.Items.Insert(0, Item);
                DropDownList6.Visible = true;
                DropDownList7.DataSource = options2;
                DropDownList7.DataBind();
                DropDownList7.Items.Insert(0, Item);
                DropDownList7.Visible = true;
                DropDownList8.DataSource = options3;
                DropDownList8.DataBind();
                DropDownList8.Items.Insert(0, Item);
                DropDownList8.Visible = true;
                DropDownList9.Visible = false;
                ViewState["b"] = b;
            }
            if (b == 5)
            {
                foreach (DataRow dr in dt2.Rows)
                {
                    d = dr["Constraint_Options"].ToString();
                    options = d.Split(',');
                    unit = dr["Constraint_Unit"].ToString();
                    int i = 0;
                    foreach (string s in options)
                    {
                        options[i] = s + unit;
                        i++;
                    }
                    d = (dr["Constraint_Options1"]).ToString();
                    options1 = d.Split(',');
                    unit1 = dr["Constraint_Unit1"].ToString();
                    i = 0;
                    foreach (string s in options1)
                    {
                        options1[i] = s + unit1;
                        i++;
                    }
                    d = dr["Constraint_Options2"].ToString();
                    options2 = d.Split(',');
                    unit2 = dr["Constraint_Unit2"].ToString();
                    i = 0;
                    foreach (string s in options2)
                    {
                        options2[i] = s + unit2;
                        i++;
                    }
                    d = dr["Constraint_Options3"].ToString();
                    options3 = d.Split(',');
                    unit3 = dr["Constraint_Unit3"].ToString();
                    i = 0;
                    foreach (string s in options3)
                    {
                        options3[i] = s + unit3;
                        i++;
                    }
                    d = dr["Constraint_Options4"].ToString();
                    options4 = d.Split(',');
                    unit4 = dr["Constraint_Unit4"].ToString();
                    i = 0;
                    foreach (string s in options4)
                    {
                        options4[i] = s + unit4;
                        i++;
                    }
                }
                DropDownList5.DataSource = options;
                DropDownList5.DataBind();
                ListItem Item = new ListItem("Select Constraint", "-1");
                DropDownList5.Items.Insert(0, Item);
                DropDownList5.Visible = true;
                DropDownList6.DataSource = options1;
                DropDownList6.DataBind();
                DropDownList6.Items.Insert(0, Item);
                DropDownList6.Visible = true;
                DropDownList7.DataSource = options2;
                DropDownList7.DataBind();
                DropDownList7.Items.Insert(0, Item);
                DropDownList7.Visible = true;
                DropDownList8.DataSource = options3;
                DropDownList8.DataBind();
                DropDownList8.Items.Insert(0, Item);
                DropDownList8.Visible = true;
                DropDownList9.DataSource = options4;
                DropDownList9.DataBind();
                DropDownList9.Items.Insert(0, Item);
                DropDownList9.Visible = true;
                ViewState["b"] = b;
            }
        }
        else
        {
            photo.Visible = false;
            DropDownList5.Visible = false;
            DropDownList6.Visible = false;
            DropDownList7.Visible = false;
            DropDownList8.Visible = false;
            DropDownList9.Visible = false;
            Label1.Visible = false;
            Label1.Text = null;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0 && DropDownList3.SelectedIndex != 0)
        {
            if (DropDownList5.SelectedIndex != 0 || DropDownList6.SelectedIndex != 0 || DropDownList7.SelectedIndex != 0 || DropDownList8.SelectedIndex != 0 || DropDownList9.SelectedIndex != 0)
            {
                b = Convert.ToInt32(ViewState["b"]);
                if (b == 1)
                {
                    photo.Visible = true;
                    Label1.Text = DropDownList5.SelectedItem.Text;
                    Label1.Visible = true;
                }
                if (b == 2)
                {
                    photo.Visible = true;
                    Label1.Text = DropDownList5.SelectedItem.Text + "," + DropDownList6.SelectedItem.Text;
                    Label1.Visible = true;
                }
                if (b == 3)
                {
                    photo.Visible = true;
                    Label1.Text = DropDownList5.SelectedItem.Text + "," + DropDownList6.SelectedItem.Text + "," + DropDownList7.SelectedItem.Text;
                    Label1.Visible = true;
                }
                if (b == 4)
                {
                    photo.Visible = true;
                    Label1.Text = DropDownList5.SelectedItem.Text + "," + DropDownList6.SelectedItem.Text + "," + DropDownList7.SelectedItem.Text + "," + DropDownList8.SelectedItem.Text;
                    Label1.Visible = true;
                }
                if (b == 5)
                {
                    photo.Visible = true;
                    Label1.Text = DropDownList5.SelectedItem.Text + "," + DropDownList6.SelectedItem.Text + "," + DropDownList7.SelectedItem.Text + "," + DropDownList8.SelectedItem.Text + "," + DropDownList9.SelectedItem.Text;
                    Label1.Visible = true;
                }
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string extension = (string)Path.GetExtension(FileUpload1.FileName);
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp")
            {
                string s = ("~/images/product-details/Uploads/" + FileUpload1.FileName).ToString();
                FileUpload1.SaveAs(Server.MapPath(s));
                Image1.Visible = true;
                Label2.Text = s;
                Image1.ImageUrl = s;
                string var = "File Successfully Uploaded";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
            else
            {
                Image1.ImageUrl = "~/images/home/Default_image.png";
                string var = "Please Upload Correct Format File";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
        }
        else
        {
            Image1.ImageUrl = "~/images/home/Default_image.png";
            string var = "Please Upload Image File";
            Response.Write("<script language=javascript>alert('" + var + "');</script>");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex != 0 && DropDownList2.SelectedIndex != 0 && DropDownList3.SelectedIndex != 0 && Image1.ImageUrl!="~/images/home/Default_image.png")
        {
            if (DropDownList5.SelectedIndex != 0 || DropDownList6.SelectedIndex != 0 || DropDownList7.SelectedIndex != 0 || DropDownList8.SelectedIndex != 0 || DropDownList9.SelectedIndex != 0)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Insert into Sample(Product_Id,Constraints,Image) values(@Prod,@Const,@Image)";
                cmd.Parameters.AddWithValue("@Prod", Convert.ToString(DropDownList3.SelectedValue));
                cmd.Parameters.AddWithValue("@Const", Label1.Text);
                cmd.Parameters.AddWithValue("@Image", Label2.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                string var = "Sample Value Added";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
        }
    }
}