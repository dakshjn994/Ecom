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

public partial class myadmin_Product : System.Web.UI.Page
{
    DataTable dtCart,dtCart1;
    string a, b, asc, da,id,cid, scid,s,f;
    int co;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitronicartsConnection"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                outstock.Visible = true;
                id = Request.QueryString["Id"].ToString();
                pro.InnerText = "Edit Product";
                SqlCommand cm = con.CreateCommand();
                cm.CommandText = "Select * From Item Where Item_Id=@a";
                cm.Parameters.AddWithValue("@a", id);
                SqlDataAdapter d = new SqlDataAdapter(cm);
                DataTable de = new DataTable();
                d.Fill(de);
                foreach (DataRow dr in de.Rows)
                {
                    txtItemName.Text = dr["Item_Name"].ToString();
                    txtPath.Text = dr["Image"].ToString();
                    txtPath1.Text = dr["Image1"].ToString();
                    txtPath2.Text = dr["Image2"].ToString();
                    imgProduct.ImageUrl = dr["Image"].ToString();
                    imgProduct1.ImageUrl = dr["Image1"].ToString();
                    imgProduct2.ImageUrl = dr["Image2"].ToString();
                    cid = (dr["Category_Id"].ToString());
                    if (dr["Sub_Category_Id"] != DBNull.Value)
                    {
                        scid = (dr["Sub_Category_Id"].ToString());
                    }
                    co = Convert.ToInt32(dr["NoOfConstraints"].ToString());
                    if (co != 0)
                    {

                        if (co == 1)
                        {
                            txtConstraint.Text = dr["Constraint_Name"].ToString();
                            txtConstSymbol.Text = dr["Constraint_Unit"].ToString();
                            txtopt.Text = dr["Constraint_Options"].ToString();
                            Constraint1.Visible = true;
                            Constraint2.Visible = false;
                            Constraint3.Visible = false;
                            Constraint4.Visible = false;
                            Constraint5.Visible = false;
                        }
                        if (co == 2)
                        {
                            txtConstraint.Text = dr["Constraint_Name"].ToString();
                            txtConstSymbol.Text = dr["Constraint_Unit"].ToString();
                            txtopt.Text = dr["Constraint_Options"].ToString();
                            txtConstraint1.Text = dr["Constraint_Name1"].ToString();
                            if (dr["Constraint_Unit1"] != DBNull.Value)
                            {
                                rbConstM.Checked = true;
                                txtConstSymbol1.Text = dr["Constraint_Unit1"].ToString();
                            }
                            else
                            {
                                rbConstB.Checked = true;
                                txtConstSymbol1.Visible = false;
                            }
                            txtopt1.Text = dr["Constraint_Options1"].ToString();
                            Constraint1.Visible = true;
                            Constraint2.Visible = true;
                            Constraint3.Visible = false;
                            Constraint4.Visible = false;
                            Constraint5.Visible = false;
                        }
                        if (co == 3)
                        {
                            txtConstraint.Text = dr["Constraint_Name"].ToString();
                            txtConstSymbol.Text = dr["Constraint_Unit"].ToString();
                            txtopt.Text = dr["Constraint_Options"].ToString();
                            txtConstraint1.Text = dr["Constraint_Name1"].ToString();
                            if (dr["Constraint_Unit1"] != DBNull.Value)
                            {
                                rbConstM.Checked = true;
                                txtConstSymbol1.Text = dr["Constraint_Unit1"].ToString();
                            }
                            else
                            {
                                rbConstB.Checked = true;
                                txtConstSymbol1.Visible = false;
                            }
                            txtopt1.Text = dr["Constraint_Options1"].ToString();
                            txtConstraint2.Text = dr["Constraint_Name2"].ToString();
                            if (dr["Constraint_Unit2"] != DBNull.Value)
                            {
                                rbConstM1.Checked = true;
                                txtConstSymbol2.Text = dr["Constraint_Unit2"].ToString();
                            }
                            else
                            {
                                rbConstB1.Checked = true;
                                txtConstSymbol2.Visible = false;
                            }
                            txtopt2.Text = dr["Constraint_Options2"].ToString();
                            Constraint1.Visible = true;
                            Constraint2.Visible = true;
                            Constraint3.Visible = true;
                            Constraint4.Visible = false;
                            Constraint5.Visible = false;
                        }
                        if (co == 4)
                        {
                            txtConstraint.Text = dr["Constraint_Name"].ToString();
                            txtConstSymbol.Text = dr["Constraint_Unit"].ToString();
                            txtopt.Text = dr["Constraint_Options"].ToString();
                            txtConstraint1.Text = dr["Constraint_Name1"].ToString();
                            if (dr["Constraint_Unit1"] != DBNull.Value)
                            {
                                rbConstM.Checked = true;
                                txtConstSymbol1.Text = dr["Constraint_Unit1"].ToString();
                            }
                            else
                            {
                                rbConstB.Checked = true;
                                txtConstSymbol1.Visible = false;
                            }
                            txtopt1.Text = dr["Constraint_Options1"].ToString();
                            txtConstraint2.Text = dr["Constraint_Name2"].ToString();
                            if (dr["Constraint_Unit2"] != DBNull.Value)
                            {
                                rbConstM1.Checked = true;
                                txtConstSymbol2.Text = dr["Constraint_Unit2"].ToString();
                            }
                            else
                            {
                                rbConstB1.Checked = true;
                                txtConstSymbol2.Visible = false;
                            }
                            txtopt2.Text = dr["Constraint_Options2"].ToString();
                            txtConstraint3.Text = dr["Constraint_Name3"].ToString();
                            if (dr["Constraint_Unit3"] != DBNull.Value)
                            {
                                rbConstM2.Checked = true;
                                txtConstSymbol3.Text = dr["Constraint_Unit3"].ToString();
                            }
                            else
                            {
                                rbConstB2.Checked = true;
                                txtConstSymbol3.Visible = false;
                            }
                            txtopt3.Text = dr["Constraint_Options3"].ToString();
                            Constraint1.Visible = true;
                            Constraint2.Visible = true;
                            Constraint3.Visible = true;
                            Constraint4.Visible = true;
                            Constraint5.Visible = false;
                        }
                        if (co == 5)
                        {
                            txtConstraint.Text = dr["Constraint_Name"].ToString();
                            txtConstSymbol.Text = dr["Constraint_Unit"].ToString();
                            txtopt.Text = dr["Constraint_Options"].ToString();
                            txtConstraint1.Text = dr["Constraint_Name1"].ToString();
                            if (dr["Constraint_Unit1"] != DBNull.Value)
                            {
                                rbConstM.Checked = true;
                                txtConstSymbol1.Text = dr["Constraint_Unit1"].ToString();
                            }
                            else
                            {
                                rbConstB.Checked = true;
                                txtConstSymbol1.Visible = false;
                            }
                            txtopt1.Text = dr["Constraint_Options1"].ToString();
                            txtConstraint2.Text = dr["Constraint_Name2"].ToString();
                            if (dr["Constraint_Unit2"] != DBNull.Value)
                            {
                                rbConstM1.Checked = true;
                                txtConstSymbol2.Text = dr["Constraint_Unit2"].ToString();
                            }
                            else
                            {
                                rbConstB1.Checked = true;
                                txtConstSymbol2.Visible = false;
                            }
                            txtopt2.Text = dr["Constraint_Options2"].ToString();
                            txtConstraint3.Text = dr["Constraint_Name3"].ToString();
                            if (dr["Constraint_Unit3"] != DBNull.Value)
                            {
                                rbConstM2.Checked = true;
                                txtConstSymbol3.Text = dr["Constraint_Unit3"].ToString();
                            }
                            else
                            {
                                rbConstB2.Checked = true;
                                txtConstSymbol3.Visible = false;
                            }
                            txtopt3.Text = dr["Constraint_Options3"].ToString();
                            txtConstraint4.Text = dr["Constraint_Name4"].ToString();
                            if (dr["Constraint_Unit4"] != DBNull.Value)
                            {
                                rbConstM3.Checked = true;
                                txtConstSymbol4.Text = dr["Constraint_Unit4"].ToString();
                            }
                            else
                            {
                                rbConstB3.Checked = true;
                                txtConstSymbol4.Visible = false;
                            }
                            txtopt4.Text = dr["Constraint_Options4"].ToString();
                            Constraint1.Visible = true;
                            Constraint2.Visible = true;
                            Constraint3.Visible = true;
                            Constraint4.Visible = true;
                            Constraint5.Visible = true;
                        }
                    }
                    s = dr["Sales"].ToString();
                    f = dr["Featured"].ToString();
                    if (s == "yes")
                    {
                        Sales.Checked = true;
                    }
                    if (f == "yes")
                    {
                        Featured.Checked = true;
                    }
                    txtMRP.Text = dr["MRP"].ToString();
                    txtSalePrice.Text = dr["SalePrice"].ToString();
                    TextArea1.InnerText = dr["Description"].ToString();
                    txtStock.Text = dr["In_Stock"].ToString();
                    txtOut.Text = dr["Out_Stock"].ToString();
                }
                btnFormSubmit.Text = "Update Product";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select Category_Id,Category_Name From Category Where Active!=@ac";
                cmd.Parameters.AddWithValue("@ac", "no");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                ddlConstraintNos.SelectedValue = co.ToString();
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "Category_Name";
                ddlCategory.DataValueField = "Category_Id";
                ddlCategory.DataBind();
                ListItem Category = new ListItem("Select Category", "-1");
                ddlCategory.Items.Insert(0, Category);
                ddlCategory.SelectedValue = cid.ToString();
                if (scid != null)
                {
                    string i = ddlCategory.SelectedValue;
                    SqlCommand cmda = con.CreateCommand();
                    cmda.CommandText = "Select Sub_Category_Id,Sub_Category_Name from MinorCategory Where Category_Id=@q and Active=@a";
                    cmda.Parameters.AddWithValue("@q", i);
                    cmda.Parameters.AddWithValue("@a", "yes");
                    SqlDataAdapter ds = new SqlDataAdapter(cmda);
                    DataTable dta = new DataTable();
                    ds.Fill(dta);
                    if (dta.Rows.Count != 0)
                    {
                        ddlSub.DataSource = dta;
                        ddlSub.DataTextField = "Sub_Category_Name";
                        ddlSub.DataValueField = "Sub_Category_Id";
                        ddlSub.DataBind();
                        ListItem Category1 = new ListItem("Select Sub-Category", "-1");
                        ddlSub.Items.Insert(0, Category1);
                        sub.Visible = true;
                        ddlSub.Visible = true;
                    }
                    else
                    {
                        ddlSub.DataSource = dta;
                        ddlSub.DataTextField = "Sub_Category_Name";
                        ddlSub.DataValueField = "Sub_Category_Id";
                        ddlSub.DataBind();
                        ListItem Category1 = new ListItem("Select Sub-Category", "-1");
                        ddlSub.Items.Insert(0, Category1);
                        sub.Visible = false;
                        ddlSub.Visible = false;
                    }
                    ddlSub.SelectedValue = scid.ToString();
                }
                else
                {
                    ddlSub.Visible = false;
                    sub.Visible = false;
                }
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select Category_Id,Category_Name From Category Where Active!=@ac";
                cmd.Parameters.AddWithValue("@ac", "no");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (!IsPostBack)
                {
                    Constraint1.Visible = false;
                    Constraint2.Visible = false;
                    Constraint3.Visible = false;
                    Constraint4.Visible = false;
                    Constraint5.Visible = false;
                    ddlSub.Visible = false;
                    sub.Visible = false;
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "Category_Name";
                    ddlCategory.DataValueField = "Category_Id";
                    ddlCategory.DataBind();
                    ListItem Category = new ListItem("Select Category", "-1");
                    ddlCategory.Items.Insert(0, Category);
                }
            }
        }
    }
    protected void btnConstraint_Click(object sender, EventArgs e)
    {
        b = txtOptions.Text;
        if(b!="")
        {
            a=txtopt.Text;
            if(a != "")
            {
                bool isnot = false;
                string[] opt = a.Split(',');
                for (int g = 0; g < opt.Length; g++)
                {
                    if (isnot == false)
                    {
                        if (opt[g] == b)
                        {
                            isnot = true;
                        }
                    }
                }
                if (isnot == false)
                {
                    txtopt.Text = txtopt.Text + "," + txtOptions.Text;
                    string ac = (string)txtopt.Text;
                    string[] sc=ac.Split(',');
                    //double[] ax = new double[sc.Length];
                    //for (int i = 0; i < sc.Length;i++)
                    //{
                    //    ax[i] = Convert.ToDouble(sc[i]);
                    //}
                    //    Array.Sort(ax);
                    int x=0;
                    foreach(var str in sc)
                    {
                        if(x==0)
                        {
                            da = (str).ToString();
                        }
                        else
                        {
                            da = da + "," + str;
                        }
                        x++;
                    }
                    //for(int i=0;i<=sc.Length;i++)
                    //{
                    //    if(i!=0)
                    //    {
                    //        asc += "," + Convert.ToString(ax[i]);
                    //    }
                    //    else
                    //    {
                    //        asc += Convert.ToString(ax[i]);
                    //    }
                    //}
                    txtopt.Text = da;
                    txtOptions.Text="";
                }
                else
                {
                    //string var = "Option already exists";
                    //Response.Write("<script language=javascript>alert('" + var + "');</script>");
                    txtOptions.Text = "";
                }
            }
            else
            {
                txtopt.Text = txtOptions.Text;
                txtOptions.Text = "";
            }
        }
        else
        {
            //string var = "Enter Option";
            //Response.Write("<script language=javascript>alert('" + var + "');</script>");
        }
    }
    protected void btnConstraint1_Click(object sender, EventArgs e)
    {
        b = txtOptions1.Text;
        if (b != "")
        {
            a = txtopt1.Text;
            if (a != "")
            {
                bool isnot=false;
                string[] opt=a.Split(',');
                for(int g=0;g<opt.Length;g++)
                {
                if(isnot==false)
                {
                    if(opt[g]==b)
                    {
                        isnot = true;
                    }
                }
                }
                if (rbConstM.Checked == true)
                {
                    if (isnot == false)
                    {
                        txtopt1.Text = txtopt1.Text + "," + txtOptions1.Text;
                        string ac = (string)txtopt1.Text;
                        string[] sc = ac.Split(',');
                        //double[] ax = new double[sc.Length];
                        //for (int i = 0; i < sc.Length; i++)
                        //{
                        //    ax[i] = Convert.ToDouble(sc[i]);
                        //}
                        //Array.Sort(ax);
                        int x = 0;
                        foreach (var str in sc)
                        {
                            if (x == 0)
                            {
                                da = (str).ToString();
                            }
                            else
                            {
                                da = da + "," + str;
                            }
                            x++;
                        }
                        txtopt1.Text = da;
                        txtOptions1.Text = "";
                    }
                    else
                    {
                        txtOptions1.Text = "";
                    }
                }
                if(rbConstB.Checked==true)
                {
                    txtopt1.Text = txtopt1.Text + "," + txtOptions1.Text;
                    txtOptions1.Text = "";
                }
            }
            else
            {
                txtopt1.Text = txtOptions1.Text;
                txtOptions1.Text = "";
            }
        }
        else
        {
            string var = "Enter Option";
            Response.Write("<script language=javascript>alert('" + var + "');</script>");
        }
    }
    protected void btnImageSubmit_Click(object sender, EventArgs e)
    {
        if (fuImage2.HasFile)
        {
            string extension = (string)Path.GetExtension(fuImage2.FileName);
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp")
            {
                string s = ("~/images/product-details/Uploads/" + fuImage2.FileName).ToString();
                fuImage2.SaveAs(Server.MapPath(s));
                imgProduct2.Visible = true;
                txtPath2.Text = s;
                imgProduct2.ImageUrl = s;
                string var = "File Successfully Uploaded";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
            else
            {
                imgProduct2.ImageUrl = "~/images/home/Default_image.png";
                string var = "Please Upload Correct Format File";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
        }
        else
        {
            imgProduct2.ImageUrl = "~/images/home/Default_image.png";
            string var = "Please Upload Image File";
            Response.Write("<script language=javascript>alert('" + var + "');</script>");
        }
    }
    protected void btnImageSubmit1_Click(object sender, EventArgs e)
    {
        if (fuImage1.HasFile)
        {
            string extension = (string)Path.GetExtension(fuImage1.FileName);
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp")
            {
                string s = ("~/images/product-details/Uploads/" + fuImage1.FileName).ToString();
                fuImage1.SaveAs(Server.MapPath(s));
                imgProduct1.Visible = true;
                txtPath1.Text = s;
                imgProduct1.ImageUrl = s;
                string var = "File Successfully Uploaded";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
            else
            {
                imgProduct1.ImageUrl = "~/images/home/Default_image.png";
                string var = "Please Upload Correct Format File";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
        }
        else
        {
            imgProduct1.ImageUrl = "~/images/home/Default_image.png";
            string var = "Please Upload Image File";
            Response.Write("<script language=javascript>alert('" + var + "');</script>");
        }

    }
    protected void btnImageSubmit2_Click(object sender, EventArgs e)
    {
        if (fuImage.HasFile)
        {
            string extension = (string)Path.GetExtension(fuImage.FileName);
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp")
            {
                string s = ("~/images/product-details/Uploads/" + fuImage.FileName).ToString();
                fuImage.SaveAs(Server.MapPath(s));
                imgProduct.Visible = true;
                txtPath.Text = s;
                imgProduct.ImageUrl = s;
                string var = "File Successfully Uploaded";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
            else
            {
                imgProduct.ImageUrl = "~/images/home/Default_image.png";
                string var = "Please Upload Correct Format File";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
        }
        else
        {
            imgProduct.ImageUrl = "~/images/home/Default_image.png";
            string var = "Please Upload Image File";
            Response.Write("<script language=javascript>alert('" + var + "');</script>");
        }
    }
    protected void btnFormSubmit_Click(object sender, EventArgs e)
    {
        if (ddlCategory.Visible == true && ddlSub.Visible == true)
        {
            if (ddlCategory.SelectedIndex != 0 && ddlSub.SelectedIndex != 0)
            {
                try
                {
                    AddData();
                }
                catch (SqlException sql)
                {
                    string var = sql.Message;
                    Response.Write("<script language=javascript>alert('" + var + "');</script>");
                }
            }
            else
            {
                string var = "Please Select Category And Sub-Category";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
        }
        else
        {
            if (ddlCategory.SelectedIndex != 0)
            {
                try
                {
                    AddData();
                }
                catch (SqlException sql)
                {
                    string var = sql.Message;
                    Response.Write("<script language=javascript>alert('" + var + "');</script>");
                }
            }
            else
            {
                string var = "Please Select Category";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
        }
        
    }
    protected void AddData()
    {
        if(ddlConstraintNos.SelectedValue=="1")
        {
            cool(false, false, false,false,false, false, false, false);
        }
        if(ddlConstraintNos.SelectedValue=="2")
        {
            if(rbConstB.Checked==true)
            {
                cool(true, false, false, false, false, false, false, false);
            }
            if(rbConstM.Checked==true)
            {
                cool(true, false, false, false, true, false, false, false);
            }
        }
        if(ddlConstraintNos.SelectedValue=="3")
        {
           if(rbConstB.Checked==true)
           {
               if(rbConstB1.Checked==true)
               {
                   cool(true, true, false, false, false, false, false, false);
               }
               if(rbConstM1.Checked==true)
               {
                   cool(true, true, false, false, false, true, false, false);
               }
           }
            if(rbConstM.Checked==true)
            {
                if(rbConstM1.Checked==true)
                {
                    cool(true, true, false, false, true, true, false, false);
                }
                if(rbConstB1.Checked==true)
                {
                    cool(true, true, false, false, true, false, false, false);
                }
            }
          }
        if(ddlConstraintNos.SelectedValue=="4")
        {
            if(rbConstB.Checked==true)
            {
                if(rbConstB1.Checked==true)
                {
                    if(rbConstB2.Checked==true)
                    {
                        cool(true,true,true,false,false,false,false,false);
                    }
                    if(rbConstM2.Checked==true)
                    {
                        cool(true,true,true,false,false,false,true,false);
                    }
                }
                if(rbConstM1.Checked==true)
                {
                    if(rbConstM2.Checked==true)
                    {
                        cool(true,true,true,false,false,true,true,false);
                    }
                    if(rbConstB2.Checked==true)
                    {
                        cool(true,true,true,false,false,true,false,false);
                    }
                }
            }
            if(rbConstM.Checked==true)
            {
                if(rbConstM1.Checked==true)
                {
                    if(rbConstM2.Checked==true)
                    {
                        cool(true,true,true,false,true,true,true,false);
                    }
                    if(rbConstB2.Checked==true)
                    {
                        cool(true,true,true,false,true,true,false,false);
                    }
                }
                if(rbConstB1.Checked==true)
                {
                    if(rbConstB2.Checked==true)
                    {
                        cool(true, true, true, false, true, false, false, false);
                    }
                    if(rbConstM2.Checked==true)
                    {
                        cool(true, true, true, false, true, false, true, false);
                    }
                }
            }
        }
        if(ddlConstraintNos.SelectedValue=="5")
        {
            if(rbConstB.Checked==true)
            {
                if(rbConstB1.Checked==true)
                {
                    if(rbConstB2.Checked==true)
                   {
                        if(rbConstB3.Checked==true)
                        {
                            cool(true, true, true, true, false, false, false, false);
                        }
                        if(rbConstM3.Checked==true)
                        {
                            cool(true, true, true, true, false, false, false, true);
                        }
                   }
                   if(rbConstM2.Checked==true)
                   {
                       if(rbConstM3.Checked==true)
                        {
                            cool(true, true, true, true, false, false, true, true);
                        }
                        if(rbConstB3.Checked==true)
                        {
                            cool(true, true, true, true, false, false, true, false);
                         }
                     }
                }
                if(rbConstM1.Checked==true)
                {
                    if(rbConstM2.Checked==true)
                    {
                        if(rbConstM3.Checked==true)
                        {
                            cool(true, true, true, true, false, true, true, true);
                        }
                        if(rbConstB3.Checked==true)
                        {
                            cool(true, true, true, true, false, true, true, false);
                        }
                    }
                    if(rbConstB2.Checked==true)
                    {
                        if(rbConstB3.Checked==true)
                        {
                            cool(true, true, true, true, false, true, false, false);
                        }
                        if(rbConstM3.Checked==true)
                        {
                            cool(true, true, true, true, false, true, false, true);
                        }
                    }
                }
            }
            if(rbConstM.Checked==true)
            {
                if(rbConstM1.Checked==true)
                {
                    if(rbConstM2.Checked==true)
                    {
                        if(rbConstM3.Checked==true)
                        {
                            cool(true, true, true, true, true, true, true, true);
                        }
                        if(rbConstB3.Checked==true)
                        {
                            cool(true, true, true, true, true, true, true, false);
                        }
                    }
                    if(rbConstB2.Checked==true)
                    {
                        if(rbConstB3.Checked==true)
                        {
                            cool(true, true, true, true, true, true, false, false);
                        }
                        if(rbConstM3.Checked==true)
                        {
                            cool(true, true, true, true, true, true, false, true);
                        }
                    }
                }
                if(rbConstB1.Checked==true)
                {
                    if(rbConstB2.Checked==true)
                    {
                        if(rbConstB3.Checked==true)
                        {
                            cool(true, true, true, true, true, false, false, false);
                        }
                        if(rbConstM3.Checked==true)
                        {
                            cool(true, true, true, true, true, false, false, true);
                        }
                    }
                    if(rbConstM2.Checked==true)
                    {
                        if(rbConstM3.Checked==true)
                        {
                            cool(true, true, true, true, true, false, true, true);
                        }
                        if(rbConstB3.Checked==true)
                        {
                            cool(true, true, true, true, true, true, true, false);
                        }
                    }
                }
            }
        }
   }
    private void cool( bool a1, bool a2, bool a3, bool a4, bool unit, bool unit1, bool unit2, bool unit3)
        {
            if (Request.QueryString["Id"] != null)
            {
                con.Open();
                SqlCommand cm = con.CreateCommand();
                cm.CommandText = "Select Count(*) From Item";
                string ab =Request.QueryString["Id"].ToString();
                SqlCommand com = con.CreateCommand();
                com.CommandText = "Update Item Set Category_Id=@Category_Id,Sub_Category_Id=@Sub_Category_Id,Item_Name=@Item_Name,Image=@Image,Image1=@Image1,Image2=@Image2,NoOfConstraints=@NoOfConstraints,Constraint_Name=@Constraint_Name,Constraint_Name1=@Constraint_Name1,Constraint_Name2=@Constraint_Name2,Constraint_Name3=@Constraint_Name3,Constraint_Name4=@Constraint_Name4,Constraint_Options=@Constraint_Options,Constraint_Options1=@Constraint_Options1,Constraint_Options2=@Constraint_Options2,Constraint_Options3=@Constraint_Options3,Constraint_Options4=@Constraint_Options4,Constraint_Unit=@Constraint_Unit,Constraint_Unit1=@Constraint_Unit1,Constraint_Unit2=@Constraint_Unit2,Constraint_Unit3=@Constraint_Unit3,Constraint_Unit4=@Constraint_Unit4,Active=@Active,Sales=@Sales,Featured=@Featured,MRP=@MRP,SalePrice=@SalePrice,Description=@Description,In_Stock=@In_Stock,Out_Stock=@Out_Stock Where Item_Id=@Item_Id";
                com.Parameters.AddWithValue("@Item_Id", ab);
                com.Parameters.AddWithValue("@Category_Id", Convert.ToInt32(ddlCategory.SelectedValue.ToString()));
                if (ddlSub.Visible == false)
                {
                    com.Parameters.AddWithValue("@Sub_Category_Id", DBNull.Value);
                }
                else
                {
                    com.Parameters.AddWithValue("@Sub_Category_Id", Convert.ToInt32(ddlSub.SelectedValue.ToString()));
                }

                com.Parameters.AddWithValue("@Item_Name", txtItemName.Text.ToString());
                com.Parameters.AddWithValue("@Image", txtPath.Text.ToString());
                com.Parameters.AddWithValue("@Image1", txtPath1.Text.ToString());
                com.Parameters.AddWithValue("@Image2", txtPath2.Text.ToString());
                com.Parameters.AddWithValue("@NoOfConstraints", ddlConstraintNos.SelectedValue);
                com.Parameters.AddWithValue("@Constraint_Name", txtConstraint.Text.ToString());
                com.Parameters.AddWithValue("@Constraint_Options", txtopt.Text.ToString());
                com.Parameters.AddWithValue("@Constraint_Unit", txtConstSymbol.Text);
                if (a1)
                {
                    com.Parameters.AddWithValue("@Constraint_Name1", txtConstraint1.Text.ToString());
                    com.Parameters.AddWithValue("@Constraint_Options1", txtopt1.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Name1", System.DBNull.Value);
                    com.Parameters.AddWithValue("@Constraint_Options1", System.DBNull.Value);
                }
                if (a2)
                {
                    com.Parameters.AddWithValue("@Constraint_Name2", txtConstraint2.Text.ToString());
                    com.Parameters.AddWithValue("@Constraint_Options2", txtopt2.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Name2", System.DBNull.Value);
                    com.Parameters.AddWithValue("@Constraint_Options2", System.DBNull.Value);
                }
                if (a3)
                {
                    com.Parameters.AddWithValue("@Constraint_Name3", txtConstraint3.Text.ToString());
                    com.Parameters.AddWithValue("@Constraint_Options3", txtopt3.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Name3", System.DBNull.Value);
                    com.Parameters.AddWithValue("@Constraint_Options3", System.DBNull.Value);
                }
                if (a4)
                {
                    com.Parameters.AddWithValue("@Constraint_Name4", txtConstraint4.Text.ToString());
                    com.Parameters.AddWithValue("@Constraint_Options4", txtopt4.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Name4", System.DBNull.Value);
                    com.Parameters.AddWithValue("@Constraint_Options4", System.DBNull.Value);
                }
                if (unit)
                {
                    com.Parameters.AddWithValue("@Constraint_Unit1", txtConstSymbol1.Text);
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Unit1", System.DBNull.Value);
                }
                if (unit1)
                {
                    com.Parameters.AddWithValue("@Constraint_Unit2", txtConstSymbol2.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Unit2", System.DBNull.Value);
                }
                if (unit2)
                {
                    com.Parameters.AddWithValue("@Constraint_Unit3", txtConstSymbol3.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Unit3", System.DBNull.Value);
                }
                if (unit3)
                {
                    com.Parameters.AddWithValue("@Constraint_Unit4", txtConstSymbol4.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Unit4", System.DBNull.Value);
                }
                com.Parameters.AddWithValue("@Active", "yes");
                string a, b;
                if (Sales.Checked && Featured.Checked)
                {
                    a = "yes";
                    b = "yes";
                }
                else if (Sales.Checked)
                {
                    a = "yes";
                    b = "no";
                }
                else if (Featured.Checked)
                {
                    a = "no";
                    b = "yes";
                }
                else
                {
                    a = "no";
                    b = "no";
                }
                com.Parameters.AddWithValue("@Sales", a);
                com.Parameters.AddWithValue("@Featured", b);
                com.Parameters.AddWithValue("@SalePrice", Convert.ToInt32(txtSalePrice.Text));
                com.Parameters.AddWithValue("@MRP", Convert.ToInt32(txtMRP.Text));
                com.Parameters.AddWithValue("@Description", TextArea1.InnerText.ToString());
                com.Parameters.AddWithValue("@In_Stock", Convert.ToInt32(txtStock.Text));
                com.Parameters.AddWithValue("@Out_Stock", Convert.ToInt32(txtOut.Text));
                com.ExecuteNonQuery();
                con.Close();
                Response.Redirect("VProduct.aspx");
            }
            else
            {
                con.Open();
                SqlCommand cm = con.CreateCommand();
                cm.CommandText = "Select Count(*) From Item";
                int ab = Convert.ToInt32(cm.ExecuteScalar());
                ab = ab + 10001;
                SqlCommand com = con.CreateCommand();
                com.CommandText = "Insert Into Item(Item_Id,Category_Id,Sub_Category_Id,Item_Name,Image,Image1,Image2,NoOfConstraints,Constraint_Name,Constraint_Name1,Constraint_Name2,Constraint_Name3,Constraint_Name4,Constraint_Options,Constraint_Options1,Constraint_Options2,Constraint_Options3,Constraint_Options4,Constraint_Unit,Constraint_Unit1,Constraint_Unit2,Constraint_Unit3,Constraint_Unit4,Active,Sales,Featured,MRP,SalePrice,Description,In_Stock,Out_Stock) values(@Item_Id,@Category_Id,@Sub_Category_Id,@Item_Name,@Image,@Image1,@Image2,@NoOfConstraints,@Constraint_Name,@Constraint_Name1,@Constraint_Name2,@Constraint_Name3,@Constraint_Name4,@Constraint_Options,@Constraint_Options1,@Constraint_Options2,@Constraint_Options3,@Constraint_Options4,@Constraint_Unit,@Constraint_Unit1,@Constraint_Unit2,@Constraint_Unit3,@Constraint_Unit4,@Active,@Sales,@Featured,@MRP,@SalePrice,@Description,@In_Stock,@Out_Stock)";
                com.Parameters.AddWithValue("@Item_Id", ab);
                com.Parameters.AddWithValue("@Category_Id", Convert.ToInt32(ddlCategory.SelectedValue.ToString()));
                if (ddlSub.Visible == false)
                {
                    com.Parameters.AddWithValue("@Sub_Category_Id", DBNull.Value);
                }
                else
                {
                    com.Parameters.AddWithValue("@Sub_Category_Id", Convert.ToInt32(ddlSub.SelectedValue.ToString()));
                }

                com.Parameters.AddWithValue("@Item_Name", txtItemName.Text.ToString());
                com.Parameters.AddWithValue("@Image", txtPath.Text.ToString());
                com.Parameters.AddWithValue("@Image1", txtPath1.Text.ToString());
                com.Parameters.AddWithValue("@Image2", txtPath2.Text.ToString());
                com.Parameters.AddWithValue("@NoOfConstraints", ddlConstraintNos.SelectedValue);
                com.Parameters.AddWithValue("@Constraint_Name", txtConstraint.Text.ToString());
                com.Parameters.AddWithValue("@Constraint_Options", txtopt.Text.ToString());
                com.Parameters.AddWithValue("@Constraint_Unit", txtConstSymbol.Text);
                if (a1)
                {
                    com.Parameters.AddWithValue("@Constraint_Name1", txtConstraint1.Text.ToString());
                    com.Parameters.AddWithValue("@Constraint_Options1", txtopt1.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Name1", System.DBNull.Value);
                    com.Parameters.AddWithValue("@Constraint_Options1", System.DBNull.Value);
                }
                if (a2)
                {
                    com.Parameters.AddWithValue("@Constraint_Name2", txtConstraint2.Text.ToString());
                    com.Parameters.AddWithValue("@Constraint_Options2", txtopt2.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Name2", System.DBNull.Value);
                    com.Parameters.AddWithValue("@Constraint_Options2", System.DBNull.Value);
                }
                if (a3)
                {
                    com.Parameters.AddWithValue("@Constraint_Name3", txtConstraint3.Text.ToString());
                    com.Parameters.AddWithValue("@Constraint_Options3", txtopt3.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Name3", System.DBNull.Value);
                    com.Parameters.AddWithValue("@Constraint_Options3", System.DBNull.Value);
                }
                if (a4)
                {
                    com.Parameters.AddWithValue("@Constraint_Name4", txtConstraint4.Text.ToString());
                    com.Parameters.AddWithValue("@Constraint_Options4", txtopt4.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Name4", System.DBNull.Value);
                    com.Parameters.AddWithValue("@Constraint_Options4", System.DBNull.Value);
                }
                if (unit)
                {
                    com.Parameters.AddWithValue("@Constraint_Unit1", txtConstSymbol1.Text);
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Unit1", System.DBNull.Value);
                }
                if (unit1)
                {
                    com.Parameters.AddWithValue("@Constraint_Unit2", txtConstSymbol2.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Unit2", System.DBNull.Value);
                }
                if (unit2)
                {
                    com.Parameters.AddWithValue("@Constraint_Unit3", txtConstSymbol3.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Unit3", System.DBNull.Value);
                }
                if (unit3)
                {
                    com.Parameters.AddWithValue("@Constraint_Unit4", txtConstSymbol4.Text.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@Constraint_Unit4", System.DBNull.Value);
                }
                com.Parameters.AddWithValue("@Active", "yes");
                string a, b;
                if (Sales.Checked && Featured.Checked)
                {
                    a = "yes";
                    b = "yes";
                }
                else if (Sales.Checked)
                {
                    a = "yes";
                    b = "no";
                }
                else if (Featured.Checked)
                {
                    a = "no";
                    b = "yes";
                }
                else
                {
                    a = "no";
                    b = "no";
                }
                com.Parameters.AddWithValue("@Sales", a);
                com.Parameters.AddWithValue("@Featured", b);
                com.Parameters.AddWithValue("@SalePrice", Convert.ToInt32(txtSalePrice.Text));
                com.Parameters.AddWithValue("@MRP", Convert.ToInt32(txtMRP.Text));
                com.Parameters.AddWithValue("@Description", TextArea1.InnerText.ToString());
                com.Parameters.AddWithValue("@In_Stock", Convert.ToInt32(txtStock.Text));
                com.Parameters.AddWithValue("@Out_Stock", Convert.ToInt32("0".ToString()));
                com.ExecuteNonQuery();
                con.Close();
                Response.Redirect("VProduct.aspx");
            }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtItemName.Text = "";
        ddlConstraintNos.SelectedIndex = 0;
        Constraint1.Visible = false;
        Constraint2.Visible = false;
        Constraint3.Visible = false;
        Constraint4.Visible = false;
        Constraint5.Visible = false;
        ddlCategory.SelectedIndex = 0;
        sub.Visible = false;
        ddlSub.Visible = false;
        imgProduct.ImageUrl = "~/images/home/Default_image.png";
        imgProduct1.ImageUrl = "~/images/home/Default_image.png";
        imgProduct2.ImageUrl = "~/images/home/Default_image.png";
        txtPath.Text = "";
        txtPath1.Text = "";
        txtPath2.Text = "";
        TextArea1.InnerText = null;
    }
    protected void ddlConstraintNos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlConstraintNos.SelectedValue=="0")
        {
        Constraint1.Visible = false;
        Constraint2.Visible = false;
        Constraint3.Visible = false;
        Constraint4.Visible = false;
        Constraint5.Visible = false;
        }
        if(ddlConstraintNos.SelectedValue=="1")
        {
            Constraint1.Visible = true;
            Constraint2.Visible = false;
            Constraint3.Visible = false;
            Constraint4.Visible = false;
            Constraint5.Visible = false;
        }
        if (ddlConstraintNos.SelectedValue == "2")
        {
            Constraint1.Visible = true;
            Constraint2.Visible = true;
            txtConstraint1.Enabled = false;
            txtConstSymbol1.Enabled = false;
            txtOptions1.Enabled = false;
            btnConstraint1.Enabled = false;
            txtopt1.Enabled = false;
            Constraint3.Visible = false;
            Constraint4.Visible = false;
            Constraint5.Visible = false;
        }
        if (ddlConstraintNos.SelectedValue == "3")
        {
            Constraint1.Visible = true;
            Constraint2.Visible = true;
            txtConstraint1.Enabled = false;
            txtConstSymbol1.Enabled = false;
            txtOptions1.Enabled = false;
            btnConstraint1.Enabled = false;
            txtopt1.Enabled = false;
            Constraint3.Visible = true;
            txtConstraint2.Enabled = false;
            txtConstSymbol2.Enabled = false;
            txtOptions2.Enabled = false;
            btnConstraint2.Enabled = false;
            txtopt2.Enabled = false;
            Constraint4.Visible = false;
            Constraint5.Visible = false;
        }
        if (ddlConstraintNos.SelectedValue == "4")
        {
            Constraint1.Visible = true;
            Constraint2.Visible = true;
            txtConstraint1.Enabled = false;
            txtConstSymbol1.Enabled = false;
            txtOptions1.Enabled = false;
            btnConstraint1.Enabled = false;
            txtopt1.Enabled = false;
            Constraint3.Visible = true;
            txtConstraint2.Enabled = false;
            txtConstSymbol2.Enabled = false;
            txtOptions2.Enabled = false;
            btnConstraint2.Enabled = false;
            txtopt2.Enabled = false;
            Constraint4.Visible = true;
            txtConstraint3.Enabled = false;
            txtConstSymbol3.Enabled = false;
            txtOptions3.Enabled = false;
            btnConstraint3.Enabled = false;
            txtopt3.Enabled = false;
            Constraint5.Visible = false;
        }
        if (ddlConstraintNos.SelectedValue == "5")
        {
            Constraint1.Visible = true;
            Constraint2.Visible = true;
            txtConstraint1.Enabled = false;
            txtConstSymbol1.Enabled = false;
            txtOptions1.Enabled = false;
            btnConstraint1.Enabled = false;
            txtopt1.Enabled = false;
            Constraint3.Visible = true;
            txtConstraint2.Enabled = false;
            txtConstSymbol2.Enabled = false;
            txtOptions2.Enabled = false;
            btnConstraint2.Enabled = false;
            txtopt2.Enabled = false;
            Constraint4.Visible = true;
            txtConstraint3.Enabled = false;
            txtConstSymbol3.Enabled = false;
            txtOptions3.Enabled = false;
            btnConstraint3.Enabled = false;
            txtopt3.Enabled = false;
            Constraint5.Visible = true;
            txtConstraint4.Enabled = false;
            txtConstSymbol4.Enabled = false;
            txtOptions4.Enabled = false;
            btnConstraint4.Enabled = false;
            txtopt4.Enabled = false;
        }
    }
    protected void rbConstM1_CheckedChanged(object sender, EventArgs e)
    {
        txtConstraint2.Enabled = true;
        txtConstSymbol2.Enabled = true;
        txtOptions2.Enabled = true;
        btnConstraint2.Enabled = true;
        txtopt2.Text = "";
        txtConstraint2.Text = "";
        txtConstSymbol2.Text = "";
        txtOptions2.Text = "";
    }
    protected void rbConstB1_CheckedChanged(object sender, EventArgs e)
    {
        txtConstSymbol2.Enabled = false;
        txtConstraint2.Enabled = true;
        txtOptions2.Enabled = true;
        btnConstraint2.Enabled = true;
        txtopt2.Text = "";
        txtConstraint2.Text = "";
        txtConstSymbol2.Text = "";
        txtOptions2.Text = "";
    }
    protected void rbConstB2_CheckedChanged(object sender, EventArgs e)
    {
        txtConstSymbol3.Enabled = false;
        txtConstraint3.Enabled = true;
        txtOptions3.Enabled = true;
        btnConstraint3.Enabled = true;
        txtopt3.Text = "";
        txtConstraint3.Text = "";
        txtConstSymbol3.Text = "";
        txtOptions3.Text = "";
    }
    protected void rbConstM2_CheckedChanged(object sender, EventArgs e)
    {
        txtConstraint3.Enabled = true;
        txtConstSymbol3.Enabled = true;
        txtOptions3.Enabled = true;
        btnConstraint3.Enabled = true;
        txtopt3.Text = "";
        txtConstraint3.Text = "";
        txtConstSymbol3.Text = "";
        txtOptions3.Text = "";
    }
    protected void rbConstB3_CheckedChanged(object sender, EventArgs e)
    {
        txtConstSymbol4.Enabled = false;
        txtConstraint4.Enabled = true;
        txtOptions4.Enabled = true;
        btnConstraint4.Enabled = true;
        txtopt4.Text = "";
        txtConstraint4.Text = "";
        txtConstSymbol4.Text = "";
        txtOptions4.Text = "";
    }
    protected void rbConstM3_CheckedChanged(object sender, EventArgs e)
    {
        txtConstraint4.Enabled = true;
        txtConstSymbol4.Enabled = true;
        txtOptions4.Enabled = true;
        btnConstraint4.Enabled = true;
        txtopt4.Text = "";
        txtConstraint4.Text = "";
        txtConstSymbol4.Text = "";
        txtOptions4.Text = "";
    }
    protected void rbConstM_CheckedChanged(object sender, EventArgs e)
    {
        txtConstraint1.Enabled = true;
        txtOptions1.Enabled = true;
        btnConstraint1.Enabled = true;
        txtConstSymbol1.Enabled = true;
        txtopt1.Text = "";
        txtConstraint1.Text="";
        txtConstSymbol1.Text = "";
        txtOptions1.Text = "";
    }
    protected void rbConstB_CheckedChanged(object sender, EventArgs e)
    {
        txtConstSymbol1.Enabled = false;
        txtConstraint1.Enabled = true;
        txtOptions1.Enabled = true;
        btnConstraint1.Enabled = true;
        txtConstSymbol1.Text = "";
        txtOptions1.Text = "";
        txtConstraint1.Text = "";
        txtopt1.Text = "";
        
    }
    protected void btnConstraint2_Click(object sender, EventArgs e)
    {

        b = txtOptions2.Text;
        if (b != "")
        {
            a = txtopt2.Text;
            if (a != "")
            {
                bool isnot = false;
                string[] opt = a.Split(',');
                for (int g = 0; g < opt.Length; g++)
                {
                    if (isnot == false)
                    {
                        if (opt[g] == b)
                        {
                            isnot = true;
                        }
                    }
                }
                if (rbConstM1.Checked == true)
                {
                    if (isnot == false)
                    {
                        txtopt2.Text = txtopt2.Text + "," + txtOptions2.Text;
                        string ac = (string)txtopt1.Text;
                        string[] sc = ac.Split(',');
                        //double[] ax = new double[sc.Length];
                        //for (int i = 0; i < sc.Length; i++)
                        //{
                        //    ax[i] = Convert.ToDouble(sc[i]);
                        //}
                        //Array.Sort(ax);
                        int x = 0;
                        foreach (var str in sc)
                        {
                            if (x == 0)
                            {
                                da = (str).ToString();
                            }
                            else
                            {
                                da = da + "," + str;
                            }
                            x++;
                        }
                        txtopt2.Text = da;
                        txtOptions2.Text = "";
                    }
                    else
                    {
                        txtOptions2.Text = "";
                    }
                }
                if (rbConstB1.Checked == true)
                {
                    txtopt2.Text = txtopt1.Text + "," + txtOptions1.Text;
                    txtOptions2.Text = "";
                }
            }
            else
            {
                txtopt2.Text = txtOptions1.Text;
                txtOptions2.Text = "";
            }
        }
        else
        {
        }
    }
    protected void btnConstraint3_Click(object sender, EventArgs e)
    {

        b = txtOptions3.Text;
        if (b != "")
        {
            a = txtopt3.Text;
            if (a != "")
            {
                bool isnot = false;
                string[] opt = a.Split(',');
                for (int g = 0; g < opt.Length; g++)
                {
                    if (isnot == false)
                    {
                        if (opt[g] == b)
                        {
                            isnot = true;
                        }
                    }
                }
                if (rbConstM2.Checked == true)
                {
                    if (isnot == false)
                    {
                        txtopt3.Text = txtopt3.Text + "," + txtOptions3.Text;
                        string ac = (string)txtopt3.Text;
                        string[] sc = ac.Split(',');
                        //double[] ax = new double[sc.Length];
                        //for (int i = 0; i < sc.Length; i++)
                        //{
                        //    ax[i] = Convert.ToDouble(sc[i]);
                        //}
                        ////Array.Sort(ax);
                        int x = 0;
                        foreach (var str in sc)
                        {
                            if (x == 0)
                            {
                                da = (str).ToString();
                            }
                            else
                            {
                                da = da + "," + str;
                            }
                            x++;
                        }
                        txtopt3.Text = da;
                        txtOptions3.Text = "";
                    }
                    else
                    {
                        txtOptions3.Text = "";
                    }
                }
                if (rbConstB2.Checked == true)
                {
                    txtopt3.Text = txtopt3.Text + "," + txtOptions3.Text;
                    txtOptions3.Text = "";
                }
            }
            else
            {
                txtopt3.Text = txtOptions3.Text;
                txtOptions3.Text = "";
            }
        }
        else
        {
           
        }
    }
    protected void btnConstraint4_Click(object sender, EventArgs e)
    {

        b = txtOptions4.Text;
        if (b != "")
        {
            a = txtopt4.Text;
            if (a != "")
            {
                bool isnot = false;
                string[] opt = a.Split(',');
                for (int g = 0; g < opt.Length; g++)
                {
                    if (isnot == false)
                    {
                        if (opt[g] == b)
                        {
                            isnot = true;
                        }
                    }
                }
                if (rbConstM3.Checked == true)
                {
                    if (isnot == false)
                    {
                        txtopt4.Text = txtopt4.Text + "," + txtOptions4.Text;
                        string ac = (string)txtopt4.Text;
                        string[] sc = ac.Split(',');
                        //double[] ax = new double[sc.Length];
                        //for (int i = 0; i < sc.Length; i++)
                        //{
                        //    ax[i] = Convert.ToDouble(sc[i]);
                        //}
                        //Array.Sort(ax);
                        int x = 0;
                        foreach (var str in sc)
                        {
                            if (x == 0)
                            {
                                da = (str).ToString();
                            }
                            else
                            {
                                da = da + "," + str;
                            }
                            x++;
                        }
                        txtopt4.Text = da;
                        txtOptions4.Text = "";
                    }
                    else
                    {
                        txtOptions4.Text = "";
                    }
                }
                if (rbConstB3.Checked == true)
                {
                    txtopt4.Text = txtopt4.Text + "," + txtOptions4.Text;
                    txtOptions4.Text = "";
                }
            }
            else
            {
                txtopt4.Text = txtOptions4.Text;
                txtOptions4.Text = "";
            }
        }
        else
        {
            
        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedIndex != 0)
        {
            string i = ddlCategory.SelectedValue;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Sub_Category_Id,Sub_Category_Name from MinorCategory Where Category_Id=@q and Active=@a";
            cmd.Parameters.AddWithValue("@q", i);
            cmd.Parameters.AddWithValue("@a", "yes");
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlSub.DataSource = dt;
                ddlSub.DataTextField = "Sub_Category_Name";
                ddlSub.DataValueField = "Sub_Category_Id";
                ddlSub.DataBind();
                ListItem Category = new ListItem("Select Sub-Category","-1");
                ddlSub.Items.Insert(0, Category);
                sub.Visible = true;
                ddlSub.Visible = true;
            }
            else
            {
                ddlSub.DataSource = dt;
                ddlSub.DataTextField = "Sub_Category_Name";
                ddlSub.DataValueField = "Sub_Category_Id";
                ddlSub.DataBind();
                ListItem Category = new ListItem("Select Sub-Category","-1");
                ddlSub.Items.Insert(0, Category);
                sub.Visible = false;
                ddlSub.Visible = false;
            }
        }
        else
        {
            ddlSub.Visible = false;
            sub.Visible = false;
        }
    }
    protected void btnClear1_Click(object sender, EventArgs e)
    {
        txtopt.Text = "";
    }
    protected void btnClear2_Click(object sender, EventArgs e)
    {
        txtopt1.Text = "";
    }
    protected void btnClear3_Click(object sender, EventArgs e)
    {
        txtopt2.Text = "";
    }
    protected void btnClear4_Click(object sender, EventArgs e)
    {
        txtopt3.Text="";
    }
    protected void btnClear5_Click(object sender, EventArgs e)
    {
        txtopt4.Text = "";
    }
}