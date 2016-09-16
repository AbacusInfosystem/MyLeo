function Get_Sizes() {

    var Size_Group_Id = $("#drpSize_Group").val();

    $.ajax({

        url: "/PurchaseOrder/Get_Sizes",

        data: { size_group_Id: Size_Group_Id },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);

            if (obj.PurchaseOrder.SizeGroups.length > 0) {

                $("#drpCenter_Size").empty();

                var tblHtml = '';

                var myTable = $("#tblPurchaseOrderItems");

                var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderSizeRow_"]').size();

                i = temptablecount;

                tblHtml += "<tr id='PurchaseOrderSizeRow_" + i + "' class='item-data-row'>";

                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";

                for (var j = 0; j < obj.PurchaseOrder.SizeGroups.length; j++) {
                                       
                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + i + "-" + (j + 1) + "'>" + obj.PurchaseOrder.SizeGroups[j].Size_Name + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.SizeGroups[j].Size_Id + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + i + "' id='hdnSize" + i + "-" + (j + 1) + "' />";
                    tblHtml += "</td>";

                    debugger;
                                     
                    
                    var center_size = document.getElementById("drpCenter_Size");
                    var option = document.createElement("option");

                    option.value = obj.PurchaseOrder.SizeGroups[j].Size_Id;
                    option.text = obj.PurchaseOrder.SizeGroups[j].Size_Name;
                    center_size.add(option);
                                       
                }

                tblHtml += "</tr>";

                var newRow = $(tblHtml);

                myTable.append(newRow);

            }
        }
    });


}

function AddPurchaseOrderDetails() {
  
    var tdSizeCount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderSizeRow_"]').size();

    x = tdSizeCount - 1;

    var counter = 1;

    var size_group_id = $("#drpSize_Group").val();
    var size_group = document.getElementById("drpSize_Group");
    var size_group_name = size_group.options[size_group.selectedIndex].text;

    var brand_id = $("#drpBrand").val();
    var brand = document.getElementById("drpBrand");
    var brand_name = brand.options[brand.selectedIndex].text;

    var category_id = $("#drpCategory").val();
    var category = document.getElementById("drpCategory");
    var category_name = category.options[category.selectedIndex].text;

    var sub_category_id = $("#drpSubCategory").val();
    var sub_category = document.getElementById("drpSubCategory");
    var sub_category_name = sub_category.options[sub_category.selectedIndex].text;
    
    //var center_size = $("#textCenter_Size").val();
    var size_id = $("#drpCenter_Size").val();
    var center = document.getElementById("drpCenter_Size");
    var center_size = center.options[center.selectedIndex].text;

    var purchase_price = $("#textPurchase_Price").val();

    var size_difference = $("#textSize_Difference").val();

    var html = '';

    var tblHtml = '';

    var myTable = $("#tblPurchaseOrderItems");

    var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderItemRow_"]').size();

    i = temptablecount;

    tblHtml += "<tr id='PurchaseOrderItemRow_" + i + "' class='item-data-row'>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Article_No' value='' id='textArticle_No_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Colour_Id' value='' id='textColour_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textBrand_Name_" + i + "'>" + brand_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + brand_id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textCategory_Name_" + i + "'>" + category_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + category_id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textSub_Category_Name_" + i + "'>" + sub_category_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + sub_category_id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Sub_Category_Id' id='hdnSub_Category_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;'  id='textSize_Group_Name" + i + "'>" + size_group_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size_group_id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Size_Group_Id' id='hdnSize_Group_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Start_Size' value='' id='textStart_Size_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].End_Size' value='' id='textEnd_Size_" + i + "' />";
    tblHtml += "</td>";

    debugger;

    var size1 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity1' value='0' id='textSize_Quantity_" + i + "-1'  onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size1 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id1' id='hdnSize_Id_" + i + "-1' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount1' id='hdnAmount_" + i + "-1' />";
    tblHtml += "</td>";
    counter++;

    var size2 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity2' value='0' id='textSize_Quantity_" + i + "-2' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size2 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id2' id='hdnSize_Id_" + i + "-2' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount2' id='hdnAmount_" + i + "-2' />";
    tblHtml += "</td>";
    counter++;

    var size3 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity3' value='0' id='textSize_Quantity_" + i + "-3' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size3 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id3' id='hdnSize_Id_" + i + "-3' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount3' id='hdnAmount_" + i + "-3' />";
    tblHtml += "</td>";
    counter++;

    var size4 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity4' value='0' id='textSize_Quantity_" + i + "-4' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size4 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id4' id='hdnSize_Id_" + i + "-4' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount4' id='hdnAmount_" + i + "-4' />";
    tblHtml += "</td>";
    counter++;

    var size5 = $("#hdnSize" + x + "-" + counter).val();    
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity5' value='0' id='textSize_Quantity_" + i + "-5' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size5 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id5' id='hdnSize_Id_" + i + "-5' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount5' id='hdnAmount_" + i + "-5' />";
    tblHtml += "</td>";
    counter++;

    var size6 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity6' value='0' id='textSize_Quantity_" + i + "-6' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size6 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id6' id='hdnSize_Id_" + i + "-6' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount6' id='hdnAmount_" + i + "-6' />";
    tblHtml += "</td>";
    counter++;

    var size7 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity7' value='0' id='textSize_Quantity_" + i + "-7' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size7 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id7' id='hdnSize_Id_" + i + "-7' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount7' id='hdnAmount_" + i + "-7' />";
    tblHtml += "</td>";
    counter++;

    var size8 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity8' value='0' id='textSize_Quantity_" + i + "-8' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size8 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id8' id='hdnSize_Id_" + i + "-8' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount8' id='hdnAmount_" + i + "-8' />";
    tblHtml += "</td>";
    counter++;

    var size9 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity9' value='0' id='textSize_Quantity_" + i + "-9' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size9 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id9' id='hdnSize_Id_" + i + "-9' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount9' id='hdnAmount_" + i + "-9' />";
    tblHtml += "</td>";
    counter++;

    var size10 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity10' value='0' id='textSize_Quantity_" + i + "-10' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size10 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id10' id='hdnSize_Id_" + i + "-10' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount10' id='hdnAmount_" + i + "-10' />";
    tblHtml += "</td>";
    counter++;

    var size11 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity11' value='0' id='textSize_Quantity_" + i + "-11' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size11 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id11' id='hdnSize_Id_" + i + "-11' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount11' id='hdnAmount_" + i + "-11' />";
    tblHtml += "</td>";
    counter++;

    var size12 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity12' value='0' id='textSize_Quantity_" + i + "-12' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size12 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id12' id='hdnSize_Id_" + i + "-12' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount12' id='hdnAmount_" + i + "-12' />";
    tblHtml += "</td>";
    counter++;

    var size13 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity13' value='0' id='textSize_Quantity_" + i + "-13' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size13 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id13' id='hdnSize_Id_" + i + "-13' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount13' id='hdnAmount_" + i + "-13' />";
    tblHtml += "</td>";
    counter++;

    var size14 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity14' value='0' id='textSize_Quantity_" + i + "-14' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size14 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id14' id='hdnSize_Id_" + i + "-14' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount14' id='hdnAmount_" + i + "-14' />";
    tblHtml += "</td>";
    counter++;

    var size15 = $("#hdnSize" + x + "-" + counter).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity15' value='0' id='textSize_Quantity_" + i + "-15' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size15 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id15' id='hdnSize_Id_" + i + "-15' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount15' id='hdnAmount_" + i + "-15' />";
    tblHtml += "</td>";
  

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' name='PurchaseOrder.PurchaseOrders[" + i + "].Item_Quantity'  id='textTotal_Quantity_" + i + "'></span>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' name='PurchaseOrder.PurchaseOrders[" + i + "].Center_Size'  id='textCenter_Size_" + i + "'>" + center_size + "</span>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' name='PurchaseOrder.PurchaseOrders[" + i + "].Purchase_Price'  id='textPurchase_Price_" + i + "'>" + purchase_price + "</span>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' name='PurchaseOrder.PurchaseOrders[" + i + "].Size_Difference'  id='textSize_Difference_" + i + "'>" + size_difference + "</span>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' name='PurchaseOrder.PurchaseOrders[" + i + "].Total_Amount'  id='textTotal_Amount_" + i + "'></span>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Comment' value='' id='textComment_" + i + "' />";
    tblHtml += "</td>";
     
    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='continue-order-details' class='btn btn-success active' onclick='ContinuePurchaseOrderDetailsData(" + i + ")'>Continue</button>";
    tblHtml += "<button type='button' id='delete-order-details' class='btn btn-danger active' onclick='DeletePurchaseOrderDetailsData(" + i + ")'>Delete</button>";
    tblHtml += "</div>";
    tblHtml += "</td>";


    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);
    
}

