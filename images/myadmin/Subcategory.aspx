<%@ Page Title="Add Sub-Category" Language="C#" MasterPageFile="~/myadmin/Adminmaster.master" AutoEventWireup="true" CodeFile="Subcategory.aspx.cs" Inherits="myadmin_Subcategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title text-center">Add Sub-Category</h2>
    <br /><asp:DropDownList ID="DropDownList1" Width="30%" CssClass="center-block" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server"></asp:DropDownList><br />
    <asp:TextBox ID="TextBox1" Enabled="false" CssClass="text-center center-block" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" CssClass="btn btn-default center-block" runat="server" Text="Add" OnClick="Button1_Click" /><br /><hr />
</asp:Content>