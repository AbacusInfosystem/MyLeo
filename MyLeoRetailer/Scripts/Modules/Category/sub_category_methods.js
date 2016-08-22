
function Get_Sub_Categories()
{
	var sViewModel =
		{
			Filter: {

				Category_Id : $("[name='Filter.Category_Id']").val(),

				Sub_Category: $("[name='Filter.Sub_Category']").val()
			},
			Grid_Detail: {

				Pager: Set_Pager($("#divSubCategoryPager"))
			}
		}

	$.ajax({

		url: "/Category/Get_Sub_Catgories",

		data: JSON.stringify(sViewModel),

		dataType: 'json',

		type: 'POST',

		contentType: 'application/json',

		success: function (response)
		{

			var obj = $.parseJSON(response);

			Bind_Anchor_Grid(obj, "Sub_Category_List", $("#SubCategory_Grid"));

			$("#divSubCategoryPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
		}
	});
}

function Save_Sub_Category()
{
	var sViewModel =
		{
			SubCategory: {

				Sub_Category: $("[name='SubCategory.Sub_Category']").val(),

				Sub_Category_Id: $("[name='SubCategory.Sub_Category_Id']").val(),

				Category_Id :$("[name='SubCategory.Category_Id']").val()
			}
		}

	var url = "";

	if ($("[name='SubCategory.Sub_Category_Id']").val() == "")
	{
		url = "/Category/Insert_Sub_Category";
	}
	else
	{
		url = "/Category/Update_Sub_Category";
	}

	$.ajax({

		url: url,

		data: JSON.stringify(sViewModel),

		dataType: 'json',

		type: 'POST',

		contentType: 'application/json',

		success: function (response)
		{
			var obj = $.parseJSON(response);

			Reset_Sub_Category();

			Get_Sub_Categories();

			Friendly_Messages(obj);
		}
	});


}

function Reset_Sub_Category()
{
	$("[name='SubCategory.Sub_Category']").val("");

	$("[name='SubCategory.Sub_Category_Id']").val("");
}

function Get_Sub_Category_By_Id(obj)
{
	$("[name='Sub_Category_List']").removeClass("active");

	$(obj).addClass("active");

	$("[name='SubCategory.Sub_Category']").val($(obj).text());

	$("[name='SubCategory.Sub_Category_Id']").val($(obj).attr("data-identity"));
}