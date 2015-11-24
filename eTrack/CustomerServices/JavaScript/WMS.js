<script type="text/javascript" language ="javascript">
function iniControl()
{
 //tab 1
 //drCustomerCode
 var obj =document .getElementById("drCustomerCode");
     obj.selectedIndex=0;
 //lblCustomerName
     obj =document .getElementById("lblCustomerName");
      obj.value="";
 //drProductCode
     obj =document .getElementById("drProductCode");
     obj.selectedIndex=0;
 //hid_val
     obj =document .getElementById("hid_val");
  ClearField(obj);
 //tab 2
  //drCustomerCode1
    obj =document.getElementById("drCustomerCode1");
    obj.selectedIndex=0;
  //txtCustomerName1
    obj =document.getElementById("txtCustomerName1");
    obj.value="";
 //drProductCode1
     obj =document.getElementById("drProductCode1");
     obj.selectedIndex=0;
 //lblCustomerName
     obj =document .getElementById("txtMovenMentDateFrom");
     obj.value="";
 //lblCustomerName
     obj =document .getElementById("txtMovenMentDateTo");
     obj.value="";        
 //tab 3
  //drCustomerCode2
    obj =document.getElementById("drCustomerCode2");
     obj.selectedIndex=0;
 //txtCustomerName2
     obj =document.getElementById("txtCustomerName2");
      obj.value="";
 //txtBrandName
     obj =document.getElementById("txtBrandName");
      obj.value="";
 //drProductCode2
     obj =document.getElementById("drProductCode2");
     obj.selectedIndex=0;
 //txtProductCode2
     obj =document.getElementById("txtProductCode2");
      obj.value="";
 //txtDateFrom
     obj =document.getElementById("txtDateFrom");
      obj.value="";
 //txtDateTo
     obj =document.getElementById("txtDateTo");
      obj.value="";
 //drWarehouseCode2
     obj =document.getElementById("drWarehouseCode2");
     obj.selectedIndex=0;
 //txtWarehouseName2
     obj =document.getElementById("txtWarehouseName2");
      obj.value="";
 //drDimensionFlag
     obj =document.getElementById("drDimensionFlag");
     obj.selectedIndex=0;      
     FunSummary();
}
function ConvertDate(strDate)
{
  strDate=strDate.substr(6)+"-"+strDate.substr(3,2)+"-"+strDate.substr(0,2);
  return strDate;
}

function ClearField(hid_val)
{
    if(hid_val.value=="1" || hid_val.value=="detail")
    {
var obj=document.getElementById("drProductCodeField");
    obj.length=0;
var hid_AddField=document.getElementById("hid_AddField")
    hid_AddField.value="";
    }
    else if(hid_val.value=="2")
    {
    var obj=document.getElementById("drProductCodeField1");
    obj.length=0;
var hid_AddField=document.getElementById("hid_AddField1")
    hid_AddField.value="";
    }
}
function RemoveField(hid_val)
{
    if(hid_val.value=="1" || hid_val.value=="detail")
    {
var hid_AddField=document.getElementById("hid_AddField")
var objPD=document.getElementById("drProductCodeField");
if(objPD.options.length>0)
{
var strsplit=ColSeparator+objPD.options[0].text;
hid_AddField.value=hid_AddField.value.replace(strsplit,"")
    objPD.options[objPD.selectedIndex]=null;
 }
     }
    else if(hid_val.value=="2")
    {
    var hid_AddField=document.getElementById("hid_AddField1")

    var objPD=document.getElementById("drProductCodeField1");
    if(objPD.options.length>0)
{
    var strsplit=ColSeparator+objPD.options[0].text;

    hid_AddField.value=hid_AddField.value.replace(strsplit,"")
       objPD.options[0]=null;
 }
    }
}

