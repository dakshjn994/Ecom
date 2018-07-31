<%@ Page Title="Bill" Language="C#" MasterPageFile="~/Mainmaster.master" AutoEventWireup="true" CodeFile="Billing.aspx.cs" Inherits="Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><h2 class="title text-center">Bill</h2><br />
    <div class="container">
          <div class="jumbotron">
              To: <span id="name" runat="server"></span><br />
        Address: <span id="add" runat="server"></span>
              </div>
    <hr />
          <div class="jumbotron">
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <div class="row">
            <div class="col-sm-12">
                <div class="col-md-2">
                    <%#Eval("SrNo")%>. <%#Eval("Item_Name")%>
                </div>
                <div class="col-md-3">
                    <asp:Image ID="Image1" Height="70%" Width="70%" ImageUrl='<%#Eval("Image")%>' runat="server" />
                </div>
                <div class="col-md-1">
                Price: ₹<%#Eval("SalePrice")%>
                    </div>
                <div class="col-md-2">
                    Quantity: <%#Eval("quantity") %> <br />
                </div>
                <div class="col-md-1">
                      Total: ₹<%#Eval("total")%>
                    <br />
                    
                </div>
                <div class="col-md-3">
                    Constraints: 
                <%#Eval("Constraint")%>
                    </div>
                
            </div>
                </div>
        </ItemTemplate>
    </asp:DataList>
              </div>
        <hr />
              <div class="jumbotron">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total: <span id="qua" runat="server" style="margin-left:50%"></span><span id="total" style="margin-left:10%" runat="server"></span>
              </div>
        <div>
        <center><asp:Button ID="Button1" OnClick="Button1_Click" runat="server" CssClass="btn btn-group" Text="Confirm" /><span />&nbsp;&nbsp;&nbsp;<a runat="server" id="A1" class="btn btn-danger" href="~/Cart.aspx"><b class="fa fa-shopping-cart">&nbsp;Cart</b></a></center></div>
        </div>
    <hr />
</asp:Content>