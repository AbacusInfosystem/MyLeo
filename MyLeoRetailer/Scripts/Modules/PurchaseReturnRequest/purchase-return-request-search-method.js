﻿function Get_Purchase_Return_Requests()
{
    var prViewModel =
		{
		    Filter: {

		        Vendor_Id: $("#drpVendor_Id").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divPurchaseReturnRequestPager")),
		    }
		}

    $.ajax({

        url: "/purchase-return-request/seatch-purchase-return-request",

        data: JSON.stringify(prViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
           
            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Purchase_Return_Request_List");

            Reset_PurchaseReturnRequest();

            $("#divPurchaseReturnRequestPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
            
            Friendly_Messages(obj);
            
        }
    });
}

function Reset_PurchaseReturnRequest() {

    $("[name='Filter.Vendor_Id']").val("");

    $("[name='Filter.Purchase_Return_Request_Id']").val("");

    document.getElementById('btnView').disabled = true;

}


















//function Get_Purchase_Return_Requests()
//{
//    var prViewModel =
//		{
//		    Filter: {

//		        Vendor_Id: $("#drpVendor_Id").val()
//		    },
//		    pager: {

//		        CurrentPage: $("#hdfCurrent_Page").val(),
//		    }
//		}

//    $.ajax({

//        url: "/purchase-return-request/seatch-purchase-return-request",

//        data: JSON.stringify(prViewModel),

//        dataType: 'json',

//        type: 'POST',

//        contentType: 'application/json',

//        success: function (response) {
           
//            var data = $.parseJSON(response);
            
//            Bind_Get_Purchase_Return_Requests_Data(data);
            
//        }
//    });
//}

//function Bind_Get_Purchase_Return_Requests_Data(data)
//{
//    var tblHTML = "";

//    $('#tblPurchaseReturnRequest tbody tr').remove();

//    if (data.PurchaseReturnRequests.length > 0) {

//        for (var i = 0; i < data.PurchaseReturnRequests.length; i++) {

//            tblHTML += "<tr>";

//            tblHTML += "<td>" + data.PurchaseReturnRequests[i].Vendor_Name + "</td>";
//            tblHTML += "<td>" + data.PurchaseReturnRequests[i].Purchase_Invoice_No + "</td>";
//            tblHTML += "<td>" + data.PurchaseReturnRequests[i].Branch_Name + "</td>";
//            tblHTML += "<td>" + data.PurchaseReturnRequests[i].Total_Quantity + "</td>";
//            tblHTML += "<td>" + data.PurchaseReturnRequests[i].Total_Amount + "</td>";
//            tblHTML += "<td>";
//            tblHTML += data.PurchaseReturnRequests[i].Status == true ? "Pending Request" : "Done";
//            tblHTML += "</td>";

//            tblHTML += "</tr>";
           
//        }

//        $('#tblPurchaseReturnRequest tbody').append(tblHTML);

//    }

//    if (data.PurchaseReturnRequests.length > 0) {
//        $('#hdfCurrent_Page').val(data.Pager.CurrentPage);

//        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

//            $('.pagination').html(data.Pager.PageHtmlString);
//        }
//    }
//    else {
//        $('.pagination').html("");
//    }

//    Friendly_Messages(data); 
//}
