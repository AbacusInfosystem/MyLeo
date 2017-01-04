function Get_Customer_Name_By_Mobile_No() {
    debugger;

    $.ajax({

        url: "/SalesOrder/Get_Customer_Name_By_Mobile_No",

        data: { MobileNo: $("#txtMobileNo").val() },

        method: 'GET',

        async: false,

        success: function (data) {
            $('#txtCustomer_Name').val(data.Customer_Name);

            $('#hdnCustomer_ID').val(data.Customer_Id);



            if (data.Customer_Name == null) {
                $('#myModalAddCustomer').modal('show');
            }

            Get_Credit_Note_Data_By_Id(data.Customer_Id);
        }
    });
}

function Get_Sales_Order_Items_By_SKU_Code(i) {

    $.ajax({

        url: "/SalesOrder/Get_Sales_Order_Items_By_SKU_Code",

        data: { SKU_Code: $("[name='SaleOrderItemList[" + i + "].SKU_Code']").val() },

        method: 'GET',

        async: false,

        success: function (data) {

            $('#textArticle_No_' + i).val(data.Article_No);

            $('#textBrand_' + i).val(data.Brand);

            $('#textCategory_' + i).val(data.Category);

            $('#textSub_Category_' + i).val(data.SubCategory);

            $('#textSize_Name_' + i).val(data.Size_Name);

            $('#textColour_Name_' + i).val(data.Colour_Name);

            $('#textMRP_Price_' + i).val(data.MRP_Price);

        }
    });
}

function Get_Sales_Order_Items_By_Barcode(i) {

    debugger;

    var Skucode = $("[name='SaleOrderItemList[" + i + "].Barcode']").val().replace(/[$]/g, '-');

    var Final = Skucode.split("+");

    var SKU = Final[0];

    $.ajax({

        url: "/SalesOrder/Get_Sales_Order_Items_By_Barcode",

        data: { Barcode: SKU },

        method: 'GET',

        async: false,

        success: function (data) {

            $('#textArticle_No_' + i).val(data.Article_No);

            $('#textSKU_No_' + i).val(data.SKU_Code);

            $('#textBrand_' + i).val(data.Brand);

            $('#textCategory_' + i).val(data.Category);

            $('#textSub_Category_' + i).val(data.SubCategory);

            $('#textSize_Name_' + i).val(data.Size_Name);

            $('#textColour_Name_' + i).val(data.Colour_Name);

            $('#textMRP_Price_' + i).val(data.MRP_Price);

            $("#SKU_" + i).find(".autocomplete-text").trigger("focusout");

        }
    });

    CalculateTotal();

    AddSalesOrderDetails();
}

function Get_Credit_Note_Data_By_Id(id) {


    var dd = $("#drpCredit_Note_No");

    var cust_Id = id;

    var urls = "/SalesOrder/Get_Credit_Note_Details_By_Id_abc?cust_Id=" + cust_Id;

    $.ajax({


        url: urls,

        // data: parseInt(cust_Id),//JSON.stringify(siViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (data) {

            if (data != null) {

                dd.html("");

                dd.append('<option value="0" > Select Credit Note no </option>');

                for (var i = 0; i < data.length; i++) {

                    dd.append('<option value="' + data[i].Credit_Note_Id + '" >' + data[i].Credit_Note_No + '</option>');
                }
            }
        }
    });

}

