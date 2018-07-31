<%@ Page Title="Customization" Language="C#" EnableEventValidation="false" MasterPageFile="~/Mainmaster.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Customization_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div class="row">
        <h2 class="title text-center">PCB Custumization</h2>
        <center><h2>Get Your PCB Designed In a Week!!</h2></center>
        <hr />
        <div class="col-sm-3">
        </div>
        <div class="col-sm-6">

            <div class="contact-form">
                <div class="status alert alert-success" style="display: none"></div>
                <form id="main-contact-form" class="contact-form row" name="contact-form" method="post">
                    <div>
                        <h4>Personal Details:-</h4><hr />
                    </div>
                    <div class="form-group col-md-4">
                        <asp:TextBox ID="txtfname" Height="40px" Width="100%" type="name" name="name" class="form-control" required="required" placeholder="First Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <asp:TextBox ID="txtmname" Height="40px" Width="100%" type="name" name="name" class="form-control" placeholder="Middle Name" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <asp:TextBox ID="txtlname" Height="40px" Width="100%" type="name" name="name" class="form-control" required="required" placeholder="Last Name" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group col-md-12">
                        <asp:TextBox ID="txtcompany" Height="40px" Width="100%" type="name" name="name" class="form-control" required="required" placeholder="Company Name." runat="server"></asp:TextBox>

                    </div>
                    <div class="form-group col-md-12">
                        <asp:TextBox ID="txtemail" Height="40px" Width="100%" type="email" name="email" class="form-control" required="required" placeholder="E-Mail Id" runat="server"></asp:TextBox>

                    </div>
                    <div class="form-group col-md-12">
                        <asp:TextBox ID="txtadd1" Height="40px" Width="100%" type="name" name="name" class="form-control" required="required" placeholder="Address." runat="server"></asp:TextBox>

                    </div>
                    <div class="form-group col-md-12">
                        <asp:TextBox ID="txtcontact" Height="40px" Width="100%" type="name" name="name" class="form-control" required="required" placeholder="Contact No." runat="server"></asp:TextBox>
                        <br />
                    </div>
                    
                    <div>
                        <hr />
                        <h4>Customization Details:-</h4>
                        <hr />
                    </div>
                    <br />
                    <div>
                         <center><h4>LAYERS:-</h4></center>
                    </div>
                    <div class="container">
                        <div class="col-md-3">
                            <asp:RadioButton ID="single" GroupName="layer" runat="server" Text="Single Side" /></div>
                        <div class="col-md-3">
                        <asp:RadioButton ID="double1" GroupName="layer" runat="server" Text="Double Side(PTH & Non PTH)" /></div>
                    </div>
                    <div>
                        <center> <h4>SOURCE:-</h4></center>
                        
                    </div>
                     <div class="container">
                         <div class="col-md-3">
                            <asp:RadioButton ID="schematic" GroupName="source" runat="server" Text="Design From Schematic" /></div>
                         <div class="col-md-2">
                        <asp:RadioButton ID="replicate" GroupName="source" runat="server" Text="Replicate PCB" /><br /></div>
                            <div class="col-md-2"><asp:RadioButton ID="both" GroupName="source" runat="server" Text="Both" /></div>
                    </div>
                    
                    <div class="form-group col-md-12">
                        <asp:TextBox ID="txtsize" Height="40px" Width="100%" type="name" name="name" class="form-control" placeholder="Size." runat="server"></asp:TextBox>

                    </div>
                    <div class="form-group col-md-12">
                        <asp:TextBox ID="txtdesc" Height="40px" Width="100%" type="name" name="name" class="form-control" placeholder="Other Description." runat="server"></asp:TextBox>
                    <hr />
                    </div>
                    
                    <div>
                         <h4>Attach Zip File:-</h4>
                        <hr />
                        <center><asp:FileUpload ID="FileUpload1" runat="server" /></center>
                        <hr />
                    </div>

                    <div class="form-group">
                        <center>
                     <asp:Button ID="submit"   Height="40px" type="submit" name="submit" class="btn btn-primary" OnClick="submit_Click" runat="server" Text="Get Quotation" />
				                 </center>
                    </div>

                </form>
            </div>

        </div>
        <div class="col-sm-3">
        </div>
    </div>
    <hr />
    <div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
</asp:Content>

