$(function () {

    $("input.mask_phone_no").mask('(9999) 9999-9999');
    //if ($("[name='Branch.Branch_ID']").val() == "" || $("[name='Branch.Branch_ID']").val() == 0) {
    //    document.getElementById("btnCancleBranch").disabled = false;
    //}
    //else {
    //    document.getElementById('btnCancleBranch').disabled = true;
    //}

  
    $("#btnSaveBranch").click(function () {
       
        if ($("#frmBranch").valid())
        {
            if ($('#hdnBranch_Id').val() == "" || $('#hdnBranch_Id').val() == 0) {  //Added by Sushant on 07/10/2016
                $("#frmBranch").attr("action", "/Branch/Insert_Branch");                
            }
            else {
                $("#frmBranch").attr("action", "/Branch/Update_Branch");                
            }
            $('#frmBranch').attr("method", "POST");
            $("#frmBranch").submit();
        }        
    });

    $("#btnAddNear").click(function () {

        $('#txtNear_Location_Pincode').rules("add", { required: true, digits: true, minlength: 6, messages: { required: "Required Field.", digits: "Invalid pin", minlength: "atleast 6 digits." } });
        
        if ($("#txtNear_Location_Pincode").valid()) {
            AddNearLocationDetails();
        }
        $("#txtNear_Location_Pincode").rules("remove");
        
    });

    $("#btnAddFar").click(function () {
        $('#txtFar_Location_Pincode').rules("add", { required: true, digits: true, minlength: 6, messages: { required: "Required Field.", digits: "Invalid pin", minlength: "atleast 6 digits." } });

        if ($("#txtFar_Location_Pincode").valid()) {
            AddFarLocationDetails();
        }
        $("#txtFar_Location_Pincode").rules("remove");
    });

    $("#btnCancleBranch").click(function () {
        Reset_Branch();
    });

});