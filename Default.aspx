<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <div class="background" style="background-color: #F1EEF2">
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
                        <li class="active"><a href="Default.aspx">Home</a></li>
                        <li><a href="#">About</a></li>
                        <li><a href="Products.aspx">Products</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Categories<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="dropdown-header">
                                <asp:Repeater ID="RepCat" runat="server">
                                    <ItemTemplate>
                                        <li><a href="Products.aspx?CAT=<%#Eval("CatName") %>"><%#Eval("CatName") %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>  
                                </li>
                            </ul>
                        </li>
                         <li><a href="SignUp.aspx">Sign Up</a></li>
                          <li><a href="SignIn.aspx">Sign In</a></li>
                    </ul>
                </div>
            </div>
        </div>
     

        <!--carousel-->
                    <!--- Carousel -->

            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="images/c1.jpg" alt="...">
                        <div class="carousel-caption">
                            
                        </div>
                    </div>
                    <div class="item">
                        <img src="images/c2.jpg" alt="...">
                        <div class="carousel-caption">
                            
                        </div>
                    </div>
                    <div class="item">
                        <img src="images/c3.jpg" alt="...">
                        <div class="carousel-caption">
                            
                        </div>
                    </div>
                </div>
                
                <!-- Controls -->
        <!--carousel-end-->
    </div>
        <br />
        <br />
        <!-- Middle Carousel-->
        <div class="container center">
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
        <!-- Middle Carousel-->
        <!-- Footer Carousel-->
        <br />
        <br />

            <footer>
                <div class="container ">
                    <p class="pull-right"><a href="Default.aspx">Back To Top</a></p>
                    <p>&copy; 2017 C# Projects &middot;<a href="Default.aspx">Home</a>&middot;<a href="Default.aspx">About</a>&middot;<a href="Default.aspx">Contact</a>&middot;</p>
                </div>
            </footer>
        <!-- Footer Carousel-->
    </div>
    </form>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
