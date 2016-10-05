$(function () {


    $("#btnSaveChaneBranch").click(function (event) {

        
        $("#div_Change_Branch").find(".panel-body").load("/Employee/Change_Branch", call_back);


    });

});