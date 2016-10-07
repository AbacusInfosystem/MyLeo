
function Get_Inventories() {
    var iViewModel =
		{
		    Filter: {

		        Branch_Id: $("[name='Filter.Branch_Id']").val(),

		        Product_SKU: $("[name='Filter.Product_SKU']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divInventoryPager"))
		    }
		}

    $.ajax({

        url: "/Inventory/Get_Inventories",

        data: JSON.stringify(iViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            //Bind_Grid(obj, "Inventory_List");// commented by aditya

            Bind_custom_Grid(obj, "Inventory_List", "Inventories", ""); // added by aditya

            $("#divInventoryPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Friendly_Messages(obj);
        }
    });
}


