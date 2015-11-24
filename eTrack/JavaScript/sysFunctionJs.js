function getXMLHttpRequest() {
    var xReq = null;
    //Mozilla/Safari
    if (window.XMLHttpRequest) {
        xReq = new XMLHttpRequest();
        //IE
    } else if (typeof ActiveXObject != "undefined") {
        try {
            xReq = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                xReq = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) {
                xReq = null;
            }
        }
    }
    return xReq;
}
/*get div data*****/
var divname = "";
var xmlHttp1 = null
function sysGetDivData(strurl, strdivname) {
    xmlHttp1 = getXMLHttpRequest();
    var datetime = new Date();
    divname = strdivname;
    xmlHttp1.open("GET", strurl + "&data=" + datetime, true);
    xmlHttp1.onreadystatechange = updateSysGetDivData;
    xmlHttp1.send(null);
}
function updateSysGetDivData() {
    if (xmlHttp1.readyState == 4) {
        try {

            var strBackInfo = xmlHttp1.responseText;
            document.all[divname].innerHTML = strBackInfo;
        } catch (e) {
        }
    }
}
/*system*/
function sysSave(strtype) {
    if (strtype == "1") {
        alert("save the doc sucess!");
    } else {
        alert("save the doc failure!");
    }
}
function sysDel(strtype) {
    if (strtype == "1") {
        alert("del the doc sucess!");
    } else {
        alert("del the doc failure!");
    }
}
function sysGoUrl(strUrl) {
    window.location = strUrl;
}
/**************/
/*select value*/
function sysSelectAll(Param) {
    var cForm = document.all["$$SelectDoc"];
    for (var i = 0; i < cForm.length; i++) {
        if (Param == 'yes')
            cForm[i].checked = true;
        else
            cForm[i].checked = false;

    }
}
function sysSelectValue() {
    if (document.all["sysSelectInfo"].checked) {
        sysSelectAll("yes")
    } else {
        sysSelectAll("no")
    }
}
/**************/
/*system Page**/
function sysPage(count, pages) {
    var strcount = count;
    var strcurpage = pages;
    var strurl = document.all["sysUrl" + strcount].value;
    var syskeys = document.all["sysKeys" + strcount].value;
    var strorder = document.all["sysOrder" + strcount].value;
    var strallurl = strurl + "?" + syskeys + "&sysOrder=" + strorder + "&sysCurPage=" + strcurpage;
    showLoading("");
    window.location = "../" + strallurl;
}
function sysGoPage(strcount) {
    var inputcount = document.all["sysGoNum" + strcount].value;
    var maxcount = document.all["sysMaxPage" + strcount].value
    if (isInteger(inputcount)) {
        if (parseInt(inputcount) > parseInt(maxcount)) {
            document.all["sysGoNum" + strcount].value = maxcount;
        }
    } else {
        document.all["sysGoNum" + strcount].value = "1";
    }
    sysPage(strcount, document.all["sysGoNum" + strcount].value);
}
function sysOrder(count, strorder) {
    var strcount = count;
    var stroldorder = document.all["sysOrder" + count].value;
    if (isValueNull(stroldorder) == false) {
        document.all["sysOrder" + count].value = strorder;
        sysPage(strcount, '1');
    } else {
        var strovalue = "";
        var strotype = "";
        var i = stroldorder.indexOf(" ");
        if (i != -1) {
            strovalue = stroldorder.substring(0, i);
            strotype = stroldorder.substring(i + 1, stroldorder.length).trim();
        } else {
            strovalue = stroldorder
        }
        if (strorder == strovalue) {
            if (strotype == "" || strotype == "asc") {
                strotype = "desc";
            } else {
                strotype = "asc";
            }
        } else {
            strovalue = strorder;
        }
        document.all["sysOrder" + count].value = strovalue + " " + strotype;
        sysPage(strcount, '1');
    }
}
/**************/
/*system Tool**/
function isValueNull(str) {
    if (str == "") {
        return false;
    } else {
        return true;
    }
}
function isInteger(strvalue) {
    if (isValueNull(strvalue) == true) {
        reg = /^[-+]?\d*$/;
        if (!reg.test(strvalue)) {
            return false;
        } else {
            return true;
        }
    } else {
        return false;
    }
}
String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

