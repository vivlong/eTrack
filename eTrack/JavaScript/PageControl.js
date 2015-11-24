<script language ="javascript" type="text/javascript">
function SelectedDiv(selectId,LiCount)
{
    var DivName;
    var LiName;
    for(var i=1;i<=LiCount;i++){
        if (selectId==i){
                DivName="divMiddle"+selectId.toString();
                document.getElementById(DivName).style.display="block";
                LiName="a"+selectId.toString();
                document.getElementById(LiName).className="f12e navNml navOn";
        }
        else{
                DivName="divMiddle"+i.toString();
                document.getElementById(DivName).style.display="none";
                LiName="a"+i.toString();
                document.getElementById(LiName).className="f12c navNml noSep";
        }
    }
}
  
function ShowDivPage(divPage)
{
    var DivName="a"+divPage.toString();
    var obj=document.getElementById(DivName);
    if (obj.style.display=="none"){
        obj.style.display="inline-block";
    }
    else {
        obj.style.display="none";
    }
 }

</script>

