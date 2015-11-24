//100118
function setToUpperCase(Tobj)
{ Tobj.value = Tobj.value.toUpperCase(); }
//100105
function ChangeHeight(objName, W, H) {
    var obj = document.getElementById(objName);
    var objBottomNav = document.getElementById("divBottomNav");
    if (ieVersion() == 6) {
        obj.style.height = H - 30;
        obj.style.width = W - 8;
        objBottomNav.style.width = W - 7;
    } else {
        obj.style.width = W;
        obj.style.height = H;
    }
}
//100105 def Broswer version
function ieVersion() {
    if (navigator.appName == "Microsoft Internet Explorer") {
        if (navigator.appVersion.indexOf("MSIE 8.0") > 0) { return 8; }
        else if (navigator.appVersion.indexOf("MSIE 7.0") > 0) { return 7; }
        else if (navigator.appVersion.indexOf("MSIE 6.0") > 0) { return 6; }
    } else { return 8; }
}
//--------------------------------------------------

function WindowDialog(strUrl, dlgWidth, dlgHeight) {
    var sFeatures = "";
    if (strUrl.indexOf("Edit.aspx") < 0 && strUrl.indexOf("SendMessage.aspx") < 0
        && strUrl.indexOf("AttachList") < 0 && strUrl.indexOf("ReceiveContainer") < 0
        && strUrl.indexOf("ReleaseContainer") < 0 && strUrl.indexOf("Vessel") < 0
        && strUrl.indexOf("TranshipmentTrack") < 0 && strUrl.indexOf("ImportShipmentStatus") < 0
        && strUrl.indexOf("DoubleSelectPage") < 0 && strUrl.indexOf("ExportBookingSelect") < 0) {
        var intRateH = screen.height / 600;
        var intRateW = screen.width / 800;
        dlgWidth = intRateW * dlgWidth;
        dlgHeight = intRateH * dlgHeight;
    }
    dlgWidth = screen.width < dlgWidth ? screen.width : dlgWidth;
    dlgHeight = screen.height < dlgHeight ? screen.height : dlgHeight;
    sFeatures = sFeatures + "dialogHeight:" + dlgHeight.toString() + "px;";
    sFeatures = sFeatures + "dialogWidth:" + dlgWidth.toString() + "px;";
    sFeatures = sFeatures + "center:yes;";
    sFeatures = sFeatures + "help:no;";
    sFeatures = sFeatures + "resizable:no;";
    sFeatures = sFeatures + "status:no;";
    sFeatures = sFeatures + "scroll:no;";
    sFeatures = sFeatures + "edge:sunken";

    //return window.showModalDialog(strUrl, "", sFeatures);
    var returnValue = null;
    var _IE = ieVersionPlus();
    if (_IE != 0) {
        returnValue = window.showModalDialog(strUrl, "", sFeatures);
        if (returnValue === undefined) {
            returnValue = window.returnValue;
        }
        return returnValue;
    }
    else {
        returnValue = window.open(strUrl, "", sFeatures);
        if (returnValue === undefined) {
            returnValue = window.returnValue;
        }
        return returnValue;
    }
}

