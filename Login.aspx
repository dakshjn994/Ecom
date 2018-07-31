<%@ Page Title="Login" Language="C#" MasterPageFile="~/Mainmaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
  <div class="row">
	    			<div class="contact-form">
	    				<h2 class="title text-center">Login to your account</h2>
	    				<div class="status alert alert-success" style="display: none"></div>
				    	<form id="main-contact-form" class="contact-form row" name="contact-form" method="post">
				            
				            <div class="form-group"><center>
                                 <asp:TextBox ID="txtemail" Width="20%" type="email" name="email" class="form-control" required="required" placeholder="Email" runat="server"></asp:TextBox>
				                </center>
				            </div>
				             
				            <div class="form-group"><center>
                 <asp:TextBox ID="txtpswd" name="password"   required="required" class="form-control" Width="20%" TextMode="Password"   placeholder="Password"  runat="server"></asp:TextBox>
				              </center>
				            </div>  
                           <center> <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>&nbsp;Keep me signed in &nbsp;&nbsp;&nbsp;&nbsp;<a href="#">Forget Password?</a>    </center><br />
                            <center>New Customer?&nbsp;<a href="Registration.aspx">Start Here.</a>    </center>                 
				            <div class="form-group">
                                <center>
                     <asp:Button ID="Button1" OnClick="Button1_Click" class="btn btn-primary" runat="server" Text="Login" />
				                 </center>
				            </div>
				        </form>
	    			</div> 	
	    	</div>  
	 <hr />

</asp:Content>

