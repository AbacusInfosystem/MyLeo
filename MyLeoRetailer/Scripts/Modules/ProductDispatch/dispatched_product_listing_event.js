$(document).ready(function () {
    Get_Product_Dispatch();


    $("#btnAccept").click(function () {

        $("#frmInwardProduct").attr("action", "/ProductDispatch/Accept_Product_Dispatch");

        $("#frmInwardProduct").attr("Method", "POST");

        $("#frmInwardProduct").submit();
    });
});
