<script language="javascript" type="text/javascript">
function pwdMatch(pwd1,pwd2){
	if( pwd1.value != pwd2.value){
		alert("���벻ƥ�䣬�����䣡");
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
		alert("���벻ƥ�䣬�����䣡");
		document.frm.oppwd.focus();
		return false;
	}else{
		return true;
	}
}

//***********************************************************************
//��������isNum		              ���ܣ��ж��ַ����ǲ���ȫ�������
//������������жϵ��ַ���       �����������ȫ�����ַ���true,���򷵻�false
//�����ߣ�yyk			        �������ڣ�2001/08/31
//�����ߣ�			            �������ڣ�
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
//��������isFloat	              ���ܣ��ж��ַ����ǲ�������������С��
//������������жϵ��ַ���       �����������ȫ��������С������true,���򷵻�false
//�����ߣ�ggk			        �������ڣ�2002/11/30
//�����ߣ�			            �������ڣ�
//������ʽ isFloat (STRING s [, BOOLEAN emptyOK])
//************************************************************************

function isFloat (s)
{
	if(parseFloat(s)>999999999999999){
		alert("�Բ���������Ľ��ܳ���999999999999999��")
		return false;
	}

    var reFloat = /^((\d+(\.\d*)?)|((\d+\.)?\d+))$/
    if (isEmpty(s))
       if (isFloat.arguments.length == 1) return false;
       else return (isFloat.arguments[1] == true);

    return reFloat.test(s)
}
//***********************************************************************
//��������isTelnum		     ���ܣ��ж��ַ����ǲ���ȫ���ָ�'(',')','-'���
//������������жϵ��ַ���       ������������Ƿ���true,���򷵻�false
//�����ߣ�yyk			        �������ڣ�2001/09/06
//�����ߣ�			            �������ڣ�
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
//��������isEmpty 	     ���ܣ��ж��ַ����ǲ��ǿմ�
//������������жϵ��ַ���       ������������Ƿ���true,���򷵻�false
//�����ߣ�yyk			        �������ڣ�2002/03/21
//�����ߣ�			            �������ڣ�
//************************************************************************
function isEmpty(s){
  return ((s == null) || (s.length == 0))
}

//***********************************************************************
//��������isEmail     	     ���ܣ��ж��ַ����ǲ�����ЧEmail��ַ
//������������жϵ��ַ���       ������������Ƿ���true,���򷵻�false
//�����ߣ�yyk			        �������ڣ�2002/03/21
//�����ߣ�			            �������ڣ�
//Email��ַ�ĸ�ʽӦ��Ϊa@b.c��û���ַ�"@","."������ЧEmail��
//"@"�����ڵ�һλ��"."���������һλ��������ЧEmail��
//"@"������"."���棬"@"��"."������,������ЧEmail��
//************************************************************************
function isEmail(src){
  src = lrtrim(src);
  if(isEmpty(src)){       //Ϊ�պϷ�
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
//��������lefttrim              	���ܣ�ȥ�ַ�������ո�
//�����������ȥ�ո���ַ���        ���������ȥ����ո����ַ���
//�����ߣ�yyk			    �������ڣ�2001/09/11
//�����ߣ�			    �������ڣ�
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
//��������righttrim              	���ܣ�ȥ�ַ������ҿո�
//�����������ȥ�ո���ַ���        ���������ȥ���ҿո����ַ���
//�����ߣ�yyk			    �������ڣ�2001/09/13
//�����ߣ�			    �������ڣ�
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
//��������lrtrim              	���ܣ�ȥ�ַ��������ҿո�
//�����������ȥ�ո���ַ���        ���������ȥ�����ҿո����ַ���
//�����ߣ�yyk			    �������ڣ�2001/09/13
//�����ߣ�			    �������ڣ�
//************************************************************************
function lrtrim(strSrc){
	strSrc = lefttrim(strSrc);
	strSrc = righttrim(strSrc);
	return strSrc;
}
//***********************************************************************
//��������delnewline            	���ܣ�ȥ�ַ��������ҿո��Լ��س���
//�����������������ַ���        ���������ȥ�����ҿո񡢻س�������ַ���
//�����ߣ�yyk			    �������ڣ�2003/06/16
//�����ߣ�			    �������ڣ�
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
//��������isIpValue		     ���ܣ��ж��ַ����ǲ��ǺϷ�IP��ַ
//������������жϵ��ַ���       ������������Ƿ���true,���򷵻�false
//�����ߣ�yyk			        �������ڣ�2002/05/22
//�����ߣ�			            �������ڣ�
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


//��������chkdate    (YYYY-MM-DD)
//���ܽ��ܣ�����Ƿ�Ϊ����
//����˵����Ҫ�����ַ���
//����ֵ��0����������  1��������
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
//��������GetObjID
//���ܣ�ͨ��������ȡ���id
//���������������                    ������������ظ����Ƶ���id
//�����ߣ�yuyankai			        �������ڣ�2003/03/05
//�����ߣ�			            �������ڣ�
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
//��������overLink
//���ܣ�������ϣ���ʾ����
//���������                                 ���������
//�����ߣ�yuyankai			    �������ڣ�2003/03/12
//�����ߣ�			            �������ڣ�
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
//��������turnover
//���ܣ���ת��ĳҳ��
//���������                                 ���������
//�����ߣ�yuyankai			    �������ڣ�2003/06/10
//�����ߣ�			            �������ڣ�
//************************************************************************
function turnover(page){
	if(document.frm.cmd!=null){
		document.frm.cmd.value = "gotopage";
	}
	document.frm.curpage.value = page;
	document.frm.submit();
}
//***********************************************************************
//��������chgLines
//���ܣ�����ҳ����ʾ����
//���������                                 ���������
//�����ߣ�yuyankai			    �������ڣ�2003/06/11
//�����ߣ�			            �������ڣ�
//************************************************************************
function chgLines(obj){
	if(document.frm.cmd!=null){
		document.frm.cmd.value = "getpagelines";
	}
	document.frm.submit();
}
//***********************************************************************
//��������delconfirm
//���ܣ��ж�����ɾ���Ƿ�ѡ���ɾ����¼
//���������nameprefix--checkbox����ǰ׺��cmdvalue--cmd��ֵ  ���������
//�����ߣ�yuyankai			    �������ڣ�2003/06/12
//�����ߣ�			            �������ڣ�
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
		if(confirm("��ȷ��Ҫɾ����ѡ�ļ�¼��")){
			document.frm.cmd.value = cmdvalue;
			document.frm.submit();
		}
	}else{
		alert("��ѡ���ɾ���ļ�¼!");
		return false;
	}
}

