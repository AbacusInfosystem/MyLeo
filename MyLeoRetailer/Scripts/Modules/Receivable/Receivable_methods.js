﻿

function Get_Receivables(Sales_Invoice_Id, Sales_Credit_Note_Id) {

    $("#hdf_Sales_Invoice_Id").val(Sales_Invoice_Id);

    $("#hdf_Sales_Credit_Note_Id").val(Sales_Credit_Note_Id);

    $("#frmReceivable").attr("action", "/Receivable/Get_Receivable_Details_By_Id");
    $("#frmReceivable").submit();

    //Bind_Receivable_Grid_Items(data);

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

            $("[name='Receivable.Credit_Note_Date']").val(obj.Receivable.Credit_Note_Date.substring(0, 10));

            alert($("[name='Receivable.Credit_Note_Amount']").val());

            //calculate(obj.Receivable.Credit_Note_Amount);

            $("[name='Receivable.Credit_Note_Amount']").focus();

            $("[name='Receivable.Credit_Note_Amount']").blur();
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

            $("[name='Receivable.Gift_Voucher_No']").val(obj.Receivable.Gift_Voucher_No);

            //calculate(obj.Receivable.Gift_Voucher_Amount);

            $("[name='Receivable.Gift_Voucher_Amount']").focus();

            $("[name='Receivable.Gift_Voucher_Amount']").blur();
        }
    });
}

function calculate(element)
{
    //if (element.id == "txtCash_amount")
    //{
    //    $("#hdnCash_Amount").val(parseInt($("#txtBalance_Amount").val()) - parseInt(element.value));
    //}
    //if (element.id == "txtCheque_Amount") {
    //    $("#hdnCheque_Amount").val(parseInt($("#txtBalance_Amount").val()) - parseInt(element.value));
    //}
    //if (element.id == "txtCredit_Note_Amount") {
    //    $("#hdnCredit_Note_Amount").val(parseInt($("#txtBalance_Amount").val()) - parseInt(element.value));
    //}

    //if (element.id == "txtCard_Amount") {
    //    $("#hdnCard_Amount").val(parseInt($("#txtBalance_Amount").val()) - parseInt(element.value));
    //}

    //if (element.id == "txtGift_Voucher_Amount") {
    //    $("#hdnGift_Voucher_Amount").val(parseInt($("#txtBalance_Amount").val()) - parseInt(element.value));
    //}

    var cash = 0;
    var credit = 0;
    var card = 0;
    var gift = 0;
    var check = 0;
    var discount = 0;


    if ($("#txtCash_amount").val() != "")
    {
        cash = $("#txtCash_amount").val()
    }

    if ($("#txtCheque_Amount").val() != "") {
        credit = $("#txtCheque_Amount").val()
    }

    if ($("#txtCredit_Note_Amount").val() != "") {
        card = $("#txtCredit_Note_Amount").val()
    }

    if ($("#txtCard_Amount").val() != "") {
        gift = $("#txtCard_Amount").val()
    }

    if ($("#txtGift_Voucher_Amount").val() != "") {
        check = $("#txtGift_Voucher_Amount").val()
    }

    if ($("#txtDiscount_Amount").val() != "") {
        discount = $("#txtDiscount_Amount").val()
    }

    //$("#txtPaid_Amount").val(parseInt($("#txtCash_amount").val()) + parseInt($("#txtCheque_Amount").val()) + parseInt($("#txtCredit_Note_Amount").val()) + parseInt($("#txtCard_Amount").val()) + parseInt($("#txtGift_Voucher_Amount").val()));
    $("#txtPaid_Amount").val(parseInt(cash) + parseInt(credit) + parseInt(card) + parseInt(gift) + parseInt(check) + parseInt(discount));



}

function Get_Balance_Amount_Using_Cash_Amount() {

    var PaidAmount = 0;

    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

    var cashamount = parseFloat($("#txtCash_amount").val());

    PaidAmount = parseFloat($("#txtPaid_Amount").val());

    var newpaidamount = PaidAmount + cashamount;

    $("#txtPaid_Amount").val(newpaidamount.toFixed(2));

    var newbalanceamount = oldbalanceamount - cashamount;

    $("#txtBalance_Amount").val(newbalanceamount.toFixed(2));

   

}

