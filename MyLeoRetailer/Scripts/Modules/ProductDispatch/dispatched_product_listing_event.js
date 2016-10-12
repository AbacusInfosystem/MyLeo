$(document).ready(function () {
    Get_Product_Dispatch();

    $("#btnAccept").click(function () {

        if (document.getElementsByClassName("table")[0].rows.length > 1) {

            $("#frmInwardProduct").attr("action", "/ProductDispatch/Accept_Product_Dispatch");

            $("#frmInwardProduct").attr("Method", "POST");

            $("#frmInwardProduct").submit();
        }
    });
});
