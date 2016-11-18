
function Get_Purchase_Orders() {
    var poViewModel =
		{
		    Filter: {

		        Purchase_Order_No: $("[name='Filter.Purchase_Order_No']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divPurchaseOrderPager"))
		    }
		}

    $.ajax({

        url: "/PurchaseOrder/Get_Purchase_Orders",

        data: JSON.stringify(poViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Purchase_Order_List");
            
            $("#divPurchaseOrderPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);

            Reset_PurchaseOrder();

            Friendly_Messages(obj);
        }
    });
}


function Reset_PurchaseOrder() {

    //$("[name='Filter.Purchase_Order_No']").val("");

    //$("[name='Filter.Purchase_Order_Id']").val("");

    document.getElementById("btnEditPurchaseOrder").disabled = true;
    
    document.getElementById("btnViewPurchaseOrder").disabled = true;

}




















//function Get_Purchase_Orders()
//{
//    var poViewModel =
//		{
//		    Filter: {

//		        Purchase_Order_No: $("[name='Filter.Purchase_Order_No']").val()
//		    },
//		    Grid_Detail: {

//		        CurrentPage: $("#hdfCurrent_Page").val()
//		    }
//		}

//    $.ajax({

//        url: "/PurchaseOrder/Get_Purchase_Order_List",

//        data: JSON.stringify(poViewModel),

//        dataType: 'json',

//        type: 'POST',

//        contentType: 'application/json',

//        success: function (response) {

//            var data = $.parseJSON(response);

//            Bind_Get_Purchase_Order_Data(data);
//        }
//    });
//}


//function Bind_Get_Purchase_Order_Data(data) {
//    var tblHTML = "";

//    $('#tblPurchaseOrder tbody tr').remove();

//    if (data.PurchaseOrder.PurchaseOrders.length > 0) {

//        for (var i = 0; i < data.PurchaseOrder.PurchaseOrders.length; i++) {

//            tblHTML += "<tr>";

//            tblHTML += "<td><input type='radio' name='r1' id='r1_" + data.PurchaseOrder.PurchaseOrders[i].Purchase_Order_Id + "' class='iradio-list'/></td>";

//            tblHTML += "<td>" + data.PurchaseOrder.PurchaseOrders[i].Purchase_Order_No + "</td>";
//            tblHTML += "<td>" + data.PurchaseOrder.PurchaseOrders[i].Purchase_Order_Date.substring(0, 10) + "</td>";

//            tblHTML += "<td>" + data.PurchaseOrder.PurchaseOrders[i].Vendor_Name + "</td>";
//            tblHTML += "<td>" + data.PurchaseOrder.PurchaseOrders[i].Shipping_Address + "</td>";

//            tblHTML += "<td>" + data.PurchaseOrder.PurchaseOrders[i].Total_Quantity + "</td>";
//            tblHTML += "<td>" + data.PurchaseOrder.PurchaseOrders[i].Net_Amount + "</td>";

//            tblHTML += "<td>" + data.PurchaseOrder.PurchaseOrders[i].Agent_Name + "</td>";
//            tblHTML += "<td>" + data.PurchaseOrder.PurchaseOrders[i].Transporter_Name + "</td>";

//            tblHTML += "<td>" + data.PurchaseOrder.PurchaseOrders[i].Start_Supply_Date.substring(0, 10) + "</td>";
//            tblHTML += "<td>" + data.PurchaseOrder.PurchaseOrders[i].Stop_Supply_Date.substring(0, 10) + "</td>";
            
//            tblHTML += "</tr>";

//        }

//        $('#tblPurchaseOrder tbody').append(tblHTML);

//    }

//    if (data.PurchaseOrder.PurchaseOrders.length > 0) {
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
//            $("#hdnPurchaseOrderId").val(this.id.replace("r1_", ""));
//            document.getElementById("btnCreatePurchaseOrder").disabled = true;
//            document.getElementById("btnEditPurchaseOrder").disabled = false;
//            document.getElementById("btnViewPurchaseOrder").disabled = false;
//        }
//    });

//    Friendly_Messages(data);
//}















