$(function () {


    $("#btnSaveChaneBranch").click(function (event) {

        var Page_URL = $('#hdnPage_URL').val();
        
        $("#div_Change_Branch").find(".panel-body").load("/Employee/Change_Branch", { Url: Page_URL }, call_back);


    });

});