/**************/
/*page loading*/
function writeWaitLoding() {
    var divTemp = document.createElement("<div id='PopupDiv'></div>");
    divTemp.style.display = "none";
    divTemp.style.left = "0";
    divTemp.style.top = "0";
    divTemp.style.position = "absolute";
    document.body.appendChild(divTemp)
    var iframeTemp = document.createElement("<iframe id='DivShim'></iframe>");
    iframeTemp.style.display = "none";
    iframeTemp.src = "#";
    iframeTemp.scrolling = "no";
    iframeTemp.frameborder = "10px";
    iframeTemp.style.left = "0";
    iframeTemp.style.top = "0";
    iframeTemp.style.width = document.body.clientWidth;
    iframeTemp.style.height = document.body.clientHeight;
    iframeTemp.style.position = "absolute";
    document.body.appendChild(iframeTemp)
    var divTemp1 = document.createElement("<div id='showSysLoading'></div>");
    divTemp1.style.display = "none";
    divTemp1.style.left = "0";
    divTemp1.style.top = "0";
    divTemp1.style.position = "absolute";
    divTemp1.style.width = document.body.clientWidth;
    divTemp1.style.height = document.body.clientHeight;
    var str = "";
    str = str + '<table width="100%" height="100%" border="0" align="center" cellpadding="0" cellspacing="0">'
    str = str + '<tr>'
    str = str + '<td align="center">'
    str = str + '<table border="0" cellpadding="0" cellspacing="0" >'
    str = str + '<tr>'
    str = str + "<td height='130' width='300' align='center' class='page-waitting'><SPAN id='showSysAlert'>plese waitting...</SPAN></td>"
    str = str + '</tr>'
    str = str + '</table>'
    str = str + '</td>'
    str = str + '</tr>'
    str = str + '</table>'
    divTemp1.innerHTML = str;
    document.body.appendChild(divTemp1)
}
function DivSetVisible(show, text) {
    var DivRef = document.getElementById('PopupDiv');
    var IfrRef = document.getElementById('DivShim');
    var tabletext = document.getElementById('showSysLoading');
    var textid = document.getElementById('showSysAlert');
    if (isValueNull(text) == true) {
        textid.innerHTML = text;
    }
    if (show) {
        DivRef.style.display = "block";
        DivRef.style.width = document.body.clientWidth;
        DivRef.style.height = document.body.clientHeight;
        DivRef.innerHTML = tabletext.innerHTML;
        IfrRef.style.width = 300;
        IfrRef.style.height = 130;
        IfrRef.style.top = (document.body.clientHeight - 130) / 2;
        IfrRef.style.left = (document.body.clientWidth - 300) / 2;
        IfrRef.style.zIndex = DivRef.style.zIndex - 1;
        IfrRef.style.display = "block";
    }
    else {
        DivRef.style.display = "none";
        IfrRef.style.display = "none";
    }
}
function showLoading(str) {
    try {
        writeWaitLoding()
        DivSetVisible(true, str);
    }
    catch (err)
   { return true; }
}
function closeLoading(str) {
    try {
        writeWaitLoding()
        DivSetVisible(false, str);
    }
    catch (err)
   { return true; }
}
/***************/
/**form sumit***/
function sysFormSubit() {
    document.forms[0].submit();
    showLoading('');
}
function sysGoUrl(strUrl) {
    window.location = strUrl;
}
/***************/
/*delte data***/
var funname = "";
var xmlHttp3 = null
function sysDelData(strurl, strfunname) {
    showLoading("");
    xmlHttp3 = getXMLHttpRequest();
    var datetime = new Date();
    funname = strfunname;
    xmlHttp3.open("GET", strurl + "&data=" + datetime, true);
    xmlHttp3.onreadystatechange = updateSysDelData;
    xmlHttp3.send(null);
}
function updateSysDelData() {
    if (xmlHttp3.readyState == 4) {
        try {
            var strBackInfo = xmlHttp3.responseText;
            if (isValueNull(strBackInfo)) {
                alert(strBackInfo);
            }
            eval(funname);
        } catch (e) {
        }
        closeLoading("");
    }
}
/***************/
/*showDiallog***/
function sysShowDialog(strType, strUrl) {
    //strtype   
    //strurl  
    var datetime = new Date();
    strUrl = strUrl + "&date=" + datetime;
    var strwidth = "";
    var strheight = "";
    if (strType == "1") {
        swidth = "200px";
        sheight = "200px";
    } else if (strType == "2") {
        swidth = "300px";
        sheight = "300px";
    } else {
        swidth = "500px";
        sheight = "500px";
    }
    window.showModalDialog(encodeURI(strUrl), window, "dialogWidth=" + swidth + ";dialogHeight=" + sheight + "");
}
/***************/
/*select sysUnit*/
function sysUnit(strType, strSelectType, strName, strId, secValue1) {
    //strType 1:company;2:depart;3:quarters;4:postion;
    //strSelectType 0:select one;1:select more;
    //strName showName;
    //strID   showID;
    //secValue  standby;
    if (strType == "1") { //company
        if (strSelectType == "0") {
            var strUrl = "../hrManager/showSelectCompanyOne.aspx?name=" + strName + "&id=" + strId;
            sysShowDialog("3", strUrl);
        } else {
            var strUrl = "../hrManager/showSelectCompanyMore.aspx?name=" + strName + "&id=" + strId;
            sysShowDialog("3", strUrl);
        }
    }
    if (strType == "2") {//depart
        if (strSelectType == "0") {
            var strUrl = "../hrManager/showSelectDepartOne.aspx?name=" + strName + "&id=" + strId;
            sysShowDialog("3", strUrl);
        } else {
            var strUrl = "../hrManager/showSelectDepartMore.aspx?name=" + strName + "&id=" + strId;
            sysShowDialog("3", strUrl);
        }
    }
    if (strType == "3") {//quarters
        if (strSelectType == "0") {
            var strUrl = "../hrManager/showSelectQuartersOne.aspx?name=" + strName + "&id=" + strId;
            sysShowDialog("3", strUrl);
        } else {
            var strUrl = "../hrManager/showSelectQuartersMore.aspx?name=" + strName + "&id=" + strId;
            sysShowDialog("3", strUrl);
        }
    }
    if (strType == "4") {//postion
        if (strSelectType == "0") {
            var strUrl = "../hrManager/showSelectPostionOne.aspx?name=" + strName + "&id=" + strId;
            sysShowDialog("3", strUrl);
        } else {
            var strUrl = "../hrManager/showSelectPostionMore.aspx?name=" + strName + "&id=" + strId;
            sysShowDialog("3", strUrl);
        }
    }
}
/***************/
/*select User*/
function sysUser(strSelectType, strName, strId, secValue1) {
    if (strSelectType == "0") {
        var strUrl = "../hrManager/showSelectUserOne.aspx?name=" + strName + "&id=" + strId;
        sysShowDialog("3", strUrl);
    } else {
        var strUrl = "../hrManager/showSelectUserMore.aspx?name=" + strName + "&id=" + strId;
        sysShowDialog("3", strUrl);
    }
}
/*************/
