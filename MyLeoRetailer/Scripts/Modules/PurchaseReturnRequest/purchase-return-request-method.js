function Get_Purchase_Invoice(obj)
{

    $.ajax({

        url: "/purchase-return-request/get-vendor-and-purchase-invoices",

        data: { Vendor_Id: $(obj).val() },

        method: 'POST',

        async: false,

        success: function (data) {

            $('#hdf_hdn_Tax_Percentage').val(data.Vendor.Vendor_Vat_Rate);
            $('#textTaxPercentage_0').val(data.Vendor.Vendor_Vat_Rate);

            $("#drpPurchase_Invoice_Id").html("");
            $("#drpPurchase_Invoice_Id").append("<option value=''>Select Invoice No.</option>");

            $("#drpPurchase_Invoice_Id").parents('.form-group').find('ul').html("");
            $("#drpPurchase_Invoice_Id").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Invoice No.</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

            if (data.PurchaseInvoices.length > 0) {

                for (var j = 0; j < data.PurchaseInvoices.length; j++) {

                    var i = j + 1;

                    $("#drpPurchase_Invoice_Id").append("<option value='" + data.PurchaseInvoices[j].Purchase_Invoice_Id + "'>" + data.PurchaseInvoices[j].Purchase_Invoice_No + "</option>");

                    $("#drpPurchase_Invoice_Id").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + data.PurchaseInvoices[j].Purchase_Invoice_No + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>")
                }
            }
            $("#textTaxPercentage_0").trigger('change');
        }
    });

}

function AddPurchaseReturnRequestDetails() {

    var html = '';

    var tblHtml = '';

    var myTable = $("#tblPurchaseReturnRequestItems");

    var temptablecount = $("#tblPurchaseReturnRequestItems").find('[id^="PurchaseReturnRequestItemRow_"]').size();

    i = temptablecount;//-1;

    tblHtml += "<tr id='PurchaseReturnRequestItemRow_" + i + "' class='item-data-row'>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Barcode' value='' onblur='javascript: Get_Purchase_Return_Items_By_Barcode(" + i + ");' id='textBarcode_No_" + i + "'>";
    tblHtml += "</td>";


    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control input-sm' onchange='javascript:Get_Purchase_Return_Items_By_SKU_Code(" + i + ");' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].SKU_Code' value='' id='textSKU_No_" + i + "'>";
    //tblHtml += "<input type='hidden' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Purchase_Order_Id' id='hdnPurchase_Order_Id_" + i + "' />"
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group auto-complete'>";
    tblHtml += "<div class='input-group'>";
    tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' id='textSKU_No_" + i + "' placeholder='Enter SKU to search' value='' data-table='Purchase_Invoice_Item' data-col='Quantity,SKU_Code' data-headernames='SKU Code' data-param='hdf_Purchase_Invoice_Id' data-field='Purchase_Invoice_Id' name='SKU_Code_" + i + "'/>";
    tblHtml += "<span class='input-group-addon'><a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    tblHtml += "<input type='hidden' id='hdnQuantity_" + i + "' value='' class='auto-complete-value'/>";
    tblHtml += "<input type='hidden' id='hdnSKU_No_" + i + "' value='' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].SKU_Code' class='auto-complete-label' onchange='javascript:Get_Purchase_Return_Items_By_SKU_Code(" + i + ");'/>";
    tblHtml += "</div>";
    tblHtml += "</div>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Article_No' readonly value='' id='textArticle_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Color' readonly value='' id='textColor_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Color_Id' id='hdnColor_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Brand' readonly value='' id='textBrand_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Category' readonly value='' id='textCategory_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].SubCategory' readonly value='' id='textSub_Category_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].SubCategory_Id' id='hdnSubCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Size_Group_Name' readonly value='' id='textSize_Group_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Size_Group_Id' id='hdnSize_Group_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Size_Name' readonly value='' id='textSize_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Size_Id' id='hdnSize_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm validate' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Quantity' value='1'  onblur='Add_Validation(" + i + "); CalculateTotal()' id='textQuantity_" + i + "'>";
    //tblHtml += "<input class='form-control input-sm' type='hidden' name='' id='hdnQuantity_" + i + "' value='' /> ";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].WSR_Price' readonly value='0' id='textWSR_Price_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Amount' readonly value='0' id='textAmount_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='addrow-Return-details' class='btn btn-success active' onclick='javascript:AddPurchaseReturnRequestDetails();'>+</button>";
    tblHtml += "<button type='button' id='delete-Return-details' class='btn btn-danger active' onclick='javascript:DeletePurchaseReturnRequestDetailsData(" + i + ");'>x</button>";
    tblHtml += "</div>";
    tblHtml += "</td>";

    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);

    Add_Validation(i);
}

