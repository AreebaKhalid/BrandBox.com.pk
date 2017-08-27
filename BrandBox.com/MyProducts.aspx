<%@ Page Title="" Language="C#" MasterPageFile="~/web.master" AutoEventWireup="true" CodeBehind="MyProducts.aspx.cs" Inherits="BrandBox.com.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btnAdd{
           font-weight: 500 !important;
	font-size: 15px  !important;
	text-transform: uppercase;
	margin-bottom: 10px;
	color: #f4511e ;
	background: transparent;
    transition: background .2s ease-in-out, border .2s ease-in-out;
	border: 2px solid #f4511e ;
       }
       .btnAdd:hover{
           
	background-color: #f4511e !important;
	color: #fff !important;
	border: 2px solid #eb7b20  !important;
       }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class =" row" style="margin:50px 0">
            <h1  id="h1noOfItems" runat="server"></h1>
            <asp:Label runat="server" ID="lblDel"></asp:Label>
            <a href="AddProduct.aspx" class = "btn btnAdd" role = "button">
                 <i class="fa fa-plus" aria-hidden="true">Add Products</i>
            </a>
        </div>
        <div class="row">
            <asp:Repeater ID="MyProductsRptr" runat="server" onitemcommand="Repeater_ItemCommand">
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
                                  <a href="#" class="btn">View</a>
                                </div>
                            </div>
                            <h3><a href="shop-item.html"></a><%# Eval("ProductName") %></h3>
                            <div class="pi-price"><%# Eval("ProductPrice") %></div>
                           <a href="AddProduct.aspx?ProductCode=<%# Eval("ProductCode") %>" class="btn add2cart">Edit</a>
                            <asp:LinkButton runat="server" CssClass="btn add2cart" CommandArgument='<%#Eval("ProductCode") %>' CommandName="Delete"  OnClientClick="deletealert(this, event);" >Delete</asp:LinkButton>
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
    <script>
        function deletealert(ctl, event) {
            // STORE HREF ATTRIBUTE OF LINK CTL (THIS) BUTTON
            var defaultAction = $(ctl).prop("href");
            // CANCEL DEFAULT LINK BEHAVIOUR
            event.preventDefault();
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                cancelButtonText: "Cancel!",
                closeOnConfirm: false,
                closeOnCancel: false
            },
                function (isConfirm) {
                    if (isConfirm) {
                        swal({ title: "Deleted!", text: "Your product has been deleted.", type: "success", confirmButtonText: "OK!", closeOnConfirm: false },
                            function () {
                                // RESUME THE DEFAULT LINK ACTION
                               window.location.href = defaultAction;
                                return true;
                            });
                    } else {
                        swal("Cancelled", "Your product is not deleted! ", "error");
                        return false;
                    }
                });
        }
    </script>
</asp:Content>
