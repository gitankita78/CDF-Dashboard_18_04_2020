<%@ Page Title="" Language="C#" MasterPageFile="~/CDFMaster.master" AutoEventWireup="true" CodeFile="Download_report_graph.aspx.cs" Inherits="CDF_Download_report_graph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <%-- <link href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" rel="stylesheet" />--%>
    <link href="../css/custom.min.css" rel="stylesheet" />

    <%-- Prevent cut , copy paste start code--%>
    <script
        src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Download Report and Graph</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>

                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>

                     



                    <div class="x_content">
                        <div class="panel panel-info">
                        <div class="panel-heading">You can download your Report and Graph</div>
                        <div class="panel-body">
                            
                            
                       
                        <br />
                        <div style="float:left;">
                            <asp:Button ID="btn_graph" runat="server" Text="Download Graph" OnClick="Button1_Click" class="btn btn-primary"/>
                        </div>
                        
                       
                        <div> 
                              <asp:Button ID="btn_report" runat="server" Text="Download Report" OnClick="btn_report_Click" class="btn btn-primary" />
                        </div>
                       
                         
                        </div>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </form>
     <!-- Custom Theme Scripts -->
    <script type="text/javascript" src="../js/custom.min.js"></script>
</asp:Content>

