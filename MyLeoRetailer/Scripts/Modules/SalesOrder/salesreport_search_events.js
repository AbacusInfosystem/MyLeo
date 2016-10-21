
$(function () {

    Get_Sales_Report();
   
    document.getElementById('btnDetails').disabled = true;

    $(document).on('change', '[name="SalesOrder_List"]', function (event) {

        if ($(this).prop('checked')) {

            $("#hdnSalesInvoiceID").val(this.value);

            document.getElementById('btnDetails').disabled = false;

        }
      
    });

    $("#btnSearchSales").click(function () {

        Get_Sales_Report();
    }

    );
  

    if ($('#frmSearchSalesOrderReport').valid()) {

        $("#btnDetails").click(function (event) {

            var InvoiceId = $('#hdnSalesInvoiceID').val();
            $("#div_Parent_Modal_Fade").find(".modal-body").load("/SalesOrder/View_Sales_Report", { InvoiceId: InvoiceId }, call_back);

            
        });
    }

});

 