function DeletePurchaseReturnRequestDetailsData(i) {


    $("#tblPurchaseReturnRequestItems").find("[id='PurchaseReturnRequestItemRow_" + i + "']").remove();

    ReArrangePurchaseReturnRequestDetailsData();


    var temptablecount = $("#tblPurchaseReturnRequestItems").find('[id^="PurchaseReturnRequestItemRow_"]').size();

    x = temptablecount;


    if (x == 0) {
        AddPurchaseReturnRequestDetails();

        $("#textDiscountPercentage_0").val(0);

        CalculateTotal();

        CalculateDiscount();

        CalculateTax();
    }
    else {

        Add_Validation(i);

        CalculateTotal();

        CalculateDiscount();

        CalculateTax();
    }


}

function ReArrangePurchaseReturnRequestDetailsData() {

    $("#tblPurchaseReturnRequestItems").find("[id^='PurchaseReturnRequestItemRow_']").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'PurchaseReturnRequestItemRow_' + i

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='textBarcode_No_']").length > 0) {
                $(newTR).find("[id^='textBarcode_No_']")[0].id = "textBarcode_No_" + i;
                $(newTR).find("[id^='textBarcode_No_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Barcode");
            }

            if ($(newTR).find("[id^='textSKU_No_']").length > 0) {
                $(newTR).find("[id^='textSKU_No_']")[0].id = "textSKU_No_" + i;
                $(newTR).find("[id^='textSKU_No_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].SKU_Code");
                //$(newTR).find("[id^='textSKU_No_']").attr("onchange", "javascript:Get_Purchase_Return_Items_By_SKU_Code(" + i + ")");
                $(newTR).find("[id^='hdnSKU_No_']").attr("onchange", "javascript:Get_Purchase_Return_Items_By_SKU_Code(" + i + ")");
                $(newTR).find("[id^='hdnQuantity_']")[0].id = "hdnQuantity_" + i;
            }

            if ($(newTR).find("[id^='textArticle_No_']").length > 0) {
                $(newTR).find("[id^='textArticle_No_']")[0].id = "textArticle_No_" + i;
                $(newTR).find("[id^='textArticle_No_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Article_No");
            }

            if ($(newTR).find("[id^='hdnColor_Id_']").length > 0) {
                $(newTR).find("[id^='hdnColor_Id_']")[0].id = "hdnColor_Id_" + i;
                $(newTR).find("[id^='hdnColor_Id_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Color_Id");
                $(newTR).find("[id^='textColor_']")[0].id = "textColor_" + i;
                $(newTR).find("[id^='textColor_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Color");
            }

            if ($(newTR).find("[id^='hdnBrand_Id_']").length > 0) {
                $(newTR).find("[id^='hdnBrand_Id_']")[0].id = "hdnBrand_Id_" + i;
                $(newTR).find("[id^='hdnBrand_Id_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Brand_Id");
                $(newTR).find("[id^='textBrand_']")[0].id = "textBrand_" + i;
                $(newTR).find("[id^='textBrand_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Brand");
            }

            if ($(newTR).find("[id^='hdnCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnCategory_Id_']")[0].id = "hdnCategory_Id_" + i;
                $(newTR).find("[id^='hdnCategory_Id_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Category_Id");
                $(newTR).find("[id^='textCategory_']")[0].id = "textCategory_" + i;
                $(newTR).find("[id^='textCategory_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Category");
            }

            if ($(newTR).find("[id^='hdnSubCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSubCategory_Id_']")[0].id = "hdnSubCategory_Id_" + i;
                $(newTR).find("[id^='hdnSubCategory_Id_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].SubCategory_Id");
                $(newTR).find("[id^='textSub_Category_']")[0].id = "textSub_Category_" + i;
                $(newTR).find("[id^='textSub_Category_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].SubCategory");
            }

            if ($(newTR).find("[id^='hdnSize_Group_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSize_Group_Id_']")[0].id = "hdnSize_Group_Id_" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Size_Group_Id");
                $(newTR).find("[id^='textSize_Group_Name_']")[0].id = "textSize_Group_Name_" + i;
                $(newTR).find("[id^='textSize_Group_Name_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Size_Group_Name");
            }

            if ($(newTR).find("[id^='hdnSize_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSize_Id_']")[0].id = "hdnSize_Id_" + i;
                $(newTR).find("[id^='hdnSize_Id_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Size_Id");
                $(newTR).find("[id^='textSize_Name_']")[0].id = "textSize_Name_" + i;
                $(newTR).find("[id^='textSize_Name_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Size_Name");
            }


            if ($(newTR).find("[id^='textQuantity_']").length > 0) {
                $(newTR).find("[id^='textQuantity_']")[0].id = "textQuantity_" + i;
                $(newTR).find("[id^='textQuantity_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Quantity");
                $(newTR).find("[id^='textQuantity_']").attr("onblur", "Add_Validation(" + i + ");");
            }

            if ($(newTR).find("[id^='textWSR_Price_']").length > 0) {
                $(newTR).find("[id^='textWSR_Price_']")[0].id = "textWSR_Price_" + i;
                $(newTR).find("[id^='textWSR_Price_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].WSR_Price");
            }


            if ($(newTR).find("[id^='textAmount_']").length > 0) {
                $(newTR).find("[id^='textAmount_']")[0].id = "textAmount_" + i;
                $(newTR).find("[id^='textAmount_']").attr("name", "PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Amount");
            }

            if ($(newTR).find("[id='delete-Return-details']").length > 0) {
                $(newTR).find("[id='delete-Return-details']").attr("onclick", "DeletePurchaseReturnRequestDetailsData(" + i + ")");
            }
        }
    });
}

