<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Mainmaster.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><h2 class="title text-center">Cart</h2><br />
    <div class="container">
          <div class="jumbotron">
    <asp:DataList ID="DataList1" RepeatColumns="1" DataKeyField="Item_Id" runat="server">
        <ItemTemplate>
            <div class="row">
            <div class="col-sm-12">
                <div class="col-md-3">
                    <asp:ImageButton ID="imgDeleteProduct" AlternateText="X" Height="15px" Width="15px" ImageUrl="~/images/home/fa-times.png" OnClientClick="return confirm('Are you sure you want to remove this product?');" runat="server" OnClick="imgDeleteProduct_Click" CausesValidation="true" CommandArgument='<%#Eval("SrNo")%>' />&nbsp;&nbsp;&nbsp;<%#Eval("SrNo")%>. <%#Eval("Item_Name")%>
                </div>
                <div class="col-md-2">
                    <asp:Image ID="Image1" CssClass="grow" Height="70%" Width="70%" ImageUrl='<%#Eval("Image")%>' runat="server" />
                </div>
                <div class="col-md-1">
                Price:₹<%#Eval("SalePrice")%>
                    </div>
                <div class="col-md-2">
                    Quantity: <br /><span><asp:Button ID="Button1" runat="server" CssClass="btn btn-link" OnClick="Button1_Click" CommandArgument='<%#Eval("SrNo")%>' Text="+"></asp:Button><asp:TextBox ID="ddlQuantity" AutoPostBack="true" Enabled="false" Text='<%#Bind("quantity")%>' Width="40%" runat="server"> Total: </asp:TextBox><asp:Button ID="Button2" CommandArgument='<%#Eval("SrNo")%>' runat="server" CssClass="btn btn-link" OnClick="Button2_Click" Text="-"></asp:Button></span>
                </div>
                <div class="col-md-1">
                      Total:₹<%#Eval("total")%>
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

        <span id="abc" runat="server"></span>
              </div>
        <center><asp:Button ID="Checkout" OnClick="Checkout_Click" CssClass="btn btn-default" runat="server" Text="Checkout" />&nbsp;&nbsp;&nbsp;<a href="Index.aspx" class="btn btn-success">Shop More</a></center><br /><br />
    <center><asp:Label ID="lblError" CssClass="text-capitalize" runat="server" Text=""></asp:Label></center>
        </div>
</asp:Content>