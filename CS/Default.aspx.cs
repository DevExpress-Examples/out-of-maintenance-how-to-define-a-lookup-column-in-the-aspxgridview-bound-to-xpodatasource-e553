using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Xpo;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page 
{
    Session xpoSession;

    protected void Page_Init(object sender, EventArgs e)
    {
        xpoSession = XpoHelper.GetNewSession();
        xpoCustomers.Session = xpoSession;
        xpoOrders.Session = xpoSession;

    }
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void ASPxGridView1_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e) {
        
    }
}
