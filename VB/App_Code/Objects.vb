Imports DevExpress.Xpo
Imports System

Public Class Order
    Inherits XPObject

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Private _orderDate As Date
    Public Property OrderDate() As Date
        Get
            Return _orderDate
        End Get
        Set(ByVal value As Date)
            SetPropertyValue("OrderDate", _orderDate, value)
        End Set
    End Property

    Private _paymentAmount As Decimal
    Public Property PaymentAmount() As Decimal
        Get
            Return _paymentAmount
        End Get
        Set(ByVal value As Decimal)
            SetPropertyValue("PaymentAmount", _paymentAmount, value)
        End Set
    End Property

    Private _customer As Customer
    <Association("Customer-Orders")> _
    Public Property Customer() As Customer
        Get
            Return _customer
        End Get
        Set(ByVal value As Customer)
            SetPropertyValue("Customer", _customer, value)
        End Set
    End Property
End Class

Public Class Customer
    Inherits XPObject

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Name", _name, value)
        End Set
    End Property
    Private _companyName As String
    Public Property CompanyName() As String
        Get
            Return _companyName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("CompanyName", _companyName, value)
        End Set
    End Property

    <Association("Customer-Orders"), Aggregated> _
    Public ReadOnly Property Orders() As XPCollection(Of Order)
        Get
            Return GetCollection(Of Order)("Orders")
        End Get
    End Property
End Class
