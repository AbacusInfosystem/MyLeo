﻿
function Get_Inventories() {
    var iViewModel =
		{
		    Filter: {

		        Branch_Id: $("[name='Filter.Branch_Id']").val(),

		        Product_SKU: $("[name='Filter.Product_SKU']").val(),

		        Brand_Code: $("[name='Filter.Brand_Code']").val(),

		        Category_Code: $("[name='Filter.Category_Code']").val()
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

            //Reset_Inventory();

            Set_Branch_Id();

            Set_Brand_Code();

            Set_Category_Code();

            $("#divInventoryPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Friendly_Messages(obj);
        }
    });
}

function Reset_Inventory() {

    $("[name='Filter.Branch_Id']").val("");

    $("[name='Filter.Product_SKU']").val("");

    $("[name='Filter.Brand_Name']").val();

    $("[name='Filter.Category']").val();

    $("#hdnBranch_Id").val("");

    $("#hdnBranch_Name").val("");

    $("#hdnInventory_Id").val("");

    $("#hdnProduct_SKU").val("");

    $("#hdntempId").val("");

    $("#textBranch").val("");

    $("#textSKU_Code").val("");

    $("#hdnBrand_Code").val("");

    $("#hdnBrand_Name").val("");

    $("#textBrand").val("");

    $("#hdnCategory").val("");

    $("#hdnCategory_Code").val("");

    $("#textCategory").val("");

    $("#hdnBranch_Id").parents('.form-group').find('#lookupUlLookup').remove();

    $("#hdnInventory_Id").parents('.form-group').find('#lookupUlLookup').remove();

    $("#hdnBrand_Code").parents('.form-group').find('#lookupUlLookup').remove();

    $("#hdnCategory").parents('.form-group').find('#lookupUlLookup').remove();

}

function Set_Branch_Id() {

    var Id = $("#hdnBranchIDs").val();

    var Lookup_Id = $("#hdnBranch_Id").val();

    if (Lookup_Id == NaN || Lookup_Id == '') {
        $("#hdntempId").val(Id);
    }
    else {
        $("#hdntempId").val(Lookup_Id);
    }


}

function Set_Brand_Code() {

    var Id = $("#hdnBranchIDs").val();

    var Lookup_Id = $("#hdnBrand_Name").val();

    if (Lookup_Id == NaN || Lookup_Id == '') {
        $("#hdntempId").val(Id);
    }
    else {
        $("#hdntempId").val(Lookup_Id);
    }


}

function Set_Category_Code() {

    var Id = $("#hdnBranchIDs").val();

    var Lookup_Id = $("#hdnCategory").val();

    if (Lookup_Id == NaN || Lookup_Id == '') {
        $("#hdntempId").val(Id);
    }
    else {
        $("#hdntempId").val(Lookup_Id);
    }


}
