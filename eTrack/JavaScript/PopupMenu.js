<script language="javascript" type="text/javascript">
 var menuskin = "skin";
 var CurrentId=0;
 
 function HideMenu(e) 
 {
     e = e||event;
    if (document.getElementById('popupMenu').style.display != "none"){
        document.getElementById('popupMenu').style.display = "none";
    }
 }
 
 function HighlighItem(e) 
 {
       e = e||event;
       srcObj = e.srcElement ? e.srcElement : e.target; 
      if (srcObj.className == "menuitems"){
          srcObj.style.border="0.1px solid";
          srcObj.style.backgroundColor = "LightSkyBlue";
          srcObj.style.color = "white";         
      }
 }

 function LowlightItem(e) 
 {
     e = e||event;
     srcObj = e.srcElement ? e.srcElement : e.target; 
     if (srcObj.className == "menuitems") {
         srcObj.style.border="";
         srcObj.style.backgroundColor = "";
         srcObj.style.color = "black";
         window.status = "";
      }
 }              
function ShowMenu(e,intId)
{ 
    e = e||event;
    var x = e.clientX;
    var y = e.clientY;
    CurrentId=intId;
    var rightedge = document.body.clientWidth-x;
    var bottomedge =document.body.clientHeight-y;
    var popupMenu= document .getElementById('popupMenu')
    if (rightedge <popupMenu.offsetWidth){
        popupMenu.style.left = document.body.scrollLeft + key.clientX - popupMenu.offsetWidth+"px";
    }
    else {
        popupMenu.style.left = document.body.scrollLeft + x+"px";
    }
    if (-bottomedge <80){
        popupMenu.style.top = document.body.scrollTop + y+"px";
    }
    else{        
        popupMenu.style.top = document.body.scrollTop + y-100+"px";
    }
    popupMenu.style.display = "block";
    return false;
}


//function showad(e,id){  
//var addiv = document.getElementById(id);
//e=e||event;
//var x = e.clientX;  
//var y = e.clientY;  

//addiv.className="showad";  
//addiv.style.top = y+ "px";  
//addiv.style.left = x+ "px";  
//}


function ClickItem(e) 
{
     e = e||event;
     srcObj = e.srcElement ? e.srcElement : e.target; 
    //var key = window.event ? e.keyCode : e.which;
     if (srcObj.className == "menuitems")  { 
         HideMenu(e);
         var arg=srcObj.getAttribute("Id");
         switch (arg){
             case "EditColumn":
                 GridColumnSet();
                 break;
            case "InsertDetail":
                InsertDetail();
                break;
            case "EditDetail":
                EditDetail(CurrentId);
                break;
            case "DeleteDetail":
                DeleteDetail(CurrentId);
                break;
            case "PrintDetail":
                PrintDetail(CurrentId)
                break;
         }
     }
 }
 
function GridColumnSet()
{
    /*
    var ret;
    ret=WindowDialog("../SysRef/DynamicColumnEdit.aspx?TableName="+TableName,600,450);
    if(ret!=null && ret!=""){
        GetPageData(null,0) ;
    }
    */
    layer.open({
        type: 2,
        title: 'Edit Column',
        maxmin: false,
        fix: true, 
        area : ['600px' , '450px'],
        content: '../SysRef/DynamicColumnEdit.aspx?TableName='+TableName,
        end: function(){
            GetPageData(null,0);
        }
    });
}

//--------------------------------------------------------------------------------------------------------
 
