function call_back(data) {

    //$('#div_Change_Branch').panel('show');
    $("#div_Change_Branch").find(".panel-title").text("Branches");

    $("#div_Change_Branch").find(".panel-footer").hide();

    $("#btnSaveBranch_Comm").click(function (event) {

        //$('#div_Change_Branch').panel('hide');

        $("#frmChangeBranch").attr("action", "/Employee/Save_Employee_Branch_Id");
        $("#frmChangeBranch").submit();

    });

}



