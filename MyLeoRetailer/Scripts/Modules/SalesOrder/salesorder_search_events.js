
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
        document.getElementById('btnPrint').disabled = true;//Added by vinod mane on 25/10/2016
        document.getElementById('btnView').disabled = true;//Added by vinod mane on 25/10/2016
        Get_SalesOrders();
    });
    //Added by vinod mane on 25/10/2016
    $(document).on("change", "#hdnSalesInvoiceNo", function () {

        document.getElementById('btnPrint').disabled = true;
        document.getElementById('btnView').disabled = true;
        Get_SalesOrders();
    });
    //End
});


