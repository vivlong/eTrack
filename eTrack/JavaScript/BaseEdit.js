<script language ="javascript" type="text/javascript">

var blChanged=false;


function SaveDetail(strTitle,intFlag)
{
    if (!StrToBool(SavePrompt) || window.confirm(ConfirmSave.replace("{0}",strTitle))) 
    { 
        if (!CanSave()) 
        {
            return;
        }
        context=intFlag;
        BeforeSave();
        var arg = "SaveData"+ParSeparator+GetDetail();
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SaveReturn", "context")%>;
    }
    else {
        if(intFlag) {
            NewDetail(1);
        }
        else {
            window.close();
        }
    }
}

function SaveReturn(result,context)
{
    AfterSave();
    var strResult=result.split(ParSeparator);
    switch(strResult.length)
    {
            case 2:
            if (strResult[0]==RtnOk) {
                if(context){
                    blChanged=true;
                    NewDetail(0);
                }
                else {
                    blChanged=true;
                    CloseWindow();
                }
            }
            else {
                window.alert(strResult[1]);
                if (strResult[0]==RtnTimeOut) {
                    CloseWindow();
                }
            }
            break;
        case 3:
        case 4:
        case 5:
            if (strResult[0]==RtnOk) {
                if(context){
                    blChanged=true;
                    NewDetail(0);
                    SetOtherSaveReturn(strResult);
                }
                else {
                    blChanged=true;
                    CloseWindow();
                }
            }
            else  {
                window.alert(strResult[1]);
                if (strResult[0]==RtnTimeOut) {
                    CloseWindow();
                }
            }  
            break;    
        default:
            window.alert(SaveUnexpectedError);
            break;
    }    
}

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



