<%@ Page Title="Shipping" Language="C#" MasterPageFile="~/Mainmaster.master" AutoEventWireup="true" CodeFile="Shipping.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title text-center">Shipping Info</h2>
    <div class="row">
    
    <div style="margin-left:10%">
    <asp:RadioButton ID="rdbtnExi" GroupName="123" AutoPostBack="true" OnCheckedChanged="rdbtnExi_CheckedChanged" runat="server" Text="Existing Address" /><br />
    <asp:RadioButton ID="rdbtnNew" GroupName="123" AutoPostBack="true" OnCheckedChanged="rdbtnNew_CheckedChanged" runat="server" Text="New Address" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtAddress" placeholder="Address" Enabled="false" style="width:25%" TextMode="MultiLine" Visible="false" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="btnShip" runat="server" OnClick="btnShip_Click" CssClass="btn btn-default" Text="Submit" />
        </div>
        
        <hr /></div>
</asp:Content>