function Get_Gift_Voucher_Details() {
    debugger;

    var dd = $("#drpGift_Voucher_No");

    var siViewModel =
        {
        }

    $.ajax({

        url: "/SalesOrder/Get_Gift_Voucher_Details",

        data: JSON.stringify(siViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (data) {

            if (data != null) {
                for (var i = 0; i < data.length; i++) {
                    dd.append('<option value="' + data[i].Gift_Voucher_Id + '" >' + data[i].Gift_Voucher_No + '</option>');
                }
            }
        }
    });

}

function Get_Credit_Note_Amount_By_Id(id) {


    var siViewModel =
        {
            SalesInvoice: {

                Sales_Credit_Note_Id: id
            }
        }

    $.ajax({

        url: "/SalesOrder/Get_Credit_Note_Amount_By_Id",

        data: JSON.stringify(siViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (data) {

            if (data != null) {

                debugger;

                $('#txtCredit_Note_Amount').val(data[0].Credit_Note_Amount);

                //$('#dtpCreditNoteDate').val(data[0].Credit_Note_Date);

                var dd1 = new Date(parseInt(data[0].Credit_Note_Date.replace('/Date(', '')));

                $('#dtpCreditNoteDate').val(dd1.getDate().toString() + '-' + (dd1.getMonth() + 1).toString() + '-' + dd1.getFullYear().toString());

                $("[name='SalesInvoice.Credit_Note_Amount']").focus();

                $("[name='SalesInvoice.Credit_Note_Amount']").blur();

            }

        }
    });
}

function Get_Gift_Voucher_Amount_By_Id(id) {


    var siViewModel =
        {
            SalesInvoice: {

                Gift_Voucher_Id: id
            }
        }

    $.ajax({

        url: "/SalesOrder/Get_Gift_Voucher_Amount_By_Id",

        data: JSON.stringify(siViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("[name='SalesInvoice.Gift_Voucher_Amount']").val(obj.SalesInvoice.Gift_Voucher_Amount);

            $("[name='SalesInvoice.Gift_Voucher_No']").val(obj.SalesInvoice.Gift_Voucher_No);

            $("[name='SalesInvoice.Gift_Voucher_Amount']").focus();

            $("[name='SalesInvoice.Gift_Voucher_Amount']").blur();

        }
    });
}

function AddSalesOrderDetails() {

    var html = '';

    var tblHtml = '';

    var myTable = $("#tblSalesOrderItems");

    //var temptablecount = $("#tblSalesOrderItems tr").length;

    var temptablecount = $("#tblSalesOrderItems").find('[id^="SalesOrderItemRow_"]').size();

    i = temptablecount;//-1;

    tblHtml += "<tr id='SalesOrderItemRow_" + i + "' class='item-data-row'>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm barcode' placeholder='' name='SaleOrderItemList[" + i + "].Barcode' onchange='javascript: Get_Sales_Order_Items_By_Barcode(" + i + ");' value='' id='textBarcode_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group auto-complete'>";
    tblHtml += "<div id='SKU_" + i + "' class='input-group'>";
    tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text lookup-text' id='textSKU_No_" + i + "' placeholder='SKU Code' value=''  data-table='Inventorys' data-col='Branch_Id,Product_SKU' data-headernames='SKU_Code' name='SaleOrderItemList[" + i + "].SKU_Code' data-param='hdnBranchID' data-field='Branch_Id'/>";
    tblHtml += "<span class='input-group-addon'><a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    tblHtml += "<input type='hidden' id='hdnProduct_Id_" + i + "'  onchange='javascript:Get_Sales_Order_Items_By_SKU_Code(" + i + ");' value='' class='auto-complete-value'/>";
    //tblHtml += "<input type='hidden' id='hdnBranchID_" + i + "' value='' name='SalesInvoice.Branch_Id' />";
    tblHtml += "<input type='hidden' id='hdnSKU_No_" + i + "' value='' class='auto-complete-label' />";
    tblHtml += "</div>";
    tblHtml += "</div>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm'  placeholder='Article No' name='SaleOrderItemList[" + i + "].Article_No' readonly value='' id='textArticle_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Brand' name='SaleOrderItemList[" + i + "].Brand' readonly value='' id='textBrand_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleOrderItemList[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Category' name='SaleOrderItemList[" + i + "].Category' readonly value='' id='textCategory_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleOrderItemList[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='SubCategory' name='SaleOrderItemList[" + i + "].SubCategory' readonly value='' id='textSub_Category_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleOrderItemList[" + i + "].SubCategory_Id' id='hdnSubCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Size' name='SaleOrderItemList[" + i + "].Size_Name' readonly value='' id='textSize_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleOrderItemList[" + i + "].Size_Id' id='hdnSize_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Colour' name='SaleOrderItemList[" + i + "].Colour_Name' readonly value='' id='textColour_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleOrderItemList[" + i + "].Colour_Id' id='hdnColour_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='MRP' name='SaleOrderItemList[" + i + "].MRP_Price' readonly value='' id='textMRP_Price_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Quantity' name='SaleOrderItemList[" + i + "].Quantity' value='1' onblur='javascript: CalculateQuantityMRP();' id='textQuantity_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Disc %' name='SaleOrderItemList[" + i + "].Discount_Percentage' value='0'  onblur='javascript: CalculateTotal();' id='textDiscount_Percentage_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='D Amt' name='SaleOrderItemList[" + i + "].SalesOrder_Discount_Amount' readonly value='0' id='textSalesOrder_Discount_Amount_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' placeholder='Amt' name='SaleOrderItemList[" + i + "].Amount' readonly value='' id='textAmount_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group auto-complete'>";
    tblHtml += "<div class='input-group'>";
    tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' name='SaleOrderItemList[" + i + "].SalesMan' id='textSalesMan_" + i + "' placeholder='Enter SalesMan' value='' data-table='Employee' data-col='Employee_Id,Employee_Name' data-headernames='Employee' data-param='hdnEmployee_Id' data-field='Sales_Invoice'>";
    tblHtml += "<span class='input-group-addon'> <a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    tblHtml += "<input type='hidden' id='hdnSalesManId_" + i + "' value='' name='SaleOrderItemList[" + i + "].SalesMan_Id' class='auto-complete-value'/>";
    tblHtml += "<input type='hidden' id='hdnSalesMan_" + i + "' value='' name='SaleOrderItemList[" + i + "].SalesMan' class='auto-complete-label' />";
    tblHtml += "</div>";
    tblHtml += "</div>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='btnAddInputRow' class='btn btn-success active' onclick='javascript:AddSalesOrderDetails();'>+</button>";
    tblHtml += "<button type='button' id='delete-salesorder-details' class='btn btn-danger active' onclick='javascript:DeleteSalesOrderDetailsData(" + i + ")'>x</button>";
    tblHtml += "</div>";
    tblHtml += "</td>";

    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);

    Add_Validation(i);

}

function DeleteSalesOrderDetailsData(i) {


    //Added by vinod mane on 14/10/2016 //Updated by Kunal on 21/10/2016.
    $("#tblSalesOrderItems").find("[id='SalesOrderItemRow_" + i + "']").remove();
    if (i == 0) {
        $('#textTaxPercentage_0').val(0);
        AddSalesOrderDetails();
        ReArrangeSalesOrderDetailsData();
        CalculateQuantityMRP();
        CalculateTotal();
        CalculateTax();
    } else {
        ReArrangeSalesOrderDetailsData();
        CalculateQuantityMRP();
        CalculateTotal();
        CalculateTax();
    }

    //ReArrangeSalesOrderDetailsData();

    //if (i == 0) {
    //    AddSalesOrderDetails(i);

    //    //  $("#textDiscountPercentage_0").val(0);

    //    CalculateTotal();

    //    CalculateTax();
    //}
    //else {

    //    Add_Validation(i);

    //    CalculateTotal();

    //    // CalculateDiscount();

    //    CalculateTax();
    //}
    //End


}

function ReArrangeSalesOrderDetailsData() {

    $("#tblSalesOrderItems").find("[id^='SalesOrderItemRow_']").each(function (i, row) {

        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'SalesOrderItemRow_' + i;

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='textBarcode_No_']").length > 0) {
                $(newTR).find("[id^='textBarcode_No_']")[0].id = "textBarcode_No_" + i;
                $(newTR).find("[id^='textBarcode_No_']").attr("name", "SaleOrderItemList[" + i + "].Barcode", "onchange", "javascript: Get_Sales_Order_Items_By_Barcode(" + i + ")");
            }

            if ($(newTR).find("[id^='textSKU_No_']").length > 0) {
                $(newTR).find("[id^='textSKU_No_']")[0].id = "textSKU_No_" + i;
                $(newTR).find("[id^='textSKU_No_']").attr("name", "SaleOrderItemList[" + i + "].SKU_Code");
                $(newTR).find("[id^='hdnProduct_Id_']").attr("onchange", "javascript: Get_Sales_Order_Items_By_SKU_Code(" + i + ")");
                $(newTR).find("[id^='hdnProduct_Id_']")[0].id = "hdnProduct_Id_" + i;
                $(newTR).find("[id^='hdnSKU_No_']")[0].id = "hdnSKU_No_" + i;
                //$(newTR).find("[id^='hdnSKU_No_']").attr("name", "SaleOrderItemList[" + i + "].SKU_Code");
                $(newTR).find("[id^='SKU_']")[0].id = "SKU_" + i;
            }

            if ($(newTR).find("[id^='textArticle_No_']").length > 0) {
                $(newTR).find("[id^='textArticle_No_']")[0].id = "textArticle_No_" + i;
                $(newTR).find("[id^='textArticle_No_']").attr("name", "SaleOrderItemList[" + i + "].Article_No");
            }

            if ($(newTR).find("[id^='hdnBrand_Id_']").length > 0) {
                $(newTR).find("[id^='hdnBrand_Id_']")[0].id = "hdnBrand_Id_" + i;
                $(newTR).find("[id^='hdnBrand_Id_']").attr("name", "SaleOrderItemList[" + i + "].Brand_Id");
                $(newTR).find("[id^='textBrand_']")[0].id = "textBrand_" + i;
                $(newTR).find("[id^='textBrand_']").attr("name", "SaleOrderItemList[" + i + "].Brand");
            }

            if ($(newTR).find("[id^='hdnCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnCategory_Id_']")[0].id = "hdnCategory_Id_" + i;
                $(newTR).find("[id^='hdnCategory_Id_']").attr("name", "SaleOrderItemList[" + i + "].Category_Id");
                $(newTR).find("[id^='textCategory_']")[0].id = "textCategory_" + i;
                $(newTR).find("[id^='textCategory_']").attr("name", "SaleOrderItemList[" + i + "].Category");
            }

            if ($(newTR).find("[id^='hdnSubCategory_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSubCategory_Id_']")[0].id = "hdnSubCategory_Id_" + i;
                $(newTR).find("[id^='hdnSubCategory_Id_']").attr("name", "SaleOrderItemList[" + i + "].SubCategory_Id");
                $(newTR).find("[id^='textSub_Category_']")[0].id = "textSub_Category_" + i;
                $(newTR).find("[id^='textSub_Category_']").attr("name", "SaleOrderItemList[" + i + "].SubCategory");
            }


            if ($(newTR).find("[id^='hdnSize_Id_']").length > 0) {
                $(newTR).find("[id^='hdnSize_Id_']")[0].id = "hdnSize_Id_" + i;
                $(newTR).find("[id^='hdnSize_Id_']").attr("name", "SaleOrderItemList[" + i + "].Size_Id");
                $(newTR).find("[id^='textSize_Name_']")[0].id = "textSize_Name_" + i;
                $(newTR).find("[id^='textSize_Name_']").attr("name", "SaleOrderItemList[" + i + "].Size_Name");
            }

            if ($(newTR).find("[id^='hdnColour_Id_']").length > 0) {
                $(newTR).find("[id^='hdnColour_Id_']")[0].id = "hdnColour_Id_" + i;
                $(newTR).find("[id^='hdnColour_Id_']").attr("name", "SaleOrderItemList[" + i + "].Colour_Id");
                $(newTR).find("[id^='textColour_Name_']")[0].id = "textColour_Name_" + i;
                $(newTR).find("[id^='textColour_Name_']").attr("name", "SaleOrderItemList[" + i + "].Colour_Name");
            }


            if ($(newTR).find("[id^='textQuantity_']").length > 0) {
                $(newTR).find("[id^='textQuantity_']")[0].id = "textQuantity_" + i;
                $(newTR).find("[id^='textQuantity_']").attr("name", "SaleOrderItemList[" + i + "].Quantity");

            }

            if ($(newTR).find("[id^='textMRP_Price_']").length > 0) {
                $(newTR).find("[id^='textMRP_Price_']")[0].id = "textMRP_Price_" + i;
                $(newTR).find("[id^='textMRP_Price_']").attr("name", "SaleOrderItemList[" + i + "].MRP_Price");
            }

            if ($(newTR).find("[id^='textDiscount_Percentage_']").length > 0) {
                $(newTR).find("[id^='textDiscount_Percentage_']")[0].id = "textDiscount_Percentage_" + i;
                $(newTR).find("[id^='textDiscount_Percentage_']").attr("name", "SaleOrderItemList[" + i + "].Discount_Percentage");
            }

            if ($(newTR).find("[id^='textSalesOrder_Discount_Amount_']").length > 0) {
                $(newTR).find("[id^='textSalesOrder_Discount_Amount_']")[0].id = "textSalesOrder_Discount_Amount_" + i;
                $(newTR).find("[id^='textSalesOrder_Discount_Amount_']").attr("name", "SaleOrderItemList[" + i + "].SalesOrder_Discount_Amount");
            }


            if ($(newTR).find("[id^='textAmount_']").length > 0) {
                $(newTR).find("[id^='textAmount_']")[0].id = "textAmount_" + i;
                $(newTR).find("[id^='textAmount_']").attr("name", "SaleOrderItemList[" + i + "].Amount");
            }


            if ($(newTR).find("[id^='textSalesMan_']").length > 0) {
                $(newTR).find("[id^='textSalesMan_']")[0].id = "textSalesMan_" + i;
                $(newTR).find("[id^='textSalesMan_']").attr("name", "SaleOrderItemList[" + i + "].SalesMan");
                $(newTR).find("[id^='hdnSalesManId_']")[0].id = "hdnSalesManId_" + i;
                $(newTR).find("[id^='hdnSalesManId_']").attr("name", "SaleOrderItemList[" + i + "].SalesMan_Id");
                $(newTR).find("[id^='hdnSalesMan_']")[0].id = "hdnSalesMan_" + i;
                $(newTR).find("[id^='hdnSalesMan_']").attr("name", "SaleOrderItemList[" + i + "].SalesMan");

            }

            if ($(newTR).find("[id='delete-salesorder-details']").length > 0) {
                $(newTR).find("[id='delete-salesorder-details']").attr("onclick", "DeleteSalesOrderDetailsData(" + i + ")");
            }
        }

    });
}

