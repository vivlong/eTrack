Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass

Partial Class SelectReportEdit
    Inherits LanguagePage
    Implements System.Web.UI.ICallbackEventHandler
    Private objAttach As clsAttach
    Private objColumns As colColumn
    Private returnValue As String
    Private intTrxNo As Int64 = ConClass.NewIdValue
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    'End Sub
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
        Return New clsBooking(intUserId)
    End Function

    Private Function GetNewId() As Int64
        Dim rdm As New Random()
        Dim rdmNum As Integer = rdm.Next(10, 99)
        Dim strAdd As String = DateTime.Now.ToString("yyyyMMddHHmmss") + rdmNum.ToString()
        Dim intId As Int64 = -Int64.Parse(strAdd)
        Return intId
    End Function

#Region "Third Tab"
    Private Sub BindAttach(ByVal intUserId As String, ByVal intTrxNo As Int64, ByVal strFolder As String)
        objAttach = New clsAttach(intUserId, intTrxNo)
        Dim strType As String = ""
        If Request("type") IsNot Nothing Then
            strType = Request("type").ToString
        End If
        Select Case strType
            Case "3"
                objAttach.GetListInfo(Server.MapPath("../Report/Documents/sibl/"), strFolder)
            Case "2"
                objAttach.GetListInfo(Server.MapPath("../Report/Documents/sebl/"), strFolder)
            Case Else
                objAttach.GetListInfo(Server.MapPath("../Report/CustomerServices/omtx/"), strFolder)
        End Select
        drReport.DataSource = objAttach.ArrProp
        drReport.DataTextField = "FileName"
        drReport.DataValueField = "FileName"
        drReport.DataBind()
        For i As Integer = 0 To drReport.Items.Count - 1
            drReport.Items(i).Text = drReport.Items(i).Text.Replace(".rpt", "")
            drReport.Items(i).Value = drReport.Items(i).Value.Replace(".rpt", "")
        Next
        drReport.Items.RemoveAt(drReport.Items.Count - 1)
    End Sub
#End Region
#Region "public"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            'Set timeout 
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Judge Login or not
            Dim objUser As clsUser = Nothing
            If Not PageFun.GetCurrentUserInfo(Page, objUser) Then
                Return
            End If
            hidId.Value = -1
            If Request("id") IsNot Nothing Then
                hidId.Value = Request("id").ToString
            End If
            btnClose.Attributes.Add("OnClick", "CloseWindow();return false;")
            Dim strType As String = ""
            If Request("type") IsNot Nothing Then
                strType = Request("type").ToString
            End If
            Select Case strType
                Case "3"
                    btnSelected.Attributes.Add("OnClick", "OpenReport(" + drReport.ClientID + ",'" + hidId.Value + "','3');return false;")
                Case "2"
                    btnSelected.Attributes.Add("OnClick", "OpenReport(" + drReport.ClientID + ",'" + hidId.Value + "','2');return false;")
                Case Else
                    btnSelected.Attributes.Add("OnClick", "OpenReport(" + drReport.ClientID + ",'" + hidId.Value + "','');return false;")

            End Select
            '090325.net836
            BindAttach(objUser.UserId, intTrxNo, "")
        End If
    End Sub
#End Region
End Class