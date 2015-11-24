<script language="javascript" type="text/javascript">
function Number()
{
    if (event.keyCode<48 || event.keyCode>57) {
       event.returnValue=false;
    }
}

function DateInput(dotlen)
{
    var myEle=event.srcElement;
    var myValue=String.fromCharCode(event.keyCode);
    if (myEle.readOnly) {
        return;
    }
    switch(dotlen) {
     //月   
     case 'mm':{event.returnValue = regInput(myEle, /(^0?[0-9]$)|(^1[0-2]$)/,  myValue); break;}
     //日   
     case 'dd':{event.returnValue = regInput(myEle, /(^[0-2]?[0-9]$)|(^3[0-1]$)/,  myValue); break;}
     //年   
     case 'yy':{event.returnValue = regInput(myEle, /^[1-2]\d{0,3}$/,  myValue); break;}
    }
}

function IsLegalDateRange(Year,firstMonth,lastMonth)
{
    if (Year.value=="" ) {
        window.alert("年份不能为空！");
        Year.focus();
        return false;
    }
    else if (firstMonth.value=="")  {
        window.alert("起始月份不能为空！");
        firstMonth.focus();
        return false;
    }
    else if (lastMonth.value=="")  {
        window.alert("结束月份不能为空！");
        lastMonth.focus();
        return false;
    }
    else if (parseInt(firstMonth.value,10)>parseInt(lastMonth.value,10)) {
        window.alert("起始月份必须小于结束月份！");
        firstMonth.focus();
        return false;
    }
    return true;
}
</script>