function ContinuePurchaseOrderDetailsData(j) {
    
    debugger;

    var tdSizeCount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderSizeRow_"]').size();

    x = tdSizeCount - 1;

    var counter = 1;

    var size_group_id = $("#hdnSize_Group_Id_" + j).val();
    var size_group_name = $("#textSize_Group_Name" + j).text();

    var brand_id = $("#hdnBrand_Id_" + j).val();
    var brand_name = $("#textBrand_Name_" + j).text();

    var category_id = $("#hdnCategory_Id_" + j).val();
    var category_name = $("#textCategory_Name_" + j).text();
    
    var sub_category_id = $("#hdnSub_Category_Id_" + j).val();
    var sub_category_name = $("#textSub_Category_Name_" + j).text();
    
    var center_size = $("#textCenter_Size_" + j).text();
    
    var purchase_price = $("#textPurchase_Price_" + j).text();

    var size_difference = $("#textSize_Difference_" + j).text();

    //var total_quantity = $("#textTotal_Quantity_" + j).text();

    //var total_amount = $("#textTotal_Amount_" + j).text();

    //var article_no = $("#textArticle_No_" + j).text();
        

    var html = '';

    var tblHtml = '';

    var myTable = $("#tblPurchaseOrderItems");

    var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderItemRow_"]').size();

    var i = temptablecount;

    tblHtml += "<tr id='PurchaseOrderItemRow_" + i + "' class='item-data-row'>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Article_No' value='' id='textArticle_No_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Colour_Id' value='' id='textColour_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textBrand_Name_" + i + "'>" + brand_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + brand_id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textCategory_Name_" + i + "'>" + category_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + category_id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textSub_Category_Name_" + i + "'>" + sub_category_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + sub_category_id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Sub_Category_Id' id='hdnSub_Category_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;'  id='textSize_Group_Name" + i + "'>" + size_group_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size_group_id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Size_Group_Id' id='hdnSize_Group_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Start_Size' value='' id='textStart_Size_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].End_Size' value='' id='textEnd_Size_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity1' value='0' id='textSize_Quantity_" + i + "-1' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-1").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id1' id='hdnSize_Id_" + i + "-1' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount1' id='hdnAmount_" + i + "-1' />";
    tblHtml += "</td>";
  

   
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity2' value='0' id='textSize_Quantity_" + i + "-2' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-2").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id2' id='hdnSize_Id_" + i + "-2' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount2' id='hdnAmount_" + i + "-2' />";
    tblHtml += "</td>";
  

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity3' value='0' id='textSize_Quantity_" + i + "-3' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-3").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id3' id='hdnSize_Id_" + i + "-3' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount3' id='hdnAmount_" + i + "-3' />";
    tblHtml += "</td>";
    

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity4' value='0' id='textSize_Quantity_" + i + "-4' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-4").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id4' id='hdnSize_Id_" + i + "-4' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount4' id='hdnAmount_" + i + "-4' />";
    tblHtml += "</td>";
  
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity5' value='0' id='textSize_Quantity_" + i + "-5' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-5").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id5' id='hdnSize_Id_" + i + "-5' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount5' id='hdnAmount_" + i + "-5' />";
    tblHtml += "</td>";
    
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity6' value='0' id='textSize_Quantity_" + i + "-6' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-6").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id6' id='hdnSize_Id_" + i + "-6' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount6' id='hdnAmount_" + i + "-6' />";
    tblHtml += "</td>";
 
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity7' value='0' id='textSize_Quantity_" + i + "-7' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-7").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id7' id='hdnSize_Id_" + i + "-7' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount7' id='hdnAmount_" + i + "-7' />";
    tblHtml += "</td>";
   
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity8' value='0' id='textSize_Quantity_" + i + "-8' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-8").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id8' id='hdnSize_Id_" + i + "-8' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount8' id='hdnAmount_" + i + "-8' />";
    tblHtml += "</td>";
   
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity9' value='0' id='textSize_Quantity_" + i + "-9' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-9").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id9' id='hdnSize_Id_" + i + "-9' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount9' id='hdnAmount_" + i + "-9' />";
    tblHtml += "</td>";
  
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity10' value='0' id='textSize_Quantity_" + i + "-10' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-10").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id10' id='hdnSize_Id_" + i + "-10' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount10' id='hdnAmount_" + i + "-10' />";
    tblHtml += "</td>";
    

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity11' value='0' id='textSize_Quantity_" + i + "-11' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-11").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id11' id='hdnSize_Id_" + i + "-11' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount11' id='hdnAmount_" + i + "-11' />";
    tblHtml += "</td>";
   
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity12' value='0' id='textSize_Quantity_" + i + "-12' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-12").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id12' id='hdnSize_Id_" + i + "-12' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount12' id='hdnAmount_" + i + "-12' />";
    tblHtml += "</td>";
    
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity13' value='0' id='textSize_Quantity_" + i + "-13' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-13").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id13' id='hdnSize_Id_" + i + "-13' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount13' id='hdnAmount_" + i + "-13' />";
    tblHtml += "</td>";
    
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity14' value='0' id='textSize_Quantity_" + i + "-14' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-14").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id14' id='hdnSize_Id_" + i + "-14' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount14' id='hdnAmount_" + i + "-14' />";
    tblHtml += "</td>";
  
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity15' value='0' id='textSize_Quantity_" + i + "-15' onfocusout='CalculateRowQuantity(" + i + ")' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_" + (i - 1) + "-15").val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id15' id='hdnSize_Id_" + i + "-15' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.Sizes[" + i + "].Amount15' id='hdnAmount_" + i + "-15' />";
    tblHtml += "</td>";


    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' name='PurchaseOrder.PurchaseOrders[" + i + "].Item_Quantity' id='textTotal_Quantity_" + i + "'></span>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' name='PurchaseOrder.PurchaseOrders[" + i + "].Center_Size'  id='textCenter_Size_" + i + "'>" + center_size + "</span>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' name='PurchaseOrder.PurchaseOrders[" + i + "].Purchase_Price'  id='textPurchase_Price_" + i + "'>" + purchase_price + "</span>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' name='PurchaseOrder.PurchaseOrders[" + i + "].Size_Difference'  id='textSize_Difference_" + i + "'>" + size_difference + "</span>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' name='PurchaseOrder.PurchaseOrders[" + i + "].Total_Amount' id='textTotal_Amount_" + i + "'></span>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Comment' value='' id='textComment_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='continue-order-details' class='btn btn-success active' onclick='ContinuePurchaseOrderDetailsData(" + i + ")'>Continue</button>";
    tblHtml += "<button type='button' id='delete-order-details' class='btn btn-danger active' onclick='DeletePurchaseOrderDetailsData(" + i + ")'>Delete</button>";
    tblHtml += "</div>";
    tblHtml += "</td>";


    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);


    

}

