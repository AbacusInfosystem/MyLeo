function Get_Vendors() {

    var vViewModel =
		{
		    Filter: {

		        Vendor_Name: $("[name='Filter.Vendor_Name']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divVendorPager"))
		    }
		}

    $.ajax({

        url: "/Vendor/Get_Vendors",

        data: JSON.stringify(vViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Vendor_List");

            Reset_Vendor();

            $("#divVendorPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

function Reset_Vendor() {

    $("[name='Vendor.Vendor_Name']").val("");

    $("[name='Vendor.Vendor_Id']").val("");
 
}