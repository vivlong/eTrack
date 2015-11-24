<script language ="javascript" type="text/javascript">
function ResetSize(WindowType,FixSize)
{
    switch (WindowType){
    //Master List Dialog
        case 0: 
            if(FixSize==0 || FixSize==null){
                FixSize=85;
            }
            var intHeight=(screen.height/600)*<%= SysMagic.SystemClass.MasterListSize.Height%>
            document.getElementById("divSource").style.height=intHeight-FixSize;
            break;
    //BaseInfo Refer List Dialog
        case 1:
            if(FixSize==0 || FixSize==null){
                FixSize=85;
            }
            var intHeight=(screen.height/600)*<%=SysMagic.SystemClass.InfoListSize.Height%>
            document.getElementById("divSource").style.height=intHeight-FixSize;
            break;
    //MuitiSelect Paging  Dialog          
        case 2:
            if(FixSize==0 || FixSize==null){
                FixSize=115;
            }
            var intHeight=(screen.height/600)*<%=SysMagic.SystemClass.SourceDestinationSize.Height%>
            document.getElementById("divSource").style.height=(intHeight-FixSize)/2;
            document.getElementById("divDestination").style.height=(intHeight-FixSize)/2;
            break;
    //Master Input 
        case 10:
            if(FixSize==0 || FixSize==null){
                FixSize=120;
            }
            //window Height
            var intHeight=0
            if(window.screenY){intHeight=screen.availHeight-window.screenY-30;}
            else{intHeight=screen.availHeight-window.screenTop-30;}
            document.getElementById("middle").style.height=intHeight-FixSize;
            break;
    //Info List Input 
        case 11:
            if(FixSize==0 || FixSize==null){
               var objSearchField=document.getElementById("divTopNav");
               if(objSearchField){ 
                  if (objSearchField.style.display != "none"){
                      FixSize=80; 
                    }
                  else{ 
                      FixSize=50;
                    }
                }
               else{
                 FixSize=50;
               } 
            }
            //window Height
            var intHeight=0
            if(window.screenY){intHeight=screen.availHeight-window.screenY-30;}
            else{intHeight=screen.availHeight-window.screenTop-30;}
            document.getElementById("divSource").style.height=intHeight-FixSize;
            break;
    //Query Result
        case 12:
            if(FixSize==0 || FixSize==null){
                FixSize=50;
            }
            //window Height
            if(window.screenY){intHeight=screen.availHeight-window.screenY-30;}
            else{intHeight=screen.availHeight-window.screenTop-30;}
            document.getElementById("divSource").style.height=intHeight-FixSize;
            break;
    //Analyze Result
        case 13:
            if(FixSize==0 || FixSize==null){
                FixSize=55;
            }
            //window Height
            var intHeight=screen.availHeight-window.screenY-30;
            document.getElementById("divSource").style.height=intHeight-FixSize;
            break;            
     //Download Result
        case 14:
            if(FixSize==0 || FixSize==null){
                FixSize=55;
            }
            //window Height
            var intHeight=screen.availHeight-window.screenY-30;
            document.getElementById("divMiddle1").style.height=intHeight-FixSize;
            break;            
    } 
} 
</script>