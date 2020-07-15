using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class CDF_my_documents : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //
                string query_docstatus = "select idcard ,certificate ,visitingCard ,ndaCopy,childTestStatus,childSessionStatus,spouseTestStatus,shadowSession From tblUserDetails where uId='" + Session["uid"].ToString() + "'";
                SqlCommand cmd = new SqlCommand(query_docstatus, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                //Check if table has rows for required query
                if (dr.HasRows)
                {

                    dr.Read();
                    string strr = Convert.ToString(dr["idcard"]);
                    if (Convert.ToString(dr["idcard"]) == "True")
                    {
                        lbl_idcard.Text = "Received";
                    }
                    else
                    {
                        lbl_idcard.Text = "Pending";
                    }
                    if (Convert.ToString(dr["certificate"]) == "True")
                    {
                        lbl_certificate.Text = "Received";
                    }
                    else
                    {
                        lbl_certificate.Text = "Pending";
                    }
                    if (Convert.ToString(dr["visitingCard"]) == "True")
                    {
                        lbl_visitingcard.Text = "Received";
                    }
                    else
                    {
                        lbl_visitingcard.Text = "Pending";
                    }
                    if (Convert.ToString(dr["ndaCopy"]) == "True")
                    {
                        lbl_ndacopy.Text = "Received";
                    }
                    else
                    {
                        lbl_ndacopy.Text = "Pending";
                    }
                    if (Convert.ToString(dr["childTestStatus"]) == "True")
                    {
                        lbl_childTest.Text = "Complete";
                    }
                    else
                    {
                        lbl_childTest.Text = "Pending";
                    }
                    if (Convert.ToString(dr["childSessionStatus"]) == "True")
                    {
                        lbl_childSession.Text = "Complete";
                    }
                    else
                    {
                        lbl_childSession.Text = "Pending";
                    }
                    if (Convert.ToString(dr["spouseTestStatus"]) == "True")
                    {
                        lbl_spouseTest.Text = "Complete";
                    }
                    else
                    {
                        lbl_spouseTest.Text = "Pending";
                    }
                    if (Convert.ToString(dr["shadowSession"]) != "")
                    {
                        lbl_shadowSessions.Text = dr["shadowSession"].ToString();
                    }
                    else
                    {
                        lbl_shadowSessions.Text = "0";
                    }
                }

            }
        }
        else
        { }
    }

    protected void btn_dwn1_Click(object sender, EventArgs e)
    {
        //Response.Write("click event");

        //finding path of img upload
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            //
            string query_docstatus = "select cdf_idcard From tblUserDetails where uId='" + Session["uid"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(query_docstatus, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            //Check if table has rows for required query
            if (dr.HasRows)
            {
              dr.Read();
             string idname = Convert.ToString(dr["cdf_idcard"]);
                if(idname!="")
                {
                    DownloadFile(idname, true);
                }
                else
                {
                    lblmsg.Text="ID card not uploaded";
                }
             


            }
            else
            {
                Response.Write("no file");

            }
        }
    }

    private void DownloadFile(string fname, bool forceDownload)
    { 
        string path = Server.MapPath(ConfigurationManager.AppSettings["CDF_Idcard"] + fname);

        //test_doc
        //string path = Server.MapPath("~/"+ ConfigurationManager.AppSettings["docfolderpath_test"] + fname);


        string name = Path.GetFileName(path);
        string ext = Path.GetExtension(path);
        string type = "";
        // set known types based on file extension  
        if (ext != null)
        {
            switch (ext.ToLower())
            {
                case ".htm":
                case ".html":
                    type = "text/HTML";
                    break;

                case ".txt":
                    type = "text/plain";
                    break;

                case ".doc":
                case ".rtf":
                    type = "Application/msword";
                    break;

                case ".pdf":
                    type = "Application/pdf";
                    break;

                case ".png":
                    type = "image/png";
                    break;

                case ".jpg":
                    type = "image/jpg";
                    break;


            }
        }
        if (forceDownload)
        {
            Response.AppendHeader("content-disposition", "attachment; filename=" + name.Replace(' ', '_'));
        }
        if (type != "")
            Response.ContentType = type;
        Response.WriteFile(path);
        Response.End();
    }

    protected void btn_dwn2_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            //
            string query_docstatus = "select cdf_certif From tblUserDetails where uId='" + Session["uid"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(query_docstatus, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            //Check if table has rows for required query
            if (dr.HasRows)
            {
                dr.Read();
                string idname = Convert.ToString(dr["cdf_certif"]);
                if (idname != "")
                {
                    DownloadFile_1(idname, true);
                }
                else
                {
                    lblmsg.Text = "Certificate not uploaded";
                }



            }
            else
            {
                Response.Write("no file");

            }
        }
    }

    private void DownloadFile_1(string fname, bool forceDownload)
    {
        string path = Server.MapPath(ConfigurationManager.AppSettings["CDF_certif"] + fname);

        //test_doc
        //string path = Server.MapPath("~/"+ ConfigurationManager.AppSettings["docfolderpath_test"] + fname);


        string name = Path.GetFileName(path);
        string ext = Path.GetExtension(path);
        string type = "";
        // set known types based on file extension  
        if (ext != null)
        {
            switch (ext.ToLower())
            {
                case ".htm":
                case ".html":
                    type = "text/HTML";
                    break;

                case ".txt":
                    type = "text/plain";
                    break;

                case ".doc":
                case ".rtf":
                    type = "Application/msword";
                    break;

                case ".pdf":
                    type = "Application/pdf";
                    break;

                case ".png":
                    type = "image/png";
                    break;

                case ".jpg":
                    type = "image/jpg";
                    break;


            }
        }
        if (forceDownload)
        {
            Response.AppendHeader("content-disposition", "attachment; filename=" + name.Replace(' ', '_'));
        }
        if (type != "")
            Response.ContentType = type;
        Response.WriteFile(path);
        Response.End();
    }

    protected void btn_dwn3_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            //
            string query_docstatus = "select cdf_visiting_card From tblUserDetails where uId='" + Session["uid"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(query_docstatus, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            //Check if table has rows for required query
            if (dr.HasRows)
            {
                dr.Read();
                string idname = Convert.ToString(dr["cdf_visiting_card"]);
                if (idname != "")
                {
                    DownloadFile_2(idname, true);
                }
                else
                {
                    lblmsg.Text = "Visiting card not uploaded";
                }



            }
            else
            {
                Response.Write("no file");

            }
        }

    }

    private void DownloadFile_2(string fname, bool forceDownload)
    {
        string path = Server.MapPath(ConfigurationManager.AppSettings["CDF_visit"] + fname);

        //test_doc
        //string path = Server.MapPath("~/"+ ConfigurationManager.AppSettings["docfolderpath_test"] + fname);


        string name = Path.GetFileName(path);
        string ext = Path.GetExtension(path);
        string type = "";
        // set known types based on file extension  
        if (ext != null)
        {
            switch (ext.ToLower())
            {
                case ".htm":
                case ".html":
                    type = "text/HTML";
                    break;

                case ".txt":
                    type = "text/plain";
                    break;

                case ".doc":
                case ".rtf":
                    type = "Application/msword";
                    break;

                case ".pdf":
                    type = "Application/pdf";
                    break;

                case ".png":
                    type = "image/png";
                    break;

                case ".jpg":
                    type = "image/jpg";
                    break;


            }
        }
        if (forceDownload)
        {
            Response.AppendHeader("content-disposition", "attachment; filename=" + name.Replace(' ', '_'));
        }
        if (type != "")
            Response.ContentType = type;
        Response.WriteFile(path);
        Response.End();
    }
}