//��һ���´���
function openwindow(location,width,height)
{
    if(width==null)
            width=600;
    if(height==null)
            height=450;
    win=window.open(location,'win',"top=70,left=150,height="+height+",width="+width+",scrollbars=1,status=no,resizable=yes");
    win.focus();
}
//�ж�һ��text�Ķ���ĳ����Ƿ񳬹�Ԥ��
//�������ؼ٣��۽�����ʾ
//δ������������;objectΪ�գ������档
//���磺if(!isShorter(document.frm.name,20,"����")){return;}
//��д������벻Ҫɾ��
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
     alert(str+"���ȱ���С��"+len);
     return false;
   }
   return true;
}

/**
 * ���option��ָ����select
 * @return
 */
function addOptions(object,stroption)
{
  for(i=object.length;i>0;i--) object.options[i] = null;
  object.options[0] = new Option("---��ѡ��---","");
  if(stroption.length!=0){
    option = stroption.split("*");
    for(i=0;i<option.length;i++){
      suboption = option[i].split(",");
      object.options[object.length] = new Option(suboption[1],suboption[0]);
    }
  }
}

/**
 * ��ʽ������
 * @return
 */
function FormatNumber(srcStr,nAfterDot){
����var srcStr,nAfterDot;
����var resultStr,nTen;
����srcStr = ""+srcStr+"";
����strLen = srcStr.length;
����dotPos = srcStr.indexOf(".",0);
����if (dotPos == -1){
��������resultStr = srcStr;
��������/*for (i=0;i<nAfterDot;i++){
������������resultStr = resultStr+"0";
��������}
       */
��������return resultStr;
����}
����else{
��������if ((strLen - dotPos - 1) >= nAfterDot){
������������nAfter = dotPos + nAfterDot + 1;
������������nTen =1;
������������for(j=0;j<nAfterDot;j++){
����������������nTen = nTen*10;
������������}
������������resultStr = Math.round(parseFloat(srcStr)*nTen)/nTen;
������������return resultStr;
��������}
��������else{
������������resultStr = srcStr;
������������for (i=0;i<(nAfterDot - strLen + dotPos + 1);i++){
����������������resultStr = resultStr+"0";
������������}
������������return resultStr;
��������}
����}
}

/**
 * ѡ���ض���option
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
//��������isLetterNum		              ���ܣ��ж��ַ����ǲ���ȫ���ֻ�����ĸ���
//������������жϵ��ַ���       �����������ȫ�����ַ���true,���򷵻�false
//�����ߣ�lc			        �������ڣ�2003/10/17
//�����ߣ�			            �������ڣ�
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