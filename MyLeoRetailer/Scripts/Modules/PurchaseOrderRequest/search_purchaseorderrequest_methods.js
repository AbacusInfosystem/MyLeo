function Get_Purchase_Order_Requests() {
    var poreqViewModel =
		{
		    Filter: {

		        Vendor_Id: $("#drpVendor_Id").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divPurchaseOrderRequestPager"))
		    }
		}

    $.ajax({

        url: "/PurchaseOrderRequest/Get_Purchase_Order_Requests",

        data: JSON.stringify(poreqViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Purchase_Order_Request_List");

            Reset_PurchaseOrderRequest();

            $("#divPurchaseOrderRequestPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Friendly_Messages(obj);
        }
    });
}

function Reset_PurchaseOrderRequest() {
    $("[name='Filter.Vendor_Id']").val("");

    $("[name='Filter.Purchase_Order_Request_Id']").val("");

    document.getElementById("btnEditPurchaseOrderRequest").disabled = true;
}






//function Get_Purchase_Order_Requests() {
//    var poreqViewModel =
//        {
//            Filter: {

//                Vendor_Id: $("#drpVendor_Id").val()
//            },
//            Grid_Detail: {

//                CurrentPage: $("#hdfCurrent_Page").val()
//            }
//        }

//    $.ajax({

//        url: "/PurchaseOrderRequest/Get_Purchase_Order_Request_List",

//        data: JSON.stringify(poreqViewModel),

//        dataType: 'json',

//        type: 'POST',

//        contentType: 'application/json',

//        success: function (response) {

//            var data = $.parseJSON(response);

//            Bind_Get_Purchase_Order_Request_Data(data);

           

//        }
//    });
//}

//function Bind_Get_Purchase_Order_Request_Data(data) {
//    var tblHTML = "";

//    $('#tblPurchaseOrderRequest tbody tr').remove();

//    if (data.PurchaseOrderRequest.PurchaseOrderRequests.length > 0) {

//        for (var i = 0; i < data.PurchaseOrderRequest.PurchaseOrderRequests.length; i++) {

//            tblHTML += "<tr>";

//            tblHTML += "<td><input type='radio' name='r1' id='r1_" + data.PurchaseOrderRequest.PurchaseOrderRequests[i].Purchase_Order_Request_Id + "' class='iradio-list'/></td>";

//            tblHTML += "<td>" + data.PurchaseOrderRequest.PurchaseOrderRequests[i].Branch_Name + "</td>";
//            tblHTML += "<td>" + data.PurchaseOrderRequest.PurchaseOrderRequests[i].Vendor_Name + "</td>";

//            tblHTML += "<td>" + data.PurchaseOrderRequest.PurchaseOrderRequests[i].Total_Quantity + "</td>";
//            tblHTML += "<td>" + data.PurchaseOrderRequest.PurchaseOrderRequests[i].Net_Amount + "</td>";

//            tblHTML += "</tr>";

//        }

//        $('#tblPurchaseOrderRequest tbody').append(tblHTML);

//    }

//    if (data.PurchaseOrderRequest.PurchaseOrderRequests.length > 0) {
//        $('#hdfCurrent_Page').val(data.Pager.CurrentPage);

//        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

//            $('.pagination').html(data.Pager.PageHtmlString);
//        }
//    }
//    else {
//        $('.pagination').html("");
//    }


//    $('[name="r1"]').on('change', function (event) {
//        if ($(this).prop('checked')) {
//            $("#hdnPurchaseOrderRequestId").val(this.id.replace("r1_", ""));
//            document.getElementById("btnEditPurchaseOrderRequest").disabled = false;
//            document.getElementById("btnCreatePurchaseOrderRequest").disabled = true;
//        }
//    });

//    Friendly_Messages(data);
//}

































