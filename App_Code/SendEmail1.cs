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

/// <summary>
/// Summary description for SendEmail1
/// </summary>
public class SendEmail1
{
    MailMessage mail;
    NetworkCredential mailAuthentication;
    static string FromID = "digitronicarts@gmail.com";                // ENTER FROM EMAIL ID
    static string pwd = "digi1234";                             // PASSWORD

	public void SendEmail(string Sub,string Msg)
	{
        string ToEmail = "digitronicarts@gmail.com";
        mail = new MailMessage(FromID, ToEmail, Sub, Msg);
        mailAuthentication = new NetworkCredential(FromID, pwd);
        SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
        mailClient.EnableSsl = true;
        mailClient.Credentials = mailAuthentication;
        mail.IsBodyHtml = true;
        mailClient.Send(mail);
	}
}