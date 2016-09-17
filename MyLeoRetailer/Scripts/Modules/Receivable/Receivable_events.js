

$(function () {

    $("#btnSearchReceivable").click(function () {

        $("#frmReceivable").attr("action", "/Receivable/Get_Receivable");

        $("#frmReceivable").submit();
    });

});