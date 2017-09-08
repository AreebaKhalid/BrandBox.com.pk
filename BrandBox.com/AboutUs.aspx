<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="BrandBox.com.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link rel="stylesheet" type="text/css" href="css/AboutUs.css">
    <link href="https://fonts.googleapis.com/css?family=Josefin+Sans:300,400,700&subset=latin-ext" rel="stylesheet">
    
    <link rel="stylesheet" type="text/css" href="css/LatestProductCarousel.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<!-- Carousel -->
  <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner">

      <div class="item active">
        <img src="images\coverImages\4.jpg" style="width:100%;">
        <div class="carousel-caption">
          <h3 class="wow bounceInLeft"><b>Brand Box</b></h3>
          <p class="wow bounceInRight">Where you find all the brands !</p>
          <asp:LinkButton runat="server" type="button" CssClass="btn btnCustom wow fadeInUp" data-wow-delay="0.8s" OnClick="Shop_Now">Shop Now</asp:LinkButton>
        </div>
      </div>

      <div class="item">
        <img src="images\coverImages\1.jpg"  style="width:100%;">
        <div class="carousel-caption">
          <h3 class="wow bounceInLeft" data-wow-delay="0.8s"><b>BrandBox</b></h3>
          <p class="wow bounceInRight" data-wow-delay="0.8s">Because every month deserve to be awsimely styled!<br>Want to add your brand for maximum benefit!</p>
            <asp:LinkButton runat="server" CssClass="btn btnCustom wow fadeInUp"  data-wow-delay="0.8s" OnClick="Signup_Now" Text="Sign Up Now" />
        
        </div>
      </div>
    
      <div class="item">
        <img src="images\coverImages\7.jpg" style="width:100%;">
        <div class="carousel-caption">
          <h3 class="wow bounceInLeft" data-wow-delay="0.8s"><b>BrandBox</b></h3>
          <p class="wow bounceInRight" data-wow-delay="0.8s">Popular Brands are here!</p>
          <asp:LinkButton runat="server" type="button" class="btn btnCustom wow fadeInUp" data-wow-delay="0.8s" OnClick="Shop_Now">Shop Now</asp:LinkButton>
        </div>
      </div>
  
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <i class="fa fa-angle-left" aria-hidden="true"></i>
    </a>
    
  

   <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
    <i class="fa fa-angle-right" aria-hidden="true"></i>
    </a>

</div>
<!--End Carousel-->



<!--reviews -->
<div class="container reviews">
<h2>What our customers say</h2>
  <div  class="carousel slide text-center" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators indicatorsCus">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
      <li data-target="#myCarousel" data-slide-to="3"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner" role="listbox">
      <div class="item active">
        <h4>"One of the best websites to shop online. Simple and easy to use!!"<br><span> Sarah Khan ,Karachi</span></h4>
      </div>
      <div class="item">
        <h4>"Offers best dresses within budget. "<br><span>Sheryar Ali,Lahore.</span></h4>
      </div>
      <div class="item">
        <h4>"Every dress I bought from BrandBox is of expected quality. love them!"<br><span>Beenish,Peshawar</span></h4>
      </div>
      <div class="item">
        <h4>"Just received my shoes, and they are perfectly amazing. Will definitely shop again and also recommend to other."<br><span>KHANSA RIAZ</span></h4>
      </div>
    </div>
    </div>
  </div>
<!--End Reviews-->
<hr>
    
<!--Item slider text-->
    <div class="container-fluid" style="background-color:	#606060; margin:0">
<div class="container"style="margin-top:30px;"">
  <div class="row" id="slider-text">
    <div class="col-md-6" >
      <h2 style="color:#fff;">NEW COLLECTION</h2>
    </div>
  </div>
</div>

<!-- Item slider-->
<div class="container-fluid" style="margin:30px 0; background-color:	#606060">

  <div class="row">
    <div class="col-xs-12 col-sm-12 col-md-12">
      <div class="carousel carousel-showmanymoveone slide" id="itemslider">
        <div class="carousel-inner">
            <asp:Repeater runat="server" ID="newproductsRptr">
                <ItemTemplate>
                  <div class="item active">
                    <div class="col-xs-12 col-sm-6 col-md-2">
                      <a href="#">
                      <a href="ViewProduct.aspx?ProductCode=<%# Eval("ProductCode") %>"><asp:Image ID="Image1" runat="server"  CssClass="img-responsive center-block" width="150px" Height="200px" ImageUrl='<%#BrandBox.com.Accessible.GetImage(Eval("ImageData")) %>' /></a>
                      <h4 style="color:#fff;" class="text-center"><%#Eval("ProductName") %></h4>
                      <h5 style="color:#fff;" class="text-center"><%#Eval("ProductPrice") %>PKR</h5>
                    </div>
                  </div>
                 </ItemTemplate>
                </asp:Repeater>
        </div>
      </div>
    </div>
  </div>
</div>
        </div>
    <hr />