function CalculateRowAmount(i) {

    debugger;

    var index = document.getElementById("drpCenter_Size").selectedIndex;

    var count = document.getElementById("drpCenter_Size").length;

    index = index + 1;

    //var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderSizeRow_"]').size();

    var x = parseInt(i);

    var size_id = $("#drpCenter_Size").val();

    var center_size = $("#textCenter_Size_" + x).text();

    var purchase_price = $("#textPurchase_Price_" + x).text();

    var size_difference = $("#textSize_Difference_" + x).text();

    //////////////////////////////////////////////////////////////////////////////////////

    var size_difference_temp = 0;

    var size_diff_count = size_difference;

    for (var j = index; j > 0; j--) {
        if (j == index) {
            $("#hdnAmount_" + x + "-" + j).val(purchase_price);
        }
        else {
            var computation = parseInt(purchase_price) - parseInt(size_difference_temp);

            $("#hdnAmount_" + x + "-" + j).val(computation);

        }
        size_difference_temp = parseInt(size_difference_temp) + parseInt(size_diff_count);

    }

    //////////////////////////////////////////////////////////////////////////////////////

    var size_difference_temp = 0;

    size_diff_count = size_difference;

    for (var j = index + 1; j <= count; j++) {

        size_difference_temp = parseInt(size_difference_temp) + parseInt(size_diff_count);

        var computation = parseInt(purchase_price) + parseInt(size_difference_temp);
        $("#hdnAmount_" + x + "-" + j).val(computation);

    }

}

