$(document).ready(function () {

    $("#btnSave").click(function () {
        if ($("#frmRole").valid()) {
            Save_Role();
        }
    });


});