function Add_Validation(i) {

   // alert(i);

    $("#textQuantity_" + i).rules("add", { required: true, QuantityCheck: true, digits: true, messages: { required: "Quantity", digits: "Invalid Quantity." } });

    //$("#textSKU_No_" + i).rules("add", { checkSKUExist: true});

    $("#textBarcode_No_" + i).rules("add", { checkBarcodeExist: true, messages: {checkBarcodeExist:"Already Mapped"}});

    $("#textSalesMan_" + i).rules("add", { required: true, messages: { required: "SalesMan" } });

    $("#textDiscount_Percentage_" + i).rules("add", { required: true, digits: true, messages: { required: "Discount", digits: "Invalid Discount." } });

}

function CalculateQuantityMRP() {
    debugger;

    var sumQuantity = 0;
    var sumMRPAmount = 0;
    //var mrpAmt = 0;

    var tr = $("#tblSalesOrderItems").find('[id^="SalesOrderItemRow_"]');

    if (tr.size() > 0) {
        for (var i = 0; i < tr.size() ; i++) {
            
            //Added by vinod mane on 12/10/2016
            var Qty = $("#tblSalesOrderItems").find('[id="textQuantity_' + i + '"]').val();

            if (Qty == "" || Qty == "NaN") {
                Qty = 0;
                $('#textQuantity_' + i).val(0);
            }
            //End
            var MRP = parseFloat($("#tblSalesOrderItems").find('[id="textMRP_Price_' + i + '"]').val());

            //Added by vinod mane on 12/10/2016
            var MRP = $("#tblSalesOrderItems").find('[id="textMRP_Price_' + i + '"]').val();

            if (MRP == "" || MRP == "NaN") {
                MRP = 0;
                $('#textMRP_Price_' + i).val(0);
            }
            //End 

            //mrpAmt = Qty * MRP

            sumQuantity = parseFloat(sumQuantity) + parseFloat(Qty);
            sumMRPAmount = parseFloat(MRP) + parseFloat(sumMRPAmount);

        } 
    } 
    $("#textTotalQuantity_0").val(sumQuantity);
    $("#textMRPAmount_0").val(sumMRPAmount.toFixed(2));
    CalculateTotal();
}

