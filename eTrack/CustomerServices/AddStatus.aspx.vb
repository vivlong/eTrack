Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports SysMagic.ZZPage
Imports SysMagic.SystemClass
Imports SysMagic

Partial Class Matra_AddStatus
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fldId.Value = Request("RfqNo").ToString()
            btnDateUpdated.Attributes.Add("OnClick", "showCalendar(txtDateUpdated,0);return false;")
            btnActivityDate.Attributes.Add("OnClick", "showCalendar(txtActivityDate,0);return false;")
            btnCode.Attributes.Add("OnClick", "selBindCode(" + txtCode.ClientID + "," + txtDescription.ClientID + ",'Jmst1','StatusCode,StatusDesc','','Status Code','Status Description');return false;")
            txtCode.Attributes.Add("OnBlur", "CheckValid('Jmst1','StatusCode'," + txtCode.ClientID + ",'','Invalid Status Code.');return false;")
        End If
    End Sub

    Public Function CheckValid(ByVal strTable As String, ByVal strFieldName As String, ByVal strValue As String, ByVal strWhere As String, ByVal strErrMessage As String) As String
        If Len(strValue) = 0 Then Return ZZMessage.ConMsgRtn.Ok + "" : Exit Function
        Dim strSQL As String = "SELECT StatusDesc FROM " & strTable & " WHERE " & strFieldName & "='" & strValue & "' " & strWhere
        Dim ds As DataSet = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, strSQL)
        If ds.Tables(0).Rows.Count > 0 Then
            Return ZZMessage.ConMsgRtn.Ok + ConSeparator.Par + ds.Tables(0).Rows(0).Item(0).ToString()
        Else
            Return ZZMessage.ConMsgRtn.Err + ConSeparator.Par + strErrMessage
        End If
    End Function

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim intMax As Integer
        Dim strSQL As String
        Dim param(5) As SqlParameter
        If Len(txtCode.Text) = 0 Then
            Exit Sub
        End If
        strSQL = "SELECT ISNULL(Max(LineItemNo),0) FROM Jmar2 WHERE RfqNo = '" & fldId.Value & "'"
        Dim dt As DataTable = BaseSelectSrvr.GetData(strSQL, "")
        intMax = dt.Rows.Item(0).Item(0) + 1
        param(0) = New SqlParameter("@RfqNo", SqlDbType.NVarChar)
        param(0).Value = fldId.Value

        param(1) = New SqlParameter("@LineItemNo", SqlDbType.SmallInt)
        param(1).Value = intMax

        param(2) = New SqlParameter("@ActivityDate", SqlDbType.DateTime)
        param(2).Value = GeneralFun.StringToDate(txtActivityDate.Text.Trim)

        param(3) = New SqlParameter("@StatusCode", SqlDbType.NVarChar)
        param(3).Value = txtCode.Text.Trim

        param(4) = New SqlParameter("@StatusDate", SqlDbType.DateTime)
        param(4).Value = GeneralFun.StringToDate(txtDateUpdated.Text.Trim)

        param(5) = New SqlParameter("@StatusDesc", SqlDbType.NVarChar)
        param(5).Value = txtDescription.Text.Trim

        Dim intResult As Integer
        intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_Jmar2", param)

        Response.Write("<script>returnValue=1;window.close();</script>")
    End Sub

End Class
