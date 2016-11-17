$(function () {


    document.getElementById('btnView').disabled = true;

    Get_SalesReturns();


    $("[name='Filter.Sales_Return_No']").focusout(function ()
    {
        document.getElementById('btnView').disabled = true;
        Get_SalesReturns();
    });


    $(document).on('change', '[name="SalesReturn_List"]', function (event) {

        if ($(this).prop('checked'))
        {
            $("#hdnSalesReturnID").val(this.value);

            document.getElementById('btnView').disabled = false;
        }
    });


    $("#btnView").click(function () {

        $("#frmSearchSalesReturn").attr("action", "/SalesReturn/Get_Sales_Return_By_Id/");

        $('#frmSearchSalesReturn').attr("method", "POST");

        $('#frmSearchSalesReturn').submit();

    });

    //Added by vinod mane on 25/10/2016
    $(document).on("change", "#hdnSalesReturnNo", function () {
        document.getElementById('btnView').disabled = true;
        Get_SalesReturns();
    });
    //End
});


