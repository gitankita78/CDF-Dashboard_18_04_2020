using System;
using System.Configuration;
using System.Collections;
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

public partial class Graph_Report_ViewGraph_new : System.Web.UI.Page
{

    db_Xaction clsXaction = new db_Xaction();
    dal clsdal = new dal();
    int cccc = 0;
    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //check the user type 
    //        if (Session.Count > 0 && Session["user_type"].ToString().Equals("Admin"))
    //            this.Page.MasterPageFile = "~/AdminMaster.master";
    //        else
    //            this.Page.MasterPageFile = "~/StaffMasterPage.master";
    //    }
    //    catch (Exception ex)
    //    {
    //        this.Page.MasterPageFile = "~/AdminMaster.master";
    //    }

    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count > 0)
        //{

        int c_id;

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
        string strcmd;


        //////////////// end new changes //////////////


        //c_id = Convert.ToInt32(dataall.Tables[0].Rows[i][0].ToString());

        c_id = Convert.ToInt32(Request.QueryString["c_id"]);

        strcmd = "select c_first_name,c_last_name,c_middle_Name from tbl_candidate_master where c_id = " + c_id;

        DataSet ds = clsXaction.ExecDataSet_maintest(strcmd);
        lbl_name.Text = ds.Tables[0].Rows[0][0].ToString() + " " + ds.Tables[0].Rows[0][2].ToString() + " " + ds.Tables[0].Rows[0][1].ToString();

        //lblCand_name.Text = Session["cand_name"].ToString();
        int id = clsXaction.get_values_maintest(c_id);
        BlueM = clsXaction.BLUEM;
        BlueL = clsXaction.BLUEL;
        RedM = clsXaction.REDM;
        RedL = clsXaction.REDL;
        BlackM = clsXaction.BLACKM;
        BlackL = clsXaction.BLACKL;
        GreenM = clsXaction.GREENM;
        GreenL = clsXaction.GREENL;
        Hole = clsXaction.HOLE;

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
        /////////////////// het function in side///


        LineChart chart1 = new LineChart();
        chart1.Fill.Color = Color.FromArgb(50, Color.SteelBlue);
        chart1.Line.Color = Color.SteelBlue;
        chart1.Line.Width = 2;

        clsXaction.set_values_maintest();
        BlueM = clsXaction.DM;
        RedM = clsXaction.IM;
        BlackM = clsXaction.SM;
        GreenM = clsXaction.CM;

        chart1.Legend = "RAPD GRAPH 1 information";
        chart1.Data.Add(new ChartPoint("R", BlueM));
        chart1.Data.Add(new ChartPoint("A", RedM));
        chart1.Data.Add(new ChartPoint("P", BlackM));
        chart1.Data.Add(new ChartPoint("D", GreenM));


        ConfigureColors1();

        ChartControl1.Charts.Add(chart1);
        ChartControl1.RedrawChart();

        ////////////end function

        //  CreateChart2();
        /////////////////// inside function 2


        LineChart chart2 = new LineChart();
        chart2.Fill.Color = Color.FromArgb(50, Color.SteelBlue);
        chart2.Line.Color = Color.SteelBlue;
        chart2.Line.Width = 2;

        clsXaction.set_values_maintest();
        BlueL = clsXaction.DL;
        RedL = clsXaction.IL;
        BlackL = clsXaction.SL;
        GreenL = clsXaction.CL;

        chart2.Legend = "RAPD GRAPH 2 information";
        chart2.Data.Add(new ChartPoint("R", BlueL));
        chart2.Data.Add(new ChartPoint("A", RedL));
        chart2.Data.Add(new ChartPoint("P", BlackL));
        chart2.Data.Add(new ChartPoint("D", GreenL));

        ConfigureColors2();
        ChartControl2.Charts.Add(chart2);
        ChartControl2.RedrawChart();



        /////////////// end function

        //CreateChart3();

        ////////////////////////////// third function inside 

        LineChart chart3 = new LineChart();
        chart3.Fill.Color = Color.FromArgb(50, Color.SteelBlue);
        chart3.Line.Color = Color.SteelBlue;
        chart3.Line.Width = 2;

        clsXaction.set_values_maintest();
        DiffB = clsXaction.DD;
        DiffR = clsXaction.ID;
        DiffBl = clsXaction.SD;
        DiffG = clsXaction.CD;


        chart3.Legend = "RAPD GRAPH 3 information";
        chart3.Data.Add(new ChartPoint("R", DiffB));
        chart3.Data.Add(new ChartPoint("A", DiffR));
        chart3.Data.Add(new ChartPoint("P", DiffBl));
        chart3.Data.Add(new ChartPoint("D", DiffG));




        String StrSql = "";
        StrSql = "SELECT * FROM tbl_candidate_RAPD_Score WHERE c_id='" + c_id + "'";
        DataSet DsDup = clsdal.ExecDataSet_mainTest(StrSql);
        StrSql = "";
        if (DsDup.Tables[0].Rows.Count == 0)
        {

            StrSql = "INSERT INTO tbl_candidate_RAPD_Score VALUES ( " + c_id + "," + DiffB + ", " + DiffR + "," + DiffBl + "," + DiffG + ")";
            int ie = clsdal.ExecNonQuery_maintest(StrSql);
            cccc++;
        }
        else
        {
            StrSql = "update tbl_candidate_RAPD_Score set Rscore=" + DiffB + ", Ascore=" + DiffR + ",Pscore=" + DiffBl + ",Dscore=" + DiffG + " where c_id=" + c_id;
            int ie = clsdal.ExecNonQuery_maintest(StrSql);
        }


        DsDup.Clear();
        DsDup.Dispose();

        ConfigureColors3();

        ChartControl3.Charts.Add(chart3);
        ChartControl3.RedrawChart();


        ////////////////// end function 


        //}
        int cccdc = cccc;
        /////////////////////// get ability factors to show 

        //String getabilityfactor = "SELECT ability_code as Ability , P_rating,rating  FROM tbl_candidate_test_results WHERE (c_id = '" + c_id + "')";
        //String getabilityfactor = "SELECT distinct ability_code as Ability , P_rating,rating  FROM tbl_candidate_test_results WHERE (c_id = '" + c_id + "')";

        //DataSet dsgetabilityfactor = clsXaction.ExecDataSet(getabilityfactor);
        //GridView2.DataSource = dsgetabilityfactor;
        //GridView2.DataBind();


        /////////////////////// get parsonality factors to show 

        //String getpersonalityfactor = "SELECT  CASE WHEN factor_no = 1 THEN 'Relationships' WHEN factor_no = 2 THEN 'Emotional Stability' WHEN factor_no = 3 THEN 'Assertiveness' WHEN factor_no = 4 THEN 'Enthusiasm' WHEN factor_no = 5 THEN 'Conscientious' WHEN factor_no = 6 THEN 'Responsiveness' WHEN factor_no = 7 THEN 'Tough Minded' WHEN factor_no = 8 THEN 'Self Assurance' WHEN factor_no = 9 THEN 'Relaxed' END AS Personality, P_rating, rating FROM tbl_KY_cand_factors WHERE        (c_id = '" + c_id + "') ORDER BY P_rating DESC";

        //DataSet dsgetpersonalityfactor = clsXaction.ExecDataSet(getpersonalityfactor);
        //GridView1.DataSource = dsgetpersonalityfactor;
        //GridView1.DataBind();

        /////////////////////// get INTEREST factors to show 

        //String getINTERESTfactor = "SELECT tbl_II_factors.name AS Interests, P_rating,rating FROM tbl_II_cand_factors,tbl_II_factors where tbl_II_cand_factors.factor_no=tbl_II_factors.factor_no and c_id = '" + c_id + "' order by P_rating desc";

        //DataSet dsgetINTERESTfactor = clsXaction.ExecDataSet(getINTERESTfactor);
        //GridView3.DataSource = dsgetINTERESTfactor;
        //GridView3.DataBind();


        ///////// insert profiler
        //clsXaction.insertprofiler(c_id);


        // get ocupectional catagary and profiler


        //String getocupectionalcatagary = "SELECT A.ocu1, A.ocu2, A.ocu3, A.ocu1score, A.ocu2score, A.ocu3score, A.Disc_candition FROM tbl_cand_ocupational_catagary AS A WHERE (A.cid  = '" + c_id + "') ";

        //DataSet dsgetocupectionalcatagary = clsXaction.ExecDataSet(getocupectionalcatagary);
        //GridView4.DataSource = dsgetocupectionalcatagary;
        //GridView4.DataBind();



        //}
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("default.aspx");
        //}

    }
    private void ConfigureColors1()
    {
        ChartControl1.Background.Color = Color.FromArgb(75, Color.SteelBlue);
        ChartControl1.Background.Type = InteriorType.LinearGradient;
        ChartControl1.Background.ForeColor = Color.SteelBlue;
        ChartControl1.Background.EndPoint = new Point(500, 350);
        ChartControl1.Legend.Position = LegendPosition.Bottom;
        ChartControl1.Legend.Width = 40;

        ChartControl1.YAxisFont.ForeColor = Color.SteelBlue;
        ChartControl1.XAxisFont.ForeColor = Color.SteelBlue;

        ChartControl1.ChartTitle.Text = "HOW OTHERS SEE YOU";
        ChartControl1.ChartTitle.ForeColor = Color.White;

        ChartControl1.Border.Color = Color.SteelBlue;
        ChartControl1.BorderStyle = BorderStyle.Ridge;


    }

    private void ConfigureColors2()
    {

        ChartControl2.Background.Color = Color.FromArgb(75, Color.SteelBlue);
        ChartControl2.Background.Type = InteriorType.LinearGradient;
        ChartControl2.Background.ForeColor = Color.SteelBlue;
        ChartControl2.Background.EndPoint = new Point(500, 350);
        ChartControl2.Legend.Position = LegendPosition.Bottom;
        ChartControl2.Legend.Width = 40;

        ChartControl2.YAxisFont.ForeColor = Color.SteelBlue;
        ChartControl2.XAxisFont.ForeColor = Color.SteelBlue;

        ChartControl2.ChartTitle.Text = "BEHAVIOUR UNDER PRESSURE";
        ChartControl2.ChartTitle.ForeColor = Color.White;

        ChartControl2.Border.Color = Color.SteelBlue;
        ChartControl2.BorderStyle = BorderStyle.Ridge;
    }

    private void ConfigureColors3()
    {
        ChartControl3.Background.Color = Color.FromArgb(75, Color.SteelBlue);
        ChartControl3.Background.Type = InteriorType.LinearGradient;
        ChartControl3.Background.ForeColor = Color.SteelBlue;
        ChartControl3.Background.EndPoint = new Point(500, 350);
        ChartControl3.Legend.Position = LegendPosition.Bottom;
        ChartControl3.Legend.Width = 40;

        ChartControl3.YAxisFont.ForeColor = Color.SteelBlue;
        ChartControl3.XAxisFont.ForeColor = Color.SteelBlue;

        ChartControl3.ChartTitle.Text = "HOW YOU SEE YOURSELF";
        ChartControl3.ChartTitle.ForeColor = Color.White;

        ChartControl3.Border.Color = Color.SteelBlue;
        ChartControl3.BorderStyle = BorderStyle.Ridge;
    }
}