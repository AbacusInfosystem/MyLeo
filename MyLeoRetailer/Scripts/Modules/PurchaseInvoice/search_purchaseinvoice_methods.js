function Get_Purchase_Invoices() {
    var piViewModel =
		{
		    Filter: {

		        Purchase_Invoice_No: $("[name='Filter.Purchase_Invoice_No']").val()
		    },
		    Grid_Detail: {

		        CurrentPage: $("#hdfCurrent_Page").val()
		    }
		}

    $.ajax({

        url: "/PurchaseInvoice/Get_Purchase_Invoices",

        data: JSON.stringify(piViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var data = $.parseJSON(response);

            Bind_Get_Purchase_Invoice_Data(data);

        }
    });
}

    function Bind_Get_Purchase_Invoice_Data(data) {
        var tblHTML = "";

        $('#tblPurchaseInvoice tbody tr').remove();

        if (data.PurchaseInvoice.PurchaseInvoices.length > 0) {

            for (var i = 0; i < data.PurchaseInvoice.PurchaseInvoices.length; i++) {

                tblHTML += "<tr>";

                tblHTML += "<td>" + data.PurchaseInvoice.PurchaseInvoices[i].Purchase_Invoice_No + "</td>";
                tblHTML += "<td>" + data.PurchaseInvoice.PurchaseInvoices[i].Challan_No + "</td>";

                tblHTML += "<td>" + data.PurchaseInvoice.PurchaseInvoices[i].Purchase_Invoice_Date.substring(0, 10) + "</td>";
                tblHTML += "<td>" + data.PurchaseInvoice.PurchaseInvoices[i].Vendor_Name + "</td>";

                tblHTML += "<td>" + data.PurchaseInvoice.PurchaseInvoices[i].Total_Quantity + "</td>";
                tblHTML += "<td>" + data.PurchaseInvoice.PurchaseInvoices[i].Net_Amount + "</td>";

                tblHTML += "<td>" + data.PurchaseInvoice.PurchaseInvoices[i].Transporter_Name + "</td>";
                tblHTML += "<td>" + data.PurchaseInvoice.PurchaseInvoices[i].Lr_No + "</td>";

                tblHTML += "</tr>";

            }

            $('#tblPurchaseInvoice tbody').append(tblHTML);

        }

        if (data.PurchaseInvoice.PurchaseInvoices.length > 0) {
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






































//function Get_Purchase_Invoices() {
//    var poViewModel =
//		{
//		    Filter: {

//		        Purchase_Invoice_No: $("[name='Filter.Purchase_Invoice_No']").val()
//		    },
//		    Grid_Detail: {

//		        Pager: Set_Pager($("#divPurchaseInvoicePager"))
//		    }
//		}

//    $.ajax({

//        url: "/PurchaseInvoice/Get_Purchase_Invoices",

//        data: JSON.stringify(poViewModel),

//        dataType: 'json',

//        type: 'POST',

//        contentType: 'application/json',

//        success: function (response) {

//            var obj = $.parseJSON(response);

//            Bind_Grid(obj, "Purchase_Invoice_List");

//            $("#divPurchaseInvoicePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
//        }
//    });
//}