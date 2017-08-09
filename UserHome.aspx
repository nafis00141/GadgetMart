<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="UserHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>GadgetMart</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
     <link href="css/Custom-Cs.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
         <div class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="container">
               <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                   <a class="navbar-brand" href="Default.aspx"><span><img alt="Logo" src="images/small.png" height="36"/></span> GadgetMart</a>
               </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li ><a href="UserHome.aspx?D=0">Home</a></li>
                        <li ><a href="Products.aspx">Products</a></li>
                        <li><a href="#">About</a></li>
                        
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Categories<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="dropdown-header">
                                
                                    <asp:Repeater ID="RepCat" runat="server">
                                        <ItemTemplate>
                                            <li><a href="Products.aspx?CAT=<%#Eval("CatName") %>"><%#Eval("CatName") %></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>  

                                    

                                <li>  

                                    

                                </li>
                            </ul>
                        </li>
                        <li>
                            
                            <%
                                if( Session["USERNAME"].ToString() != "admin")
                                {
                                    ArrayList cart1 = (ArrayList)Session["CARTP"];
                                    btnCart.Text = "Cart (" + cart1.Count.ToString() + ")";

                                    %>
                                        <asp:Button ID="btnCart" CssClass="btn btn-default navbar-btn" runat="server"  OnClick="btnCart_Click"  />
                                        
                                    <%

                                         
                                 }
                            %>
                            <asp:Button ID="btnSignOut" runat="server" CssClass="btn btn-default navbar-btn"  Text="Sign Out" OnClick="btnSignOut_Click" />
                        </li> 
                    </ul>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
    <asp:Button ID="Button1" runat="server" Text="Show Delevered List" class="btn btn-danger" OnClick ="Button1_Click"/>
    <asp:Button ID="Button2" runat="server" Text="Show Ordered List"  class="btn btn-info" OnClick ="Button2_Click"/>
    <div style="padding:8px 8px 8px 8px;">
    <h3 style="color:red; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif"><asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label></h3>
     </div>


     <div   style="border-bottom:1px solid #eaeaec; border-left:1px solid #eaeaec; border-top:1px solid #eaeaec; border-right:1px solid #eaeaec;  padding:8px 8px 8px 8px; margin-left:70%;">
             
       </div>
    
    
      <asp:Repeater ID="rptrsold" runat="server">
            <ItemTemplate>
                <div class="col-md-8" style="border-bottom:1px solid #eaeaec; border-left:1px solid #eaeaec; border-top:1px solid #eaeaec; border-right:1px solid #eaeaec; padding:8px 8px 8px 8px;">
                 
                <div class="media">
                  
                    <div class="media-body">
                    
                    <h5 class="media-heading proNameViewCart ">Uid:<%#Eval("uid") %>Date:<%#Eval("date") %></h5>
                        <p> Mobile No: <%#Eval("num") %> </p>
                        <p> Address : <%#Eval("add") %></p>
                    
                         <%
                            if (Convert.ToInt32(Request.QueryString["D"]) == 0)
                            {
                                %>
                                <asp:LinkButton ID="LinkButton1"  runat="server" class="btn btn-danger"> Cancel </asp:LinkButton>

                                <%
                            }
                        %>
                        <!---->
                         <asp:LinkButton ID="LinkButton2"  runat="server" CommandArgument='<%#Eval("sid") %>' class="btn btn-primary" OnClick ="LinkButton2_Click" > Get Details </asp:LinkButton>

                         <asp:LinkButton ID="LinkButton4"  runat="server"  class="btn btn-primary" data-toggle="modal" data-target="#myModal" > View </asp:LinkButton>


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
                                  
                                     <asp:Repeater ID="rptrSoldItems" runat="server"> 
                                    <ItemTemplate>
                                         <h5 style="color:cornflowerblue; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">Product Name: <%#Eval("PName") %>  </h5>
                                    </ItemTemplate>
                                </asp:Repeater> 

                                </div>
                                <div class="modal-footer">

                                </div>
                              </div>
      
                            </div>
                          </div>

                        

                               

                    </div>
                  </div>
                </div>
               
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <hr />

        <footer class="footer-pos">
           <div class="container ">
               <p class="pull-right"><a href="Default.aspx">Back To Topault.aspx">About</a>&middot;<a href="Default.aspx">Contact</a>&middot;</p>
           </div>
        </footer>


    </form>

     <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>

</body>
</html>