function CalculateTotal() {

    var sumQuantity = 0;
    var sumMRPAmount = 0;
    var sumDiscountAmount = 0;
    var sumGrossAmount = 0;

    var tr = $("#tblSalesOrderItems").find('[id^="SalesOrderItemRow_"]');


    if (tr.size() > 0) {
        for (var i = 0; i < tr.size() ; i++) {
            var Qty = parseFloat($("#tblSalesOrderItems").find('[id="textQuantity_' + i + '"]').val());

            //Added by vinod mane on 12/10/2016
            var Qty = $("#tblSalesOrderItems").find('[id="textQuantity_' + i + '"]').val();
            if (Qty == "" || Qty == "NaN") {
                Qty = 0;
                $('#textQuantity_' + i).val(0);
            }
            //End
            var MRP = parseFloat($("#tblSalesOrderItems").find('[id="textMRP_Price_' + i + '"]').val());
            //var Discount = parseFloat($("#tblSalesOrderItems").find('[id="textDiscount_Percentage_' + i + '"]').val());

            //Added by vinod mane on 12/10/2016
            var Discount = $("#tblSalesOrderItems").find('[id="textDiscount_Percentage_' + i + '"]').val();
            if (Discount == "" || Discount == "NaN") {
                Discount = 0;
                $('#textDiscount_Percentage_' + i).val(0);
            }
            //End

            var DiscountAmt = (Discount == "" || Discount == undefined) ? 0 : parseFloat((Qty * MRP * Discount) / 100);
            $("#tblSalesOrderItems").find('[id="textSalesOrder_Discount_Amount_' + i + '"]').val(DiscountAmt);
            var Amount = parseFloat(MRP * Qty - DiscountAmt);
            $("#tblSalesOrderItems").find('[id="textAmount_' + i + '"]').val(Amount);

            sumQuantity = parseFloat(sumQuantity) + parseFloat(Qty);
            sumMRPAmount = MRP + sumMRPAmount;
            sumDiscountAmount = sumDiscountAmount + DiscountAmt;
            sumGrossAmount = sumGrossAmount + Amount;

        }
    }

    $("#textTotalQuantity_0").val(sumQuantity);
    $("#textMRPAmount_0").val(sumMRPAmount.toFixed(2));
    $("#textDiscountAmount_0").val(sumDiscountAmount.toFixed(2));
    $("#textGrossAmount_0").val(sumGrossAmount.toFixed(2));
      
    CalculateTax();
}

