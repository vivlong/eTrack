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
Imports SysMagic.ZZMessage
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Partial Class VesselSchedule_VesselScheduleDetail
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private objServer As clsVessualScheduleEdit
    Private objColumns As colColumn
    Private objList As clsJobStatus
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

    Public Function NewServerObject(ByVal intUserId As String) As clsBaseSrv
        Return New clsVessualScheduleEdit(intUserId)
    End Function
    Private Sub BindDetailData(ByVal intUserId As String, ByVal strVoyageID As String)
        objServer = NewServerObject(intUserId)
        If strVoyageID <> "" Then
            Dim tmpProp As clsPropVessualSchedule = objServer.GetDetail(strVoyageID)
            fldId.Value = tmpProp.VoyageID
            txtVesselVoyage.Text = tmpProp.VesselCode
            txtPortOfDischarge.Text = tmpProp.PortOfDischargeName
            txtArrivalDate.Text = tmpProp.Eta
            txtDepartureDate.Text = tmpProp.ETD
        Else
            fldId.Value = ""
            txtVesselVoyage.Text = ""
            txtPortOfDischarge.Text = ""
            txtArrivalDate.Text = ""
            txtDepartureDate.Text = ""
        End If
        'Repair Detail
    End Sub

    Private Sub SetInitValue(ByVal intUserId As String)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load '
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Session("LoginType") = 3 Then
                '' this part for just directly search so dont need check user ... Add it by Jackie 080904
            Else
                If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                    Return
                End If
            End If
            Dim strVoyageID As String = ""
            If Not (Request("id") Is Nothing) Then
                strVoyageID = Request("id").ToString()
                Head1.Title = "VesselSchedule"
            End If
            'Set Default Value
            SetInitValue(objUser.UserId)
            'Bind Detail Data
            BindDetailData(objUser.UserId, strVoyageID)
        End If
    End Sub

    Protected Sub gvwSource_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            'Row color
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
        End If
    End Sub
    'bylzw081224
    Protected Sub gvwAttach_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Dim objUser As clsUser = Nothing
        If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
            Return
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            'e.Row.Attributes.Add("OnClick", "DownloadAttachment(""div1"");return false;")
            e.Row.Attributes.Add("onMouseOver", "RowMouseOver(this)")
            If e.Row.RowIndex Mod 2 = 0 Then
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,1)")
            Else
                e.Row.Attributes.Add("onMouseOut", "RowMouseOut(this,0)")
            End If
        End If
        If e.Row.RowIndex = objServer.ArrProp.Count - 1 Then
            e.Row.Cells(0).Text = ""
            e.Row.Cells(1).Text = ""
            e.Row.Cells(2).Text = ""
            e.Row.Cells(3).Text = ""
        End If
    End Sub
End Class