function Get_Balance_Amount_Using_Cheque_Amount() {

    var PaidAmount = 0;

    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

    var chequeamount = parseFloat($("#txtCheque_Amount").val());

    PaidAmount = parseFloat($("#txtPaid_Amount").val());

    var newpaidamount = PaidAmount + chequeamount;

    $("#txtPaid_Amount").val(newpaidamount.toFixed(2));

    var newbalanceamount = oldbalanceamount - chequeamount;

    if (newbalanceamount < 0) {

        $("#txtPaid_Amount").rules("add", { required: true, messages: { required: "Paid amount is greater than balance amount." } });
    }

    else {
        $("#txtBalance_Amount").val(newbalanceamount.toFixed(2));
    }


}

function Get_Balance_Amount_Using_Credit_Note_Amount() {

    var PaidAmount = 0;

    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

    var creditnoteamount = parseFloat($("#txtCredit_Note_Amount").val());

    PaidAmount = parseFloat($("#txtPaid_Amount").val());

    var newpaidamount = PaidAmount + creditnoteamount;

    $("#txtPaid_Amount").val(newpaidamount.toFixed(2));

    var newbalanceamount = oldbalanceamount - creditnoteamount;

    if (newbalanceamount < 0) {

        //$("#txtPaid_Amount").rules("add", { required: true, messages: { required: "Paidamount is greater. " } });
        $("#txtPaid_Amount").rules("add", { required: true, messages: { required: "required." } });
    }

    else {
        $("#txtBalance_Amount").val(newbalanceamount.toFixed(2));
    }

    document.getElementById("txtCredit_Note_Amount").disabled = true;
}

function Get_Balance_Amount_Using_Gift_Voucher_Amount() {

    var PaidAmount = 0;

    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

    var giftvoucheramount = parseFloat($("#txtGift_Voucher_Amount").val());

    PaidAmount = parseFloat($("#txtPaid_Amount").val());

    var newpaidamount = PaidAmount + giftvoucheramount;

    $("#txtPaid_Amount").val(newpaidamount.toFixed(2));

    var newbalanceamount = oldbalanceamount - giftvoucheramount;

    if (newbalanceamount < 0) {

        $("#txtPaid_Amount").rules("add", { required: true, messages: { required: "Paid amount is greater than balance amount." } });
    }

    else {
        $("#txtBalance_Amount").val(newbalanceamount.toFixed(2));
    }


}

function Get_Balance_Amount_Using_Card_Amount() {

    var PaidAmount = 0;

    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

    var cardamount = parseFloat($("#txtCard_Amount").val());

    PaidAmount = parseFloat($("#txtPaid_Amount").val());

    var newpaidamount = PaidAmount + cardamount;

    $("#txtPaid_Amount").val(newpaidamount.toFixed(2));

    var newbalanceamount = oldbalanceamount - cardamount;

    if (newbalanceamount < 0) {

        $("#txtPaid_Amount").rules("add", { required: true, messages: { required: "Paid amount is greater than balance amount." } });
    }

    else
    {
        $("#txtBalance_Amount").val(newbalanceamount.toFixed(2));
    }

   

   

    
}

function Cancel() {

    document.getElementById("txtPaid_Amount").disabled = false;

}

