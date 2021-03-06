﻿
function Get_Payable(Purchase_Invoice_Id) {

    alert(Purchase_Credit_Note_Id);

    $("#hdf_Purchase_Invoice_Id").val(Purchase_Invoice_Id);

    //$("#hdf_Purchase_Credit_Note_Id").val(Purchase_Credit_Note_Id);

    $("#frmPayable").attr("action", "/Payable/Get_Payable_Details_By_Id");

    $('#frmPayable').attr("method", "POST");

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

            Calculate_Fianl_Amount_Using_Credit_Note_Amount();
            //$("#frmPay").validate();
            //$("#txtCN_amount").rules("add", { checkCreditnoteamount: true });

            //jQuery.validator.addMethod("checkCreditnoteamount", function (value, element) {

            //    var result = true;
            //    var final_amt = parseFloat($("#txtFinal_amount").val());
            //    var creditnote_amt = parseFloat($("#txtCN_amount").val());

            //    if (final_amt != "" && final_amt != 0) {
            //        alert("500")
            //        if (final_amt >= creditnote_amt) {
            //            result = true;
            //            Calculate_Fianl_Amount_Using_Credit_Note_Amount();
            //        }
            //        else {
            //            result = false;
            //        }
            //    }
            //    return result;

            //}, "Entered amount is greater than final amount.");

        }
    });
}

function Calculate_Fianl_Amount_Using_Credit_Note_Amount() {
    debugger

    if ($("#drpCredit_Note_No").val() != 0) {

        $("#hdnChangebleFAmt").val(0);

        var finalamount = parseFloat($("#txtFinal_amount").val());

        var CNamount = parseFloat($("#txtCN_amount").val());

        var newfinalamount = finalamount - CNamount;

        if (newfinalamount < 0)
            $("#lblFinalPriceError").show();
        else 
        $("#txtFinal_amount").val(newfinalamount.toFixed(2)); 
        
    }
    else {
        $("#txtCN_amount").val('');
        $("#txtFinal_amount").val($("#txtAmount_due").val());
    }
}

function Calculate_Fianl_Amount_Using_Discount() {
    debugger
    if ($("#txtDiscount").val() != 0 && $("#txtDiscount").val() != '') {

        //$('#txtDiscount_amount').attr('readonly', true);
        //$('#txtDiscount').attr('readonly', true);
        $("#txtDiscount_amount").attr("disabled", "disabled");
        $("#txtDiscount").attr("disabled", "disabled");
        $("#hdnChangebleFAmt").val(0);

        var finalamount = parseFloat($("#txtFinal_amount").val());
        var amountdue = parseFloat($("#txtAmount_due").val());

        var discount = parseFloat($("#txtDiscount").val());

        if (finalamount != amountdue) {
            var discountAmt = (discount == "" || discount == undefined) ? 0 : parseFloat((finalamount * discount) / 100);
            var newfinalamount = finalamount - discountAmt;
        } else {
            var discountAmt = (discount == "" || discount == undefined) ? 0 : parseFloat((amountdue * discount) / 100);
            newfinalamount = amountdue - discountAmt;
        }

        $("#txtDiscount_amount").val(discountAmt.toFixed(2));


        if (newfinalamount < 0)
            $("#lblFinalPriceError").show(); 
        else
            $("#txtFinal_amount").val(newfinalamount.toFixed(2)); 
    }
    else
    {
        $("#txtDiscount_amount").val(''); 
        $("#txtFinal_amount").val($("#txtAmount_due").val());
    }
}

function FinalAmount() {
    debugger
    if ($("#txtFinal_amount").val() != 0 && $("#txtFinal_amount").val() != '') {
        var FinalAmount = parseFloat($("#txtFinal_amount").val());
        var amountdue = parseFloat($("#txtAmount_due").val());

        var PaidAmount = parseFloat($("#txtPaid_Amount").val()); 

        if (!isNaN(PaidAmount)) {

            $("#txtPaid_Amount").attr("disabled", "disabled");
            $("#drpPayment_Mode").attr("disabled", "disabled");

            if (FinalAmount != amountdue) {
                if (FinalAmount >= PaidAmount) {
                    var abcamount = FinalAmount - PaidAmount;
                    $("#txtFinal_amount").val(abcamount.toFixed(2));
                }
                else {
                    $("#lblPaidPriceError").show();
                }
            }
            else {
                if (amountdue >= PaidAmount) {
                    var abcamount = amountdue - PaidAmount;
                    $("#txtFinal_amount").val(abcamount.toFixed(2));
                }
                else {
                    $("#lblPaidPriceError").show();
                }
            }
        }
        //document.getElementById("txtPaid_Amount").disabled = true;
    }
}

