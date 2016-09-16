function Get_Purchase_Orders()
{
    var poViewModel =
		{
		    Filter: {

		        Purchase_Order_No: $("[name='Filter.Purchase_Order_No']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divPurchaseOrderPager"))
		    }
		}

    $.ajax({

        url: "/PurchaseOrder/Get_Purchase_Orders",

        data: JSON.stringify(poViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Purchase_Order_List");

            $("#divPurchaseOrderPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}