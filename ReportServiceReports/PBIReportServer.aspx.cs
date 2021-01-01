using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportServiceReports
{
    public partial class PBIReportServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rsname = "powerbi/Kiosk?rs:embed=true";// Request.QueryString["rsname"];

            string environment = "reportsPBI"; //ConfigurationManager.AppSettings["RsPath"];

            if (!Page.IsPostBack)
            {
                //账户信息如果以后需要维护再放到Web.config中；
                ReportViewer1.ServerReport.ReportServerCredentials = new ReportServerCredentials("spark.zhou", "Password1", "");
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.Width = Unit.Percentage(100);
                ReportViewer1.Height = Unit.Percentage(100);
                ReportViewer1.BackColor = System.Drawing.Color.AliceBlue;
                ReportViewer1.KeepSessionAlive = true;

                // Set the processing mode for the ReportViewer to Remote  
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                ServerReport serverReport = ReportViewer1.ServerReport;

                // Set the report server URL and report path  
                serverReport.ReportServerUrl =
                    new Uri("http://192.168.26.56/");
                serverReport.ReportPath = string.Format("/{0}/{1}", environment, rsname);


            }
        }


        public class ReportServerCredentials : IReportServerCredentials
        {
            private string _userName;
            private string _password;
            private string _domain;

            public ReportServerCredentials(string userName, string password, string domain)
            {
                _userName = userName;
                _password = password;
                _domain = domain;
            }

            public WindowsIdentity ImpersonationUser
            {
                get
                {
                    // Use default identity.
                    return null;
                }
            }

            public ICredentials NetworkCredentials
            {
                get
                {
                    // Use default identity.
                    return new NetworkCredential(_userName, _password, _domain);
                }
            }

            public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
            {
                // Do not use forms credentials to authenticate.
                authCookie = null;
                user = password = authority = null;
                return false;
            }
        }
    }
}