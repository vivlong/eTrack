<script language="javascript" type="text/javascript">
//Change the Long date format to short date format when the focus move to the date field (Mask Edit Box).            												
//Will call from the Date field(Mask Edit) Got_Focus Event  
//06-12-09 to 2009-12-06 
function SingleToLongDate(strDate)
{
  if(strDate.length==14)
  {
    var strYear=strDate.substring(6,8);
    var strMonth=strDate.substring(3,5);
    var strDay=strDate.substring(0,2);
    var strTime="";
    if(strDate.length==15){strTime=strDate.substring(10,strDate.length);}
    else{strTime="";}
    if(parseInt(strYear,10)=="NaN" || parseInt(strMonth,10)=="NaN" || parseInt(strDay,10)=="NaN"){return "";}
    if(parseInt(strYear,10)==0){strYear="2000";}
    else if(parseInt(strYear,10)>0 && parseInt(strYear,10)<=50){strYear="20"+strYear;}
    else if(parseInt(strYear,10)>=50 && parseInt(strYear,10)<=99){strYear="19"+strYear;}
    else {return "";}
    return strYear+"-"+strMonth+"-"+strDay+" "+strTime;
  }
  else{return "";}
}

//2009-12-06 to "12-Dec-00 10:30"
function StringToLongDate(strDate) //OnFocus
{
     var strMonth="";
     if(strDate.length!=10){return false;}
     else
     {
       strMonth=strDate.substring(5,7);
       ConMonth=MonthConvert(strMonth,1)
       return strDate.substring(8,10)+"-"+ConMonth+"-"+ strDate.substring(2,4);
       
     }
}
          												
//E.g "12-Dec-00 10:30" will change to "12-12-00 10:30"     
function ChangeShortDate(objName) //OnFocus
{
     var strMonth="";
     var obj =document .getElementById(objName);
     if(obj.value.length!=9 && obj.value.length!=15){return false;} 
     else 
     {
       strMonth=obj.value.substring(3,6);
       ConMonth=MonthConvert(strMonth,0)
       obj.value=obj.value.substring(0,3)+ConMonth+ obj.value.substring(6,obj.value.length);
     }
}
function ChangeLongDate(objName) //OnFocus
{
     var strMonth="";
     var obj =document .getElementById(objName);
     if(obj.value.length!=14 && obj.value.length!=8){return false;} 
     else 
     {
       strMonth=obj.value.substring(3,5);
       ConMonth=MonthConvert(strMonth,1)
       obj.value=obj.value.substring(0,3)+ConMonth+ obj.value.substring(5,obj.value.length);
     }
}
function ConvertDate(strDate)
{
  if(strDate.length==9 || strDate.length==15)
  {
    var strYear=strDate.substring(7,9);
    var strMonth=strDate.substring(3,6);
    var strDay=strDate.substring(0,2);
    var strTime="";
    if(strDate.length==15){strTime=strDate.substring(10,strDate.length);}
    else{strTime="";}
    if(parseInt(strYear,10)=="NaN" || parseInt(strMonth,10)=="NaN" || parseInt(strDay,10)=="NaN"){return "";}
    if(parseInt(strYear,10)==0){strYear="2000";}
    else if(parseInt(strYear,10)>0 && parseInt(strYear,10)<=50){strYear="20"+strYear;}
    else if(parseInt(strYear,10)>=50 && parseInt(strYear,10)<=99){strYear="19"+strYear;}
    else {return "";}
    strMonth=MonthConvert(strMonth,0);
    return strYear+"-"+strMonth+"-"+strDay+" "+strTime;
  }
  else{return "";}

}

function MonthConvert(Month,ConvertFlag) //0-word to number ; 1-number to word toUpperCase
{
  Month=Month.toUpperCase();
  if(!ConvertFlag)
  {
      switch (Month)
     {
       case "JAN":{ return "01"; break;}
       case "FEB":{ return "02"; break;}
       case "MAR":{ return "03"; break;}
       case "APR":{ return "04"; break;}
       case "MAY":{ return "05"; break;}
       case "JUN":{ return "06"; break;}
       case "JUL":{ return "07"; break;}
       case "AUG":{ return "08"; break;}
       case "SEP":{ return "09"; break;}
       case "OCT":{ return "10"; break;}
       case "NOV":{ return "11"; break;}
       case "DEC":{ return "12"; break;}
       default:{return "  "}
     }
  }
  else
  {
      switch (Month)
     {
       case "01":{ return "Jan"; break;}
       case "02":{ return "Feb"; break;}
       case "03":{ return "Mar"; break;}
       case "04":{ return "Apr"; break;}
       case "05":{ return "May"; break;}
       case "06":{ return "Jun"; break;}
       case "07":{ return "Jul"; break;}
       case "08":{ return "Aug"; break;}
       case "09":{ return "Sep"; break;}
       case "10":{ return "Oct"; break;}
       case "11":{ return "Nov"; break;}
       case "12":{ return "Dec"; break;}
       default:{return "  "}
     }
  }
}

function  TxtAreaLength(objName,intLength)
{
  var obj =document .getElementById(objName);
  return obj.value.length<=intLength;
}

function Number(event) //OnKeyPress
{
    if (event.keyCode<48 || event.keyCode>57) {
       event.returnValue=false;
    }
}
function FloatNum(objName,event) //OnKeyPress
{
    if (event.keyCode<48 || event.keyCode>57) {
 
        var obj =document .getElementById(objName);
         if(event.keyCode==46)
            {
               if(obj.value.indexOf(".")>0){event.returnValue=false; return false;}
               else
               {
                  var rngSel = document.selection.createRange();
                  var rngTxt = obj.createTextRange();
                  var flag = rngSel.getBookmark();
                  rngTxt.collapse();
                  rngTxt.moveToBookmark(flag);
                  rngTxt.moveStart('character',-obj.value.length);
                  str = rngTxt.text.replace(/\r\n/g,'');
                  if(str.length==0){event.returnValue=false; return false;}
               }
            }
          else{event.returnValue=false;}
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
</script>


