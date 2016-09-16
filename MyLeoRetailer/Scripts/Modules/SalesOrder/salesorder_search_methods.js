function Get_SalesOrders() {

    var siViewModel =
		{
		    Filter: {

		        Sales_Invoice_No: $("[name='Filter.Sales_Invoice_No']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divSalesOrderPager"))
		    }
		}

    $.ajax({

        url: "/SalesOrder/Get_SalesOrder",

        data: JSON.stringify(siViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "SalesOrder_List");

            Reset_SalesOrder();

            $("#divSalesOrderPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

function Reset_SalesOrder() {

    $("[name='Filter.Sales_Invoice_No']").val("");

    $("[name='Filter.Sales_Invoice_Id']").val("");

}