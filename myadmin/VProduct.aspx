<%@ Page Title="Edit Product" Language="C#" EnableEventValidation="false" MasterPageFile="~/myadmin/Adminmaster.master" AutoEventWireup="true" CodeFile="VProduct.aspx.cs" Inherits="myadmin_VProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title text-center">Edit Products</h2>
    <h3 class="text-center">Products</h3><br />
            <div class="jumbotron">
                <div class="row">         
                    <div class="col-sm-12">
       <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <center>
                        <div class="col-md-1">
                           <%#Eval("Item_Name")%>
                        </div>
                        <div class="col-md-1">
                            <asp:Image ID="Image1" Height="75px" Width="75px" ImageUrl='<%#Eval("Image")%>' runat="server"></asp:Image>
                        </div>
                        <div class="col-md-1">
                           Constraint: <%#Eval("NoOfConstraints")%>
                        </div>
                        <div class="col-md-1">
                           <%#Eval("MRP")%>
                        </div>
                        <div class="col-md-1">
                            <%#Eval("SalePrice")%>
                        </div>
                        <div class="col-md-1">
                            In Stock: <%#Eval("In_Stock")%>
                        </div>
                        <div class="col-md-1">
                           Out Stock: <%#Eval("Out_Stock")%>
                        </div>
                        <div class="col-md-1">
                            Sales: <%#Eval("Sales")%>
                        </div>
                <div class="col-md-1">
                    Featured: <%#Eval("Featured")%>
                </div>
                        <div class="col-md-1">
                      Cat.: <%#Eval("Category_Id")%>
                        </div>
                        <div class="col-md-1">
                           Sub Cat.: <%#Eval("Sub_Category_Id") %> 
                        </div>
                <div class="col-md-1">
                     <a href='Product.aspx?Id=<%#Eval("Item_Id")%>'><i class="fa fa-edit"></i></a>&nbsp;&nbsp; <asp:ImageButton ID="ImageButton1" ImageUrl="~/images/home/editing-delete-icon.png" OnClick="ImageButton1_Click" Height="20px" Width="20px" runat="server" CommandArgument='<%#Eval("Item_Id") %>' />
                </di>
                </center>
        </ItemTemplate>
    </asp:DataList>
   </div>
   </div>
  </div>
    <hr />
</asp:Content>