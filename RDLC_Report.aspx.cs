using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System;
using Microsoft.Reporting.WebForms;

namespace _3200_project
{
    public partial class RDLC_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
     
                DataTable dt = new DataTable();
                dt = (DataTable)Session["buyitems"];
                if (dt != null)
                {
                    Label1.Text = dt.Rows.Count.ToString();
                }
                else
                {
                    Label1.Text = "0";
                }

                if (Session["New"] != null)
                {
                    Button6.Text = Session["New"].ToString();
                }
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //Session["payment_id"] = "11c8b18e-b8f8-4f75-8e43-8ec80c341b78";
                SqlDataAdapter da = new SqlDataAdapter("Select * from [Table] where  Id= '" + Session["product_id"].ToString() + "'", con);
                System.Diagnostics.Debug.WriteLine(Session["payment_id"].ToString());
                dt = new DataTable("table1");
                da.Fill(dt);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("RDLC_Report.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                ReportViewer1.LocalReport.Refresh();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("pro_insert.aspx");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("search.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("account.aspx");
        }

    }
}