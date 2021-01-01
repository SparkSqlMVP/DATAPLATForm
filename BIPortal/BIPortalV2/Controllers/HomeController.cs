using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.Rest;
using BIPortalV2.Models;
using BIPortalV2.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Net;

namespace BIPortalV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmbedService m_embedService;

        public HomeController()
        {
            m_embedService = new EmbedService();
        }

        public ActionResult Index()
        {
            var result = new IndexConfig();
            var assembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Where(n => n.Name.Equals("Microsoft.PowerBI.Api")).FirstOrDefault();
            if (assembly != null)
            {
                result.DotNETSDK = assembly.Version.ToString(3);
            }
            return View(result);
        }

        public ActionResult login()
        {
          return View();
        }

    public async Task<ActionResult> EmbedReport(string username, string roles)
        {
            var embedResult = await m_embedService.EmbedReport(username, roles);
            if (embedResult)
            {
                return View(m_embedService.EmbedConfig);
            }
            else
            {
                return View(m_embedService.EmbedConfig);
            }
        }

        public async Task<ActionResult> EmbedDashboard()
        {
            var embedResult = await m_embedService.EmbedDashboard();
            if (embedResult)
            {
                return View(m_embedService.EmbedConfig);
            }
            else
            {
                return View(m_embedService.EmbedConfig);
            }
        }

        public async Task<ActionResult> EmbedTile()
        {
            var embedResult = await m_embedService.EmbedTile();
            if (embedResult)
            {
                return View(m_embedService.TileEmbedConfig);
            }
            else
            {
                return View(m_embedService.TileEmbedConfig);
            }
        }



        public ActionResult RSReports(string reportname)
        {
            ReportViewer rptViewer = new ReportViewer();
            // ProcessingMode will be Either Remote or Local  
            rptViewer.ServerReport.ReportServerCredentials = new ReportServerCredentials("Administrator", "2$BmYCZc-2E](1_v", "");
            rptViewer.ProcessingMode = ProcessingMode.Remote;
            //rptViewer.SizeToReportContent = true;
            rptViewer.AsyncRendering = false;
            //rptViewer.SizeToReportContent = true;
            //rptViewer.ZoomMode = ZoomMode.FullPage;
            //rptViewer.ZoomMode = ZoomMode.PageWidth;
            rptViewer.Width = Unit.Percentage(100);
            rptViewer.Height = Unit.Pixel(470);
            rptViewer.BackColor = System.Drawing.Color.AliceBlue;
            rptViewer.AsyncRendering = true;
            rptViewer.ServerReport.ReportServerUrl = new Uri("http://45.76.120.192/reportserver/");
            rptViewer.ServerReport.ReportPath = string.Format("/Feitian_RS/{0}", reportname);

            ViewBag.ReportViewer = rptViewer;
            return View();
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
