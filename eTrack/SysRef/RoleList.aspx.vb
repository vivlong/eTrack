Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass

Class RoleList
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private SelectRoleInfo As clsSelectRoleInfo

    Private returnValue As String

    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Dim arrParam As String() = GeneralFun.GetPar(returnValue)
        Select Case arrParam.Length
            Case 1
                Return CStr(Me.GetType().GetMethod(arrParam(0)).Invoke(Me, Nothing))
            Case Else
                Dim arrObject(arrParam.Length - 2) As Object
                Dim i As Integer
                For i = 0 To arrParam.Length - 2
                    arrObject(i) = arrParam(i + 1)
                Next
                Return CStr(Me.GetType().GetMethod(arrParam(0)).Invoke(Me, arrObject))
        End Select
    End Function

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        returnValue = eventArgument
    End Sub

    Public Function GetQueryData(ByVal strQuery As String) As String
        Dim objUser As clsUser = Nothing
        If PageFun.GetCurrentUserInfo(Page, objUser) Then
            SelectRoleInfo = New clsSelectRoleInfo(objUser.UserId)
            gvwSource.DataSource = SelectRoleInfo.GetRoleInfoList(objUser.RoleName, strQuery)
            gvwSource.DataBind()
        End If
        Return GridViewFun.RenderControl(gvwSource)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)

            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If

            'New Object SelectStoreHouseInfo
            If Not (SelectRoleInfo Is Nothing) Then
                SelectRoleInfo = Nothing
            End If
            SelectRoleInfo = New clsSelectRoleInfo(objUser.UserId)

            'Default Get First Page Data;
            BindSourceData(objUser.RoleName)

            'Assign Search Event
            btnSearch.Attributes.Add("OnClick", "GetQueryData(" + txtSearch.ClientID + ");return false;")
            txtSearch.Attributes.Add("OnKeyDown", "javascript:if(event.keyCode==13){GetQueryData(" + txtSearch.ClientID + "); return false;}")

            btnOk.Attributes.Add("OnClick", "ClosingWindow(1);return false;")
            btnCancel.Attributes.Add("OnClick", "ClosingWindow(0);return false")
        End If
    End Sub

    Public Sub BindSourceData(ByVal RoleName As String)
        gvwSource.DataSource = SelectRoleInfo.GetRoleInfoList(RoleName, "")
        gvwSource.DataBind()
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            If SelectRoleInfo.SourceIsEmpty Then
                e.Row.Visible = False
            Else
                e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this);")
                If e.Row.RowIndex Mod 2 = 0 Then
                    e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1);")
                Else
                    e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0);")
                End If
            End If
        End If
    End Sub

End Class