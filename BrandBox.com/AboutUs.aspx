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
          <button type="button" class="btn btnCustom wow fadeInUp" data-wow-delay="0.8s" >Sign Up</button>
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

<!--Featured Products-->



<!--End featured products-->



<!--Sign In-->


<div id="signup" class="signup">
  <div class="container">
    <div class="row">
     <h2 class="wow fadeInUp">Sign In</h2>
     <div class="col-lg-2 col-md-2"></div>
      <div class="col-lg-8 col-md-8">
        <div class="input-group input-group-lg wow fadeInUp" data-wow-delay="1.2s">
          <span class="input-group-addon" id="sizing-addon1"><i class="fa fa-envelope" aria-hidden="true"></i></span>
            <asp:textbox id="email" runat="server" class="form-control" placeholder="Email address" ></asp:textbox> 
        </div>
        <div class="input-group input-group-lg">
          <asp:RequiredFieldValidator runat="server" id="reqEmail" controltovalidate="email" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" ValidationGroup="Group1"/>
          <asp:RegularExpressionValidator id="validEmail" ControlToValidate="email" Text="Invalid email address." CssClass="errors" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Runat="server" Display="Dynamic" ValidationGroup="Group1"/>        
        </div>
        <div class="input-group input-group-lg wow fadeInUp" data-wow-delay="1.6s">
          <span class="input-group-addon" id="sizing-addon2"><i class="fa fa-key" aria-hidden="true"></i></span>
          <asp:TextBox ID="password" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>


         </div>
         <div class="input-group input-group-lg">
           <asp:RequiredFieldValidator runat="server" id="reqpass" controltovalidate="password" ValidationGroup="Group1" CssClass="errors" errormessage="Please enter password." Display="Dynamic" />
         </div>
         <div>

        <div class="form-group" style="clear: left">                       
           <asp:Label ID="lblError" runat="server" CssClass="errors"></asp:Label>
         </div>

        <div class="form-group">                   
           <asp:CheckBox ID="RememberMeCheckBox" CssClass="control-label wow fadeInUp" data-wow-delay="2.4s" runat="server" />
           <asp:Label ID="Label3" runat="server" CssClass="control-label wow fadeInUp" data-wow-delay="2.4s" Text="Remember me ?"></asp:Label>
                   
        </div>
             
          <asp:Button runat="server" CssClass="btn btn-lg btnCustom wow fadeInUp"  data-wow-delay="2.4s" ValidationGroup="Group1" Text="Sign In" OnClick="Signin_Click"/>
         </div>
          <br/>
          <p class="wow fadeInDown" data-wow-delay="2.4s">Don't have an account?</p>
          <asp:LinkButton runat="server" CssClass="btn btn-lg btnCustom wow fadeInUp"  data-wow-delay="2.4s" OnClick="Signup_Now" Text="Sign Up Now" />
        
        </div>
        <div class="col-lg-2 col-md-2"></div>
  </div>
</div>
</div>

<!--end SignUp-->

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
</asp:Content>