function Cancle() {

    document.getElementById("txtPaid_Amount").disabled = false;
    document.getElementById("drpPayment_Mode").disabled = false;
    document.getElementById("txtDiscount").disabled = false;
    document.getElementById("txtDiscount_amount").disabled = false;
    //document.getElementById("txtPaid_Amount").disabled = false;
    //document.getElementById("txtPaid_Amount").disabled = false;

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

		        Credit_Note_No: $("[name='Payable.Credit_Note_No']").val(),

		        Credit_Note_Amount: $("[name='Payable.Credit_Note_Amount']").val(),

		        Discount_Percentage: $("[name='Payable.Discount_Percentage']").val(),

		        Discount_Amount: $("[name='Payable.Discount_Amount']").val(),

		        Credit_Card_No: $("[name='Payable.Credit_Card_No']").val(),

		        Debit_Card_No: $("[name='Payable.Debit_Card_No']").val(),

		        Vendor_Employee_Name: $("[name='Payable.Vendor_Employee_Name']").val(),
		        //Employee: $("[name='Payable.Employee']").val(),
		        //Employee_Id: $("[name='Payable.Employee_Id']").val(),
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

            var obj = $.parseJSON(response);

            Bind_Payable_Grid_Items(obj);

            //Reset_Brand();

            //Get_Brands();

            Friendly_Messages(obj);

            $("#drpCredit_Note_No").text("");
            var html = '<option value=0>Select CN no</option>'
            for (var i = 0; i < obj.CreditNote.length; i++) {
                html += '<option value=' + obj.CreditNote[i].Purchase_Credit_Note_Id + '>' + obj.CreditNote[i].Credit_Note_No + '</option>';
            }
            $("#drpCredit_Note_No").append(html);

            document.getElementById("txtPaid_Amount").disabled = false;

            document.getElementById("btnResetPay").disabled = false; 
            document.getElementById("drpPayment_Mode").disabled = false;
            document.getElementById("txtDiscount").disabled = false;
            document.getElementById("txtDiscount_amount").disabled = false;

            $("#drpPayment_Mode").trigger("change");

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

    //$("#txtPayament_Date").val(DateTime.Now.ToShortDateString());

    //$("#txtCheque_Date").val(DateTime.Now.ToShortDateString());

    $('#txtPayament_Date').datepicker('setDate', 'today');

    $('#txtCheque_Date').datepicker('setDate', 'today');

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

        //htmlText += "<th>Action</th>";
    }

    htmlText += "</tr>";

    for (i = 0; i < data.Payables.length; i++) {

        htmlText += "<tr>";



        htmlText += "<td>";


        htmlText += data.Payables[i].Payment_Mode1 == null ? "" : data.Payables[i].Payment_Mode1;

        //htmlText += showPayableDate == null ? "" : showPayableDate;

        htmlText += "<input type='hidden' id='hdnPayment_Mode" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Payment_Mode + "'/>";

        htmlText += "<input type='hidden' id='hdnPaid_Amount" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Paid_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnVendor_Employee_Name" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Vendor_Employee_Name + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Card_No" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Credit_Card_No + "'/>";

        htmlText += "<input type='hidden' id='hdnDebit_Card_No" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Debit_Card_No + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_No" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Cheque_No + "'/>";

        htmlText += "<input type='hidden' id='hdnBank_Name" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Bank_Name + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_Date" + data.Payables[i].Payable_Item_Id + "' value='" + (data.Payables[i].Cheque_Date == '01/01/1999' ? '' : data.Payables[i].Cheque_Date) + ".ToString('dd-MM-yyyy')'/>";

        htmlText += "<input type='hidden' id='hdnPayable_Item_Id" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Payable_Item_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnPayable_Id" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Payable_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Note_No" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Purchase_Credit_Note_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Note_Amount" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Credit_Note_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnDiscount_Percentage" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Discount_Percentage + "'/>";

        htmlText += "<input type='hidden' id='hdnDiscount_Amount" + data.Payables[i].Payable_Item_Id + "' value='" + data.Payables[i].Discount_Amount + "'/>";

        //htmlText += "<input type='hidden' id='hdnPayable_Date" + data.Payables[i].Payable_Item_Id + "' value='" + showPayableDate + "'/>";


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




        //if (data.Payable.Status != "Payment Done") {
        //htmlText += "<td>";


        //htmlText += "<button type='button' id='edit-Payable-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditPayableData(" + data.Payables[i].Payable_Item_Id + ")'><i class='fa fa-pencil' ></i></button>";

        ////htmlText += "<button type='button' id='delete-Payable-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeletPayableData(" + data.Payables[i].Payable_Item_Id + ")'><i class='fa fa-times' ></i></button>";

        //htmlText += "</td>";
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




}

