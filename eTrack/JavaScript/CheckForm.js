<script language="javascript" type="text/javascript">
function pwdMatch(pwd1,pwd2){
	if( pwd1.value != pwd2.value){
		alert("密码不匹配，请重输！");
		pwd1.focus();
		return false;
	}else{
		return true;
	}
}


function pwdMatch_src(){
	var oppwd = document.frm.oppwd.value;
	var oppwdcert = document.frm.oppwdcert.value;
	if( oppwd != oppwdcert){
		alert("密码不匹配，请重输！");
		document.frm.oppwd.focus();
		return false;
	}else{
		return true;
	}
}

//***********************************************************************
//函数名：isNum		              功能：判断字符串是不是全数字组成
//输入参数：待判断的字符串       输出参数：若全是数字返回true,否则返回false
//创建者：yyk			        创建日期：2001/08/31
//更改者：			            更改日期：
//************************************************************************
function isNum(strSrc){
	var strNum = "0123456789";
	var len = strSrc.length;
	for(var i=0;i<len;i++){
		if (strNum.indexOf(strSrc.charAt(i))<0){
			return false;
		}
	}
	return true;
}

//***********************************************************************
//函数名：isFloat	              功能：判断字符串是不是数，整数或小数
//输入参数：待判断的字符串       输出参数：若全是整数或小数返回true,否则返回false
//创建者：ggk			        创建日期：2002/11/30
//更改者：			            更改日期：
//调用形式 isFloat (STRING s [, BOOLEAN emptyOK])
//************************************************************************

function isFloat (s)
{
	if(parseFloat(s)>999999999999999){
		alert("对不起，您输入的金额不能超过999999999999999！")
		return false;
	}

    var reFloat = /^((\d+(\.\d*)?)|((\d+\.)?\d+))$/
    if (isEmpty(s))
       if (isFloat.arguments.length == 1) return false;
       else return (isFloat.arguments[1] == true);

    return reFloat.test(s)
}
//***********************************************************************
//函数名：isTelnum		     功能：判断字符串是不是全数字跟'(',')','-'组成
//输入参数：待判断的字符串       输出参数：若是返回true,否则返回false
//创建者：yyk			        创建日期：2001/09/06
//更改者：			            更改日期：
//************************************************************************
function isTelnum(strSrc){
	var strTelnum = "0123456789()-, ";
	var len = strSrc.length;
	for(var i=0;i<len;i++){
		if (strTelnum.indexOf(strSrc.charAt(i))<0){
			return false;
		}
	}
	return true;
}

//***********************************************************************
//函数名：isEmpty 	     功能：判断字符串是不是空串
//输入参数：待判断的字符串       输出参数：若是返回true,否则返回false
//创建者：yyk			        创建日期：2002/03/21
//更改者：			            更改日期：
//************************************************************************
function isEmpty(s){
  return ((s == null) || (s.length == 0))
}

//***********************************************************************
//函数名：isEmail     	     功能：判断字符串是不是有效Email地址
//输入参数：待判断的字符串       输出参数：若是返回true,否则返回false
//创建者：yyk			        创建日期：2002/03/21
//更改者：			            更改日期：
//Email地址的格式应该为a@b.c，没有字符"@","."属于无效Email；
//"@"出现在第一位，"."出现在最后一位，属于无效Email；
//"@"出现在"."后面，"@"跟"."紧挨着,属于无效Email；
//************************************************************************
function isEmail(src){
  src = lrtrim(src);
  if(isEmpty(src)){       //为空合法
    return true;
  }

  if((src.indexOf("@")<=0) || (src.indexOf(".")<=0) || (src.indexOf(".")==src.length-1)){
    return false;
  }
  if((src.indexOf("@")>src.indexOf(".")) || (src.indexOf("@")+1==src.indexOf("."))){
    return false;
  }
  return true;
}

//***********************************************************************
//函数名：lefttrim              	功能：去字符串的左空格
//输入参数：待去空格的字符串        输出参数：去掉左空格后的字符串
//创建者：yyk			    创建日期：2001/09/11
//更改者：			    更改日期：
//************************************************************************
function lefttrim(strSrc){
	var len = strSrc.length;
	if(typeof(strSrc)!="string")
		return strSrc;
	for (var i=0; i<len; i++)
		if(strSrc.charAt(i)!=" ")
			break;
	strSrc=strSrc.substring(i,len);
	return strSrc;
}
//***********************************************************************
//函数名：righttrim              	功能：去字符串的右空格
//输入参数：待去空格的字符串        输出参数：去掉右空格后的字符串
//创建者：yyk			    创建日期：2001/09/13
//更改者：			    更改日期：
//************************************************************************
function righttrim(strSrc){
	var len = strSrc.length;
	if(typeof(strSrc)!="string")
		return strSrc;
	for (var i=len-1; i>=0; i--)
		if(strSrc.charAt(i)!=" ")
			break;
	strSrc=strSrc.substring(0,i+1);
	return strSrc;
}
//***********************************************************************
//函数名：lrtrim              	功能：去字符串的左右空格
//输入参数：待去空格的字符串        输出参数：去掉左右空格后的字符串
//创建者：yyk			    创建日期：2001/09/13
//更改者：			    更改日期：
//************************************************************************
function lrtrim(strSrc){
	strSrc = lefttrim(strSrc);
	strSrc = righttrim(strSrc);
	return strSrc;
}
//***********************************************************************
//函数名：delnewline            	功能：去字符串的左右空格以及回车符
//输入参数：待处理的字符串        输出参数：去掉左右空格、回车符后的字符串
//创建者：yyk			    创建日期：2003/06/16
//更改者：			    更改日期：
//************************************************************************
function delnewline(strSrc){
	var len = strSrc.length;
	var tmp = "";
	var result = "";
	if(len<=0){
		return "";
	}
	alert("len=" + len);
	alert("a=" + strSrc.charAt(0));
	for(var i=0;i<len;i++){
		tmp = strSrc.charAt(i);
		if(tmp=="\n" || tmp==" " || tmp==' '){
			continue;
		}
		result = result + tmp;
	}
	return result;
}

