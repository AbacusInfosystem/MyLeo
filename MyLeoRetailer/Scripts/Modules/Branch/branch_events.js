﻿$(function () {

    //$("#btnSaveBranch").click(function () {
    //    if ($("#frmBranchPrimaryInfo").valid()) {
    //        //Save_Branch();
    //    }
    //});


    $("#btnSaveBranch").click(function () {
        if ($("#frmBranch").valid())
        {
            if ($("[name='Branch.Branch_ID']").val() == "" || $("[name='Branch.Branch_ID']").val() == 0) {
                $("#frmBranch").attr("action", "/Branch/Insert_Branch");
                $("#frmBranch").submit();
            }
            else {
                $("#frmBranch").attr("action", "/Branch/Update_Branch");
                $("#frmBranch").submit();
            }            
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


});