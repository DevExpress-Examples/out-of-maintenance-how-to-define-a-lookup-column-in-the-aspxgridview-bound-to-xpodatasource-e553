Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Xpo
Imports DevExpress.Web.ASPxEditors

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private xpoSession As Session

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		xpoSession = XpoHelper.GetNewSession()
		xpoCustomers.Session = xpoSession
		xpoOrders.Session = xpoSession

	End Sub
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub ASPxGridView1_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatedEventArgs)

	End Sub
End Class