function CalculateTotal() {

    var sumQuantity = 0;
    var sumWSRAmount = 0;

    var tr = $("#tblPurchaseReturnRequestItems").find('[id^="PurchaseReturnRequestItemRow_"]');

    if (tr.size() > 0) {
        for (var i = 0; i < tr.size() ; i++) {

            if ($('[id="textQuantity_' + i + '"]').val() != 0 && $('[id="textQuantity_' + i + '"]').val() != '') {

                var Qty = parseFloat($("#tblPurchaseReturnRequestItems").find('[id="textQuantity_' + i + '"]').val());

                //Added by vinod mane on 12/10/2016
                var Qty = $("#tblPurchaseReturnRequestItems").find('[id="textQuantity_' + i + '"]').val();

                if (Qty == "" || Qty == "NaN") {
                    Qty = 1;
                    $('#textQuantity_' + i).val(1);
                }
                //End


                var WSR = ""
                if ($("#tblPurchaseReturnRequestItems").find('[id="textWSR_Price_' + i + '"]').val() == "" || $("#tblPurchaseReturnRequestItems").find('[id="textWSR_Price_' + i + '"]').val() == undefined) {
                    WSR = 0;
                }
                else {
                    WSR = parseFloat($("#tblPurchaseReturnRequestItems").find('[id="textWSR_Price_' + i + '"]').val());
                }

                var Amount = parseFloat(WSR * Qty);
                $("#tblPurchaseReturnRequestItems").find('[id="textAmount_' + i + '"]').val(Amount);

                sumQuantity = sumQuantity + Qty;
                sumWSRAmount = sumWSRAmount + Amount;

            }

        }
    }

    $("#textTotalQuantity_0").val(sumQuantity);
    $("#textTotalAmount_0").val(sumWSRAmount.toFixed(2));

    CalculateDiscount();
}

function CalculateDiscount() {

    var netAmt = 0;
   
    //var discount = parseFloat($("#textDiscountPercentage_0").val());//Commented by vinod mane on 12/10/2016

    //Added by vinod mane on 12/10/2016
    var discount = $("#textDiscountPercentage_0").val();

    if (discount == "" ||discount == "NaN") {
        discount = 0;
        $("#textDiscountPercentage_0").val(0);
    }
    //End
    var sumtotalAmount = parseFloat($("#textTotalAmount_0").val());

    var discountAmt = (discount == "" || discount == undefined) ? 0 : parseFloat((sumtotalAmount * discount) / 100);
    $("#textDiscountAmount_0").val(discountAmt);

    var grossAmt = sumtotalAmount - discountAmt;

    $("#textGrossAmount_0").val(grossAmt.toFixed(2));

    $("#textGrossAmount_0").trigger('change');
    
    CalculateTax();

}

function CalculateTax() {
    
    var netAmt = 0;

    var tax = parseFloat($("#textTaxPercentage_0").val());
    var sumGrossAmount = parseFloat($("#textGrossAmount_0").val());

    var taxAmt = (tax == "" || tax == undefined) ? 0 : parseFloat((sumGrossAmount * tax) / 100);
    //$("#tblPurchaseReturnRequestItems").find("textTaxAmount_0").val(taxAmt);
    $("textTaxAmount_0").val(taxAmt);


    var netAmt_temp = taxAmt + sumGrossAmount;

    var roundedDecimal = netAmt_temp.toFixed(2);

    var intPart = Math.floor(roundedDecimal);

    var fracPart = parseFloat((roundedDecimal - intPart), 2);
    //Added by vinod mane on 12/10/2016
    if (fracPart>=0.50) {
        netAmt_temp += 1;
    }
    //End

    if (fracPart == "" || fracPart == null) {
        fracPart = 0.00
    }

    var roundOff = parseFloat(netAmt_temp.toString().split(".")[1]);

    var netAmt = netAmt_temp - fracPart;

    $("#textTaxAmount_0").val(taxAmt.toFixed(2));

    $("#textRoundOff_0").val(fracPart.toFixed(2));

    $("#textNETAmount_0").val(Math.round(netAmt));


}

