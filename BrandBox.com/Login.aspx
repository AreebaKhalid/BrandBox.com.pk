<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BrandBox.com.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container signupBox">
        <div class="login-signup">
            <div class="row">
                <div class="col-sm-12 nav-tab-holder">
                    <ul class="nav nav-tabs row" role="tablist">
                        <li role="presentation" class="active col-sm-12"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Login</a></li>
                     </ul>
                </div>

            </div>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="row">
                        <div class="col-sm-12 mobile-pull">
                            <article role="login">
                                    <form class="signup" name="SignUpForm" method="post">
                                        <div class="input-group input-group-lg form-group">
                                            <span class="input-group-addon" id="sizing-addon1"><i class="fa fa-envelope" aria-hidden="true"></i></span>
                                            <asp:textbox id="email" runat="server" CssClass="form-control" placeholder="Email address" ></asp:textbox> 
                                         </div>
                                        <asp:RequiredFieldValidator runat="server" id="emailReq" controltovalidate="email" ValidationGroup="Group1" CssClass="errors" errormessage="Please enter email." Display="Dynamic" />    
                                      

                                        <div class="input-group input-group-lg form-group">
                                            <span class="input-group-addon" id="sizing-addon2"><i class="fa fa-key" aria-hidden="true"></i></span>
                                            <asp:TextBox ID="password" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                        </div>

                                        <asp:RequiredFieldValidator runat="server" id="PasswordReq" controltovalidate="password" ValidationGroup="Group1" CssClass="errors" errormessage="Please enter password." Display="Dynamic" />    

                                        <asp:Label id="lblError" runat="server"></asp:Label>

                                        <div class="form-group">                   
                                            <asp:CheckBox ID="RememberMeCheckBox" CssClass="control-label" runat="server" />
                                            <asp:Label ID="lblRemeber" runat="server" CssClass="control-label" Text="Remember me ?"></asp:Label>          
                                        </div>

                                        <div class="form-group">
                                            <asp:Button runat="server" CssClass="btn btn-success btn-block" ValidationGroup="Group1" Text="Sign In" OnClick="Signin_Click"/>
                                        </div>

                                         <p>Don't have an account?</p>
                                         <asp:Button runat="server" CssClass="btn btn-success btn-block"  OnClick="Signup_Now" Text="Sign Up Now" />
        

                                    </form>
                            </article>
                        </div>
                    </div>
                </div>

        </div>
    </div>

</asp:Content>
