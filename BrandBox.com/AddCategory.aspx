<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="BrandBox.com.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--form1 starts-->
<div class="container signupBox">
    <div class="login-signup">
       <div class="row">
        <div class="col-sm-12 nav-tab-holder">
            <ul class="nav nav-tabs row" role="tablist">
                 <li role="presentation" class="active col-sm-12"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Add Category</a></li>  
            </ul>
        </div>
        </div>


      <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="home">
          <div class="row">

            <div class="col-sm-12 mobile-pull">
              <article role="login">
                <div class="form">


                  <div class="form-group">
                      <asp:TextBox runat="server" id="catName" CssClass="form-control" placeholder="Product Name" />
                      <asp:RequiredFieldValidator runat="server" ValidationGroup="vg" id="reqName" controltovalidate="catName" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                      <asp:RegularExpressionValidator ValidationGroup="vg" Display = "Dynamic" ControlToValidate = "catName" ID="maxName" CssClass="errors" ValidationExpression = "^[\s\S]{0,50}$" runat="server" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                      <asp:RegularExpressionValidator ValidationGroup="vg" Display = "Dynamic" ControlToValidate = "catName" ID="minName" CssClass="errors" ValidationExpression = "^[\s\S]{3,}$" runat="server" ErrorMessage="Minimum 3 characters required."></asp:RegularExpressionValidator>
                  </div>

                  

                <div class="form-group">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </div>
                 
                  <div class="form-group">
                      <asp:Button  Text="SUBMIT" CssClass="btn btn-success btn-block" ValidationGroup="vg" runat="server" OnClick="Add_Category"/>
                  </div>
                </div>

              </article>
            </div>

           

          </div>
          <!-- end of row -->
        </div>
 
  </div>
  </div>
</div>

<!--form1 end-->
    <div class="container signupBox">
    <h3>Categories</h3>
        <hr />
        <div class="panel panel-default">
            <!-- Default panel contents -->
            <div class="panel-heading">All categories</div>

            <asp:Repeater ID="CatRptr" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Categories</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("PCID") %></th>
                        <td><%# Eval("ProductCatName") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
   
    </div>

</asp:Content>
