<script language="javascript" type="text/javascript">
var ReadType=1;

function GetDownload(intReadFlag)
{
    var LiName;
    for(var i=1;i<=9;i++) {
        LiName="a"+i.toString();
        if (intReadFlag==i){
            document.getElementById(LiName).className="f12e navNml navOn";
        }
        else {
            document.getElementById(LiName).className="f12c navNml noSep";
        }
    }
    ReadType = intReadFlag;
    switch(ReadType){
        case 1:
            strWhere = "a.bRead=0";
            break;
        case 2:
            strWhere = "a.bRead=1";
            break;
        default:
            strWhere = "";
            break;
    }
}

function SelectedDiv(selectId,LiCount)
{
    var DivName;
    var LiName;
    for(var i=1;i<=LiCount;i++){
        if (selectId==i){
                DivName="divMiddle"+selectId.toString();
                document.getElementById(DivName).style.display="block";
                LiName="a"+selectId.toString();
                document.getElementById(LiName).className="f12e navNml navOn";
        }
        else{
                DivName="divMiddle"+i.toString();
                document.getElementById(DivName).style.display="none";
                LiName="a"+i.toString();
                document.getElementById(LiName).className="f12c navNml noSep";
        }
    }
}

function AddSelectedDownloadAttach1()
{
////    var strId="4.5";
    var strId = 1;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div1;
        var arg = "AddSelectedDownloadAttach1"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach1(strFileName)
{
////    var strId="4.5"; 
    var strId = 1;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div1;
        var arg = "DeleteOneDownloadAttach1"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedDownloadAttach2()
{
////    var strId="5.0";
    var strId = 2;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div2;
        var arg = "AddSelectedDownloadAttach2"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach2(strFileName)
{
////    var strId="5.0";
    var strId = 2;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div2;
        var arg = "DeleteOneDownloadAttach2"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedDownloadAttach3()
{
////    var strId="4.5 Project";
    var strId = 3;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div3;
        var arg = "AddSelectedDownloadAttach3"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach3(strFileName)
{
////    var strId="4.5 Project";
    var strId = 3;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div3;
        var arg = "DeleteOneDownloadAttach3"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedDownloadAttach4()
{
////    var strId="5.0 Project";
    var strId = 4;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div4;
        var arg = "AddSelectedDownloadAttach4"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach4(strFileName)
{
////    var strId="5.0 Project";
    var strId = 4;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div4;
        var arg = "DeleteOneDownloadAttach4"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedDownloadAttach5()
{
////    var strId="User Manual";
    var strId = 5;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div5;
        var arg = "AddSelectedDownloadAttach5"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach5(strFileName)
{
////    var strId="User Manual";
    var strId = 5;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div5;
        var arg = "DeleteOneDownloadAttach5"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedDownloadAttach6()
{
////    var strId="Others";
    var strId = 6;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div6;
        var arg = "AddSelectedDownloadAttach6"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach6(strFileName)
{
////    var strId="Others";
    var strId = 6;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div6;
        var arg = "DeleteOneDownloadAttach6"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedDownloadAttach7()
{
////    var strId="Net";
    var strId = 7;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div7;
        var arg = "AddSelectedDownloadAttach7"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach7(strFileName)
{
////    var strId="Net";
    var strId = 7;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div7;
        var arg = "DeleteOneDownloadAttach7"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedDownloadAttach8()
{
////    var strId="Net Project";
    var strId = 8;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div8;
        var arg = "AddSelectedDownloadAttach8"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach8(strFileName)
{
////    var strId="Net Project";
    var strId = 8;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div8;
        var arg = "DeleteOneDownloadAttach8"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedDownloadAttach9()
{
////    var strId="New EXE";
    var strId = 9;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div9;
        var arg = "AddSelectedDownloadAttach9"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach9(strFileName)
{
////    var strId="Net EXE";
    var strId = 9;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div9;
        var arg = "DeleteOneDownloadAttach9"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedDownloadAttach10()
{
////    var strId="Internal 4.5";
    var strId = 10;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div10;
        var arg = "AddSelectedDownloadAttach10"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach10(strFileName)
{
////    var strId="Internal 4.5";
    var strId = 10;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div10;
        var arg = "DeleteOneDownloadAttach10"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function AddSelectedDownloadAttach11()
{
////    var strId="Internal 5.0";
    var strId = 11;
    var ret=WindowDialog("DownloadAttachEdit.aspx?Id="+strId,640,450);
    if(ret!=null && ret!=""){
        context= div11;
        var arg = "AddSelectedDownloadAttach11"+ParSeparator+ret; 
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function DeleteOneDownloadAttach11(strFileName)
{
////    var strId="Internal 5.0";
    var strId = 11;
    if (window.confirm("Are you sure to delete current select download?")) {
        context=div11;
        var arg = "DeleteOneDownloadAttach11"+ParSeparator+strId+ParSeparator+strFileName;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetReturnValue", "context")%>;
    }
}

function SetReturnValue(result,context) 
{ 
    var strResult=result.split(ParSeparator);
    switch(strResult.length) {
        case 2:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
            break;
        case 3:
            if (strResult[0]==RtnOk) {
                context.innerHTML = strResult[1];
                document.getElementById("fldId").value=strResult[2];
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
            break;
        default:
            break;
    }    
}

//function SetReturnValue(result,context)
//{
//    strResult=result.split(ParSeparator);
//    if (strResult.length==4) {
//        switch(strResult[0])
//        {
//            case RtnOk:
//                intCount=strResult[2];
//                if(intPage>intCount && intPage!=1){
//                    intPage=intCount;
//                }
//                context.innerHTML = strResult[3]; 
//                var lbl=document.getElementById("lblPage");
//                lbl.innerHTML = PageTitle + intPage.toString() + PageSeparator + intCount.toString();
//                var txt=document.getElementById("txtPage");
//                txt.value=intPage.toString();
//                if(StrToBool(SuccessPrompt)){
//                    window.alert(strResult[1]);
//                }
//                break;
//            default:
//                window.alert(strResult[1]);
//                break;
//        }
//       else {
//       window.alert("test1");
//       } 
//    }
//////    else {
//////        window.alert(ReturnValueError);
//////    }
//}
</script>

