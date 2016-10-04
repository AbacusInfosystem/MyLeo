
function Get_Product_Dispatch() {
    var pViewModel =
		{
		    Filter: {

		        Branch_Name: $("[id='txtBranch_Name']").val(),

		        From_Request_Date: $("[id='txtFromRequestDate']").val(),

		        To_Request_Date: $("[id='txtToRequestDate']").val(),

		        Status: $("[id='drpStatus']").val(),
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divProductDispatchPager"))
		    }
		}

    $.ajax({

        url: "/ProductDispatch/Get_Product_To_Dispatch",

        data: JSON.stringify(pViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "ProductDispatch_List");

            $("#divProductDispatchPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}