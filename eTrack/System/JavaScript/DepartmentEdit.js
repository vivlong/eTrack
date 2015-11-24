<script language ="javascript" type="text/javascript">

function CanSave()
{
    var txt;
  
    txt=document.getElementById("txtsDepartNo");
    if (txt.value.Rtrim()=="")
    {
        window.alert("编号不能为空!");
        txt.focus();
        return false;
    }
    txt=document.getElementById("txtsDepartName");
    if (txt.value.Rtrim()=="")
    {
        window.alert("名称不能为空!");
        txt.focus();
        return false;
    }
    return true;
}

function GetDetail()
{
    var strDetail="";
    var drop=document.getElementById("drpsDepartManager");
    strDetail=document.getElementById("fldId").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsDepartNo").value;
    strDetail=strDetail+ColSeparator+document.getElementById("txtsDepartName").value;
    strDetail=strDetail+ColSeparator+drop.options[drop.selectedIndex].text;
    strDetail=strDetail+ColSeparator+drop.options[drop.selectedIndex].value;
    return strDetail;
}

function NewDetail(intFlag)
{
    document.getElementById("fldId").value="-1";
    document.getElementById("txtsDepartNo").value="";
    document.getElementById("txtsDepartName").value="";
    document.getElementById("drpsDepartManager").selectedIndex=0;
    document.getElementById("txtsDepartNo").focus();
}

</script>








