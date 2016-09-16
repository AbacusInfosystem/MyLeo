﻿$(document).ready(function () {

    Get_Roles();
    
    Get_RoleAccess_Functions(0);

    $("#btnSave").click(function () {
        if ($("#frmRole").valid()) {
            Save_Role();
        }
    });

    $("[name='Filter.Role']").focusout(function () {
        Get_Roles();
    });

    $(document).on("click", "[name='Role_List']", function () {

        Get_Role_By_Id(this);

    });

    $(document).on("click", "#btnCancel", function () {

        Reset_Role();

    });

    

});