//***********************************************************************
//函数名：isIpValue		     功能：判断字符串是不是合法IP地址
//输入参数：待判断的字符串       输出参数：若是返回true,否则返回false
//创建者：yyk			        创建日期：2002/05/22
//更改者：			            更改日期：
//************************************************************************
function isIpValue(strSrc){
	var strIpValue = "0123456789.";
	var len = strSrc.length;
	for(var i=0;i<len;i++){
		if (strIpValue.indexOf(strSrc.charAt(i))<0){
			return false;
		}
	}
	return true;
}


//函数名：chkdate    (YYYY-MM-DD)
//功能介绍：检查是否为日期
//参数说明：要检查的字符串
//返回值：0：不是日期  1：是日期
function chkdate(datestr) {
  var lthdatestr
  if (datestr != "")
    lthdatestr= datestr.length ;
  else
    lthdatestr=0;
  var tmpy="";
  var tmpm="";
  var tmpd="";
  //var datestr;
  var status;
  status=0;
  if ( lthdatestr== 0)
    return 0;
  for (i=0;i<lthdatestr;i++) {
    if (datestr.charAt(i)== '-') {
      status++;
    }
    if (status>2) {
      return 0;
    }
    if ((status==0) && (datestr.charAt(i)!='-')) {
      tmpy=tmpy+datestr.charAt(i)
    }
    if ((status==1) && (datestr.charAt(i)!='-')) {
      tmpm=tmpm+datestr.charAt(i)
    }
    if ((status==2) && (datestr.charAt(i)!='-')) {
      tmpd=tmpd+datestr.charAt(i)
    }
  }
  year=new String (tmpy);
  month=new String (tmpm);
  day=new String (tmpd);
  if ((tmpy.length!=4) || (tmpm.length>2) || (tmpd.length>2)) {
    return 0;
  }
  if (!((1<=month) && (12>=month) && (31>=day) && (1<=day)) ) {
    return 0;
  }
  if (!((year % 4)==0) && (month==2) && (day==29)) {
    return 0;
  }
  if ((month<=7) && ((month % 2)==0) && (day>=31)) {
    return 0;
  }
  if ((month>=8) && ((month % 2)==1) && (day>=31)) {
    return 0;
  }
  if ((month==2) && (day==30)) {
    return 0;
  }
  return 1;
}

//***********************************************************************
//函数名：GetObjID
//功能：通过域名称取域的id
//输入参数：域名称                    输出参数：返回该名称的域id
//创建者：yuyankai			        创建日期：2003/03/05
//更改者：			            更改日期：
//************************************************************************
function GetObjID(ObjName)
{
  for (var ObjID=0; ObjID < window.frm.elements.length; ObjID++)
    if ( window.frm.elements[ObjID].name == ObjName )
    {  return(ObjID);
       break;
    }
  return(-1);
}



//***********************************************************************
//函数名：overLink
//功能：鼠标置上，显示手形
//输入参数：                                 输出参数：
//创建者：yuyankai			    创建日期：2003/03/12
//更改者：			            更改日期：
//************************************************************************

function overLink(){
 var arg = overLink.arguments;
 var link =arg[0];
 linkcor=link.style.color;
 link.style.cursor = "hand";
 if(arg.length >=2 ){
    window.status=arg[1];
 }
 link.style.color= "#FF9900";
}
function outLink(link){
  link.style.color= linkcor;
  window.status=""

}


