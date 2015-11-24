<script language ="javascript" type="text/javascript">

    function CheckValid(strTable,strFieldName,strControl,strWhere,strErrMessage)
        {
            context=strControl;
            var arg = "CheckValid"+ParSeparator+strTable+ParSeparator+strFieldName+ParSeparator+strControl.value+ParSeparator+strWhere+ParSeparator+strErrMessage;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "CheckValidReturn", "context")%>;
        }
    
    function CheckValidReturn(result,context)
    {
        var strResult=result.split(ParSeparator);
        if(strResult[0]==RtnOk)
        {
            //do nothing
        }
        else
        {
            alert(strResult[1]);
            context.focus();
        }
    }
    
    function CheckBlank()
    {
        alert('Status Code must be entered.');
        document.getElementById("txtCode").focus();
        return false;
    }
    
        function selBindCode(txtCode,txtName,table,fields,where,showCode,showName)
        {
            var ret=WindowDialog("../SysRef/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
            if(ret!=null) 
            {
             var strRel=ret.split(ColSeparator);
            if (strRel.length==2) 
            {
                var txt=strRel[1]=="&nbsp;"?" ":strRel[1];
                txt=txt.replace('amp;','');
                txtName.value=txt;
                txtCode.value=strRel[0];
            }
        }
    }
    
</script>

