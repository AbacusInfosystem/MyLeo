function Get_ProductWarehouse() {
    var pViewModel =
		{
		    Filter: {

		        Product_SKU: $("[name='Filter.Product_SKU']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divProductWarehousePager"))
		    }
		}

    $.ajax({

        url: "/ProductWarehouse/Get_WarehouseProducts",

        data: JSON.stringify(pViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "ProductWarehouse_List");

            $("#divProductWarehousePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}