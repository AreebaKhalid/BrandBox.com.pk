<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="MyProducts.aspx.cs" Inherits="BrandBox.com.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class =" row" style="margin:50px 0">
            <h1> My Products </h1>
        </div>
        <div class="row">
            <asp:Repeater ID="MyProductsRptr" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>    
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="product-item">
                            <div class="pi-img-wrapper">
                                <asp:Image runat="server" ID="img" alt="image" CssClass="img-responsive zoom" ImageUrl='<%# BrandBox.com.Accessible.GetImage(Eval("ImageData")) %>' />    
                                <div>
                                  <a href="#" class="btn">Zoom</a>
                                  <a href="#" class="btn">View</a>
                                </div>
                            </div>
                            <h3><a href="shop-item.html"></a><%# Eval("ProductName") %></h3>
                            <div class="pi-price"><%# Eval("ProductPrice") %></div>
                            <a href="javascript:;" class="btn add2cart">Edit</a>
                        </div>
                    </div>
              </ItemTemplate>
              <FooterTemplate>
                    </tbody>
               </table>
              </FooterTemplate>
            </asp:Repeater>

        </div>

     </div>

</asp:Content>
