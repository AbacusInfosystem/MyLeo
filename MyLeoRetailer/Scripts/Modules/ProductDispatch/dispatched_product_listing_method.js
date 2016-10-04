function Get_Product_Dispatch() {
   
    $.ajax({

        url: "/ProductDispatch/Dispatched_Product_Listing_binding",

        data: JSON.stringify(null),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "ProductDispatch_List", List_product_Dispatch);

            $("#divProductDispatchPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}