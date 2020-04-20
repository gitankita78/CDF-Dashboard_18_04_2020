using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using System.Reflection;
using WebChart;
using System.Drawing;
using System.Data;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Text.RegularExpressions;
using log4net;
using System;
using System.Configuration;

public partial class CDF_CDF_Graphs : System.Web.UI.Page
{
   
    string name = "", username = "", age = "";
    string strcmd;
    private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    int c_id = 0;
    // Declare parameters to use for assessment
    int BlackM;
    int BlackL;
    int BlueM;
    int BlueL;
    int RedM;
    int RedL;
    int GreenM;
    int GreenL;
    int Hole;
    int DiffB;
    int DiffR;
    int DiffBl;
    int DiffG;
    MobileDAL dal = new MobileDAL();
    Document doc = new Document();
    int batid = 3;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                #region load Graph

                //c_id = Convert.ToInt32(Request.QueryString["c_id"]);
                c_id = Convert.ToInt32(Session["uid"].ToString());

                if (c_id > 0)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {

                        //Get Personal Details
                        strcmd = "SELECT fname,lname,(DATEPART(yyyy,regDateTime)-DATEPART(yyyy,dob)) as age,email FROM tblUserMaster where uId=" + c_id;
                        SqlCommand cmdinfo = new SqlCommand(strcmd, con);
                        con.Open();
                        SqlDataReader sdruserinfo = cmdinfo.ExecuteReader();
                        if (sdruserinfo.HasRows)
                        {
                            sdruserinfo.Read();
                            name = sdruserinfo["fname"].ToString() + " " + sdruserinfo["lname"].ToString();
                            age = sdruserinfo["age"].ToString();
                            username = sdruserinfo["email"].ToString();

                            lbl_name.Text = name;
                            lbl_username.Text = "Username - " + username;
                            lbl_age.Text = "Age - " + age;

                            sdruserinfo.Close();

                            //lblCand_name.Text = Session["cand_name"].ToString();
                            Boolean flag = dal.get_values(c_id, batid);
                            if (flag)
                            {
                                BlueM = dal.BLUEM;
                                BlueL = dal.BLUEL;
                                RedM = dal.REDM;
                                RedL = dal.REDL;
                                BlackM = dal.BLACKM;
                                BlackL = dal.BLACKL;
                                GreenM = dal.GREENM;
                                GreenL = dal.GREENL;
                                Hole = dal.HOLE;

                                DiffB = BlueM - BlueL;
                                DiffR = RedM - RedL;
                                DiffBl = BlackM - BlackL;
                                DiffG = GreenM - GreenL;

                                lblBM.Text = Convert.ToString(BlueM);
                                lblBL.Text = Convert.ToString(BlueL);
                                lblRM.Text = Convert.ToString(RedM);
                                lblRL.Text = Convert.ToString(RedL);
                                lblBlM.Text = Convert.ToString(BlackM);
                                lblBlL.Text = Convert.ToString(BlackL);
                                lblGM.Text = Convert.ToString(GreenM);
                                lblGL.Text = Convert.ToString(GreenL);
                                lblDiffB.Text = Convert.ToString(DiffB);
                                lblDiffR.Text = Convert.ToString(DiffR);
                                lblDiffBl.Text = Convert.ToString(DiffBl);
                                lblDiffG.Text = Convert.ToString(DiffG);
                                lblTotal.Text = Convert.ToString(Hole);

                                //  CreateChart1();
                                LineChart chart1 = new LineChart();
                                chart1.Fill.Color = System.Drawing.Color.FromArgb(50, System.Drawing.Color.SteelBlue);
                                chart1.Line.Color = System.Drawing.Color.SteelBlue;
                                chart1.Line.Width = 2;

                                dal.set_values();
                                BlueM = dal.DM;
                                RedM = dal.IM;
                                BlackM = dal.SM;
                                GreenM = dal.CM;

                                chart1.Legend = "RAPD GRAPH 1 information";
                                chart1.Data.Add(new ChartPoint("R", BlueM));
                                chart1.Data.Add(new ChartPoint("A", RedM));
                                chart1.Data.Add(new ChartPoint("P", BlackM));
                                chart1.Data.Add(new ChartPoint("D", GreenM));


                                ConfigureColors1();

                                ChartControl1.Charts.Add(chart1);
                                ChartControl1.RedrawChart();

                                //  CreateChart2();

                                LineChart chart2 = new LineChart();
                                chart2.Fill.Color = System.Drawing.Color.FromArgb(50, System.Drawing.Color.SteelBlue);
                                chart2.Line.Color = System.Drawing.Color.SteelBlue;
                                chart2.Line.Width = 2;

                                dal.set_values();
                                BlueL = dal.DL;
                                RedL = dal.IL;
                                BlackL = dal.SL;
                                GreenL = dal.CL;

                                chart2.Legend = "RAPD GRAPH 2 information";
                                chart2.Data.Add(new ChartPoint("R", BlueL));
                                chart2.Data.Add(new ChartPoint("A", RedL));
                                chart2.Data.Add(new ChartPoint("P", BlackL));
                                chart2.Data.Add(new ChartPoint("D", GreenL));

                                ConfigureColors2();
                                ChartControl2.Charts.Add(chart2);
                                ChartControl2.RedrawChart();

                                //CreateChart3();
                                LineChart chart3 = new LineChart();
                                chart3.Fill.Color = System.Drawing.Color.FromArgb(50, System.Drawing.Color.SteelBlue);
                                chart3.Line.Color = System.Drawing.Color.SteelBlue;
                                chart3.Line.Width = 2;

                                dal.set_values();
                                DiffB = dal.DD;
                                DiffR = dal.ID;
                                DiffBl = dal.SD;
                                DiffG = dal.CD;

                                chart3.Legend = "RAPD GRAPH 3 information";
                                chart3.Data.Add(new ChartPoint("R", DiffB));
                                chart3.Data.Add(new ChartPoint("A", DiffR));
                                chart3.Data.Add(new ChartPoint("P", DiffBl));
                                chart3.Data.Add(new ChartPoint("D", DiffG));

                                ConfigureColors3();

                                ChartControl3.Charts.Add(chart3);
                                ChartControl3.RedrawChart();


                                strcmd = "SELECT * FROM tblCandRAPDScore WHERE c_id=" + c_id;
                                SqlCommand cmdRAPD = new SqlCommand(strcmd, con);
                                SqlDataReader sdrRAPD = cmdRAPD.ExecuteReader();
                                if (sdrRAPD.HasRows)
                                {
                                    sdrRAPD.Close();
                                    SqlCommand updateRAPD = new SqlCommand("update tblCandRAPDScore set Rscore=@Rscore,Ascore=@Ascore,Pscore=@Pscore,Dscore=@Dscore where c_id=@c_id", con);
                                    updateRAPD.Parameters.AddWithValue("@c_id", c_id);
                                    updateRAPD.Parameters.AddWithValue("@Rscore", DiffB);
                                    updateRAPD.Parameters.AddWithValue("@Ascore", DiffR);
                                    updateRAPD.Parameters.AddWithValue("@Pscore", DiffBl);
                                    updateRAPD.Parameters.AddWithValue("@Dscore", DiffG);
                                    int intEffectedRows = updateRAPD.ExecuteNonQuery();
                                }
                                else
                                {
                                    sdrRAPD.Close();

                                    SqlCommand updateRAPD = new SqlCommand("insert into tblCandRAPDScore (c_id,Rscore,Ascore,Pscore,Dscore) values(@c_id,@Rscore,@Ascore,@Pscore,@Dscore)", con);
                                    updateRAPD.Parameters.AddWithValue("@Rscore", DiffB);
                                    updateRAPD.Parameters.AddWithValue("@Ascore", DiffR);
                                    updateRAPD.Parameters.AddWithValue("@Pscore", DiffBl);
                                    updateRAPD.Parameters.AddWithValue("@Dscore", DiffG);
                                    updateRAPD.Parameters.AddWithValue("@c_id", c_id);
                                    int intEffectedRows = updateRAPD.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                Log.Warn("Something went wrong");
                                Response.Redirect("ErrorPage.aspx", false);
                            }
                        }
                        else
                        {
                            Log.Warn("User Not Registered");
                            Response.Redirect("ErrorPage.aspx", false);
                        }
                    }
                }
                #endregion