function Save_Receivable_Data() {
    var rViewModel =
		{
		    Receivable: {



		        Receivable_Item_Id: $("[name='Receivable.Receivable_Item_Id']").val(),

		        Receivable_Id: $("[name='Receivable.Receivable_Id']").val(),

		        Sales_Credit_Note_Id: $("[name='Receivable.Sales_Credit_Note_Id']").val(),

		        Credit_Note_Amount: $("[name='Receivable.Credit_Note_Amount']").val(),

		        Gift_Voucher_Id: $("[name='Receivable.Gift_Voucher_Id']").val(),

		        Sales_Invoice_Id: $("[name='Receivable.Sales_Invoice_Id']").val(),

		        Payament_Date: $("[name='Receivable.Payament_Date']").val(),

		        Balance_Amount: $("[name='Receivable.Balance_Amount']").val(),

		        Gift_Voucher_No: $("[name='Receivable.Gift_Voucher_No']").val(),

		        Net_Amount: $("[name='Receivable.Net_Amount']").val(),

		        Paid_Amount: $("[name='Receivable.Paid_Amount']").val(),

		        Cash_Amount: $("[name='Receivable.Cash_Amount']").val(),

		        Cheque_Amount: $("[name='Receivable.Cheque_Amount']").val(),

		        Card_Amount: $("[name='Receivable.Card_Amount']").val(),

		        Gift_Voucher_Amount: $("[name='Receivable.Gift_Voucher_Amount']").val(),

		        Cheque_Date: $("[name='Receivable.Cheque_Date']").val(),

		        Branch_ID: $("[name='Receivable.Branch_ID']").val(),

		        Branch_Name: $("[name='Receivable.Branch_Name']").val(),

		        Cheque_No: $("[name='Receivable.Cheque_No']").val(),

		        Bank_Name: $("[name='Receivable.Bank_Name']").val(),

		        Credit_Card_No: $("[name='Receivable.Credit_Card_No']").val(),

		        Discount_Percentage: $("[name='Receivable.Discount_Percentage']").val(),

		        Discount_Amount: $("[name='Receivable.Discount_Amount']").val(),
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

            //$("#drpGift_Voucher_No").html('');

            //$("#drpCredit_Note_No").html('');

            var obj = $.parseJSON(response);

            Bind_Receivable_Grid_Items(obj);

            Friendly_Messages(obj);

            //Cancle();

            $("#drpGift_Voucher_No").text("");
            var html = '<option value=0>Gift Voucher No</option>'
            for (var i = 0; i < obj.Receivables1.length; i++) {
                html += '<option value=' + obj.Receivables1[i].Gift_Voucher_Id + '>' + obj.Receivables1[i].Gift_Voucher_No + '</option>';
            }
            $("#drpGift_Voucher_No").append(html);

            $("#drpCredit_Note_No").text("");
            var html = '<option value=0>Select Credit Note no</option>'
            for (var i = 0; i < obj.Credit_Notes.length; i++) {
                html += '<option value=' + obj.Credit_Notes[i].Sales_Credit_Note_Id + '>' + obj.Credit_Notes[i].Credit_Note_No + '</option>';
            }
            $("#drpCredit_Note_No").append(html);

            document.getElementById("btnResetPay").disabled = false;

            document.getElementById("txtCredit_Note_Amount").disabled = false;
            //Friendly_Messages(obj);


        }
    });

}

