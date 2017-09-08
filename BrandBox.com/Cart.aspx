<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BrandBox.com.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .btnCart{
           font-weight: 500 !important;
	font-size: 15px  !important;
	text-transform: uppercase;
	margin-bottom: 10px;
	color: #f4511e ;
	background: transparent;
    transition: background .2s ease-in-out, border .2s ease-in-out;
	border: 2px solid #f4511e ;
       }
       .btnCart:hover{
           
	background-color: #f4511e !important;
	color: #fff !important;
	border: 2px solid #eb7b20  !important;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <div class="container">
            <div class="row">
                <div class="col-sm-12 col-md-10 col-md-offset-1" style="margin-top:80px;">
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>Product</th>
                                <th>Quantity</th>
                                <th>Size</th>
                                <th></th>
                                <th class="text-center">Price of Single Product</th>
                                <th></th>
                                <th> </th>
                            </tr>
                        </thead>
                        <tbody>
                        <h2  runat="server" id="h2NoItems"></h2> 
                            <asp:Repeater ID="rptrCartProducts" runat="server">
                                <ItemTemplate>
                                    <tr>

                                        <td class="col-sm-8 col-md-6">
                                        <div class="media">
                            
                                        <div class="media-body">
                                  
                                        <h4 class="media-heading"><%#Eval("ProductName") %></h4>
                                        <div class="text-center">
                                        <asp:Image ID="Image1" runat="server" alt="image" style="height:100px;width:100px"  ImageUrl='<%#BrandBox.com.Accessible.GetImage(Eval("ImageData")) %>' />
                                        </div>
                                        </div>
                                        </div>
                                        </td>
                                        <td class="col-sm-1 col-md-1" style="text-align: center"><strong><%#Eval("ProductQnty") %></strong></td>
                                        <td class="col-sm-1 col-md-1" style="text-align: center"><strong><%#Eval("ProductSize") %></strong></td>
                                        <td></td>
                                        <td class="col-sm-1 col-md-1 text-center"><strong><%#Eval("ProductPrice") %></strong></td>
                                        <td></td>
                                        <td class="col-sm-1 col-md-1">
                                        <asp:LinkButton runat="server" type="button" class="btn btnCart" CommandArgument='<%#Eval("ProductCode") %>' OnClick="btnRemoveItem_Click">
                                        <i class="fa fa-times" aria-hidden="true"></i>
                                        </asp:LinkButton></td>
                                
                                   </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                    <tfoot runat="server" id="divPriceDetails">
                    <tr>
                        <td>   </td>
                        <td>   </td>
                        <td>   </td>
                        <td><h3>Total</h3></td>
                        <td class="text-right"><h3 id="spanTotal" runat="server"></h3></td>
                    </tr>
                    <tr>
                        <td>   </td>
                        <td>   </td>
                        <td>   </td>
                        <td>
                        <a href="AllProducts.aspx" class="btn btnCart btn-md" style="padding-right: 10px;padding-left: 10px; margin-left:15px;">

                        <i class="fa fa-cart-plus" aria-hidden="true"></i> Continue shopping
                        </a></td>
                                                                              
                        <td>
                       <asp:LinkButton runat="server" CssClass="btn btnCart" OnClick="checkOut_Click"><i class="fa fa-shopping-cart"> Checkout</i></asp:LinkButton>
                       
                        
                        </td>
 


                    </tr>
                </tfoot>
            </table>
        </div>
    </div>
</div>
</div>
    <asp:Label runat="server" ID="msg"></asp:Label>

</asp:Content>
