<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PBIReportServer.aspx.cs" Inherits="ReportServiceReports.PBIReportServer" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style>
        html, body, form, #div1 {
            height: 100%;
            Width: 99%;
        }
    </style>
    <title>BI Report</title>

</head>
<body>

    <form id="form1" runat="server" style="width:100%; height:100%;">
    <asp:HiddenField ID="DatePickers" runat="server" />
        <div id="div1">
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600">
            </asp:ScriptManager>
            <rsweb:ReportViewer WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="100%" Width="100%" SizeToReportContent="True" ID="ReportViewer1" runat="server" ProcessingMode="Remote">
                <ServerReport ReportServerUrl="https://192.168.26.56/reportsPBI" />
            </rsweb:ReportViewer>
        </div>

    </form>

</body>
</html>
