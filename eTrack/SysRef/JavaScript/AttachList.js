<script language ="javascript" type="text/javascript">
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
function AddSelectedAttach()
{
    blChanged=true;
    var strId=document.getElementById("hidId").value;
    var strFolder=document.getElementById("hidFolder").value;
    var ret=WindowDialog("AttachEdit.aspx?Id="+strId+"&Folder="+strFolder,640,450);
    if(ret!=null && ret!=""){
        context = document.getElementById("divAttach");
        var arg = "AddSelectedAttach"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneAttach(strFileName)
{   
    blChanged=true;
    var strId=document.getElementById("hidId").value;
    if (window.confirm("Are you sure to delete current select attachment?")) {
        context = document.getElementById("divAttach");
        var arg = "DeleteOneAttach"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}
function SetOtherSaveReturn(strResult)
{
    if(strResult.length==4){
        document.getElementById("divAttach").innerHTML=strResult[2];
        document.getElementById("hidId").value=strResult[3];
    }
}
function SetReturnValue(result,context) 
{ 
  var strResult=result.split(ParSeparator);
  if (strResult[0]==RtnOk) {context.innerHTML = strResult[1];}
}
</script>