function Get_Purchase_Return_Items_By_SKU_Code(i) {

    $.ajax({

        url: "/purchase-return-request/get-purchase-return-request-item-by-sku-code",

        data: { SKU_Code: $("[name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].SKU_Code']").val(), Purchase_Invoice_Id: $("#hdf_Purchase_Invoice_Id").val() },

        method: 'POST',

        async: false,

        success: function (data) {

            $('#textArticle_No_' + i).val(data.Article_No);

            $('#textColor_' + i).val(data.Color);

            $('#hdnColor_Id_' + i).val(data.Color_Id);

            $('#textBrand_' + i).val(data.Brand);

            $('#hdnBrand_Id_' + i).val(data.Brand_Id);

            $('#textCategory_' + i).val(data.Category);

            $('#hdnCategory_Id_' + i).val(data.Category_Id);

            $('#textSub_Category_' + i).val(data.SubCategory);

            $('#hdnSubCategory_Id_' + i).val(data.SubCategory_Id);

            $('#textSize_Group_Name_' + i).val(data.Size_Group_Name);

            $('#hdnSize_Group_Id_' + i).val(data.Size_Group_Id);

            $('#textSize_Name_' + i).val(data.Size_Name);

            $('#hdnSize_Id_' + i).val(data.Size_Id);

            $('#textWSR_Price_' + i).val(data.WSR_Price);

            $('#textQuantity_' + i).val(1);
        }

    });

    $("#textDiscountPercentage_0").val(0);

    CalculateTotal();
    
}

function Get_Purchase_Return_Items_By_Barcode(i) {

    debugger;

    var barcode = $("[name='PurchaseReturnRequest.PurchaseReturnRequestItems[" + i + "].Barcode']").val().replace(/[$]/g, '-');

    $.ajax({

        url: "/purchase-return-request/get-purchase-return-request-item-by-sku-code",

        data: { SKU_Code: barcode, Purchase_Invoice_Id: $("#hdf_Purchase_Invoice_Id").val() },

        method: 'POST',

        async: false,

        success: function (data) {

            $('#textArticle_No_' + i).val(data.Article_No);

            $('#textColor_' + i).val(data.Color);

            $('#hdnColor_Id_' + i).val(data.Color_Id);

            $('#textBrand_' + i).val(data.Brand);

            $('#hdnBrand_Id_' + i).val(data.Brand_Id);

            $('#textCategory_' + i).val(data.Category);

            $('#hdnCategory_Id_' + i).val(data.Category_Id);

            $('#textSub_Category_' + i).val(data.SubCategory);

            $('#hdnSubCategory_Id_' + i).val(data.SubCategory_Id);

            $('#textSize_Group_Name_' + i).val(data.Size_Group_Name);

            $('#hdnSize_Group_Id_' + i).val(data.Size_Group_Id);

            $('#textSize_Name_' + i).val(data.Size_Name);

            $('#hdnSize_Id_' + i).val(data.Size_Id);

            $('#textWSR_Price_' + i).val(data.WSR_Price);

            $('#textQuantity_' + i).val(1);
        }

    });

    $("#textDiscountPercentage_0").val(0);

    CalculateTotal();

}

function Set_Purchase_Invoice_Id(value) {

    $('#hdf_Purchase_Invoice_Id').val(value);
}


function Add_Validation(i)
{
    //$("#tblPurchaseReturnRequestItems").find(".validate").rules("add", { QuantityCheck: false });

    $("#textQuantity_" + i).rules("add", { required: true, digits: true, QuantityCheck:true, messages: { required: "Required field", digits: "Invalid quantity." } });

    $("#hdnSKU_No_" + i).rules("add", { required: true, checkSKUExist: true, messages: { required: "SKU is Required", } });
  
    $("#textBarcode_No_" + i).rules("add", { checkBarcodeExist: true, messages: { checkBarcodeExist: "Already Mapped" } });

    jQuery.validator.addMethod("QuantityCheck", function (value, element) {

        debugger;

        var result = true;

        var id = $(element).attr('id')

        j = id.replace("textQuantity_", "");


        var EnterQty = parseInt($('[id="textQuantity_' + j + '"]').val());

        var OrgQty = parseInt($("#hdnQuantity_" + j).val());


        if (isNaN($("#hdnQuantity_" + j).val()) || $("#hdnQuantity_" + j).val() == "") {
            result = true;
        }
        else {

            if (EnterQty != "" || $('[id="textQuantity_' + j + '"]').val() != '0') {

                if (OrgQty >= EnterQty) {

                    result = true;
                }
                else {
                    result = false;
                }

            }
            else {
                result = false;
            }
        }

        return result;

    }, "Quantity less than Invoice Quantity And Not Zero.");


}