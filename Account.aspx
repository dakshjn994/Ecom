<%@ Page Title="My Account" Language="C#" MasterPageFile="~/Mainmaster.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title text-center">Personal Details</h2><br />
    <div class="jumbotron">
    <center>Name : <span id="nam" runat="server"></span>&nbsp;&nbsp;&nbsp;&nbsp;
    Email : <span id="email" runat="server"></span><br />
    Address : <span id="add" runat="server"></span>&nbsp;&nbsp;<a href="#"><i class="fa fa-pencil-square-o"></i></a><br />
    Mobile no. : <span id="mob" runat="server"></span>&nbsp;&nbsp;<a href="#"><i class="fa fa-pencil-square-o"></i></a>&nbsp;&nbsp;&nbsp;&nbsp;Password : &nbsp;&nbsp;<a href="#"><i class="fa fa-pencil-square-o"></i></a></center><br /></div>
    <h2 class="title text-center">My Orders</h2><br /><br />
    <div class="jumbotron">
        <div class="row text-center">
                <div class="col-md-2">Bill Id</div>
                <div class="col-md-2">Name</div>
                <div class="col-md-1">Quantity</div>
                <div class="col-md-2">Constraints</div>
                <div class="col-md-3">Address</div>
                <div class="col-md-1">Status</div>
            </div>
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <center><div class="row">
                <div class="col-md-2"><%#Eval("Bill_Id")%></div>
                <div class="col-md-2"><%#Eval("Product_Name") %></div>
                <div class="col-md-1"><%#Eval("Product_Quantity") %></div>
                <div class="col-md-2"><%#Eval("Constraints") %></div>
                <div class="col-md-4"><%#Eval("Address") %></div>
                <div class="col-md-1"><%#Eval("Status") %></div>
            </div></center>
        </ItemTemplate>
    </asp:DataList>
    <center><div id="noor" runat="server" visible="false">No Orders Placed</div></center>
        </div>
</asp:Content>