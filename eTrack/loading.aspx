<%@ Page Language="vb" CodeFile="loading.aspx.vb" Inherits="loading" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
<title></title>
<script type="text/javascript"  language="javascript">
    var strHref = location.href;
    var intPos = strHref.indexOf("?tourl=");
    var theUrl = strHref.substr(intPos + 7);
    document.write("<meta http-equiv='refresh' content='0;URL="+theUrl+"'>");
</script>

<style type="text/css">
body{TEXT-ALIGN:center;margin:50px 0 12px;} 
<%-- background:#ebf0fa--%>
#MsgBox {width:300px;font:9pt/28px 'tahoma';border:1px solid #498AC2;MARGIN:0px auto; TEXT-ALIGN:center}
#MsgBox .bar {background:url(images/msgboxbar.gif) no-repeat #45A0EE;height:28px;color:#fff;text-align:left;padding-left:8px}
#MsgBox .content {padding-top:36px;height:120px;border:1px solid #fff;background:url(images/msgboxbg.gif) 0 -20px #fff;color:#327FC6;}
</style>
</head>
	<body>
		<div id="MsgBox">
			<div class="bar"><asp:label  ID="lblLoadTitleHint" runat="server"  Text="<%$ Resources:lblTitle.Text %>"></asp:label>
			</div>
			<div class="content">
			    <img alt="" src="images/load.gif"  style=" text-align :center ; vertical-align: middle "/>&nbsp; &nbsp;<asp:label ID="lblMessage" runat="server"  Text="<%$ Resources:lblMessage.Text %>"></asp:label>
			 </div>
		</div>
	</body>
</html>
