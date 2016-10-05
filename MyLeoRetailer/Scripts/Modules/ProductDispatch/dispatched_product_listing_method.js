function Get_Product_Dispatch() {
    var pViewModel =
		{
		    Grid_Detail: {

		        Pager: Set_Pager($("#divProductDispatchPager"))
		    }
		}
   
    $.ajax({

        url: "/ProductDispatch/Dispatched_Product_Listing_binding",

        data: JSON.stringify(pViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_custom_Grid(obj, "Is_Checked", "List_product_Dispatch", "checkbox"); // Custom common method (List_product_Dispatch is used for binding in name eg: name"List_product_Dispatch[0].SKU" and checkbox is for radio type to bind on list and is check is propert in class of viewmodel )

            $("#divProductDispatchPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}