                #region Graph_page
                //cover page of docoment.
                doc.NewPage();
                PdfWriter.GetInstance(doc, new FileStream(Server.MapPath(".") + "/Reports_pdf/Graph_" + name.Replace(' ', '_') + ".pdf", FileMode.Create));
                doc.Open();

                iTextSharp.text.Image dheyalogo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/ReportImages/LOGO-NEW.png"));
                //jpeg.ScalePercent(35f);
                dheyalogo.ScaleToFit(50f, 50f);
                dheyalogo.SetAbsolutePosition(30, 25);
                // jpeg.SpacingAfter = -50f;
                doc.Add(dheyalogo);

                Paragraph headname = new Paragraph(name, FontFactory.GetFont("Arial", 18, iTextSharp.text.Color.BLACK));
                headname.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                doc.Add(headname);

                headname = new Paragraph("Username :- " + username + "   Age :- " + age, FontFactory.GetFont("Arial", 16, iTextSharp.text.Color.BLACK));
                headname.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                doc.Add(headname);

                headname = new Paragraph("Personality Test", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER));
                headname.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                doc.Add(headname);

                headname = new Paragraph("Following is the result of Personality Test", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.COURIER));
                headname.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                doc.Add(headname);


                iTextSharp.text.Table PDTopTable2 = new iTextSharp.text.Table(4);
                PDTopTable2.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                PDTopTable2.Width = 50;
                PDTopTable2.Padding = 1;
                PDTopTable2.AddCell(new Cell(new Paragraph(" ", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  M", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  L", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  DIFF", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  R", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblBM.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblBL.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblDiffB.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  A", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblRM.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblRL.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblDiffR.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  P", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblBlM.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblBlL.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblDiffBl.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  D", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblGM.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblGL.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + lblDiffG.Text, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  ", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  Total", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph("  " + Hole, FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));
                PDTopTable2.AddCell(new Cell(new Paragraph(" ", FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.COURIER))));


                doc.Add(PDTopTable2);
                headname = new Paragraph(" Following are the resultant graphs of Personality Test", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.COURIER));
                headname.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                doc.Add(headname);

                iTextSharp.text.Table PDTopTable1 = new iTextSharp.text.Table(3);
                PDTopTable1.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                PDTopTable1.Width = 100;

                iTextSharp.text.Image graph1 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/WebCharts/" + ChartControl1.ImageID + ".png"));
                PDTopTable1.AddCell(new Cell(graph1));

                iTextSharp.text.Image graph2 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/WebCharts/" + ChartControl2.ImageID + ".png"));
                PDTopTable1.AddCell(new Cell(graph2));

                iTextSharp.text.Image graph3 = iTextSharp.text.Image.GetInstance(Server.MapPath("~/WebCharts/" + ChartControl3.ImageID + ".png"));
                PDTopTable1.AddCell(new Cell(graph3));

                doc.Add(PDTopTable1);
                doc.Close();
                #endregion

                DownloadFile("Graph_" + name.Replace(' ', '_') + ".pdf", true);


            }
            catch (System.Threading.ThreadAbortException tae)
            {
            }
            catch (Exception ex)
            {
                Log.Error("" + ex);
                // Response.Redirect("ErrorPage.aspx", false);
            }
        }
    }

    private void DownloadFile(string fname, bool forceDownload)
    {
        string path = Server.MapPath("./Reports_pdf/" + fname);
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
            }
        }
        if (forceDownload)
        {
            Response.AppendHeader("content-disposition",
                "attachment; filename=" + name);

            //Response.AppendHeader("content-disposition",
            //                " inline; attachment; filename=" + name + ".pdf");
        }
        if (type != "")
            Response.ContentType = type;
        Response.WriteFile(path);
        Response.End();
    }

    private void ConfigureColors1()
    {
        ChartControl1.Background.Color = System.Drawing.Color.FromArgb(75, System.Drawing.Color.SteelBlue);
        ChartControl1.Background.Type = InteriorType.LinearGradient;
        ChartControl1.Background.ForeColor = System.Drawing.Color.SteelBlue;
        ChartControl1.Background.EndPoint = new Point(500, 350);
        ChartControl1.Legend.Position = LegendPosition.Bottom;
        ChartControl1.Legend.Width = 40;

        ChartControl1.YAxisFont.ForeColor = System.Drawing.Color.SteelBlue;
        ChartControl1.XAxisFont.ForeColor = System.Drawing.Color.SteelBlue;

        ChartControl1.ChartTitle.Text = "HOW OTHERS SEE YOU";
        ChartControl1.ChartTitle.ForeColor = System.Drawing.Color.White;

        ChartControl1.Border.Color = System.Drawing.Color.SteelBlue;
        ChartControl1.BorderStyle = BorderStyle.Ridge;


    }

    private void ConfigureColors2()
    {

        ChartControl2.Background.Color = System.Drawing.Color.FromArgb(75, System.Drawing.Color.SteelBlue);
        ChartControl2.Background.Type = InteriorType.LinearGradient;
        ChartControl2.Background.ForeColor = System.Drawing.Color.SteelBlue;
        ChartControl2.Background.EndPoint = new Point(500, 350);
        ChartControl2.Legend.Position = LegendPosition.Bottom;
        ChartControl2.Legend.Width = 40;

        ChartControl2.YAxisFont.ForeColor = System.Drawing.Color.SteelBlue;
        ChartControl2.XAxisFont.ForeColor = System.Drawing.Color.SteelBlue;

        ChartControl2.ChartTitle.Text = "BEHAVIOUR UNDER PRESSURE";
        ChartControl2.ChartTitle.ForeColor = System.Drawing.Color.White;

        ChartControl2.Border.Color = System.Drawing.Color.SteelBlue;
        ChartControl2.BorderStyle = BorderStyle.Ridge;
    }

    private void ConfigureColors3()
    {
        ChartControl3.Background.Color = System.Drawing.Color.FromArgb(75, System.Drawing.Color.SteelBlue);
        ChartControl3.Background.Type = InteriorType.LinearGradient;
        ChartControl3.Background.ForeColor = System.Drawing.Color.SteelBlue;
        ChartControl3.Background.EndPoint = new Point(500, 350);
        ChartControl3.Legend.Position = LegendPosition.Bottom;
        ChartControl3.Legend.Width = 40;

        ChartControl3.YAxisFont.ForeColor = System.Drawing.Color.SteelBlue;
        ChartControl3.XAxisFont.ForeColor = System.Drawing.Color.SteelBlue;

        ChartControl3.ChartTitle.Text = "HOW YOU SEE YOURSELF";
        ChartControl3.ChartTitle.ForeColor = System.Drawing.Color.White;

        ChartControl3.Border.Color = System.Drawing.Color.SteelBlue;
        ChartControl3.BorderStyle = BorderStyle.Ridge;
    }


}