function CalculateRowQuantity(i) {

    CalculateRowAmount(i);

    debugger;

    /// Row ///   

    var count = document.getElementById("drpCenter_Size").length;

    var sum_row_quantity = 0;

    var sum_row_amount = 0;


    for (var j = 0; j < count ; j++) {

        var Qty = parseFloat($("#tblPurchaseOrderItems").find('[id="textSize_Quantity_' + i + '-' + (j + 1) + '"]').val());

        var WSR = parseFloat($("#tblPurchaseOrderItems").find('[id="hdnAmount_' + i + '-' + (j + 1) + '"]').val());

        var Amount = parseFloat(WSR * Qty);

        $("#tblPurchaseOrderItems").find('[id="textAmount_' + i + '"]').val(Amount);

        sum_row_quantity = sum_row_quantity + Qty;

        sum_row_amount = sum_row_amount + Amount;

        document.getElementById('textTotal_Quantity_' + i).innerText = sum_row_quantity;

        document.getElementById('textTotal_Amount_' + i).innerText = sum_row_amount;

    }
    

    /// Total ///

    var sumQuantity = 0;

    var sumWSRAmount = 0;
    
    if (i >= 0) {

        for (var j = 0; j <= i ; j++) {

            var Qty = parseFloat($("#tblPurchaseOrderItems").find('[id="textTotal_Quantity_' + j + '"]').text());

            var Amount = parseFloat($("#tblPurchaseOrderItems").find('[id="textTotal_Amount_' + j + '"]').text());

            sumWSRAmount = sumWSRAmount + Amount;

            sumQuantity = sumQuantity + Qty;
        }
    }


    document.getElementById('tdTotalQuantity').innerText = sumQuantity;

    document.getElementById('tdNetAmount').innerText = sumWSRAmount;
       
}

function DeletePurchaseOrderDetailsData(i) {

    debugger;

    $("#tblPurchaseOrderItems").find("[id='PurchaseOrderItemRow_" + i + "']").remove();

    ReArrangePurchaseOrderDetailsData();

    var i = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderItemRow_"]').size();
        
    CalculateRowQuantity(i);
}

