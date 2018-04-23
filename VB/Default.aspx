<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Xpo.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Xpo" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>How to define a lookup column in the ASPxGridView bound to XpoDataSource</title>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="false">
    <div>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
            DataSourceID="xpoOrders" KeyFieldName="Oid" Width="865px">
            <Columns>
                <dxwgv:GridViewCommandColumn VisibleIndex="0" ShowClearFilterButton="true" ShowEditButton="true">                    
                </dxwgv:GridViewCommandColumn>
                <dxwgv:GridViewDataTextColumn Caption="Oid" FieldName="Oid" ReadOnly="True" VisibleIndex="1" Visible="False">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataDateColumn Caption="OrderDate" FieldName="OrderDate" VisibleIndex="1">
                </dxwgv:GridViewDataDateColumn>
                <dxwgv:GridViewDataTextColumn Caption="PaymentAmount" FieldName="PaymentAmount" VisibleIndex="2">
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataComboBoxColumn Caption="Customer!Key (Lookup)" FieldName="Customer!Key"
                    VisibleIndex="3">
                    <PropertiesComboBox DataSourceID="xpoCustomers" TextField="Name" ValueField="Oid"
                        ValueType="System.Int32">
                    </PropertiesComboBox>
                </dxwgv:GridViewDataComboBoxColumn>
                <dxwgv:GridViewDataTextColumn Caption="Customer.CompanyName (Non-Lookup)" FieldName="Customer.CompanyName"
                    VisibleIndex="4">
                    <EditFormSettings Visible="False" />
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <Settings ShowFilterRow="True" />
        </dxwgv:ASPxGridView>

    </div>
        <dx:XpoDataSource ID="xpoOrders" runat="server" TypeName="Order"/>
        <dx:XpoDataSource ID="xpoCustomers" runat="server" TypeName="Customer"/>
    </form>
</body>
</html>