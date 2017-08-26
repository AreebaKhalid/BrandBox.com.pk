<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="BrandBox.com.SignUp" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<!--form1 starts-->
<div class="container signupBox">
    <div class="login-signup">
       <div class="row">
        <div class="col-sm-12 nav-tab-holder">
            <ul class="nav nav-tabs row" role="tablist">
                 <li role="presentation" class="active col-sm-12"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Sign Up</a></li>
            </ul>
        </div>
       </div>


      <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="home">
          <div class="row">

            <div class="col-sm-12 mobile-pull">
              <article role="login">
                <h3 class="text-center"><i class="fa fa-lock"></i>&nbspCreate Vendor Account</h3>
                <form class="signup" name="SignUpForm" method="post">

                  <div class="form-group">
                      <asp:TextBox runat="server" id="vendorName" CssClass="form-control" placeholder="Vendor Brand Name" />
                      <asp:Label ID="VNameErrorMessage" runat="server" Text=""></asp:Label>
                      <asp:RequiredFieldValidator runat="server" ValidationGroup="Group1" id="reqName" controltovalidate="vendorName" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                      <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "vendorName" ID="maxName" CssClass="errors" ValidationExpression = "^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                      <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "vendorName" ID="minName" CssClass="errors" ValidationExpression = "^[\s\S]{5,}$" runat="server" ErrorMessage="Minimum 5 characters required."></asp:RegularExpressionValidator>
                  </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="vendorEmail" CssClass="form-control" placeholder="Email Address" />
                    <asp:Label ID="VEmailErrorMessage" runat="server" Text=""></asp:Label>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="Group1" id="reqEmail" controltovalidate="vendorEmail" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                    <asp:RegularExpressionValidator id="validEmail" ValidationGroup="Group1" ControlToValidate="vendorEmail" Text="Invalid email address." CssClass="errors" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Runat="server" Display="Dynamic"/>        
                  </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="vendorPassword" CssClass="form-control" placeholder="Password" textMode="Password"/>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="Group1" id="reqPass" controltovalidate="vendorPassword" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                    <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "vendorPassword" ID="maxpass" CssClass="errors" ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed."></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "vendorPassword" ID="minpass" CssClass="errors" ValidationExpression = "^[\s\S]{7,}$" runat="server" ErrorMessage="Minimum 7 characters required."></asp:RegularExpressionValidator>
                  </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="vendorConfPass" CssClass="form-control" placeholder="Confirm Password" textMode="Password"/>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="Group1" id="reqPass1" controltovalidate="vendorConfPass" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                    <asp:CompareValidator id="comparePass" ValidationGroup="Group1" runat="server" ControlToCompare="vendorPassword" CssClass="errors" ControlToValidate="vendorConfPass" ErrorMessage="Password must match." Display="Dynamic" />
                  </div>

                   <div class="form-group">
                       <asp:FileUpload ID="VendorFileUpload" runat="server" />
                       <asp:RequiredFieldValidator runat="server" ValidationGroup="Group1" id="RequiredVendorFileUpload" controltovalidate="VendorFileUpload" CssClass="errors" errormessage="Please add a logo of your brand." Display="Dynamic" />
                       <asp:Label ID="VUploadError" runat="server" ValidationGroup="Group1" Text=""></asp:Label>
                   </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="vendorphoneNum" CssClass="form-control" placeholder="Phone Number" textMode="Phone" Type="Number"/>
                    <asp:RegularExpressionValidator ID="validPhone" ValidationGroup="Group1" runat="server" ControlToValidate="vendorphoneNum" CssClass="errors" ErrorMessage="Please enter a valid phone number." Display="Dynamic"  ValidationExpression="[0-9]{11}"></asp:RegularExpressionValidator> 
                  </div>

                 <div class="form-group">
                    <asp:TextBox runat="server" id="vendorDetails" CssClass="form-control" placeholder="Details" textMode="MultiLine"/>
                    <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "vendorDetails" ID="lengthDetails" CssClass="errors" ValidationExpression = "^[\s\S]{0,200}$" runat="server" ErrorMessage="Maximum length reached."></asp:RegularExpressionValidator>
                 </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="vendorLocation" CssClass="form-control" placeholder="Address"/>
                    <asp:RequiredFieldValidator runat="server" id="reqLocation" ValidationGroup="Group1" controltovalidate="vendorLocation" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                  </div>

                  
                  <div class="form-group">
                      <asp:Button ID="Submit" Text="SUBMIT" CssClass="btn btn-success btn-block" ValidationGroup="Group1" runat="server" OnClick="SignUpSuccessful" />
                  </div>
                </form>

            </article>
          </div>

          </div>
          <!-- end of row -->
         </div>
        <!-- end of home -->
        </div>
         </div>
 </div>
</div>

<!--form1 end-->
    <div style="margin: 0px 40% 10px" class="container">
	<div class="row">
		<span style="color:  #585858">Already have an account. </span>
        <asp:LinkButton style="color:#f4511e" Text="Login." PostBackUrl="~/Login.aspx" runat="server"/> 
	</div>    
  </div>
</asp:Content>