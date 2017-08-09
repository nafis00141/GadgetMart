<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Button ID="Button1" runat="server" Text="Show Delevered List" class=" btn btn-danger"  OnClick ="Button1_Click"/>
    <asp:Button ID="Button2" runat="server" Text="In Query List" class="btn btn-primary" OnClick ="Button2_Click"/>
    <div style=" padding:8px 8px 8px 8px;">
    <h3 style="color:red; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif"><asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label></h>
    </div>
     <div style="border-bottom:1px solid #eaeaec; border-left:1px solid #eaeaec; border-top:1px solid #eaeaec; border-right:1px solid #eaeaec; margin-left:70%; padding:8px 8px 8px 8px;">
            
       </div>

    
      <asp:Repeater ID="rptrsold" runat="server">
            <ItemTemplate>
                <div class="col-md-8" style="border-bottom:1px solid #eaeaec; border-left:1px solid #eaeaec; border-top:1px solid #eaeaec; border-right:1px solid #eaeaec; padding:8px 8px 8px 8px;">
                 
                <div class="media">
                  
                    <div class="media-body">
                    
                    <h5 class="media-heading proNameViewCart ">Uid:<%#Eval("uid") %>  Date:<%#Eval("date") %> </h5>
                        <p> Mobile No: <%#Eval("num") %> </p>
                        <p> Address : <%#Eval("add") %></p>
                    
                         <asp:LinkButton ID="LinkButton1"  runat="server" class="btn btn-danger"> Cancel </asp:LinkButton>
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
                                             <h5 style="color:cornflowerblue; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif">PID: <%#Eval("PID") %>  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;   Name: <%#Eval("PName") %>  </h5>
                                        </ItemTemplate>
                                    </asp:Repeater> 

                                </div>
                                <div class="modal-footer">

                                </div>
                              </div>
      
                            </div>
                          </div>

                         <asp:LinkButton ID="LinkButton3"  runat="server" CommandArgument='<%#Eval("sid") %>' class="btn btn-info" OnClick ="LinkButton3_Click"> Done </asp:LinkButton>

                    </div>
                  </div>
                </div>
               
            </ItemTemplate>
        </asp:Repeater>            
                

</asp:Content>

