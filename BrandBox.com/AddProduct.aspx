<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="BrandBox.com.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<!--form1 starts-->
<div class="container signupBox">
    <div class="login-signup">
       <div class="row">
        <div class="col-sm-12 nav-tab-holder">
            <ul class="nav nav-tabs row" role="tablist">
                 <li role="presentation" class="active col-sm-12"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Add Products</a></li>  
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
                      <asp:TextBox runat="server" id="productName" CssClass="form-control" placeholder="Product Name" />
                      <asp:Label ID="VNameErrorMessage" runat="server" Text=""></asp:Label>
                      <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="productName" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic"  ValidationGroup="Group1"/>
                      <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "productName" ID="maxName" CssClass="errors" ValidationExpression = "^[\s\S]{0,50}$" runat="server" ValidationGroup="Group1" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                      <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "productName" ID="minName" CssClass="errors" ValidationExpression = "^[\s\S]{5,}$" runat="server" ValidationGroup="Group1" ErrorMessage="Minimum 5 characters required."></asp:RegularExpressionValidator>
                  </div>

                  <div class="form-group">
                    <asp:TextBox runat="server" id="productPrice" CssClass="form-control" placeholder="Product Price" />
                    <asp:RequiredFieldValidator runat="server" id="reqPrice" ValidationGroup="Group1" controltovalidate="productPrice" CssClass="errors" errormessage="This field cannot be blank." Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="Group1" runat="server" ControlToValidate="productPrice" CssClass="errors" ErrorMessage="Please enter a valid price." Display="Dynamic"  ValidationExpression="^\d+$"></asp:RegularExpressionValidator> 
                  </div>

                  <div class="form-group" >
                   <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Category" ForeColor="Black"></asp:Label>
                 
                    <asp:DropDownList ID="productCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="PCatReq" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="productCategory" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
                
                   <div class="form-group">
                       <asp:FileUpload ID="ProductImageFileUpload" runat="server" />
                       <asp:Label ID="Fileuoploader" Text ="Please image of your product" runat="server"></asp:Label>
                       <asp:RequiredFieldValidator runat="server" id="RequiredProductImageFileUpload" ValidationGroup="Group1" controltovalidate="ProductImageFileUpload" CssClass="errors" errormessage="Please add image of the product." Display="Dynamic" />
                       <asp:Label ID="PImageUploadError" runat="server" Text=""></asp:Label>
                   </div>

                  
                 <div class="form-group">
                    <asp:TextBox runat="server" id="productDetails" CssClass="form-control" placeholder="Details" textMode="MultiLine"/>
                    <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "productDetails" ID="lengthDetails" CssClass="errors" ValidationExpression = "^[\s\S]{0,200}$" runat="server" ErrorMessage="Maximum length reached."></asp:RegularExpressionValidator>
                 </div>

                 
                      <asp:CheckBox  Text="Small" Value="Small" ID="chkSmall" runat ="server" ForeColor="Black" float="left" width="50%"/>
                  <div class="form-group">  
                    <asp:TextBox runat="server" id="SproductQnty" CssClass="form-control" placeholder="Product Quantity" width="50%"/>
                    <asp:RegularExpressionValidator ID="SchkValidPQnty" ValidationGroup="Group1" runat="server" ControlToValidate="SproductQnty" CssClass="errors" ErrorMessage="Please enter a valid Quantity" Display="Dynamic"  ValidationExpression="^\d+$"></asp:RegularExpressionValidator> 
                   </div>
                      <asp:CheckBox  Text="Large" Value="Large" ID="chkLarge" runat="server" ForeColor="Black"/>
                    <div class="form-group">
                     
                    <asp:TextBox runat="server" id="LproductQnty" CssClass="form-control" placeholder="Product Quantity" />
                   <asp:RegularExpressionValidator ID="LchkValidPQnty" ValidationGroup="Group1" runat="server" ControlToValidate="LproductQnty" CssClass="errors" ErrorMessage="Please enter a valid Quantity" Display="Dynamic"  ValidationExpression="^\d+$"></asp:RegularExpressionValidator> 
                </div>
                      <asp:CheckBox  Text="Medium" Value="Medium" ID="chkMedium" runat="server" ForeColor="Black"/>
                     <div class="form-group">
                    <asp:TextBox runat="server" id="MproductQnty" CssClass="form-control" placeholder="Product Quantity" />
                     <asp:RegularExpressionValidator ID="MchkValidPQnty" ValidationGroup="Group1" runat="server" ControlToValidate="MproductQnty" CssClass="errors" ErrorMessage="Please enter a valid Quantity" Display="Dynamic"  ValidationExpression="^\d+$"></asp:RegularExpressionValidator> 
                  
                </div>

                <div class="form-group">
                    <asp:Label ID="chkLabel" runat="server" CssClass="col-md-2 control-label" Text="Category"></asp:Label>
                <div class="col-md-3">
                </div>
                 
                  <div class="form-group">
                      <asp:Button  Text="SUBMIT"  ValidationGroup="Group1" CssClass="btn btn-success btn-block" runat="server" OnClick="CreateProducts"/>
                  </div>
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


</asp:Content>
