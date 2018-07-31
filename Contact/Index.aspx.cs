using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact_Index : System.Web.UI.Page
{
    string Name, Pmsg, Subject, Email, NMsg;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        Name = txtname.Text;
        Pmsg = txtmsg.Text;
        Subject = "Contact:- "+TextBox2.Text;
        Email = txtemail.Text;
        NMsg = "From Mr." + Name + "<br/><br/>" + "Email: " + Email + "<br/><br/>" + "Message : " + Pmsg;
        SendEmail1 a=new SendEmail1();
        a.SendEmail(Subject,NMsg);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox2.Text = "";
        txtemail.Text = "";
        txtmsg.Text = "";
        txtname.Text = "";
    }
}