function Bind_Receivable_Grid_Items(data) {

    $("#tblReceivableItems").html("");

    var htmlText = "";

    $("#hdnReceivable_Item_Id").val(data.Receivable.Receivable_Item_Id),

    $("#hdnReceivable_Id").val(data.Receivable.Receivable_Id),

     $("#hdf_Sales_Credit_Note_Id").val(data.Receivable.Sales_Credit_Note_Id),

    $("#hdf_Gift_Voucher_Id").val(data.Receivable.Gift_Voucher_Id),

    $("#hdnSales_Invoice_Id").val(data.Receivable.Sales_Invoice_Id),

    $("#txtNet_Amount").val(data.Receivable.Net_Amount),

    $("#txtBalance_Amount").val(data.Receivable.Balance_Amount);

    $('#txtPayament_Date').datepicker('setDate', 'today');

    $('#txtCheque_Date').datepicker('setDate', 'today');

    $('#txtCredit_Note_Date').datepicker('setDate', 'today');

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

        htmlText += "<th>Credit note date</th>";

        htmlText += "<th>Card no</th>";

        htmlText += "<th>Card amount</th>";

        htmlText += "<th>Gift voucher no</th>";

        htmlText += "<th>Gift voucher amount</th>";

        htmlText += "<th>Discount%</th>";

        htmlText += "<th>Discount amount</th>";

        //htmlText += "<th>Action</th>"
      

    }

    htmlText += "</tr>";

    for (i = 0; i < data.Receivables.length; i++) {

        htmlText += "<tr>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Paid_Amount == null ? "" : data.Receivables[i].Paid_Amount;


        htmlText += "<input type='hidden' id='hdnPaid_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Paid_Amount + "'/>";

        //htmlText += "<input type='hidden' id='hdnTotal_MRP_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Total_MRP_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCash_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cash_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cheque_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cheque_No + "'/>";

        htmlText += "<input type='hidden' id='hdnCheque_Date" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Cheque_Date + "'/>";

        htmlText += "<input type='hidden' id='hdnPayament_Date" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivable.Payament_Date + "'/>";

        htmlText += "<input type='hidden' id='hdnBranchID" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivable.Branch_ID + "'/>";

        htmlText += "<input type='hidden' id='hdnBranchName" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivable.Branch_Name + "'/>";

        htmlText += "<input type='hidden' id='hdnBank_Name" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Bank_Name + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Note_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Sales_Credit_Note_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Note_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Credit_Note_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Note_Date" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Credit_Note_Date + "'/>";

        htmlText += "<input type='hidden' id='hdnCredit_Card_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Credit_Card_No + "'/>";

        htmlText += "<input type='hidden' id='hdnCard_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Card_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnGift_Voucher_No" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Gift_Voucher_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnGift_Voucher_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Gift_Voucher_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnDiscount_Percentage" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Discount_Percentage + "'/>";

        htmlText += "<input type='hidden' id='hdnDiscount_Amount" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Discount_Amount + "'/>";

        htmlText += "<input type='hidden' id='hdnReceivable_Item_Id" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Receivable_Item_Id + "'/>";

        htmlText += "<input type='hidden' id='hdnReceivable_Id" + data.Receivables[i].Receivable_Item_Id + "' value='" + data.Receivables[i].Receivable_Id + "'/>";



        htmlText += "</td>";

        //htmlText += "<td>";

        //htmlText += data.Receivables[i].Total_MRP_Amount == null ? "" : data.Receivables[i].Total_MRP_Amount;

        //htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cash_Amount == 0 ? "NA" : data.Receivables[i].Cash_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cheque_Amount == 0 ? "NA" : data.Receivables[i].Cheque_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cheque_No == null ? "NA" : data.Receivables[i].Cheque_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Cheque_Date == "1999-01-01" ? "NA" : data.Receivables[i].Cheque_Date.substring(0, 10);

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Bank_Name == null ? "NA" : data.Receivables[i].Bank_Name;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Note_No == null ? "NA" : data.Receivables[i].Credit_Note_No;

        htmlText += "</td>";


        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Note_Amount == 0 ? "NA" : data.Receivables[i].Credit_Note_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Note_Date == "0001-01-01" ? "NA" : data.Receivables[i].Credit_Note_Date.substring(0, 10);

        //Added By Vinod Mane on 23/09/2016
        //var Customer_DOB = new Date(obj.Customer.Customer_DOB);
        //Customer_DOB = (Customer_DOB.getDate().toString() + "-" + (Customer_DOB.getMonth() + 1).toString() + "-" + Customer_DOB.getFullYear());
        //$("[name='Customer.Customer_DOB']").val(Customer_DOB);
        //End

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Credit_Card_No == null ? "NA" : data.Receivables[i].Credit_Card_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Card_Amount == 0 ? "NA" : data.Receivables[i].Card_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Gift_Voucher_No == null ? "NA" : data.Receivables[i].Gift_Voucher_No;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Gift_Voucher_Amount == 0 ? "NA" : data.Receivables[i].Gift_Voucher_Amount;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Discount_Percentage == 0 ? "NA" : data.Receivables[i].Discount_Percentage;

        htmlText += "</td>";

        htmlText += "<td>";

        htmlText += data.Receivables[i].Discount_Amount == 0 ? "NA" : data.Receivables[i].Discount_Amount;

        htmlText += "</td>";

        //htmlText += showPayableDate == null ? "" : showPayableDate;

             

        //if (data.Payable.Status != "Payment Done") {
        //htmlText += "<td>";


        //htmlText += "<button type='button' id='edit-Payable-details' class='btn btn-box-tool btn-tel-edit' onclick='javascript:EditReceivableData(" + data.Receivables[i].Receivable_Item_Id +")'><i class='fa fa-pencil' ></i></button>";

        ////htmlText += "<button type='button' id='delete-Payable-details' class='btn btn-box-tool btn-tel-delete' onclick='javascript:DeletPayableData(" + data.Receivables[i].Receivable_Item_Id + ")'><i class='fa fa-times' ></i></button>";

        //htmlText += "</td>";
        //}

        htmlText += "</tr>";
    }
  

    $('#tblReceivableItems').html(htmlText);

    //Friendly_Message(data);

    ClearReceivableData();


}

