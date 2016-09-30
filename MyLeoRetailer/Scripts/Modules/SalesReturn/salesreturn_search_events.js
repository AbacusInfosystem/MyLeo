$(function () {


    $("#btnView").hide();

    Get_SalesReturns();


    $("[name='Filter.Sales_Return_No']").focusout(function ()
    {
        Get_SalesReturns();
    });


    $(document).on('change', '[name="SalesReturn_List"]', function (event) {

        if ($(this).prop('checked'))
        {
            $("#hdnSalesReturnID").val(this.value);

            $('#btnView').show();
        }
    });


    $("#btnView").click(function () {

        $("#frmSearchSalesReturn").attr("action", "/SalesReturn/Get_Sales_Return_By_Id/");

        $('#frmSearchSalesReturn').attr("method", "POST");

        $('#frmSearchSalesReturn').submit();

    });

});


