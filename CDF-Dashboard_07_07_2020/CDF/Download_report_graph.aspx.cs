using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CDF_Download_report_graph : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CDF_Graphs.aspx",false);
    }

    protected void btn_report_Click(object sender, EventArgs e)
    {
        Response.Redirect("CDF_reports.aspx", false);
    }
}