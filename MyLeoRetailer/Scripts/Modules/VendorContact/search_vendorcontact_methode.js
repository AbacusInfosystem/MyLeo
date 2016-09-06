

function Get_Vendor_Contacts() {
    var vcViewModel =
		{
		    Filter: {

		        Vendor_Contact_Name: $("[name='Filter.Vendor_Contact_Name']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divVendorContactPager"))
		    }
		}

    $.ajax({

        url: "/VendorContact/Get_Vendor_Contacts",

        data: JSON.stringify(vcViewModel),// data we are sending to server

        dataType: 'json',  //WHAT WE ARE EXPECTING

        type: 'POST',

        contentType: 'application/json', //WHAT WE ARE SENDING

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Vendor_Contact_List");

           // Reset_Vendor_Contact();

            $("#divVendorContactPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

function Get_Vendor_Contact_By_Id(obj) {
    $("[name='Vendor_Contact_List']").removeClass("active");

    $(obj).addClass("active");

    $("[name='VendorContact.Vendor_Contact_Name']").val($(obj).text());

    $("[name='VendorContact.Vendor_Id']").val($(obj).text());

    $("[name='VendorContact.Address']").val($(obj).text());

    $("[name='VendorContact.City']").val($(obj).text());

    $("[name='VendorContact.State']").val($(obj).text());

    $("[name='VendorContact.Country']").val($(obj).text());

    $("[name='VendorContact.Pincode']").val($(obj).text());

    $("[name='VendorContact.Mobile1']").val($(obj).text());

    $("[name='VendorContact.Mobile2']").val($(obj).text());

    $("[name='VendorContact.Email_Id']").val($(obj).text());

    $("[name='VendorContact.IsActive']").val($(obj).text());

    $("[name='VendorContact.VendorContact_Id']").val($(obj).attr("data-identity"));

    $("#hdnVendorContact_Id").val($(obj).attr("data-identity"));
}
