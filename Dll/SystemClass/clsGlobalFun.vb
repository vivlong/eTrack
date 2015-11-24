Imports System
Imports System.Web
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.IO
Imports System.Globalization
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.SqlClient
Imports SysMagic.ZZSystem

Namespace SystemClass

#Region " Class of Page Function "

    Public Enum ReferenceTarget
        NewWindow = 0
        WindowDialog = 1
        Self = 2
        Parent = 3
        VesselSchedule = 1
    End Enum

    Public Class PageFun

        Public Shared Function GetCurrentUserInfo(ByVal pgCurrent As Page, ByRef objUser As clsUser) As Boolean
            Dim strPage As String = pgCurrent.Request.RawUrl
            If HttpContext.Current.Session(ConSessionName.UserInfo) Is Nothing Then
                pgCurrent.Response.Redirect(("../Default.aspx?Redirect=" + strPage))
                'pgCurrent.Response.Redirect(("Default.aspx?Redirect=" + strPage))
                Return False
            Else
                objUser = CType(HttpContext.Current.Session(ConSessionName.UserInfo), clsUser)
                HttpContext.Current.Session(ConSessionName.UserInfo) = objUser
                Return True
            End If
        End Function

        Public Shared Function GetCurrentUserInfo(ByVal pgCurrent As Page, ByRef objUser As clsUser, ByVal unNeedValid As String) As Boolean
            Dim strPage As String = pgCurrent.Request.RawUrl
            objUser = CType(HttpContext.Current.Session(ConSessionName.UserInfo), clsUser)
            HttpContext.Current.Session(ConSessionName.UserInfo) = objUser
            objUser = New clsUser()
            HttpContext.Current.Session(ConSessionName.UserInfo) = objUser
            Return True
        End Function

        Public Shared Function GetRequestValueAsInt(ByVal pgCurrent As Page, ByVal strRequest As String) As Integer
            Dim strValue As String = ""
            If Not (pgCurrent.Request.QueryString(strRequest) Is Nothing) Then
                strValue = pgCurrent.Request.QueryString(strRequest).ToString()
            End If
            If strValue = "" Then
                Return 0
            Else
                Return Integer.Parse(strValue)
            End If
        End Function

        Public Shared Function GetRequestValue(ByVal pgCurrent As Page, ByVal strRequest As String) As String
            Dim strValue As String = ""
            If Not (pgCurrent.Request.QueryString(strRequest) Is Nothing) Then
                strValue = pgCurrent.Request.QueryString(strRequest).ToString()
            End If
            Return strValue
        End Function

        Public Shared Function GetFunNo(ByVal pgCurrent As Page) As String
            Return GetRequestValue(pgCurrent, "FunNo")
        End Function

        Public Shared Function GetRequestId(ByVal pgCurrent As Page) As Int64
            Dim intId As Int64 = 0
            If Not (pgCurrent.Request.QueryString("Id") Is Nothing) Then
                If Not Int64.TryParse(pgCurrent.Request.QueryString("Id").ToString().Trim(), intId) Then
                    intId = 0
                End If
            End If
            Return intId
        End Function

        Public Shared Function GetPrintId(ByVal pgPrint As Page) As Int64
            Dim intId As Int64 = 0
            If Not (pgPrint.Request.QueryString("Id") Is Nothing) Then
                If Not Int64.TryParse(pgPrint.Request.QueryString("Id").ToString().Trim(), intId) Then
                    intId = 0
                End If
            End If
            Return intId
        End Function

        Public Shared Function GetWaitingPage(ByVal strPage As String, ByVal intLevel As Integer) As String
            Select Case intLevel
                Case 0
                    Return "loading.aspx?tourl=" + strPage
                Case 1
                    Return "../loading.aspx?tourl=" + strPage
                Case Else
                    Return "~/loading.aspx?tourl=" + strPage
            End Select
        End Function

        Public Shared Function GetReferencePage(ByVal strPrefix As String, ByVal strPage As String, ByVal strReference As String, ByVal enumTarget As ReferenceTarget) As String
            Select Case enumTarget
                Case ReferenceTarget.NewWindow
                    Return strPrefix + "<A href=""" + PageFun.GetWaitingPage(strPage, 1) + """ target=""" + "_blank" + """>" + strReference + "</A>"
                Case ReferenceTarget.Self
                    Return strPrefix + "<A href=""" + PageFun.GetWaitingPage(strPage, 1) + """ target=""" + "_self" + """>" + strReference + "</A>"
                Case ReferenceTarget.Parent
                    Return strPrefix + "<A href=""" + PageFun.GetWaitingPage(strPage, 1) + """ target=""" + "_parent" + """>" + strReference + "</A>"
                Case ReferenceTarget.WindowDialog
                    Return strPrefix + "<A href=""javascript:WindowDialog('" + PageFun.GetWaitingPage(strPage, 1) + "',800,600);"">" + strReference + "</A>"
                Case ReferenceTarget.VesselSchedule
                    Return strPrefix + "<A href=""javascript:WindowDialog('" + PageFun.GetWaitingPage(strPage, 1) + "',600,400);"">" + strReference + "</A>"
                Case Else
                    Return strPrefix + "<A href=""" + PageFun.GetWaitingPage(strPage, 1) + """ target=""" + "_blank" + """>" + strReference + "</A>"
            End Select
        End Function

        Public Shared Function GetReferenceFile(ByVal strPrefix As String, ByVal strFileName As String, ByVal strReference As String) As String
            Return strPrefix + "<A href=""" + strFileName + """ target=""_blank"">" + strReference + "</A>"
        End Function

        Public Shared Function GetSortOrderReference(ByVal strPrefix As String, ByVal strFieldName As String, ByVal blnSortDesc As Boolean) As String
            If blnSortDesc Then
                Return strPrefix + " <a href=""javascript:GetSortPageData('" + strFieldName + "',0)""> ¡ý </a>"
            Else
                Return strPrefix + " <a href=""javascript:GetSortPageData('" + strFieldName + "',1)""> ¡ü </a>"
            End If
        End Function

        Public Shared Function GetNavigateId(ByVal pgCurrent As Page) As Int64
            Dim intId As Int64 = 0
            If Not (pgCurrent.Request.QueryString("Id") Is Nothing) Then
                If Not Int64.TryParse(pgCurrent.Request.QueryString("Id").ToString().Trim(), intId) Then
                    intId = 0
                End If
            End If
            Dim intMessageId As Int64 = 0
            If Not (pgCurrent.Request.QueryString("MessageId") Is Nothing) Then
                If Not Int64.TryParse(pgCurrent.Request.QueryString("MessageId").ToString().Trim(), intMessageId) Then
                    intMessageId = 0
                End If
            End If
            If intMessageId <> 0 Then
                Try
                    Dim param(0) As SqlParameter
                    param(0) = New SqlParameter("@intId", SqlDbType.BigInt)
                    param(0).Value = intMessageId
                    SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spu_SystemSms", param)
                Catch
                End Try
            End If
            Return intId
        End Function

    End Class

#End Region
End Namespace