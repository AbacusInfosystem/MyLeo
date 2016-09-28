function Get_Purchase_Returns() {
        var prViewModel =
    		{
    		    Filter: {

    		        Debit_Note_No: $("[name='Filter.Debit_Note_No']").val()
    		    },
    		    Grid_Detail: {

    		        CurrentPage: $("#hdfCurrent_Page").val()
    		    }
    		}

        $.ajax({

            url: "/PurchaseReturn/Get_Purchase_Returns",

            data: JSON.stringify(prViewModel),

            dataType: 'json',

            type: 'POST',

            contentType: 'application/json',

            success: function (response) {
                               
            var data = $.parseJSON(response);

            Bind_Get_Purchase_Return_Data(data);

        }
    });
}

function Bind_Get_Purchase_Return_Data(data) {
    var tblHTML = "";

    $('#tblPurchaseReturn tbody tr').remove();

    if (data.PurchaseReturn.PurchaseReturns.length > 0) {

        for (var i = 0; i < data.PurchaseReturn.PurchaseReturns.length; i++) {

            tblHTML += "<tr>";

            tblHTML += "<td>" + data.PurchaseReturn.PurchaseReturns[i].Debit_Note_No + "</td>";
            tblHTML += "<td>" + data.PurchaseReturn.PurchaseReturns[i].GR_No + "</td>";

            tblHTML += "<td>" + data.PurchaseReturn.PurchaseReturns[i].Vendor_Name + "</td>";
            tblHTML += "<td>" + data.PurchaseReturn.PurchaseReturns[i].Purchase_Invoice_No + "</td>";

            tblHTML += "<td>" + data.PurchaseReturn.PurchaseReturns[i].Total_Quantity + "</td>";
            tblHTML += "<td>" + data.PurchaseReturn.PurchaseReturns[i].Total_Amount + "</td>";

            tblHTML += "<td>" + data.PurchaseReturn.PurchaseReturns[i].Transporter_Name + "</td>";
            tblHTML += "<td>" + data.PurchaseReturn.PurchaseReturns[i].Logistics_Person_Name + "</td>";
            tblHTML += "<td>" + data.PurchaseReturn.PurchaseReturns[i].Lr_No + "</td>";
            tblHTML += "<td>" + data.PurchaseReturn.PurchaseReturns[i].Purchase_Return_Date.substring(0, 10) + "</td>";

            tblHTML += "</tr>";

        }

        $('#tblPurchaseReturn tbody').append(tblHTML);

    }

    if (data.PurchaseReturn.PurchaseReturns.length > 0) {
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

//function Get_Purchase_Returns() {
//    var prViewModel =
//		{
//		    Filter: {

//		        Debit_Note_No: $("[name='Filter.Debit_Note_No']").val()
//		    },
//		    Grid_Detail: {

//		        Pager: Set_Pager($("#divPurchaseReturnPager"))
//		    }
//		}

//    $.ajax({

//        url: "/PurchaseReturn/Get_Purchase_Returns",

//        data: JSON.stringify(prViewModel),

//        dataType: 'json',

//        type: 'POST',

//        contentType: 'application/json',

//        success: function (response) {

//            var obj = $.parseJSON(response);

//            Bind_Grid(obj, "Purchase_Return_List");

//            $("#divPurchaseReturnPager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
//        }
//    });
//}