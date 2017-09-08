<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="AllProducts.aspx.cs" Inherits="BrandBox.com.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <link rel="stylesheet" type="text/css" href="css/sideBar.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="sideNavigation" class="sidenav">
        <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>
        <asp:LinkButton runat="server" OnClick="All_Click" >All</asp:LinkButton>
        <asp:Repeater ID="AllProductsRptr" runat="server" OnItemCommand="AllProductsRptr_ItemCommand"> 
            <ItemTemplate>
                <asp:LinkButton runat="server" CommandArgument='<%#Eval("PCID") %>'><%# Eval("ProductCatName") %></asp:LinkButton>
            </ItemTemplate>
         </asp:Repeater>
    </div>
 
    <nav class="navbar-fixed-top showcat col-md-3" style="margin-top: 50px;">
        <a href="#" onclick="openNav()">&nbsp&nbsp<i class="fa fa-arrow-right" aria-hidden="true"></i> Choose category</a>
    </nav>

    <div class="container">
        <div class =" row" style="margin:50px 0">
            <h1 id="h1noOfItems" runat="server"> </h1>
            <asp:Label runat="server" ID="lblDel"></asp:Label>
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
                            <div class="pi-img-wrapper" style="height: 250px;width:250px;">
                                <asp:Image runat="server" ID="img" alt="image" Height="250px" Width="250px" CssClass="img-responsive zoom" ImageUrl='<%# BrandBox.com.Accessible.GetImage(Eval("ImageData")) %>' />    
                                <div>
                                  <a href="#" class="btn">Zoom</a>
                                  <a href="ViewProduct.aspx?ProductCode=<%# Eval("ProductCode") %>" class="btn">View</a>
                                </div>
                            </div>
                            <h3><a href="shop-item.html"></a><%# Eval("ProductName") %></h3>
                            <div class="pi-price"><%# Eval("ProductPrice") %></div>
                           
                        </div>
                    </div>
              </ItemTemplate>
            </asp:Repeater>
    <script>
        function openNav() {
             document.getElementById("sideNavigation").style.width = "250px";
             document.getElementById("main").style.marginLeft = "250px";
                }
 
       function closeNav() {
            document.getElementById("sideNavigation").style.width = "0";
            document.getElementById("main").style.marginLeft = "0";
                }
    </script>
</asp:Content>