function ReArrangePurchaseOrderDetailsData() {

    debugger;

    $("#tblPurchaseOrderItems").find("[id^='PurchaseOrderItemRow_']").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'PurchaseOrderItemRow_' + i

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='textArticle_No_']").length > 0) {
                $(newTR).find("[id^='textArticle_No_']")[0].id = "textArticle_No_" + i;
                $(newTR).find("[id^='textArticle_No_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Article_No");
            }

            if ($(newTR).find("[id^='textColour_Id_']").length > 0) {
                $(newTR).find("[id^='textColour_Id_']")[0].id = "textColour_Id_" + i;
                $(newTR).find("[id^='textColour_Id_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Colour_Id");
            }

            if ($(newTR).find("[id^='textBrand_Name_']").length > 0) {
                $(newTR).find("[id^='textBrand_Name_']")[0].id = "textBrand_Name_" + i;
                $(newTR).find("[id^='hdnBrand_Id_']")[0].id = "hdnBrand_Id_" + i;
                $(newTR).find("[id^='hdnBrand_Id_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Brand_Id");
            }

            if ($(newTR).find("[id^='textCategory_Name_']").length > 0) {
                $(newTR).find("[id^='textCategory_Name_']")[0].id = "textCategory_Name_" + i;
                $(newTR).find("[id^='hdnCategory_Id_']")[0].id = "hdnCategory_Id_" + i;
                $(newTR).find("[id^='hdnCategory_Id_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Category_Id");
            }

            if ($(newTR).find("[id^='textSub_Category_Name_']").length > 0) {
                $(newTR).find("[id^='textSub_Category_Name_']")[0].id = "textSub_Category_Name_" + i;
                $(newTR).find("[id^='hdnSub_Category_Id_']")[0].id = "hdnSub_Category_Id_" + i;
                $(newTR).find("[id^='hdnSub_Category_Id_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Sub_Category_Id");
            }

            if ($(newTR).find("[id^='textSize_Group_Name']").length > 0) {
                $(newTR).find("[id^='textSize_Group_Name']")[0].id = "textSize_Group_Name" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']")[0].id = "hdnSize_Group_Id_" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Size_Group_Id");
            }

            if ($(newTR).find("[id^='textSize_Group_Name']").length > 0) {
                $(newTR).find("[id^='textSize_Group_Name']")[0].id = "textSize_Group_Name" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']")[0].id = "hdnSize_Group_Id_" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Size_Group_Id");
            }

            if ($(newTR).find("[id^='textStart_Size_']").length > 0) {
                $(newTR).find("[id^='textStart_Size_']")[0].id = "textStart_Size_" + i;
                $(newTR).find("[id^='textStart_Size_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Start_Size");
            }

            if ($(newTR).find("[id^='textEnd_Size_']").length > 0) {
                $(newTR).find("[id^='textEnd_Size_']")[0].id = "textEnd_Size_" + i;
                $(newTR).find("[id^='textEnd_Size_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].End_Size");
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            debugger;

          

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-1']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-1']")[0].id = "textSize_Quantity_" +  i  + "-1";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-1']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity1");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-1']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-1']")[0].id = "hdnSize_Id_" + i + "-1";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-1']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id1");

                $(newTR).find("[id^='hdnAmount_" + i + "-1']")[0].id = "hdnAmount_" + i + "-1";
                $(newTR).find("[id^='hdnAmount_" + i + "-1']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount1");

            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-2']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-2']")[0].id = "textSize_Quantity_" + i + "-2";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-2']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity2");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-2']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-2']")[0].id = "hdnSize_Id_" + i + "-2";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-2']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id2");

                $(newTR).find("[id^='hdnAmount_" + i + "-2']")[0].id = "hdnAmount_" + i + "-2";
                $(newTR).find("[id^='hdnAmount_" + i + "-2']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount2");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-3']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-3']")[0].id = "textSize_Quantity_" + i + "-3";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-3']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity3");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-3']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-3']")[0].id = "hdnSize_Id_" + i + "-3";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-3']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id3");

                $(newTR).find("[id^='hdnAmount_" + i + "-3']")[0].id = "hdnAmount_" + i + "-3";
                $(newTR).find("[id^='hdnAmount_" + i + "-3']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount3");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-4']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-4']")[0].id = "textSize_Quantity_" + i + "-4";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-4']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity4");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-4']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-4']")[0].id = "hdnSize_Id_" + i + "-4";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-4']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id4");

                $(newTR).find("[id^='hdnAmount_" + i + "-4']")[0].id = "hdnAmount_" + i + "-4";
                $(newTR).find("[id^='hdnAmount_" + i + "-4']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount4");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-5']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-5']")[0].id = "textSize_Quantity_" + i + "-5";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-5']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity5");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-5']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-5']")[0].id = "hdnSize_Id_" + i + "-5";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-5']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id5");

                $(newTR).find("[id^='hdnAmount_" + i + "-5']")[0].id = "hdnAmount_" + i + "-5";
                $(newTR).find("[id^='hdnAmount_" + i + "-5']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount5");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-6']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-6']")[0].id = "textSize_Quantity_" + i + "-6";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-6']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity6");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-6']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-6']")[0].id = "hdnSize_Id_" + i + "-6";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-6']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id6");

                $(newTR).find("[id^='hdnAmount_" + i + "-6']")[0].id = "hdnAmount_" + i + "-6";
                $(newTR).find("[id^='hdnAmount_" + i + "-6']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount6");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-7']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-7']")[0].id = "textSize_Quantity_" + i + "-7";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-7']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity7");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-7']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-7']")[0].id = "hdnSize_Id_" + i + "-7";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-7']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id7");

                $(newTR).find("[id='hdnAmount_" + i + "-7']")[0].id = "hdnAmount_" + i + "-7";
                $(newTR).find("[id='hdnAmount_" + i + "-7']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount7");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-8']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-8']")[0].id = "textSize_Quantity_" + i + "-8";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-8']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity8");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-8']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-8']")[0].id = "hdnSize_Id_" + i + "-8";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-8']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id8");

                $(newTR).find("[id^='hdnAmount_" + i + "-8']")[0].id = "hdnAmount_" + i + "-8";
                $(newTR).find("[id^='hdnAmount_" + i + "-8']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount8");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-9']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-9']")[0].id = "textSize_Quantity_" + i + "-9";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-9']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity9");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-9']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-9']")[0].id = "hdnSize_Id_" + i + "-9";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-9']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id9");

                $(newTR).find("[id^='hdnAmount_" + i + "-9']")[0].id = "hdnAmount_" + i + "-9";
                $(newTR).find("[id^='hdnAmount_" + i + "-9']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount9");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-10']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-10']")[0].id = "textSize_Quantity_" + i + "-10";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-10']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity10");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-10']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-10']")[0].id = "hdnSize_Id_" + i + "-10";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-10']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id10");

                $(newTR).find("[id^='hdnAmount_" + i + "-10']")[0].id = "hdnAmount_" + i + "-10";
                $(newTR).find("[id^='hdnAmount_" + i + "-10']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount10");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-11']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-11']")[0].id = "textSize_Quantity_" + i + "-11";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-11']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity11");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-11']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-11']")[0].id = "hdnSize_Id_" + i + "-11";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-11']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id11");

                $(newTR).find("[id^='hdnAmount_" + i + "-11']")[0].id = "hdnAmount_" + i + "-";
                $(newTR).find("[id^='hdnAmount_" + i + "-11']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount11");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-12']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-12']")[0].id = "textSize_Quantity_" + i + "-12";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-12']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity12");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-12']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-12']")[0].id = "hdnSize_Id_" + i + "-12";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-12']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id12");

                $(newTR).find("[id^='hdnAmount_" + i + "-12']")[0].id = "hdnAmount_" + i + "-12";
                $(newTR).find("[id^='hdnAmount_" + i + "-12']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount12");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-13']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-13']")[0].id = "textSize_Quantity_" + i + "-13";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-13']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity13");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-13']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-13']")[0].id = "hdnSize_Id_" + i + "-13";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-13']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id13");

                $(newTR).find("[id^='hdnAmount_" + i + "-13']")[0].id = "hdnAmount_" + i + "-13";
                $(newTR).find("[id^='hdnAmount_" + i + "-13']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount13");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-14']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-14']")[0].id = "textSize_Quantity_" + i + "-14";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-14']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity14");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-14']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-14']")[0].id = "hdnSize_Id_" + i + "-14";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-14']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id14");

                $(newTR).find("[id^='hdnAmount_" + i + "-14']")[0].id = "hdnAmount_" + i + "-14";
                $(newTR).find("[id^='hdnAmount_" + i + "-14']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount14");
            }

            if ($(newTR).find("[id^='textSize_Quantity_" + i + "-15']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_" + i + "-15']")[0].id = "textSize_Quantity_" + i + "-15";
                $(newTR).find("[id^='textSize_Quantity_" + i + "-15']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity15");
                $(newTR).find("[id^='textSize_Quantity_" + i + "-15']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_" + i + "-15']")[0].id = "hdnSize_Id_" + i + "-15";
                $(newTR).find("[id^='hdnSize_Id_" + i + "-15']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id15");

                $(newTR).find("[id^='hdnAmount_" + i + "-15']")[0].id = "hdnAmount_" + i + "-15";
                $(newTR).find("[id^='hdnAmount_" + i + "-15']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount15");
            }




            debugger;


            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            
            if ($(newTR).find("[id^='textTotal_Quantity_']").length > 0) {
                $(newTR).find("[id^='textTotal_Quantity_']")[0].id = "textTotal_Quantity_" + i;
                $(newTR).find("[id^='textTotal_Quantity_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Item_Quantity");
            }

            if ($(newTR).find("[id^='textCenter_Size_']").length > 0) {
                $(newTR).find("[id^='textCenter_Size_']")[0].id = "textCenter_Size_" + i;
                $(newTR).find("[id^='textCenter_Size_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Center_Size");
            }

            if ($(newTR).find("[id^='textPurchase_Price_']").length > 0) {
                $(newTR).find("[id^='textPurchase_Price_']")[0].id = "textPurchase_Price_" + i;
                $(newTR).find("[id^='textPurchase_Price_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Purchase_Price");
            }

            if ($(newTR).find("[id^='textSize_Difference_']").length > 0) {
                $(newTR).find("[id^='textSize_Difference_']")[0].id = "textSize_Difference_" + i;
                $(newTR).find("[id^='textSize_Difference_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Size_Difference");
            }

            if ($(newTR).find("[id^='textTotal_Amount_']").length > 0) {
                $(newTR).find("[id^='textTotal_Amount_']")[0].id = "textTotal_Amount_" + i;
                $(newTR).find("[id^='textTotal_Amount_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Total_Amount");
            }

            if ($(newTR).find("[id^='textComment_']").length > 0) {
                $(newTR).find("[id^='textComment_']")[0].id = "textComment_" + i;
                $(newTR).find("[id^='textComment_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Comment");
            }

                      
            if ($(newTR).find("[id='continue-order-details']").length > 0) {
                $(newTR).find("[id='continue-order-details']").attr("onclick", "ContinuePurchaseOrderDetailsData(" + i + ")");
            }
           
            if ($(newTR).find("[id='delete-order-details']").length > 0) {
                $(newTR).find("[id='delete-order-details']").attr("onclick", "DeletePurchaseOrderDetailsData(" + i + ")");
            }
        }
    });

}







