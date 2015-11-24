<script language ="javascript" type="text/javascript">

function CanSave()
{
    var txt;
    txt=document.getElementById("txtsCompNo");
    if (txt.value.Rtrim()=="")
    {
        window.alert("Company code must input!");
        txt.focus();
        return false;
    }
    txt=document.getElementById("txtsCnCompPartName");
    if (txt.value.Rtrim()=="")
    {
        window.alert("Company abbreviate name must input!");
        txt.focus();
        return false;
    }
    txt=document.getElementById("txtsCnCompName");
    if (txt.value.Rtrim()=="")
    {
        window.alert("Company name must input!");
        txt.focus();
        return false;
    }
    txt=document.getElementById("txtsSmtpPassword");
    txt2=document.getElementById("txtsConfirmPassword");
    if (txt.value!=txt2.value){
        window.alert("Smtp Password is not equal to the confirm password!");
        txt.focus();
        return false;
    }
    return true;
}

function GetDetail()
{
    var strDetail="";
    strDetail=document.getElementById("fldId").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsCompNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsCnCompPartName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsCnCompName").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsCnCompAddr").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsCompTel").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsCompFax").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsCompZip").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsCompWeb").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsCompEmail").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsSmtpServer").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsSmtpPort").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsSmtpUser").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsSmtpPassword").value;
    return strDetail;
}

function NewDetail(intFlag)
{
    document.getElementById("fldId").value="-1";
    document.getElementById("txtsCompNo").value="";
    document.getElementById("txtsCnCompPartName").value="";
    document.getElementById("txtsCnCompName").value="";
    document.getElementById("txtsCnCompAddr").value="";
    document.getElementById("txtsCompTel").value="";
    document.getElementById("txtsCompFax").value="";
    document.getElementById("txtsCompZip").value="";
    document.getElementById("txtsCompWeb").value="";
    document.getElementById("txtsCompEmail").value="";
    document.getElementById("txtsSmtpServer").value="";
    document.getElementById("txtsSmtpPort").value="";
    document.getElementById("txtsSmtpUser").value="";
    document.getElementById("txtsSmtpPassword").value="";
    SelectedDiv(1,2)
    document.getElementById("txtsCompNo").focus();
}

function BeforeSave()
{
    document.getElementById("btnSave").disabled=true;
    document.getElementById("btnNew").disabled=true;
    document.getElementById("btnClose").disabled=true;
    document.getElementById("SaveHint").style.display = "block";
}

function AfterSave()
{
    document.getElementById("btnSave").disabled=false;
    document.getElementById("btnNew").disabled=false;
    document.getElementById("btnClose").disabled=false;
    document.getElementById("SaveHint").style.display = "none";
}

</script>








