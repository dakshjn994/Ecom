<%@ Page Title="Shop" Language="C#" MasterPageFile="~/Mainmaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Index.aspx.cs" Inherits="Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
   		 <!-- Use a container to wrap the slider, the purpose is to enable slider to always fit width of the wrapper while window resize -->
    <div class="container">
        <!-- Jssor Slider Begin -->
        <!-- To move inline styles to css file/block, please specify a class name for each element. --> 
        <!-- ================================================== -->
        <div id="slider1_container" style="visibility: hidden; position: relative; margin: 0 auto; width: 1140px; height: 442px; overflow: hidden;">

            <!-- Loading Screen -->
            <div u="loading" style="position: absolute; top: 0px; left: 0px;">
                <div style="filter: alpha(opacity=70); opacity:0.7; position: absolute; display: block;

                background-color: #000; top: 0px; left: 0px;width: 100%; height:100%;">
                </div>
                <div style="position: absolute; display: block; background: url(../img/loading.gif) no-repeat center center;

                top: 0px; left: 0px;width: 100%;height:100%;">
                </div>
            </div>

            <!-- Slides Container -->
            <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1140px; height: 442px;
            overflow: hidden;">
                <div>
                    <img u="image" src2="../img/home/001.jpg" />
                </div>
                <div>
                    <img u="image" src2="../img/home/002.jpg" />
                </div>
                <div>
                    <img u="image" src2="../img/home/003.png" />
                </div>
                <div>
                    <img u="image" src2="../img/home/004.jpg" />
                </div>
                 <div>
                    <img u="image" src2="../img/home/005.gif" />
                </div>
            </div>
            
            <!--#region Bullet Navigator Skin Begin -->
            <!-- Help: http://www.jssor.com/tutorial/set-bullet-navigator.html -->
            <style>
                /* jssor slider bullet navigator skin 05 css */
                /*
                .jssorb05 div           (normal)
                .jssorb05 div:hover     (normal mouseover)
                .jssorb05 .av           (active)
                .jssorb05 .av:hover     (active mouseover)
                .jssorb05 .dn           (mousedown)
                */
                .jssorb05 {
                    position: absolute;
                }
                .jssorb05 div, .jssorb05 div:hover, .jssorb05 .av {
                    position: absolute;
                    /* size of bullet elment */
                    width: 16px;
                    height: 16px;
                    background: url(../img/b05.png) no-repeat;
                    overflow: hidden;
                    cursor: pointer;
                }
                .jssorb05 div { background-position: -7px -7px; }
                .jssorb05 div:hover, .jssorb05 .av:hover { background-position: -37px -7px; }
                .jssorb05 .av { background-position: -67px -7px; }
                .jssorb05 .dn, .jssorb05 .dn:hover { background-position: -97px -7px; }
            </style>
            <!-- bullet navigator container -->
            <div u="navigator" class="jssorb05" style="bottom: 16px; right: 6px;">
                <!-- bullet navigator item prototype -->
                <div u="prototype"></div>
            </div>
            <!--#endregion Bullet Navigator Skin End -->
            
            <!--#region Arrow Navigator Skin Begin -->
            <!-- Help: http://www.jssor.com/tutorial/set-arrow-navigator.html -->
            <style>
                /* jssor slider arrow navigator skin 11 css */
                /*
                .jssora11l                  (normal)
                .jssora11r                  (normal)
                .jssora11l:hover            (normal mouseover)
                .jssora11r:hover            (normal mouseover)
                .jssora11l.jssora11ldn      (mousedown)
                .jssora11r.jssora11rdn      (mousedown)
                */
                .jssora11l, .jssora11r {
                    display: block;
                    position: absolute;
                    /* size of arrow element */
                    width: 37px;
                    height: 37px;
                    cursor: pointer;
                    background: url(../img/a11.png) no-repeat;
                    overflow: hidden;
                }
                .jssora11l { background-position: -11px -41px; }
                .jssora11r { background-position: -71px -41px; }
                .jssora11l:hover { background-position: -131px -41px; }
                .jssora11r:hover { background-position: -191px -41px; }
                .jssora11l.jssora11ldn { background-position: -251px -41px; }
                .jssora11r.jssora11rdn { background-position: -311px -41px; }
            </style>
            <!-- Arrow Left -->
            <span u="arrowleft" class="jssora11l" style="top: 123px; left: 8px;">
            </span>
            <!-- Arrow Right -->
            <span u="arrowright" class="jssora11r" style="top: 123px; right: 8px;">
            </span>
            <!--#endregion Arrow Navigator Skin End -->
            <a style="display: none" href="http://www.jssor.com">Bootstrap Carousel</a>
        </div>
        <!-- Jssor Slider End -->
    </div>

   

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="../js/jquery-1.9.1.min.js"></script>
    <script src="bootstrap.min.js"></script>
    <script src="docs.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="ie10-viewport-bug-workaround.js"></script>

    <!-- jssor slider scripts-->
    <!-- use jssor.slider.debug.js for debug -->
    <script type="text/javascript" src="../js/jssor.slider.mini.js"></script>
    <script>

        jQuery(document).ready(function ($) {
            var options = {
                $AutoPlay: true,                                    //[Optional] Whether to auto play, to enable slideshow, this option must be set to true, default value is false
                $AutoPlaySteps: 1,                                  //[Optional] Steps to go for each navigation request (this options applys only when slideshow disabled), the default value is 1
                $Idle: 2000,                            //[Optional] Interval (in milliseconds) to go for next slide since the previous stopped if the slider is auto playing, default value is 3000
                $PauseOnHover: 1,                                   //[Optional] Whether to pause when mouse over if a slider is auto playing, 0 no pause, 1 pause for desktop, 2 pause for touch device, 3 pause for desktop and touch device, 4 freeze for desktop, 8 freeze for touch device, 12 freeze for desktop and touch device, default value is 1

                $ArrowKeyNavigation: true,   			            //[Optional] Allows keyboard (arrow key) navigation or not, default value is false
                $SlideEasing: $JssorEasing$.$EaseOutQuint,          //[Optional] Specifies easing for right to left animation, default value is $JssorEasing$.$EaseOutQuad
                $SlideDuration: 800,                                //[Optional] Specifies default duration (swipe) for slide in milliseconds, default value is 500
                $MinDragOffsetToSlide: 20,                          //[Optional] Minimum drag offset to trigger slide , default value is 20
                //$SlideWidth: 600,                                 //[Optional] Width of every slide in pixels, default value is width of 'slides' container
                //$SlideHeight: 300,                                //[Optional] Height of every slide in pixels, default value is height of 'slides' container
                $SlideSpacing: 0, 					                //[Optional] Space between each slide in pixels, default value is 0
                $Cols: 1,                                  //[Optional] Number of pieces to display (the slideshow would be disabled if the value is set to greater than 1), the default value is 1
                $ParkingPosition: 0,                                //[Optional] The offset position to park slide (this options applys only when slideshow disabled), default value is 0.
                $UISearchMode: 1,                                   //[Optional] The way (0 parellel, 1 recursive, default value is 1) to search UI components (slides container, loading screen, navigator container, arrow navigator container, thumbnail navigator container etc).
                $PlayOrientation: 1,                                //[Optional] Orientation to play slide (for auto play, navigation), 1 horizental, 2 vertical, 5 horizental reverse, 6 vertical reverse, default value is 1
                $DragOrientation: 1,                                //[Optional] Orientation to drag slide, 0 no drag, 1 horizental, 2 vertical, 3 either, default value is 1 (Note that the $DragOrientation should be the same as $PlayOrientation when $Cols is greater than 1, or parking position is not 0)

                $ArrowNavigatorOptions: {                           //[Optional] Options to specify and enable arrow navigator or not
                    $Class: $JssorArrowNavigator$,                  //[Requried] Class to create arrow navigator instance
                    $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                    $AutoCenter: 2,                                 //[Optional] Auto center arrows in parent container, 0 No, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                    $Steps: 1,                                      //[Optional] Steps to go for each navigation request, default value is 1
                    $Scale: false                                   //Scales bullets navigator or not while slider scale
                },

                $BulletNavigatorOptions: {                                //[Optional] Options to specify and enable navigator or not
                    $Class: $JssorBulletNavigator$,                       //[Required] Class to create navigator instance
                    $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                    $AutoCenter: 1,                                 //[Optional] Auto center navigator in parent container, 0 None, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                    $Steps: 1,                                      //[Optional] Steps to go for each navigation request, default value is 1
                    $Rows: 1,                                      //[Optional] Specify lanes to arrange items, default value is 1
                    $SpacingX: 12,                                   //[Optional] Horizontal space between each item in pixel, default value is 0
                    $SpacingY: 4,                                   //[Optional] Vertical space between each item in pixel, default value is 0
                    $Orientation: 1,                                //[Optional] The orientation of the navigator, 1 horizontal, 2 vertical, default value is 1
                    $Scale: false                                   //Scales bullets navigator or not while slider scale
                }
            };

            var jssor_slider1 = new $JssorSlider$("slider1_container", options);

            //responsive code begin
            //you can remove responsive code if you don't want the slider scales while window resizing
            function ScaleSlider() {
                var parentWidth = jssor_slider1.$Elmt.parentNode.clientWidth;
                if (parentWidth) {
                    jssor_slider1.$ScaleWidth(parentWidth - 30);
                }
                else
                    window.setTimeout(ScaleSlider, 30);
            }
            ScaleSlider();

            $(window).bind("load", ScaleSlider);
            $(window).bind("resize", ScaleSlider);
            $(window).bind("orientationchange", ScaleSlider);
            //responsive code end
        });
    </script>
    <BR /><BR />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<section>
		<div class="container">
			<div class="row" >
				<div class="col-sm-3" style="background-color:#005580;" >
                    <div class="left-sidebar" style="background-color:#005580;">
						 <ul><li style="background-color:#005580;color:#ffffff;font-size:large;margin-left:20%">Category</li></ul>
                            <div class="panel-group category-products" id="accordian" >
                            <div class="panel panel-default" style="background-color:#005580;">
        <asp:DataList ID="outerDataList" runat="server" OnItemDataBound="outerDataList_ItemDataBound" >
                <ItemTemplate>
             <div class="panel-heading" style="background-color:#005580;">
									<h4 class="panel-title">
										<a data-toggle="collapse" data-parent="#accordian" style="color:#ffffff;" href='#<%#Eval("Category_Id")%>'>
											<span class="badge pull-right"><i  style="color:aliceblue;" class="fa fa-plus"></i></span><%#Eval("Category_Name")%></a>
									</h4>
								</div>
                        <div id='<%#Eval("Category_Id") %>' class="panel-collapse collapse">
									<div class="panel-body">
										<ul>
                        <asp:DataList ID="innerDataList" runat="server">
                            <ItemTemplate>
                                <li><a style="color:#ffffff;" href='Index.aspx?UId=<%#Eval("Sub_Category_Id")%>&UName=<%#Eval("Sub_Category_Name")%>'><%#Eval("Sub_Category_Name")%></a></li>
                            </ItemTemplate>
                        </asp:DataList>
                        </ul>
									</div>
								</div>
                </ItemTemplate>
            </asp:DataList>
                                <asp:DataList ID="DataList1" runat="server">
                                    <ItemTemplate>
                                        <div class="panel panel-default" >
								<div class="panel-heading"  style="background-color:#005580;">
									<h4 class="panel-title"><a style="color:#ffffff;" href='index.aspx?Id=<%#Eval("Category_Id")%>&Name=<%#Eval("Category_Name")%>'><%#Eval("Category_Name")%></a></h4>
								</div>
							</div>
                                    </ItemTemplate>
                                </asp:DataList>
            </div>
            </div>
	     	</div>
                    </div>
    <div class="col-sm-9">
					<div class="features_items">
						<h2 id="Typepro" runat="server" class="title text-center">Featured Items</h2>
						<asp:DataList ID="DataList2" RepeatColumns="2" RepeatDirection="Horizontal" runat="server">
                           <ItemTemplate>
                        <div>
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
                                        <br />
                                        <p class="col-sm-12">
                                            <p class="col-md-6">
                                        <a href='Details.aspx?Id=<%#Eval("Item_Id")%>'>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image")%>' Height="156px" Width="100%" /></p><br /><br />
										
                                            <p class="col-md-6"><p> <strike>₹<%#Eval("MRP")%></strike>&nbsp;₹<%#Eval("SalePrice")%></p>
										<p><%#Eval("Item_Name")%></p>
                                            </a>
                                        <a class="btn btn-default add-to-cart" href='Details.aspx?Id=<%#Eval("Item_Id")%>'><b class="fa fa-eye"></b> View</a>
                                            </p>
                                            </p>
									</div>
                                    <div class="product-overlay" style="width:100%;">
										<div class="overlay-content">
                                            <br />
                                            <p class="col-sm-12">
                                                <p class="col-md-6">
                                            <a href='Details.aspx?Id=<%#Eval("Item_Id")%>'>
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("Image")%>' Height="156px" Width="100%" /></p><br /><br />
                                                <p class="col-md-6">
											<p> <strike>₹<%#Eval("MRP")%></strike>&nbsp;₹<%#Eval("SalePrice")%></p>
											<p><%#Eval("Item_Name")%></p></a>
                                            <a class="btn btn-default add-to-cart" href='Details.aspx?Id=<%#Eval("Item_Id")%>'><b class="fa fa-eye"></b> View</a>
                                                </p>
                                                </p>
										</div>
									</div>
                                    </div>
                                <div class="choose">
									<ul class="nav nav-pills nav-justified">
										<li><a href=""><i class="fa fa-plus-square"></i>Add to Wishlist&nbsp;</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to Compare</a></li>
									</ul>
								</div>
							</div>
						</div>
                               </ItemTemplate>
                            </asp:DataList>
                        <h5 id="Pro" runat="server" visible="false"></h5>
                        </div>
        <center><asp:Button ID="btnfirst" CssClass="btn btn-default" OnClick="btnfirst_Click" runat="server" Text="<<" />&nbsp;&nbsp;<asp:Button ID="btnprevious" OnClick="btnprevious_Click" CssClass="btn btn-default" runat="server" Text="Previous" />&nbsp;&nbsp;<asp:Button ID="btnnext" CssClass="btn btn-default" OnClick="btnnext_Click" runat="server" Text="Next" />&nbsp;&nbsp;<asp:Button ID="btnlast" CssClass="btn btn-default" OnClick="btnlast_Click" runat="server" Text=">>" /></center>
            <div class="features_items" id="fea" runat="server">
						<h2 id="H1" runat="server" class="title text-center">Featured Items</h2>
                <div class="col-md-1"><a id="btnPrevious1" runat="server" onserverclick="btnPrevious1_Click"><i class="fa fa-chevron-circle-left fa-3x"  style="height:100%;width:100%;"></i></a></div>
                <div class="col-md-10">
						<asp:DataList ID="DataList3" RepeatColumns="2" RepeatDirection="Horizontal" runat="server">
                           <ItemTemplate>
                        <div>
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
                                        <br />
                                        <p class="col-sm-12">
                                            <p class="col-md-6">
                                        <a href='Details.aspx?Id=<%#Eval("Item_Id")%>'>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image")%>' Height="156px" Width="100%" /></p><br /><br />
										
                                            <p class="col-md-6"><p> <strike>₹<%#Eval("MRP")%></strike>&nbsp;₹<%#Eval("SalePrice")%></p>
										<p><%#Eval("Item_Name")%></p>
                                            </a>
                                        <a class="btn btn-default add-to-cart" href='Details.aspx?Id=<%#Eval("Item_Id")%>'><b class="fa fa-eye"></b> View</a>
                                            </p>
                                            </p>
									</div>
                                    <div class="product-overlay" style="width:100%;">
										<div class="overlay-content">
                                            <br />
                                            <p class="col-sm-12">
                                                <p class="col-md-6">
                                            <a href='Details.aspx?Id=<%#Eval("Item_Id")%>'>
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("Image")%>' Height="156px" Width="100%" /></p><br /><br />
                                                <p class="col-md-6">
											<p> <strike>₹<%#Eval("MRP")%></strike>&nbsp;₹<%#Eval("SalePrice")%></p>
											<p><%#Eval("Item_Name")%></p></a>
                                            <a class="btn btn-default add-to-cart" href='Details.aspx?Id=<%#Eval("Item_Id")%>'><b class="fa fa-eye"></b> View</a>
                                                </p>
                                                </p>
										</div>
									</div>
                                    </div>
                                <div class="choose">
									<ul class="nav nav-pills nav-justified">
										<li><a href=""><i class="fa fa-plus-square"></i>Add to Wishlist&nbsp;</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to Compare</a></li>
									</ul>
								</div>
							</div>
						</div>
                               </ItemTemplate>
                            </asp:DataList>
                </div>
                <div class="col-md-1"><a id="btnNext1" runat="server" onserverclick="btnNext1_Click"><i class="fa fa-chevron-circle-right fa-3x"></i></a></div>
                </div>
        <div class="features_items" id="sal" runat="server">
						<h2 id="H2" runat="server" class="title text-center">Sale Items</h2>
                <div class="col-md-1"><a id="btnPrevious2" runat="server" onserverclick="btnPrevious2_ServerClick"><i class="fa fa-chevron-circle-left fa-3x"  style="height:100%;width:100%;"></i></a></div>
                <div class="col-md-10">
						<asp:DataList ID="DataList4" RepeatColumns="2" RepeatDirection="Horizontal" runat="server">
                           <ItemTemplate>
                        <div>
							<div class="product-image-wrapper">
								<div class="single-products">
									<div class="productinfo text-center">
                                        <br />
                                        <p class="col-sm-12">
                                            <p class="col-md-6">
                                        <a href='Details.aspx?Id=<%#Eval("Item_Id")%>'>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Image")%>' Height="156px" Width="100%" /></p><br /><br />
										
                                            <p class="col-md-6"><p> <strike>₹<%#Eval("MRP")%></strike>&nbsp;₹<%#Eval("SalePrice")%></p>
										<p><%#Eval("Item_Name")%></p>
                                            </a>
                                        <a class="btn btn-default add-to-cart" href='Details.aspx?Id=<%#Eval("Item_Id")%>'><b class="fa fa-eye"></b> View</a>
                                            </p>
                                            </p>
									</div>
                                    <div class="product-overlay" style="width:100%;">
										<div class="overlay-content">
                                            <br />
                                            <p class="col-sm-12">
                                                <p class="col-md-6">
                                            <a href='Details.aspx?Id=<%#Eval("Item_Id")%>'>
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("Image")%>' Height="156px" Width="100%" /></p><br /><br />
                                                <p class="col-md-6">
											<p> <strike>₹<%#Eval("MRP")%></strike>&nbsp;₹<%#Eval("SalePrice")%></p>
											<p><%#Eval("Item_Name")%></p></a>
                                            <a class="btn btn-default add-to-cart" href='Details.aspx?Id=<%#Eval("Item_Id")%>'><b class="fa fa-eye"></b> View</a>
                                                </p>
                                                </p>
										</div>
									</div>
                                    <img src="images/home/sale.png" class="new" alt="" />
                                    </div>
                                <div class="choose">
									<ul class="nav nav-pills nav-justified">
										<li><a href=""><i class="fa fa-plus-square"></i>Add to Wishlist&nbsp;</a></li>
										<li><a href=""><i class="fa fa-plus-square"></i>Add to Compare</a></li>
									</ul>
								</div>
							</div>
						</div>
                               </ItemTemplate>
                            </asp:DataList>
                </div>
                <div class="col-md-1"><a id="btnNext2" runat="server" onserverclick="btnNext2_ServerClick"><i class="fa fa-chevron-circle-right fa-3x"></i></a></div>
                </div>
        </div>
       </div>
            </div>
     </section>
    <br /><br />
            </ContentTemplate>
            </asp:UpdatePanel>
    
</asp:Content>