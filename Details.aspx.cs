using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AjaxControlToolkit;
using System.Drawing;
public partial class Details : System.Web.UI.Page
{
    DataTable dtCart, dtable;
    string name1, image, image1, image2, money, mrp1, id1, constname, constname1, constname2, constname3, constname4, constoptions, constoptions1, constoptions2, constoptions3, constoptions4, des, unit, unit1, unit2, unit3, unit4;
    string[] options, options1, options2, options3, options4;
    int i,no,tot=0,ave=0,asd;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        i = Convert.ToInt32(Request.QueryString["Id"]);
        id1 = Convert.ToString(Request.QueryString["Id"]);
        if (id1 != null)
        {
            con.Open();
            SqlCommand co = con.CreateCommand();
            co.CommandText = "Select Image,Image1,Image2,NoOfConstraints,SalePrice,MRP,Item_Name,Description from Item Where Item_Id=@y and In_Stock-Out_Stock > 0";
            co.Parameters.AddWithValue("@y", i);
            DataTable tab = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(co);
            adap.Fill(tab);
            //Session["dtSelectedProduct"] = tab;
            con.Close();
            foreach (DataRow row in tab.Rows)
            {
                image = row["Image"].ToString();
                image1 = row["Image1"].ToString();
                image2 = row["Image2"].ToString();
                money = row["SalePrice"].ToString();
                name1 = row["Item_Name"].ToString();
                mrp1 = row["MRP"].ToString();
                des = row["Description"].ToString();
                no = Convert.ToInt32(row["NoOfConstraints"]);
            }
            Dropdown(no);
            Des.InnerText = des;
            Image1.ImageUrl = image;
            Image2.ImageUrl=image1;
            Image3.ImageUrl = image2;
            ImageB1.Src = image;
            ImageB2.Src = image1;
            ImageB3.Src = image2;
            name.InnerText = name1;
            mrp.InnerText = mrp1;
            sales.InnerText = money;
            //Constraint1.InnerText = constname + " (" + unit + ")";
            //Constraint2.InnerText = constname1 + " (" + unit1 + ")";
            //options = constoptions.Split(',');
            //options1 = constoptions1.Split(',');
            //for (int a = 0; a < options.Length; a++)
            //{
            //    options[a] = options[a] + unit;
            //}
            //for (int j = 0; j < options1.Length; j++)
            //{
            //    options1[j] = options1[j] + unit1;
            //}
            SqlCommand cm = con.CreateCommand();
            cm.CommandText = "Select Comment,Email,Rating from Comment Where Product_Id=@y And Active=@a";
            cm.Parameters.AddWithValue("@y",i);
            cm.Parameters.AddWithValue("@a","yes");
            SqlDataAdapter sd = new SqlDataAdapter(cm);
            dtable = new DataTable();
            sd.Fill(dtable);
            DataList1.DataSource = dtable;
            DataList1.DataBind();
            if (dtable.Rows.Count != 0)
            {
                foreach (DataRow dr in dtable.Rows)
                {
                    tot += Convert.ToInt32(dr["Rating"]);
                }
                ave = tot / (dtable.Rows.Count);
                Rating2.CurrentRating = ave;
            }
            else
            {
                Rating2.Visible = false;
            }
            if (!IsPostBack)
            {
                //DropDownList2.DataSource = options1;
                //DropDownList2.DataBind();
                //DropDownList1.DataSource = options;
                //DropDownList1.DataBind();
                Dropdownenable(no);
            }
        }
        else
        {
            Response.Redirect("Index.aspx");
        }
    }
    private void Dropdownenable(int a)
    {
        if(a==1)
        {
            DropDownList1.DataSource = options;
            DropDownList1.DataBind();
            constr1.Visible = false;
            DropDownList2.Visible = false;
            constr2.Visible = false;
            DropDownList3.Visible = false;
            constr3.Visible = false;
            DropDownList4.Visible = false;
            constr4.Visible = false;
            DropDownList5.Visible = false;
        }
        if (a == 2)
        {
            DropDownList1.DataSource = options;
            DropDownList1.DataBind();
            DropDownList2.DataSource = options1;
            DropDownList2.DataBind();
            constr2.Visible = false;
            DropDownList3.Visible = false;
            constr3.Visible = false;
            DropDownList4.Visible = false;
            constr4.Visible = false;
            DropDownList5.Visible = false;
        }
        if (a == 3)
        {
            DropDownList1.DataSource = options;
            DropDownList1.DataBind();
            DropDownList2.DataSource = options1;
            DropDownList2.DataBind();
            DropDownList3.DataSource = options2;
            DropDownList3.DataBind();
            constr3.Visible = false;
            DropDownList4.Visible = false;
            constr4.Visible = false;
            DropDownList5.Visible = false;
        }
        if (a == 4)
        {
            DropDownList1.DataSource = options;
            DropDownList1.DataBind();
            DropDownList2.DataSource = options1;
            DropDownList2.DataBind();
            DropDownList3.DataSource = options2;
            DropDownList3.DataBind();
            DropDownList4.DataSource = options3;
            DropDownList4.DataBind();
            constr4.Visible = false;
            DropDownList5.Visible = false;
        }
        if (a == 5)
        {
            DropDownList1.DataSource = options;
            DropDownList1.DataBind();
            DropDownList2.DataSource = options1;
            DropDownList2.DataBind();
            DropDownList3.DataSource = options2;
            DropDownList3.DataBind();
            DropDownList4.DataSource = options3;
            DropDownList4.DataBind();
            DropDownList5.DataSource = options3;
            DropDownList5.DataBind();
        }
    }
    private void Dropdown(int a)
    {
        if(a==1)
        {
            con.Open();
            SqlCommand co = con.CreateCommand();
            co.CommandText = "Select Constraint_Name,Constraint_Options,Constraint_Unit from Item Where Item_Id=@y";
            co.Parameters.AddWithValue("@y", i);
            DataTable Const = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(co);
            adap.Fill(Const);
            //Session["dtSelectedProduct"] = tab;
            con.Close();
            foreach(DataRow dr in Const.Rows)
            {
                constname=(dr["Constraint_Name"]).ToString();
                constoptions = (dr["Constraint_Options"]).ToString();
                unit=(dr["Constraint_Unit"]).ToString();
            }
            options=constoptions.Split(',');
            Constraint1.InnerText=constname+" ("+unit+")";
            Constraint2.Visible = false;
            Constraint3.Visible = false;
            Constraint4.Visible = false;
            Constraint5.Visible = false;
            for (int y = 0; y < options.Length; y++)
            {
                options[y] = options[y] + unit;
            }
        }
        if(a==2)
        {
            con.Open();
            SqlCommand co = con.CreateCommand();
            co.CommandText = "Select Constraint_Name,Constraint_Name1,Constraint_Options,Constraint_Options1,Constraint_Unit,Constraint_Unit1 from Item Where Item_Id=@y";
            co.Parameters.AddWithValue("@y", i);
            DataTable Const = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(co);
            adap.Fill(Const);
            //Session["dtSelectedProduct"] = tab;
            con.Close();
            foreach (DataRow dr in Const.Rows)
            {
                constname = (dr["Constraint_Name"]).ToString();
                constname1 = (dr["Constraint_Name1"]).ToString();
                constoptions = (dr["Constraint_Options"]).ToString();
                constoptions1 = (dr["Constraint_Options1"]).ToString();
                unit = (dr["Constraint_Unit"]).ToString();
                unit1 = (dr["Constraint_Unit1"]).ToString();
            }
            options = constoptions.Split(',');
            Constraint1.InnerText = constname + " (" + unit + ")";
            options1 = constoptions1.Split(',');
            Constraint2.InnerText = constname1 + " (" + unit1 + ")";
            Constraint3.Visible = false;
            Constraint4.Visible = false;
            Constraint5.Visible = false;
            for (int y = 0; y < options.Length; y++)
            {
                options[y] = options[y] + unit;
                
            }
            for (int y = 0; y < options1.Length; y++)
            {
                options1[y] = options1[y] + unit1;
            }
        }
        if(a==3)
        {
            con.Open();
            SqlCommand co = con.CreateCommand();
            co.CommandText = "Select Constraint_Name,Constraint_Name1,Constraint_Name2,Constraint_Options,Constraint_Options1,Constraint_Options2,Constraint_Unit,Constraint_Unit1,Constraint_Unit2 from Item Where Item_Id=@y";
            co.Parameters.AddWithValue("@y", i);
            DataTable Const = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(co);
            adap.Fill(Const);
            //Session["dtSelectedProduct"] = tab;
            con.Close();
            foreach (DataRow dr in Const.Rows)
            {
                constname = (dr["Constraint_Name"]).ToString();
                constname1 = (dr["Constraint_Name1"]).ToString();
                constname2 = (dr["Constraint_Name2"]).ToString();
                constoptions = (dr["Constraint_Options"]).ToString();
                constoptions1 = (dr["Constraint_Options1"]).ToString();
                constoptions2 = (dr["Constraint_Options2"]).ToString();
                unit = (dr["Constraint_Unit"]).ToString();
                unit1 = (dr["Constraint_Unit1"]).ToString();
                unit2 = (dr["Constraint_Unit2"]).ToString();
            }
            options = constoptions.Split(',');
            Constraint1.InnerText = constname + " (" + unit + ")";
            options1 = constoptions1.Split(',');
            Constraint2.InnerText = constname1 + " (" + unit1 + ")";
            options2 = constoptions2.Split(',');
            Constraint3.InnerText = constname2 + " (" + unit2 + ")";
            Constraint4.Visible = false;
            Constraint5.Visible = false;
            for (int y = 0; y < options.Length; y++)
            {
                options[y] = options[y] + unit;
            }
            for (int y = 0; y < options1.Length; y++)
            {
                options1[y] = options1[y] + unit1;
            }
            for (int y = 0; y < options2.Length; y++)
            {
                options2[y] = options2[y] + unit2;
            }

        }
        if(a==4)
        {
            con.Open();
            SqlCommand co = con.CreateCommand();
            co.CommandText = "Select Constraint_Name,Constraint_Name1,Constraint_Name2,Constraint_Name3,Constraint_Options,Constraint_Options1,Constraint_Options2,Constraint_Options3,Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Unit3 from Item Where Item_Id=@y";
            co.Parameters.AddWithValue("@y", i);
            DataTable Const = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(co);
            adap.Fill(Const);
            //Session["dtSelectedProduct"] = tab;
            con.Close();
            foreach (DataRow dr in Const.Rows)
            {
                constname = (dr["Constraint_Name"]).ToString();
                constname1 = (dr["Constraint_Name1"]).ToString();
                constname2 = (dr["Constraint_Name2"]).ToString();
                constname3 = (dr["Constraint_Name3"]).ToString();
                constoptions = (dr["Constraint_Options"]).ToString();
                constoptions1 = (dr["Constraint_Options1"]).ToString();
                constoptions2 = (dr["Constraint_Options2"]).ToString();
                constoptions3 = (dr["Constraint_Options3"]).ToString();
                unit = (dr["Constraint_Unit"]).ToString();
                unit1 = (dr["Constraint_Unit1"]).ToString();
                unit2 = (dr["Constraint_Unit2"]).ToString();
                unit3 = (dr["Constraint_Unit3"]).ToString();
            }
            options = constoptions.Split(',');
            Constraint1.InnerText = constname + " (" + unit + ")";
            options1 = constoptions1.Split(',');
            Constraint2.InnerText = constname1 + " (" + unit1 + ")";
            options2 = constoptions2.Split(',');
            Constraint3.InnerText = constname2 + " (" + unit2 + ")";
            options3 = constoptions3.Split(',');
            Constraint4.InnerText = constname3 + " (" + unit3 + ")";
            Constraint5.Visible = false;
            for (int y = 0; y < options.Length; y++)
            {
                options[y] = options[y] + unit;
            }
            for (int y = 0; y < options1.Length; y++)
            {
                options1[y] = options1[y] + unit1;
            }
            for (int y = 0; y < options2.Length; y++)
            {
                options2[y] = options2[y] + unit2;
            }
            for (int y = 0; y < options3.Length; y++)
            {
                options3[y] = options3[y] + unit3;
            }
        }
        if(a==5)
        {
            con.Open();
            SqlCommand co = con.CreateCommand();
            co.CommandText = "Select Constraint_Name,Constraint_Name1,Constraint_Name2,Constraint_Name3,Constraint_Name4,Constraint_Options,Constraint_Options1,Constraint_Options2,Constraint_Options3,Constraint_Options4,Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Unit3,Constraint_Unit4 from Item Where Item_Id=@y";
            co.Parameters.AddWithValue("@y", i);
            DataTable Const = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(co);
            adap.Fill(Const);
            //Session["dtSelectedProduct"] = tab;
            con.Close();
            foreach (DataRow dr in Const.Rows)
            {
                constname = (dr["Constraint_Name"]).ToString();
                constname1 = (dr["Constraint_Name1"]).ToString();
                constname2 = (dr["Constraint_Name2"]).ToString();
                constname3 = (dr["Constraint_Name3"]).ToString();
                constname4 = (dr["Constraint_Name4"]).ToString();
                constoptions = (dr["Constraint_Options"]).ToString();
                constoptions1 = (dr["Constraint_Options1"]).ToString();
                constoptions2 = (dr["Constraint_Options2"]).ToString();
                constoptions3 = (dr["Constraint_Options3"]).ToString();
                constoptions4 = (dr["Constraint_Options4"]).ToString();
                unit = (dr["Constraint_Unit"]).ToString();
                unit1 = (dr["Constraint_Unit1"]).ToString();
                unit2 = (dr["Constraint_Unit2"]).ToString();
                unit3 = (dr["Constraint_Unit3"]).ToString();
                unit4 = (dr["Constraint_Unit4"]).ToString();
            }
            options = constoptions.Split(',');
            Constraint1.InnerText = constname + " (" + unit + ")";
            options1 = constoptions1.Split(',');
            Constraint2.InnerText = constname1 + " (" + unit1 + ")";
            options2 = constoptions2.Split(',');
            Constraint3.InnerText = constname2 + " (" + unit2 + ")";
            options3 = constoptions3.Split(',');
            Constraint4.InnerText = constname3 + " (" + unit3 + ")";
            options4 = constoptions4.Split(',');
            Constraint5.InnerText = constname4 + " (" + unit4 + ")";
            for (int y = 0; y < options.Length; y++)
            {
                options[y] = options[y] + unit;
            }
            for (int y = 0; y < options1.Length; y++)
            {
                options1[y] = options1[y] + unit1;
            }
            for (int y = 0; y < options2.Length; y++)
            {
                options2[y] = options2[y] + unit2;
            }
            for (int y = 0; y < options3.Length; y++)
            {
                options3[y] = options3[y] + unit3;
            }
            for (int y = 0; y < options4.Length; y++)
            {
                options4[y] = options4[y] + unit3;
            }
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Image1.ImageUrl = image1;
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Image1.ImageUrl = image2;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (id1 != null)
        {
            SqlCommand co = con.CreateCommand();
            co.CommandText = "Select Item_Id,Image,SalePrice,Item_Name,Description from Item Where Item_Id=@y";
            co.Parameters.AddWithValue("@y", i);
            DataTable tab = new DataTable();
            con.Open();
            SqlDataAdapter adap = new SqlDataAdapter(co);
            adap.Fill(tab); 
            Session["dtSelectedProduct"] = tab;
            con.Close();
            string s=TextBox1.Text;
            SqlCommand stock = con.CreateCommand();
            stock.CommandText = "Select In_Stock,Out_Stock from Item Where Item_Id=@y";
            stock.Parameters.AddWithValue("@y", i);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(stock);
            DataTable dtable = new DataTable();
            da.Fill(dtable);
            con.Close();
            foreach(DataRow dr in dtable.Rows)
            {
                int a=Convert.ToInt32(dr["In_Stock"]);
                int b = Convert.ToInt32(dr["Out_Stock"]);
                asd = a - b;
            }
            if (s != "" && !(Convert.ToInt32(s) < 1) && !(Convert.ToInt32(s) > asd))
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
                Response.Redirect("Index.aspx");
            }
            else if(Convert.ToInt32(s)<1)
            {
                string var = "Product Could Not Be Added As Quantity is less than 1";
                Response.Write("<script language=javascript>alert('" + var + "')</script>");
            }
            else if(Convert.ToInt32(s)>asd)
            {
                string var = "Product Could Not Be Added As Quantity is greater than "+asd;
                Response.Write("<script language=javascript>alert('" + var + "')</script>");
            }
            else 
            {
                string var = "Product Could Not Be Added As Quantity was Zero Cannot be Empty";
                Response.Write("<script language=javascript>alert('" + var + "')</script>");
            }
            
            //string var = "Product Added To Cart";
            //Response.Write("<script language=javascript>alert('" + var + "');</script>");
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
            if (Session["dtSelectedProduct"] != null)
            {
                foreach (DataRow dr in dtSelProduct.Rows)
                {
                    if (no == 1)
                    {
                        dtCart.Rows.Add(Convert.ToInt32(dtCart.Rows.Count + 1), Convert.ToInt32(dr["Item_Id"]), Convert.ToString(dr["Item_Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["SalePrice"]), Convert.ToString(DropDownList1.SelectedItem.Text), Convert.ToInt32(TextBox1.Text), Convert.ToInt32(Convert.ToInt32(TextBox1.Text) * Convert.ToInt32(dr["SalePrice"])));
                    }
                    if (no == 2)
                    {
                        dtCart.Rows.Add(Convert.ToInt32(dtCart.Rows.Count + 1), Convert.ToInt32(dr["Item_Id"]), Convert.ToString(dr["Item_Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["SalePrice"]), Convert.ToString(DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text), Convert.ToInt32(TextBox1.Text), Convert.ToInt32(Convert.ToInt32(TextBox1.Text) * Convert.ToInt32(dr["SalePrice"])));
                    }
                    if (no == 3)
                    {
                        dtCart.Rows.Add(Convert.ToInt32(dtCart.Rows.Count + 1), Convert.ToInt32(dr["Item_Id"]), Convert.ToString(dr["Item_Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["SalePrice"]), Convert.ToString(DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text), Convert.ToInt32(TextBox1.Text), Convert.ToInt32(Convert.ToInt32(TextBox1.Text) * Convert.ToInt32(dr["SalePrice"])));
                    }
                    if (no == 4)
                    {
                        dtCart.Rows.Add(Convert.ToInt32(dtCart.Rows.Count + 1), Convert.ToInt32(dr["Item_Id"]), Convert.ToString(dr["Item_Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["SalePrice"]), Convert.ToString(DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text + "," + DropDownList4.SelectedItem.Text), Convert.ToInt32(TextBox1.Text), Convert.ToInt32(Convert.ToInt32(TextBox1.Text) * Convert.ToInt32(dr["SalePrice"])));
                    }
                    if (no == 5)
                    {
                        dtCart.Rows.Add(Convert.ToInt32(dtCart.Rows.Count + 1), Convert.ToInt32(dr["Item_Id"]), Convert.ToString(dr["Item_Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["SalePrice"]), Convert.ToString(DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text + "," + DropDownList4.SelectedItem.Text + "," + DropDownList5.SelectedItem.Text), Convert.ToInt32(TextBox1.Text), Convert.ToInt32(Convert.ToInt32(TextBox1.Text) * Convert.ToInt32(dr["SalePrice"])));
                    }

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
    protected void Button2_Click(object sender, EventArgs e)
    {
        if(Session["Name"]!=null && Session["Email"]!=null)
        {
            SqlCommand command = con.CreateCommand();
            command.CommandText = "Insert into Comment values(@a,@b,@c,@d,@e);";
            command.Parameters.AddWithValue("@a",i);
            command.Parameters.AddWithValue("@b", TextBox2.Text);
            command.Parameters.AddWithValue("@c", Convert.ToString(Session["Email"]));
            int a=Rating1.CurrentRating;
            command.Parameters.AddWithValue("@d", a);
            //if (ratinginput14.Checked == true)
            //{
            //    command.Parameters.AddWithValue("@d", 4);
            //}
            //if (ratinginput13.Checked == true)
            //{
            //    command.Parameters.AddWithValue("@d", 3);
            //}
            //if (ratinginput12.Checked == true)
            //{
            //    command.Parameters.AddWithValue("@d", 2);
            //}
            //if (ratinginput11.Checked == true)
            //{
            //    command.Parameters.AddWithValue("@d", 1);
            //}
            command.Parameters.AddWithValue("@e", "no");
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            Label1.ForeColor=Color.Red;
            Label1.Text = "You Will Be Able To View The Comment After Its Been Approved";
        }
        else
        {
            Label1.ForeColor = Color.Red;
            Label1.Text = "Please Login To Comment On The Product";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlCommand cm = con.CreateCommand();
        cm.CommandText = "Select Count(*) from Sample Where Product_Id=@a And Constraints=@b";
        if (no == 1)
        {
            cm.Parameters.AddWithValue("@b", DropDownList1.SelectedItem.Text);
        }
        if (no == 2)
        {
            cm.Parameters.AddWithValue("@b", DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text);
        }
        if (no == 3)
        {
            cm.Parameters.AddWithValue("@b", DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text);
        }
        if (no == 4)
        {
            cm.Parameters.AddWithValue("@b", DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text + "," + DropDownList4.SelectedItem.Text);
        }
        if (no == 5)
        {
            cm.Parameters.AddWithValue("@b", DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text + "," + DropDownList4.SelectedItem.Text + "," + DropDownList5.SelectedItem.Text);
        }
        cm.Parameters.AddWithValue("@a", i);
        con.Open();
        int b = Convert.ToInt32(cm.ExecuteScalar().ToString());
        con.Close();
        if (b != 0)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Image from Sample Where Product_Id=@a And Constraints=@b";
            if (no == 1)
            {
                cmd.Parameters.AddWithValue("@b", DropDownList1.SelectedItem.Text);
            }
            if (no == 2)
            {
                cmd.Parameters.AddWithValue("@b", DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text);
            }
            if (no == 3)
            {
                cmd.Parameters.AddWithValue("@b", DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text);
            }
            if (no == 4)
            {
                cmd.Parameters.AddWithValue("@b", DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text + "," + DropDownList4.SelectedItem.Text);
            }
            if (no == 5)
            {
                cmd.Parameters.AddWithValue("@b", DropDownList1.SelectedItem.Text + "," + DropDownList2.SelectedItem.Text + "," + DropDownList3.SelectedItem.Text + "," + DropDownList4.SelectedItem.Text + "," + DropDownList5.SelectedItem.Text);
            }
            cmd.Parameters.AddWithValue("@a", i);
            con.Open();
            string a = cmd.ExecuteScalar().ToString();
            con.Close();
            if (a != null && a != DBNull.Value.ToString())
            {
                Image4.ImageUrl = a;
            }
            else
            {
                Image4.ImageUrl = "~/images/home/Default_image.png";
                string var = "Image Not Available";
                Response.Write("<script language=javascript>alert('" + var + "')</script>");
            }
        }
        else
        {
            Image4.ImageUrl = "~/images/home/Default_image.png";
            string var = "No Sample Image";
            Response.Write("<script language=javascript>alert('" + var + "')</script>");
        }
    }
    protected void Rating1_Changed(object sender, RatingEventArgs e)
    {

    }
}