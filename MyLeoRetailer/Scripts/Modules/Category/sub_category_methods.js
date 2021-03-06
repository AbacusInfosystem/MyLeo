﻿
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

			//$("[name='SubCategory.IsActive']").val(1);

			//alert(11);

			//if (obj.SubCategory.IsActive == true) {
			//    $("[name='SubCategory.IsActive']").val(1);
			//    document.getElementById('SubCateFlag').checked = true;
			//}
			//else {
			//    $("[name='SubCategory.IsActive']").val(0);
			//    document.getElementById('SubCateFlag').checked = false;
			//}


		}
	});
}

function Save_Sub_Category()
{
    var activeFlg = false;
    if ($("[name='SubCategory.IsActive']").val() == 1) {
        activeFlg = true;
    }

	var sViewModel =
		{
			SubCategory: {

			    Sub_Category: $("[name='SubCategory.Sub_Category']").val(),

			    Sub_Category_Code: $("[name='SubCategory.Sub_Category_Code']").val(),

				Sub_Category_Id: $("[name='SubCategory.Sub_Category_Id']").val(),

				Category_Id: $("[name='SubCategory.Category_Id']").val(),

				IsActive: activeFlg,
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

			$("[name='SubCategory.IsActive']").val(1);

		    //Set IsActive Button Status
			var fix = $("[name='SubCategory.IsActive']").val();

			if (fix == 0) {
			    document.getElementById('SubCateFlag').checked = false;
			}
			else {
			    document.getElementById('SubCateFlag').checked = true;
			}
		}
	});


}

function Reset_Sub_Category()
{
    $("[name='SubCategory.Sub_Category']").val("");

    $("[name='SubCategory.Sub_Category_Code']").val("");

	$("[name='SubCategory.Sub_Category_Id']").val("");
	$("#hdnSub_Category").val("");//Added by vinod Mane on 26/09/2016
	$("[name='Sub_Category_List']").removeClass("active");//Added by vinod mane on 25/10/2016
}

function Get_Sub_Category_By_Id(obj)
{
	$("[name='Sub_Category_List']").removeClass("active");

	$(obj).addClass("active");

	$("[name='SubCategory.Sub_Category']").val($(obj).text());

	$("[name='SubCategory.Sub_Category_Id']").val($(obj).attr("data-identity"));

    //
	var Sub_cate_Id = $("[name='SubCategory.Sub_Category_Id']").val();

	$.ajax({

	    url: "/category/get-sub-category-by-id",

	    data: { Sub_category_Id: Sub_cate_Id },

	    type: 'POST',

	    success: function (response) {

	        var obj = $.parseJSON(response);

	        $("[name='SubCategory.Sub_Category']").val(obj.SubCategory.Category);
	        $("[name='SubCategory.Sub_Category_Code']").val(obj.SubCategory.Sub_Category_Code);

	        if (obj.SubCategory.IsActive == true) {
	            $("[name='SubCategory.IsActive']").val(1);
	            document.getElementById('SubCateFlag').checked = true;
	        }
	        else {
	            $("[name='SubCategory.IsActive']").val(0);
	            document.getElementById('SubCateFlag').checked = false;
	        }	        

	        $("#hdnSub_Category").val(obj.SubCategory.Category);//Added by Vinod Mane on 26/09/2016

	    }
	});
    //
}