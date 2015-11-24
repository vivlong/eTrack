<script language ="javascript" type="text/javascript">

function CanSave()
{
    return true;
}

function GetDetail()
{
    var strDetail="";
    var obj=document.getElementById("txtJobNo");
    strDetail=obj.value;
    obj=document.getElementById("fldId");
    strDetail=strDetail+ColSeparator+obj.value;
    obj=document.getElementById("txtDateTime");
    strDetail=strDetail+ColSeparator+obj.value;
    obj=document.getElementById("txtDescription");
    strDetail=strDetail+ColSeparator+obj.value;
    obj=document.getElementById("txtRefNo");
    strDetail=strDetail+ColSeparator+obj.value;
    obj=document.getElementById("fldUpdateBy");
    strDetail=strDetail+ColSeparator+obj.value;
    obj=document.getElementById("drpStatusCode");
    strDetail=strDetail+ColSeparator+obj.options[obj.selectedIndex].value;

    return strDetail;
}

function NewDetail(intFlag)
{
    var obj=document.getElementById("txtDateTime");
    obj.value="";
    obj.focus();
    obj=document.getElementById("txtDescription");
    obj.value="";
    obj=document.getElementById("txtRefNo");
    obj.value="";
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








