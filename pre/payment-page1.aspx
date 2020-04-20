<%@ Page Title="" Language="C#" MasterPageFile="~/pre/PreCDFMasterPage.master" AutoEventWireup="true" CodeFile="payment-page1.aspx.cs" Inherits="pre_payment_page1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

/* start add css for Discount card */
  .column_dis{
      width: 45%;
      display: block;
      margin-bottom: 0px;
  }
  .card_dis{
      box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
      padding: 5px;
      text-align: center;
      background-color: #f1f1f1;
      float:left;
  }
  
  .row_dis {
      /*margin: 0 -5px;*/
      margin: 40px -2px;
    padding: 7px;
  }
  .row_dis:after {
     content: "";
     display: table;
     clear: both;
}
  /* end Dicount card*/

  /* Table css */
  #tbl_balance {
  font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 85%;
  font-size:14px;
}

#tbl_balance td, #customers th {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: center;
}

#tbl_balance tr:nth-child(even){background-color: #f2f2f2;}

#tbl_balance tr:hover {background-color: #ddd;}

#tbl_balance th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align:center;
  background-color: #337ab7;
  color: white;
  font-weight:600;
 
  
}
  /*End*/




        .rowspace {
            padding: 0 10px 0 10px;
        }

        .razorpay-payment-button {
            padding: 8px 60px 8px 60px;
            background-color: #428bca;
            align-content: center;
            border-color: #428bca;
            color: #ffffff;
            margin: 15px 0 0 0;
        }

        p {
            font-size: 15px;
        }

        .awesome {
            font-family: Cambria;
            font-style: normal;
            color: #313131;
            font-weight: bold;
            -webkit-animation: colorchange 2s infinite alternate;
        }

        @-webkit-keyframes colorchange {
            0% {
                color: black;
            }

            10% {
                color: red;
            }

            20% {
                color: black;
            }

            30% {
                color: red;
            }

            40% {
                color: black;
            }

            50% {
                color: red;
            }

            60% {
                color: black;
            }

            70% {
                color: red;
            }

            80% {
                color: black;
            }

            90% {
                color: red;
            }

            100% {
                color: black;
            }
        }
    </style>
    <link href="../css/pagination.css" rel="stylesheet" type="text/css" />
         <%-- Prevent cut , copy paste start code--%>
    <script
        src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js">
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('body').bind('cut copy paste', function (e) {
                e.preventDefault();
            });
        });
    </script>
     <%-- Prevent cut , copy paste end code --%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="x_panel">
        <div class="x_title">
            <h2>Payment</h2>
            <ul class="nav navbar-right panel_toolbox">
                <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                </li>

                <li><a class="close-link"><i class="fa fa-close"></i></a>
                </li>
            </ul>
            <div class="clearfix"></div>
        </div>
        <div class="x_content">
            <br />
            <div class="row rowspace">

                <div class="" id="div_msg" runat="server" style="text-align: center; margin-left: 10px; margin-right: 10px;">
                </div>
            </div>
            <div class="row rowspace">
                <div class="" id="div_payment" runat="server">
                    <center>
                    <form action="mainprocess.aspx" method="post">
                        <p style="text-align:justify;">
                           Thanks for showing your interest and faith in us by confirming the same while making payment of the aforesaid amount to Join Dheya community to help national youth to shape their career. We welcome you to “Dheya” community and will update you with your payment details. We will update our records and will proceed with other formalities for your candidature. Our executive will be in touch with you to discuss other formalities and event details. 
