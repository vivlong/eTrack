Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports System.IO
Imports System.Globalization

Namespace SystemClass

#Region " Class of ExportBookingSelect"

    <Serializable()> _
    Public Class clsExportBookingSelect
        Inherits clsQuery
        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
        End Sub
        Public Overrides Function DecodeQueryCondition(ByVal strValue As String, ByRef strMsg As String) As Boolean
            SqlRelation.AddToWhereString(Where, strValue)
            strMsg = ""
            Return True
        End Function
        Protected Overrides Function GetList() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.Int)
                param(0).Value = -1

                param(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1500)
                param(1).Value = Where

                param(2) = New SqlParameter("@strQuery", SqlDbType.NVarChar, 1500)
                param(2).Value = Query

                param(3) = New SqlParameter("@strOrderBy", SqlDbType.NVarChar, 100)
                param(3).Value = OrderBy

                param(4) = New SqlParameter("@PageIndex", SqlDbType.Int)
                param(4).Value = PageIndex

                param(5) = New SqlParameter("@PageSize", SqlDbType.Int)
                param(5).Value = PageSize

                param(6) = New SqlParameter("@PageCount", SqlDbType.Int)
                param(6).Direction = ParameterDirection.Output

                param(7) = New SqlParameter("@RecordCount", SqlDbType.Int)
                param(7).Direction = ParameterDirection.Output

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_Sebk1_VesselSchedule", param)
                If PageSize = 0 Then
                    'Total Page Count
                    PageCount = 1
                    'Total Record Count
                    RecordCount = ds.Tables(0).Rows.Count
                    If Where <> "" Then
                        dt = ds.Tables(0)
                    Else
                        dt = ds.Tables(0)
                    End If
                Else
                    'Total Page Count
                    PageCount = Integer.Parse(param(6).Value.ToString())
                    'Total Record Count
                    RecordCount = Integer.Parse(param(7).Value.ToString())
                    dt = ds.Tables(1)
                End If
                If dt.Rows.Count = 0 Then
                    dt.Rows.Add()
                    IsEmpty = True
                Else
                    IsEmpty = False
                End If
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

    End Class

#End Region

#Region " Class of Collection of Property ExportBookingSelect "

    <Serializable()> _
    Public Class colExportBookingSelect
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropExportBookingSelect(ConClass.NewIdValue)
        End Function

    End Class

#End Region
#Region " Class of ExportBookingSelect Server "

    <Serializable()> _
    Public Class clsExportBookingSelectEdit
        Inherits clsBaseSrv



        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colExportBookingSelect()
            Title = "ExportBookingSelect"
            colProp.AddOneSpaceRecord(0, intUserId)
        End Sub
        ''' <summary>
        ''' 100315 ZhiWei for judge by Role
        ''' </summary>
        ''' <param name="strUserId"></param>
        ''' <param name="RoleName"></param>
        ''' <param name="strFunNo"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String)
            MyBase.New(strUserId, RoleName, strFunNo)
            colProp = New colTracking()
            Title = "ExportBookingSelect"
        End Sub

        Private Function InsertSeaFreight(ByVal propSeaFreight As clsPropTracking, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Private Function UpdateSeaFreight(ByVal propSeaFreight As clsPropTracking, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Private Function DeleteSeaFreight(ByVal propSeaFreight As clsPropTracking, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overrides Function GetList() As DataTable
            Return Nothing
        End Function

        Public Overrides Function GetDetail(ByVal intId As Int64) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function GetDetail(ByVal strKey As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@VoyageID", SqlDbType.NVarChar, 20)
                param(0).Value = strKey

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Rcvy1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Return True
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Return True
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function
        'bylzw081224´´½¨Á´½Ó
        Public Shared Function GetReferenceFile(ByVal strPrefix As String, ByVal strFileName As String, ByVal strReference As String) As String
            Return strPrefix + "<A href=""" + strFileName + """ target=""_blank"">" + strReference + "</A>"
        End Function
        Public Overloads Sub GetListInfo(ByVal strPath As String, ByVal strDownloadPath As String)

        End Sub
    End Class

#End Region
End Namespace