//ex:OpenWindow('a.html',200,100)
function OpenWindow(url, iWidth, iHeight) {
    var url;
    var nane = "NewPage";
    var iWidth;
    var iHeight;
    var iTop = (window.screen.availHeight - 30 - iHeight) / 2;
    var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;
    window.open(url, name, 'height=' + iHeight + ',,innerHeight=' + iHeight + ',width=' + iWidth + ',innerWidth=' + iWidth + ',top=' + iTop + ',left=' + iLeft + ',toolbar=no,menubar=no,scrollbars=yes,resizeable=no,location=no,status=no');
}
//fix the height and width
//ex:ModalDialog('a.html',200,100)
function ModalDialog(strUrl, dlgWidth, dlgHeight) {
    var sFeatures = "";
    dlgWidth = screen.width < dlgWidth ? screen.width : dlgWidth;
    dlgHeight = screen.height < dlgHeight ? screen.height : dlgHeight;
    sFeatures = sFeatures + "dialogHeight:" + dlgHeight.toString() + "px;";
    sFeatures = sFeatures + "dialogWidth:" + dlgWidth.toString() + "px;";
    sFeatures = sFeatures + "center:yes;";
    sFeatures = sFeatures + "help:no;";
    sFeatures = sFeatures + "resizable:no;";
    sFeatures = sFeatures + "status:no;";
    sFeatures = sFeatures + "scroll:no;";
    sFeatures = sFeatures + "edge:sunken";
    return window.showModalDialog(strUrl, "", sFeatures);
}
function DivAutoSize(intHig) {
    var divSource = document.getElementById("divSource");
    var height = 0;
    var _IE = ieVersionPlus();
    if (_IE > 4 && _IE < 9) {
        height = window.screenTop;
    } else if (_IE === 0) {
        height = window.screenY + 160;
    } else {
        height = window.screenTop;
    }
    /*
    if ('screenTop' in window) {
        // IE-compatible variants
        height = window.screenTop;
    } else if ('screenX' in window) {
        // Firefox-compatible
        height = window.screenY + 210;
    }
    */
    divSource.style.height = window.screen.availHeight - height - intHig + "px"; //document.body.clientWidth
}
function NumberInput(event, dotlen) {
    var myEle = event.srcElement ? event.srcElement : event.target;
    var myValue = String.fromCharCode(event.keyCode);
    if (event.keyCode != "13") {
        if (myEle.readOnly)
        { return; }
        switch (dotlen) {
            case 0: { event.returnValue = regInput(myEle, /^[\-]?\d*\.?\d{0,0}$/, myValue); break; }
            case 1: { event.returnValue = regInput(myEle, /^[\-]?\d*\.?\d{0,1}$/, myValue); break; }
            case 2: { event.returnValue = regInput(myEle, /^[\-]?\d*\.?\d{0,2}$/, myValue); break; }
            case 3: { event.returnValue = regInput(myEle, /^[\-]?\d*\.?\d{0,3}$/, myValue); break; }
            case 4: { event.returnValue = regInput(myEle, /^[\-]?\d*\.?\d{0,4}$/, myValue); break; }
            case 5: { event.returnValue = regInput(myEle, /^[\-]?\d*\.?\d{0,5}$/, myValue); break; }
            case 6: { event.returnValue = regInput(myEle, /^[\-]?\d*\.?\d{0,6}$/, myValue); break; }
            case 7: { event.returnValue = regInput(myEle, /^[\-]?\d*\.?\d{0,7}$/, myValue); break; }
            case 8: { event.returnValue = regInput(myEle, /^[\-]?\d*\.?\d{0,8}$/, myValue); break; }
            default: { event.returnValue = regInput(myEle, /^[\-]?\d*\.?\d{0,0}$/, myValue); break; }
        }
    }
    else {
        event.keyCode = 0;
    }
}
function getSelectionText() {
    return '';
}
function regInput(obj, reg, inputStr) {
    var docSel = document.selection.createRange()
    if (docSel.parentElement().tagName != "INPUT") return false
    oSel = docSel.duplicate()
    oSel.text = ""
    var srcRange = obj.createTextRange()
    oSel.setEndPoint("StartToStart", srcRange)
    var str = oSel.text + inputStr + srcRange.text.substr(oSel.text.length)
    return reg.test(str)
}
function DateInput(dotlen) {
    var myEle = event.srcElement;
    var myValue = String.fromCharCode(event.keyCode);
    if (myEle.readOnly) {
        return;
    }
    switch (dotlen) {
        //month     
        case 'mm': { event.returnValue = regInput(myEle, /(^0?[0-9]$)|(^1[0-2]$)/, myValue); break; }
            //Day
        case 'dd': { event.returnValue = regInput(myEle, /(^[0-2]?[0-9]$)|(^3[0-1]$)/, myValue); break; }
            //Month-by zhi
        case 'yy': { event.returnValue = regInput(myEle, /^[1-2]\d{0,3}$/, myValue); break; }
    }
}
function IsLostFocus() {
    //change by zhiwei for ff
    if (event.KeyCode == 0x26 || event.keyCode == 13 || event.keyCode == 0x28 || event.keyCode == 0x09) {
        return true;
    }
    else {
        return false;
    }
}
function FocusControl(e, Prev, Next) {
    //change by zhiwei for ff
    var key = window.event ? e.keyCode : e.which;
    if (key == 0x26) {
        if (Prev != null) {
            if (!Prev.disabled && Prev.style.display != "none") {
                e.returnValue = false;
                Prev.focus();
                if (Prev.type == "text") {
                    var r = Prev.createTextRange();
                    r.moveStart("character", Prev.value.length);
                    r.collapse(true);
                    r.select();
                }
            }
            else {
                key = 9;
            }
            return;
        }
        else {
            e.returnValue = false;
        }
    }
    else if ((key == 13) || (key == 0x28)) {
        if (Next != null) {
            if (!Next.disabled && Next.style.display != "none") {
                e.returnValue = false;
                Next.focus();
                if (Next.type == "text") {
                    var r = Next.createTextRange();
                    r.moveStart("character", Next.value.length);
                    r.collapse(true);
                    r.select();
                }
            }
            else {
                key = 9;
            }
            return;
        }
        else {
            e.returnValue = false;
        }
    }
}
function FocusControlJS(e, Prev, Next) {
    Prev = Prev == null ? null : document.getElementById(Prev);
    Next = Next == null ? null : document.getElementById(Next);
    //change by zhiwei for ff
    var key = window.event ? e.keyCode : e.which;
    if (key == 0x26) {
        if (Prev != null) {
            if (!Prev.disabled && Prev.style.display != "none") {
                e.returnValue = false;
                Prev.focus();
                if (Prev.type == "text") {
                    var r = Prev.createTextRange();
                    r.moveStart("character", Prev.value.length);
                    r.collapse(true);
                    r.select();
                }
            }
            else {
                key = 9;
            }
            return;
        }
        else {
            e.returnValue = false;
        }
    }
    else if ((key == 13) || (key == 0x28)) {
        if (Next != null) {
            if (!Next.disabled && Next.style.display != "none") {
                e.returnValue = false;
                Next.focus();
                if (Next.type == "text") {
                    var r = Next.createTextRange();
                    r.moveStart("character", Next.value.length);
                    r.collapse(true);
                    r.select();
                }
            }
            else {
                key = 9;
            }
            return;
        }
        else {
            e.returnValue = false;
        }
    }
}
function SetReadOnly(txt, blnReadOnly, blnFlag) {
    if (txt == null) {
        return;
    }
    if (blnFlag == 1) {
        if (blnReadOnly) {
            txt.readOnly = true;
        }
        else {
            txt.readOnly = false;
        }
    }
    else if (blnFlag == 2) {
        if (blnReadOnly) {
            txt.disabled = false;
        }
        else {
            txt.disabled = false;
        }
    }
    else if (blnFlag == 3) {
        if (blnReadOnly) {
            txt.disabled = true;
        }
        else {
            txt.disabled = false;
        }
    }
}
function RowMouseOver(tr) {
    tr.style.backgroundColor = colorSelected;
}
function RowMouseOut(tr, oddFlag) {
    if (tr.cells[0].hasChildNodes() && (tr.cells[0].childNodes[0].nodeType == 1)) {
        chk = tr.cells[0].childNodes[0];
        if (chk.checked) {
            tr.style.backgroundColor = colorSelected;
        }
        else {
            if (oddFlag == 1) {
                tr.style.backgroundColor = colorFirst;
            }
            else {
                tr.style.backgroundColor = colorSecond;
            }
        }
    }
    else {
        if (oddFlag == 1) {
            tr.style.backgroundColor = colorFirst;
        }
        else {
            tr.style.backgroundColor = colorSecond;
        }
    }
}
function DialogReturnIdValue(strId) {
    window.returnValue = strId;
    window.close();
}
function DialogReturnArray(row, arrCol) {
    ret = new Array();
    var strValue = "";
    for (var j = 0; j < arrCol.length; j++) {
        var cell = row.cells[arrCol[j]];
        if (cell.hasChildNodes() && (cell.childNodes[0].nodeType == 1)) {
            ret[j] = cell.childNodes[0].value;
            for (var k = 0; k < cell.childNodes.length; k++) {
                if (cell.childNodes[k].id != undefined) {
                    if (k > 0) {
                        strValue = strValue + ColSeparator + cell.childNodes[k].value;
                    }
                    else {
                        strValue = cell.childNodes[k].value;
                    }
                }
            }
        }
        else {
            ret[j] = cell.innerText;
        }
    }
    if (strValue != "") {
        ret[ret.length] = strValue;
    }
    window.returnValue = ret;
    window.close();
}
function StrToBool(value) {
    if ((value == "True") || (value == "true") || (value == "1")) {
        return true;
    }
    else {
        return false;
    }
}
String.prototype.Trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.LTrim = function () {
    return this.replace(/(^\s*)/g, "");
}
String.prototype.Rtrim = function () {
    return this.replace(/(\s*$)/g, "");
}
String.prototype.DotExists = function () {
    return this.indexOf(".") >= 0;
}
String.prototype.LineExists = function () {
    return this.indexOf("-") >= 0;
}
function SelectedDiv(selectId, LiCount) {
    var DivName;
    var LiName;
    for (var i = 1; i <= LiCount; i++) {
        if (selectId == i) {
            DivName = "divMiddle" + selectId.toString();
            document.getElementById(DivName).style.display = "block";
            LiName = "a" + selectId.toString();
            document.getElementById(LiName).className = "f12e navNml navOn";
        }
        else {
            DivName = "divMiddle" + i.toString();
            document.getElementById(DivName).style.display = "none";
            LiName = "a" + i.toString();
            document.getElementById(LiName).className = "f12c navNml noSep";
        }
    }
}
function ShowDivPage(divPage) {
    var DivName = "a" + divPage.toString();
    var obj = document.getElementById(DivName);
    if (obj.style.display == "none") {
        obj.style.display = "inline-block";
    }
    else {
        obj.style.display = "none";
    }
}
String.prototype.Trim = function ()
{ return this.replace(/(^\s*)|(\s*$)/g, ""); }
String.prototype.LTrim = function ()
{ return this.replace(/(^\s*)/g, ""); }
String.prototype.RTrim = function ()
{ return this.replace(/(\s*$)/g, ""); }
//----------------------------------------------------------------------------------------
function textLimit(event, obj, intPar) {
    if (obj.value.length >= intPar + 1) {
        obj.value = obj.value.substring(0, intPar)
        event.keyCode = 0;
        return;
    }
}
//---------------------Replace String when Insert to DataBase---------------------------------------------------------------
function StringSafe(strValue) {
    return strValue.replace("\n", "").replace("<", "&lt;").replace(">", "&gt;").replace("\r", "<br>").replace(" ", "&nbsp;");
}
