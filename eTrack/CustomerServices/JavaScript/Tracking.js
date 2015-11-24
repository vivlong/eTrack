<script language ="javascript" type="text/javascript">
function GetQueryValue()
{
 return "";
}


function fromchange()
{
    var obj=document.getElementById("drpFrom");
 if (obj.value=="ETD" || obj.value=="ETA") 
     {
        obj=document.getElementById("lblTo");
        obj.style.display = "inline-block";
        obj=document.getElementById("txtTo");
        obj.style.display = "inline-block";
        obj.value="";  
        obj=document.getElementById("txtFrom");
        obj.value="";   
        obj=document.getElementById("btnFrom");
        obj.style.display = "inline-block";
        obj=document.getElementById("btnTo");
        obj.style.display = "inline-block"; 
    }
    else{
        obj=document.getElementById("lblTo");
        obj.style.display = "none";
        obj=document.getElementById("txtTo");
        obj.style.display = "none";
        obj.value=""; 
        obj=document.getElementById("txtFrom");
        obj.value="";   
        obj=document.getElementById("btnFrom");
        obj.style.display = "none";
        obj=document.getElementById("btnTo");
        obj.style.display = "none"; 
        }
}
//showModalDialog
function GoToPage(url,title,width,height)
{

    var select =document.getElementById("drJobNo");
   var strfield=select.options[select.selectedIndex].value;
   var strval=document.getElementById("txt_serach").value;
   if(strval=="")
   {
   alert("No allow blank!")
   }
   else
   {
       var title=title;
       var url=url+"?strfield="+strfield+"&strval="+strval+"&Radom="+Math.random();
       var Width=width;
       var Height=height;
       var arguemnts = new Object();
       arguemnts.window = window;
        if (document.all&&window.print)
        {
            window.showModalDialog(url,arguemnts,"dialogWidth:" + Width + "px;dialogHeight:" + Height + "px;center:yes;status:no;scroll:no;help:no;");
        }
        else 
       { 
            window.open(url,"","width=" + Width + "px,height=" + Height + "px,resizable=1,scrollbars=1"); 
       }
   }
}
function BindTrackDownGrid(strobj)
{
        context=divSource2;
        var arg = "BindDownGridBack"+ParSeparator+strobj;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "TrackDownGridValue", "context")%>;
 }
 function TrackDownGridValue(result,context) 
{
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk)
             {
                context.innerHTML = strResult[1];
             }
            else if (strResult[1]!="")
            {
                //window.alert(strResult[1]);
            }
}
function AirSeaDetail(strUrl,width,height) //090113byzhiwei
{
    var ret;
        ret=WindowDialog(strUrl,width,height);
}
//090904
function GetQuery()
{
    var strValue="";
    var txt;
     //CustomerCode
    txt=document.getElementById("fldLoginType");
    var obj=document.getElementById("fldCustomerCode");
    if(txt.value==0){strValue =" and a.CustomerCode ='"+obj.value+"'";} 
    //SearchField
    obj=document.getElementById("drpSearch");
    var strDr=obj.options[obj.selectedIndex].value;
    txt=document.getElementById("txtSearch");
    if(txt.value.Trim()!=""){strValue +=" and a."+strDr+" like '%"+txt.value+"%'";}
        //Second line search
        obj=document.getElementById("drpFrom");
        var strDr=obj.options[obj.selectedIndex].value;
        if(strDr=="ETD" || strDr=="ETA")
        {
            txt=document.getElementById("txtFrom");
          if(txt.value.Trim()!="")
           { strValue +=" and datediff(d,'" + txt.value + "',"+ strDr + ")>=0 ";}
            txt=document.getElementById("txtTo");
          if(txt.value.Trim()!="") { strValue +=" and datediff(d,'" + txt.value + "',"+strDr+")<=0 "}
        }
        else
        {
          txt=document.getElementById("txtFrom");
          strValue +=" and a."+strDr+" ='"+txt.value+"'";    
        }
    strWhere=strValue;
}
//by lzw 090323
function GetQueryData() 
{   
    context = document.getElementById("divSource");
    intPage=1;
    ShowLoadingData();
    GetQuery();
    var arg = "GetPageData"+ParSeparator+intPage.toString()+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString()+ParSeparator+"";  
    WebForm_DoCallback('__Page',arg,SetSourceValue,context,null,false); 
} 
function ExportExcel()
{
    Loading();
    var arg = "ServerExportExcel"+ParSeparator+strQuery+ParSeparator+strWhere+ParSeparator+SortField+ParSeparator+SortDesc.toString();
    context=null;
    <%= ClientScript.GetCallbackEventReference(Me, "arg", "ShowExcelFile", "context")%>;
}
</script>
