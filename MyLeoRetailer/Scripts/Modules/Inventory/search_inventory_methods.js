
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

            Reset_Inventory();

            Set_Branch_Id();

            $("#divInventoryPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Friendly_Messages(obj);
        }
    });
}

function Reset_Inventory()
{
    $("[name='Filter.Branch_Id']").val("");

    $("[name='Filter.Product_SKU']").val("");

    $("#hdnBranch_Id").val("");

    $("#hdnBranch_Name").val("");

    $("#hdnInventory_Id").val("");

    $("#hdnProduct_SKU").val("");

    $("#hdntempId").val("");

    $("#textBrand").val("");

    $("#textSKU_Code").val("");
}


function Set_Branch_Id() {

    var Id = $("#hdnBranchIDs").val();

    var Lookup_Id = $("#hdnBranch_Id").val();

    if (Lookup_Id == NaN || Lookup_Id == '')
    {
        $("#hdntempId").val(Id);
    }
    else
    {
        $("#hdntempId").val(Lookup_Id);
    }

    
}

