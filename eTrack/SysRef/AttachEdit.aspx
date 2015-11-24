<%@ Page Language="VB" AutoEventWireup="true" CodeFile="AttachEdit.aspx.vb" Inherits="AttachEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Attachment</title>
    <base target="_self"></base>
    <link href="../App_Themes/LrErp.css" rel="Stylesheet" type="text/css" />
    <link href="../App_Themes/PageControl.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/AttachEdit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
        var Count=0
        function AddFile()
        {
            var paconBody =document.getElementById("conBody")
            var newnode=paconBody.firstChild.cloneNode(true);
            if(paconBody.firstElementChild)
            {
             newnode=paconBody.firstElementChild.cloneNode(true);
            }
          document.getElementById("conBody").appendChild(newnode);
        }
        function DelFile()
        {
            var td = document.getElementById("conBody");
            var l = td.childNodes.length;
            if(l == 1) {
                window.alert("This is the last upload object, cann't be deleted!"); 
             }
             else {
                  td.removeChild(td.childNodes[l - 1]); 
             }
        }
        function SelectFile()
        {
            document.getElementById("FileSelect").click();
        }
        function change()
        {
            var myEle=event.srcElement;
            var id=myEle.id
            var lblId=id.replace("FileSelect","lblFile");
            if (document.getElementById(lblId)){
                if (document.getElementById(id).value!=""){
                    document.getElementById(lblId).innerHTML=document.getElementById(id).value;
                }
            }
        }
    </script>
    <script type="text/javascript" language="javascript" src="../JavaScript/Common.js"> </script>
</head>
<body onload="ChangeHeight('divMiddle',634,364);" >
    <form id="frmUploadFile" runat="server">
    <div id="divTopNav" style="width: 638px">
        <ul id="ulTopNav">
            <li>
                <asp:Label ID="a1" CssClass="f12e navNml navOn" runat="server" Text="<%$ Resources:a1.Text %>"></asp:Label></li>
        </ul>
    </div>
    <%--<div id="divMiddle" class="divBorder" style="height: 360px;">
            <div id="TdFile" style="text-align: right;">
                <input id="FileSelect" type="file" class="FileUpload" runat="server" style="height: 20px;
                    size: 200px;" />
            </div>
        </div>--%>
    <div id="divMiddle" class="divBorder">
        <table style="widows: 100%;">
            <tbody id="conBody">
                <tr>
                    <td style="width: 7%;">
                    </td>
                    <td>
                        <input id="FileSelect" type="file" style="width: 500px;" size="100" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div id="divBottomNav" style="padding-right: 5px; padding-top: 5px; text-align :right ;">
        <input type="button" value="Add" class="Button" onclick="AddFile();" />
        <input type="button" value="Delete" class="Button" onclick="DelFile();" />
        <asp:Button ID="BtnUpload" runat="server" CssClass="Button" Text="<%$ Resources:BtnUpload.Text %>"
            OnClick="BtnUpload_Click" UseSubmitBehavior="False"></asp:Button>
    </div>
    </form>
</body>
</html>
