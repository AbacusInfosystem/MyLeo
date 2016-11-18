$(document).ready(function () {

    $("input.mask_mobile_no").mask('(99) 99999-99999');

    $("#textQuantity_0").rules("add", { required: true, digits: true, messages: { required: "Required", digits: "Invalid quantity." } });

    $("#textSKU_No_0").rules("add", { required: true, checkSKUExist: true, messages: { required: "Required field", } });

    $("#textBarcode_No_0").rules("add", { checkBarcodeExist: true });

    //$("#txtPayament_Date").rules("add", { required: true, messages: { required: "Payment is Required", } });

    //$("#textSales_Branch_Name_0").val($("#hdnBranchName" + id).val());

    //$("#hdnBranchID").val($("#hdnBranchID" + id).val());


    //if ($('#textSales_Branch_Name_0').val() != 0)

    //    $("#divBranch").find(".autocomplete-text").trigger("focusout");

    //$("#btnCustomer").click(function () {

       
    //});



    $('#dtpInvoice_Date').datepicker({

        dateFormat: "dd-MM-yy",
        changeMonth: true,
        changeYear: true,
        minDate: 0,
        autoclose: true,

    });


    debugger

    if ($('#hdnSalesInvoiceID').val() != 0) {

        debugger;

        //$('#btnAddInputRow').attr("disabled", "disabled");

        $('#btnSaveSalesOrder').attr("disabled", "disabled");

        $('#btnCustomer').attr("disabled", "disabled");

    }


    debugger;

    //CalculateDiscountAmount();

    //CalculateTax();

    //Get_Gift_Voucher_Details();

});

$(function ()
{


    $("[name='SalesInvoice.Mobile']").focusout(function ()
    {
        Get_Customer_Name_By_Mobile_No();

    });


    $('[name = "SalesInvoice.Sales_Credit_Note_Id"]').change(function () {

        Get_Credit_Note_Amount_By_Id($(this).val());

        

    });

    $('[name = "SalesInvoice.Gift_Voucher_Id"]').change(function () {

        Get_Gift_Voucher_Amount_By_Id($(this).val());

       

    });


    $("#btnSaveSalesOrder").click(function ()
    {
        debugger;

        $("#tblSalesOrderItems").find("[id^='SalesOrderItemRow_']").each(function (i, row)
        {
            Add_Validation(i);
        });

        //$('.barcode').each(function () {

        //    alert(this.id);
        //    //$(this).rules("remove");
        //    $("#'"+ this.id + "'").rules("remove");
        //});



        //$('#textBarcode_No_0').rules("remove");

        if ($("#frmSalesOrder").valid()) {

            if ($('#tblSalesOrderItems tbody tr').length > 0) {

                $("#frmSalesOrder").attr("action", "/SalesOrder/Insert_SalesOrder/");

                $('#frmSalesOrder').attr("method", "POST");

                $('#frmSalesOrder').submit();

            }
        }

    });


    $("#btnCustomer").click(function () {

        debugger;

        $("#hdnCreateCustomerFlag").val(true);

        // alert($("#hdnCreateCustomerFlag").val());

        $("#frmSalesOrder").validate().cancelSubmit = true;

        //$("#Searchcustomer").hide();

        //$('#textSKU_No_0').rules("remove");

        //$('#textQuantity_0').rules("remove");

        ////$('#txtPayament_Date').rules("remove");

        //$('#dtpInvoice_Date').removeClass("login-error");
        //$('#dtpInvoice_Date').rules("remove");

        //$('#txtMobileNo').removeClass("MobileNo");
        //$('#txtMobileNo').rules("remove");

        //$('#txtCustomer_Name').removeClass("login-error");
        //$('#txtCustomer_Name').rules("remove");

        //$('#textTaxPercentage_0').rules("remove");

        $("#frmSalesOrder").attr("action", "/Customer/Index/");

        $('#frmSalesOrder').attr("method", "POST");

        $('#frmSalesOrder').submit();

    });

});

//function CalculateQuantityMRP()
//{
//    debugger;

//    var sumQuantity = 0;
//    var sumMRPAmount = 0;
//    //var mrpAmt = 0;

//    var tr = $("#tblSalesOrderItems").find('[id^="SalesOrderItemRow_"]');

//    if (tr.size() > 0) {
//        for (var i = 0; i < tr.size() ; i++)
//        {
//            //var Qty = parseFloat($("#tblSalesOrderItems").find('[id="textQuantity_' + i + '"]').val());

//            //Added by vinod mane on 12/10/2016
//            var Qty = $("#tblSalesOrderItems").find('[id="textQuantity_' + i + '"]').val();

