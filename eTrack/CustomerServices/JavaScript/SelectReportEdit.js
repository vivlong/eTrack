<script language ="javascript" type="text/javascript">
 var blChanged=false;
 function CloseWindow()
 {
        if(blChanged) {
            window.returnValue=RtnOk;
        }
        else {
            window.returnValue=RtnNoChange;
        }
        window.close();     
 }

</script>