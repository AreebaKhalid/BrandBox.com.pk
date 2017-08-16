<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="BrandBox.com.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <img src="images\coverImages\1.jpg" style="width:100%;">
        <div class="carousel-caption">
          <h3 class="wow bounceInLeft"><b>Brand Box</b></h3>
          <p class="wow bounceInRight">Where you find all the brands !</p>
          <button type="button" class="btn btnCustom wow fadeInUp">Shop Now</button>
        </div>
      </div>

      <div class="item">
        <img src="images\coverImages\4.jpg"  style="width:100%;">
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
          <button type="button" class="btn btnCustom wow fadeInUp" data-wow-delay="0.8s">Shop Now</button>
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


<!--New items-->
  
<!--End ctNew items-->

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
                   <asp:Image runat="server" alt="image" height="200" width="300" style="border:5px solid black" ImageUrl='<%# BrandBox.com.Accessible.GetImage(Eval("ImageData")) %>' /> 
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
    <hr />
    <br />
<!--Featured Products-->
   <div class="container" width="90px" float="center">
        <p> Latest products here</p>


    </div>

    <hr />
<!--End featured products-->





<!--reviews -->
<div class="container reviews">
<h2>What our customers say</h2>
  <div id="myCarousel" class="carousel slide text-center" data-ride="carousel">
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
        <h4>"This company is the best. I am so happy with the result!"<br><span>Michael Roe, Vice President, Comment Box</span></h4>
      </div>
      <div class="item">
        <h4>"One word... WOW!!"<br><span>John Doe, Salesman, Rep Inc</span></h4>
      </div>
      <div class="item">
        <h4>"Could I... BE any more happy with this company?"<br><span>Chandler Bing, Actor, FriendsAlot</span></h4>
      </div>
      <div class="item">
        <h4>"Just received my shoes, and they are perfectly amazing. Will definitely shop again and also recommend to other."<br><span>KHANSA RIAZ</span></h4>
      </div>
    </div>
    </div>
  </div>
<!--End Reviews-->




<!--Who we are-->
<div id="brandbox" class="brandbox">
  <div class="container">
    <div class="row">
     <h2 class="wow fadeInUp">Who we are</h2>
    <p class="wow fadeInUp">ahha aha kosgde www d did s dsdsosoda jsuwqdiwu djoisq dauaudwa diud wwi wwiq wuw wuw wugebo eywbo fowtyyw wibcle wy whwi wjwwuwe eu qyui huj qgwh awoh hau uenn eheuenk anjq qnaj wuaan ajka dio siw  ixn sjs oepe </p>
        
  </div>
</div>
</div>
<!--End who we are-->

<!--Tean Starts-->
<div id="team" class="team">
  <div class="container">
    <div class="row">
      <h2 class="wow fadeInUp">Meet our team</h2>
      <p class="wow fadeInUp" data-wow-delay="0.4s">Lorem Ipsum passages, and more recently with desktop publishing software</p>
      <div class="col-lg-4 col-md-4 wow fadeInLeft" data-wow-delay="2s">
        <img src="images/teams/team-1.jpg" class="img-circle">
        <h4>John Doe</h4>
        <b>CEO and Founder</b>
        <p>Lorem Ipsum passages, and more recently with desktop publishing software</p>
        <a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a>
        <a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a>
        <a href="#"><i class="fa fa-linkedin" aria-hidden="true"></i></a>
        <a href="#"><i class="fa fa-pinterest" aria-hidden="true"></i></a>
      </div>
      <div class="col-lg-4 col-md-64 wow fadeInLeft" data-wow-delay="1.6s">
        <img src="images/teams/team-2.jpg" class="img-circle">
        <h4>John Doe</h4>
        <b>CEO and Founder</b>
        <p>Lorem Ipsum passages, and more recently with desktop publishing software</p>
        <a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a>
        <a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a>
        <a href="#"><i class="fa fa-linkedin" aria-hidden="true"></i></a>
        <a href="#"><i class="fa fa-pinterest" aria-hidden="true"></i></a>
      </div>
      <div class="col-lg-4 col-md-4 wow fadeInLeft" data-wow-delay="1.2s">
        <img src="images/teams/team-3.jpg" class="img-circle">
        <h4>John Doe</h4>
        <b>CEO and Founder</b>
        <p>Lorem Ipsum passages, and more recently with desktop publishing software</p>
        <a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a>
        <a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a>
        <a href="#"><i class="fa fa-linkedin" aria-hidden="true"></i></a>
        <a href="#"><i class="fa fa-pinterest" aria-hidden="true"></i></a>
      </div>
    </div>
  </div>
</div>

<!-- End Team -->
             <!--footer -->
<div id="footer" class="footer">
  <div class="container">
    <div class="row">
      <div class="col-lg-3 col-md-3">
        <h4 class="wow fadeInUp">Contact Us</h4>
        <p>
          <i class="fa fa-home" aria-hidden="true"></i>  111 Main Street, Washington DC, 222222
        </p>
        <p>
        <i class="fa fa-envelope" aria-hidden="true"></i> info@media.com
        </p>
        <p>
          <i class="fa fa-phone" aria-hidden="true"></i> +1 222 222 2222
        </p>
        <p>
          <i class="fa fa-globe" aria-hidden="true"></i> www.media.com
        </p>
      </div>
      <div class="col-md-3 col-lg-3">
        <h4 class="wow fadeInUp">Cusomer Care</h4>
        <p>Shop</p>
        <p>My Account</p>
        <p>Shopping Cart</p>
      </div>
       <div class="col-lg-3 col-md-3">
         <h4 class="wow fadeInUp">About</h4>
         <p>
           <i class="fa fa-square-o" aria-hidden="true"></i> About Us
         </p>
         <p>
           <i class="fa fa-square-o" aria-hidden="true"></i> Privacy
         </p>
         <p>
           <i class="fa fa-square-o" aria-hidden="true"></i> Term & Condition
         </p>
       </div>
       
        <div class="col-lg-3 col-md-3">
          <h4 class="wow fadeInUp">Stay in touch</h4>
          <i class="social fa fa-facebook" aria-hidden="true"></i>
          <i class="social fa fa-twitter" aria-hidden="true"></i>
          <i class="social fa fa-linkedin" aria-hidden="true"></i>
          <i class="social fa fa-pinterest" aria-hidden="true"></i>
          <i class="social fa fa-youtube" aria-hidden="true"></i>
          <i class="social fa fa-github" aria-hidden="true"></i><br>
        </div>
    </div>
  </div>
</div>

<!--end footer-->
</asp:Content>
