<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="CustomerBill.aspx.cs" Inherits="BrandBox.com.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="jumbotron">
    <div class="container">
    <div class="row">
        
           <h1>Thankyou for shopping :)</h1>
        
        <!--first half-->
       <div class="col-sm-12 col-md-5 col-md-offset-1" style="margin-top:30px;">

            <table class="table table-hover">
                <thead>
                    <tr>
                        <th colspan="2"><h2>Your Receipt</h2></th>
                    </tr>
                </thead>
                <tbody>
                  <asp:Repeater ID="rptrOrderDetails"  runat="server">
                      <ItemTemplate>
                    <tr><td><strong>Your Order ID:</strong></td><td>  <%#Eval("OrderID") %></td></tr>
                    <tr><td><strong>Total Amount:</strong></td><td>  <%#Eval("CTotalPayment") %></td></tr>
                    <tr><td><strong>Shipping Address:</strong></td><td>  <%#Eval("CustomerAddress") %></td></tr>
                       </ItemTemplate>
                  </asp:Repeater>

                </tbody>
                
            </table>
        </div>
        
        <!--first half-->
        
        <!--second half-->
       <div class="col-sm-12 col-md-5 col-md-offset-1" style="margin-top:30px;">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Product</th>
                        <th>Quantity</th>
                        <th></th>
                        <th class="text-center">Price</th>
                        <th></th>
                        <th> </th>
                    </tr>
                </thead>
                <tbody>
                    <h2  runat="server" id="h2NoItems"></h2>

                     <asp:Repeater ID="rptrCartProducts" runat="server">
                     <ItemTemplate>
                       <tr>

                        <td class="col-sm-6 col-md-4">
                         <div class="media">
                            
                            <div class="media-body">
                                  
                                  <h4 class="media-heading"><%#Eval("ProductName") %></h4>
                                <div class="text-center">
                                    <asp:Image ID="Image1" runat="server" alt="image" style="border:5px solid black; height: 80px;width:150px;"  ImageUrl='<%#BrandBox.com.Accessible.GetImage(Eval("ImageData")) %>' />
                                 </div>
                            </div>
                          </div>


                        </td>
                        <td class="col-sm-1 col-md-1" style="text-align: center"><strong><%#Eval("OrderQnty") %></strong></td>
                           <td></td>
                        <td class="col-sm-1 col-md-1 text-center"><strong><%#Eval("OrderTotalPrice") %></strong></td>
                       <td></td>
                                
                    </tr>
                    </ItemTemplate>
                  </asp:Repeater>
                </tbody>
            </table>
        </div>
        <!--second half-->

    </div>
</div>
</div>
</asp:Content>