//***********************************************************************
//函数名：turnover
//功能：跳转到某页面
//输入参数：                                 输出参数：
//创建者：yuyankai			    创建日期：2003/06/10
//更改者：			            更改日期：
//************************************************************************
function turnover(page){
	if(document.frm.cmd!=null){
		document.frm.cmd.value = "gotopage";
	}
	document.frm.curpage.value = page;
	document.frm.submit();
}
//***********************************************************************
//函数名：chgLines
//功能：控制页面显示行数
//输入参数：                                 输出参数：
//创建者：yuyankai			    创建日期：2003/06/11
//更改者：			            更改日期：
//************************************************************************
function chgLines(obj){
	if(document.frm.cmd!=null){
		document.frm.cmd.value = "getpagelines";
	}
	document.frm.submit();
}
//***********************************************************************
//函数名：delconfirm
//功能：判断批量删除是否选择待删除记录
//输入参数：nameprefix--checkbox名称前缀，cmdvalue--cmd域值  输出参数：
//创建者：yuyankai			    创建日期：2003/06/12
//更改者：			            更改日期：
//************************************************************************
function delconfirm(nameprefix,cmdvalue){
	var len = window.frm.elements.length;
	var name = "";
	var haveChecked = false;

	if(nameprefix==undefined || nameprefix==null){
		nameprefix = "chk";
	}
	if(cmdvalue==undefined || cmdvalue==null){
		cmdvalue = "del";
	}
	for(var i=0;i<len;i++){
		name = window.frm.elements[i].name;
		if(name.indexOf(nameprefix)>=0){
			if(window.frm.elements[i].checked==true){
				haveChecked = true;
				break;
			}
		}
	}
	if(haveChecked){
		if(confirm("您确认要删除所选的记录吗？")){
			document.frm.cmd.value = cmdvalue;
			document.frm.submit();
		}
	}else{
		alert("请选择待删除的记录!");
		return false;
	}
}

//打开一个新窗口
function openwindow(location,width,height)
{
    if(width==null)
            width=600;
    if(height==null)
            height=450;
    win=window.open(location,'win',"top=70,left=150,height="+height+",width="+width+",scrollbars=1,status=no,resizable=yes");
    win.focus();
}
//判断一个text的对象的长度是否超过预期
//超过返回假，聚焦，提示
//未超过，返回真;object为空，返回真。
//例如：if(!isShorter(document.frm.name,20,"名称")){return;}
//编写：李超，请不要删除
function isShorter(object,len,str)
{
   if(object==null)
   {
      return true;
   }
   if(object.value==null)
   {
      return true;
   }
   if(object.value.length==null)
   {
      return true;
   }
   if(object.value.length>len)
   {
     object.focus();
     alert(str+"长度必须小于"+len);
     return false;
   }
   return true;
}

/**
 * 添加option到指定的select
 * @return
 */
function addOptions(object,stroption)
{
  for(i=object.length;i>0;i--) object.options[i] = null;
  object.options[0] = new Option("---请选择---","");
  if(stroption.length!=0){
    option = stroption.split("*");
    for(i=0;i<option.length;i++){
      suboption = option[i].split(",");
      object.options[object.length] = new Option(suboption[1],suboption[0]);
    }
  }
}

/**
 * 格式化数字
 * @return
 */
function FormatNumber(srcStr,nAfterDot){
　　var srcStr,nAfterDot;
　　var resultStr,nTen;
　　srcStr = ""+srcStr+"";
　　strLen = srcStr.length;
　　dotPos = srcStr.indexOf(".",0);
　　if (dotPos == -1){
　　　　resultStr = srcStr;
　　　　/*for (i=0;i<nAfterDot;i++){
　　　　　　resultStr = resultStr+"0";
　　　　}
       */
　　　　return resultStr;
　　}
　　else{
　　　　if ((strLen - dotPos - 1) >= nAfterDot){
　　　　　　nAfter = dotPos + nAfterDot + 1;
　　　　　　nTen =1;
　　　　　　for(j=0;j<nAfterDot;j++){
　　　　　　　　nTen = nTen*10;
　　　　　　}
　　　　　　resultStr = Math.round(parseFloat(srcStr)*nTen)/nTen;
　　　　　　return resultStr;
　　　　}
　　　　else{
　　　　　　resultStr = srcStr;
　　　　　　for (i=0;i<(nAfterDot - strLen + dotPos + 1);i++){
　　　　　　　　resultStr = resultStr+"0";
　　　　　　}
　　　　　　return resultStr;
　　　　}
　　}
}

/**
 * 选择特定的option
 * @return
 */
function selectoption(object,selectedsn){

    for(i=object.length;i>=0;i--){
      if(selectedsn!=' '){
      if(object.options[i-1].value==selectedsn){
        object.selectedIndex = i-1;
        break;
        }
    }
  }
}

//***********************************************************************
//函数名：isLetterNum		              功能：判断字符串是不是全数字或者字母组成
//输入参数：待判断的字符串       输出参数：若全是数字返回true,否则返回false
//创建者：lc			        创建日期：2003/10/17
//更改者：			            更改日期：
//************************************************************************
function isLetterNum(strSrc)
{
	var len = strSrc.length;
	for(var i=0;i<len;i++){
		if ((strSrc.charAt(i)<'A' || (strSrc.charAt(i)>'Z' && strSrc.charAt(i)<'a') || strSrc.charAt(i)>'z') && !isNum(strSrc.charAt(i))){
			return false;
		}
	}
	return true;
}


</script>