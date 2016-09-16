

$(function () {

    Get_SalesOrders();


    $("[name='Filter.Sales_Invoice_No']").focusout(function () {

        Get_SalesOrders();

    });


});


