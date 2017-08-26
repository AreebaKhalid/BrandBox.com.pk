<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="CustSignup.aspx.cs" Inherits="BrandBox.com.WebForm9" %>
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
                <h3 class="text-center"><i class="fa fa-lock"></i>&nbspCreate Customer Account</h3>
                <div class="signup" name="SignUpForm" method="post">

                  <div class="form-group">
                      <asp:TextBox runat="server" id="custName" CssClass="form-control" placeholder=" Name" />
                      <asp:Label ID="CNameErrorMessage" runat="server" Text=""></asp:Label>
                      <asp:RequiredFieldValidator runat="server" ValidationGroup="Group1" id="reqName" controltovalidate="custName" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                      <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "custName" ID="maxName" CssClass="errors" ValidationExpression = "^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                      <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "custName" ID="minName" CssClass="errors" ValidationExpression = "^[\s\S]{5,}$" runat="server" ErrorMessage="Minimum 5 characters required."></asp:RegularExpressionValidator>
                  </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="custEmail" CssClass="form-control" placeholder="Email Address" />
                    <asp:Label ID="CEmailErrorMessage" runat="server" Text=""></asp:Label>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="Group1" id="reqEmail" controltovalidate="custEmail" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                    <asp:RegularExpressionValidator id="validEmail" ValidationGroup="Group1" ControlToValidate="custEmail" Text="Invalid email address." CssClass="errors" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Runat="server" Display="Dynamic"/>        
                  </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="custPassword" CssClass="form-control" placeholder="Password" textMode="Password"/>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="Group1" id="reqPass" controltovalidate="custPassword" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                    <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "custPassword" ID="maxpass" CssClass="errors" ValidationExpression = "^[\s\S]{0,15}$" runat="server" ErrorMessage="Maximum 15 characters allowed."></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "custPassword" ID="minpass" CssClass="errors" ValidationExpression = "^[\s\S]{7,}$" runat="server" ErrorMessage="Minimum 7 characters required."></asp:RegularExpressionValidator>
                  </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="custConfPass" CssClass="form-control" placeholder="Confirm Password" textMode="Password"/>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="Group1" id="reqPass1" controltovalidate="custConfPass" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                    <asp:CompareValidator id="comparePass" ValidationGroup="Group1" runat="server" ControlToCompare="custPassword" CssClass="errors" ControlToValidate="custConfPass" ErrorMessage="Password must match." Display="Dynamic" />
                  </div>

                  <div class="form-group">
                    <asp:Label ID="lblcity" runat="server" CssClass="col-md-2 control-label" Text="City:"></asp:Label>
                    <asp:DropDownList ID="custCity" CssClass="form-control" runat="server" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="PCityReq" ValidationGroup="Group1" CssClass="errors" runat="server" ErrorMessage="This field is Required !" ControlToValidate="custCity" InitialValue="0"></asp:RequiredFieldValidator>
                  </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="custphoneNum" CssClass="form-control" placeholder="Phone Number" textMode="Phone" Type="Number"/>
                    <asp:RegularExpressionValidator ID="validPhone" ValidationGroup="Group1" runat="server" ControlToValidate="custphoneNum" CssClass="errors" ErrorMessage="Please enter a valid phone number." Display="Dynamic"  ValidationExpression="[0-9]{11}"></asp:RegularExpressionValidator> 
                  </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="custLocation" CssClass="form-control" placeholder="Address"/>
                    <asp:RequiredFieldValidator runat="server" id="reqLocation" ValidationGroup="Group1" controltovalidate="custLocation" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                  </div>
                 
                  <div class="form-group">
                      <asp:Button  Text="SUBMIT" CssClass="btn btn-success btn-block" ValidationGroup="Group1" runat="server" OnClick="SignUpSuccessful" />
                  </div>
                </div>

            </article>
          </div>

          </div>
          <!-- end of row -->
         </div>
        <!-- end of home -->
        </div>
 </div>
 </div>


<!--form1 end-->
    <div style="margin: 0px 40% 10px" class="container">
	<div class="row">
		<span style="color:  #585858">Already have an account. </span>
        <asp:LinkButton style="color:#f4511e" Text="Login." PostBackUrl="~/CustLogin.aspx" runat="server"/> 
	</div>    
  </div>

</asp:Content>
