$(document).ready(function () {

    $("#btnNotification").click(function () {


        $("#div_Warehouse_Notification").find(".panel-body").load("/ProductWarehouse/Warehouse_Notifiation");

    });

});