//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-1']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-1']")[0].id = "textSize_Quantity_" +  i  + "-1";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-1']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity1");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-1']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "']")[0].id = "hdnSize_Id_" + i + "-1";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id1");

//    $(newTR).find("[id^='hdnAmount_" + i + "']")[0].id = "hdnAmount_" + i + "-1";
//    $(newTR).find("[id^='hdnAmount_" + i + "']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount1");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-2']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-2']")[0].id = "textSize_Quantity_" + i + "-2";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-2']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity2");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-2']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-2']")[0].id = "hdnSize_Id_" + i + "-2";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-2']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id2");

//    $(newTR).find("[id^='hdnAmount_" + i + "-2']")[0].id = "hdnAmount_" + i + "-2";
//    $(newTR).find("[id^='hdnAmount_" + i + "-2']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount2");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-3']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-3']")[0].id = "textSize_Quantity_" + i + "-3";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-3']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity3");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-3']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-3']")[0].id = "hdnSize_Id_" + i + "-3";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-3']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id3");

//    $(newTR).find("[id^='hdnAmount_" + i + "-3']")[0].id = "hdnAmount_" + i + "-3";
//    $(newTR).find("[id^='hdnAmount_" + i + "-3']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount3");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-4']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-4']")[0].id = "textSize_Quantity_" + i + "-4";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-4']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity4");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-4']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-4']")[0].id = "hdnSize_Id_" + i + "-4";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-4']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id4");

//    $(newTR).find("[id^='hdnAmount_" + i + "-4']")[0].id = "hdnAmount_" + i + "-4";
//    $(newTR).find("[id^='hdnAmount_" + i + "-4']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount4");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-5']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-5']")[0].id = "textSize_Quantity_" + i + "-5";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-5']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity5");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-5']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-5']")[0].id = "hdnSize_Id_" + i + "-5";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-5']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id5");

//    $(newTR).find("[id^='hdnAmount_" + i + "-5']")[0].id = "hdnAmount_" + i + "-5";
//    $(newTR).find("[id^='hdnAmount_" + i + "-5']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount5");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-6']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-6']")[0].id = "textSize_Quantity_" + i + "-6";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-6']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity6");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-6']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-6']")[0].id = "hdnSize_Id_" + i + "-6";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-6']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id6");

