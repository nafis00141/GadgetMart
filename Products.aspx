<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <div  class="col-md-3"  style="padding-top:40px; margin-left:76%; padding-bottom:20px;" >
             <asp:TextBox ID="name_search" Class="form-control" runat="server"  AutoPostBack="True" placeholder="Search by Product Name"></asp:TextBox>
        </div>
       <div class="form-group" style="padding-top:70px; margin-left:90%;">
              <div style="margin-left:360px;" class="col-md-2"></div>
                  <div  class="col-md-6">
                  <asp:Button ID="Button10" runat="server" Text="Search" CssClass="btn btn-success" OnClick="Button10_Click"   />          
               </div>
        </div>
    <hr/>

    <div class="row" style="padding-top: 50px">
        <asp:Repeater ID="rptrProducts" runat="server">
            <ItemTemplate>
                <div class="col-sm-3 col-md-3">
                    <a style="text-decoration:none;" href="ProductView.aspx?PID=<%#Eval("PID") %>">
                    <div class="thumbnail">
                        <img src="Images/ProductImages/<%#Eval("PID") %>/<%#Eval("ImgName") %><%#Eval("Extention") %>" alt="<%#Eval("ImgName") %>" width="250" height="250"/>
                        <div class="caption">
                            <div class="probrand"><%#Eval("BrandName") %></div>
                            <div class="proName"><%#Eval("PName") %></div>
                            <div class="proPrice">Price : <%#Eval("PSellPrice") %></div>
                        </div>
                    </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
