<%@ Page Title="" Language="C#" MasterPageFile="~/myadmin/Adminmaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="RCategory.aspx.cs" Inherits="myadmin_RCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title text-center">Edit Category</h2>
    <center><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
                <asp:BoundField HeaderText="Category Name" DataField="Category_Name" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Eval("Category_Id")%>' runat="server" OnClick="ImageButton1_Click" ImageUrl="~/images/home/editing-delete-icon.png" OnClientClick="return confirm('Are you sure you want to remove this Category and Delete all of it Content Products ?');" Height="40px" Width="40px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" ImageUrl="~/images/home/bfa_edit_simple-black_128x128.png" Height="40px" Width="40px" CommandArgument='<%#Eval("Category_Id")%>' runat="server" OnClientClick="return confirm('Are you sure you want to Edit this Category ?');" OnClick="ImageButton2_Click"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView></center>
    <br />
    <div id="formy" runat="server">
        <hr />
        <center><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><br />
        <span><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-success" Text="Submit" /><span /><span /><span />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" CssClass="btn btn-danger" Text="Cancel" /></span></center>
    </div>
    <hr />
</asp:Content>