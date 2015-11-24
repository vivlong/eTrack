//Add Separator
function splitNumber(eValue) {
    var intPart = "";
    var decPart = "";
    if (eValue.indexOf(",") >= 0) {
        eValue = eValue.replace(/,/g, "");
    }
    if (eValue.indexOf(".") >= 0) {
        intPart = eValue.split(".")[0];
        decPart = eValue.split(".")[1];
    }
    else {
        intPart = eValue;
    }
    var num = intPart + "";
    var re = /(-?\d+)(\d{3})/
    while (re.test(num)) {
        num = num.replace(re, "$1,$2")
    }
    if (eValue.indexOf(".") >= 0) {
        eValue = num + "." + decPart;
    }
    else {
        eValue = num;
    }
    return eValue;
}


function RemoveSeparator(value) {
    return value.replace(/,/g, "");
}

function DeleteTailZero(value) {
    if (value != "") {
        var len = value.length;
        var dotFind = false;
        if (value.indexOf(".") < 0) {
            return value;
        }
        for (var i = len - 1; i > 0; i--) {
            if (value.charAt(i) == ".") {
                dotFind = true;
                break;
            }
            else if (value.charAt(i) != "0") {
                break;
            }
        }
        if (dotFind) {
            return value.substring(0, i);
        }
        else {
            return value.substring(0, i + 1);
        }
    }
    else {
        return "0";
    }
}

function NumberFocus() {
    var e = event.srcElement;
    if (e.readOnly) {
        return;
    }
    var tmpvalue = DeleteTailZero(RemoveSeparator(e.value));
    if (tmpvalue == "0") {
        e.value = "";
    }
    else {
        e.value = tmpvalue;
    }
    //    var r =e.createTextRange();
    //    e.style.textAlign="left";
    //    r.moveStart("character",e.value.length);
    //    r.collapse(true);
    //    r.select();
}

function NumberBlur(event, dotlen, intFlag) {
    var e = event.srcElement ? event.srcElement : event.target;
    if (e.readOnly) {
        return;
    }
    if (e.value == "") {
        if (intFlag) {
            //            e.value="0";  
        }
        else {
            e.value = (parseFloat("0")).toFixed(dotlen);
        }
    }
    else if (e.value == "-") {
        if (intFlag) {
            e.value = "0";
        }
        else {
            e.value = (parseFloat("0")).toFixed(dotlen);
        }
    }
    else {
        if (intFlag) {
            e.value = DeleteTailZero((parseFloat(e.value).toFixed(dotlen)));
        }
        else {
            e.value = splitNumber((parseFloat(e.value)).toFixed(dotlen));
        }
    }
    e.style.textAlign = "left";
}
function DateFocus() {
    var e = event.srcElement;
    if (e.readOnly) {
        return;
    }
    if (e.value == "0") {
        e.value = "";
    }
    //    var r =e.createTextRange();
    //    e.style.textAlign="left";
    //    r.moveStart("character",e.value.length);
    //    r.collapse(true);
    //    r.select();
}

function DateBlur() {
    var e = event.srcElement;
    if (e.readOnly) {
        return;
    }
    if (e.value == "") {
        e.value = "0";
    }
    e.style.textAlign = "right";
}

function getNumber(strValue) {
    var strNum = "0123456789.";
    if (strValue == "") {
        return 0;
    }
    else {
        for (var i = 0; i < strValue.length; i++) {
            if (strNum.indexOf(strValue.charAt(i)) < 0) {
                break;
            }
        }
        return strValue.substring(0, i);
    }
}
//090330
function NumberFocus(obj)
{ return false; }
function NumberFocus(event, obj) {
    var e = event.srcElement ? event.srcElement : event.target;
    if (e.readOnly) {
        return;
    }
    var tmpvalue = DeleteTailZero(RemoveSeparator(e.value));
    if (tmpvalue == "0") {
        e.value = "";
    }
    else {
        e.value = tmpvalue;
    }
    //    var r =e.createTextRange();
    //    e.style.textAlign="left";
    //    r.moveStart("character",e.value.length);
    //    r.collapse(true);
    //    r.select();

    //    var Sel = window.document.body.createTextRange();
    //    Sel.moveToElementText(obj);
    //    window.document.execCommand("SelectAll");
}
//081118bylzw
function NumberFocusbylzw(obj) {
    var e = event.srcElement;
    if (e.readOnly) {
        return;
    }
    var tmpvalue = DeleteTailZero(RemoveSeparator(e.value));
    if (tmpvalue == "0") {
        e.value = "";
    }
    else {
        e.value = tmpvalue;
    }
    var r = e.createTextRange();
    e.style.textAlign = "left";
    r.moveStart("character", e.value.length);
    r.collapse(true);
    r.select();

    var Sel = window.document.body.createTextRange();
    Sel.moveToElementText(obj);
    window.document.execCommand("SelectAll");
}

function NumberFocusEqu(obj) {
    var e = event.srcElement;
    if (e.readOnly) {
        return;
    }
    var tmpvalue = DeleteTailZero(RemoveSeparator(e.value));
    if (tmpvalue == "0") {
        e.value = "";
    }
    else {
        e.value = tmpvalue;
    }
    var r = e.createTextRange();
    e.style.textAlign = "left";
    r.moveStart("character", e.value.length);
    r.collapse(true);
    var Sel = window.document.body.createTextRange();
    Sel.moveToElementText(obj);
    window.document.execCommand("SelectAll");
}