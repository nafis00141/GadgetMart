<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="col-md-3" style="margin-left:70%">
            <div style="border-bottom: 1px solid #eaeaec">
                <h4>Price Details</h4>
                <div>
                    <label>Cart Total : </label>
                    <span class="pull-right"><%=total%></span>
                </div>
            </div>
            <div style="padding-top: 16px; ">
                

                 <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Buy Now</button>

                  <!-- Modal -->
                  <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">
    
                      <!-- Modal content-->
                      <div class="modal-content">
                        <div class="modal-header">
                          <button type="button" class="close" data-dismiss="modal">&times;</button>  
                          <h4 class="modal-title">Buy Now</h4>
                        </div>
                        <div class="modal-body">
                          <p>Enter Your Phone Number :
                              <asp:TextBox ID="num" Class="form-control" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorNum" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="num"></asp:RequiredFieldValidator>
                          </p>
                            
                          <p>Enter Your Address :
                              <asp:TextBox ID="add" Class="form-control" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdd" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="add"></asp:RequiredFieldValidator>
                          </p>

                        </div>
                        <div class="modal-footer">
                          
                          <asp:Button ID="Button2" class="btn btn-default" runat="server" Text="Button" OnClick="Button2_Click" />
                          
                          
                          

                        </div>
                      </div>
      
                    </div>
                  </div>

            </div>
        </div>

    <div style="padding-top: 50px">
        
       
        <asp:Repeater ID="rptrProductDetails" runat="server">
            <ItemTemplate>
                <div class="col-md-8" style="border-bottom:1px solid #eaeaec; border-left:1px solid #eaeaec; border-top:1px solid #eaeaec; border-right:1px solid #eaeaec; padding:8px 8px 8px 8px;">
                 
                <div class="media">
                  <div class="media-left">
                    <a href="#">
                      <img  width="150px" class="media-object" src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("ImgName") %><%#Eval("Extention") %>" alt="<%#Eval("ImgName") %>" alt="product">
                    </a>
                   &nbsp;</div>
                    <div class="media-body">
                    <h5 class="media-heading proNameViewCart "><%#Eval("PName") %></h5>
                    <p> Price : <%#Eval("PSellPrice") %></p>
                    <p> Category : Mobile</p>
                    <p> Brand : <%#Eval("BrandName") %> </p>
                         <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("PID") %>' runat="server">Remove</asp:LinkButton>
                         <asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("PID") %>' runat="server" OnClick="LinkButton2_Click">LinkButton</asp:LinkButton>
                  </div>
                </div>
            </div>
               
            </ItemTemplate>
        </asp:Repeater>
       

        
    </div>

    <!-- -->

   
    
</asp:Content>



