<%@ Page Title="Add Admin" Language="C#" MasterPageFile="~/myadmin/Adminmaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="AddAdmin.aspx.cs" Inherits="myadmin_AddAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <center><h2 class="title text-center">Add Admin</h2></center><br />
    <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" runat="server" />
    <center><asp:TextBox ID="TextBox1" CssClass=" text-center" placeholder="Name" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="TextBox1" Text="*" ToolTip="Name is Required" ValidationGroup="ab1" ErrorMessage="Name is Required"></asp:RequiredFieldValidator></center><br />
    <center><asp:TextBox ID="TextBox2" CssClass=" text-center" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ForeColor="Red" Text="*" ValidationGroup="ab1" ToolTip="Password is Required" ErrorMessage="Password is Required"></asp:RequiredFieldValidator></center><br />
    <center><asp:TextBox ID="TextBox3" CssClass=" text-center" TextMode="Password" placeholder="Re Enter Password" runat="server"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Textbox2" ControlToValidate="TextBox3" ValidationGroup="ab1" ForeColor="Red" Text="*" ToolTip="Passwords Dont Match" ErrorMessage="Passwords Dont Match"></asp:CompareValidator></center><br />
        <%--<center><asp:CheckBox ID="CheckBox1" Checked="true" Text="   Give Login Privilege" runat="server"></asp:CheckBox></center><br />--%>
    <center><asp:Button ID="Button1" runat="server" CssClass="btn btn-default" OnClick="Button1_Click" ValidationGroup="ab1" Text="Submit" /></center><hr />
</asp:Content>