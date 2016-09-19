function Get_Purchase_Returns() {
    var prViewModel =
		{
		    Filter: {

		        Debit_Note_No: $("[name='Filter.Debit_Note_No']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divPurchaseReturnPager"))
		    }
		}

    $.ajax({

        url: "/PurchaseReturn/Get_Purchase_Returns",

        data: JSON.stringify(prViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Purchase_Return_List");

            $("#divPurchaseReturnPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}