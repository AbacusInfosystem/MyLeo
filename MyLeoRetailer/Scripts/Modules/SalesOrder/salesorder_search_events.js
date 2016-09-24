//$(document).ready(function () {
   
  
    
//});


$(function () {

    $("#btnPrint").hide();

    Get_SalesOrders();


    $("#btnPrint").click(function () {

        $("#hdnFlag").val(true);

        alert($("#hdnFlag").val());

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

            $('#btnPrint').show();
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


