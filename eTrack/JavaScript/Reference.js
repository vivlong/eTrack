    //090324 forWMS lzw
function PrintDetail(Title,Type,SelectionFormula,SfValue,ResUrl) {
	if (Title) {
		var strUrl = "../loading.aspx?tourl=" + PrintPath + "/crPrintToReport.aspx?Title="+Title + "&Type="+Type+"&SelectionFormula="+SelectionFormula+"&SfValue="+SfValue+"&ResUrl="+ResUrl+"";
		window.open(strUrl);
	}
}
function PrintCrystalReport(FileName, FormulaField,FormulaFieldValue,Type) {
	if (FileName) {
		var strUrl = "../loading.aspx?tourl=" + PrintPath + "/crReport.aspx?FileName="
		+ FileName + "&FormulaField=" + FormulaField + "&FormulaFieldValue=" + FormulaFieldValue + "&Type=" + Type + "";
		window.open(strUrl);
	}
}