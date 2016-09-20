
function Get_Payable(Purchase_Invoice_Id, Purchase_Credit_Note_Id) {

  

    $("#hdf_Purchase_Invoice_Id").val(Purchase_Invoice_Id);

    $("#hdf_Purchase_Credit_Note_Id").val(Purchase_Credit_Note_Id);
   
    $("#frmPayable").attr("action", "/Payable/Get_Payable_Details_By_Id");
    $("#frmPayable").submit();
}

function Get_Credit_Note_Amount_By_Id(id) {


    var pViewModel =
        {
            Payable: {

                Purchase_Credit_Note_Id: id
            }
        }

    $.ajax({

        url: "/Payable/Get_Credit_Note_Amount_By_Id",

        data: JSON.stringify(pViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("[name='Payable.Credit_Note_Amount']").val(obj.Payable.Credit_Note_Amount);

        }
    });
}

function CalculateDiscount() {
   
    debugger;

    
    var Amountdue = parseFloat($("#txtAmount_due").val());

    var CNamount = parseFloat($("#txtCN_amount").val());
    
    var abcamount = Amountdue - CNamount;

    var discount = parseFloat($("#txtDiscount").val());

    var discountAmt = (discount == "" || discount == undefined) ? 0 : parseFloat((abcamount * discount) / 100);

    $("#txtDiscount_amount").val(discountAmt.toFixed(2));

    var finalamount = abcamount - discountAmt;

    $("#txtFinal_amount").val(finalamount.toFixed(2));

}

