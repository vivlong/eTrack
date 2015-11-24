Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem

Namespace SystemClass

#Region " Class of Person Setting "

    <Serializable()> _
    Public Class clsDepotIn
        Private _UserId As Integer
        Private _FirstPage As String
        Private _DetailSize As Integer
        Private _QuerySize As Integer
        Private _OpenSize As Integer
        Private _SearchSize As Integer
        Private _InfoSize As Integer
        Private _DisplaySmsHint As Boolean
        Private _Title As String

        Public Sub New(ByVal intUserId As String)
            UserId = intUserId
            _Title = "personality setting"
        End Sub

        Public Property UserId() As Integer
            Get
                Return _UserId
            End Get
            Set(ByVal value As Integer)
                _UserId = value
            End Set
        End Property

        Public Property FirstPage() As String
            Get
                Return _FirstPage
            End Get
            Set(ByVal value As String)
                _FirstPage = value
            End Set
        End Property

        Public Property DetailSize() As Integer
            Get
                Return _DetailSize
            End Get
            Set(ByVal value As Integer)
                _DetailSize = value
            End Set
        End Property

        Public Property QuerySize() As Integer
            Get
                Return _QuerySize
            End Get
            Set(ByVal value As Integer)
                _QuerySize = value
            End Set
        End Property

        Public Property OpenSize() As Integer
            Get
                Return _OpenSize
            End Get
            Set(ByVal value As Integer)
                _OpenSize = value
            End Set
        End Property

        Public Property SearchSize() As Integer
            Get
                Return _SearchSize
            End Get
            Set(ByVal value As Integer)
                _SearchSize = value
            End Set
        End Property

        Public Property InfoSize() As Integer
            Get
                Return _InfoSize
            End Get
            Set(ByVal value As Integer)
                _InfoSize = value
            End Set
        End Property

        Public Property DisplaySmsHint() As Boolean
            Get
                Return _DisplaySmsHint
            End Get
            Set(ByVal value As Boolean)
                _DisplaySmsHint = value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return _Title
            End Get
            Set(ByVal value As String)
                _Title = value
            End Set
        End Property

        Public Function ModifyCurrent(ByVal tmpProp As clsDepotIn, ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 8 Then
                Return False
            Else
                tmpProp.UserId = Integer.Parse(strRow(0))
                tmpProp.FirstPage = strRow(1)
                If strRow(2) = "" Then
                    tmpProp.InfoSize = 10
                Else
                    tmpProp.InfoSize = Integer.Parse(strRow(2))
                End If
                If strRow(3) = "" Then
                    tmpProp.SearchSize = 10
                Else
                    tmpProp.SearchSize = Integer.Parse(strRow(3))
                End If
                If strRow(4) = "" Then
                    tmpProp.OpenSize = 10
                Else
                    tmpProp.OpenSize = Integer.Parse(strRow(4))
                End If
                If strRow(5) = "" Then
                    tmpProp.QuerySize = 10
                Else
                    tmpProp.QuerySize = Integer.Parse(strRow(5))
                End If
                If strRow(6) = "" Then
                    tmpProp.DetailSize = 10
                Else
                    tmpProp.DetailSize = Integer.Parse(strRow(6))
                End If
                If strRow(7) = "" Then
                    tmpProp.DisplaySmsHint = False
                Else
                    tmpProp.DisplaySmsHint = Boolean.Parse(strRow(7))
                End If
                Return True
            End If
        End Function

        Public Sub GetDepotIn(ByVal intUserId As String)
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(0).Value = intUserId

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_DepotIn", param)
                dt = ds.Tables(0)
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    'UserId
                    UserId = CInt(GeneralFun.CheckNull(dt.Rows(0)("lUserId"), DbType.Int32))
                    'FirstPage
                    FirstPage = CStr(GeneralFun.CheckNull(dt.Rows(0)("sFirstPage"), DbType.String)).TrimEnd()
                    'DetailSize
                    DetailSize = CInt(GeneralFun.CheckNull(dt.Rows(0)("lDetailSize"), DbType.Int32))
                    'QuerySize
                    QuerySize = CInt(GeneralFun.CheckNull(dt.Rows(0)("lQuerySize"), DbType.Int32))
                    'OpenSize
                    OpenSize = CInt(GeneralFun.CheckNull(dt.Rows(0)("lOpenSize"), DbType.Int32))
                    'SearchSize
                    SearchSize = CInt(GeneralFun.CheckNull(dt.Rows(0)("lSearchSize"), DbType.Int32))
                    'InfoSize
                    InfoSize = CInt(GeneralFun.CheckNull(dt.Rows(0)("lInfoSize"), DbType.Int32))
                    'DisplaySmsHint
                    DisplaySmsHint = CBool(GeneralFun.CheckNull(dt.Rows(0)("bDisplaySmsHint"), DbType.Boolean))
                Next i
            Catch
            End Try
        End Sub

        Public Function UpdateDepotIn(ByVal propPerson As clsDepotIn, ByRef strMsg As String) As Boolean
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.NVarChar, 20)
                param(0).Value = propPerson.UserId

                param(1) = New SqlParameter("@strFirstPage", SqlDbType.NVarChar, 50)
                param(1).Value = propPerson.FirstPage

                param(2) = New SqlParameter("@intDetailSize", SqlDbType.Int)
                param(2).Value = propPerson.DetailSize

                param(3) = New SqlParameter("@intQuerySize", SqlDbType.Int)
                param(3).Value = propPerson.QuerySize

                param(4) = New SqlParameter("@intOpenSize", SqlDbType.Int)
                param(4).Value = propPerson.OpenSize

                param(5) = New SqlParameter("@intSearchSize", SqlDbType.Int)
                param(5).Value = propPerson.SearchSize

                param(6) = New SqlParameter("@intInfoSize", SqlDbType.Int)
                param(6).Value = propPerson.InfoSize

                param(7) = New SqlParameter("@blDisplaySmsHint", SqlDbType.Bit)
                param(7).Value = propPerson.DisplaySmsHint

                SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spu_DepotIn", param)
                strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.GeneralUpdateSuccess, Title)
                Return True
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

    End Class

#End Region
End Namespace