function AddField(hid_val)
{
    var strValue="";
    var txt;
    //SearchField
    if(hid_val.value==1 || hid_val.value=="detail")
    {
        obj=document.getElementById("drProductCode");
        strValue=obj.options[obj.selectedIndex].value;
        if(document.getElementById("hid_AddField").value.indexOf(strValue)< 0 )
        {document.getElementById("hid_AddField").value+=ColSeparator+strValue}
        //setValue 
        var objPD=document.getElementById("drProductCodeField");
        for(var i=objPD.options.length-1;i> -1;i--) 
        { 
         if(objPD.options[i].text==strValue) { objPD.options[i]=null; }
        }
             var tOption = document.createElement("Option");
             tOption.text=strValue;
             tOption.value=document.getElementById("drProductCode").options.length+1;
             //*********
        objPD.options.add(tOption);
        for(var i=objPD.options.length-1;i> -1;i--) 
        { 
        objPD.appendChild(objPD.options[i]) ;
        objPD.options[objPD.selectedIndex].value=strValue;
        }
        objPD.selectedIndex=0;
    }
    else if (hid_val.value==2)
    {
        obj=document.getElementById("drProductCode1");
        strValue=obj.options[obj.selectedIndex].value;
        if(document.getElementById("hid_AddField1").value.indexOf(strValue)< 0 )
        {document.getElementById("hid_AddField1").value+=ColSeparator+strValue}
        //setValue 
                var objPD=document.getElementById("drProductCodeField1");
        for(var i=objPD.options.length-1;i> -1;i--) 
        {
        if(objPD.options[i].text==strValue)
        {
        objPD.options[i]=null;
        }
        }
         var tOption = document.createElement("Option");
         tOption.text=strValue;
         tOption.value=document.getElementById("drProductCode1").options.length+1;
        //*********
        objPD.options.add(tOption);
        for(var i=objPD.options.length-1;i> -1;i--) 
        { 
        objPD.appendChild(objPD.options[i]) ;
        objPD.options[objPD.selectedIndex].value=strValue;
        }
        objPD.selectedIndex=0;
    }
}
// change CustomerCode and CustomerName
function CustomerCodechange(type,drCustomerCode,drProductCode){
TabType=type;
if (type =="Bal"){context=document.getElementById("div_ProductCode");}
else if(type =="Mov") {context=document.getElementById("div_ProductCode1");}
else if(type =="Inv") {context=document.getElementById("div_ProductCode2");}
var strName=drCustomerCode.options[drCustomerCode.selectedIndex].value;
//-------------
document.getElementById("txtProductCode2").value="";
//---------------
var strCode=drCustomerCode.options[drCustomerCode.selectedIndex].text
var arg="CustomerChange"+ParSeparator+strCode+ParSeparator+strName+ParSeparator+type;
<%= ClientScript.GetCallbackEventReference(Me,"arg","SetProductCode", "context")%>; 
}

