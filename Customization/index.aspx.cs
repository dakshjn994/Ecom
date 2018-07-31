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
public partial class Customization_index : System.Web.UI.Page
{
    string msg;
    bool a=false, b=false,c=false,d=false,f=false;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        string extension = (string)Path.GetExtension(FileUpload1.FileName);
        if (FileUpload1.HasFile)
        {
            if (extension == ".zip" || extension == ".rar")
            {
                MailMessage mail = new MailMessage();
                try
                {
                    if (single.Checked.Equals(true))
                    {
                        a = true;
                        b = false;
                    }
                    else if (double1.Checked.Equals(true))
                    {
                        a = true;
                        b = true;
                    }
                    else
                    {
                        a = false;
                        b = false;
                    }
                    if (schematic.Checked.Equals(true))
                    {
                        c = true;
                        d = false;
                        f = false;
                    }
                    else if (replicate.Checked.Equals(true))
                    {
                        c = false;
                        d = true;
                        f = false;
                    }
                    else if (both.Checked.Equals(true))
                    {
                        c = false;
                        d = false;
                        f = true;
                    }
                    else
                    {
                        c = false;
                        d = false;
                        f = false;
                    }
                    if (a == true)
                    {
                        if (c == true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Single Side<br />Source:- Design From Schematic<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else if (d == true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Single Side<br />Source:- Replicate PCB<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else if (f == true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Single Side<br />Source:- Both<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else
                        {
                            string var = "Please Select Source";
                            Response.Write("<script language=javascript>alert('" + var + "');</script>");
                        }
                    }
                    else if (b == true)
                    {
                        if (c == true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Double Side(PTH & Non PTH)<br />Source:- Design From Schematic<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else if (d == true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Double Side(PTH & Non PTH)<br />Source:- Replicate PCB<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else if (f == true)
                        {
                            msg = "<b>Personal Details:-</b> <br /><br/>Name:- " + txtfname.Text + " " + txtmname.Text + " " + txtlname.Text + "<br />Company:- " + txtcompany.Text + "<br />Email:- " + txtemail.Text + "<br />Address:- " + txtadd1.Text + "<br/>Contact:- " + txtcontact.Text + "<br /><br /><b>Customization Details:- </b><br /><br />Layer:- Double Side(PTH & Non PTH)<br />Source:- Both<br/>Size:- " + txtsize.Text + "<br/>Description:- " + txtdesc.Text;
                        }
                        else
                        {
                            string var = "Please Select Source";
                            Response.Write("<script language=javascript>alert('" + var + "');</script>");
                        }
                    }
                    else
                    {
                        string var = "Please Select Layers";
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