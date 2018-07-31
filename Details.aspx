<%@ Page Title="Details" Language="C#" MasterPageFile="~/Mainmaster.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br /><br />
    <div class="row">
        <div class="col-sm-12">
            <h2 id="name" class="title text-center" runat="server"></h2>
            <br />
            <div class="col-sm-5">
                <%--<asp:Image ID="Image1" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" Style="margin-left: 10%"  Height="250px" Width="80%" runat="server" /><br />--%>
                <div id="slider-carousel" class="carousel slide" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#slider-carousel" data-slide-to="0" class="active"></li>
                        <li data-target="#slider-carousel" data-slide-to="1"></li>
                        <li data-target="#slider-carousel" data-slide-to="2"></li>
                    </ol>
                    <div class="carousel-inner">
                        <div class="item active">
                            <div class="col-sm-12 grow">
                                <center><asp:Image ID="Image1" Height="250px" Width="100%" runat="server" /></center>
                                <%--<img src="images/home/pricing.png"  class="pricing" alt="" />--%>
                            </div>
                        </div>
                        <div class="item">
                            <div class="col-sm-12 grow">
                                <center><asp:Image ID="Image2" Height="250px" Width="100%" runat="server" /></center>
                                <%--<img src="images/home/pricing.png"  class="pricing" alt="" />--%>
                            </div>
                        </div>
                        <div class="item">
                            <div class="col-sm-12 grow">
                                <center><asp:Image ID="Image3" Height="250px" Width="100%" runat="server" /></center>
                                <%--	<img src="images/home/pricing.png" class="pricing" alt="" />--%>
                            </div>
                        </div>
                    </div>
                    <a href="#slider-carousel" class="left control-carousel hidden-xs" data-slide="prev">
                        <i class="fa fa-angle-left"></i>
                    </a>
                    <a href="#slider-carousel" class="right control-carousel hidden-xs" data-slide="next">
                        <i class="fa fa-angle-right"></i>
                    </a>
                </div>
                <br />
                <br />
                <br />
                <br />
                <center><div class="carousel-indicators">
							<img id="ImageB1" data-target="#slider-carousel" data-slide-to="0" style="height:50px;width:50px;border:solid;border-color:black;border-width:1px" runat="server" />
							<img id="ImageB2" data-target="#slider-carousel" data-slide-to="1" style="height:50px;width:50px;border:solid;border-color:black;border-width:1px" runat="server" />
                            <img id="ImageB3" data-target="#slider-carousel" data-slide-to="2" style="height:50px;width:50px;border:solid;border-color:black;border-width:1px" runat="server" />
						</div>
<br />
            
<%--<asp:ImageButton ID="ImageButton1" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" CssClass="img-thumbnail" OnClick="ImageButton1_Click" Height="60px" Width="60px" runat="server" />--%>
            </div>
            <div class="col-sm-7">
                <h4 id="Des" runat="server"  style="width: 80%;text-align:justify"></h4>
                <br />
                <div class="col-md-12">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <cc1:Rating ID="Rating2" Enabled="false" AutoPostBack="true" StarCssClass="fa fa-star-o" EmptyStarCssClass="fa fa-star-o" FilledStarCssClass="fa fa-star" WaitingStarCssClass="fa fa-star" runat="server"></cc1:Rating>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </div>
                <div class="col-md-6" id="constr" runat="server">
                    <h4 id="Constraint1" runat="server"></h4>
                    <asp:DropDownList ID="DropDownList1" Width="50%" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-6" id="constr1" runat="server">
                    <h4 id="Constraint2" runat="server"></h4>
                    <asp:DropDownList ID="DropDownList2" Width="50%" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-6" id="constr2" runat="server">
                    <h4 id="Constraint3" runat="server"></h4>
                    <asp:DropDownList ID="DropDownList3" Width="50%" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-6" id="constr3" runat="server">
                    <h4 id="Constraint4" runat="server"></h4>
                    <asp:DropDownList ID="DropDownList4" Width="50%" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-6" id="constr4" runat="server">
                    <h4 id="Constraint5" runat="server"></h4>
                    <asp:DropDownList ID="DropDownList5" Width="50%" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <h2 style="margin-left: 2%; margin-top: 5%">₹ <strike id="mrp" runat="server"></strike>&nbsp;&nbsp;&nbsp;&nbsp; ₹ <b id="sales" runat="server"></b></h2>
                </div>
                <div class="col-md-6">
                    <br />
                    Quantity:
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="TextBox1" FilterMode="ValidChars" FilterType="Numbers" runat="server" />
                    <asp:TextBox ID="TextBox1" Text="5" Width="30%" runat="server"></asp:TextBox>
                            </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <br />
                <div class="col-md-6">
                    <br />
                    <a runat="server" id="Button1" class="btn btn-warning" style="margin-left: 2%" onclick="return alert('Product Added');" onserverclick="Button1_Click"><b class="fa fa-shopping-cart">Add to Cart</b></a></div>
            </div>
            <br />
            <div class="col-sm-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="col-md-4">
                            <div id="photo" runat="server" class="panel panel-default center-block" style="height: 60%; width: 50%;">
                                <center><h4>Check Sample Image</h4><asp:Image ID="Image4" Height="80%" Width="80%" ImageUrl="~/images/home/Default_image.png" runat="server" ImageAlign="Top" /><br /><asp:Button ID="Button3" runat="server" CssClass="btn btn-info" Text="Check" OnClick="Button3_Click" /></center>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox2" TextMode="MultiLine" placeholder="Comment" CssClass=" text-center text-area" runat="server"></asp:TextBox></div>
                        <div class="col-md-2">
                            <br />
                            <br />
                            <br />
                            Rating :
                            <cc1:Rating ID="Rating1" OnChanged="Rating1_Changed" AutoPostBack="true" StarCssClass="fa fa-star-o" EmptyStarCssClass="fa fa-star-o" FilledStarCssClass="fa fa-star" WaitingStarCssClass="fa fa-star" runat="server"></cc1:Rating>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-12">
                <br />
                <center><asp:Button ID="Button2" runat="server" CssClass="btn btn-default" OnClick="Button2_Click" Text="Submit" /><br /><asp:Label ID="Label1" runat="server" Text=""></asp:Label></center>
            </div>
            <div class="col-lg-12">
                <h3 class="text-center" style="color: #3399ff">Comments</h3>
                <br />
                <center><asp:DataList ID="DataList1" runat="server">
                            <ItemTemplate>
                            <div class="col-sm-12">
                                <div class="col-md-2"><i class="fa fa-user fa-4x"></i><br />
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-9">
                                    <%#Eval("Email")%>&nbsp;&nbsp;&nbsp;<%#Eval("Rating")%> <i class="fa fa-star"></i><br />
                                    <%#Eval("Comment")%>
                                </div>
                            </div><br /><br />
                            </ItemTemplate>
                        </asp:DataList></center>
                <br />

            </div>
        </div>
        <div class="col-md-2">
        </div>
    </div>

    </div>
        
    </div>
    <hr />
</asp:Content>
