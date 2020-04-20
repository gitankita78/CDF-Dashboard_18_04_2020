﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CDFMaster.master" CodeFile="CandidateReportsAndGraph.aspx.cs" Inherits="Candidate_CandidateReportsAndGraph" %>

<%@ Register TagPrefix="rjs" Namespace="RJS.Web.WebControl" Assembly="RJS.Web.WebControl.PopCalendar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .row {
            padding: 5px;
        }

        .panel {
            padding-bottom: 10px;
            text-align: center;
            max-width: 800px;
            margin-bottom: 30 auto;
        }
    </style>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <%-- <link href="../../datetimepicker/jquery.datepick.css" rel="stylesheet" />
    <script type="text/javascript" src="../datetimepicker/jquery.plugin.js"></script>
    <script type="text/javascript" src="../datetimepicker/jquery.datepick.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="Form1" class="form-horizontal" role="form" runat="server">

        <%--  <div class="panel panel-info">--%>

        <%--<div class="panel-heading ">
                <div class="panel-title text-center ">
                    Candidate Report And Graph
                </div>
            </div>--%>
        <div class="x_panel">
            <div class="x_title">
                <h2>Candidate Report And Graph</h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>

                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="x_content">

                <div class="row" style="padding-top: 20px;">
                    <div id="div1" runat="server" class=" alert alert-danger" style="text-align: center;"></div>
                    
                    <label for="name" class="col-sm-3 control-label text-right">
                        Type :
                    </label>
                    <div class="col-sm-8">
                        <asp:DropDownList ID="ddl_Type" runat="server" CssClass="form-control" SkinID="DropDown">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Report</asp:ListItem>
                            <asp:ListItem>Graph</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row" >
                    <div id="div_Error" runat="server" class=" alert alert-danger" style="text-align: center;" visible="false"></div>
                    <%--   <div class="row" style="margin-top: 20PX">--%>
                    <label for="name" class="col-sm-3 control-label text-right">
                        Test Status :
                    </label>
                    <div class="col-sm-8">
                        <asp:DropDownList ID="ddlCandTestStatus" runat="server" CssClass="form-control" SkinID="DropDown">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Complete</asp:ListItem>
                            <asp:ListItem>Not Complete</asp:ListItem>
                        </asp:DropDownList>

                        <%--   <span>
                            <select class="form-control" id="ddlCandTestStatus" name="Cand_Test_Status" tabindex="1">
                                <option selected="selected" value="0">--Select--</option>
                                <option value="1">Complete</option>
                                <option value="2">Not Complete</option>
                              
                            </select></span>--%>
                    </div>
                    <%--  <div class="col-sm-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCandTestStatus"
                                    Display="Dynamic" ErrorMessage="Please Select Candidate Test Status" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                          
            </div>--%>
                </div>
                <div class="row">
                    <label for="name" class="col-sm-3 control-label text-right">
                        Test Type :
                    </label>
                    <div class="col-sm-8">


                        <%--                                  <span>
                            <select class="form-control" id="ddltesttype" name="Cand_Test_Status" tabindex="1">
                                <option selected="selected" value="0">--Select--</option>
                                <option value="1">Corptest</option>
                                <option value="2">Personality</option>
                                 <option value="3">Teaching Test</option>
                                <option value="4">Non-Teaching Test</option>
                              
                            </select></span>--%>

                        <asp:DropDownList ID="ddltesttype" runat="server" CssClass="form-control" SkinID="DropDown">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Corptest</asp:ListItem>
                            <%--   <asp:ListItem>Personality Test</asp:ListItem>
                                    <asp:ListItem>Teaching Test</asp:ListItem>
                                    <asp:ListItem>Non-Teaching Test</asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                    <%--   <div class="col-sm-1">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddltesttype"
                                    Display="Dynamic" ErrorMessage="Please Select Test Type" InitialValue="--Select--">*</asp:RequiredFieldValidator>
                          
            </div>--%>
                </div>
                <div class="row">
                    <label for="name" class="col-sm-3 control-label text-right">
                        Name :
                    </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txt_name" placeholder="Candidate Name" class="form-control" runat="server"></asp:TextBox>
                        <%--       <input class="form-control" id="txtname" type="text" name="first_name" placeholder="Candidate Name"  />--%>
                    </div>
                    <div class="col-sm-1">
                    </div>
                </div>
                <div class="row">
                    <label for="username" class="col-sm-3 control-label text-right">
                        Username :
                    </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txt_username" placeholder="Candidate Username" class="form-control"
                            runat="server"></asp:TextBox>
                        <%--   <input class="form-control" id="txt_username" type="text" name="user_name" placeholder="Candidate Username"  />--%>
                    </div>
                    <div class="col-sm-1">
                    </div>
                </div>
                <div class="row">
                    <label for="city" class="col-sm-3 control-label text-right">
                        City :
                    </label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txt_city" placeholder="Candidate City" class="form-control"
                            runat="server"></asp:TextBox>
                        <%--                    <input class="form-control" id="txt_city" type="text" name="city_name" placeholder="Candidate City"  />--%>
                    </div>
                    <div class="col-sm-1">
                    </div>
                </div>

                <div class="row">
                    <label for="name" class="col-sm-3 control-label text-right">
                        Date :
                    </label>
                    <%--<div class="col-sm-4">--%>
                    <%--<asp:TextBox class="form-control" ID="tbDate1" runat="server" placeholder="From Date"></asp:TextBox>--%>
                    <%-- </div>--%>

                    <div class="col-sm-4">
                        <asp:TextBox ID="tbDate1" placeholder="From Date" class="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbDate1"
                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                            ErrorMessage="Invalid date format.">*</asp:RegularExpressionValidator>
                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers, Custom"
                            ValidChars="/" TargetControlID="tbDate1" />
                    </div>

                    <div class="col-sm-4">
                        <asp:TextBox ID="tbDate2" placeholder="To Date" class="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbDate2"
                            ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                            ErrorMessage="Invalid date format.">*</asp:RegularExpressionValidator>
                        <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers, Custom"
                            ValidChars="/" TargetControlID="tbDate2" />
                    </div>

                    <div class="col-sm-1">
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-4 col-sm-offset-3">
                        <asp:Button ID="btn_preview" runat="server" class="btn btn-info btn-block" Text="Preview" OnClick="btn_preview_Click" />

                        <%--   <input id="btn_preview" class="btn btn-primary btn-block"  name="Preview" value="Preview" /> --%>

                        <%--onclick="submit_form()"--%>
                    </div>
                    <%--   <div class="col-sm-4">
                <asp:Button ID="btn_export" runat="server" class="btn btn-info btn-block" 
                    Text="Export"/>           onclick="btn_export_Click"

             
            </div> --%>
                </div>
                <%--   <div class="row">
            <label class="control-label col-sm-3">
               Bulk Download :</label><div class="col-sm-4">
                <asp:TextBox ID="txt_start" placeholder="Start C_ID" class="form-control" runat="server"></asp:TextBox>
            </div>
           
            <div class="col-sm-4">
                <asp:TextBox ID="txt_end" placeholder="End C_ID" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_start"
                    Display="Dynamic" ErrorMessage="Please Enter Start C_ID" InitialValue=""
                    ValidationGroup="bulkdownload">*</asp:RequiredFieldValidator>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_end"
                    Display="Dynamic" ErrorMessage="Please Enter End C_ID" InitialValue=""
                    ValidationGroup="bulkdownload">*</asp:RequiredFieldValidator>
            </div>
        </div>--%>
                <%--    <div class="row">
          <div class="col-sm-4">
            </div>
            <div class="col-sm-5">
                <asp:Button ID="btn_bulk_download" runat="server" class="btn btn-info btn-block"
                    Text="Bulk Download" ValidationGroup="bulkdownload" /> 
            </div>
        </div>--%>
                <div class="row">
                </div>
                <div class="">
                    <asp:Label ID="lbl_rowcount" class="control-label col-sm-4" runat="server" Text=""></asp:Label>
                    <div class="">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="GridView1_RowCommand"
                            ForeColor="#333333" GridLines="None" AllowPaging="True" CssClass="table"
                            Width="100%" DataKeyNames="c_id"
                            PageSize="15" AllowSorting="True">
                            <%--OnPageIndexChanging="GridView1_PageIndexChanging"  OnDataBound="GridView1_DataBound"  OnRowDataBound="GridView1_RowDataBound" --%>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="c_username" HeaderText="UserName" SortExpression="c_username" />
                                <%--  <asp:BoundField DataField="c_password" HeaderText="Password" SortExpression="c_password" />--%>
                                <asp:BoundField DataField="promotional_code" HeaderText="AuthCode" SortExpression="promotional_code" />
                                <asp:BoundField DataField="c_first_name" HeaderText="First Name" SortExpression="c_first_name" />
                                <asp:BoundField DataField="c_last_name" HeaderText="Last Name" SortExpression="c_last_name" />
                                <asp:BoundField DataField="c_gender" HeaderText="Gender" SortExpression="c_gender" />
                                <asp:BoundField DataField="c_age_years" HeaderText="Age" SortExpression="c_age_years" />
                                <%--  <asp:BoundField DataField="c_DOB" HeaderText="DOB" SortExpression="c_DOB" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />--%>
                                <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                <asp:BoundField DataField="c_date_of_reg" HeaderText="Date_of_Reg" SortExpression="c_date_of_reg"
                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />

                                <asp:TemplateField HeaderText="View Graph">

                                    <ItemTemplate>

                                        <asp:LinkButton ID="lnkView" Text="View" runat="server" CommandName="ViewTest"
                                            CommandArgument='<%#Eval("c_id") %>' />

                                        <%--   <a href ="#" title ="Update" onclick="return jsPopup('CandidateReportsAndGraph.aspx?c_id=<%#Eval("c_id")%> '); "> Update</a>--%>
                                        <%-- <asp:HyperLink ID="hlView" runat="server" Target="_blank"  NavigateUrl='<%# Eval("c_id") %>'> View </asp:HyperLink>--%>
                                        <%--  <asp:HyperLink ID="hlView"  runat="server" NavigateUrl='<%# Eval("c_id") %>'>View</asp:HyperLink>--%>
                                        <asp:HyperLink ID="hldownload" runat="server" NavigateUrl='<%# Eval("c_id", "DownloadGraph.aspx?c_id={0}") %>'>Download</asp:HyperLink>
                                        

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" Download Report">
                                    <ItemTemplate>
                                        <%--<asp:HyperLink ID="Full_Report" runat="server" NavigateUrl='<%# Eval("c_id", "~/Candidate/sales_report.aspx?c_id={0}") %>'
                                        CssClass="bodytext">CompetencyReport</asp:HyperLink>--%>
                                        <asp:HyperLink ID="PDReport" runat="server" NavigateUrl='<%# Eval("c_id", "~/Candidate/PDReport.aspx?c_id={0}") %>'>PDReport</asp:HyperLink>
                                        <asp:HyperLink ID="Print_Report" runat="server" NavigateUrl='<%# Eval("c_id", "~/Candidate/Reportforprint.aspx?c_id={0}") %>'
                                            CssClass="bodytext">ReportForPrint</asp:HyperLink>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" VerticalAlign="Top" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" VerticalAlign="Top" />
                            <PagerStyle BackColor="#2461BF" HorizontalAlign="Center"
                                Font-Bold="True" CssClass="pagination-ys" Wrap="True" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </div>
                </div>
            </div>


        </div>
        <%--  </div>--%>
    </form>

    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#ctl00_ContentPlaceHolder1_tbDate1").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                yearRange: "-90:+00"
            });

            $("#ctl00_ContentPlaceHolder1_tbDate2").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                yearRange: "-90:+00"
            });

        });
    </script>

    <!-- Custom Theme Scripts -->
    <script type="text/javascript" src="../js/custom.min.js"></script>

</asp:Content>
