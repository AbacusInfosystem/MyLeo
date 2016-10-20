function Set_Vendor_Id(value) {
    debugger;

    $("#tblPurchaseOrderRequestItems").find("tr:gt(0)").remove();

    $(".Details").hide();

    $('#hdf_Vendor_Id').val(value);

    //Added by vinod mane on 12/10/2016
    document.getElementById('tdTotalQuantity').innerText = 0;
    document.getElementById('tdNetAmount').innerText = 0;  
    ClearAllDropdownlist();
    //End

    $.ajax({

        url: "/PurchaseOrderRequest/Get_Details_By_Vendor_Id",

        data: { Vendor_Id: value },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("#drpArticle_No").html("");

            $("#drpArticle_No").append("<option value=''>Select Article No.</option>");

            $("#drpArticle_No").parents('.form-group').find('ul').html("");

            $("#drpArticle_No").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Article No.</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");
           
            if (obj.PurchaseOrderRequest.Vendors.length > 0) {
              
                for (var j = 0; j < obj.PurchaseOrderRequest.Vendors.length; j++) {
                    debugger;

                    var i = j + 1;

                    $("#drpArticle_No").append("<option value='" + obj.PurchaseOrderRequest.Vendors[j].Article_No + "'>" + obj.PurchaseOrderRequest.Vendors[j].Article_No + "</option>");

                    $("#drpArticle_No").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrderRequest.Vendors[j].Article_No + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }


           
        }
    });

    Reset_Detalis_After_Delete();
}

