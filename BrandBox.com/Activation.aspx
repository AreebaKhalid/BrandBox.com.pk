<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="BrandBox.com.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <h3 class="text-center"><i class="fa fa-lock"></i>&nbspEnter verification code</h3>
                <div class="signup" name="SignUpForm">

                 

                  <div class="form-group">
                    <asp:TextBox runat="server" id="email" CssClass="form-control" placeholder="Enter your email"/>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="Group1" controltovalidate="email" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                  </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="code" CssClass="form-control" placeholder="Enter code sent to your email Address"/>
                    <asp:RequiredFieldValidator runat="server" id="reqLocation" ValidationGroup="Group1" controltovalidate="code" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                  </div>

                  <div class="form-group">
                   <asp:Label ID="ErrorMessage" runat="server" ValidationGroup="Group1" Text=""></asp:Label>
                  </div>

                  <div class="form-group">
                      <asp:Button ID="btnVerify" Text="SUBMIT" CssClass="btn btn-success btn-block" ValidationGroup="Group1" runat="server" OnClick="btnVerify_Click" />
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


    
</asp:Content>
