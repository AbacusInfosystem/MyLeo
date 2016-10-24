

function Get_Products() {
    var pViewModel =
		{
		    Filter: {

		        Article_No: $("[name='Filter.Article_No']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divProductPager"))
		    }
		}

    $.ajax({

        url: "/Product/Get_Products",

        data: JSON.stringify(pViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Product_List");

            //Reset_Product();

            $("#divProductPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
} 