function Set_Article_No(value) {
    debugger;
   
    $(".Details").hide();

    $("#hdf_Article_No").val(value);

    $("#drpSize_Group").val('');

    $("#drpBrand").html("");
    $("#drpBrand").append("<option value=''>Select Brand</option>");
    $("#drpBrand").parents('.form-group').find('ul').html("");

    $("#drpCategory").html("");
    $("#drpCategory").append("<option value=''>Select Category</option>");
    $("#drpCategory").parents('.form-group').find('ul').html("");

    $("#drpSubCategory").html("");
    $("#drpSubCategory").append("<option value=''>Select SubCategory.</option>");
    $("#drpSubCategory").parents('.form-group').find('ul').html("");

    $("#drpCenter_Size").html("");
    $("#drpCenter_Size").append("<option value=''>Select Center Size.</option>");
    $("#drpCenter_Size").parents('.form-group').find('ul').html("");

    $("#textPurchase_Price").val('');

    $("#textSize_Difference").val('');
    
    $.ajax({

        url: "/PurchaseOrderRequest/Get_Details_By_Article_No",

        data: { Article_No: value },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);


            $("#drpSize_Group").html("");

            $("#drpSize_Group").append("<option value=''>Select Size Group</option>");

            $("#drpSize_Group").parents('.form-group').find('ul').html("");

            $("#drpSize_Group").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Size Group</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

            if (obj.PurchaseOrderRequest.SizeGroups.length > 0) {

                for (var j = 0; j < obj.PurchaseOrderRequest.SizeGroups.length; j++) {
                    debugger;

                    var i = j + 1;

                    $("#drpSize_Group").append("<option value='" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Group_Id + "'>" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Group_Name + "</option>");

                    $("#drpSize_Group").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Group_Name + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }
            

            if (obj.PurchaseOrderRequest.Brands.length > 0) {

                $("#drpBrand").html("");

                $("#drpBrand").append("<option value='0'>Select Brand</option>");

                $("#drpBrand").parents('.form-group').find('ul').html("");

                $("#drpBrand").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Brand</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");


                for (var j = 0; j < obj.PurchaseOrderRequest.Brands.length; j++) {
                    debugger;

                    var i = j + 1;

                    $("#drpBrand").append("<option value='" + obj.PurchaseOrderRequest.Brands[j].Brand_Id + "'>" + obj.PurchaseOrderRequest.Brands[j].Brand_Name + "</option>");

                    $("#drpBrand").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrderRequest.Brands[j].Brand_Name + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }

            if (obj.PurchaseOrderRequest.Categories.length > 0) {

                $("#drpCategory").html("");

                $("#drpCategory").append("<option value='0'>Select Category</option>");

                $("#drpCategory").parents('.form-group').find('ul').html("");

                $("#drpCategory").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Category</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                for (var j = 0; j < obj.PurchaseOrderRequest.Categories.length; j++) {
                    debugger;
                    var i = j + 1;

                    $("#drpCategory").append("<option value='" + obj.PurchaseOrderRequest.Categories[j].Category_Id + "'>" + obj.PurchaseOrderRequest.Categories[j].Category + "</option>");

                    $("#drpCategory").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrderRequest.Categories[j].Category + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }

            $("#drpColor").html("");

            $("#drpColor").append("<option value=''>Select Color</option>");

            $("#drpColor").parents('.form-group').find('ul').html("");

            $("#drpColor").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Color</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

            if (obj.PurchaseOrderRequest.Colors.length > 0) {

                for (var j = 0; j < obj.PurchaseOrderRequest.Colors.length; j++) {
                    debugger;

                    var i = j + 1;

                    $("#drpColor").append("<option value='" + obj.PurchaseOrderRequest.Colors[j].Colour_Id + "'>" + obj.PurchaseOrderRequest.Colors[j].Colour + "</option>");

                    $("#drpColor").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrderRequest.Colors[j].Colour + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }
        }
    });

    Reset_Detalis_After_Delete();
}

function Set_Sub_Category_Drp_Id(value) {
    debugger;

    var Article_No = $("#hdf_Article_No").val();

    $.ajax({

        url: "/PurchaseOrderRequest/Get_Details_By_Category_Article_No",

        data: { Article_No: Article_No, Category_Id: value },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("#drpSubCategory").html("");

            $("#drpSubCategory").append("<option value='0'>Select SubCategory.</option>");

            $("#drpSubCategory").parents('.form-group').find('ul').html("");

            $("#drpSubCategory").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select SubCategory.</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");


            if (obj.PurchaseOrderRequest.SubCategories.length > 0) {

                for (var j = 0; j < obj.PurchaseOrderRequest.SubCategories.length; j++) {
                    debugger;

                    var i = j + 1;

                    $("#drpSubCategory").append("<option value='" + obj.PurchaseOrderRequest.SubCategories[j].Sub_Category_Id + "'>" + obj.PurchaseOrderRequest.SubCategories[j].Sub_Category + "</option>");

                    $("#drpSubCategory").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrderRequest.SubCategories[j].Sub_Category + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }
        }
    });


}

function Get_Sizes() {

    Delete_Size_Row();

    var Size_Group_Id = $("#drpSize_Group").val();

    $.ajax({

        url: "/PurchaseOrderRequest/Get_Sizes",

        data: { size_group_Id: Size_Group_Id },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("#drpCenter_Size").html("");

            $("#drpCenter_Size").append("<option value=''>Select Center Size.</option>");

            $("#drpCenter_Size").parents('.form-group').find('ul').html("");

            $("#drpCenter_Size").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Center Size.</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");


            $("#drpTemp_Center_Size").html("");

            $("#drpTemp_Center_Size").append("<option value=''>Select Center Size.</option>");

            $("#drpTemp_Center_Size").parents('.form-group').find('ul').html("");

            $("#drpTemp_Center_Size").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Center Size.</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");


            if (obj.PurchaseOrderRequest.SizeGroups.length > 0) {
                 
                var tblHtml = '';

                var myTable = $("#tblPurchaseOrderRequestItems");

                var temptablecount = $("#tblPurchaseOrderRequestItems").find('[id^="PurchaseOrderRequestSizeRow_"]').size();

                i = temptablecount;

                tblHtml += "<tr id='PurchaseOrderRequestSizeRow_" + i + "' class='item-data-row'>";

                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";

                for (var j = 0; j < 15; j++) {


                    if (j < obj.PurchaseOrderRequest.SizeGroups.length) {
                        tblHtml += "<td>";
                        tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Name + "</span>";
                        tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Id + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                        tblHtml += "</td>";

                        debugger;

                        var K = j + 1;

                        $("#drpCenter_Size").append("<option value='" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Id + "'>" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Name + "</option>");

                        $("#drpCenter_Size").parents('.form-group').find('ul').append("<li rel='" + K + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Name + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                        //*************//

                        $("#drpTemp_Center_Size").append("<option value='" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Name + "'>" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Name + "</option>");

                        $("#drpTemp_Center_Size").parents('.form-group').find('ul').append("<li rel='" + K + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrderRequest.SizeGroups[j].Size_Name + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");
                        
                        //************//
                    }
                    else {
                        tblHtml += "<td>";
                        tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'></span>";
                        tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id" + i + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                        tblHtml += "</td>";
                    }
                }

                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";
                tblHtml += "<td></td>";

                tblHtml += "</tr>";

                var newRow = $(tblHtml);

                myTable.append(newRow);

            }
        }
    });


}

function AddPurchaseOrderRequestDetails() {

    var tdSizeCount = $("#tblPurchaseOrderRequestItems").find('[id^="PurchaseOrderRequestSizeRow_"]').size();

    var x = tdSizeCount;

    if (x != 0) {
        var x = tdSizeCount - 1;
    }

    var counter = 1;

    var size_group_id = $("#drpSize_Group").val();
    var size_group = document.getElementById("drpSize_Group");
    var size_group_name = size_group.options[size_group.selectedIndex].text;

    //var artical = $("#drpArticle_No").val();
    var artical = document.getElementById("drpArticle_No");
    var artical_no = artical.options[artical.selectedIndex].text;

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

    var myTable = $("#tblPurchaseOrderRequestItems");

    var temptablecount = $("#tblPurchaseOrderRequestItems").find('[id^="PurchaseOrderRequestItemRow_"]').size();

    i = temptablecount;

    tblHtml += "<tr id='PurchaseOrderRequestItemRow_" + i + "' class='item-data-row'>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Article_No' value='' id='textArticle_No_" + i + "' />";
    //tblHtml += "</td>";.

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textArticle_No_" + i + "'>" + artical_no + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + artical_no + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Article_No' id='hdnArticle_No_" + i + "' />";
    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Colour_Id' value='' id='textColour_Id_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textColour_Id_" + i + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Colour_Id'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textBrand_Name_" + i + "'>" + brand_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + brand_id + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textCategory_Name_" + i + "'>" + category_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + category_id + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textSub_Category_Name_" + i + "'>" + sub_category_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + sub_category_id + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Sub_Category_Id' id='hdnSub_Category_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;'  id='textSize_Group_Name" + i + "'>" + size_group_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size_group_id + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Size_Group_Id' id='hdnSize_Group_Id_" + i + "' />";
    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Start_Size' value='' id='textStart_Size_" + i + "' />";
    //tblHtml += "</td>";
    
    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textStart_Size_" + i + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Start_Size' onchange='Enable_Size_Quantity(" + i + ")'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textEnd_Size_" + i + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].End_Size' onchange='Enable_Size_Quantity(" + i + ")'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
    tblHtml += "</td>";                     

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].End_Size' value='' id='textEnd_Size_" + i + "' />";
    //tblHtml += "</td>";


    var size1 = $("#hdnSize1-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity1' value='0' id='textSize_Quantity_1-" + i + "'  onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size1 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id1' id='hdnSize_Id_1-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount1' id='hdnAmount_1-" + i + "' />";
    tblHtml += "</td>";

    var size2 = $("#hdnSize2-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity2' value='0' id='textSize_Quantity_2-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size2 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id2' id='hdnSize_Id_2-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount2' id='hdnAmount_2-" + i + "' />";
    tblHtml += "</td>";

    var size3 = $("#hdnSize3-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity3' value='0' id='textSize_Quantity_3-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size3 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id3' id='hdnSize_Id_3-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount3' id='hdnAmount_3-" + i + "' />";
    tblHtml += "</td>";

    var size4 = $("#hdnSize4-" + x).val();
    tblHtml += "<td>"; 
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity4' value='0' id='textSize_Quantity_4-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size4 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id4' id='hdnSize_Id_4-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount4' id='hdnAmount_4-" + i + "' />";
    tblHtml += "</td>";

    var size5 = $("#hdnSize5-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity5' value='0' id='textSize_Quantity_5-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size5 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id5' id='hdnSize_Id_5-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount5' id='hdnAmount_5-" + i + "' />";
    tblHtml += "</td>";

    var size6 = $("#hdnSize6-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity6' value='0' id='textSize_Quantity_6-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size6 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id6' id='hdnSize_Id_6-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount6' id='hdnAmount_6-" + i + "' />";
    tblHtml += "</td>";

    var size7 = $("#hdnSize7-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity7' value='0' id='textSize_Quantity_7-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size7 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id7' id='hdnSize_Id_7-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount7' id='hdnAmount_7-" + i + "' />";
    tblHtml += "</td>";

    var size8 = $("#hdnSize8-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity8' value='0' id='textSize_Quantity_8-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size8 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id8' id='hdnSize_Id_8-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount8' id='hdnAmount_8-" + i + "' />";
    tblHtml += "</td>";

    var size9 = $("#hdnSize9-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity9' value='0' id='textSize_Quantity_9-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size9 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id9' id='hdnSize_Id_9-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount9' id='hdnAmount_9-" + i + "' />";
    tblHtml += "</td>";

    var size10 = $("#hdnSize10-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity10' value='0' id='textSize_Quantity_10-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size10 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id10' id='hdnSize_Id_10-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount10' id='hdnAmount_10-" + i + "' />";
    tblHtml += "</td>";

    var size11 = $("#hdnSize11-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity11' value='0' id='textSize_Quantity_11-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size11 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id11' id='hdnSize_Id_11-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount11' id='hdnAmount_11-" + i + "' />";
    tblHtml += "</td>";

    var size12 = $("#hdnSize12-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity12' value='0' id='textSize_Quantity_12-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size12 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id12' id='hdnSize_Id_12-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount12' id='hdnAmount_12-" + i + "' />";
    tblHtml += "</td>";

    var size13 = $("#hdnSize13-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity13' value='0' id='textSize_Quantity_13-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size13 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id13' id='hdnSize_Id_13-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount13' id='hdnAmount_13-" + i + "' />";
    tblHtml += "</td>";

    var size14 = $("#hdnSize14-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity14' value='0' id='textSize_Quantity_14-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size14 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id14' id='hdnSize_Id_14-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount14' id='hdnAmount_14-" + i + "' />";
    tblHtml += "</td>";

    var size15 = $("#hdnSize15-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity15' value='0' id='textSize_Quantity_15-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size15 + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id15' id='hdnSize_Id_15-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount15' id='hdnAmount_15-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textTotal_Quantity_" + i + "'>0</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Item_Quantity' id='hdnTotal_Quantity_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textCenter_Size_" + i + "'>" + center_size + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + center_size + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Center_Size' id='hdnCenter_Size_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textPurchase_Price_" + i + "'>" + purchase_price + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + purchase_price + "'  name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Purchase_Price' id='hdnPurchase_Price_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textSize_Difference_" + i + "'>" + size_difference + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size_difference + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Size_Difference' id='hdnSize_Difference_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textTotal_Amount_" + i + "'>0</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Total_Amount' id='hdnTotal_Amount_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Comment' value='' id='textComment_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='continue-order-details" + i + "' disabled class='btn btn-success active' onclick='ContinuePurchaseOrderRequestDetailsData(" + i + ")'>Continue</button>";
    tblHtml += "<button type='button' id='delete-order-details' class='btn btn-danger active' onclick='DeletePurchaseOrderRequestDetailsData(" + i + ")'>Delete</button>";
    tblHtml += "</div>";
    tblHtml += "</td>";


    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);

    $("#PurchaseOrderRequestItemRow_" + i).addClass("PORI_Row_" + x);

    debugger;


    var $options = $("#drpTemp_Center_Size > option").clone();

    $("#textStart_Size_" + i).append($options);

    $("#textStart_Size_" + i).val('');


    var $optionss = $("#drpTemp_Center_Size > option").clone();

    $("#textEnd_Size_" + i).append($optionss);

    $("#textEnd_Size_" + i).val('');


    var $options1 = $("#drpColor > option").clone();

    $("#textColour_Id_" + i).append($options1);


    Add_Validation(i);

    //********//

    $("#hdnrecords_Validation").hide();
    
    //********//
}

function ContinuePurchaseOrderRequestDetailsData(j) {

    debugger;

    var tdSizeCount = $("#tblPurchaseOrderRequestItems").find('[id^="PurchaseOrderRequestSizeRow_"]').size();
    
    var x = tdSizeCount;

    if (x != 0)
    {
        var x = tdSizeCount - 1;
    }

    var counter = 1;

    var size_group_id = $("#hdnSize_Group_Id_" + j).val();
    var size_group_name = $("#textSize_Group_Name" + j).text();

    var artical_no = $("#textArticle_No_" + j).text();

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

    var myTable = $("#tblPurchaseOrderRequestItems");

    var temptablecount = $("#tblPurchaseOrderRequestItems").find('[id^="PurchaseOrderRequestItemRow_"]').size();

    var i = temptablecount;

    tblHtml += "<tr id='PurchaseOrderRequestItemRow_" + i + "' class='item-data-row'>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Article_No' value='' id='textArticle_No_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textArticle_No_" + i + "'>" + artical_no + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + artical_no + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Article_No' id='hdnArticle_No_" + i + "' />";
    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Colour_Id' value='' id='textColour_Id_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textColour_Id_" + i + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Colour_Id'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textBrand_Name_" + i + "'>" + brand_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + brand_id + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textCategory_Name_" + i + "'>" + category_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + category_id + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textSub_Category_Name_" + i + "'>" + sub_category_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + sub_category_id + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Sub_Category_Id' id='hdnSub_Category_Id_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;'  id='textSize_Group_Name" + i + "'>" + size_group_name + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size_group_id + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Size_Group_Id' id='hdnSize_Group_Id_" + i + "' />";
    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Start_Size' value='' id='textStart_Size_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textStart_Size_" + i + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Start_Size' onchange='Enable_Size_Quantity(" + i + ")'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textEnd_Size_" + i + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].End_Size' onchange='Enable_Size_Quantity(" + i + ")'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].End_Size' value='' id='textEnd_Size_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control  read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity1' value='0' id='textSize_Quantity_1-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_1-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id1' id='hdnSize_Id_1-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount1' id='hdnAmount_1-" + i + "' />";
    tblHtml += "</td>";


    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity2' value='0' id='textSize_Quantity_2-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_2-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id2' id='hdnSize_Id_2-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount2' id='hdnAmount_2-" + i + "' />";
    tblHtml += "</td>";


    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity3' value='0' id='textSize_Quantity_3-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_3-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id3' id='hdnSize_Id_3-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount3' id='hdnAmount_3-" + i + "' />";
    tblHtml += "</td>";


    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity4' value='0' id='textSize_Quantity_4-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_4-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id4' id='hdnSize_Id_4-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount4' id='hdnAmount_4-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity5' value='0' id='textSize_Quantity_5-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_5-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id5' id='hdnSize_Id_5-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount5' id='hdnAmount_5-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity6' value='0' id='textSize_Quantity_6-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_6-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id6' id='hdnSize_Id_6-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount6' id='hdnAmount_6-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity7' value='0' id='textSize_Quantity_7-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_7-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id7' id='hdnSize_Id_7-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount7' id='hdnAmount_7-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity8' value='0' id='textSize_Quantity_8-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_8-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id8' id='hdnSize_Id_8-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount8' id='hdnAmount_8-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity9' value='0' id='textSize_Quantity_9-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_9-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id9' id='hdnSize_Id_9-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount9' id='hdnAmount_9-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity10' value='0' id='textSize_Quantity_10-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_10-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id10' id='hdnSize_Id_10-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount10' id='hdnAmount_10-" + i + "' />";
    tblHtml += "</td>";


    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity11' value='0' id='textSize_Quantity_11-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_11-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id11' id='hdnSize_Id_11-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount11' id='hdnAmount_11-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity12' value='0' id='textSize_Quantity_12-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_12-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id12' id='hdnSize_Id_12-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount12' id='hdnAmount_12-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity13' value='0' id='textSize_Quantity_13-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_13-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id13' id='hdnSize_Id_13-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount13' id='hdnAmount_13-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity14' value='0' id='textSize_Quantity_14-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_14-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id14' id='hdnSize_Id_14-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount14' id='hdnAmount_14-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrderRequest.Sizes[" + i + "].Quantity15' value='0' id='textSize_Quantity_15-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_15-" + (i - 1)).val() + "' name='PurchaseOrderRequest.Sizes[" + i + "].Size_Id15' id='hdnSize_Id_15-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrderRequest.Sizes[" + i + "].Amount15' id='hdnAmount_15-" + i + "' />";
    tblHtml += "</td>";


    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textTotal_Quantity_" + i + "'>0</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Item_Quantity' id='hdnTotal_Quantity_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textCenter_Size_" + i + "'>" + center_size + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + center_size + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Center_Size' id='hdnCenter_Size_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textPurchase_Price_" + i + "'>" + purchase_price + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + purchase_price + "'  name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Purchase_Price' id='hdnPurchase_Price_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textSize_Difference_" + i + "'>" + size_difference + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size_difference + "' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Size_Difference' id='hdnSize_Difference_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textTotal_Amount_" + i + "'>0</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Total_Amount' id='hdnTotal_Amount_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Comment' value='' id='textComment_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='continue-order-details" + i + "' disabled class='btn btn-success active' onclick='ContinuePurchaseOrderRequestDetailsData(" + i + ")'>Continue</button>";
    tblHtml += "<button type='button' id='delete-order-details' class='btn btn-danger active' onclick='DeletePurchaseOrderRequestDetailsData(" + i + ")'>Delete</button>";
    tblHtml += "</div>";
    tblHtml += "</td>";


    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);

    $("#PurchaseOrderRequestItemRow_" + i).addClass("PORI_Row_" + x);
    
    var $options = $("#drpTemp_Center_Size > option").clone();

    $("#textStart_Size_" + i).append($options);

    $("#textStart_Size_" + i).val('');


    var $optionss = $("#drpTemp_Center_Size > option").clone();

    $("#textEnd_Size_" + i).append($optionss);

    $("#textEnd_Size_" + i).val('');


    var $options1 = $("#drpColor > option").clone();

    $("#textColour_Id_" + i).append($options1);


    Add_Validation(i);

}

function CalculateRowAmount(i) {

    debugger;

    var index = document.getElementById("drpCenter_Size").selectedIndex;

    var count = document.getElementById("drpCenter_Size").length;

    index = index;

    //var temptablecount = $("#tblPurchaseOrderRequestItems").find('[id^="PurchaseOrderRequestSizeRow_"]').size();

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
            $("#hdnAmount_" + j + "-" + x).val(purchase_price);
        }
        else {
            var computation = parseInt(purchase_price) - parseInt(size_difference_temp);

            $("#hdnAmount_" + j + "-" + x).val(computation);

        }
        size_difference_temp = parseInt(size_difference_temp) + parseInt(size_diff_count);

    }

    //////////////////////////////////////////////////////////////////////////////////////

    var size_difference_temp = 0;

    size_diff_count = size_difference;

    for (var j = index + 1; j < count; j++) {

        size_difference_temp = parseInt(size_difference_temp) + parseInt(size_diff_count);

        var computation = parseInt(purchase_price) + parseInt(size_difference_temp);
        $("#hdnAmount_" + j + "-" + x).val(computation);

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

        var Qty = parseFloat($("#tblPurchaseOrderRequestItems").find('[id="textSize_Quantity_' + (j + 1) + '-' + i + '"]').val());

        if (isNaN(Qty))
            Qty = 0;

        var WSR = parseFloat($("#tblPurchaseOrderRequestItems").find('[id="hdnAmount_' + (j + 1) + '-' + i + '"]').val());

        var Amount = parseFloat(WSR * Qty);

        $("#tblPurchaseOrderRequestItems").find('[id="textAmount_' + i + '"]').val(Amount);

        sum_row_quantity = sum_row_quantity + Qty;

        sum_row_amount = sum_row_amount + Amount;

        document.getElementById('textTotal_Quantity_' + i).innerText = sum_row_quantity;

        document.getElementById('textTotal_Amount_' + i).innerText = sum_row_amount;

        $("#tblPurchaseOrderRequestItems").find('[id="hdnTotal_Quantity_' + i + '"]').val(sum_row_quantity);

        $("#tblPurchaseOrderRequestItems").find('[id="hdnTotal_Amount_' + i + '"]').val(sum_row_amount);
       
        if (sum_row_quantity > 0) {

            $("#hdnrecords_Validation").hide();
        }
    }


    /// Total ///

    var sumQuantity = 0;

    var sumWSRAmount = 0;

    if (i >= 0) {

        for (var j = 0; j <= i ; j++) {

            var Qty = parseFloat($("#tblPurchaseOrderRequestItems").find('[id="textTotal_Quantity_' + j + '"]').text());

            var Amount = parseFloat($("#tblPurchaseOrderRequestItems").find('[id="textTotal_Amount_' + j + '"]').text());

            sumWSRAmount = sumWSRAmount + Amount;

            sumQuantity = sumQuantity + Qty;
           
        }
    }


    document.getElementById('tdTotalQuantity').innerText = sumQuantity;

    document.getElementById('tdNetAmount').innerText = sumWSRAmount;

    $("#tblPurchaseOrderRequestCalculation").find('[id="hdnTotalQuantity"]').val(sumQuantity);

    $("#tblPurchaseOrderRequestCalculation").find('[id="hdnNetAmount"]').val(sumWSRAmount);


    if ($("#hdnTotalQuantity").val() != 0) {
        document.getElementById('continue-order-details' + i).disabled = false;
    }

}

function Enable_Size_Quantity(i) {

    debugger;

    var start = document.getElementById("textStart_Size_" + i).selectedIndex;

    var end = document.getElementById("textEnd_Size_" + i).selectedIndex;

    //$(".read-only").attr("readonly", true);
    
    //$(".read-only").rules("remove");

    $("#textStart_Size_" + i).parents('tr').find(".read-only").attr("readonly", true);

    $("#textStart_Size_" + i).parents('tr').find(".read-only").rules("remove");

    $("#textStart_Size_" + i).parents('tr').find(".read-only").val(0);


    $("#textEnd_Size_" + i).parents('tr').find(".read-only").attr("readonly", true);

    $("#textEnd_Size_" + i).parents('tr').find(".read-only").rules("remove");

    $("#textEnd_Size_" + i).parents('tr').find(".read-only").val(0);

    if (start <= end) {

        for (var j = start; j <= end; j++) {

            $("#textSize_Quantity_" + j + "-" + i).attr("readonly", false);

            $("#textSize_Quantity_" + j + "-" + i).val('');

            $("#textSize_Quantity_" + j + "-" + i).rules("add", { required: true, digits: true, messages: { required: "Quantity is required.", digits: "Enter only digits." } });
        }
    }

    CalculateRowQuantity(i);
}

function Add_Validation(i) {

    $("#textColour_Id_" + i).rules("add", { required: true, messages: { required: "Color is required." } });
    $("#textStart_Size_" + i).rules("add", { required: true, messages: { required: "Start size is required.", } });
    $("#textEnd_Size_" + i).rules("add", { required: true, messages: { required: "End size is required.", } });
   

}

function Show_Button() {

    if ($("#drpSize_Group").val() != '') {
    document.getElementById("btnAddSizesPurchaseOrderRequest").disabled = false;
}
    else {
        document.getElementById("btnAddSizesPurchaseOrderRequest").disabled = true;
    }
}

function Reset_Details() {

    debugger;

    $("#textPurchase_Price").val(0);
   
    $("#textSize_Difference").val(0);
    //document.getElementById("drpCenter_Size").selectedIndex = 0;
}

function Delete_Size_Row() {

    var temptablecount = $("#tblPurchaseOrderRequestItems").find('[id^="PurchaseOrderRequestSizeRow_"]').size();

    k = temptablecount;

    if (k != 0) {
        k = k - 1;
    }

    var count = $("#tblPurchaseOrderRequestItems").find(".PORI_Row_" + k).size();

    if (count == 0) {
        $("#tblPurchaseOrderRequestItems").find("[id='PurchaseOrderRequestSizeRow_" + k + "']").remove();
    }

}

function Disable_AddDetalis_Button() {

    var temptablecount = $("#tblPurchaseOrderRequestItems").find('[id^="PurchaseOrderRequestItemRow_"]').size();

    j = temptablecount;

    for (var i = 0; i < j; i++) {

        // $("#continue-order-details" + i).parents('tr').find(".POI_Row_" + k).attr("disabled", true);

        document.getElementById("continue-order-details" + i).disabled = true;
    }

}

function Reset_Detalis_After_Delete() {

    debugger;

    var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderItemRow_"]').size();

    j = temptablecount;

    for (var i = 0; i < j; i++) {

        var qty = $("#hdnTotal_Quantity_" + i).val();

        var amt = $("#hdnTotal_Amount_" + i).val();

        var total_qty = 0;

        var total_amt = 0;

        if (qty != 0 || qty != null) {

            total_qty = parseInt(total_qty) + parseInt(qty);
        }

        if (amt != 0 || amt != null) {

            total_amt = parseInt(total_amt) + parseInt(amt);
        }

        document.getElementById('tdTotalQuantity').innerText = total_qty;

        document.getElementById('tdNetAmount').innerText = total_amt;

        $("#tblPurchaseOrderRequestCalculation").find('[id="hdnTotalQuantity"]').val(total_qty);

        $("#tblPurchaseOrderRequestCalculation").find('[id="hdnNetAmount"]').val(total_amt);
    }

    if (j == 0) {

        document.getElementById('tdTotalQuantity').innerText = 0;

        document.getElementById('tdNetAmount').innerText = 0;

        $("#tblPurchaseOrderRequestCalculation").find('[id="hdnTotalQuantity"]').val(0);

        $("#tblPurchaseOrderRequestCalculation").find('[id="hdnNetAmount"]').val(0);

        //***********//
        $("#hdnrecords_Validation").show();

        $("#records_Message").html("Minimum one Record  is Required");
        //***********//
    }
}

function DeletePurchaseOrderRequestDetailsData(i) {

    debugger;

    $("#tblPurchaseOrderRequestItems").find("[id='PurchaseOrderRequestItemRow_" + i + "']").remove();

    ReArrangePurchaseOrderRequestDetailsData();

    Reset_Detalis_After_Delete();
        
}

function ReArrangePurchaseOrderRequestDetailsData() {

    debugger;

    $("#tblPurchaseOrderRequestItems").find("[id^='PurchaseOrderRequestItemRow_']").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'PurchaseOrderRequestItemRow_' + i

            var newTR = "#" + $(row)[0].id + " td";

            if ($(newTR).find("[id^='textArticle_No_']").length > 0) {
                $(newTR).find("[id^='textArticle_No_']")[0].id = "textArticle_No_" + i;
                $(newTR).find("[id^='hdnArticle_No_']")[0].id = "hdnArticle_No_" + i;
                $(newTR).find("[id^='hdnArticle_No_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Article_No");
            }

            if ($(newTR).find("[id^='textColour_Id_']").length > 0) {
                $(newTR).find("[id^='textColour_Id_']")[0].id = "textColour_Id_" + i;
                $(newTR).find("[id^='textColour_Id_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Colour_Id");
            }

            if ($(newTR).find("[id^='textBrand_Name_']").length > 0) {
                $(newTR).find("[id^='textBrand_Name_']")[0].id = "textBrand_Name_" + i;
                $(newTR).find("[id^='hdnBrand_Id_']")[0].id = "hdnBrand_Id_" + i;
                $(newTR).find("[id^='hdnBrand_Id_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Brand_Id");
            }

            if ($(newTR).find("[id^='textCategory_Name_']").length > 0) {
                $(newTR).find("[id^='textCategory_Name_']")[0].id = "textCategory_Name_" + i;
                $(newTR).find("[id^='hdnCategory_Id_']")[0].id = "hdnCategory_Id_" + i;
                $(newTR).find("[id^='hdnCategory_Id_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Category_Id");
            }

            if ($(newTR).find("[id^='textSub_Category_Name_']").length > 0) {
                $(newTR).find("[id^='textSub_Category_Name_']")[0].id = "textSub_Category_Name_" + i;
                $(newTR).find("[id^='hdnSub_Category_Id_']")[0].id = "hdnSub_Category_Id_" + i;
                $(newTR).find("[id^='hdnSub_Category_Id_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Sub_Category_Id");
            }

            if ($(newTR).find("[id^='textSize_Group_Name']").length > 0) {
                $(newTR).find("[id^='textSize_Group_Name']")[0].id = "textSize_Group_Name" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']")[0].id = "hdnSize_Group_Id_" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Size_Group_Id");
            }

            if ($(newTR).find("[id^='textSize_Group_Name']").length > 0) {
                $(newTR).find("[id^='textSize_Group_Name']")[0].id = "textSize_Group_Name" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']")[0].id = "hdnSize_Group_Id_" + i;
                $(newTR).find("[id^='hdnSize_Group_Id_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Size_Group_Id");
            }

            if ($(newTR).find("[id^='textStart_Size_']").length > 0) {
                $(newTR).find("[id^='textStart_Size_']")[0].id = "textStart_Size_" + i;
                $(newTR).find("[id^='textStart_Size_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Start_Size");
                $(newTR).find("[id^='textStart_Size_-']").attr("onchange", "Enable_Size_Quantity(" + i + ")");
            }

            if ($(newTR).find("[id^='textEnd_Size_']").length > 0) {
                $(newTR).find("[id^='textEnd_Size_']")[0].id = "textEnd_Size_" + i;
                $(newTR).find("[id^='textEnd_Size_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].End_Size");
                $(newTR).find("[id^='textEnd_Size_-']").attr("onchange", "Enable_Size_Quantity(" + i + ")");
            }


            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            debugger;



            if ($(newTR).find("[id^='textSize_Quantity_1-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_1-']")[0].id = "textSize_Quantity_1-" + i;
                $(newTR).find("[id^='textSize_Quantity_1-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity1");
                $(newTR).find("[id^='textSize_Quantity_1-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_1-']")[0].id = "hdnSize_Id_1-" + i;
                $(newTR).find("[id^='hdnSize_Id_1-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id1");
                $(newTR).find("[id^='hdnSize_Id_1-']").attr("value", $("#hdnSize_Id_1-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_1-']")[0].id = "hdnAmount_1-" + i;
                $(newTR).find("[id^='hdnAmount_1-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount1");

            }

            if ($(newTR).find("[id^='textSize_Quantity_2-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_2-']")[0].id = "textSize_Quantity_2-" + i;
                $(newTR).find("[id^='textSize_Quantity_2-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity2");
                $(newTR).find("[id^='textSize_Quantity_2-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_2-']")[0].id = "hdnSize_Id_2-" + i;
                $(newTR).find("[id^='hdnSize_Id_2-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id2");
                $(newTR).find("[id^='hdnSize_Id_2-']").attr("value", $("#hdnSize_Id_2-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_2-']")[0].id = "hdnAmount_2-" + i;
                $(newTR).find("[id^='hdnAmount_2-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount2");
            }

            if ($(newTR).find("[id^='textSize_Quantity_3-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_3-']")[0].id = "textSize_Quantity_3-" + i;
                $(newTR).find("[id^='textSize_Quantity_3-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity3");
                $(newTR).find("[id^='textSize_Quantity_3-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_3-']")[0].id = "hdnSize_Id_3-" + i;
                $(newTR).find("[id^='hdnSize_Id_3-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id3");
                $(newTR).find("[id^='hdnSize_Id_3-']").attr("value", $("#hdnSize_Id_3-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_3-']")[0].id = "hdnAmount_3-" + i;
                $(newTR).find("[id^='hdnAmount_3-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount3");
            }

            if ($(newTR).find("[id^='textSize_Quantity_4-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_4-']")[0].id = "textSize_Quantity_4-" + i;
                $(newTR).find("[id^='textSize_Quantity_4-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity4");
                $(newTR).find("[id^='textSize_Quantity_4-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_4-']")[0].id = "hdnSize_Id_4-" + i;
                $(newTR).find("[id^='hdnSize_Id_4-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id4");
                $(newTR).find("[id^='hdnSize_Id_4-']").attr("value", $("#hdnSize_Id_4-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_4-']")[0].id = "hdnAmount_4-" + i;
                $(newTR).find("[id^='hdnAmount_4-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount4");
            }

            if ($(newTR).find("[id^='textSize_Quantity_5-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_5-']")[0].id = "textSize_Quantity_5-" + i;
                $(newTR).find("[id^='textSize_Quantity_5-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity5");
                $(newTR).find("[id^='textSize_Quantity_5-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_5-']")[0].id = "hdnSize_Id_5-" + i;
                $(newTR).find("[id^='hdnSize_Id_5-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id5");
                $(newTR).find("[id^='hdnSize_Id_5-']").attr("value", $("#hdnSize_Id_5-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_5-']")[0].id = "hdnAmount_5-" + i;
                $(newTR).find("[id^='hdnAmount_5-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount5");
            }

            if ($(newTR).find("[id^='textSize_Quantity_6']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_6-']")[0].id = "textSize_Quantity_6-" + i;
                $(newTR).find("[id^='textSize_Quantity_6-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity6");
                $(newTR).find("[id^='textSize_Quantity_6-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_6-']")[0].id = "hdnSize_Id_6-" + i;
                $(newTR).find("[id^='hdnSize_Id_6-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id6");
                $(newTR).find("[id^='hdnSize_Id_6-']").attr("value", $("#hdnSize_Id_6-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_6-']")[0].id = "hdnAmount_6-" + i;
                $(newTR).find("[id^='hdnAmount_6-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount6");
            }

            if ($(newTR).find("[id^='textSize_Quantity_7-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_7-']")[0].id = "textSize_Quantity_7-" + i;
                $(newTR).find("[id^='textSize_Quantity_7-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity7");
                $(newTR).find("[id^='textSize_Quantity_7-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_7-']")[0].id = "hdnSize_Id_7-" + i;
                $(newTR).find("[id^='hdnSize_Id_7-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id7");
                $(newTR).find("[id^='hdnSize_Id_7-']").attr("value", $("#hdnSize_Id_7-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_7-']")[0].id = "hdnAmount_7-" + i;
                $(newTR).find("[id^='hdnAmount_7-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount7");
            }

            if ($(newTR).find("[id^='textSize_Quantity_8-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_8-']")[0].id = "textSize_Quantity_8-" + i;
                $(newTR).find("[id^='textSize_Quantity_8-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity8");
                $(newTR).find("[id^='textSize_Quantity_8-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_8-']")[0].id = "hdnSize_Id_8-" + i;
                $(newTR).find("[id^='hdnSize_Id_8-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id8");
                $(newTR).find("[id^='hdnSize_Id_8-']").attr("value", $("#hdnSize_Id_8-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_8-']")[0].id = "hdnAmount_8-" + i;
                $(newTR).find("[id^='hdnAmount_8-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount8");
            }

            if ($(newTR).find("[id^='textSize_Quantity_9-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_9-']")[0].id = "textSize_Quantity_9-" + i;
                $(newTR).find("[id^='textSize_Quantity_9-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity9");
                $(newTR).find("[id^='textSize_Quantity_9-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_9-']")[0].id = "hdnSize_Id_9-" + i;
                $(newTR).find("[id^='hdnSize_Id_9-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id9");
                $(newTR).find("[id^='hdnSize_Id_9-']").attr("value", $("#hdnSize_Id_9-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_9-']")[0].id = "hdnAmount_9-" + i;
                $(newTR).find("[id^='hdnAmount_9-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount9");
            }

            if ($(newTR).find("[id^='textSize_Quantity_10-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_10-']")[0].id = "textSize_Quantity_10-" + i;
                $(newTR).find("[id^='textSize_Quantity_10-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity10");
                $(newTR).find("[id^='textSize_Quantity_10-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_10-']")[0].id = "hdnSize_Id_10-" + i;
                $(newTR).find("[id^='hdnSize_Id_10-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id10");
                $(newTR).find("[id^='hdnSize_Id_10-']").attr("value", $("#hdnSize_Id_10-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_10-']")[0].id = "hdnAmount_10-" + i;
                $(newTR).find("[id^='hdnAmount_10-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount10");
            }

            if ($(newTR).find("[id^='textSize_Quantity_11-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_11-']")[0].id = "textSize_Quantity_11-" + i;
                $(newTR).find("[id^='textSize_Quantity_11-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity11");
                $(newTR).find("[id^='textSize_Quantity_11-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_11-']")[0].id = "hdnSize_Id_11-" + i;
                $(newTR).find("[id^='hdnSize_Id_11-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id11");
                $(newTR).find("[id^='hdnSize_Id_11-']").attr("value", $("#hdnSize_Id_11-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_11-']")[0].id = "hdnAmount_11-" + i;
                $(newTR).find("[id^='hdnAmount_11-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount11");
            }

            if ($(newTR).find("[id^='textSize_Quantity_12-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_12-']")[0].id = "textSize_Quantity_12-" + i;
                $(newTR).find("[id^='textSize_Quantity_12-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity12");
                $(newTR).find("[id^='textSize_Quantity_12-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_12-']")[0].id = "hdnSize_Id_12-" + i;
                $(newTR).find("[id^='hdnSize_Id_12-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id12");
                $(newTR).find("[id^='hdnSize_Id_12-']").attr("value", $("#hdnSize_Id_12-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_12-']")[0].id = "hdnAmount_12-" + i;
                $(newTR).find("[id^='hdnAmount_12-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount12");
            }

            if ($(newTR).find("[id^='textSize_Quantity_13-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_13-']")[0].id = "textSize_Quantity_13-" + i;
                $(newTR).find("[id^='textSize_Quantity_13-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity13");
                $(newTR).find("[id^='textSize_Quantity_13-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_13-']")[0].id = "hdnSize_Id_13-" + i;
                $(newTR).find("[id^='hdnSize_Id_13-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id13");
                $(newTR).find("[id^='hdnSize_Id_13-']").attr("value", $("#hdnSize_Id_13-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_13-']")[0].id = "hdnAmount_13-" + i;
                $(newTR).find("[id^='hdnAmount_13-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount13");
            }

            if ($(newTR).find("[id^='textSize_Quantity_14-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_14-']")[0].id = "textSize_Quantity_14-" + i;
                $(newTR).find("[id^='textSize_Quantity_14-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity14");
                $(newTR).find("[id^='textSize_Quantity_14-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_14-']")[0].id = "hdnSize_Id_14-" + i;
                $(newTR).find("[id^='hdnSize_Id_14-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id14");
                $(newTR).find("[id^='hdnSize_Id_14-']").attr("value", $("#hdnSize_Id_14-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_14-']")[0].id = "hdnAmount_14-" + i;
                $(newTR).find("[id^='hdnAmount_14-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount14");
            }

            if ($(newTR).find("[id^='textSize_Quantity_15-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_15-']")[0].id = "textSize_Quantity_15-" + i;
                $(newTR).find("[id^='textSize_Quantity_15-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Quantity15");
                $(newTR).find("[id^='textSize_Quantity_15-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_15-']")[0].id = "hdnSize_Id_15-" + i;
                $(newTR).find("[id^='hdnSize_Id_15-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Size_Id15");
                $(newTR).find("[id^='hdnSize_Id_15-']").attr("value", $("#hdnSize_Id_15-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_15-']")[0].id = "hdnAmount_15-" + i;
                $(newTR).find("[id^='hdnAmount_15-']").attr("name", "PurchaseOrderRequest.Sizes[" + i + "].Amount15");
            }

            debugger;


            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            if ($(newTR).find("[id^='textTotal_Quantity_']").length > 0) {
                $(newTR).find("[id^='textTotal_Quantity_']")[0].id = "textTotal_Quantity_" + i;
                $(newTR).find("[id^='hdnTotal_Quantity_']")[0].id = "hdnTotal_Quantity_" + i;
                $(newTR).find("[id^='hdnTotal_Quantity_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Item_Quantity");
            }

            if ($(newTR).find("[id^='textCenter_Size_']").length > 0) {
                $(newTR).find("[id^='textCenter_Size_']")[0].id = "textCenter_Size_" + i;
                $(newTR).find("[id^='hdnCenter_Size_']")[0].id = "hdnCenter_Size_" + i;
                $(newTR).find("[id^='hdnCenter_Size_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Center_Size");
            }

            if ($(newTR).find("[id^='textPurchase_Price_']").length > 0) {
                $(newTR).find("[id^='textPurchase_Price_']")[0].id = "textPurchase_Price_" + i;
                $(newTR).find("[id^='hdnPurchase_Price_']")[0].id = "hdnPurchase_Price_" + i;
                $(newTR).find("[id^='hdnPurchase_Price_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Purchase_Price");
            }

            if ($(newTR).find("[id^='textSize_Difference_']").length > 0) {
                $(newTR).find("[id^='textSize_Difference_']")[0].id = "textSize_Difference_" + i;
                $(newTR).find("[id^='hdnSize_Difference_']")[0].id = "hdnSize_Difference_" + i;
                $(newTR).find("[id^='hdnSize_Difference_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Size_Difference");
            }

            if ($(newTR).find("[id^='textTotal_Amount_']").length > 0) {
                $(newTR).find("[id^='textTotal_Amount_']")[0].id = "textTotal_Amount_" + i;
                $(newTR).find("[id^='hdnTotal_Amount_']")[0].id = "hdnTotal_Amount_" + i;
                $(newTR).find("[id^='hdnTotal_Amount_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Total_Amount");
            }

            if ($(newTR).find("[id^='textComment_']").length > 0) {
                $(newTR).find("[id^='textComment_']")[0].id = "textComment_" + i;
                $(newTR).find("[id^='textComment_']").attr("name", "PurchaseOrderRequest.PurchaseOrderRequests[" + i + "].Comment");
            }
            
            if ($(newTR).find("[id^='continue-order-details']").length > 0) {
                $(newTR).find("[id^='continue-order-details']").attr("onclick", "ContinuePurchaseOrderRequestDetailsData(" + i + ")");
            }

            if ($(newTR).find("[id='delete-order-details']").length > 0) {
                $(newTR).find("[id='delete-order-details']").attr("onclick", "DeletePurchaseOrderRequestDetailsData(" + i + ")");
            }
        }
    });

}


//added by vinod mane on 12/10/2016
function ClearAllDropdownlist() {
    //$("#drpArticle_No").val('');
    //$("#drpBrand").val('');
    //$("#drpCategory").val('');
    //$("#drpSubCategory").val('');   
    //$("#drpCenter_Size").val('');
    $("#drpSize_Group").val('');

    $("#drpArticle_No").html("");
    $("#drpArticle_No").append("<option value=''>Select Article No.</option>");
    $("#drpArticle_No").parents('.form-group').find('ul').html("");

    $("#drpBrand").html("");
    $("#drpBrand").append("<option value=''>Select Brand</option>");
    $("#drpBrand").parents('.form-group').find('ul').html("");

    $("#drpCategory").html("");
    $("#drpCategory").append("<option value=''>Select Category</option>");
    $("#drpCategory").parents('.form-group').find('ul').html("");

    $("#drpSubCategory").html("");
    $("#drpSubCategory").append("<option value=''>Select SubCategory.</option>");
    $("#drpSubCategory").parents('.form-group').find('ul').html("");

    $("#drpCenter_Size").html("");
    $("#drpCenter_Size").append("<option value=''>Select Center Size.</option>");
    $("#drpCenter_Size").parents('.form-group').find('ul').html("");

}

