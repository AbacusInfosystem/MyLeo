
$(function () {

    document.getElementById('btnPrint').disabled = true;

    document.getElementById('btnView').disabled = true;

    Get_SalesOrders();


    $("#btnPrint").click(function () {

        $("#hdnFlag").val(true);

        $("#frmSearchSalesOrder").attr("action", "/SalesOrder/Get_SalesOrder_By_Id/");

        $('#frmSearchSalesOrder').attr("method", "POST");

        $('#frmSearchSalesOrder').submit();

    });

    $("#btnView").click(function () {

        $("#frmSearchSalesOrder").attr("action", "/SalesOrder/Get_SalesOrder_By_Id/");

        $('#frmSearchSalesOrder').attr("method", "POST");

        $('#frmSearchSalesOrder').submit();

    });



    $(document).on('change', '[name="SalesOrder_List"]', function (event) {

        if ($(this).prop('checked'))
        {

            $("#hdnSalesInvoiceID").val(this.value);

            document.getElementById('btnPrint').disabled = false;

            document.getElementById('btnView').disabled = false;
        }
    });

    $("#btnPrint").click(function () {

        $("#frmSearchSalesOrder").attr("action", "/SalesOrder/Get_SalesOrder_By_Id");

        $("#frmSearchSalesOrder").submit();

    });

    $("[name='Filter.Sales_Invoice_No']").focusout(function ()
    {
        Get_SalesOrders();
    });

});


