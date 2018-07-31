<%@ Page Title="Edit Category/Sub Category" Language="C#" EnableEventValidation="false" MasterPageFile="~/myadmin/Adminmaster.master" AutoEventWireup="true" CodeFile="CatAnd Sub.aspx.cs" Inherits="myadmin_CatAnd_Sub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="text-center title" style="font-size:large;">Category</h2>
    <div class="container">
        <div class="col-sm-4"></div>
        <div class="col-sm-4">
                            <div class="panel-group category-products" id="accordian" >
                            <div class="panel panel-default"><center>
        <asp:DataList ID="outerDataList" runat="server" OnItemDataBound="outerDataList_ItemDataBound" >
                <ItemTemplate>
             <div class="panel-heading">
									<h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordian" href='#<%#Eval("Category_Id")%>'>
											<span class="badge pull-right"><i class="fa fa-plus"></i></span></a>
                                        <a href='#<%#Eval("Category_Id")%>'>
											<span class="badge pull-right">
                                                <asp:ImageButton ID="ImageButton2" OnClientClick="return confirm('Are you sure you want to remove this Category And All Of Its Contents(Sub Categories and Products) ?');" OnClick="ImageButton2_Click" Height="12px" Width="12px" ImageUrl="~/images/home/fa-times.png" CommandArgument='<%#Eval("Category_Id") %>' runat="server" /></span></a>
                                        <a>
                                        <a href='Category.aspx?Id=<%#Eval("Category_Id")%>&Name=<%#Eval("Category_Name") %>'>
											<span class="badge pull-right"><i class="fa fa-edit"></i></span></a>
                                        <a>
                                        <a style="font-size:large">
											<%#Eval("Category_Name")%>
										</a>
									</h4>
								</div>
                        <div id='<%#Eval("Category_Id") %>' class="panel-collapse collapse">
									<div class="panel-body">
										<ul>
                        <asp:DataList ID="innerDataList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a>
											<span class="badge pull-right">
                                                <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" Height="12px" Width="12px" OnClientClick="return confirm('Are you sure you want to remove this Sub-Category ?');" ImageUrl="~/images/home/fa-times.png" CommandArgument='<%#Eval("Sub_Category_Id") %>' runat="server" /></span></a>
                                        </a>
                                        <a href='Subcategory.aspx?Id=<%#Eval("Sub_Category_Id")%>&Name=<%#Eval("Sub_Category_Name")%>'>
											<span class="badge pull-right"><i class="fa fa-edit"></i></span></a>
                                        </a>
                                    <a style="font-size:medium">
                                        <%#Eval("Sub_Category_Name")%>
                                    </a>
                                            </li>
                            </ItemTemplate>
                        </asp:DataList>
                        </ul>
									</div>
								</div>
                </ItemTemplate>
            </asp:DataList>
            <asp:DataList ID="DataList1" runat="server">
                                    <ItemTemplate>
                                        <div class="panel panel-default" >
								<div class="panel-heading">
									<h4 class="panel-title">
                                        <a href='#<%#Eval("Category_Id")%>'>
											<span class="badge pull-right"> <asp:ImageButton ID="ImageButton3" OnClick="ImageButton3_Click" OnClientClick="return confirm('Are you sure you want to remove this Category ?');" Height="12px" Width="12px" ImageUrl="~/images/home/fa-times.png" CommandArgument='<%#Eval("Category_Id") %>' runat="server" /></span></a>
                                        <a>
                                        <a href='#<%#Eval("Category_Id")%>'>
											<span class="badge pull-right"><i class="fa fa-edit"></i></span></a>
                                        <a>
                                        <a style="font-size:large"><%#Eval("Category_Name")%>&nbsp;&nbsp;</a></h4>
								</div>
							</div>
                                    </ItemTemplate>
                                </asp:DataList>
                                </center>
                                </div>
                                </div>
                </div>
        <div class="col-sm-4"></div>
        </div>
    <hr />  
</asp:Content>