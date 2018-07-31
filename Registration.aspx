<%@ Page Title="Registration Form" Language="C#" EnableEventValidation="false" MasterPageFile="~/Mainmaster.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
    <div class="row">  
        <h2 class="title text-center">Registration Form</h2>	
       <div class="col-sm-3">
           </div>
	    		 <div class="col-sm-6">
	    			<div class="contact-form">
	    				
	    				<div class="status alert alert-success" style="display: none"></div>
				    	<form id="main-contact-form" class="contact-form row" name="contact-form" method="post">
				            
				            <div class="form-group col-md-4"> 
                                <asp:TextBox ID="txtfname" Height="40px" Width="100%"  type="name" name="name" class="form-control" required="required" placeholder="First Name" runat="server"></asp:TextBox>
                               </div>
                              <div class="form-group col-md-4"> 
                                 <asp:TextBox ID="txtmname" Height="40px"   Width="100%"  type="name" name="name" class="form-control"   placeholder="Middle Name" runat="server"></asp:TextBox>
                                   </div>
                                    <div class="form-group col-md-4"> 
                                 <asp:TextBox ID="txtlname" Height="40px" Width="100%"  type="name" name="name" class="form-control" required="required" placeholder="Last Name" runat="server"></asp:TextBox>
				                  </div>

                            <div class="form-group col-md-12">  
                                <asp:TextBox ID="txtemail"  Height="40px" Width="100%" type="email" name="email" class="form-control" required="required" placeholder="E-Mail Id" runat="server"></asp:TextBox>
                                
                                </div>
                             <div class="form-group col-md-12">  
                                <asp:TextBox ID="txtadd1" Height="40px"  Width="100%" type="name" name="name" class="form-control" required="required" placeholder="Address Line 1" runat="server"></asp:TextBox>
                                
                                </div>

                             <div class="form-group col-md-4">  
                                 <asp:TextBox ID="txtcountry" Height="40px"  Width="100%" type="name" name="name" class="form-control" required="required" Text="India" Enabled="false" runat="server"></asp:TextBox>
                                
                                </div>
                            <div class="form-group col-md-4">  
                                 <asp:TextBox ID="txtstate" Height="40px"  Width="100%" type="name" name="name" class="form-control" required="required" Text="Maharashtra" Enabled="false" runat="server"></asp:TextBox>
                                
                                </div>
                            <div class="form-group col-md-4">  
                                <asp:DropDownList ID="ddltown" Height="40px"  Width="100%" type="name" name="name" class="form-control" required="required" runat="server">
                                    <asp:ListItem Text="Mumbai">Mumbai</asp:ListItem>
                                    <asp:ListItem Text="Pune">Pune</asp:ListItem>
                                    <asp:ListItem Text="Nagpur">Nagpur</asp:ListItem>
                                </asp:DropDownList>
                                </div>
                            <div class="form-group col-md-12">  
                                <asp:TextBox ID="txtpin" placeholder="Pin" Height="40px"  Width="100%" type="name" name="name" class="form-control" required="required" runat="server"></asp:TextBox>
                                
                                </div>
                            <div class="form-group col-md-12">  
                                <asp:TextBox ID="txtcontact" Height="40px"  Width="100%" type="name" name="name" class="form-control" required="required" placeholder="Contact No." runat="server"></asp:TextBox>
                                
                                </div>
                            <div class="form-group col-md-6">  
                                <asp:TextBox ID="txtpswd" Height="40px"  Width="100%" type="name" name="name" class="form-control" required="required" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                                
                                </div>
				            
                            <div class="form-group col-md-6">  
                                <asp:TextBox ID="txtrpswd" Height="40px"  Width="100%" type="name" name="name" class="form-control" required="required" placeholder="Retype Password" TextMode="Password" runat="server"></asp:TextBox>
                                
                                </div>
				             
				              
                           <center> <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>&nbsp; *I accept the Terms and Conditions. 
 </center> 
                                           
				            <div class="form-group">
                                <center>
                     <asp:Button ID="Button1" OnClick="Button1_Click" Height="40px" type="submit" name="submit" class="btn btn-primary" runat="server" Text="Go Ahead" />
				                 </center>
				            </div>
				        </form>
	    			</div>
	    		 </div>
	    		 	<div class="col-sm-3">
           </div> 	
	    	</div>  
		 


    <hr />

</asp:Content>

