

function Get_Receivables(Sales_Invoice_Id, Sales_Credit_Note_Id) {

    $("#hdf_Sales_Invoice_Id").val(Sales_Invoice_Id);

    $("#hdf_Sales_Credit_Note_Id").val(Sales_Credit_Note_Id);

    //$("#hdf_Gift_Voucher_Id").val(Gift_Voucher_Id);

    $("#frmReceivable").attr("action", "/Receivable/Get_Receivable_Details_By_Id");
    $("#frmReceivable").submit();
}

function Get_Credit_Note_Amount_By_Id(id) {


    var rViewModel =
        {
            Receivable: {

                Sales_Credit_Note_Id: id
            }
        }

    $.ajax({

        url: "/Receivable/Get_Credit_Note_Amount_By_Id",

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("[name='Receivable.Credit_Note_Amount']").val(obj.Receivable.Credit_Note_Amount);

        }
    });
}

function Get_Gift_Voucher_Amount_By_Id(id) {


    var rViewModel =
        {
            Receivable: {

                Gift_Voucher_Id: id
            }
        }

    $.ajax({

        url: "/Receivable/Get_Gift_Voucher_Amount_By_Id",

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("[name='Receivable.Gift_Voucher_Amount']").val(obj.Receivable.Gift_Voucher_Amount);

        }
    });
}

function CalculateDiscount() {

    debugger;


    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

    var chequeamount = parseFloat($("#txtCheque_Amount").val());

    var cashamount = parseFloat($("#txtCash_amount").val());

    var creditnoteamount = parseFloat($("#txtCredit_Note_Amount").val());

    var giftvoucheramount = parseFloat($("#txtGift_Voucher_Amount").val());

    var cardamount = parseFloat($("#txtCard_Amount").val());

    var paidamount = chequeamount + cashamount + creditnoteamount + giftvoucheramount + cardamount;

    $("#txtPaid_Amount").val(paidamount.toFixed(2));

    var newbalanceamount = oldbalanceamount - paidamount;

    $("#txtBalance_Amount").val(newbalanceamount.toFixed(2));

    

}