//            if (Qty == "" || Qty == "NaN") {
//                Qty = 0;
//                $('#textQuantity_' + i).val(0);
//            }
//            //End
//            var MRP = parseFloat($("#tblSalesOrderItems").find('[id="textMRP_Price_' + i + '"]').val());

//            //Added by vinod mane on 12/10/2016
//            var MRP = $("#tblSalesOrderItems").find('[id="textMRP_Price_' + i + '"]').val();

//            if (MRP == "" || MRP == "NaN") {
//                MRP = 0;
//                $('#textMRP_Price_' + i).val(0);
//            }
//            //End
//            //$("#textMRP_Price_" + i).val(mrpAmt);

//            //mrpAmt = Qty * MRP

//            sumQuantity = parseFloat(sumQuantity) + parseFloat(Qty);
//            sumMRPAmount = parseFloat(MRP) + parseFloat(sumMRPAmount);
           
//        }
//        //$("#textMRP_Price_" + i).val(mrpAmt);
//    }
//    //$("#textMRP_Price_" + i).val(mrpAmt);
//    $("#textTotalQuantity_0").val(sumQuantity);
//    $("#textMRPAmount_0").val(sumMRPAmount.toFixed(2));
//}

//function CalculateTotal()
//{

//    var sumQuantity = 0;
//    var sumMRPAmount = 0;
//    var sumDiscountAmount = 0;
//    var sumGrossAmount = 0;

//    var tr = $("#tblSalesOrderItems").find('[id^="SalesOrderItemRow_"]');


//    if (tr.size() > 0)
//    {
//        for (var i = 0; i < tr.size() ; i++)
//        {
//            var Qty = parseFloat($("#tblSalesOrderItems").find('[id="textQuantity_' + i + '"]').val());

//            //Added by vinod mane on 12/10/2016
//            var Qty = $("#tblSalesOrderItems").find('[id="textQuantity_' + i + '"]').val();
//            if (Qty == "" || Qty == "NaN") {
//                Qty = 0;
//                $('#textQuantity_' + i).val(0);
//            }
//            //End
//            var MRP = parseFloat($("#tblSalesOrderItems").find('[id="textMRP_Price_' + i + '"]').val());
//            //var Discount = parseFloat($("#tblSalesOrderItems").find('[id="textDiscount_Percentage_' + i + '"]').val());
           
//            //Added by vinod mane on 12/10/2016
//            var Discount = $("#tblSalesOrderItems").find('[id="textDiscount_Percentage_' + i + '"]').val();
//            if (Discount == "" || Discount == "NaN") {
//                Discount = 0;
//                $('#textDiscount_Percentage_' + i).val(0);
//            }
//            //End

//            var DiscountAmt = (Discount == "" || Discount == undefined) ? 0 : parseFloat((Qty * MRP * Discount) / 100);
//            $("#tblSalesOrderItems").find('[id="textSalesOrder_Discount_Amount_' + i + '"]').val(DiscountAmt);
//            var Amount = parseFloat(MRP * Qty - DiscountAmt);
//            $("#tblSalesOrderItems").find('[id="textAmount_' + i + '"]').val(Amount);
          
//            sumQuantity = parseFloat(sumQuantity) + parseFloat(Qty);
//            sumMRPAmount = MRP + sumMRPAmount;
//            sumDiscountAmount = sumDiscountAmount + DiscountAmt;
//            sumGrossAmount = sumGrossAmount + Amount;

//        }
//    }

//    $("#textTotalQuantity_0").val(sumQuantity);
//    $("#textMRPAmount_0").val(sumMRPAmount.toFixed(2));
//    $("#textDiscountAmount_0").val(sumDiscountAmount.toFixed(2));
//    $("#textGrossAmount_0").val(sumGrossAmount.toFixed(2));
    
//}

//function CalculateTax() {
   
//    var netAmt = 0;

//    //var tax = parseFloat($("#textTaxPercentage_0").val());

//    //Added by vinod mane on 12/10/2016
//    var tax = $("#textTaxPercentage_0").val();

//    if (tax == "" || tax == "NaN") {
//        tax = 0;
//        $('#textTaxPercentage_0').val(0);
//    }
//    //End
//    var sumGrossAmount = parseFloat($("#textGrossAmount_0").val());
   

//    var taxAmt = (tax == "" || tax == undefined) ? 0 : parseFloat((sumGrossAmount * tax) / 100);
//    $("#tblSalesOrderItems").find("textTaxAmount_0").val(taxAmt);

//    var netAmt_temp = taxAmt + sumGrossAmount;

//    var roundedDecimal = netAmt_temp.toFixed(2);

//    var intPart = Math.floor(roundedDecimal);
   
