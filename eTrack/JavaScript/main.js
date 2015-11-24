//showModalDialog
function GoToPage(url, title, width, height) {
    var select = document.getElementById("drJobNo");
    var strfield = $("#drJobNo").val();
    var strval = $("#txt_serach").val();
    if (strval == "") {
        alert("No allow blank!")
    }
    else {
        var title = title;
        var url = url + "?strfield=" + strfield + "&strval=" + strval + "&Radom=" + Math.random();
        var Width = width;
        var Height = height;
        var arguemnts = new Object();
        arguemnts.window = window;
        if (document.all && window.print) {
            window.showModalDialog(url, arguemnts, "dialogWidth:" + Width + "px;dialogHeight:" + Height + "px;center:yes;status:no;scroll:no;help:no;");
        }
        else {
            window.open(url, "", "width=" + Width + "px,height=" + Height + "px,resizable=1,scrollbars=1");
        }
    }
}
function Logout(result, context) {
    window.top.location.href = "Default.aspx";
}


function CloseSystem(result, context) {
    var ua = navigator.userAgent;
    var ie = navigator.appName == "Microsoft Internet Explorer" ? true : false;
    if (ie) {
        var IEversion = parseFloat(ua.substring(ua.indexOf("MSIE ") + 5, ua.indexOf(";", ua.indexOf("MSIE "))));
        if (IEversion < 5.5) {
            var str = '<object id=noTipClose classid="clsid:ADB880A6-D8FF-11CF-9377-00AA003B7A11">';
            str += '<param name="Command" value="Close"></object>';
            top.document.body.insertAdjacentHTML("beforeEnd", str);
            top.document.all.noTipClose.Click();
        }
        else {
            top.window.opener = null;
            top.window.close();
        }
    }
    else {
        window.open('', '_self', '');
        top.window.close();
    }
}

function ImgMouseDown(Img, Flag) {
    switch (Flag) {
        case 3:
            if (document.frmHeader.imgSystemHelp.src.toLowerCase().indexOf("images/systemhelp.gif") >= 0)
                document.frmHeader.imgSystemHelp.src = "images/SystemHelp.gif";
            if (document.frmHeader.imgLogin.src.toLowerCase().indexOf("images/relogin.gif") == -1)
                document.frmHeader.imgLogin.src = "images/relogin.gif";
            if (document.frmHeader.imgExit.src.toLowerCase().indexOf("images/exit.gif") == -1)
                document.frmHeader.imgExit.src = "images/exit.gif";
            window.open("Help/Help.htm");
            break;
        case 4:
            if (document.frmHeader.imgSystemHelp.src.toLowerCase().indexOf("images/systemhelp.gif") == -1)
            { document.frmHeader.imgSystemHelp.src = "images/SystemHelp.gif"; }
            if (document.frmHeader.imgLogin.src.toLowerCase().indexOf("images/relogin.gif") >= 0)
                document.frmHeader.imgLogin.src = "images/relogin2.gif";
            if (document.frmHeader.imgExit.src.toLowerCase().indexOf("images/exit.gif") == -1)
                document.frmHeader.imgExit.src = "images/exit.gif";
            if (window.confirm(ConfirmLogout))
                Closing(Logout);
            else { document.frmHeader.imgLogin.src = "images/relogin.gif"; }
            break;
        case 5:
            if (document.frmHeader.imgSystemHelp.src.toLowerCase().indexOf("images/systemhelp.gif") == -1) {
                document.frmHeader.imgSystemHelp.src = "images/SystemHelp.gif";
            }
            if (document.frmHeader.imgLogin.src.toLowerCase().indexOf("images/relogin.gif") == -1)
                document.frmHeader.imgLogin.src = "images/relogin.gif";
            if (document.frmHeader.imgExit.src.toLowerCase().indexOf("images/exit.gif") >= 0)
                document.frmHeader.imgExit.src = "images/exit2.gif";
            if (window.confirm(ConfirmExitSystem))
                Closing(CloseSystem);
            else {
                document.frmHeader.imgExit.src = "images/exit.gif";
            }
            break;
        default:
            break;
    }
}

function ImgMouseDown1(Img, Flag) {
    switch (Flag) {
        case 3:
            window.open("Help/Help.htm");
            break;
        case 4:
            if (window.confirm(ConfirmLogout))
                Closing(Logout);
            else {
            }
            break;
        case 5:
            if (window.confirm(ConfirmExitSystem))
                Closing(CloseSystem);
            else {

            }
            break;
        default:
            break;
    }
}
$(function () {
    windowResize();
    $(window).resize(function () {
        windowResize();
    });
});
function getWindowHeight() {
    return $(window).height();
}
function getWindowWidth() {
    return $(window).width();
}
function windowResize() {
    var width = getWindowWidth();
    var height = getWindowHeight();
    $('form#form1').width(width);
    $('form#form1').height(height);
    $('form#form1').layout();
}
//Dynamically add tabs 
function addTab(title, url) {
    if ($('#tabs').tabs('exists', title)) {
        $('#tabs').tabs('select', title);
    } else {
        var content = '<iframe scrolling="auto" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
        $('#tabs').tabs('add', {
            title: title,
            content: content,
            closable: true
        });
    }
}