function CalculateTax() {

    var netAmt = 0; 

    //Added by vinod mane on 12/10/2016
    var tax = $("#textTaxPercentage_0").val();

    if (tax == "" || tax == "NaN") {
        tax = 0;
        $('#textTaxPercentage_0').val(0);
    }
    //End
    var sumGrossAmount = parseFloat($("#textGrossAmount_0").val());


    var taxAmt = (tax == "" || tax == undefined) ? 0 : parseFloat((sumGrossAmount * tax) / 100);
    $("#tblSalesOrderItems").find("textTaxAmount_0").val(taxAmt);

    var netAmt_temp = taxAmt + sumGrossAmount;

    var roundedDecimal = netAmt_temp.toFixed(2);

    var intPart = Math.floor(roundedDecimal);

    var fracPart = parseFloat((roundedDecimal - intPart), 2);
    //Added by vinod mane on 12/10/2016
    if (fracPart >= 0.50) {
        netAmt_temp += 1;
    }
    //End
    var roundOff = parseFloat(netAmt_temp.toString().split(".")[1]);

    var netAmt = netAmt_temp - fracPart;

    //var netAmt = Math.round(0.2);

    $("#textTaxAmount_0").val(taxAmt.toFixed(2));
    $("#textRoundOff_0").val(fracPart.toFixed(2));
    $("#textNETAmount_0").val(Math.round(netAmt));
    $("#textTotalAmount").val(Math.round(netAmt));


}