function Save_Payable_Data() {
    var pViewModel =
		{
		    Payable: {

		        

		        Payable_Item_Id: $("[name='Payable.Payable_Item_Id']").val(),

		        Payable_Id: $("[name='Payable.Payable_Id']").val(),

		        Purchase_Credit_Note_Id: $("[name='Payable.Purchase_Credit_Note_Id']").val(),

		        Purchase_Invoice_Id: $("[name='Payable.Purchase_Invoice_Id']").val(),

		        Payment_Mode: $("[name='Payable.Payment_Mode']").val(),

		        Paid_Amount: $("[name='Payable.Paid_Amount']").val(),

		        Discount_Amount: $("[name='Payable.Discount_Amount']").val(),

		        Discount_Percentage: $("[name='Payable.Discount_Percentage']").val(),

		        Payament_Date: $("[name='Payable.Payament_Date']").val(),

		        Final_Amount: $("[name='Payable.Final_Amount']").val(),

		        Total_Amount: $("[name='Payable.Total_Amount']").val(),

		        Cheque_Date: $("[name='Payable.Cheque_Date']").val(),

		        Cheque_No: $("[name='Payable.Cheque_No']").val(),

		        Bank_Name: $("[name='Payable.Bank_Name']").val(),

                Person_Name: $("[name='Payable.Person_Name']").val(),

		        Remark: $("[name='Payable.Remark']").val(),

		        //Credit_Note_No: $("[name='Payable.Credit_Note_No']").val(),

		        Credit_Card_No: $("[name='Payable.Credit_Card_No']").val(),

		        Debit_Card_No: $("[name='Payable.Debit_Card_No']").val(),

		        //Gift_Voucher_No: $("[name='Payable.Gift_Voucher_No']").val(),
		    }
		}

    var url = "";


          if ($("[name='Payable.Payable_Item_Id']").val() == "" || $("[name='Payable.Payable_Item_Id']").val() == 0) {

              url = "/Payable/Insert_Payable";
            }
            else {
              url = "/Payable/Update_Payable";
            }

    //alert(Payable_Item_Id);

    $.ajax({

        url: url,

        data: JSON.stringify(pViewModel),

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

    $("#tblPayableItems").html("");

    var htmlText = "";

    //$("#txtPurchase_Order_No").val(data.Payable.Purchase_Order_Id),

    $("#hdnPayable_Item_Id").val(data.Payable.Payable_Item_Id),

    $("#hdnPayable_Id").val(data.Payable.Payable_Id),

    $("#hdnPurchase_Invoice_Id").val(data.Payable.Purchase_Invoice_Id),

    $("#txtTotal_Amount").val(data.Payable.Total_Amount),

    $("#txtAmount_due").val(data.Payable.Balance_Amount);

    //$("#dvPurchase_Order").find(".autocomplete-text").trigger("focusout");

    if (data.Payables.length > 0) {

        htmlText += "<tr>";

        htmlText += "<th>Payment mode</th>";

        htmlText += "<th>Paid Amount</th>";

        htmlText += "<th>Credit Card no</th>";

        htmlText += "<th>Debit Card no</th>";

        htmlText += "<th>Cheque No</th>";

        htmlText += "<th>Cheque Date</th>";

        htmlText += "<th>Bank Name</th>";


    }

    htmlText += "</tr>";

    for (i = 0; i < data.Payables.length; i++) {

        //var showPayableDate = new Date(parseInt(data.Payables[i].Payable_Date.replace('/Date(', '')));

        //showPayableDate = (showPayableDate.getMonth() + 1).toString() + "/" + (showPayableDate.getDate().toString() + "/" + showPayableDate.getFullYear());

        var showChequeDate = new Date(parseInt(data.Payables[i].Cheque_Date.replace('/Date(', '')));

        showChequeDate = (showChequeDate.getMonth() + 1).toString() + "/" + (showChequeDate.getDate().toString() + "/" + showChequeDate.getFullYear());

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Payment_Mode == null ? "" : data.Payables[i].Payment_Mode;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Paid_Amount == null ? "" : data.Payables[i].Paid_Amount;

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

        htmlText += showChequeDate

        htmlText += showChequeDate == "1/1/1999" ? "NA" : showChequeDate;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Payables[i].Bank_Name == null ? "" : data.Payables[i].Bank_Name;

        htmlText += "<td>";

        //htmlText += showPayableDate == null ? "" : showPayableDate;

        htmlText += "<input type='hidden' id='hdnPayment_Mode" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Payment_Mode + "'/>";

        htmlText += "<input type='hidden' id='hdnPaid_Amount" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Paid_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Card_No" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Credit_Card_No + "'/>";

        htmlText += "<input type='hidden' id='hdnDebit_Card_No" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Debit_Card_No + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_No" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Cheque_No + "'/>";

        htmlText += "<input type='hidden' id='hdnBank_Name" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Bank_Name + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_Date" + data.Payables[i].Payable_Item_Id + "' value='" + showChequeDate + "'/>";

        htmlText += "<input type='text' id='hdnPayable_Item_Id" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Payable_Item_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnPayable_Id" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Payable_Id + "'/>";

        //htmlText += "<input type='hidden' id='hdnCredit_Note_No" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Credit_Note_No + "'/>";

        //htmlText += "<input type='hidden' id='hdnGift_Voucher_No" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Gift_Voucher_No + "'/>";

        //htmlText += "<input type='hidden' id='hdnPayable_Date" + data.Payables[i].Payable_Item_Id + "' value='" + showPayableDate + "'/>";

        htmlText += "</td>";

        //if (data.Payable.Status != "Payment Done") {
        htmlText += "<td>";


        htmlText += "<button type='button' id='edit-Payable-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditPayableData(" + data.Payables[i].Payable_Item_Id + ")'><i class='fa fa-pencil' ></i></button>";

        //htmlText += "<button type='button' id='delete-Payable-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeletPayableData(" + data.Payables[i].Payable_Item_Id + ")'><i class='fa fa-times' ></i></button>";

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

    ClearPayableData();

    
}

function EditPayableData(id) {

    var Total_Bal = 0;
    var Balance_amount = 0;
    var Item_amount = 0;
    var Previous_Item_Amount = $("#hdnPaid_Amount").val();

    $("#drpPayment_Mode").val($("#hdnPayment_Mode" + id).val());

    $("#txtPaid_Amount").val($("#hdnPaid_Amount" + id).val());

    $("#txtCredit_card_no").val($("#hdnCredit_Card_No" + id).val());

    $("#txtDebit_card_no").val($("#hdnDebit_Card_No" + id).val());

    $("#txtCheque_no").val($("#hdnCheque_No" + id).val());

    $("#txtBank_Name").val($("#hdnBank_Name" + id).val());

    $("#hdnPayable_Item_Id").val($("#hdnPayable_Item_Id" + id).val());

    $("#hdnPayable_Id").val($("#hdnPayable_Id" + id).val());

    Balance_amount = $("#txtAmount_due").val();
    Item_amount = $("#hdnPaid_Amount" + id).val();

    Total_Bal = parseFloat(Balance_amount) + parseFloat(Item_amount);

    Total_Bal = parseFloat(Total_Bal) - parseFloat(Previous_Item_Amount);

    $("#txtBalance_Amount").val(Total_Bal);

    $("#hdnPaid_Amount").val(Item_amount);

}

function ClearPayableData() {

    $("#drpPayment_Mode").val(0);

    $("#txtPaid_Amount").val('');

    $("#txtDebit_card_no").val('');

    $("#txtCheque_no").val('');

    $("#txtBank_Name").val('');

    $("#txtCredit_card_no").val('');

    $("#dp-2").val('');

   
  

}