function Save_Receivable_Data() {
    var rViewModel =
		{
		    Receivable: {



		        Receivable_Item_Id: $("[name='Receivable.Receivable_Item_Id']").val(),

		        Receivable_Id: $("[name='Receivable.Receivable_Id']").val(),

		        Sales_Credit_Note_Id: $("[name='Receivable.Sales_Credit_Note_Id']").val(),

		        Sales_Invoice_Id: $("[name='Receivable.Sales_Invoice_Id']").val(),

		        Payament_Date: $("[name='Receivable.Payament_Date']").val(),

		        Balance_Amount: $("[name='Receivable.Balance_Amount']").val(),

		        Gift_Voucher_No: $("[name='Receivable.Gift_Voucher_No']").val(),

		        Paid_Amount: $("[name='Receivable.Paid_Amount']").val(),

		        Cash_Amount: $("[name='Receivable.Cash_Amount']").val(),

		        Cheque_Amount: $("[name='Receivable.Cheque_Amount']").val(),

		        Card_Amount: $("[name='Receivable.Card_Amount']").val(),

		        Gift_Voucher_Amount: $("[name='Receivable.Gift_Voucher_Amount']").val(),

		        Cheque_Date: $("[name='Receivable.Cheque_Date']").val(),

		        Cheque_No: $("[name='Receivable.Cheque_No']").val(),

		        Bank_Name: $("[name='Receivable.Bank_Name']").val(),

		        Credit_Card_No: $("[name='Receivable.Credit_Card_No']").val(),
		    }
		}

    var url = "";


    if ($("[name='Receivable.Receivable_Item_Id']").val() == "" || $("[name='Receivable.Receivable_Item_Id']").val() == 0) {

        url = "/Receivable/Insert_Receivable";
    }
    else {
        url = "/Receivable/Update_Receivable";
    }

    //alert(Receivable_Item_Id);

    $.ajax({

        url: url,

        data: JSON.stringify(rViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {
            debugger;

            var obj = $.parseJSON(response);

            Bind_Payable_Grid_Items(obj);

            //Reset_Brand();

            //Get_Brands();

            //Friendly_Messages(obj);

        }
    });

}

function Bind_Payable_Grid_Items(data) {

    $("#tblReceivableItems").html("");

    var htmlText = "";

    //$("#txtPurchase_Order_No").val(data.Payable.Purchase_Order_Id),

    $("#hdnReceivable_Item_Id").val(data.Receivable.Receivable_Item_Id),

    $("#hdnReceivable_Id").val(data.Receivable.Receivable_Id),

    $("#hdnSales_Invoice_Id").val(data.Receivable.Sales_Invoice_Id),

    $("#txtTotal_MRP_Amount").val(data.Receivable.Total_MRP_Amount),

    $("#txtBalance_Amount").val(data.Receivable.Balance_Amount);

    //$("#dvPurchase_Order").find(".autocomplete-text").trigger("focusout");

    if (data.Receivables.length > 0) {

        htmlText += "<tr>";

        htmlText += "<th>Paid Amount</th>";

        htmlText += "<th>Cash Amount</th>";

        htmlText += "<th>Cheque Amount</th>";

        htmlText += "<th>Cheque No</th>";

        htmlText += "<th>Cheque Date</th>";

        htmlText += "<th>Bank Name</th>";

        htmlText += "<th>Credit note no</th>";

        htmlText += "<th>Credit note amount</th>";

        htmlText += "<th>Card no</th>";

        htmlText += "<th>Card amount</th>";

        htmlText += "<th>Gift voucher no</th>";

        htmlText += "<th>Gift voucher amount</th>";

      

    }

    htmlText += "</tr>";

    for (i = 0; i < data.Receivables.length; i++) {

        var showChequeDate = new Date(parseInt(data.Receivables[i].Cheque_Date.replace('/Date(', '')));

        showChequeDate = (showChequeDate.getMonth() + 1).toString() + "/" + (showChequeDate.getDate().toString() + "/" + showChequeDate.getFullYear());

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Paid_Amount == null ? "" : data.Receivables[i].Paid_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cash_Amount == null ? "" : data.Receivables[i].Cash_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cheque_Amount == null ? "" : data.Receivables[i].Cheque_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cheque_No == null ? "" : data.Receivables[i].Cheque_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += showChequeDate

        htmlText += showChequeDate == "1/1/1999" ? "NA" : showChequeDate;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Bank_Name == null ? "" : data.Receivables[i].Bank_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Note_No == null ? "" : data.Receivables[i].Credit_Note_No;

        htmlText += "<td>";


        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Note_Amount == null ? "" : data.Receivables[i].Credit_Note_Amount;

        htmlText += "<td>";


        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Card_No == null ? "" : data.Receivables[i].Credit_Card_No;

        htmlText += "<td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Card_Amount == null ? "" : data.Receivables[i].Card_Amount;

        htmlText += "<td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Gift_Voucher_No == null ? "" : data.Receivables[i].Gift_Voucher_No;

        htmlText += "<td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Gift_Voucher_Amount == null ? "" : data.Receivables[i].Gift_Voucher_Amount;

        htmlText += "<td>";

        //htmlText += showPayableDate == null ? "" : showPayableDate;

        htmlText += "<input type='hidden' id='hdnPaid_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Paid_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCash_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cash_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cheque_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cheque_No + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_Date" + data.Receivables[i].Receivable_Item_Id + "' value='" + showChequeDate + "'/>";

        htmlText += "<input type='hidden' id='hdnBank_Name" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Bank_Name + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Note_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Credit_Note_No + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Note_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Credit_Note_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Card_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Credit_Card_No + "'/>";

        htmlText += "<input type='hidden' id='hdnCard_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Card_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnGift_Voucher_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Gift_Voucher_No + "'/>";

        htmlText += "<input type='text' id='hdnGift_Voucher_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Gift_Voucher_Amount + "'/>";

        htmlText += "<input type='text' id='hdnReceivable_Item_Id" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Receivable_Item_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnReceivable_Id" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Receivable_Id + "'/>";

        htmlText += "</td>";

        //if (data.Payable.Status != "Payment Done") {
        htmlText += "<td>";


        htmlText += "<button type='button' id='edit-Payable-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditReceivableData(" + data.Receivables[i].Receivable_Item_Id + ")'><i class='fa fa-pencil' ></i></button>";

        //htmlText += "<button type='button' id='delete-Payable-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeletPayableData(" + data.Receivables[i].Receivable_Item_Id + ")'><i class='fa fa-times' ></i></button>";

        htmlText += "</td>";
        //}

        htmlText += "</tr>";
    }
    //}
    //else {
    //    htmlText += "<tr>";

    //    htmlText += "<td colspan='3'> No Record found.";

    //    htmlText += "</td>";

    //    htmlText += "</tr>";
    // }


    $('#tblPayableItems').html(htmlText);

    //Friendly_Message(data);

    //ClearReceivableData();


}


function EditReceivableData(id) {

    var Total_Bal = 0;
    var Balance_amount = 0;
    var Item_amount = 0;

    var Previous_Item_Amount = $("#hdnPaid_Amount").val();

    $("#drpPayment_Mode").val($("#hdnPayment_Mode" + id).val());

    $("#txtPaid_Amount").val($("#hdnPaid_Amount" + id).val());

    //$('#drpPayment_Mode').trigger('change');

    // $("#txtPayable_Item_Amount").val($("#hdnPayable_Item_Amount" + id).val());

    //$("#txtPayDate").val($("#hdnPayable_Date" + id).val());

    $("#txtCredit_card_no").val($("#hdnCredit_Card_No" + id).val());

    $("#txtDebit_card_no").val($("#hdnDebit_Card_No" + id).val());

    $("#txtCheque_no").val($("#hdnCheque_No" + id).val());

    $("#txtBank_Name").val($("#hdnBank_Name" + id).val());

    $("#hdnPayable_Item_Id").val($("#hdnPayable_Item_Id" + id).val());

    $("#hdnPayable_Id").val($("#hdnPayable_Id" + id).val());

    //$("#txtCredit_note_no").val($("#hdnCredit_Note_No" + id).val());

    //$("#txtGift_voucher_no").val($("#hdnGift_Voucher_No" + id).val());

    Balance_amount = $("#txtAmount_due").val();
    Item_amount = $("#hdnPaid_Amount" + id).val();

    Total_Bal = parseFloat(Balance_amount) + parseFloat(Item_amount);

    Total_Bal = parseFloat(Total_Bal) - parseFloat(Previous_Item_Amount);

    $("#txtBalance_Amount").val(Total_Bal);

    $("#hdnPaid_Amount").val(Item_amount);

}



