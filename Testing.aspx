<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Testing.aspx.cs" Inherits="Testing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
     <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/font-awesome.min.css" rel="stylesheet"/>
    <link href="../css/prettyPhoto.css" rel="stylesheet"/>
    <link href="../css/price-range.css" rel="stylesheet"/>
    <link href="../css/animate.css" rel="stylesheet"/>
	<link href="../css/main.css" rel="stylesheet"/>
	<link href="../css/responsive.css" rel="stylesheet"/>
    <link rel="shortcut icon" href="images/ico/favicon.ico">
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="images/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="images/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="images/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="images/ico/apple-touch-icon-57-precomposed.png">
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainmenu pull-left">
                            <div class="panel panel-default">
        <asp:DataList ID="outerDataList" runat="server" OnItemDataBound="outerDataList_ItemDataBound">
                <ItemTemplate>
             <div class="panel-heading">
									<h4 class="panel-title">
										<a data-toggle="collapse" data-parent="#accordian" href='#<%#Eval("Category_Id")%>'>
											<span class="badge pull-right"><i class="fa fa-plus"></i></span>
											<%#Eval("Category_Name")%>
										</a>
									</h4>
								</div>
                        <div id='<%#Eval("Category_Id") %>' class="panel-collapse collapse">
									<div class="panel-body">
										<ul>
                        <asp:DataList ID="innerDataList" runat="server">
                            <ItemTemplate>
                                <li><a href='Index.aspx?UId=<%#Eval("Sub_Category_Id")%>&UName=<%#Eval("Sub_Category_Name")%>'><%#Eval("Sub_Category_Name")%></a></li>
                            </ItemTemplate>
                        </asp:DataList>
                        </ul>
									</div>
								</div>
                </ItemTemplate>
            </asp:DataList>
            </div>
            </div>
    </form>
    <script src="../js/jquery.js"></script>
	<script src="../js/bootstrap.min.js"></script>
	<script src="../js/jquery.scrollUp.min.js"></script>
	<script src="../js/price-range.js"></script>
    <script src="../js/jquery.prettyPhoto.js"></script>
    <script src="../js/main.js"></script>
</body>
</html>