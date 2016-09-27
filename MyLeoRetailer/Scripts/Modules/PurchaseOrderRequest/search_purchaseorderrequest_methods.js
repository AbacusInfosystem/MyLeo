function Get_Purchase_Order_Requests() {
    var poreqViewModel =
        {
            Filter: {

                Vendor_Id: $("#drpVendor_Id").val()
            },
            Grid_Detail: {

                CurrentPage: $("#hdfCurrent_Page").val()
            }
        }

    $.ajax({

        url: "/PurchaseOrderRequest/Get_Purchase_Order_Requests",

        data: JSON.stringify(poreqViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var data = $.parseJSON(response);

            Bind_Get_Purchase_Order_Request_Data(data);

        }
    });
}

function Bind_Get_Purchase_Order_Request_Data(data) {
    var tblHTML = "";

    $('#tblPurchaseOrderRequest tbody tr').remove();

    if (data.PurchaseOrderRequest.PurchaseOrderRequests.length > 0) {

        for (var i = 0; i < data.PurchaseOrderRequest.PurchaseOrderRequests.length; i++) {

            tblHTML += "<tr>";

            tblHTML += "<td>" + data.PurchaseOrderRequest.PurchaseOrderRequests[i].Branch_Name + "</td>";
            tblHTML += "<td>" + data.PurchaseOrderRequest.PurchaseOrderRequests[i].Vendor_Name + "</td>";

            tblHTML += "<td>" + data.PurchaseOrderRequest.PurchaseOrderRequests[i].Status + "</td>";

            tblHTML += "<td>" + data.PurchaseOrderRequest.PurchaseOrderRequests[i].Total_Quantity + "</td>";
            tblHTML += "<td>" + data.PurchaseOrderRequest.PurchaseOrderRequests[i].Net_Amount + "</td>";

            tblHTML += "</tr>";

        }

        $('#tblPurchaseOrderRequest tbody').append(tblHTML);

    }

    if (data.PurchaseOrderRequest.PurchaseOrderRequests.length > 0) {
        $('#hdfCurrent_Page').val(data.Pager.CurrentPage);

        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else {
        $('.pagination').html("");
    }

    Friendly_Messages(data);
}

































//function Get_Purchase_Order_Requests() {
//    var poreqViewModel =
//		{
//		    Filter: {

//		        Vendor_Id: $("[name='Filter.Vendor_Id']").val()
//		    },
//		    Grid_Detail: {

//		        Pager: Set_Pager($("#divPurchaseOrderRequestPager"))
//		    }
//		}

//    $.ajax({

//        url: "/PurchaseOrderRequest/Get_Purchase_Order_Requests",

//        data: JSON.stringify(poreqViewModel),

//        dataType: 'json',

//        type: 'POST',

//        contentType: 'application/json',

//        success: function (response) {

//            var obj = $.parseJSON(response);

//            Bind_Grid(obj, "Purchase_Order_Request_List");

//            $("#divPurchaseOrderRequestPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
//        }
//    });
//}

//function Set_Vendor_Id(value)
//{
//    $("[name='Filter.Vendor_Id']").val(value);

//    Get_Purchase_Order_Requests();
//}