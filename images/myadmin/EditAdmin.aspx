<%@ Page Title="" Language="C#" MasterPageFile="~/myadmin/Adminmaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="EditAdmin.aspx.cs" Inherits="myadmin_EditAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <center><h2 class="title text-center">Edit Admin</h2></center>
    <center>
        <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Name" DataField="Name" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Eval("Admin_Id")%>' Height="40px" Width="40px" runat="server" OnClientClick="return confirm('Are you sure you want to remove this Admin ?');" OnClick="ImageButton1_Click" ImageUrl="~/images/home/editing-delete-icon.png"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" ImageUrl="~/images/home/bfa_edit_simple-black_128x128.png" Height="40px" Width="40px" CommandArgument='<%#Eval("Admin_Id")%>' runat="server" OnClientClick="return confirm('Are you sure you want to Edit this Admin ?');" OnClick="ImageButton2_Click" runat="server"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </center>
    <div id="form" runat="server" style="margin-right:10%;">
        <br /><br /><br />
        <center><h3>Change Name/Password</h3></center><br />
    <center><asp:TextBox ID="TextBox1" CssClass=" text-center" placeholder="Name" runat="server"></asp:TextBox></center><br />
    <center><asp:TextBox ID="TextBox2" CssClass=" text-center" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox></center><br />
    <center><asp:TextBox ID="TextBox3" CssClass=" text-center" TextMode="Password" placeholder="Re Enter Password" runat="server"></asp:TextBox></center><br />
        <%--<center><asp:CheckBox ID="CheckBox1" Checked="true" Text="   Give Login Privilege" runat="server"></asp:CheckBox></center><br />--%>
    <center><asp:Button ID="Button3" runat="server" CssClass="btn btn-default" OnClick="Button3_Click" Text="Submit" />&nbsp;&nbsp;&nbsp;<asp:Button ID="Button4" runat="server" CssClass="btn btn-default" OnClick="Button4_Click" Text="Cancel" /></center></div><hr />
</asp:Content>

