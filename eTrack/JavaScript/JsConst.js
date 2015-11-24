<script language ="javascript" type="text/javascript">

    var colorFirst="White"; 
    var colorSecond="#e6eff8"//"#F0F0F0";
    var colorSelected="#9fbbe2"//"#C0C0C0";

    var RowSeparator="<%= SysMagic.ZZsystem.ConSeparator.Row %>";
    var ColSeparator="<%= SysMagic.ZZsystem.ConSeparator.Col %>";
    var ParSeparator="<%= SysMagic.ZZsystem.ConSeparator.Par %>";

    var RtnError="<%= SysMagic.ZZmessage.ConMsgRtn.Err%>";
    var RtnOk="<%= SysMagic.ZZmessage.ConMsgRtn.Ok%>";
    var RtnExist="<%= SysMagic.ZZmessage.ConMsgRtn.Exist%>";
    var RtnNoLogin="<%= SysMagic.ZZmessage.ConMsgRtn.NoLogin%>";
    var RtnTimeOut="<%= SysMagic.ZZmessage.ConMsgRtn.TimeOut%>";
    var RtnNotAllow="<%= SysMagic.ZZmessage.ConMsgRtn.NotAllow%>";
    var RtnAddSubError="<%= SysMagic.ZZmessage.ConMsgRtn.AddSubError%>";
    var RtnDeleteSubError="<%= SysMagic.ZZmessage.ConMsgRtn.DeleteSubError%>";
    var RtnNoChange="<%= SysMagic.ZZmessage.ConMsgRtn.NoChange%>";
    
    var SuccessPrompt="<%= SysMagic.ZZmessage.ConMsgPrompt.SuccessPrompt%>";
    var SavePrompt="<%= SysMagic.ZZmessage.ConMsgPrompt.SavePrompt%>";
    var NotifyPrompt="<%= SysMagic.ZZmessage.ConMsgPrompt.NotifyPrompt%>";
    var AuditPrompt="<%= SysMagic.ZZmessage.ConMsgPrompt.AuditPrompt%>";
    var DeletePrompt="<%= SysMagic.ZZmessage.ConMsgPrompt.DeletePrompt%>";
    var RestorePrompt="<%= SysMagic.ZZmessage.ConMsgPrompt.RestorePrompt%>";
    var SubDeletePrompt="<%= SysMagic.ZZmessage.ConMsgPrompt.SubDeletePrompt%>";

    var IntTrueString="1";
    var IntFalseString="0";

    var AmountDigital=2;
    var PriceDigital=4;
    var QuantityDigital=4;
    
    var PrintPath="Print";


    var IEType=0;
    var ChildSpl=0;
    CheckBrowserType();
    function CheckBrowserType()
    {
        var browser=navigator.appName;
        var browserVersion="";
        try{
            browserVersion=navigator.appVersion.split(";")[1].replace(/[ ]/g,"");
        }
        catch(e){
    
        }
        if(browser=="Microsoft Internet Explorer"&&browserVersion=="MSIE9.0")
        {
            IEType=9;//ie9
            ChildSpl=1;
        }
        else if(browser=="Microsoft Internet Explorer"&&browserVersion=="MSIE10.0")
        {
            IEType=10;
            ChildSpl=1;
        }
        else if(browser.indexOf("Firefox")>=0&&browser.indexOf("Netscape")>=0)
        {
            IEType=4;//firefox
        }
        else if(browserVersion.indexOf("Chrome")>=0&&browser.indexOf("Netscape")>=0)
        {
             ChildSpl=1;
        }
        var _IE = ieVersionPlus();
        if( _IE === 0){
            IEType = 20;
            ChildSpl = 1;
        }
        else if(_IE > 4 && _IE < 9){
            IEType = _IE;
        }else if(_IE >= 9){
            IEType = _IE;
            ChildSpl = 1;
        }
    }
    function valiString(a,b,c,c,e)
    {
   
    }
    function ieVersionPlus() {
    if (!!window.ActiveXObject || "ActiveXObject" in window) {
        var v = 3, div = document.createElement('div'), all = div.getElementsByTagName('i');
        while (
            div.innerHTML = '<!--[if gt IE ' + (++v) + ']><i></i><![endif]-->',
            all[0]
        );
        return v;
    } else {
        return 0;
    }
}
    
</script>

