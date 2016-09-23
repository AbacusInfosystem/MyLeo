$(document).ready(function () {

    Get_Purchase_Return_Requests();

    $("#drpVendor_Id").change(function () {

        Get_Purchase_Return_Requests();

    });


});
