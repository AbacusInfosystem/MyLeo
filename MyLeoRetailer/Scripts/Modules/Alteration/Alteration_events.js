//$(function () {


//    $("#btnSaveAlteration").click(function () {

//        if ($("#frmAlteration1").valid()) {

//            Save_Alteration();


//        }
//    });

//});


$(function () {

    $("#btnSaveAlteration").click(function () {
        if ($("#frmAlteration1").valid()) {
            
            if ($("#hdnAlteration_ID").val() == 0) {
                $("#frmAlteration1").attr("action", "/Alteration/Insert_Alteration/");
            }
            else {
                $("#frmAlteration1").attr("action", "/Alteration/Update_Alteration/");
            }
            $('#frmAlteration1').attr("method", "POST");
            $('#frmAlteration1').submit();
        }
    });

});