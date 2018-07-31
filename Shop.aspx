<%@ Page Title="Shop" Language="C#" MasterPageFile="~/Mainmaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Shop.aspx.cs" Inherits="Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <section>
		<div class="container">
			<div class="row">
				<div class="col-sm-3">
					<div class="left-sidebar">
						<h2>Category</h2>
						<div class="panel-group category-products" id="accordian">
                        <asp:DataList ID="DataList1" runat="server">
                           <ItemTemplate>
                            <div class="panel panel-default">
								<div class="panel-heading">
                                    <h4 class="panel-title"><a href="Shop.aspx?Id=<%#Eval("Category_Id")%>&Name=<%#Eval("Category_Name")%>"><%#Eval("Category_Name") %></a></h4>
								</div>
							</div>
                        </ItemTemplate>
                     </asp:DataList>
						</div>
                        </div>
                    </div>
    <div class="col-sm-9 padding-right">
					<div class="features_items">
						<h2 id="Typepro" runat="server" class="title text-center">Featured Items</h2>
						<asp:DataList ID="DataList2" RepeatDirection="Horizontal" runat="server">
                           <ItemTemplate>
                        <div class="col-sm-4" style="width:100%">
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
                                        <br />
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image")%>' Height="75%" Width="75%" /><br /><br />
										<p> <strike>₹<%#Eval("MRP")%></strike>  &nbsp;₹<%#Eval("SalePrice")%></p>
										<p><%#Eval("Item_Name")%></p>
                                        <asp:Button ID="Button1" CommandArgument='<%#Eval("Item_Id")%>' CssClass="btn btn-default add-to-cart" runat="server" Text="Add To Cart" />
										<%--<a href="#" class=""><i class="fa fa-shopping-cart"></i>Add to cart</a>--%>
									</div>
                                    <div class="product-overlay" style="width:100%;">
										<div class="overlay-content">
                                            <br />
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("Image")%>' Height="75%" Width="75%" /><br /><br />
											<p> <strike>₹<%#Eval("MRP")%></strike>  &nbsp;₹<%#Eval("SalePrice")%></p>
											<p><%#Eval("Item_Name")%></p>
                                            <asp:Button ID="Button2" CssClass="btn btn-default add-to-cart" CommandArgument='<%#Eval("Item_Id")%>' OnClick="Button2_Click" runat="server" Text="Add To Cart" />
										</div>
									</div>
                                    </div>
                                <div class="choose">
									<ul class="nav nav-pills nav-justified">
										<li><a href=""><i class="fa fa-plus-square"></i>Add to wishlist</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to compare</a></li>
									</ul>
								</div>
							</div>
						</div>
                                </div>
                            </div>
                               </ItemTemplate>
                            </asp:DataList>
                        </div>
        </div>
								</div>
            </div>
                                    </section>
</asp:Content>