<!-- Item slider end-->
<!--Brands-->
    
            
<div id="brands" class="brands">
  <div class="container">
    <div class="row">
        <h2 class="wow fadeInUp">Our popular brands</h2>
        <asp:Repeater ID="BrandRptr" runat="server">
                <HeaderTemplate>
                   
                        
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-lg-4 col-md-4 wow fadeInLeft" data-wow-delay="2s">
                   <li>
                   <asp:Image runat="server" alt="image" height="150" width="150" style="border:5px solid black" ImageUrl='<%# BrandBox.com.Accessible.GetImage(Eval("ImageData")) %>' /> 
                   </li>
                     </div>
                </ItemTemplate>
                <FooterTemplate>
                   
                </FooterTemplate>
            </asp:Repeater>
      
     
      
      
    </div>
  </div>
</div>

<!--End Brands-->
    <br />









<!--Who we are-->
<div id="brandbox" class="brandbox">
  <div class="container">
    <div class="row">
     <h2 class="wow fadeInUp">Who we are</h2>
    <p class="wow fadeInUp">BrandBox, as the name suggests is an online shopping platform which
        let customers to buy dresses of all the age groups and genders from various popular brands 
        available across the country from home making shopping an easy and relaxing experience.
        Along with this we offer brands to share their products on this website thus helping small
        and less popular brands to get noticed in the market. BrandBox privileges the personalization
        and security of its users above all. </p>
        
  </div>
</div>
</div>
<!--End who we are-->

<!--Tean Starts-->
<div id="team" class="team">
  <div class="container">
    <div class="row">
      <h2 class="wow fadeInUp">Meet our team</h2>
        <p class="wow fadeInUp" data-wow-delay="0.4s">We have some amazing and skillful developers who are always ready to give their best.</p>
        <div class="col-lg-2 col-md-2"> </div>
        <div class="col-lg-4 col-md-4 wow fadeInLeft" data-wow-delay="2s">
        <img src="images/teams/team-1.jpg" class="img-circle">
        <h4>Yamna Wasi</h4>
        <b>CEO</b><br />
        <a href="https://www.facebook.com/yamna.wasi?ref=br_rs"><i class="fa fa-facebook" aria-hidden="true"></i></a>
        <a href="https://pk.linkedin.com/in/yamna-wasi-36138ab7"><i class="fa fa-linkedin" aria-hidden="true"></i></a>
      </div>
      <div class="col-lg-4 col-md-64 wow fadeInLeft" data-wow-delay="1.6s">
        <img src="images/teams/team-2.jpg" class="img-circle">
        <h4>Areeba Khalid</h4>
        <b>Founder</b><br />
        <a href="https://www.facebook.com/syeda.khalid.7"><i class="fa fa-facebook" aria-hidden="true"></i></a>
        <a href="https://twitter.com/SyedaaAreeba"><i class="fa fa-twitter" aria-hidden="true"></i></a>
        <a href="https://www.linkedin.com/in/syeda-areeba-khalid-69aa09b7/"><i class="fa fa-linkedin" aria-hidden="true"></i></a>
      </div>
        <div class="col-lg-2 col-md-2"> </div>

    </div>
  </div>
</div>

<!-- End Team -->
             <!--footer -->
<div id="foter" class="footer">
  <div class="container">
    <div class="row">
      <div class="col-lg-4 col-md-4">
        <h4 class="wow fadeInUp">Contact Us</h4>
        <p>
          <i class="fa fa-home" aria-hidden="true"></i> BrandBox Pvt Ltd, 7th Floor, Shahnaz Arcade, Shaheed-e-Millat Road, Karachi, Pakistan
        </p>
        <p>
        <i class="fa fa-envelope" aria-hidden="true"></i> BrandBox.com.pk@gmail.com
        </p>
        <p>
          <i class="fa fa-phone" aria-hidden="true"></i> +92-21-111-143-327
        </p>
        <p>
          <a href="AboutUs.aspx" style="color:#cccccc"><i class="fa fa-globe" aria-hidden="true"></i> www.brandbox.com.pk</a>
        </p>
      </div>
      <div class="col-md-4 col-lg-4">
        <h4 class="wow fadeInUp">Cusomer Care</h4>
        <a  style="color:#cccccc" href="AllProducts.aspx"><p>Shop</p></a>
        <a  style="color:#cccccc" href="CustLogin.aspx"><p>My Account</p></a>
        <a  style="color:#cccccc" href="Cart.aspx"><p>Shopping Cart</p></a>
      </div>
       
       
        <div class="col-lg-4 col-md-4">
          <h4 class="wow fadeInUp">Stay in touch</h4>
          <a  style="color:#cccccc" href="https://www.facebook.com/BrandBox-1405840389514945"><i class="social fa fa-facebook" aria-hidden="true"></i></a>
          <a  style="color:#cccccc" href="https://twitter.com/BrandBoxDotCom"><i class="social fa fa-twitter" aria-hidden="true"></i>
          <a  style="color:#cccccc" href="http://github.com/areebakhalid/BrandBox.com.pk"><i class="social fa fa-github" aria-hidden="true"></i></a><br>
        </div>
    </div>
  </div>
</div>

<!--end footer-->
</asp:Content>
