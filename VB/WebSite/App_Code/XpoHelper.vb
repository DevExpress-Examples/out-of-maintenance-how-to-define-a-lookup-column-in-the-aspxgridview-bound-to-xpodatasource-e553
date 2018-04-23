Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.Metadata

''' <summary>
''' Summary description for XpoHelper
''' </summary>
Public NotInheritable Class XpoHelper
	Private Sub New()
	End Sub
	Public Shared Function GetNewSession() As Session
		Return New Session(DataLayer)
	End Function

	Public Shared Function GetNewUnitOfWork() As UnitOfWork
		Return New UnitOfWork(DataLayer)
	End Function

	Private ReadOnly Shared lockObject As Object = New Object()

    Private Shared fDataLayer As IDataLayer
    Private Shared ReadOnly Property DataLayer() As IDataLayer
        Get
            If fDataLayer Is Nothing Then
                SyncLock lockObject
                    If System.Threading.Thread.VolatileRead(fDataLayer) Is Nothing Then
                        System.Threading.Thread.VolatileWrite(fDataLayer, GetDataLayer())
                    End If
                End SyncLock
            End If
            Return fDataLayer
        End Get
    End Property

	Private Shared Function GetDataLayer() As IDataLayer
		XpoDefault.Session = Nothing

		Dim conn As String = AccessConnectionProvider.GetConnectionString("|DataDirectory|\db.mdb")
		Dim dict As XPDictionary = New DevExpress.Xpo.Metadata.ReflectionDictionary()
		Dim store As IDataStore = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists)
		dict.GetDataStoreSchema(GetType(Order).Assembly) ' <<< initialize the XPO dictionary
		Dim dl As IDataLayer = New ThreadSafeDataLayer(dict, store)
		Return dl
	End Function
End Class
