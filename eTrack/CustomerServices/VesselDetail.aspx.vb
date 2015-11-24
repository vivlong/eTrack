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

Partial Class VesselDetail
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
        Return New clsVessualSchedule_Sebl1Edit(intUserId)
    End Function

    Private Sub BindDetailData(ByVal intUserId As String, ByVal strVoyageID As String)
        objServer = NewServerObject(intUserId)
        If strVoyageID <> "" Then
            Dim tmpProp As clsPropVessualSchedule = objServer.GetDetail(strVoyageID)
            fldId.Value = tmpProp.VoyageID
            txtVessel.Text = tmpProp.VesselCode
            txtVoyage.Text = tmpProp.VesselCode


            txtPortOfDischarge.Text = tmpProp.PortOfDischargeName
            txtArrivalDate.Text = tmpProp.Eta
            txtDepartureDate.Text = tmpProp.ETD
        Else
            fldId.Value = ""
            txtVessel.Text = ""
            txtVoyage.Text = ""
            txtPortOfDischarge.Text = ""
            txtArrivalDate.Text = ""
            txtDepartureDate.Text = ""
        End If
        'Repair Detail
    End Sub

    Private Sub SetInitValue(ByVal intUserId As String)
        If Request("arrPara") IsNot Nothing And Request("arrPara").ToString.Length > 0 Then
            Dim arrPara As String() = Request("arrPara").ToString.Replace("$$$$", "$").Split("$")
            If arrPara.Length = 5 Then
                txtDepartureDate.Text = arrPara(0)
                If (arrPara(1).ToString() <> "") Then
                    txtVessel.Text = arrPara(1).Substring(0, arrPara(1).IndexOf("/"))
                    txtVoyage.Text = arrPara(1).Substring(arrPara(1).IndexOf("/") + 1, arrPara(1).Length - arrPara(1).IndexOf("/") - 1)
                End If
                txtShippingline.Text = arrPara(2)
                txtPortOfDischarge.Text = arrPara(3)
                txtArrivalDate.Text = arrPara(4)
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing

            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            Dim strVoyageID As String = ""
            If Not (Request("id") Is Nothing) Then
                Head1.Title = "VesselSchedule"
            End If
            'Set Default Value
            SetInitValue(objUser.UserId)
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
        End If
    End Sub

End Class