//    $(newTR).find("[id^='hdnAmount_" + i + "-6']")[0].id = "hdnAmount_" + i + "-6";
//    $(newTR).find("[id^='hdnAmount_" + i + "-6']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount6");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-7']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-7']")[0].id = "textSize_Quantity_" + i + "-7";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-7']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity7");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-7']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-7']")[0].id = "hdnSize_Id_" + i + "-7";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-7']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id7");

//    $(newTR).find("[id='hdnAmount_" + i + "-7']")[0].id = "hdnAmount_" + i + "-7";
//    $(newTR).find("[id='hdnAmount_" + i + "-7']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount7");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-8']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-8']")[0].id = "textSize_Quantity_" + i + "-8";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-8']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity8");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-8']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-8']")[0].id = "hdnSize_Id_" + i + "-8";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-8']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id8");

//    $(newTR).find("[id^='hdnAmount_" + i + "-8']")[0].id = "hdnAmount_" + i + "-8";
//    $(newTR).find("[id^='hdnAmount_" + i + "-8']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount8");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-9']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-9']")[0].id = "textSize_Quantity_" + i + "-9";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-9']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity9");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-9']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-9']")[0].id = "hdnSize_Id_" + i + "-9";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-9']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id9");

//    $(newTR).find("[id^='hdnAmount_" + i + "-9']")[0].id = "hdnAmount_" + i + "-9";
//    $(newTR).find("[id^='hdnAmount_" + i + "-9']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount9");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-10']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-10']")[0].id = "textSize_Quantity_" + i + "-10";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-10']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity10");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-10']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-10']")[0].id = "hdnSize_Id_" + i + "-10";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-10']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id10");

//    $(newTR).find("[id^='hdnAmount_" + i + "-10']")[0].id = "hdnAmount_" + i + "-10";
//    $(newTR).find("[id^='hdnAmount_" + i + "-10']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount10");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-11']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-11']")[0].id = "textSize_Quantity_" + i + "-11";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-11']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity11");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-11']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-11']")[0].id = "hdnSize_Id_" + i + "-11";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-11']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id11");

//    $(newTR).find("[id^='hdnAmount_" + i + "-11']")[0].id = "hdnAmount_" + i + "-";
//    $(newTR).find("[id^='hdnAmount_" + i + "-11']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount11");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-12']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-12']")[0].id = "textSize_Quantity_" + i + "-12";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-12']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity12");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-12']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-12']")[0].id = "hdnSize_Id_" + i + "-12";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-12']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id12");

//    $(newTR).find("[id^='hdnAmount_" + i + "-12']")[0].id = "hdnAmount_" + i + "-12";
//    $(newTR).find("[id^='hdnAmount_" + i + "-12']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount12");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-13']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-13']")[0].id = "textSize_Quantity_" + i + "-13";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-13']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity13");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-13']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-13']")[0].id = "hdnSize_Id_" + i + "-13";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-13']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id13");

//    $(newTR).find("[id^='hdnAmount_" + i + "-13']")[0].id = "hdnAmount_" + i + "-13";
//    $(newTR).find("[id^='hdnAmount_" + i + "-13']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount13");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-14']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-14']")[0].id = "textSize_Quantity_" + i + "-14";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-14']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity14");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-14']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-14']")[0].id = "hdnSize_Id_" + i + "-14";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-14']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id14");

//    $(newTR).find("[id^='hdnAmount_" + i + "-14']")[0].id = "hdnAmount_" + i + "-14";
//    $(newTR).find("[id^='hdnAmount_" + i + "-14']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount14");
//}

//if ($(newTR).find("[id^='textSize_Quantity_" + i + "-15']").length > 0) {
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-15']")[0].id = "textSize_Quantity_" + i + "-15";
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-15']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity15");
//    $(newTR).find("[id^='textSize_Quantity_" + i + "-15']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//    $(newTR).find("[id^='hdnSize_Id_" + i + "-15']")[0].id = "hdnSize_Id_" + i + "-15";
//    $(newTR).find("[id^='hdnSize_Id_" + i + "-15']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id15");

//    $(newTR).find("[id^='hdnAmount_" + i + "-15']")[0].id = "hdnAmount_" + i + "-15";
//    $(newTR).find("[id^='hdnAmount_" + i + "-15']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount15");
//}


















//$("#tblPurchaseOrderItems").find("[id^='PurchaseOrderItemRow_']").each(function (i, row) {
//    if ($(row)[0].id != 'tblHeading') {

//        $(row)[0].id = 'PurchaseOrderItemRow_' + i

//        var newTR = "#" + $(row)[0].id + " td";


//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-1']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-1']")[0].id = "textSize_Quantity_" + i + "-1";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-1']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity1");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-1']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "']")[0].id = "hdnSize_Id_" + i + "-1";
//            $(newTR).find("[id='hdnSize_Id_" + i + "']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id1");

//            $(newTR).find("[id='hdnAmount_" + i + "']")[0].id = "hdnAmount_" + i + "-1";
//            $(newTR).find("[id='hdnAmount_" + i + "']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount1");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-2']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-2']")[0].id = "textSize_Quantity_" + i + "-2";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-2']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity2");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-2']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-2']")[0].id = "hdnSize_Id_" + i + "-2";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-2']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id2");

//            $(newTR).find("[id='hdnAmount_" + i + "-2']")[0].id = "hdnAmount_" + i + "-2";
//            $(newTR).find("[id='hdnAmount_" + i + "-2']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount2");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-3']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-3']")[0].id = "textSize_Quantity_" + i + "-3";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-3']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity3");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-3']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-3']")[0].id = "hdnSize_Id_" + i + "-3";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-3']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id3");

