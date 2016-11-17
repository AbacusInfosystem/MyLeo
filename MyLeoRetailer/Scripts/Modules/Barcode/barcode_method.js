

function Get_Employees() {
    var eViewModel =
		{
		    Filter: {

		        Employee: $("[name='Filter.Employee']").val()
		    },
		    Grid_Detail: {

		        Pager: Set_Pager($("#divEmployeePager"))
		    }
		}

    $.ajax({

        url: "/Employee/Get_Employees",

        data: JSON.stringify(eViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
            var obj = $.parseJSON(response);

            Bind_Grid(obj, "Employee_List");
             
            $("#divEmployeePager").html(obj.Grid_Detail['Pager']['PageHtmlString']);
        }
    });
}

function Bind_Payable_Grid_Items(data) {

    ClearPayableData();

    $("#tblPayableItems").html("");

    var htmlText = "";

    $("#hdnPayable_Item_Id").val(data.Payable.Payable_Item_Id),

    $("#hdnPayable_Id").val(data.Payable.Payable_Id),

    $("#hdnPurchase_Invoice_Id").val(data.Payable.Purchase_Invoice_Id),

    $("#txtTotal_Amount").val(data.Payable.Total_Amount),

    $("#txtAmount_due").val(data.Payable.Balance_Amount);

    $("#txtFinal_amount").val(data.Payable.Balance_Amount);

    if (data.Payables.length > 0) {

        htmlText += "<tr>";

        htmlText += "<th>Payment mode</th>";

        htmlText += "<th>Paid Amount</th>";

        htmlText += "<th>Vendor Employee Name</th>";

        htmlText += "<th>Credit Card no</th>";

        htmlText += "<th>Debit Card no</th>";

        htmlText += "<th>Cheque No</th>";

        htmlText += "<th>Cheque Date</th>";

        htmlText += "<th>Bank Name</th>";

        htmlText += "<th>Credit note no</th>";

        htmlText += "<th>Credit note amount</th>";

        htmlText += "<th>Discount %</th>";

        htmlText += "<th>Discount amount</th>";

    }

    htmlText += "</tr>";

    for (i = 0; i < data.Payables.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Payment_Mode1 == null ? "" : data.Payables[i].Payment_Mode1;

        htmlText += "<input type='hidden' id='hdnPayment_Mode" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Payment_Mode + "'/>";

        htmlText += "<input type='hidden' id='hdnPaid_Amount" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Paid_Amount + "'/>";

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Paid_Amount == null ? "" : data.Payables[i].Paid_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Vendor_Employee_Name == null ? "NA" : data.Payables[i].Vendor_Employee_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Credit_Card_No == null ? "" : data.Payables[i].Credit_Card_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Debit_Card_No == null ? "" : data.Payables[i].Debit_Card_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Cheque_No == null ? "" : data.Payables[i].Cheque_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Cheque_Date == "1999-01-01" ? "NA" : data.Payables[i].Cheque_Date.substring(0, 10);

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Bank_Name == null ? "" : data.Payables[i].Bank_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Credit_Note_No == null ? "NA" : data.Payables[i].Credit_Note_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Credit_Note_Amount == 0 ? "NA" : data.Payables[i].Credit_Note_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Discount_Percentage == 0 ? "NA" : data.Payables[i].Discount_Percentage;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Discount_Amount == 0 ? "NA" : data.Payables[i].Discount_Amount;

        htmlText += "</td>";

        htmlText += "</tr>";
    }


    $('#tblPayableItems').html(htmlText);
}


