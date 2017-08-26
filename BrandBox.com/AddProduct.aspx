<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="BrandBox.com.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="margin-top:50px; margin-bottom:200px">
        <div class="form-horizontal">
            <h2>Add Product</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Product Name"></asp:Label>
                <div class="col-md-3">
                      <asp:TextBox runat="server" id="productName" CssClass="form-control" placeholder="Product Name" />
                      <asp:Label ID="VNameErrorMessage" runat="server" Text="" CssClass="errors"></asp:Label>
                      <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="productName" CssClass="text-danger" errormessage="This field cannot be blank." Display="Dynamic"  ValidationGroup="Group1"/>
                      <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "productName" ID="maxName" CssClass="text-danger" ValidationExpression = "^[\s\S]{0,50}$" runat="server" ValidationGroup="Group1" ErrorMessage="Maximum 50 characters allowed."></asp:RegularExpressionValidator>
                      <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "productName" ID="minName" CssClass="text-danger" ValidationExpression = "^[\s\S]{5,}$" runat="server" ValidationGroup="Group1" ErrorMessage="Minimum 5 characters required."></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label" Text="Product Price:"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox runat="server" id="productPrice" CssClass="form-control" placeholder="Product Price" />
                    <asp:RequiredFieldValidator runat="server" id="reqPrice" ValidationGroup="Group1" controltovalidate="productPrice" CssClass="text-danger" errormessage="This field cannot be blank." Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="Group1" runat="server" ControlToValidate="productPrice" CssClass="text-danger" ErrorMessage="Please enter a valid price." Display="Dynamic"  ValidationExpression="^\d+$"></asp:RegularExpressionValidator>         
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="Choose Category:"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="productCategory" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="PCatReq" ValidationGroup="Group1" CssClass="errors" runat="server" ErrorMessage="This field is Required !" ControlToValidate="productCategory" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
           </div>

           <div class="form-group">
                <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label" Text="Gender: "></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlGender" runat="server"  CssClass="form-control" AutoPostBack="true">
                         <asp:ListItem Text="Select Gender" Value="0"></asp:ListItem>
                         <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                         <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                         <asp:ListItem Text="Children" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="genderReq" ValidationGroup="Group1" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="ddlGender" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
           </div>

          <div class="form-group">
                <asp:Label ID="Label5" runat="server" CssClass="col-md-2 control-label" Text="Upload Image: "></asp:Label>
                <div class="col-md-3">
                    <asp:FileUpload ID="ProductImageFileUpload" runat="server" />     
                    <asp:RequiredFieldValidator runat="server" id="RequiredProductImageFileUpload" ValidationGroup="Group1" controltovalidate="ProductImageFileUpload" CssClass="text-danger" errormessage="Please add image of the product." Display="Dynamic" />
                    <asp:Label ID="PImageUploadError" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
          </div>
            
          <div class="form-group">
                <asp:Label ID="Label6" runat="server" CssClass="col-md-2 control-label" Text="Product Details: "></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox runat="server" id="productDetails" CssClass="form-control" placeholder="Details" textMode="MultiLine"/>
                    <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="Group1" ControlToValidate = "productDetails" ID="lengthDetails" CssClass="text-danger" ValidationExpression = "^[\s\S]{0,200}$" runat="server" ErrorMessage="Maximum length reached."></asp:RegularExpressionValidator>
                </div>
          </div>

          <div class="form-group">
              
                <asp:Label ID="Label7" runat="server" CssClass="col-md-2 control-label" Text="Size "></asp:Label>
                <div class="col-md-2">
                <asp:CheckBox  Text="Small" Value="Small" ID="chkSmall" runat ="server" oncheckedchanged="small_CheckedChanged" AutoPostBack="true"/>
                <asp:TextBox runat="server" id="SproductQnty" CssClass="form-control" Enabled="false"/>
                <asp:RegularExpressionValidator ID="SchkValidPQnty" ValidationGroup="Group1" runat="server" ControlToValidate="SproductQnty" CssClass="text-danger" ErrorMessage="Please enter a valid Quantity" Display="Dynamic"  ValidationExpression="^\d+$"></asp:RegularExpressionValidator> 
                </div>
                <div class="col-md-2">
                <asp:CheckBox  Text="Large" Value="Large" ID="chkLarge" runat="server" oncheckedchanged="large_CheckedChanged" AutoPostBack="true"/>
                <asp:TextBox runat="server" id="LproductQnty" CssClass="form-control" Enabled="false"/>
                <asp:RegularExpressionValidator ID="LchkValidPQnty" ValidationGroup="Group1" runat="server" ControlToValidate="LproductQnty" CssClass="text-danger" ErrorMessage="Please enter a valid Quantity" Display="Dynamic"  ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </div>
                <div class="col-md-2">
                <asp:CheckBox  Text="Medium" Value="Medium" ID="chkMedium" runat="server" oncheckedchanged="medium_CheckedChanged" AutoPostBack="true"/>
                <asp:TextBox runat="server" id="MproductQnty" CssClass="form-control" Enabled="false"/>
                <asp:RegularExpressionValidator ID="MchkValidPQnty" ValidationGroup="Group1" runat="server" ControlToValidate="MproductQnty" CssClass="text-danger" ErrorMessage="Please enter a valid Quantity" Display="Dynamic"  ValidationExpression="^\d+$"></asp:RegularExpressionValidator> 
                </div>
                
                
          </div>

          
           
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                     <asp:Button  Text="SUBMIT"  ValidationGroup="Group1" CssClass="btn btn-default" runat="server" OnClick="CreateProducts"/>
                </div>
                    <asp:Label ID="chkLabel" runat="server" CssClass="col-md-2 control-label errors" Text=""></asp:Label>
                
            </div>

        </div>
    </div>

</asp:Content>
