<script type="text/javascript" language ="javascript">
     function SelectedDivl(selectId,LiCount)
   {
    var DivName;
    var LiName;
    for(var i=1;i<=LiCount;i++)
    {
        if (selectId==i)
        {
                LiName="a"+selectId.toString();
                document.getElementById(LiName).className="f12e navNml navOn";
        }
        else{
                LiName="a"+i.toString();
                document.getElementById(LiName).className="f12c navNml noSep";
             }
    }
    SortField="TrxNo";
    if(selectId==1)
    { 
          TableName="sebl1";
         // strQuery="sebl1";
          $('#divdrpSearch1').css("display","block");
          $('#divdrpSearch2').css("display","none");
    }
    else if(selectId==2)
    {
          TableName="Sibl1_BillofLading";
          //strQuery="sibl1";
          $('#divdrpSearch1').css("display","none");
          $('#divdrpSearch2').css("display","block");
    }
     document.getElementById('hidVal_BillofLading').value=selectId;
     context=document.getElementById('hid_div');
     var arg="SetTabVal"+ParSeparator+selectId;
     <%= ClientScript.GetCallbackEventReference(Me,"arg","SetResult", "context")%>; 
    }
       function SetResult(result,context)
   {
    var strResult=result.split(ParSeparator);
            if (strResult[0]==RtnOk) {
            context.innerHTML=strResult[1];
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
   }
       function GetQuery() 
    {
        //by lzw
        strWhere="";
        var strWhereBook = "";
        var strQuery = document.getElementById("txtSearch").value;
        var objSearchField = document.getElementById("drpSearch1");
        var divdrpSearch1 = document.getElementById("divdrpSearch1");        
        if(divdrpSearch1.style.display=="" || divdrpSearch1.style.display=="block"){objSearchField = document.getElementById("drpSearch1");}
        else{objSearchField = document.getElementById("drpSearch2");}
        if (objSearchField) 
        {
            var arrFieldName = objSearchField.options[objSearchField.selectedIndex].value.split(",");
            if(arrFieldName[0].length!=0)
            {    
                if (arrFieldName[1] == "0") 
                {
                    if (strQuery.Trim == "") 
                    {
                        strWhere = " and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";
                    }
                    else { strWhere = "  and " + arrFieldName[0] + " like '%" + strQuery + "%' "; }
                }
                else 
                {
                    if (strQuery.Trim == "") 
                    {
                        strWhere = "  and (" + arrFieldName[0] + " is null or " + arrFieldName[0] + "='') ";
                    }
                    else { strWhere = "  and Cast(" + arrFieldName[0] + " as NVarChar(50))" + " like '%" + strQuery + "%' "; }
                }
            }
        }
        strWhere = strWhere + strWhereBook;
    }
   function AdvGetQuery() {}
</script>
