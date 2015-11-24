<script language ="javascript" type="text/javascript">
function selCN(txtCode,txtName,table,fields,where,showCode,showName)
{
    var ret=WindowDialog("../SysRef/TypeSort.aspx?table="+table+"&fields="+fields+"&where="+where+"&showCode="+showCode+"&showName="+showName,<%=SysMagic.SystemClass.InfoListSize.Width%>,<%=SysMagic.SystemClass.InfoListSize.Height%>);
    if(ret!=null) 
    {
         var strRel=ret.split(ColSeparator);
         if (strRel.length==2) 
         { 
            var txt=strRel[1]=="&nbsp;"?" ":strRel[1];
            txt=txt.replace('amp;','');
            txtCode.value=strRel[0];
            //txtName.value=txt;
             
         }
    }
}
</script>