function ClearReceivableData() {

    $("#txtPaid_Amount").val('');

    $("#txtCash_amount").val('');

    $("#txtCheque_Amount").val('');

    $("#txtCheque_No").val('');

    //$("#txtCheque_Date").val('');

    //$("#txtPayament_Date").val('');

    $("#txtBank_Name").val('');

    $("#drpCredit_Note_No").val('');

    $("#txtCredit_Note_Amount").val('');

    $("#txtCredit_Card_No").val('');

    //$("#txtCredit_Note_Date").val('');

    $("#txtCard_Amount").val('');

    $("#drpGift_Voucher_No").val('');

    $("#txtGift_Voucher_Amount").val('');

    //$("#text_Branch_Name").val('');

    $("#txtDiscount_Percentage").val('');

    $("#txtDiscount_Amount").val('');

}

function EditReceivableData(id) {

    document.getElementById("btnResetPay").disabled = true;

    var Balance_amount = 0;
    var paid_amount = 0;
    var total_bal_amount = 0;
   

    $("#txtPaid_Amount").val($("#hdnPaid_Amount" + id).val());

    //$("#txtTotal_MRP_Amount").val($("#hdnTotal_MRP_Amount" + id).val());

    $("#txtCash_amount").val($("#hdnCash_Amount" + id).val());

    $("#txtCheque_Amount").val($("#hdnCheque_Amount" + id).val());

    $("#txtCheque_No").val($("#hdnCheque_No" + id).val());

    $("#a123").val($("#hdnCheque_Date" + id).val());

    $("#txtCheque_Date").val($("#hdnCheque_Date" + id).val());

    $("#txtPayament_Date").val($("#hdnPayament_Date" + id).val());

    $("#txtBank_Name").val($("#hdnBank_Name" + id).val());

    $("#txtCredit_Note_Amount").val($("#hdnCredit_Note_Amount" + id).val());

    $("#txtCredit_Card_No").val($("#hdnCredit_Card_No" + id).val());

    $("#txtCredit_Note_Date").val($("#hdnCredit_Note_Date" + id).val());

    $("#txtCard_Amount").val($("#hdnCard_Amount" + id).val());

    $("#txtGift_Voucher_Amount").val($("#hdnGift_Voucher_Amount" + id).val());

    $("#hdnReceivable_Item_Id").val($("#hdnReceivable_Item_Id" + id).val());

    $('[name = "Receivable.Sales_Credit_Note_Id"]').val($("#hdnCredit_Note_No" + id).val());

    $('[name = "Receivable.Gift_Voucher_Id"]').val($("#hdnGift_Voucher_No" + id).val());

    $("#hdnReceivable_Id").val($("#hdnReceivable_Id" + id).val());


    //edited by sushant for Branch

    //$('[name = "Receivable.Branch_Name"]').val($("#hdnBranchName" + id).val());

    //$('[name = "Receivable.Gift_Voucher_Id"]').val($("#hdnGift_Voucher_No" + id).val());

    $("#text_Branch_Name").val($("#hdnBranchName" + id).val());

    $("#hdnBranchID").val($("#hdnBranchID" + id).val());


    if ($('#text_Branch_Name').val() != 0)

        $("#divBranch").find(".autocomplete-text").trigger("focusout");


    Balance_amount = $("#txtBalance_Amount").val();

    paid_amount = $("#txtPaid_Amount").val();

    total_bal_amount = parseFloat(Balance_amount) + parseFloat(paid_amount);

    $("#txtBalance_Amount").val(total_bal_amount);


}

function CalculateDiscount()
{
    var cash = 0;
    var credit = 0;
    var card = 0;
    var gift = 0;
    var check = 0;
    var paid_amount = 0;
    var balance_amount = 0;
    var discount = 0;

    cash = $("#txtCash_amount").val();
    credit = $("#txtCheque_Amount").val();
    card = $("#txtCredit_Note_Amount").val();
    gift = $("#txtCard_Amount").val();
    check = $("#txtGift_Voucher_Amount").val();
    paid_amount = $("#txtPaid_Amount").val();
    balance_amount = $("#txtBalance_Amount").val();
    discount = $("#txtDiscount_Percentage").val();

    if (cash != "" || credit !== "" || card != "" || gift != "" || check != "") {

        final_amount = balance_amount - paid_amount;
        var discountAmt = (discount == "" || discount == undefined) ? 0 : parseFloat((final_amount * discount) / 100);
        $("#txtDiscount_Amount").val(discountAmt.toFixed(0));
    }
    else
    {
        var discountAmt = (discount == "" || discount == undefined) ? 0 : parseFloat((balance_amount * discount) / 100);
        $("#txtDiscount_Amount").val(discountAmt.toFixed(0));
    }

}

