function Get_Customer_Name_By_Mobile_No()
{
    debugger;

    $.ajax({

        url: "/SalesOrder/Get_Customer_Name_By_Mobile_No",

        data: {MobileNo : $("[name='SalesInvoice.Mobile']").val()},

        method: 'GET',

        async: false,

        success: function (data)
        {
            $('#txtCustomer_Name').val(data.Customer_Name);

            $('#hdnCustomer_ID').val(data.Customer_Id);

         

            if (data.Customer_Name == null)
            {
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

        success: function (data)
        {

            $('#textArticle_No_'+i).val(data.Article_No);

            $('#textBrand_'+i).val(data.Brand);

            $('#textCategory_'+i).val(data.Category);

            $('#textSub_Category_'+i).val(data.SubCategory);

            $('#textSize_Name_' + i).val(data.Size_Name);

            $('#textColour_Name_' + i).val(data.Colour_Name);

            $('#textMRP_Price_'+i).val(data.MRP_Price);

        }
    });
}

function Get_Credit_Note_Data_By_Id(id) {

    //debugger;

    //var dd = $("#drpCredit_Note_No");

    //var siViewModel =
    //    {
    //        SalesInvoice: {

    //            Customer_Id: id
    //        }
    //    }

    //$.ajax({

    //    url: "/SalesOrder/Get_Credit_Note_Data_By_Id",

    //    data: JSON.stringify(siViewModel),

    //    dataType: 'json',

    //    type: 'POST',

    //    contentType: 'application/json',

    //    success: function (data) {

    //        if (data != null) {
    //            for (var i = 0; i < data.length; i++) {
    //                dd.append('<option value="' + data[i].Credit_Note_Id + '" >' + data[i].Credit_Note_No + '</option>');
    //            }
    //        }
    //    }
    //});


    var dd = $("#drpCredit_Note_No");

    var cust_Id = id;

   // var siViewModel = 
        //{
        //    SalesInvoice: {

        //        Customer_Id: id
        //    }
    //}

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

function Get_Gift_Voucher_Details()
{
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

function AddSalesOrderDetails(i) 
{
    //alert(i);

    var html = '';
    
    var tblHtml = '';
    
    var myTable = $("#tblSalesOrderItems");
    
    //var temptablecount = $("#tblSalesOrderItems tr").length;

    var temptablecount = $("#tblSalesOrderItems").find('[id^="SalesOrderItemRow_"]').size();

    i = temptablecount;//-1;

    tblHtml += "<tr id='SalesOrderItemRow_"+ i +"' class='item-data-row'>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:100px' placeholder='Barcode No' name='SaleOrderItemList[" + i + "].Barcode' value='' id=textBarcode_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group auto-complete'>";
    tblHtml += "<div class='input-group'>";
    tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' style='width:150px' id='textSKU_No_" + i + "' onblur='javascript:Get_Sales_Order_Items_By_SKU_Code(" + i + ");' placeholder='SKU Code' value=''  data-table='Inventorys' data-col='Branch_Id,Product_SKU' data-headernames='SKU_Code' name='SKU_Code_" + i + "' data-param='hdnBranchID' data-field='Branch_Id'/>";
    tblHtml += "<span class='input-group-addon'><a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    tblHtml += "<input type='hidden' id='hdnProduct_Id_" + i + "' value='' class='auto-complete-value'/>";
    //tblHtml += "<input type='hidden' id='hdnBranchID_" + i + "' value='' name='SalesInvoice.Branch_Id' />";
    tblHtml += "<input type='hidden' id='hdnSKU_No_" + i + "' value='' name='SaleOrderItemList[" + i + "].SKU_Code' class='auto-complete-label' />";
    tblHtml += "</div>";
    tblHtml += "</div>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:60px' placeholder='Article No' name='SaleOrderItemList[" + i + "].Article_No' readonly value='' id='textArticle_No_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:60px' placeholder='Brand' name='SaleOrderItemList[" + i + "].Brand' readonly value='' id='textBrand_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleOrderItemList[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:80px' placeholder='Category' name='SaleOrderItemList[" + i + "].Category' readonly value='' id='textCategory_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleOrderItemList[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:100px' placeholder='SubCategory' name='SaleOrderItemList[" + i + "].SubCategory' readonly value='' id='textSub_Category_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleOrderItemList[" + i + "].SubCategory_Id' id='hdnSubCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:50px' placeholder='Size' name='SaleOrderItemList[" + i + "].Size_Name' readonly value='' id='textSize_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleOrderItemList[" + i + "].Size_Id' id='hdnSize_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:60px' placeholder='Colour' name='SaleOrderItemList[" + i + "].Colour_Name' readonly value='' id='textColour_Name_" + i + "'>";
    tblHtml += "<input type='hidden' name='SaleOrderItemList[" + i + "].Colour_Id' id='hdnColour_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:80px' placeholder='MRP' name='SaleOrderItemList[" + i + "].MRP_Price' readonly value='' id='textMRP_Price_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:80px' placeholder='Quantity' name='SaleOrderItemList[" + i + "].Quantity' value='' onblur='javascript: CalculateQuantityMRP();' id='textQuantity_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:70px' placeholder='Disc %' name='SaleOrderItemList[" + i + "].Discount_Percentage' value=''  onblur='javascript: CalculateTotal();' id='textDiscount_Percentage_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:80px' placeholder='D Amt' name='SaleOrderItemList[" + i + "].SalesOrder_Discount_Amount' readonly value='' id='textSalesOrder_Discount_Amount_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control input-sm' style='width:80px' placeholder='Amt' name='SaleOrderItemList[" + i + "].Amount' readonly value='' id='textAmount_" + i + "'>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group auto-complete'>";
    tblHtml += "<div class='input-group'>";
    tblHtml += "<input type='text' class='form-control invoice-filter autocomplete-text' style='width:80px' name='SaleOrderItemList[" + i + "].SalesMan' id='textSalesMan_" + i + "' placeholder='Enter SalesMan' value='' data-table='Employee' data-col='Employee_Id,Employee_Name' data-headernames='Employee' data-param='hdnEmployee_Id' data-field='Role_Id'>";
    tblHtml += "<span class='input-group-addon'> <a href='#' class='text-muted' id='hrefDealer' role='button'> <i class='fa fa-search' style='color:#fff;' aria-hidden='true'></i></a></span>";
    tblHtml += "<input type='hidden' id='hdnSalesManId_" + i + "' value='' name='SaleOrderItemList[" + i + "].SalesMan_Id' class='auto-complete-value'/>";
    tblHtml += "<input type='hidden' id='hdnSalesMan_" + i + "' value='' name='SaleOrderItemList[" + i + "].SalesMan' class='auto-complete-label' />";
    tblHtml += "</div>";
    tblHtml += "</div>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<button type='button' id='delete-salesorder-details' class='btn btn-danger active' onclick='javascript:DeleteSalesOrderDetailsData(" + i + ")'><i class='fa fa-times'></i>Delete</button>";
    tblHtml += "</td>";

    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);

    Add_Validation(i);

}

function DeleteSalesOrderDetailsData(i) {

    if ($('#tblSalesOrderItems tbody tr').length == 1)
    {
        $("#lblError").text("Atleast one required.");
    }
    else
    {
        $("#lblError").text("");

        $("#tblSalesOrderItems").find("[id='SalesOrderItemRow_" + i + "']").remove();

        ReArrangeSalesOrderDetailsData();

        Add_Validation(i);

        CalculateTotal();

        CalculateTax()

    }
}

function ReArrangeSalesOrderDetailsData() {

        $("#tblSalesOrderItems").find("[id^='SalesOrderItemRow_']").each(function (i, row) {

            if ($(row)[0].id != 'tblHeading') {

                $(row)[0].id = 'SalesOrderItemRow_' + i;

                var newTR = "#" + $(row)[0].id + " td";

                if ($(newTR).find("[id^='textBarcode_No_']").length > 0) {
                    $(newTR).find("[id^='textBarcode_No_']")[0].id = "textBarcode_No_" + i;
                    $(newTR).find("[id^='textBarcode_No_']").attr("name", "SaleOrderItemList[" + i + "].Barcode");
                }

                if ($(newTR).find("[id^='textSKU_No_']").length > 0) {
                    $(newTR).find("[id^='textSKU_No_']")[0].id = "textSKU_No_" + i;
                    $(newTR).find("[id^='textSKU_No_']").attr("name", "SaleOrderItemList[" + i + "].SKU_Code", "onblur", "javascript: Get_Sales_Order_Items_By_SKU_Code(" + i + ")");
                    $(newTR).find("[id^='hdnProduct_Id_']")[0].id = "hdnProduct_Id_" + i;             
                    $(newTR).find("[id^='hdnSKU_No_']")[0].id = "hdnSKU_No_" + i;
                    $(newTR).find("[id^='hdnSKU_No_']").attr("name", "SaleOrderItemList[" + i + "].SKU_Code");

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
                    $(newTR).find("[id^='textSalesMan_']").attr("name", "SaleOrderItemList[" + i + "].SalesMan_Id");
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

    $("#textQuantity_" + i).rules("add", { required: true, QuantityCheck: true, digits: true, messages: { required: "Quantity", digits: "Invalid Quantity." } });

    $("#textSKU_No_" + i).rules("add", { required: true, checkSKUExist: true, messages: { required: "SKU is Required", } });

    $("#textSalesMan_" + i).rules("add", { required: true, messages: { required: "SalesMan" } });

    $("#textDiscount_Percentage_" + i).rules("add", { required: true, digits: true, messages: { required: "Discount", digits: "Invalid Discount." } });

}

  