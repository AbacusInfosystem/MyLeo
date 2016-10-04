
function Get_Inventory() {
    var iViewModel =
		{
		    Filter: {

		        Inventory_Id: $("[name='Filter.Inventory_Id']").val()
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

            Bind_Grid(obj, "Inventory_List");

            $("#divInventoryPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Friendly_Messages(obj);
        }
    });
}