function BalanceAmount() {

    debugger;

    alert("5000");
    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

    var PaidAmount = parseFloat($("#txtPaid_Amount").val());

    var newbalanceamount = oldbalanceamount - PaidAmount;

    $("#txtBalance_Amount").val(newbalanceamount.toFixed(2));



}

function Cancle() {

    document.getElementById("txtCredit_Note_Amount").disabled = false;

}

//function CalculateDiscount() {


//    var oldbalanceamount = 0;
//    var chequeamount = 0;
//    var cashamount = 0;
//    var creditnoteamount = 0;
//    var giftvoucheramount = 0;
//    var cardamount = 0;

//    if ($("#txtBalance_Amount").val() != "") {
//        oldbalanceamount = parseFloat($("#txtBalance_Amount").val());
//    }

//    if ($("#txtCheque_Amount").val() != "") {
//        chequeamount = parseFloat($("#txtCheque_Amount").val());
//    }

//    if ($("#txtCash_amount").val() != "") {
//        cashamount = parseFloat($("#txtCash_amount").val());
//    }

//    if ($("#txtCredit_Note_Amount").val() != "") {
//        creditnoteamount = parseFloat($("#txtCredit_Note_Amount").val());
//    }

//    if ($("#txtGift_Voucher_Amount").val() != "") {
//        giftvoucheramount = parseFloat($("#txtGift_Voucher_Amount").val());
//    }

//    if ($("#txtCard_Amount").val() != "") {
//        cardamount = parseFloat($("#txtCard_Amount").val());
//    }

//    var total = 0;

//    var PaidAmount = 0;

//    total = chequeamount + cashamount + creditnoteamount + giftvoucheramount + cardamount;

//    if (total > oldbalanceamount) {
//        ClearReceivableData();
//    }
//    else {
//        $("#txtPaid_Amount").val(total.toFixed(2));

//        BalanceAmount();

//        document.getElementById("txtPaid_Amount").disabled = true;
//    }



//    //if (cashamount == 0) {

//    //    paidamount = chequeamount + creditnoteamount + giftvoucheramount + cardamount;

//    //    //var newbalanceamount = oldbalanceamount - paidamount
//    //}

//    //else if (chequeamount == 0)
//    //{
//    //    paidamount = cashamount + creditnoteamount + giftvoucheramount + cardamount;

//    //    //var newbalanceamount = oldbalanceamount - paidamount
//    //}

//    //else if (creditnoteamount == 0)
//    //{

//    //    paidamount = cashamount + chequeamount + giftvoucheramount + cardamount;

//    //    //var newbalanceamount = oldbalanceamount - paidamount
//    //}

//    //else if (giftvoucheramount == 0) {

//    //    paidamount = cashamount + chequeamount + creditnoteamount + cardamount;

//    //    //var newbalanceamount = oldbalanceamount - paidamount
//    //}

//    //else if (cardamount == 0)
//    //{

//    //    paidamount = cashamount + chequeamount + creditnoteamount + giftvoucheramount;


//    //}

//    //else {

//    //    paidamount = cashamount + chequeamount + creditnoteamount + cardamount + giftvoucheramount;

//    //    var newbalanceamount = oldbalanceamount - paidamount

//    //    //var newbalanceamount = oldbalanceamount - paidamount
//    //}
//    // var paidamount = chequeamount + cashamount + creditnoteamount + giftvoucheramount + cardamount;



//    //$("#txtBalance_Amount").val(newbalanceamount.toFixed(2));

//    //$("#txtPaid_Amount").enabled = false;




//}

//function add_Validation(elem)
//{
//    $("#txtBalance_Amount").rules("add", "checkBalanceamount" );

//    jQuery.validator.addMethod("checkBalanceamount", function (value, element) {

//        alert();
//        var result = true;
//        var bal_amt = parseFloat($("#txtBalance_Amount").val());

//        if (bal_amt != "" && bal_amt != 0) {

//            if (bal_amt >= 0) {
//                result = true;
//            }
//            else {
//                result = false;
//            }
//        }
//        return result;

//    }, "Paid amount is greater than balance amount.");

//}