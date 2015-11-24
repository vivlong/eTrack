<script language ="javascript" type="text/javascript">
function SelectedScan(selectId,LiCount)
{
        if (selectId==1){
                document.getElementById("a1").className="f12e navNml navOn";
                document.getElementById("a2").className="f12c navNml noSep";
                strWhere ="1";
        }
        else{
                document.getElementById("a2").className="f12e navNml navOn";
                document.getElementById("a1").className="f12c navNml noSep";
                strWhere ="2";
        }
    context = document.getElementById("divSource");
    intPage=1;
    ShowLoadingData();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+""+ParSeparator+strWhere+ParSeparator+"SortNo"+ParSeparator+" Desc"+ParSeparator+""; 
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSelectedScan", "context")%>; 
}
 function SetSelectedScan(result, context) 
{  
    HideLoadingData();
    arrTmp = result.split(ParSeparator);
    if(arrTmp.length==2 && arrTmp[1]!=null && arrTmp[1]!=""){
        intCount=arrTmp[0];
        if(intPage>intCount && intPage!=1){
            intPage=intCount;
        }
        context.innerHTML = arrTmp[1];
        return true;
    }
    else{
        return false;
    }
} 
var blChanged=false;
function CloseWindow()
{
    if(blChanged) {
        window.returnValue=RtnOk;
    }
    else {
        window.returnValue=RtnNoChange;
    }
    window.close();     
}
</script>