function SetProductCode(result,context) 
{ 

    var strResult=result.split(ParSeparator);
 
            if (strResult[0]==RtnOk) {
                if (strResult[3] =="Bal"){document.getElementById("divCustomerName").innerHTML=strResult[2];}
                else if(strResult[3] =="Mov"){document.getElementById("divCustomerName1").innerHTML=strResult[2];}
                else if(strResult[3] =="Inv"){document.getElementById("divCustomerName2").innerHTML=strResult[2];}
                context.innerHTML=strResult[1];
            }
            else if (strResult[1]!=""){
                window.alert(strResult[1]);
            }
            var  hid_val=document.getElementById("hid_val");
            ClearField(hid_val);
}
// change CustomerCode and CustomerName
function SetDropValue(DropCon,type)
{
  var strDropCon= DropCon.options[DropCon.selectedIndex].value;
  strHidCon1=DropCon.selectedIndex;
  var arg="SetDropValue"+ParSeparator+strDropCon+ParSeparator+type;
<%= ClientScript.GetCallbackEventReference(Me,"arg","SetDropValueS", "context")%>; 
}
function SetDropValueS(result,context) 
{ 
    var strResult=result.split(ParSeparator);
    if(strResult[0]=='drCustomerCode2') {document.getElementById("divCustomerName2").innerHTML=strResult[1];}
    if(strResult[0]=='drProductCode2') {document.getElementById("div_ProductName2").innerHTML=strResult[1];}
    if(strResult[0]=='drWarehouseCode2') {document.getElementById("divWarehouseCode2").innerHTML=strResult[1];}
     if(strResult[0]=='drDimensionFlag') {document.getElementById("divDimensionFlag").innerHTML=strResult[1];}  
}
//dateChange
function SetDateValue(txtCon,type)
{
  var strCon= txtCon.value;
  var arg="SetDateValue"+ParSeparator+strCon+ParSeparator+type;
<%= ClientScript.GetCallbackEventReference(Me,"arg","SetDateValueR", "context")%>; 
}
function SetDateValueR(result,context) 
{return false ;}
//set strWhere value
function GetQueryValue()
{
  strWhere="";
  var strValue="";
  var drValue="";
  var obj ;
  var srrhid_val=document.getElementById("hid_val").value;
        //Impm1_Detail
        if(TableName=="Impm1_Detail"){  
        var strValue="";
        strQuery="Impm1_Detail";
        
        document.getElementById("divColumn").style.display="inline";
        document.getElementById("divSummary").style.display="inline";
        document.getElementById("divDetail").style.display="none";
        strWhere+=strValue;
        }
        else if(TableName=="impm1_Balance")//impm1_Balance
        {
          var obj=document.getElementById("drCustomerCode");
          if(obj.selectedIndex==-1){strWhere="  and 1!=1";return false;}
           var strValue=obj.selectedIndex;
           //CustomerCode 
           if (strValue != "0")
           {strWhere=" and a.CustomerCode ='" + obj.options[obj.selectedIndex].text + "' ";} 
           obj=document.getElementById("hid_AddField") 
            //ProductCode
            var drValue="";
            obj=document.getElementById("drProductCode");
            if(obj.selectedIndex != "0")
            {
            if(document.getElementById("hid_AddField").value=="")
            {drValue=" and a.ProductCode ='" + obj.options[obj.selectedIndex].text + "' ";}
            else {drValue="'" + obj.options[obj.selectedIndex].text + "',";}
            }
            obj=document.getElementById("hid_AddField")
            if(obj.value.Trim()!="")
            {
              var arrProductCode=obj.value.Trim().split(ColSeparator);
                if (arrProductCode.length >0)
                 {
                    var i = 0;
                    var strProductCode= "";
                    for(i = 0;i< arrProductCode.length;i++)
                    {if(arrProductCode[i] != "")  {strProductCode += "'" + arrProductCode[i] + "',";}}
                    strProductCode = strProductCode.substring(0, strProductCode.length - 1);
                    if(strProductCode.length > 0){strWhere += " and ProductCode in (" + strProductCode + ")";}
                 }
             }
            else
            {strWhere+=drValue;}
            //movementDate
            obj=document.getElementById("txtAsonDate");
            strValue=obj.value;
            if(strValue != "")
            {
                var strsql = " and datediff(d,'" + ConvertDate(strValue) + "',movementDate)<=0 "
                strWhere += strsql;    
            }
            
          //RefNo
        obj=document.getElementById("txtRefNo");
        strValue=obj.value;
        if(strValue != "")
        {
            var strsql = " and RefNo = '"+ strValue +"' "
            strWhere += strsql;    
        }
            

           if(strWhere.Trim()==""){strWhere="  and 1!=1";}
          }
  else if(TableName=="Impm1_Movement")
       {
        strQuery="Impm1_Movement";
        var obj=document.getElementById("drCustomerCode1");
        var strValue=obj.selectedIndex;
           //CustomerCode 
           if (strValue != "0")
           {strWhere=" and a.CustomerCode ='" + obj.options[obj.selectedIndex].text + "' ";} 
           obj=document.getElementById("hid_AddField1") 
            //ProductCode
            var drValue="";
            obj=document.getElementById("drProductCode1");
            if(obj.selectedIndex != "0")
            {
            if(document.getElementById("hid_AddField1").value=="")
            {drValue=" and a.ProductCode ='" + obj.options[obj.selectedIndex].text + "' ";}
            else {drValue="'" + obj.options[obj.selectedIndex].text + "',";}
            }
            obj=document.getElementById("hid_AddField1")
            if(obj.value.Trim()!="")
            {
              var arrProductCode=obj.value.Trim().split(ColSeparator);
                if (arrProductCode.length >0)
                 {
                    var i = 0;
                    var strProductCode= "";
                    for(i = 0;i< arrProductCode.length;i++)
                      {
                        if(arrProductCode[i] != "")  {strProductCode += "'" + arrProductCode[i] + "',";}              
                      }
                    strProductCode = strProductCode.substring(0, strProductCode.length - 1);
                    if(strProductCode.length > 0){strWhere += " and ProductCode in (" + strProductCode + ")";}
                 }
             }
            else
            {strWhere+=drValue;}
        //movementDateFrom
        obj=document.getElementById("txtMovenMentDateFrom");
        strValue=obj.value;
        if(strValue != "")
        {
        }
        //movementDateTo
        obj=document.getElementById("txtMovenMentDateTo");
        strValue=obj.value;
        if(strValue != "")
        {
            var strsql = " and datediff(d,'" + ConvertDate(strValue) + "',movementDate)<=0 "
            strWhere += strsql;    
        }
        
         //RefNo
        obj=document.getElementById("txtRefNo1");
        strValue=obj.value;
        if(strValue != "")
        {
            var strsql = " and RefNo = '"+ strValue +"' "
            strWhere += strsql;    
        }
        }
   else if(TableName=="Impm1_Inventory1"){GetInventoryQuery();}
   MutiTab=strQuery;
   return TableName;
}