//    var fracPart = parseFloat((roundedDecimal - intPart), 2);
//    //Added by vinod mane on 12/10/2016
//    if (fracPart >= 0.50) {
//        netAmt_temp += 1;
//    }
//    //End
//    var roundOff = parseFloat(netAmt_temp.toString().split(".")[1]);

//    var netAmt = netAmt_temp - fracPart;

//    //var netAmt = Math.round(0.2);

//    $("#textTaxAmount_0").val(taxAmt.toFixed(2));
//    $("#textRoundOff_0").val(fracPart.toFixed(2));
//    $("#textNETAmount_0").val(Math.round(netAmt));
//    $("#textTotalAmount").val(Math.round(netAmt));


//}

//function CalculateDiscountAmount()
//{
//    var tr = $("#tblSalesOrderItems").find('[id^="SalesOrderItemRow_"]');

//    if (tr.size() > 0) {
//        for (var i = 0; i < tr.size() ; i++) {

//            var Qty = parseFloat($("#tblSalesOrderItems").find('[id="textQuantity_' + i + '"]').val());
//            var MRP = parseFloat($("#tblSalesOrderItems").find('[id="textMRP_Price_' + i + '"]').val());

//            var Discount = parseFloat($("#tblSalesOrderItems").find('[id="textDiscount_Percentage_' + i + '"]').val());
//            var DiscountAmt = (Discount == "" || Discount == undefined) ? 0 : parseFloat((Qty * MRP * Discount) / 100);
//            $("#tblSalesOrderItems").find('[id="textSalesOrder_Discount_Amount_' + i + '"]').val(DiscountAmt);

//        }
//    }
//}

//function CalculatePaidAmt() {

//    debugger;

//   // alert();

//    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

//    var chequeamount = parseFloat($("#txtCheque_Amount").val());

//    var cashamount = parseFloat($("#txtCash_amount").val());

//    var creditnoteamount = parseFloat($("#txtCredit_Note_Amount").val());

//    var giftvoucheramount = parseFloat($("#txtGift_Voucher_Amount").val());

//    var cardamount = parseFloat($("#txtCard_Amount").val());

//    if (cashamount == 0) {

//        paidamount = chequeamount + creditnoteamount + giftvoucheramount + cardamount;
//    }

//    else if (chequeamount == 0) {
//        paidamount = cashamount + creditnoteamount + giftvoucheramount + cardamount;
//    }

//    else if (creditnoteamount == 0) {

//        paidamount = cashamount + chequeamount + giftvoucheramount + cardamount;
//    }

//    else if (giftvoucheramount == 0) {

//        paidamount = cashamount + chequeamount + creditnoteamount + cardamount;
//    }

//    else {

//        paidamount = cashamount + chequeamount + creditnoteamount + giftvoucheramount + cardamount;
//    }

//    // var paidamount = chequeamount + cashamount + creditnoteamount + giftvoucheramount + cardamount;

//    $("#txtPaid_Amount").val(paidamount.toFixed(2));

//    //var newbalanceamount = oldbalanceamount - paidamount;

//    //$("#txtBalance_Amount").val(newbalanceamount.toFixed(2));


//}

//function CalculateBalAmt()
//{
//    var oldbalanceamount = parseFloat($("#textTotalAmount").val());

//    $("#txtPaid_Amount").val(paidamount.toFixed(2));

//    var newbalanceamount = oldbalanceamount - paidamount;

//    $("#txtBalance_Amount").val(newbalanceamount.toFixed(2));

//}

//function calculate() {

//    var cash = 0;
//    var credit = 0;
//    var card = 0;
//    var gift = 0;
//    var check = 0;


//    if ($("#txtCash_amount").val() != "") {
//        cash = $("#txtCash_amount").val()
//    }

//    if ($("#txtCheque_Amount").val() != "") {
//        credit = $("#txtCheque_Amount").val()
//    }

//    if ($("#txtCredit_Note_Amount").val() != "") {
//        card = $("#txtCredit_Note_Amount").val()
//    }

//    if ($("#txtCard_Amount").val() != "") {
//        gift = $("#txtCard_Amount").val()
//    }

//    if ($("#txtGift_Voucher_Amount").val() != "") {
//        check = $("#txtGift_Voucher_Amount").val()
//    }


//    $("#txtPaid_Amount").val(parseInt($("#txtCash_amount").val()) + parseInt($("#txtCheque_Amount").val()) + parseInt($("#txtCredit_Note_Amount").val()) + parseInt($("#txtCard_Amount").val()) + parseInt($("#txtGift_Voucher_Amount").val()));


//    $("#txtBalance_Amount").val( parseInt($("#textTotalAmount").val()) -  parseInt($("#txtPaid_Amount").val()));
//   //$("#txtPaid_Amount").val(parseInt(cash) + parseInt(credit) + parseInt(card) + parseInt(gift) + parseInt(check));


//}

