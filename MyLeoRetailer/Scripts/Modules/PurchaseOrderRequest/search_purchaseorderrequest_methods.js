function Get_Purchase_Order_Requests() {
    var poreqViewModel =
		{
		    Filter: {

		        Vendor_Id: $("[name='Filter.Vendor_Id']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divPurchaseOrderRequestPager"))
		    }
		}

    $.ajax({

        url: "/PurchaseOrderRequest/Get_Purchase_Order_Requests",

        data: JSON.stringify(poreqViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Purchase_Order_Request_List");

            $("#divPurchaseOrderRequestPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

function Set_Vendor_Id(value)
{
    $("[name='Filter.Vendor_Id']").val(value);

    Get_Purchase_Order_Requests();
}