<br />
Please feel free to contact us for any further queries to assigned executive or at customer support at phone numbers: +91 99 23 400 555 | 020-24223655 / 65007555  or write us at  care@dheya.com.
                        </p>                        
                        <%--<script
                            src="https://checkout.razorpay.com/v1/checkout.js"
                            data-key="<%=razorkey11%>"
                            data-amount="<%=price%>"
                           data-name="Dheya CDF"
                            data-description="Training Fees"
                            data-order_id="<%=orderId%>"
                            data-image="../images/Dheya-Icon.png"
                            data-prefill.name="<%=usename%>"
                            data-prefill.email="<%=email%>"
                            data-prefill.contact="<%=contact%>"
                            data-theme.color="#2380D9"></script>  
                        <input type="hidden" value="Hidden Element" name="hidden" />--%>
                    </form>
                        </center>
                </div>
            </div>
            <hr />
            <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="row rowspace">
                  <%--   <div id="table_balance">
                           <table id="tbl_balance" align="center">
                             <tbody>
                             <tr>
                             <th>Basic Level</th>
                             <th>Adnavce Level</th>
                             </tr>
                              <tr>
                              <td> Rs.40000</td> 
                              <td>RS.42000</td>
                              </tr>
                            </tbody> 

                           </table> <hr />
                         </div>--%>
                   
                      

                    <div class="" id="div_status" runat="server">
                        <h2 style="font-weight: 600; margin-bottom: 15px; text-align: center; font-size:24px;">Fees</h2>
                         <h3 style="font-weight: 600; margin-bottom: 15px; text-align: center; font-size:24px;">Basic Level + Advance Level</h3>

                       <div class="row_dis">
                                   <div class="column_dis" style=" float: left; margin-right: 6px;">
                                       <div class="card_dis" style="padding-bottom:8px;margin-left: 410px">
                                           <h2><b style="font-size:20px; margin:42px">
                                               <asp:Label ID="lblamt_disc" runat="server" ></asp:Label></b><br></h2>

                                           
                                            
                                           
                                       </div>
                                   </div>
                                   
                               </div>

                        <div class="col-sm-8 col-sm-offset-2">

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="Horizontal" AllowPaging="True" CssClass="table table-responsive"
                                Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                                PageSize="10">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="Product Name" HeaderText="Product Name 111" SortExpression="Product Name">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>

                                  <%--  <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>--%>
                                     <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                       Rs.<asp:Label ID="lblamount3" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Payment Date" HeaderText="Payment Date" SortExpression="Payment Date" DataFormatString="{0:dd/MM/yyyy hh:mm tt}">
                                        <HeaderStyle Wrap="False" />
                                    </asp:BoundField>

                                </Columns>
                                <RowStyle BackColor="#F7F6F3" VerticalAlign="Top" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" VerticalAlign="Top" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" CssClass="GridPager" Wrap="True" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>


                        </div>
                    </div>
                </div>


                <div class="row" id="div_custompay" runat="server">
                    <br />

                    <div class="col-sm-8 col-sm-offset-2">
                    <%--<div class="col-sm-6">
                        <h2 class="awesome">OPTION 1</h2>--%>
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Make One Time Payment </h2>
                                 <div class="clearfix"></div>
                            </div>
                                <%--Add discound card--%>
                            <asp:Panel ID="Panel_full" runat="server">
                                <div class="row_dis">
                                   <div class="column_dis" style=" float: left; margin-right: 6px;">
                                       <div class="card_dis" style="padding-bottom:8px;">
                                           <h2><b style="font-size:20px; margin:42px">
                                               <asp:Label ID="lblamt_disc1" runat="server" ></asp:Label></b><br></h2>

                                           
                                              <%-- <p><b><a style="text-decoration:line-through;"> <asp:Label ID="lblprice_real" runat="server" ></asp:Label></a></b></p>--%>
                                          
                                               <%--<p style="visibility:hidden;"><b>40000 &nbsp;<a style="text-decoration:line-through;"> Rs. 40000/-</a></b></p>--%>
                                           
                                       </div>
                                   </div>
                                    <div>
                                        <asp:Button ID="btn_makepayment_off" runat="server" class="btn btn-success" style="margin:22px" Text="Click here to payment" OnClick="btn_makepayment_off_Click" />
                                        <%--<button type="button" class="btn btn-success" style="margin:22px">Click here to payment</button>--%>

                                    </div>
                               </div>
                                </asp:Panel>