//作者:陈小朋 2007-01-07
window.Menu=function(isDir,text,handle)
{
 this.HTMLObj=null; //关联HTML对象
 this.ParentMenu=null; //父菜单
 this.SubMenus=[]; //存储子菜单数组
 this.ZIndex=900; //层
 this.IsDirectory=isDir?isDir:false; //是否是目录
 this.Text=text?text:"";
 this.Handle=handle?handle:""; //单击时所执行的语句,目录不支持此属性

 //创建并追加子菜单
 this.CreateSubMenu=function(isDir,text,handle)
 {
  if(this.IsDirectory)
  {
   var oMenu=new Menu();
   if(typeof(isDir)!="undefined")
   {
    oMenu.IsDirectory=isDir;
   }
   if(typeof(text)!="undefined")
   {
    oMenu.Text=text;
   }
   if(typeof(handle)!="undefined")
   {
    oMenu.Handle=handle;
   }
   this.AppendSubMenu(oMenu);
   return oMenu;
  }
  alert("出现错误,该对象不支持CreateSubMenu方法");
  return null;
 }

 //追加子菜单
 this.AppendSubMenu=function(oMenu)
 {
  this.SubMenus.push(oMenu);
  oMenu.ParentMenu=this;
  oMenu.ZIndex=this.ZIndex+1;
 }

 //插入子菜单
 this.InsertSubMenu=function(oMenu,iAlign)
 {
  if(iAlign>=this.SubMenus.length)
  {
   this.SubMenus.push(oMenu);
  }
  else
  {
   this.SubMenus.splice(iAlign,0,oMenu);
  }
  oMenu.ParentMenu=this;
  oMenu.ZIndex=this.ZIndex+1;
 }

 //移除子菜单
 this.RemoveSubMenu=function(iAlign)
 {
  var RemoveArr=this.SubMenus.splice(iAlign,1);
  if(RemoveArr.length>0)
  {
   if(RemoveArr[0].IsDirectory)
   {
    RemoveArr[0].Clear();
   }
   else
   {
    RemoveArr[0].HTMLObj.parentNode.removeChild(RemoveArr[0].HTMLObj);
   }
  }
 }

 //把子菜单的数据转换成HTML格式
 this.Create=function()
 {
  if(!this.IsDirectory)
  {
   alert("出现错误,该对象不支持Create方法");
   return false;
  }
  var ParentElement=document.createElement("span");
  this.ChildMenuHTMLObj=ParentElement; //关联子菜单的HTML对象容器
  ParentElement.style.cursor="default";
  ParentElement.style.position="absolute";
  ParentElement.style.visibility="hidden";
  ParentElement.style.zIndex=this.ZIndex;
  ParentElement.style.border="1px solid #464646"; 
  ParentElement.style.borderRight="1px solid #aaa";
  ParentElement.style.borderBottom="1px solid #aaa";
  ParentElement.style.borderTop="1px solid #fff";
  ParentElement.style.borderLeft="1px solid #fff";
  ParentElement.onmousedown=function(e)
  {
   Menu.Config.IsIE?window.event.cancelBubble=true:e.stopPropagation();
  }
  ParentElement.onselectstart=function()
  {
   return false;
  }  
  var table=document.createElement("table");
  table.cellPadding=0;
  table.cellSpacing=0;
  var tbody=document.createElement("tbody");
  var tr=document.createElement("tr");
  var ltd=document.createElement("td");
  var rtd=document.createElement("td");    
  ltd.style.width="25px";
  ltd.innerHTML=Menu.Config.IsIE?"<pre>  </pre>":"<pre>   </pre>";
  tr.appendChild(ltd);
  tr.appendChild(rtd);
  tbody.appendChild(tr);
  table.appendChild(tbody);
  ParentElement.appendChild(table);
  var len=this.SubMenus.length;
  if(len>0)
  {
   var ChildTable=document.createElement("table");
   var ChildTBody=document.createElement("tbody");
   ChildTable.border=0;
   ChildTable.cellPadding=0;
   ChildTable.cellSpacing=0;
   ChildTable.style.fontSize=Menu.Config.FontSize;
   ChildTable.style.color=Menu.Config.FontColor;
   ChildTable.appendChild(ChildTBody);
   rtd.appendChild(ChildTable);
  }
  for(var i=0;i<len;i++)
  {
   var tempTr=document.createElement("tr");
   //关联HTML对象和DATA对象
   this.SubMenus[i].HTMLObj=tempTr; //关联子菜单的HTML对象
   tempTr.DataObj=this.SubMenus[i];
   var tempTd=document.createElement("td");
   tempTr.style.backgroundColor=Menu.Config.BgColor;
   tempTr.appendChild(tempTd);
   tempTd.style.height=Menu.Config.PerMenuHeight;
   tempTd.vAlign="middle";
   tempTd.style.paddingLeft="5px";
   tempTd.style.paddingRight="5px";
   tempTr.onmouseover=this.SubMenus[i].MouseOver;
   tempTr.onmouseout=this.SubMenus[i].MouseOut;
   tempTr.onclick=this.SubMenus[i].Click;
   tempTd.innerHTML="<nobr>"+this.SubMenus[i].Text+"</nobr>";
   var DirectoryTd=document.createElement("td");
   if(this.SubMenus[i].IsDirectory)
   {
    DirectoryTd.innerHTML="<font face='webdings'>4</font>";
   }
   tempTr.appendChild(DirectoryTd);
   ChildTBody.appendChild(tempTr);
  }
  document.body.appendChild(ParentElement);
  for(var i=0;i<len;i++)
  {
   if(this.SubMenus[i].IsDirectory)
   {
    this.SubMenus[i].Create();
   }
  }
 }

 this.Show=function(e)
 {
  if(!this.IsDirectory)
  {
   alert("出现错误,该对象不支持Show方法");
   return false;
  }
  if(this.SubMenus.length==0) return;
  var ChildHTMLObj=this.ChildMenuHTMLObj;
  var DWidth=document.body.clientWidth;
  var DHeight=document.body.clientHeight;
  var left=document.body.scrollLeft,top=document.body.scrollTop;
  var x,y;
  if(this.ParentMenu==null) //根对象
  {
   x=e.clientX,y=e.clientY;
   if(x+ChildHTMLObj.offsetWidth>DWidth)
   {
    x-=ChildHTMLObj.offsetWidth;
   }
   if(y+ChildHTMLObj.offsetHeight>DHeight)
   {
    y-=ChildHTMLObj.offsetHeight;
   }
   x+=left;
   y+=top;
  }
  else
  {
   var CurrentHTMLObj=this.HTMLObj;
   var x=Menu.GetMenuPositionX(CurrentHTMLObj)+CurrentHTMLObj.offsetWidth,y=Menu.GetMenuPositionY(CurrentHTMLObj);
   if(x+ChildHTMLObj.offsetWidth>DWidth+left)
   {
    x-=(CurrentHTMLObj.offsetWidth+ChildHTMLObj.offsetWidth);
   }
   if(y+ChildHTMLObj.offsetHeight>DHeight+top)
   {
    y-=ChildHTMLObj.offsetHeight;
    y+=CurrentHTMLObj.offsetHeight;
   }
  }
  ChildHTMLObj.style.left=x;
  ChildHTMLObj.style.top=y;
  this.ChildMenuHTMLObj.style.visibility="visible";
 }
 this.Hidden=function()
 {  
  if(!this.IsDirectory)
  {
   alert("出现错误,该对象不支持Hidden方法");
   return false;
  }
  var len=this.SubMenus.length;
  for(var i=0;i<len;i++)
  {
   if(this.SubMenus[i].IsDirectory)
   {
    this.SubMenus[i].Hidden();
   }
  }
  this.ChildMenuHTMLObj.style.visibility="hidden";
 }

 this.MouseOver=function(e)
 {
  this.style.backgroundColor=Menu.Config.OverBgColor;
  var ParentMenu=this.DataObj.ParentMenu;
  var len=ParentMenu.SubMenus.length;
  for(var i=0;i<len;i++)
  {
   if(ParentMenu.SubMenus[i].IsDirectory)
   {
    ParentMenu.SubMenus[i].Hidden();
   }
  }
  if(this.DataObj.IsDirectory)
  {
   e=e?e:event;
   this.DataObj.Show(e);
  }
 }

 this.MouseOut=function()
 {
  this.style.backgroundColor=Menu.Config.BgColor;
 }

 this.Clear=function()
 {
  if(this.IsDirectory)
  {
   var len=this.SubMenus.length;
   for(var i=0;i<len;i++)
   {
    if(this.SubMenus[i].IsDirectory)
    {
     this.SubMenus[i].Clear();
    }
   }
  }
  document.body.removeChild(this.ChildMenuHTMLObj);
 }

 this.Click=function()
 { 
  if(!this.DataObj.IsDirectory)
  {
   eval(this.DataObj.Handle);
   Menu.Config.FirstMenu.Hidden();
  }
 }
}

