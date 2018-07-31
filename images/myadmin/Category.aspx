<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/myadmin/Adminmaster.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="myadmin_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h2 class="title text-center">Add Category</h2></center><br />
    <center><asp:TextBox ID="TextBox1" runat="server" placeholder="Category Name"></asp:TextBox></center><br />
    <center><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-default" Text="Add"></asp:Button></center><hr />
</asp:Content>

