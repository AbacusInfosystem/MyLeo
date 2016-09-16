$(function () {

    Get_SalesReturns();


    $("[name='Filter.Sales_Return_No']").focusout(function ()
    {
        Get_SalesReturns();
    });

});


