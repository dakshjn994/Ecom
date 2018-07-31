<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Mainmaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Contact_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
     <div id="contact-page" class="container">
    	<div class="bg">
           
	    	<div class="row">    		
	    		<div class="col-sm-12">    			   			
					<h2 class="title text-center">Contact <strong>Us</strong></h2>    			    				    				
					<div id="gmap" class="contact-map">
                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d396.0626049857935!2d72.84850783910962!3d19.1950388796399!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3be7b6e0f90b028d%3A0xfc694127a35031a4!2sBhadran+Nagar+Rd+Number+2%2C+Mahavir+Nagar%2C+Malad+West%2C+Mumbai%2C+Maharashtra+400064!5e0!3m2!1sen!2sin!4v1484813268757" width="100%" height="100%" frameborder="0" style="border:0" allowfullscreen></iframe>  
					</div>
				</div>			 		
			</div> 
              	
    		<div class="row">  	
	    		<div class="col-sm-8">
	    			<div class="contact-form">
	    				<h2 class="title text-center">Get In Touch</h2>
	    				<div class="status alert alert-success" style="display: none"></div>
				    	<form id="main-contact-form" class="contact-form row" name="contact-form" method="post">
				            <div class="form-group col-md-6">
				                  
         <asp:TextBox ID="txtname" type="text" name="name" class="form-control" required="required" placeholder="Name" runat="server"></asp:TextBox>
				            </div>
				            <div class="form-group col-md-6">
                                 <asp:TextBox ID="txtemail" type="email" name="email" class="form-control" required="required" placeholder="Email" runat="server"></asp:TextBox>
				            </div>
				            <div class="form-group col-md-12">
             <asp:TextBox ID="TextBox2" type="txtsub" name="subject" class="form-control" required="required" placeholder="Subject"  runat="server"></asp:TextBox>
				            </div>
				            <div class="form-group col-md-12">
                 <asp:TextBox ID="txtmsg" name="message"   required="required" class="form-control" TextMode="MultiLine" Rows="8" Height="20%" placeholder="Your Message Here"  runat="server"></asp:TextBox>
				            </div>                        
				            <div class="form-group col-md-12">
                                <center><asp:Button ID="Button1" OnClick="Button1_Click" runat="server" class="btn btn-primary right" Text="Clear" />
                                <asp:Button ID="submit" OnClick="submit_Click" runat="server" type="submit" name="submit" class="btn btn-primary right" value="Submit" Text="Submit" /></center>
				            </div>
				        </form>
	    			</div>
	    		</div>
	    		<div class="col-sm-4">
	    			<div class="contact-info">
	    				<h2 class="title text-center">Contact Info</h2>
	    				<address>
	    					<p>Digitronicarts</p>
							<p>02,Madrasi chawl,Behind Vrajesh Apartment</p>
							<p>Rd no. 02 Bhadran Nagar, Malad West </p>
                            <p>Mumbai 400064</p>
							<p>Mobile: +91 8286 22 3864</p>
							<p>WhatsApp: +91 8286 22 3864</p>
							<p>Email: digitronicarts@gmail.com</p>
	    				</address>
	    				<div class="social-networks">
	    					<h2 class="title text-center">Social Networking</h2>
							<ul>
								<li>
									<a href="#"><i class="fa fa-facebook"></i></a>
								</li>
								<li>
									<a href="#"><i class="fa fa-twitter"></i></a>
								</li>
								<li>
									<a href="#"><i class="fa fa-google-plus"></i></a>
								</li>
								<li>
									<a href="#"><i class="fa fa-youtube"></i></a>
								</li>
							</ul>
	    				</div>
	    			</div>
    			</div>    			
	    	</div>  
    	</div>	
         <hr />
    </div><!--/#contact-page-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
</asp:Content>