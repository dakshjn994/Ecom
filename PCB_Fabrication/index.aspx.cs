using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Security.Cryptography;
public partial class PCB_Fabrication_index : System.Web.UI.Page
{
    string msg;
    bool a = false, b = false, c = false, d = false, f = false,g=false;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string extension = (string)Path.GetExtension(FileUpload1.FileName);
        if (FileUpload1.HasFile)
        {
            if (extension == ".zip")
            {
                MailMessage mail = new MailMessage();
                try
                {
                    if(single.Checked.Equals(true))
                    {
                        a = true;
                        b = false;
                        c = false;
                    }
                    else if(ndouble.Checked.Equals(true))
                    {
                        a = false;
                        b = true;
                        c = false;
                    }
                    else if(double1.Checked.Equals(true))
                    {
                        a = false;
                        b = false;
                        c = true;
                    }
                    else
                    {
                        a = false; b = false; c = false;
                    }
                    if (legend.Checked.Equals(true) && masking.Checked.Equals(true))
                    {
                        d = true;
                        f = true;
                    }
                    else if(masking.Checked.Equals(true))
                    {
                        d = false;
                        f = true;
                    }
                    else if (legend.Checked.Equals(true))
                    {
                        d = true;
                        f = false;
                    }
                    else
                    {
                        d = false;
                        f = false;
                    }
                    if(a==true)
                    {
                        if(d==true && f==true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Single Side<br />LAYER REQUIRED ON BOARD:- Cu Layer-Legend And Masking Layer<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else if(d==true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Single Side<br />LAYER REQUIRED ON BOARD:- Cu Layer-Legend<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else if(f==true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Single Side<br />LAYER REQUIRED ON BOARD:- Cu Layer-Masking Layer<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else
                        {
                            string var = "Please Select Layer Required on Board";
                            Response.Write("<script language=javascript>alert('" + var + "');</script>");
                        }
                    }
                    else if(b==true)
                    {
                        if(d==true && f==true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Double Side(Non PTH)<br />LAYER REQUIRED ON BOARD:- Cu Layer-Legend And MAsking Layer<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else if (d == true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Double Side(Non PTH)<br />LAYER REQUIRED ON BOARD:- Cu Layer-Legend<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else if (f == true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Double Side(Non PTH)<br />LAYER REQUIRED ON BOARD:- Cu Layer-Masking Layer<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else
                        {
                            string var = "Please Select Layer Required on Board";
                            Response.Write("<script language=javascript>alert('" + var + "');</script>");
                        }
                    }
                    else if(c==true)
                    {
                        if(d==true && f==true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Double Side(PTH)<br />LAYER REQUIRED ON BOARD:- Cu Layer-Legend And Masking Layer<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else if (d == true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Double Side(PTH)<br />LAYER REQUIRED ON BOARD:- Cu Layer-Legend<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else if (f == true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Double Side(PTH)<br />LAYER REQUIRED ON BOARD:- Cu Layer-Masking Layer<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else
                        {
                            string var = "Please Select Layer Required on Board";
                            Response.Write("<script language=javascript>alert('" + var + "');</script>");
                        }
                    }
                    else
                    {
                        string var = "Please Select Layer";
                        Response.Write("<script language=javascript>alert('" + var + "');</script>");
                    }
                    mail = new MailMessage("digitronicarts@gmail.com", "digitronicarts@gmail.com", "PCB Customization", msg);
                    mail.Attachments.Add(new Attachment(FileUpload1.FileContent, System.IO.Path.GetFileName(FileUpload1.FileName)));
                    NetworkCredential mailAuthentication = new NetworkCredential("digitronicarts@gmail.com", "digi1234");
                    SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
                    mailClient.EnableSsl = true;
                    mailClient.Credentials = mailAuthentication;
                    mail.IsBodyHtml = true;
                    mailClient.Send(mail);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    mail.Dispose();
                }
            }
            else
            {
                string var = "Please Upload Correct Format File";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
        }
            else
            {
                string var = "Please Upload File";
                Response.Write("<script language=javascript>alert('" + var + "');</script>");
            }
      }
}