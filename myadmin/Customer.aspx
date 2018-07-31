<%@ Page Title="Customer" Language="C#" MasterPageFile="~/myadmin/Adminmaster.master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="myadmin_Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title text-center">Customer Details</h2>
    <center><asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="Customer_Name" HeaderText="Customer_Name" SortExpression="Customer_Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Mobile_No" HeaderText="Mobile_No" SortExpression="Mobile_No" />
        </Columns>
    </asp:GridView></center><hr />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DigitronicartsConnection %>" SelectCommand="SELECT Customer_Name,Email,Address,Mobile_No FROM Customer WHERE Active ='yes'"></asp:SqlDataSource>
</asp:Content>