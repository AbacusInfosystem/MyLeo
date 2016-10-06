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

            //Bind_Grid(obj, "ProductWarehouse_List");

            Bind_custom_Grid(obj, "ProductWarehouse_List", "List_product_warehouse", ""); // Custom common method (List_product_Dispatch is used for binding in name eg: name"List_product_Dispatch[0].SKU" and checkbox is for radio type to bind on list and is check is propert in class of viewmodel )


            $("#divProductWarehousePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}