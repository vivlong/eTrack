<script language="javascript" type="text/javascript">
function EditDetail(strBatchNo,strFun)
{
    var ret;
    if (EditPage.indexOf(".aspx?")>0){
        ret=WindowDialog(EditPage+"&Id="+strBatchNo+"&strFun="+strFun,1024,540);
    }
    else{
        ret=WindowDialog(EditPage+"?Id="+strBatchNo+"&strFun="+strFun,1024,540);
    }
    if (ret==RtnOk) {
        GetPageData(null,-1)
    }
}

function DeleteCTSO2(strContainerNo)
{
            if (window.confirm("Are you sure to delete this record?")) 
            {
                context = document.getElementById("divSource");
                var arg = "DeleteCTSO2"+ParSeparator+strContainerNo.toString();
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetDeleteCTSO2", "context")%>;
            }
}
function SetDeleteCTSO2(result,context) 
{ 
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
                //----------------------------------
                intCount=strResult[2];
                if(intPage>intCount && intPage!=1){
                    intPage=intCount;
                }
                var lbl=document.getElementById("lblPage");
                lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
                var txt=document.getElementById("txtPage");
                txt.value=intPage.toString();
                //----------------------------------
            }
            else {
            alert(strResult[1]);
            }
}
</script>