
function Get_Product_Dispatch() {
    var pViewModel =
		{
		    Filter: {

		        Branch_Name: $("[id='txtBranch_Name']").val(),

		        From_Request_Date: $("#txtFromRequestdate").val(),

		        To_Request_Date: $("#txtToRequestdate").val(),

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

function Reset_Product_Dispatch()
{
    $("#hdnBranch_Id").val("");

    $("#hdnBranchName").val("");

    $("#txtBranch_Name").val("");

    $("#txtFromRequestdate").val("");

    $("#txtToRequestdate").val("");

    $("#drpStatus").val("");

    $("#hdnBranch_Id").parents('.form-group').find('#lookupUlLookup').remove();

    $("#btnDateFilter").hide();
}