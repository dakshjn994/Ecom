<%@ Page Title="Add Sample" Language="C#" MasterPageFile="~/myadmin/Adminmaster.master" AutoEventWireup="true" CodeFile="SampleImage.aspx.cs" Inherits="myadmin_SampleImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><center><h2 class="title">Add Sample Image</h2></center></div>
    <div><center><asp:DropDownList ID="DropDownList1" Width="30%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server"></asp:DropDownList></center></div>
    <div><center><asp:DropDownList ID="DropDownList2" Width="30%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" runat="server"></asp:DropDownList></center></div>
    <div><center><asp:DropDownList ID="DropDownList3" Width="30%" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" runat="server"></asp:DropDownList></center></div>
    <div><center><asp:DropDownList ID="DropDownList5" AutoPostBack="true" Width="30%" runat="server"></asp:DropDownList></center></div>
    <div><center><asp:DropDownList ID="DropDownList6" AutoPostBack="true" Width="30%" runat="server"></asp:DropDownList></center></div>
    <div><center><asp:DropDownList ID="DropDownList7" AutoPostBack="true" Width="30%" runat="server"></asp:DropDownList></center></div>
    <div><center><asp:DropDownList ID="DropDownList8" AutoPostBack="true" Width="30%" runat="server"></asp:DropDownList></center></div>
    <div><center><asp:DropDownList ID="DropDownList9" AutoPostBack="true" Width="30%" runat="server"></asp:DropDownList></center></div>
    <div><center><asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label></center></div>
    <br /><div><center><asp:Button ID="Button2" CssClass="btn btn-default" runat="server" Text="Create Sample Value" OnClick="Button2_Click"></asp:Button></center></div><br />
    <div id="photo" runat="server" visible="false" class="panel panel-default center-block" style="height:50%;width:30%;"><center><h4>Add Image</h4><asp:Image ID="Image1" Height="80%" Width="80%" ImageUrl="~/images/home/Default_image.png" runat="server" ImageAlign="Top" /><br /><br /><asp:FileUpload ID="FileUpload1" CssClass="center-block" Height="5%" Width="50%" runat="server" /><asp:Label ID="Label2" runat="server" Text=""></asp:Label><br /><asp:Button ID="Button3" runat="server" CssClass="btn btn-info" Text="Upload" OnClick="Button3_Click" /><br /></center></div><br />
    <div><center><asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="Button1_Click" /></center></div><br />
</asp:Content>