function EditPayableData(id) {

    document.getElementById("btnResetPay").disabled = true;

    var Balance_amount = 0;
    var Discount_amount = 0;
    var creditnote_amount = 0;
    var paid_amount = 0;
    var total_bal_amount = 0;
    var totalbal_amount1 = 0;
    var fianl_amount = 0;
    var totalbal_amount2 = 0;
    var totalbal_amount3 = 0;

    $('[name = "Payable.Payment_Mode"]').val($("#hdnPayment_Mode" + id).val());

    $('[name = "Payable.Payment_Mode"]').trigger('change');

    $("#txtPaid_Amount").val($("#hdnPaid_Amount" + id).val());

    $("#txtCredit_card_no").val($("#hdnCredit_Card_No" + id).val());

    $("#txtDebit_card_no").val($("#hdnDebit_Card_No" + id).val());

    $("#txtCheque_no").val($("#hdnCheque_No" + id).val());

    $("#txtBank_Name").val($("#hdnBank_Name" + id).val());

    $("#hdnPayable_Item_Id").val($("#hdnPayable_Item_Id" + id).val());

    $("#hdnPayable_Id").val($("#hdnPayable_Id" + id).val());

    $("#txtCheque_Date").val($("#hdnCheque_Date" + id).val());

    $('[name = "Payable.Purchase_Credit_Note_Id"]').val($("#hdnCredit_Note_No" + id).val());

    $("#txtCN_amount").val($("#hdnCredit_Note_Amount" + id).val());

    $("#txtDiscount").val($("#hdnDiscount_Percentage" + id).val());

    $("#txtDiscount_amount").val($("#hdnDiscount_Amount" + id).val());

    Balance_amount = $("#txtAmount_due").val();

    Discount_amount = $("#txtDiscount_amount").val();

    creditnote_amount = $("#txtCN_amount").val();

    paid_amount = $("#txtPaid_Amount").val();

    fianl_amount = $("#txtFinal_amount").val();

    total_bal_amount = parseFloat(Balance_amount) + parseFloat(paid_amount);

    $("#txtAmount_due").val(total_bal_amount);

    $("#txtFinal_amount").val(total_bal_amount);


    //$("#txtFinal_amount").val(total_bal_amount);

    //if (creditnote_amount == 0) {
    //    $("#txtAmount_due").val(total_bal_amount);
    //    //$("#txtFinal_amount").val(total_bal_amount);
    //}
    //else {
    //    totalbal_amount1 = parseFloat(total_bal_amount) + parseFloat(creditnote_amount);

    //    $("#txtAmount_due").val(total_bal_amount1);

    //    //$("#txtFinal_amount").val(totalbal_amount1);
    //}


    //if (Discount_amount == 0 )
    //{
    //    $("#txtAmount_due").val(total_bal_amount);
    //    //$("#txtFinal_amount").val(total_bal_amount);
    //}
    //else
    //{
    //    totalbal_amount2 = parseFloat(total_bal_amount) + parseFloat(Discount_amount);

    //    $("#txtAmount_due").val(totalbal_amount2);

    //    //$("#txtFinal_amount").val(totalbal_amount2);
    //}

}

function ClearPayableData() {

    $("#drpPayment_Mode").val(0);

    $("#txtPaid_Amount").val('');

    $("#txtDebit_card_no").val('');

    $("#txtCheque_no").val('');

    $("#txtBank_Name").val('');

    $("#txtCredit_card_no").val('');

    $("#txtCheque_Date").val('');

    $("#drpCredit_Note_No").val('');

    $("#txtCN_amount").val('');

    $("#txtDiscount").val('');

    $("#txtDiscount_amount").val('');

    $("#txtFinal_amount").val('');

    $("#txtPerson_Name").val('');

    $("#txtRemark").val('');

    $("#txtPayament_Date").val('');

    $("#txtVendoremployeename").val('');
} 