function CalculateDiscountAmount() {
    var tr = $("#tblSalesOrderItems").find('[id^="SalesOrderItemRow_"]');

    if (tr.size() > 0) {
        for (var i = 0; i < tr.size() ; i++) {

            var Qty = parseFloat($("#tblSalesOrderItems").find('[id="textQuantity_' + i + '"]').val());
            var MRP = parseFloat($("#tblSalesOrderItems").find('[id="textMRP_Price_' + i + '"]').val());

            var Discount = parseFloat($("#tblSalesOrderItems").find('[id="textDiscount_Percentage_' + i + '"]').val());
            var DiscountAmt = (Discount == "" || Discount == undefined) ? 0 : parseFloat((Qty * MRP * Discount) / 100);
            $("#tblSalesOrderItems").find('[id="textSalesOrder_Discount_Amount_' + i + '"]').val(DiscountAmt);

        }
    }
}

function CalculatePaidAmt() {

    debugger;

    // alert();

    var oldbalanceamount = parseFloat($("#txtBalance_Amount").val());

    var chequeamount = parseFloat($("#txtCheque_Amount").val());

    var cashamount = parseFloat($("#txtCash_amount").val());

    var creditnoteamount = parseFloat($("#txtCredit_Note_Amount").val());

    var giftvoucheramount = parseFloat($("#txtGift_Voucher_Amount").val());

    var cardamount = parseFloat($("#txtCard_Amount").val());

    if (cashamount == 0) {

        paidamount = chequeamount + creditnoteamount + giftvoucheramount + cardamount;
    }

    else if (chequeamount == 0) {
        paidamount = cashamount + creditnoteamount + giftvoucheramount + cardamount;
    }

    else if (creditnoteamount == 0) {

        paidamount = cashamount + chequeamount + giftvoucheramount + cardamount;
    }

    else if (giftvoucheramount == 0) {

        paidamount = cashamount + chequeamount + creditnoteamount + cardamount;
    }

    else {

        paidamount = cashamount + chequeamount + creditnoteamount + giftvoucheramount + cardamount;
    }

    // var paidamount = chequeamount + cashamount + creditnoteamount + giftvoucheramount + cardamount;

    $("#txtPaid_Amount").val(paidamount.toFixed(2));

    //var newbalanceamount = oldbalanceamount - paidamount;

    //$("#txtBalance_Amount").val(newbalanceamount.toFixed(2));


}

