<script language ="javascript" type="text/javascript">
function findObj(theObj, theDoc)
{
var p, i, foundObj;
if(!theDoc) theDoc = document;
if( (p = theObj.indexOf("?")) > 0 && parent.frames.length)
{ 
    theDoc = parent.frames[theObj.substring(p+1)].document;    
    theObj = theObj.substring(0,p); 
} 
if(!(foundObj = theDoc[theObj]) && theDoc.all) 
    foundObj = theDoc.all[theObj]; 

for (i=0; !foundObj && i < theDoc.forms.length; i++)     
    foundObj = theDoc.forms[i][theObj]; 

for(i=0; !foundObj && theDoc.layers && i < theDoc.layers.length; i++)     
    foundObj = findObj(theObj,theDoc.layers[i].document); 
    
if(!foundObj && document.getElementById) 
    foundObj = document.getElementById(theObj);    

return foundObj;
}
function AddSignRow(flag)
{
var txtTRLastIndex = findObj("txtTRLastIndex",document);
var rowID = parseInt(txtTRLastIndex.value);
var signFrame = findObj("gvwDimension",document);

//var signFrame = document.getElementById("gvwDimension");
var newTR = signFrame.insertRow(signFrame.rows.length);
newTR.id = "SignItem" + rowID;
//del
var newDeleteTD=newTR.insertCell(0);
newDeleteTD.innerHTML = "<a  href='javascript:;' onclick=\"DeleteSignRow('SignItem" + rowID + "')\"><img src='../Images/Edit/ed_delete.gif' alt='delete' //><//a>";
//S/No
var newIdTD=newTR.insertCell(1);
//newNameTD.innerHTML = rowID;
//Pcs
var newPcsTD=newTR.insertCell(2);
newPcsTD.innerHTML = "<input name='txtPcs" + rowID + "' id='txtPcs" + rowID + "' type='text' size='12' class='TextBox'  onKeyDown='txtKeyPress()' OnKeyUp='GetTotalValue()' style='width:120px' //>";
//Weight
var newWeightTD=newTR.insertCell(3);
newWeightTD.innerHTML = "<input name='txtWeight" + rowID + "' id='txtWeight" + rowID + "' type='text' size='12' class='TextBox'  onKeyDown='txtKeyPress()' OnKeyUp='GetTotalValue()' style='width:120px'//>";
//Length
var newWeightTD=newTR.insertCell(4);
newWeightTD.innerHTML = "<input name='txtWeight" + rowID + "' id='txtWeight" + rowID + "' type='text' size='12' class='TextBox'  onKeyDown='txtKeyPress()' OnKeyUp='GetTotalValue()' style='width:120px'//>";
//Width
var newWidthTD=newTR.insertCell(5);
newWidthTD.innerHTML = "<input name='txtWidth" + rowID + "' id='txtWidth" + rowID + "' type='text' size='12' class='TextBox'  onKeyDown='txtKeyPress()' OnKeyUp='GetTotalValue()' style='width:120px'//>";
//Height
var newHeightTD=newTR.insertCell(6);
newHeightTD.innerHTML = "<input name='txtHeight" + rowID + "' id='txtHeight" + rowID + "' type='text' size='12' class='TextBox'  onKeyDown='txtKeyPress()' OnKeyUp='GetTotalValue()' style='width:120px'//>";
//Volume
var newHeightTD=newTR.insertCell(7);
newHeightTD.innerHTML = "<a  id='txtHeight" + rowID + "' type='text' size='12' ><//a>";
//set the line no to the next line
txtTRLastIndex.value = (rowID + 1).toString() ;

var signFrame = findObj("gvwDimension",document);
var signItem = findObj(rowid,document);
//Get Delete Index
var rowIndex = signItem.rowIndex;
for(i=rowIndex;i<signFrame.rows.length;i++){
signFrame.rows[i].cells[1].innerHTML = i.toString();
}


}
//Delete Row
function DeleteSignRow(rowid)
{
var signFrame = findObj("gvwDimension",document);
var signItem = findObj(rowid,document);
//Get Delete Index
var rowIndex = signItem.rowIndex;
//  Delete Index Row
signFrame.deleteRow(rowIndex);
for(i=rowIndex;i<signFrame.rows.length;i++){
signFrame.rows[i].cells[1].innerHTML = i.toString();
}
}
    function   txtKeyPress()
    {  
         var e=window.event;   
         if(e.keyCode==13) 
         {  
              e.keyCode=9;
              var strRow=e.srcElement.parentElement.parentElement.rowIndex;
              if(e.srcElement.parentElement.cellIndex==6)
              {
                 var signFrame = findObj("gvwDimension",document);
                 var leng= signFrame.rows.length-1;
                 tr = signFrame.rows[leng];
                 var flat =true;
                   for (var j = 2; j< tr.cells.length-1; j++) 
                     {
                        if (tr.cells[j].childNodes[0].value!="") { flat=false; }
                     }
                 if(flat==false && strRow==leng){AddSignRow(2);}
            }
         }
         else{return;}
    }
