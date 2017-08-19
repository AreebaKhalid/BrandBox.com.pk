<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="BrandBox.com.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
       .pic-size {
             width:320px;
             height:360px;
                 }
       .pic-size-1 {
        width:280px;
        height:210px;
                   }
         p,h3 {
            
    -o-text-overflow: ellipsis;   /* Opera */
    text-overflow:    ellipsis;   /* IE, Safari (WebKit) */
    overflow:hidden;              /* don't show excess chars */
    white-space:nowrap;           /* force single line */
    width: 300px;                 /* fixed width */
         }
         .divider {
         margin: 5px;
         }
       .dropdown:hover .dropdown-menu {
        display: block;
        }
         .dropdown-menu {
             background-color:red;
             color:white;
         }
       .dropdown-menu:hover {
        color:black;
        }
       .btnAddToCart{
           font-weight: 500 !important;
	font-size: 15px  !important;
	text-transform: uppercase;
	margin-bottom: 10px;
	color: #f4511e ;
	background: transparent;
    transition: background .2s ease-in-out, border .2s ease-in-out;
	border: 2px solid #f4511e ;
       }
       .btnAddToCart:hover{
           
	background-color: #f4511e !important;
	color: #fff !important;
	border: 2px solid #eb7b20  !important;
       }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
                <div class="container" style ="margin-top:80px;">
                       <div class = "row">
                          
                              <asp:Repeater ID="rptrImages" runat="server" >
                
                               <ItemTemplate>
                              <div class = " col-xs-12 col-sm-offset-1 col-sm-6 col-md-offset-1 col-md-6 pic-size " style="height: 400px;width:530px;">
                                 <div class = "thumbnail">
                                    <asp:Image ID="Image1" runat="server" alt="image" Height="330px" Width="250px"  class="img-responsive zoom"   ImageUrl='<%#BrandBox.com.Accessible.GetImage(Eval("ImageData")) %>' />
                                 </div>
                                 
                                 
                                 </div>
                                   </ItemTemplate>
                                  </asp:Repeater>

                                 <div class = " col-xs-12 col-sm-5 col-md-5 pic-size">
                                         <div class="container-fluid">
                                                <div class="row">
                                                  <div class="col-xs-12 col-sm-12">
                                                     <asp:Repeater ID="rptrProductDetails"  runat="server" OnItemDataBound="rptrProductDetails_ItemDataBound">
                                                        <ItemTemplate>
                                                            <div class="panel panel-default" style="width: 347px;height: 340px;">
                                                            <div class="panel-heading text-center" >
                                                            <h3><%#Eval("ProductName") %></h3>
                                                            </div>
                                                            <div class="panel-body">
                                                            <p><strong>Category</strong>  <%#Eval("ProductCatName") %></p>
                                                            <p><strong>Brand:</strong>  <%#Eval("VendorName") %></p>
                                                            <p><strong>Price:</strong> <%#Eval("ProductPrice") %></p>
                                                            <p><strong>Description:</strong> <%#Eval("ProductDetails") %></p>
                                                            <asp:Label ID="Label7" runat="server" CssClass="col-md-2 control-label" Text="Size "></asp:Label>
                                                            <div>
                                                            <asp:RadioButtonList runat="server" ID="rblSize" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                            </asp:RadioButtonList>
                                                            </div>
                                                            <asp:TextBox runat="server" id="productQnty" CssClass="form-control" ForeColor="Black"/>
                                                            <asp:RegularExpressionValidator ID="SchkValidPQnty" ValidationGroup="Group1" runat="server" ControlToValidate="productQnty" CssClass="text-danger" ErrorMessage="Please enter a valid Quantity" Display="Dynamic"  ValidationExpression="^\d+$"></asp:RegularExpressionValidator>                                                                                                               
                                                            </div>
                                                        </ItemTemplate>
                                                       </asp:Repeater>
                                                      
                                                      <br/><br/>
                                                    </div> 
                                                   </div> 
                                                </div>

                                                <div class="row">
                                                  <div class="col-xs-12 col-sm-12">
                                                    <div  >
                                                      
                                                        <asp:Button ID="btnAddToCart" ValidationGroup="Group1" runat="server" Text="ADD TO CART" class="btn btnAddToCart btn-lg " OnClick="AddCart" style="padding-right: 110px;padding-left: 110px;"/>
                                                        <asp:Label runat="server" ID ="lblErr"></asp:Label>                                                                                                             

                                                    </div>
                                                   </div> 
                                                </div>


                                          </div>
                                          

                                </div>

                          
                          </section>
       <script>
          
               function ShowHideDiv(chkBox) {
                   var dvqnty = document.getElementByClassName("productQntyDiv");
                    dvqnty.style.display = chkBox.checked ? "block" : "none";
        }
    </script>

</asp:Content>
