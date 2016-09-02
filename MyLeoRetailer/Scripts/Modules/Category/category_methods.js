

function Get_Categories()
{
	var cViewModel =
		{
			Filter: {

				Category: $("[name='Filter.Category']").val()
			},
			Grid_Detail: {

				Pager: Set_Pager($("#divCategoryPager"))
			}
		}

	$.ajax({

		url: "/Category/Get_Catgories",

		data: JSON.stringify(cViewModel),// data we are sending to server

		dataType: 'json',  //WHAT WE ARE EXPECTING

		type: 'POST',

		contentType: 'application/json', //WHAT WE ARE SENDING

		success: function (response)
		{

			var obj = $.parseJSON(response);

			Bind_Anchor_Grid(obj, "Category_List", $("#Category_Grid"));

			Reset_Category();

			$("#divCategoryPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
		}
	});
}

function Save_Category()
{
    var activeFlg = false;
    if ($("[name='Category.IsActive']").val() == 1){
        activeFlg = true;
    }

	var cViewModel =
		{
			Category: {

				Category: $("[name='Category.Category']").val(),

			    //IsActive: $("[name='Category.IsActive']").val(),
				IsActive: activeFlg,

				Category_Id: $("[name='Category.Category_Id']").val()
			}
		}

	var url = "";

	if ($("[name='Category.Category_Id']").val() == "")
	{
		url = "/Category/Insert_Category";
	}
	else
	{
		url = "/Category/Update_Category";
	}

	$.ajax({

		url: url,

		data: JSON.stringify(cViewModel),

		dataType: 'json',

		type: 'POST',

		contentType: 'application/json',

		success: function (response)
		{
			var obj = $.parseJSON(response);

			Reset_Category();

			$("#dvSubCategory").html("");

			Get_Categories();

			Friendly_Messages(obj);
			
		}
	});


}

function Reset_Category()
{
	$("[name='Category.Category']").val("");

	$("[name='Category.Category_Id']").val("");

	$("#dvSubCategory").html("");
}

function Get_Category_By_Id(obj)
{
	$("[name='Category_List']").removeClass("active");

	$(obj).addClass("active");

	$("[name='Category.Category']").val($(obj).text());

	$("[name='Category.Category_Id']").val($(obj).attr("data-identity"));

    //
	var Category_Id = $("[name='Category.Category_Id']").val();
	
	$.ajax({

	    url: "/category/get-category-by-id",

	    data: { Category_Id: Category_Id },

	    type: 'POST',

	    success: function (response) {

	        var obj = $.parseJSON(response);

	        if (obj.Category.IsActive == true) {
	            $("[name='Category.IsActive']").val(1);
	            document.getElementById('Flag').checked = true;
	        }
	        else {
	            $("[name='Category.IsActive']").val(0);
	            document.getElementById('Flag').checked = false; 
	        }

	    }
	});
    //

}

function Get_SubCategories(obj)
{
	$("#dvSubCategory").load("/Category/Get_Sub_Category_By_Category_Id", { catgeory_Id: $(obj).attr("data-identity"), category: $(obj).text() });
}