//////////////////////////////////////////////////////////////////////////////////////////////////
         function txtonload(oText) 
      {
          if(oText.value.Trim()=='') oText.value='0';
      }    

          //float
      function FormatAfterDotNumber(ValueString, nAfterDotNum)
    {
        var ValueString,nAfterDotNum ;
        var resultStr,nTen;
        ValueString = ""+ValueString+"";
        strLen = ValueString.length;
        dotPos = ValueString.indexOf(".",0);
        if (dotPos == -1)
            {
　　        resultStr = ValueString+".";
　　        for (i=0;i<nAfterDotNum ;i++){resultStr = resultStr+"0";}
　　        return resultStr;
            }
        else
            {
　　         if ((strLen - dotPos - 1) >= nAfterDotNum)
　　            {
　　　　          nAfter = dotPos + nAfterDotNum  + 1;
　　　　          nTen =1;
　　　　          for(j=0;j<nAfterDotNum ;j++){nTen = nTen*10;}
　　　　          resultStr = Math.round(parseFloat(ValueString)*nTen)/nTen;
　　　　          return resultStr;
　　            }
　　        else{
　　　　            resultStr = ValueString;
　　　　            for (i=0;i<(nAfterDotNum  - strLen + dotPos + 1);i++){resultStr = resultStr+"0";}
　　　　            return resultStr;
　　            }
　　        }
　   }
 function KeyPress(objTR)
{
   var txtval = objTR.value;
   var key = event.keyCode;
   if((key <48 || key >57)&&key !=46)
   {
         event.keyCode = 0;
   }
   else
   {
         if(key == 46)
         {
               if(txtval.indexOf(".") != -1 || txtval.length == 0)
                     event.keyCode = 0;
         }
   }
} 
function setFirstFocus()
{
    var signFrame = document.getElementById("gvwDimension");
    var tr;
    if (signFrame.rows.length > 1)
    { 
            tr = signFrame.rows[1];
            if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) 
              {
                tr.cells[2].focus();
              }
    }
}
function GetTotalValue()
{

    var TotalPcs=0
    var TotalWeight=0
    var TotalVolumn=0
    var signFrame = document.getElementById("gvwDimension");
    var tr;
    if (signFrame.rows.length > 1)
    { 
        for (var i = 1; i < signFrame.rows.length; i++) 
        {
            tr = signFrame.rows[i];
              if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType==1)) 
              {
              var filPcs=tr.cells[2].childNodes[0].value==""?"0":tr.cells[2].childNodes[0].value;
              var filWeight=tr.cells[3].childNodes[0].value==""?"0":tr.cells[3].childNodes[0].value; 
              var filVolumn=tr.cells[7].childNodes[0].innerHTML==""?"0":tr.cells[7].childNodes[0].innerHTML;
              var Cell2=0;
              var Cell3=0;
              var Cell4=0;
              var Cell5=0;
              var Cell6=0;
             if(tr.cells[2].childNodes[0].value.Trim()==""){Cell2=0;} else{Cell2=tr.cells[2].childNodes[0].value;}
             if(tr.cells[3].childNodes[0].value.Trim()==""){Cell3=0;} else{Cell3=tr.cells[3].childNodes[0].value;}
             if(tr.cells[4].childNodes[0].value.Trim()==""){Cell4=0;} else{Cell4=tr.cells[4].childNodes[0].value;}
             if(tr.cells[5].childNodes[0].value.Trim()==""){Cell5=0;} else{Cell5=tr.cells[5].childNodes[0].value;}
             if(tr.cells[6].childNodes[0].value.Trim()==""){Cell6=0;} else{Cell6=tr.cells[6].childNodes[0].value;}
             var strsum=parseInt(Cell2)*parseFloat(Cell4)*parseFloat(Cell5)*parseFloat(Cell6);
              tr.cells[7].childNodes[0].innerHTML=strsum.toFixed(0);
                 TotalPcs += +parseFloat(filPcs);
                 TotalWeight += +parseFloat(filWeight);
                 var obj =document.getElementById("drDimension")
                 if(obj.selectedIndex==0)
                 {
                    TotalVolumn += +parseFloat(filVolumn)/1000000;       
                 }
                 else
                 {
                    TotalVolumn += +parseFloat(filVolumn)*6000/(1000000*366); 
                 }
              }
          }
          document.getElementById("txtTotalPcs").innerHTML=TotalPcs;
          document.getElementById("txtTotalWeight").innerHTML=TotalWeight;
          document.getElementById("txtTotalVolumn").innerHTML=FormatAfterDotNumber(TotalVolumn,3);
      }
      if(signFrame.rows.length<=1)
      {
          document.getElementById("txtTotalPcs").innerHTML=0;
          document.getElementById("txtTotalWeight").innerHTML=0;
          document.getElementById("txtTotalVolumn").innerHTML=0;
      }
}
</script>