<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="ProductView.aspx.cs" Inherits="ProductView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-top: 50px">
        <div class="col-md-5">
            <div style="max-width: 480px" class="thumbnail">
                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                  <!-- Indicators -->
                  <ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                  </ol>

                  <!-- Wrapper for slides -->
                  <div class="carousel-inner" role="listbox">

                      <asp:Repeater ID="rptrImages" runat="server">
                        <ItemTemplate>
                            <div class="item <%# GetActiveClass(Container.ItemIndex) %>">
                              <img src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("ImgName") %><%#Eval("Extention") %>" alt="<%#Eval("ImgName") %>" alt="01" onerror="this.src='images/NoPicAvailable.png'">
                              <div class="carousel-caption"><%#Eval("PName") %></div>
                            </div>
                        </ItemTemplate>
                      </asp:Repeater>

                      <!-- Controls -->
                      <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                      </a>
                      <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                  </a>
                </div>
            </div> 
        </div>
    </div>

    <div class="col-md-7">
        <asp:Repeater ID="rptrProductDetails" runat="server">
            <ItemTemplate>
                <div class ="divDet1">
                    <h1 class="proNameView"><%#Eval("PName") %></h1>
                    <p class="proPriceView"><%#Eval("PSellPrice") %></p>
                </div>


                <div class ="divDet1">
                    <h3 class="proNameView">Brand</h3>
                    <p class="proPriceView"><%#Eval("BrandName") %></p>  
            
                </div>

                <div class ="divDet1">
                    <h3 class="proNameView">Catagory</h3>
                    <p class="proPriceView"><%#Eval("CatName") %></p>  
                </div>

                <div class ="divDet1">
                    <h3 class="proNameView">Product Details</h3>

                    <p><%#Eval("PProductDetails") %></p>
                </div>

                <div>
                   <p><%# ((int)Eval("FreeDelivery")==1)?"Free Delivery":"" %></p>
                   <p><%# ((int)Eval("3DayReturn")==1)?"3 Days Returns":"" %></p>
                   <p><%# ((int)Eval("COD")==1)?"Cash on Delivery":"" %></p>
               </div>
           </ItemTemplate>
        </asp:Repeater>

        <div class ="divDet1">
            
            <%
                if( Session["USERNAME"].ToString() == "admin")
                {
                    %>
                        <asp:Button ID="Button3" CssClass="mainButton" runat="server" Text="Remove" OnClick="Button3_Click"  />
                    <%
               }
               else
               {
                    %>
                        <asp:Button ID="btnAddToCart" OnClick="btnAddToCart_Click" CssClass="mainButton" runat="server" Text="ADD TO CART" />
                    <%
               }
            %>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>

    </div>

</asp:Content>

