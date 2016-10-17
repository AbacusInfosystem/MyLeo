
 
function ResetForm() {
    $('#frmEmployee').each(function () {
       
      
        this.reset();
       
    });
    //$('[data-id="drpDesignation"]').html("Select Designation" + " <span class=\"caret\"></span>");
    //$('[data-id="drpGender"]').html("Select Gender" + " <span class=\"caret\"></span>"); 
    //$('[data-id="drpBranch"]').html("Select Branch" + " <span class=\"caret\"></span>");
}



//function checkDate() {
  
//    var EnterDOB = document.getElementById("txt_DOB").value; 
//    var date = new Date(Date.parse(EnterDOB.replace(" -", "")));
//    alert(new Date(Date.now(Date())));
//    if (date >= new Date(Date.now())) {
//        alert("Entered date is greater than today's date");       
//    }
//}


