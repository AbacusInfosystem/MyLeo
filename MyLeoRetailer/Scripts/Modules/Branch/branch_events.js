$(function () {

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
        AddNearLocationDetails();
    });

    $("#btnAddFar").click(function () {
        AddFarLocationDetails();
    });


});