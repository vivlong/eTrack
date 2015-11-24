<script language ="javascript" type="text/javascript">

function InsertDetail()
{
    var ret=WindowDialog(EditPage,EditWidth,EditHeight);
    if (ret==RtnOk) {
        GetPageData(null,-1)
    }
}

function EditDetail(intId)
{
    var ret;
    if (EditPage.indexOf(".aspx?")>0){
        ret=WindowDialog(EditPage+"&Id="+intId.toString(),EditWidth,EditHeight);
    }
    else{
        ret=WindowDialog(EditPage+"?Id="+intId.toString(),EditWidth,EditHeight);
    }
    if (ret==RtnOk) {
        GetPageData(null,-1)
    }
}
//bylzw for po 090707
function EditDetail(intId,FunNo)
{
    var ret;
    if (EditPage.indexOf(".aspx?")>0){
        ret=WindowDialog(EditPage+"&Id="+intId.toString()+"&FunNo="+FunNo,EditWidth,EditHeight);
    }
    else{
        ret=WindowDialog(EditPage+"?Id="+intId.toString()+"&FunNo="+FunNo,EditWidth,EditHeight);
    }
    if (ret==RtnOk) {
        GetPageData(null,-1)
    }
}

function DeleteDetail(intId)
{
    if (!StrToBool(DeletePrompt) || window.confirm(ConfirmDelete)) {
        context = document.getElementById("divSource");
        var arg = "DeleteOneData"+ParSeparator+intId.toString()+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function UndeleteDetail(intId)
{
    if (window.confirm(ConfirmRestore)) {
        context = document.getElementById("divSource");
        var arg = "UndeleteOneData"+ParSeparator+intId.toString()+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function SetReturnValue(result,context)
{
    strResult=result.split(ParSeparator);
    if (strResult.length==4) {
        switch(strResult[0])
        {
            case RtnOk:
                intCount=strResult[2];
                if(intPage>intCount && intPage!=1){
                    intPage=intCount;
                }
                context.innerHTML = strResult[3]; 
                var lbl=document.getElementById("lblPage");
                lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
                var txt=document.getElementById("txtPage");
                txt.value=intPage.toString();
                if(StrToBool(SuccessPrompt)){
                   window.alert(strResult[1]);
                }
                break;
            default:
                window.alert(strResult[1]);
                break;
        }
    } 
    else {
        window.alert(ReturnValueError);
    }
}

</script>