<%--    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount">
                                                    <HeaderStyle Wrap="False" />
                                                </asp:BoundField>--%>

                               
                            <%--<div class="x_content">
                                <asp:Panel ID="Panel_full" runat="server">
                                    <div align="center">
                                        <asp:GridView ID="gvCustomPay_full" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            ForeColor="#333333" GridLines="Horizontal" AllowPaging="True" CssClass="table table-responsive"
                                            Width="100%"
                                            PageSize="20" OnRowCommand="gvCustomPay_RowCommand" DataKeyNames="id">
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text="CDF Training"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                       
                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                       Rs.<asp:Label ID="Label22" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Payment">
                                                    <ItemTemplate>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                               <asp:Button ID="btn_pay" CssClass="btn btn-success btn-sm"
                                                                    runat="server" Text="click here to payment" CommandArgument='<%# Eval("Amount") + "," +  Eval("id")%>' CommandName="pay" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                            </Columns>
                                            <RowStyle BackColor="#F7F6F3" VerticalAlign="Top" ForeColor="#333333" />
                                            <EditRowStyle BackColor="#999999" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" VerticalAlign="Top" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" CssClass="GridPager" Wrap="True" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                            </div>--%>
                        </div>
                    </div>
                    <div id="div_hide_option2" runat="server">
                    <div class="col-sm-6">
                        <h2 class="awesome">OPTION 2</h2>
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Advance Payment to Confirm Participation</h2>
                                <div class="clearfix"></div>
                            </div>
                                <asp:Panel ID="Panel_Advance" runat="server">
                                <div class="row_dis">
                                   <div class="column_dis" style=" float: left; margin-right: 6px;">
                                       <div class="card_dis" style="padding-bottom:8px">
                                           <h2><b style="font-size:16px; margin:auto">
                                               <asp:Label ID="Label2" runat="server" Text="CDF Training Advance Payment"></asp:Label></b><br></h2>

                                           
                                               <p><b> <a><asp:Label ID="lbladv_pay" runat="server" ></asp:Label></a></b></p>
                                          
                                               <%--<p style="visibility:hidden;"><b>40000 &nbsp;<a style="text-decoration:line-through;"> Rs. 40000/-</a></b></p>--%>
                                           
                                       </div>
                                   </div>
                                    <div>
                                        <asp:Button ID="btn_payment_advance" runat="server" class="btn btn-success" style="margin:22px" Text="Click here to payment" />
                                        <%--<button type="button" class="btn btn-success" style="margin:22px">Click here to payment</button>--%>

                                    </div>
                               </div>
                                </asp:Panel>
                            <%--<div class="x_content">
                                <div class="form-horizontal" role="form" runat="server">

                                    <div class="x_content">
                                        <asp:Panel ID="Panel_Advance" runat="server">
                                            <div align="center">
                                                <asp:GridView ID="gvCustomPay_Advance_fix" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    ForeColor="#333333" GridLines="Horizontal" AllowPaging="True" CssClass="table table-responsive"
                                                    Width="100%"
                                                    PageSize="20" OnRowCommand="gvCustomPay_RowCommand" DataKeyNames="id">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text="CDF Training Advance Payment"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                      
                                                         <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                       Rs.<asp:Label ID="lblamount1" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="Payment">
                                                            <ItemTemplate>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Button ID="btn_pay_Advance_fix" CssClass="btn btn-success btn-sm"
                                                                            runat="server" Text="click here to payment" CommandArgument='<%# Eval("Amount") + "," +  Eval("id")%>' CommandName="pay" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                    </Columns>
                                                    <RowStyle BackColor="#F7F6F3" VerticalAlign="Top" ForeColor="#333333" />
                                                    <EditRowStyle BackColor="#999999" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" VerticalAlign="Top" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" CssClass="GridPager" Wrap="True" />
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                </asp:GridView>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>--%>

                            <hr />
                            <div id="div_balance_payment" runat="server">
                                <div class="x_title">
                                    <h2>Balance Payment During Basic Training Program</h2>

                                    <div class="clearfix"></div>
                                </div>

                                 <%--Payment Details--%>
                                <asp:Panel ID="Panel_Balance" runat="server">
                                <div class="row_dis">
                                   <div class="column_dis" style=" float: left; margin-right: 6px;">
                                       <div class="card_dis" style="padding-bottom:8px; width:182px;">
                                           <h2><b style="font-size:16px; margin:auto">
                                               <asp:Label ID="Label1" runat="server" Text="Balance Payment"></asp:Label></b><br></h2>

                                           
                                               <p><b> <a><asp:Label ID="lblbalac_amt" runat="server"></asp:Label></a></b></p>
                                          
                                               
                                           
                                       </div>
                                   </div>
                                    <div>
                                        <asp:Button ID="btn_balance_payment" runat="server" class="btn btn-success" style="margin:22px" Text="Click here to payment" />
                                        <%--<button type="button" class="btn btn-success" style="margin:22px">Click here to payment</button>--%>

                                    </div>
                               </div>
                                </asp:Panel>

                                <%--<div class="x_content">
                                    <div class="form-horizontal" role="form" runat="server">
                                       
                                        <div class="x_content">
                                            <asp:Panel ID="Panel_Balance" runat="server" Enabled="false">
                                                <div align="center">
                                                    <asp:GridView ID="gvCustomPay_Balance" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        ForeColor="#333333" GridLines="Horizontal" AllowPaging="True" CssClass="table table-responsive"
                                                        Width="100%"
                                                        PageSize="20" OnRowCommand="gvCustomPay_RowCommand" DataKeyNames="id">
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text="Balance Payment"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                       

                                                     <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                       Rs.<asp:Label ID="lblamount2" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                            <asp:TemplateField HeaderText="Payment">
                                                                <ItemTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="btn_pay_Balance" CssClass="btn btn-success btn-sm"
                                                                                runat="server" Text="click here to payment" CommandArgument='<%# Eval("Amount") + "," +  Eval("id")%>' CommandName="pay" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                        </Columns>
                                                        <RowStyle BackColor="#F7F6F3" VerticalAlign="Top" ForeColor="#333333" />
                                                        <EditRowStyle BackColor="#999999" />
                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" VerticalAlign="Top" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" CssClass="GridPager" Wrap="True" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                    </asp:GridView>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                        </div>
                </div>
            </form>
        </div>
    </div>

    <!-- Custom Theme Scripts -->
    <script src="../js/custom.min.js"></script>
</asp:Content>

