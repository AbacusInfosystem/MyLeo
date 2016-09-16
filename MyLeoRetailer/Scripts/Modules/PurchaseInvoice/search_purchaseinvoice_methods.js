function Get_Purchase_Invoices() {
    var poViewModel =
		{
		    Filter: {

		        Purchase_Invoice_No: $("[name='Filter.Purchase_Invoice_No']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divPurchaseInvoicePager"))
		    }
		}

    $.ajax({

        url: "/PurchaseInvoice/Get_Purchase_Invoices",

        data: JSON.stringify(poViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Purchase_Invoice_List");

            $("#divPurchaseInvoicePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}