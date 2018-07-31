<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="myadmin_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Admin Login | Digitronicarts</title>

    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/font-awesome.min.css" rel="stylesheet"/>
    <link href="../css/prettyPhoto.css" rel="stylesheet"/>
    <link href="../css/price-range.css" rel="stylesheet"/>
    <link href="../css/animate.css" rel="stylesheet"/>
	<link href="../css/main.css" rel="stylesheet"/>
	<link href="../css/responsive.css" rel="stylesheet"/>
</head>
<body class="jumbotron">
    <form id="form1" runat="server">
   <div>
        <br /><br />
        <center><h2 class=" text-info">Digitronicarts</h2></center>
        <br />
        <center><asp:TextBox ID="txtName" placeholder="Name" CssClass="text-center" runat="server"></asp:TextBox></center><br />
        <center><asp:TextBox ID="txtPassword" placeholder="Password" CssClass="text-center" TextMode="Password" runat="server"></asp:TextBox></center><br />
        <center><asp:Button ID="btnLogin" OnClick="btnLogin_Click" runat="server" CssClass="btn btn-success" Text="Login" /></center>
    </div>
    <script src="../js/jquery.js"></script>
	<script src="../js/bootstrap.min.js"></script>
	<script src="../js/jquery.scrollUp.min.js"></script>
	<script src="../js/price-range.js"></script>
    <script src="../js/jquery.prettyPhoto.js"></script>
    <script src="../js/main.js"></script>
    </form>
</body>
</html>
