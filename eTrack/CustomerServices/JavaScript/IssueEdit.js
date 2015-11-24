<script language ="javascript" type="text/javascript">
function SaveOmtx2(strTitle,strTrxNo)
{
    var blankFlag=0;
    var strFile="";
    var signFrame = document.getElementById("gvwSource");
    var tr;
       if(signFrame.rows.length == 1){blankFlag+=1}
       else if (signFrame.rows.length > 1)
       { 
            tr = signFrame.rows[signFrame.rows.length-1];
              if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
              {
                 strContainerNO=tr.cells[1].childNodes[0].value.replace(/,/g,"");
                       //check mentory
                       if(tr.cells[1].childNodes[0].value=="" && tr.cells[2].childNodes[0].value=="" && tr.cells[3].childNodes[0].value==""){ window.close();return false ;}
                       strFile+=strTrxNo;            //TrxNo
                       strFile+=",'"+ConvertDate(tr.cells[1].childNodes[0].value.replace(/,/g,""))+"'";   //Date
                       strFile+=","+tr.cells[2].childNodes[0].value.replace(/,/g,"");   //PackingQty
                       strFile+=",'"+tr.cells[3].childNodes[0].value.replace(/,/g,"")+"'";   //Remark
    
              }
       }
       if(strFile.indexOf('undefined')<0)
       {
            context = document.getElementById("divSource");
            var arg = "SaveOneRecord"+ParSeparator+strFile+ParSeparator+strTrxNo;
            <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSaveOne", "context")%>;  
       }
}
 
function ConvertDate(strDate)
{
  if(strDate.length==10)
  {
    var strYear=strDate.substring(6,10);
    var strMonth=strDate.substring(3,5);
    var strDay=strDate.substring(0,2);
    var strTime="";
    if(parseInt(strYear,10)=="NaN" || parseInt(strMonth,10)=="NaN" || parseInt(strDay,10)=="NaN"){return "";}
    return strYear+"-"+strMonth+"-"+strDay+" "+strTime;
  }
  else{return "";}

}
       //UpdteValue-Onfocus
       function UpdateRecord(TrxNo,LineItemNo,FieldName,conField)
       {
        var valField="";
         valField= conField.value.replace("'","''");
        if(FieldName=='PackingQty'){if(valField==""){valField=0;}}
        if(FieldName=='Date'){
          if(valField!=""){valField= ConvertDate(valField);}
          if(valField==""){valField='null';}
        }
        if(FieldName!='PackingQty'&& valField!='null')
        {valField="'"+valField+"'";}
        var strslq=" update omtx2 set "+FieldName+"="+valField+" where TrxNo="+TrxNo+" and LineItemNo="+LineItemNo;
        context = document.getElementById("divSource");
        var arg = "UpdateRecord"+ParSeparator+strslq+ParSeparator+TrxNo+ParSeparator+LineItemNo+ParSeparator+conField.id+ParSeparator+valField;
        <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetUpdateRecord", "context")%>;
       }
      function SetUpdateRecord(result,context) 
       {
        var strResult=result.split(ParSeparator);
          if (strResult[0]==RtnOk){
            blChanged=true;
            context.innerHTML = strResult[1];
           }
             else{alert(strResult[1]);}
       }
function DeleteData(intId,lineitem)
{
            if (window.confirm("Are you sure to delete this record?")) 
            {
                context = document.getElementById("divSource");
                var arg = "DeleteData"+ParSeparator+intId.toString()+ParSeparator+lineitem.toString();
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetDeleteData", "context")%>;
            }
  function SetDeleteData(result,context) 
  { 
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
                blChanged=true;
                context.innerHTML = strResult[1];
            }
            else if (strResult[1]!=""){
            }
  }
}
function SaveOneRecord(strTrxNo)
{
   if((event.keyCode==13)||(event.keyCode==0x28)||(event.keyCode==9)) 
   {
        var blankFlag=0;
        var strFile="";
        var signFrame = document.getElementById("gvwSource");
        var tr;
           if(signFrame.rows.length == 1){blankFlag+=1}
           else if (signFrame.rows.length > 1)
           { 
                tr = signFrame.rows[signFrame.rows.length-1];
                  if (tr.cells[1].hasChildNodes() && (tr.cells[1].childNodes[0].nodeType==1)) 
                  {
                     strContainerNO=tr.cells[1].childNodes[0].value.replace(/,/g,"");
                           //check mentory
                           if(tr.cells[1].childNodes[0].value=="" && tr.cells[2].childNodes[0].value=="" && tr.cells[3].childNodes[0].value==""){tr.cells[1].childNodes[0].focus(); return false ;}
                           strFile+=strTrxNo;            //TrxNo
                           strFile+=",'"+ConvertDate(tr.cells[1].childNodes[0].value.replace(/,/g,""))+"'";   //Date
                           strFile+=","+tr.cells[2].childNodes[0].value.replace(/,/g,"");   //PackingQty
                           strFile+=",'"+tr.cells[3].childNodes[0].value.replace(/,/g,"")+"'";   //Remark
        
                  }
           }
           if(strFile.indexOf('undefined')<0)
           {
                context = document.getElementById("divSource");
                var arg = "SaveOneRecord"+ParSeparator+strFile+ParSeparator+strTrxNo;
                <%= ClientScript.GetCallbackEventReference(Me, "arg", "SetSaveOne", "context")%>;  
           }
      }
}
function SetSaveOne(result,context) 
{
    var strResult=result.split(ParSeparator);
       if (strResult[0]==RtnOk) { context.innerHTML = strResult[1];blChanged=true;}
       else{alert(strResult[1]);}
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