function CalculateBalAmt() {
    var oldbalanceamount = parseFloat($("#textTotalAmount").val());

    $("#txtPaid_Amount").val(paidamount.toFixed(2));

    var newbalanceamount = oldbalanceamount - paidamount;

    $("#txtBalance_Amount").val(newbalanceamount.toFixed(2));

}

function calculate() {

    //var cash = 0;
    //var credit = 0;
    //var card = 0;
    //var gift = 0;
    //var check = 0;
    var total_amt = parseInt($("#textTotalAmount").val());
    var paid_amt = parseInt($("#txtPaid_Amount").val());
    var cashamt = parseInt($("#txtCash_amount").val());
    var chequeamt = parseInt($("#txtCheque_Amount").val());
    var crdnoteamt = parseInt($("#txtCredit_Note_Amount").val());
    var cardamt = parseInt($("#txtCard_Amount").val());
    var gift_amt = parseInt($("#txtGift_Voucher_Amount").val());

    if (isNaN(cashamt))
        cashamt = 0;
    if (isNaN(chequeamt))
        chequeamt = 0;
    if (isNaN(crdnoteamt))
        crdnoteamt = 0;
    if (isNaN(cardamt))
        cardamt = 0;
    if (isNaN(gift_amt))
        gift_amt = 0;
    if (isNaN(total_amt))
        total_amt = 0;
    if (isNaN(paid_amt))
        paid_amt = 0;


    //if ($("#txtCash_amount").val() != "") {
    //    cash = $("#txtCash_amount").val()
    //}

    //if ($("#txtCheque_Amount").val() != "") {
    //    credit = $("#txtCheque_Amount").val()
    //}

    //if ($("#txtCredit_Note_Amount").val() != "") {
    //    card = $("#txtCredit_Note_Amount").val()
    //}

    //if ($("#txtCard_Amount").val() != "") {
    //    gift = $("#txtCard_Amount").val()
    //}

    //if ($("#txtGift_Voucher_Amount").val() != "") {
    //    check = $("#txtGift_Voucher_Amount").val()
    //}


    $("#txtPaid_Amount").val(cashamt + chequeamt + crdnoteamt + cardamt + gift_amt);
    paid_amt = cashamt + chequeamt + crdnoteamt + cardamt + gift_amt;

    $("#txtBalance_Amount").val(total_amt - paid_amt);
    //$("#txtPaid_Amount").val(parseInt(cash) + parseInt(credit) + parseInt(card) + parseInt(gift) + parseInt(check));


}

function Reset_Sales_Order()
{
    var temptablecount = $("#tblSalesOrderItems").find('[id^="SalesOrderItemRow_"]').size();

    $("#hdnBranchID").parents('.form-group').find('#lookupUlLookup').remove();

    $("#hdnBranchID").val("");

    $("#hdnBranchName").val("");

    for (var i = 0; i < temptablecount; i++) {             


        $("#hdnSalesManId_" + i).val("");

        $("#hdnProduct_Id_" + i).val("");

        $("#hdnSKU_No_" + i).val("");

        $("#hdnSalesMan_" + i).val("");

        $("#hdnSalesManId_" + i).parents('.form-group').find('#lookupUlLookup').remove();

        $("#hdnProduct_Id_" + i).parents('.form-group').find('#lookupUlLookup').remove();

    }
}

