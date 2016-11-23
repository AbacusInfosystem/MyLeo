
$(document).ready(function () {

    if ($("#text_Employee_Id").val() != 0) {

        $("#Employee").find(".autocomplete-text").trigger("focusout");
    }
    else
    {
        $("#text_Employee_Id").val('');
    }

    if ($("#text_Sales_Invoice_Id").val() != 0) {

        $("#Invoice").find(".autocomplete-text").trigger("focusout");
    }
    else
    {
        $("#text_Sales_Invoice_Id").val('');
    }

    $("input.mask_mobile_no").mask('(99) 99999-99999');

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

    $("#btnResetAlteration").click(function () {
        reset();
    });

});