//            $(newTR).find("[id='hdnAmount_" + i + "-3']")[0].id = "hdnAmount_" + i + "-3";
//            $(newTR).find("[id='hdnAmount_" + i + "-3']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount3");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-4']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-4']")[0].id = "textSize_Quantity_" + i + "-4";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-4']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity4");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-4']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-4']")[0].id = "hdnSize_Id_" + i + "-4";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-4']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id4");

//            $(newTR).find("[id='hdnAmount_" + i + "-4']")[0].id = "hdnAmount_" + i + "-4";
//            $(newTR).find("[id='hdnAmount_" + i + "-4']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount4");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-5']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-5']")[0].id = "textSize_Quantity_" + i + "-5";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-5']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity5");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-5']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-5']")[0].id = "hdnSize_Id_" + i + "-5";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-5']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id5");

//            $(newTR).find("[id='hdnAmount_" + i + "-5']")[0].id = "hdnAmount_" + i + "-5";
//            $(newTR).find("[id='hdnAmount_" + i + "-5']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount5");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-6']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-6']")[0].id = "textSize_Quantity_" + i + "-6";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-6']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity6");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-6']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-6']")[0].id = "hdnSize_Id_" + i + "-6";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-6']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id6");

//            $(newTR).find("[id='hdnAmount_" + i + "-6']")[0].id = "hdnAmount_" + i + "-6";
//            $(newTR).find("[id='hdnAmount_" + i + "-6']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount6");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-7']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-7']")[0].id = "textSize_Quantity_" + i + "-7";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-7']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity7");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-7']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-7']")[0].id = "hdnSize_Id_" + i + "-7";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-7']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id7");

//            $(newTR).find("[id='hdnAmount_" + i + "-7']")[0].id = "hdnAmount_" + i + "-7";
//            $(newTR).find("[id='hdnAmount_" + i + "-7']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount7");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-8']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-8']")[0].id = "textSize_Quantity_" + i + "-8";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-8']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity8");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-8']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-8']")[0].id = "hdnSize_Id_" + i + "-8";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-8']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id8");

//            $(newTR).find("[id='hdnAmount_" + i + "-8']")[0].id = "hdnAmount_" + i + "-8";
//            $(newTR).find("[id='hdnAmount_" + i + "-8']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount8");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-9']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-9']")[0].id = "textSize_Quantity_" + i + "-9";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-9']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity9");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-9']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-9']")[0].id = "hdnSize_Id_" + i + "-9";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-9']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id9");

//            $(newTR).find("[id='hdnAmount_" + i + "-9']")[0].id = "hdnAmount_" + i + "-9";
//            $(newTR).find("[id='hdnAmount_" + i + "-9']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount9");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-10']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-10']")[0].id = "textSize_Quantity_" + i + "-10";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-10']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity10");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-10']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-10']")[0].id = "hdnSize_Id_" + i + "-10";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-10']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id10");

//            $(newTR).find("[id='hdnAmount_" + i + "-10']")[0].id = "hdnAmount_" + i + "-10";
//            $(newTR).find("[id='hdnAmount_" + i + "-10']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount10");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-11']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-11']")[0].id = "textSize_Quantity_" + i + "-11";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-11']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity11");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-11']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-11']")[0].id = "hdnSize_Id_" + i + "-11";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-11']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id11");

//            $(newTR).find("[id='hdnAmount_" + i + "-11']")[0].id = "hdnAmount_" + i + "-";
//            $(newTR).find("[id='hdnAmount_" + i + "-11']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount11");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-12']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-12']")[0].id = "textSize_Quantity_" + i + "-12";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-12']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity12");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-12']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-12']")[0].id = "hdnSize_Id_" + i + "-12";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-12']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id12");

//            $(newTR).find("[id='hdnAmount_" + i + "-12']")[0].id = "hdnAmount_" + i + "-12";
//            $(newTR).find("[id='hdnAmount_" + i + "-12']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount12");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-13']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-13']")[0].id = "textSize_Quantity_" + i + "-13";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-13']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity13");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-13']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-13']")[0].id = "hdnSize_Id_" + i + "-13";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-13']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id13");

//            $(newTR).find("[id='hdnAmount_" + i + "-13']")[0].id = "hdnAmount_" + i + "-13";
//            $(newTR).find("[id='hdnAmount_" + i + "-13']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount13");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-14']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-14']")[0].id = "textSize_Quantity_" + i + "-14";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-14']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity14");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-14']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-14']")[0].id = "hdnSize_Id_" + i + "-14";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-14']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id14");

//            $(newTR).find("[id='hdnAmount_" + i + "-14']")[0].id = "hdnAmount_" + i + "-14";
//            $(newTR).find("[id='hdnAmount_" + i + "-14']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount14");
//        }

//        if ($(newTR).find("[id='textSize_Quantity_" + i + "-15']").length > 0) {
//            $(newTR).find("[id='textSize_Quantity_" + i + "-15']")[0].id = "textSize_Quantity_" + i + "-15";
//            $(newTR).find("[id='textSize_Quantity_" + i + "-15']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity15");
//            $(newTR).find("[id='textSize_Quantity_" + i + "-15']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

//            $(newTR).find("[id='hdnSize_Id_" + i + "-15']")[0].id = "hdnSize_Id_" + i + "-15";
//            $(newTR).find("[id='hdnSize_Id_" + i + "-15']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id15");

//            $(newTR).find("[id='hdnAmount_" + i + "-15']")[0].id = "hdnAmount_" + i + "-15";
//            $(newTR).find("[id='hdnAmount_" + i + "-15']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount15");
//        }
//    }
//});