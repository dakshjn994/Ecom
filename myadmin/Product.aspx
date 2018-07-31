<%@ Page Title="Insert Product" Language="C#" MasterPageFile="~/myadmin/Adminmaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="myadmin_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <center><h2 id="pro" runat="server" class="title text-center">Add Item</h2></center><br />
    <center>
    <asp:TextBox ID="txtItemName" placeholder="Item Name" runat="server"></asp:TextBox><br /><br /><br />
        <div class="row"><div class="col-sm-1"></div><center><div class="panel col-sm-3 panel-default" style="width:300px;height:420px;">
            <h3 style="width:60%" class="title text-center">Add First Image</h3>
        <asp:Image ID="imgProduct" Height="200px" Width="200px" ImageUrl="~/images/home/Default_image.png" runat="server"></asp:Image>
            <asp:FileUpload ID="fuImage" Width="60%" runat="server" /><br /><br />
        <asp:Button ID="btnImageSubmit2" Width="60%" OnClick="btnImageSubmit2_Click" CssClass="btn btn-info" runat="server" Text="Upload" /><br /><br />
        <asp:Label ID="txtPath" Visible="false" runat="server"></asp:Label>
        </div></center><div class="col-sm-1"></div><center><div class="panel col-sm-3 panel-default"  style="width:300px;height:420px;">
            <h3 style="width:60%" class="title text-center">Add Second Image</h3>
        <asp:Image ID="imgProduct1" Height="200px" Width="200px" ImageAlign="Top" ImageUrl="~/images/home/Default_image.png" runat="server"></asp:Image>
            <asp:FileUpload ID="fuImage1" Width="60%" runat="server" /><br /><br/>
        <asp:Button ID="btnImageSubmit1" Width="60%" OnClick="btnImageSubmit1_Click" CssClass="btn btn-info" runat="server" Text="Upload" /><br /><br />
        <asp:Label ID="txtPath1" Visible="false" runat="server"></asp:Label>
            </div></center><div class="col-sm-1"></div><center><div class="panel col-sm-3 panel-default" style="width:300px;height:420px;">
            <h3 style="width:60%" class="title text-center">Add Third Image</h3>
        <asp:Image ID="imgProduct2" Height="200px" Width="200px" ImageAlign="Top" ImageUrl="~/images/home/Default_image.png" runat="server"></asp:Image>
            <asp:FileUpload ID="fuImage2" Width="60%" runat="server" /><br /><br />
    <asp:Button ID="btnImageSubmit" Width="60%" OnClick="btnImageSubmit_Click" CssClass="btn btn-info" runat="server" Text="Upload" /><br /><br />
        <asp:Label ID="txtPath2" runat="server" Visible="false" Text=""></asp:Label>
            </div></center></div><br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        Category: <asp:DropDownList ID="ddlCategory" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" Width="20%" runat="server"></asp:DropDownList><br /><br />
                <div id="sub" runat="server">Sub Category: <asp:DropDownList ID="ddlSub"  Width="20%" runat="server"></asp:DropDownList></div><br /><br />
                No Of Constraints: <asp:DropDownList ID="ddlConstraintNos" AutoPostBack="true" OnSelectedIndexChanged="ddlConstraintNos_SelectedIndexChanged" Width="15%" runat="server">
            <asp:ListItem Value="0" Text=".."></asp:ListItem>
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
            <asp:ListItem Text="4" Value="4"></asp:ListItem>
            <asp:ListItem Text="5" Value="5"></asp:ListItem>
        </asp:DropDownList><br />
                <div id="Constraint1" runat="server"><br />
    <asp:TextBox ID="txtConstraint" placeholder="First Constraint" runat="server"></asp:TextBox><br /><BR />
    <asp:TextBox ID="txtConstSymbol" placeholder="Symbol" runat="server"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtOptions" placeholder="Add Option" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="btnConstraint" OnClick="btnConstraint_Click" CssClass="btn btn-default" runat="server" Text="Add" />&nbsp;&nbsp;
    <asp:Button ID="btnClear1" OnClick="btnClear1_Click" runat="server" CssClass="btn btn-danger" Text="Clear"></asp:Button><br /><br />
    <asp:TextBox ID="txtopt" placeholder="All Options" Enabled="false" runat="server"></asp:TextBox><br /><br />
                    </div>
                <div id="Constraint2" runat="server">
    <asp:RadioButton ID="rbConstM" OnCheckedChanged="rbConstM_CheckedChanged" AutoPostBack="true" GroupName="123" Text="Measurement" runat="server"></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbConstB" Text="Brand" AutoPostBack="true" OnCheckedChanged="rbConstB_CheckedChanged" GroupName="123" runat="server"></asp:RadioButton><br /><br />
    <asp:TextBox ID="txtConstraint1" placeholder="Second Constraint" runat="server"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtConstSymbol1" placeholder="Symbol" runat="server"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtOptions1" placeholder="Add Option" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="btnConstraint1" CssClass="btn btn-default" OnClick="btnConstraint1_Click" runat="server" Text="Add" />&nbsp;&nbsp;
    <asp:Button ID="btnClear2" OnClick="btnClear2_Click" runat="server" CssClass="btn btn-danger" Text="Clear"></asp:Button><br /><br />
    <asp:TextBox ID="txtopt1" placeholder="All Options" Enabled="false" runat="server"></asp:TextBox><br /><br />
                    </div>
                <div id="Constraint3" runat="server">
    <asp:RadioButton ID="rbConstM1" OnCheckedChanged="rbConstM1_CheckedChanged" AutoPostBack="true" GroupName="c" Text="Measurement" runat="server"></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbConstB1" Text="Brand" OnCheckedChanged="rbConstB1_CheckedChanged" AutoPostBack="true" GroupName="c" runat="server"></asp:RadioButton><br /><br />
    <asp:TextBox ID="txtConstraint2" placeholder="First Constraint" runat="server"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtConstSymbol2" placeholder="Symbol" runat="server"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtOptions2" placeholder="Add Option" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="btnConstraint2" OnClick="btnConstraint2_Click" CssClass="btn btn-default" runat="server" Text="Add" />&nbsp;&nbsp;
    <asp:Button ID="btnClear3" OnClick="btnClear3_Click" runat="server" CssClass="btn btn-danger" Text="Clear"></asp:Button><br /><br />
    <asp:TextBox ID="txtopt2" placeholder="All Options" Enabled="false" runat="server"></asp:TextBox><br /><br />
                    </div>
                <div id="Constraint4" runat="server">
    <asp:RadioButton ID="rbConstM2" OnCheckedChanged="rbConstM2_CheckedChanged" AutoPostBack="true" GroupName="b" Text="Measurement" runat="server"></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbConstB2" OnCheckedChanged="rbConstB2_CheckedChanged" AutoPostBack="true" Text="Brand" GroupName="b" runat="server"></asp:RadioButton><br /><br />
    <asp:TextBox ID="txtConstraint3" placeholder="First Constraint" runat="server"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtConstSymbol3" placeholder="Symbol" runat="server"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtOptions3" placeholder="Add Option" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="btnConstraint3" OnClick="btnConstraint3_Click" CssClass="btn btn-default" runat="server" Text="Add" />&nbsp;&nbsp;
    <asp:Button ID="btnClear4" OnClick="btnClear4_Click" runat="server" CssClass="btn btn-danger" Text="Clear"></asp:Button><br /><br />
    <asp:TextBox ID="txtopt3" placeholder="All Options" Enabled="false" runat="server"></asp:TextBox><br /><br />
                    </div>
                <div id="Constraint5" runat="server">
    <asp:RadioButton ID="rbConstM3" OnCheckedChanged="rbConstM3_CheckedChanged" AutoPostBack="true" GroupName="a" Text="Measurement" runat="server"></asp:RadioButton>&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbConstB3" Text="Brand" OnCheckedChanged="rbConstB3_CheckedChanged" AutoPostBack="true" GroupName="a" runat="server"></asp:RadioButton><br /><br />
    <asp:TextBox ID="txtConstraint4" placeholder="First Constraint" runat="server"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtConstSymbol4" placeholder="Symbol" runat="server"></asp:TextBox><br /><br />
    <asp:TextBox ID="txtOptions4" placeholder="Add Option" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="btnConstraint4" OnClick="btnConstraint4_Click" CssClass="btn btn-default" runat="server" Text="Add" />&nbsp;&nbsp;
    <asp:Button ID="btnClear5" OnClick="btnClear5_Click" runat="server" CssClass="btn btn-danger" Text="Clear"></asp:Button><br /><br />
    <asp:TextBox ID="txtopt4" placeholder="All Options" Enabled="false" runat="server"></asp:TextBox><br /><br />
                    </div>
        <span><asp:CheckBox ID="Featured" runat="server" Text="Featured"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="Sales" runat="server" Text="Sales"></asp:CheckBox></span><br /><br />
        M.R.P. :  <asp:TextBox ID="txtMRP" placeholder="M. R. P." runat="server"></asp:TextBox><br /><br />
        Sale Price : <asp:TextBox ID="txtSalePrice" placeholder="Sale Price" runat="server"></asp:TextBox><br /><br />
        <textarea id="TextArea1" placeholder="Description" style="width:30%" runat="server" rows="2" cols="20"></textarea><br /><br />
        In Stock : <asp:TextBox ID="txtStock" placeholder="Available Goods" runat="server"></asp:TextBox><br /><br />
                <div id="outstock" runat="server" visible="false">Out Stock : <asp:TextBox ID="txtOut" runat="server" Placeholder="Out Stock"></asp:TextBox><br /><br /></div>
                </ContentTemplate></asp:UpdatePanel>
        <span><asp:Button ID="btnFormSubmit" CssClass="btn btn-success" OnClick="btnFormSubmit_Click" runat="server" Text="Submit"></asp:Button>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-warning" runat="server" Text="Clear"></asp:Button></span><br />
        </center><br /><br /><br />
</asp:Content>