function GetInventoryQuery()
{
    strQuery="Impm1_Inventory1";
    var strValue="";
    var obj=document.getElementById("drCustomerCode2");
    var strobj=obj.options[obj.selectedIndex].text;
    if(obj.selectedIndex > 0){strValue  += " and a.CustomerCode like '%" + strobj + "%' ";}
     obj=document.getElementById("drProductCode2");
    //SearchField
    if(obj.selectedIndex > 0){
     strobj=obj.options[obj.selectedIndex].text;    
    strValue += " and a.ProductCode like '%" + strobj + "%' ";}
    obj=document.getElementById("txtBrandName");
    if(obj.value.Trim()!=""){strValue +="  and a.BrandName like '%"+obj.value+"%'  ";}
    //drWarehouseCode2
     obj=document.getElementById("drWarehouseCode2");

    if(obj.selectedIndex > 0){
         strobj=obj.options[obj.selectedIndex].text;
    strValue +="  and a.WarehouseCode like '%"+strobj+"%'  ";}
    strWhere+=strValue;
    obj=document.getElementById("txtDateFrom");
    var strDateFrom=obj.value.Trim();
    
    if(strDateFrom.Trim()!="")
    {strWhere+=" and Convert(varchar(10), a.movementdate, 20) >='"+ConvertDate(strDateFrom) + "' ";
     document.getElementById("hidDateFrom").value=ConvertDate(strDateFrom);
     strHidCon2=ConvertDate(strDateFrom);
    }
     obj=document.getElementById("txtDateTo");
     var strDateTo=obj.value;
     if(strDateTo.Trim()!=""){strWhere+=" and Convert(varchar(10), a.movementdate, 20) <='"+ConvertDate(strDateTo) + "' ";
     document.getElementById("hidDateTo").value=ConvertDate(strDateTo);
     strHidCon3=ConvertDate(strDateTo);
    }
}
 
 function FunSummary()
{
 document.getElementById("divDetail").style.display="inline";
 document.getElementById("divSummary").style.display="none";
 document.getElementById("divColumn").style.display="none";
}
function SelMultiType(objCode)
{
    var orderby="ProductCode";
    var strSql="ProductCode as [Product Code],ProductName as [Product Name],Description ~~ impm1 ~~ "
    var strSearchCode="ProductCode@Product Code~ProductName@Product Name";
    var ret=WindowDialog("../Reference/MultiCheckType.aspx?Sql="+strSql+"&SearchCode="+strSearchCode+"&orderby="+orderby,<%= SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null)
    {
     var strRel=ret.split(ColSeparator);
     for(var i=0;i<strRel.length;i++ )
     {
      strRel[i]=strRel[i]=="&nbsp;"?" ":strRel[i];
      strRel[i]=strRel[i].replace('amp;','');
     }
    var objPD=document.getElementById(objCode);
    if (objPD!=null)
    {
    for(var j=objPD.options.length-1;j> -1;j--) 
    { 
        objPD.options[j]=null;
        //objPD.remove[j];
    }
    }
    for(var k=0;k< strRel.length-1;k++) 
    { 
        var tOption = document.createElement("Option");
             tOption.text=strRel[k];
             tOption.value=strRel[k];
            objPD.options.add(tOption);
    }
        objPD.selectedIndex=0;
    }
}
function AddToDrp(hid_val)
{
    var strValue="";
    var txt;
    //SearchField
        obj=document.getElementById("drProductCode");
        strValue=obj.options[obj.selectedIndex].value;
        if(document.getElementById("hid_AddField").value.indexOf(strValue)< 0 )
        {document.getElementById("hid_AddField").value+=ColSeparator+strValue}
        //setValue 
        var objPD=document.getElementById("drProductCodeField");
        for(var i=objPD.options.length-1;i> -1;i--) 
        { 
         if(objPD.options[i].text==strValue) { objPD.options[i]=null; }
        }
             var tOption = document.createElement("Option");
             tOption.text=strValue;
             tOption.value=document.getElementById("drProductCode").options.length+1;
             //*********
        objPD.options.add(tOption);
        for(var i=objPD.options.length-1;i> -1;i--) 
        { 
        objPD.appendChild(objPD.options[i]) ;
        objPD.options[objPD.selectedIndex].value=strValue;
        }
        objPD.selectedIndex=0;
}
</script>