//菜单配置
Menu.Config=
{
 FirstMenu:new Menu(true), //系统定义的第一个菜单,必须为容器(IsDirectory=true)
 BgColor:"#FFFFFF", //设置菜单背景颜色
 OverBgColor:"#B5BED6", //设置菜单鼠标经过时的背景颜色
 FontSize:"13px", //设置菜单字体大小
 FontColor:"#000000", //设置菜单字体颜色
 PerMenuHeight:"25px", //调整菜单的行距
 IsIE:document.all?true:false
};

Menu.GetMenuPositionX=function(obj)
{
 var ParentObj=obj;
 var left;
 left=ParentObj.offsetLeft;
 while(ParentObj=ParentObj.offsetParent){
  left+=ParentObj.offsetLeft;
 }
 return left;
}

Menu.GetMenuPositionY=function(obj)
{
 var ParentObj=obj;
 var top;
 top=ParentObj.offsetTop;
 while(ParentObj=ParentObj.offsetParent){
  top+=ParentObj.offsetTop;
 }
 return top;
}

Menu.Update=function()
{
 var FirstMenu=Menu.Config.FirstMenu;
 FirstMenu.Clear();
 FirstMenu.Create();
}

//事件
window.onload=function()
{ 
 Menu.Config.FirstMenu.Create();
 document.oncontextmenu=function(e)
 {
  Menu.Config.FirstMenu.Hidden();
  e=e?e:event;
  Menu.Config.FirstMenu.Show(e);
  return false;
 }
 document.onmousedown=function()
 {
  Menu.Config.FirstMenu.Hidden();
 }
}
</script>
