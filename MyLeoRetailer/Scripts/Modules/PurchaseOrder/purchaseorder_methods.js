function Set_Vendor_Id(value) {

    $(".Details").hide();

    //added by vinod mane on 10/10/2016
    $("#tblPurchaseOrderItems").find("tr:gt(0)").remove();    
    document.getElementById('tdTotalQuantity').innerText = 0;
    document.getElementById('tdNetAmount').innerText = 0;
    $('#hdf_Vendor_Id').val(value);
    
    ClearAllDropdownlist();   

    //End
    
    $.ajax({

        url: "/PurchaseOrder/Get_Details_By_Vendor_Id",

        data: { Vendor_Id: value },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);


            $("#drpArticle_No").html("");

            $("#drpArticle_No").append("<option value=''>Select Article No.</option>");

            $("#drpArticle_No").parents('.form-group').find('ul').html("");

            $("#drpArticle_No").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Article No.</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");
            
            if (obj.PurchaseOrder.Vendors.length > 0) {

                for (var j = 0; j < obj.PurchaseOrder.Vendors.length; j++) {
                    debugger;
                                       
                    var i = j + 1;
                   
                    $("#drpArticle_No").append("<option value='" + obj.PurchaseOrder.Vendors[j].Article_No + "'>" + obj.PurchaseOrder.Vendors[j].Article_No + "</option>");

                    $("#drpArticle_No").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrder.Vendors[j].Article_No + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }

            $("#drpColor").html("");

            $("#drpColor").append("<option value=''>Select Color</option>");

            $("#drpColor").parents('.form-group').find('ul').html("");

            $("#drpColor").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Color</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

            if (obj.PurchaseOrder.Colors.length > 0) {

                for (var j = 0; j < obj.PurchaseOrder.Colors.length; j++) {
                    debugger;

                    var i = j + 1;

                    $("#drpColor").append("<option value='" + obj.PurchaseOrder.Colors[j].Colour_Id + "'>" + obj.PurchaseOrder.Colors[j].Colour + "</option>");

                    $("#drpColor").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrder.Colors[j].Colour + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }
           
        }
    });

   
    Get_Consolidate_Purchase_Orders(value);
   
    debugger;
       
}

function Set_Article_No(value) {

    $("#hdf_Article_No").val(value);

    $(".Details").hide();
       
    $.ajax({

        url: "/PurchaseOrder/Get_Details_By_Article_No",

        data: { Article_No: value },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("#drpSize_Group").html("");

            $("#drpSize_Group").append("<option value=''>Select Size Group</option>");

            $("#drpSize_Group").parents('.form-group').find('ul').html("");

            $("#drpSize_Group").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Size Group</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

            if (obj.PurchaseOrder.SizeGroups.length > 0) {

                for (var j = 0; j < obj.PurchaseOrder.SizeGroups.length; j++) {
                    debugger;

                    var i = j + 1;

                    $("#drpSize_Group").append("<option value='" + obj.PurchaseOrder.SizeGroups[j].Size_Group_Id + "'>" + obj.PurchaseOrder.SizeGroups[j].Size_Group_Name + "</option>");

                    $("#drpSize_Group").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrder.SizeGroups[j].Size_Group_Name + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }

            $("#drpBrand").html("");

            $("#drpBrand").append("<option value=''>Select Brand</option>");

            $("#drpBrand").parents('.form-group').find('ul').html("");

            $("#drpBrand").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Brand</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

            if (obj.PurchaseOrder.Brands.length > 0) {

                for (var j = 0; j < obj.PurchaseOrder.Brands.length; j++) {
                    debugger;

                    var i = j + 1;

                    $("#drpBrand").append("<option value='" + obj.PurchaseOrder.Brands[j].Brand_Id + "'>" + obj.PurchaseOrder.Brands[j].Brand_Name + "</option>");

                    $("#drpBrand").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrder.Brands[j].Brand_Name + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }

            if (obj.PurchaseOrder.Categories.length > 0) {

                $("#drpCategory").html("");

                $("#drpCategory").append("<option value=''>Select Category</option>");

                $("#drpCategory").parents('.form-group').find('ul').html("");

                $("#drpCategory").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select Category</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                if (obj.PurchaseOrder.Categories.length > 0) {

                    for (var j = 0; j < obj.PurchaseOrder.Categories.length; j++) {
                        debugger;
                        var i = j + 1;

                        $("#drpCategory").append("<option value='" + obj.PurchaseOrder.Categories[j].Category_Id + "'>" + obj.PurchaseOrder.Categories[j].Category + "</option>");

                        $("#drpCategory").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrder.Categories[j].Category + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                    }
                }
            }

           
        }
    });
    
}

function Set_Sub_Category_Drp_Id(value) {
    debugger;

    var Article_No = $("#hdf_Article_No").val();

    $.ajax({

        url: "/PurchaseOrder/Get_Details_By_Category_Article_No",

        data: { Article_No: Article_No, Category_Id: value },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);

            $("#drpSubCategory").html("");

            $("#drpSubCategory").append("<option value=''>Select SubCategory.</option>");

            $("#drpSubCategory").parents('.form-group').find('ul').html("");

            $("#drpSubCategory").parents('.form-group').find('ul').append("<li rel='0' class=''><a style='' class='' tabindex='0'><span class='text'>Select SubCategory.</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");


            if (obj.PurchaseOrder.SubCategories.length > 0) {

                for (var j = 0; j < obj.PurchaseOrder.SubCategories.length; j++) {
                    debugger;
                    var i = j + 1;

                    $("#drpSubCategory").append("<option value='" + obj.PurchaseOrder.SubCategories[j].Sub_Category_Id + "'>" + obj.PurchaseOrder.SubCategories[j].Sub_Category + "</option>");

                    $("#drpSubCategory").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrder.SubCategories[j].Sub_Category + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");

                }
            }


        }
    });


}

function Get_Consolidate_Purchase_Orders(value) {

    $.ajax({

        url: "/PurchaseOrder/Get_Consolidate_Purchase_Orders",

        data: { Vendor_Id: value },

        type: 'POST',

        success: function (response) {

            var obj = $.parseJSON(response);

            debugger;

            if (obj.PurchaseOrder.PurchaseOrders.length > 0) {               

                var qty = 0;

                var amt = 0;

                for (var i = 0; i < obj.PurchaseOrder.PurchaseOrders.length; i++) {

                    var html = '';

                    var tblHtml = '';

                    var myTable = $("#tblPurchaseOrderItems");

                    tblHtml += "<tr id='PurchaseOrderSizeRow_" + i + "' class='item-data-row'>";

                    //**************************************************************************************//

                    tblHtml += "<td></td>";
                    tblHtml += "<td></td>";
                    tblHtml += "<td></td>";
                    tblHtml += "<td></td>";
                    tblHtml += "<td></td>";
                    tblHtml += "<td></td>";
                    tblHtml += "<td></td>";
                    tblHtml += "<td></td>";
                  
                    for (var j = 0; j < 15; j++) {

                        if (j < obj.PurchaseOrder.PurchaseOrders[i].Sizes.length) {

                            debugger;

                            if ((j + 1) == 1 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id1 != 0)
                            {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id1 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 2 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id2 != 0)
                            {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id2 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 3 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id3 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id3 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 4 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id4 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id4 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 5 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id5 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id5 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 6 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id6 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id6 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 7 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id7 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id7 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 8 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id8 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id8 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 9 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id9 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id9 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 10 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id10 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id10 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 11 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id11 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id11 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 12 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id12 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id12 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 13 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id13 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id13 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 14 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id14 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id14 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 15 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id15 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Name + "</span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id15 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else {
                                tblHtml += "<td>";
                                tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'></span>";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }

                        }

                        else
                        {
                            tblHtml += "<td>";
                            tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'></span>";
                            tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
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


                    //**************************************************************************************//
                                       

                    tblHtml += "<tr id='PurchaseOrderItemRow_" + i + "' class='item-data-row'>";

                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textArticle_No_" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Article_No + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Article_No + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Article_No' id='hdnArticle_No_" + i + "' />";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Item_Ids + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Item_Ids' id='hdnItem_Ids_" + i + "' />";

                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Branch_Ids + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Branch_Ids' id='hdnBranch_Ids_" + i + "' />";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Request_Ids + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Request_Ids' id='hdnRequest_Ids_" + i + "' />";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Request_Dates + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Request_Dates' id='hdnRequest_Dates_" + i + "' />";

                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<input type='text' class='form-control' value='" + obj.PurchaseOrder.PurchaseOrders[i].Colour_Name + "'/>";
                    tblHtml += "<input type='hidden' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Colour_Id' value='" + obj.PurchaseOrder.PurchaseOrders[i].Colour_Id + "' id='textColour_Id_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textBrand_Name_" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Brand_Name + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Brand_Id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Brand_Id' id='hdnBrand_Id_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textCategory_Name_" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Category_Name + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Category_Id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Category_Id' id='hdnCategory_Id_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textSub_Category_Name_" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Sub_Category_Name + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sub_Category_Id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Sub_Category_Id' id='hdnSub_Category_Id_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;'  id='textSize_Group_Name" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Size_Group_Name + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Size_Group_Id + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Size_Group_Id' id='hdnSize_Group_Id_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Start_Size' value='" + obj.PurchaseOrder.PurchaseOrders[i].Start_Size + "' id='textStart_Size_" + i + "'  onchange='Enable_Size_Quantity(" + i + ")' readonly />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].End_Size' value='" + obj.PurchaseOrder.PurchaseOrders[i].End_Size + "' id='textEnd_Size_" + i + "'  onchange='Enable_Size_Quantity(" + i + ")' readonly />";
                    tblHtml += "</td>";


                    ////***************************************************************************////                                       
                   
                    debugger;

                    for (var j = 0; j < 15; j++) {

                        if (j < obj.PurchaseOrder.PurchaseOrders[i].Sizes.length) {

                            if ((j + 1) == 1 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id1 != 0)
                            {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity1 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id1 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount1 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 2 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id2 != 0)
                            {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity2 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id2 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount2 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 3 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id3 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity3 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id3 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount3 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 4 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id4 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity4 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id4 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount4 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 5 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id5 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity5 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "''  onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id5 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount5 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 6 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id6 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity6 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id6 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount6 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 7 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id7 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity7 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id7 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount7 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 8 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id8 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity8 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id8 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount8 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 9 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id9 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity9 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id9 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount9 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 10 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id10 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity10 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id10 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount10 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 11 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id11 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity11 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id11 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount11 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 12 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id12 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity12 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id12 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount12 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 13 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id13 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity13 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id13 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount13 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 14 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id14 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity14 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id14 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount14 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else if ((j + 1) == 15 && obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id15 != 0) {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity15 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id15 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount15 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }
                            else
                            {
                                tblHtml += "<td>";
                                tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='0' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' readonly />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                                tblHtml += "</td>";
                            }


                            //tblHtml += "<td>";
                            //tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Quantity1 + "' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' />";
                            //tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Size_Id1 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                            //tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Sizes[j].Amount1 + "' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                            //tblHtml += "</td>";
                        }

                        else
                        {
                            tblHtml += "<td>";
                            tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.Sizes[" + i + "].Quantity" + (j + 1) + "' value='0' id='textSize_Quantity_" + (j + 1) + "-" + i + "'' readonly />";
                            tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize_Id_" + (j + 1) + "-" + i + "' />";
                            tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount" + (j + 1) + "' id='hdnAmount_" + (j + 1) + "-" + i + "' />";
                            tblHtml += "</td>";
                        }

                    }
                    ////***************************************************************************////

                   
                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textTotal_Quantity_" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Item_Quantity + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Item_Quantity + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Item_Quantity' id='hdnTotal_Quantity_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textCenter_Size_" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Center_Size + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Center_Size + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Center_Size' id='hdnCenter_Size_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textPurchase_Price_" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Purchase_Price + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Purchase_Price + "'  name='PurchaseOrder.PurchaseOrders[" + i + "].Purchase_Price' id='hdnPurchase_Price_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textSize_Difference_" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Size_Difference + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Size_Difference + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Size_Difference' id='hdnSize_Difference_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textTotal_Amount_" + i + "'>" + obj.PurchaseOrder.PurchaseOrders[i].Total_Amount + "</span>";
                    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.PurchaseOrders[i].Total_Amount + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Total_Amount' id='hdnTotal_Amount_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Comment' value='" + obj.PurchaseOrder.PurchaseOrders[i].Comment + "' id='textComment_" + i + "' />";
                    tblHtml += "</td>";

                    tblHtml += "<td>";
                    tblHtml += "<div class='btn-group'>";
                    tblHtml += "<button type='button' id='continue-order-details" + i + "' disabled class='btn btn-success active' onclick='ContinuePurchaseOrderDetailsData(" + i + ")'>Continue</button>";
                    tblHtml += "<button type='button' id='delete-order-details' class='btn btn-danger active' onclick='DeletePurchaseOrderDetailsData(" + i + ")'>Delete</button>";
                    tblHtml += "</div>";
                    tblHtml += "</td>";

                    tblHtml += "</tr>";

                    var newRow = $(tblHtml);

                    myTable.append(newRow);
                    

                    qty = parseInt(qty) + parseInt(obj.PurchaseOrder.PurchaseOrders[i].Item_Quantity);

                    amt = parseInt(amt) + parseInt(obj.PurchaseOrder.PurchaseOrders[i].Total_Amount);


                   


                    $("#tblPurchaseOrderCalculation").find('[id="hdnTotalQuantity"]').val(qty);

                    $("#tblPurchaseOrderCalculation").find('[id="hdnNetAmount"]').val(amt);


                    document.getElementById('tdTotalQuantity').innerText = qty;

                    document.getElementById('tdNetAmount').innerText = amt;

                    
                }

               
            }


        }
    });

}

function Get_Sizes()
{
    Delete_Size_Row();

    var Size_Group_Id = $("#drpSize_Group").val();

    $.ajax({

        url: "/PurchaseOrder/Get_Sizes",

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


            if (obj.PurchaseOrder.SizeGroups.length > 0) {

                //$("#drpCenter_Size").html("");

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

                for (var j = 0; j < 15; j++) {

                    if (j < obj.PurchaseOrder.SizeGroups.length)
                    {
                        tblHtml += "<td>";
                        tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'>" + obj.PurchaseOrder.SizeGroups[j].Size_Name + "</span>";
                        tblHtml += "<input type='hidden' class='form-control input-sm' value='" + obj.PurchaseOrder.SizeGroups[j].Size_Id + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + (j + 1) + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
                        tblHtml += "</td>";

                        debugger;

                        var K = j + 1;

                        $("#drpCenter_Size").append("<option value='" + obj.PurchaseOrder.SizeGroups[j].Size_Id + "'>" + obj.PurchaseOrder.SizeGroups[j].Size_Name + "</option>");

                        $("#drpCenter_Size").parents('.form-group').find('ul').append("<li rel='" + K + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrder.SizeGroups[j].Size_Name + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");
                        

                        //*************//

                        $("#drpTemp_Center_Size").append("<option value='" + obj.PurchaseOrder.SizeGroups[j].Size_Name + "'>" + obj.PurchaseOrder.SizeGroups[j].Size_Name + "</option>");

                        $("#drpTemp_Center_Size").parents('.form-group').find('ul').append("<li rel='" + K + "' class=''><a style='' class='' tabindex='0'><span class='text'>" + obj.PurchaseOrder.SizeGroups[j].Size_Name + "</span><i class='glyphicon glyphicon-ok icon-ok check-mark'></i></a></li>");


                        //************//
                    }
                    else
                    {
                        tblHtml += "<td>";
                        tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='Size" + (j + 1) + "-" + i + "'></span>";
                        tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Size_Id" + i + "' id='hdnSize" + (j + 1) + "-" + i + "' />";
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

function AddPurchaseOrderDetails() {


  
    var tdSizeCount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderSizeRow_"]').size();

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

    var myTable = $("#tblPurchaseOrderItems");

    var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderItemRow_"]').size();

    i = temptablecount;

    tblHtml += "<tr id='PurchaseOrderItemRow_" + i + "' class='item-data-row'>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Article_No' value='' id='textArticle_No_" + i + "' />";
    //tblHtml += "</td>";.

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textArticle_No_" + i + "'>" + artical_no + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + artical_no + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Article_No' id='hdnArticle_No_" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Item_Ids' id='hdnItem_Ids_" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Branch_Ids' id='hdnBranch_Ids_" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Request_Ids' id='hdnRequest_Ids_" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Request_Dates' id='hdnRequest_Dates_" + i + "' />";


    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Colour_Id' value='' id='textColour_Id_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textColour_Id_" + i + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Colour_Id'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
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

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Start_Size' value='' id='textStart_Size_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textStart_Size_" + i + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Start_Size' onchange='Enable_Size_Quantity(" + i + ")'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textEnd_Size_" + i + "' name='PurchaseOrder.PurchaseOrders[" + i + "].End_Size' onchange='Enable_Size_Quantity(" + i + ")'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].End_Size' value='' id='textEnd_Size_" + i + "' />";
    //tblHtml += "</td>";

    debugger;

   
    var size1 = $("#hdnSize1-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity1' value='0' id='textSize_Quantity_1-" + i + "'  onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size1 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id1' id='hdnSize_Id_1-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount1' id='hdnAmount_1-" + i + "' />";
    tblHtml += "</td>";
   
    var size2 = $("#hdnSize2-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity2' value='0' id='textSize_Quantity_2-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size2 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id2' id='hdnSize_Id_2-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount2' id='hdnAmount_2-" + i + "' />";
    tblHtml += "</td>";
 
    var size3 = $("#hdnSize3-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity3' value='0' id='textSize_Quantity_3-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size3 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id3' id='hdnSize_Id_3-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount3' id='hdnAmount_3-" + i + "' />";
    tblHtml += "</td>";
   
    var size4 = $("#hdnSize4-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity4' value='0' id='textSize_Quantity_4-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size4 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id4' id='hdnSize_Id_4-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount4' id='hdnAmount_4-" + i + "' />";
    tblHtml += "</td>";
    
    var size5 = $("#hdnSize5-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity5' value='0' id='textSize_Quantity_5-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size5 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id5' id='hdnSize_Id_5-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount5' id='hdnAmount_5-" + i + "' />";
    tblHtml += "</td>";
   
    var size6 = $("#hdnSize6-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity6' value='0' id='textSize_Quantity_6-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size6 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id6' id='hdnSize_Id_6-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount6' id='hdnAmount_6-" + i + "' />";
    tblHtml += "</td>";
 
    var size7 = $("#hdnSize7-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity7' value='0' id='textSize_Quantity_7-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size7 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id7' id='hdnSize_Id_7-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount7' id='hdnAmount_7-" + i + "' />";
    tblHtml += "</td>";
   
    var size8 = $("#hdnSize8-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity8' value='0' id='textSize_Quantity_8-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size8 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id8' id='hdnSize_Id_8-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount8' id='hdnAmount_8-" + i + "' />";
    tblHtml += "</td>";
  
    var size9 = $("#hdnSize9-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity9' value='0' id='textSize_Quantity_9-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size9 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id9' id='hdnSize_Id_9-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount9' id='hdnAmount_9-" + i + "' />";
    tblHtml += "</td>";
    
    var size10 = $("#hdnSize10-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity10' value='0' id='textSize_Quantity_10-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size10 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id10' id='hdnSize_Id_10-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount10' id='hdnAmount_10-" + i + "' />";
    tblHtml += "</td>";
  
    var size11 = $("#hdnSize11-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity11' value='0' id='textSize_Quantity_11-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size11 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id11' id='hdnSize_Id_11-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount11' id='hdnAmount_11-" + i + "' />";
    tblHtml += "</td>";
    
    var size12 = $("#hdnSize12-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity12' value='0' id='textSize_Quantity_12-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size12 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id12' id='hdnSize_Id_12-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount12' id='hdnAmount_12-" + i + "' />";
    tblHtml += "</td>";
    
    var size13 = $("#hdnSize13-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity13' value='0' id='textSize_Quantity_13-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size13 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id13' id='hdnSize_Id_13-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount13' id='hdnAmount_13-" + i + "' />";
    tblHtml += "</td>";
    
    var size14 = $("#hdnSize14-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity14' value='0' id='textSize_Quantity_14-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size14 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id14' id='hdnSize_Id_14-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount14' id='hdnAmount_14-" + i + "' />";
    tblHtml += "</td>";
    
    var size15 = $("#hdnSize15-" + x).val();
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity15' value='0' id='textSize_Quantity_15-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size15 + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id15' id='hdnSize_Id_15-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount15' id='hdnAmount_15-" + i + "' />";
    tblHtml += "</td>";
  

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textTotal_Quantity_" + i + "'>0</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Item_Quantity' id='hdnTotal_Quantity_" + i + "' />";
    tblHtml += "</td>";
    
    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textCenter_Size_" + i + "'>" + center_size + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + center_size + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Center_Size' id='hdnCenter_Size_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textPurchase_Price_" + i + "'>" + purchase_price + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + purchase_price + "'  name='PurchaseOrder.PurchaseOrders[" + i + "].Purchase_Price' id='hdnPurchase_Price_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textSize_Difference_" + i + "'>" + size_difference + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size_difference + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Size_Difference' id='hdnSize_Difference_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textTotal_Amount_" + i + "'>0</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Total_Amount' id='hdnTotal_Amount_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Comment' value='' id='textComment_" + i + "' />";
    tblHtml += "</td>";
     
    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='continue-order-details" + i + "' class='btn btn-success active' onclick='ContinuePurchaseOrderDetailsData(" + i + ")' disabled>Continue</button>";
    tblHtml += "<button type='button' id='delete-order-details' class='btn btn-danger active' onclick='DeletePurchaseOrderDetailsData(" + i + ")'>Delete</button>";
    tblHtml += "</div>";
    tblHtml += "</td>";


    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);

    $("#PurchaseOrderItemRow_" + i).addClass("POI_Row_" + x);
    
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

function ContinuePurchaseOrderDetailsData(j) {
    
    debugger;

    var tdSizeCount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderSizeRow_"]').size();

    var x = tdSizeCount;

    if (x != 0) {
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

    var myTable = $("#tblPurchaseOrderItems");

    var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderItemRow_"]').size();

    var i = temptablecount;

    if (i > 0) {
        document.getElementById("continue-order-details" + (i - 1)).disabled = true;
    }    

    tblHtml += "<tr id='PurchaseOrderItemRow_" + i + "' class='item-data-row'>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Article_No' value='' id='textArticle_No_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textArticle_No_" + i + "'>" + artical_no + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + artical_no + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Article_No' id='hdnArticle_No_" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Item_Ids' id='hdnItem_Ids_" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Branch_Ids' id='hdnBranch_Ids_" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Request_Ids' id='hdnRequest_Ids_" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Request_Dates' id='hdnRequest_Dates_" + i + "' />";

    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Colour_Id' value='' id='textColour_Id_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textColour_Id_" + i + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Colour_Id'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
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

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Start_Size' value='' id='textStart_Size_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textStart_Size_" + i + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Start_Size' onchange='Enable_Size_Quantity(" + i + ")'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='form-group'>";
    tblHtml += "<select class='form-control select' id='textEnd_Size_" + i + "' name='PurchaseOrder.PurchaseOrders[" + i + "].End_Size' onchange='Enable_Size_Quantity(" + i + ")'>";
    tblHtml += " </select>";
    tblHtml += " </div>";
    tblHtml += "</td>";

    //tblHtml += "<td>";
    //tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].End_Size' value='' id='textEnd_Size_" + i + "' />";
    //tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity1' value='0' id='textSize_Quantity_1-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_1-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id1' id='hdnSize_Id_1-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount1' id='hdnAmount_1-" + i + "' />";
    tblHtml += "</td>";
  
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity2' value='0' id='textSize_Quantity_2-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_2-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id2' id='hdnSize_Id_2-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount2' id='hdnAmount_2-" + i + "' />";
    tblHtml += "</td>";
  

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity3' value='0' id='textSize_Quantity_3-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_3-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id3' id='hdnSize_Id_3-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount3' id='hdnAmount_3-" + i + "' />";
    tblHtml += "</td>";
    

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity4' value='0' id='textSize_Quantity_4-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_4-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id4' id='hdnSize_Id_4-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount4' id='hdnAmount_4-" + i + "' />";
    tblHtml += "</td>";
  
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity5' value='0' id='textSize_Quantity_5-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_5-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id5' id='hdnSize_Id_5-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount5' id='hdnAmount_5-" + i + "' />";
    tblHtml += "</td>";
    
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity6' value='0' id='textSize_Quantity_6-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_6-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id6' id='hdnSize_Id_6-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount6' id='hdnAmount_6-" + i + "' />";
    tblHtml += "</td>";
 
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity7' value='0' id='textSize_Quantity_7-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_7-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id7' id='hdnSize_Id_7-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount7' id='hdnAmount_7-" + i + "' />";
    tblHtml += "</td>";
   
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity8' value='0' id='textSize_Quantity_8-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_8-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id8' id='hdnSize_Id_8-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount8' id='hdnAmount_8-" + i + "' />";
    tblHtml += "</td>";
   
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity9' value='0' id='textSize_Quantity_9-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_9-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id9' id='hdnSize_Id_9-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount9' id='hdnAmount_9-" + i + "' />";
    tblHtml += "</td>";
  
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity10' value='0' id='textSize_Quantity_10-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_10-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id10' id='hdnSize_Id_10-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount10' id='hdnAmount_10-" + i + "' />";
    tblHtml += "</td>";
    

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity11' value='0' id='textSize_Quantity_11-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_11-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id11' id='hdnSize_Id_11-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount11' id='hdnAmount_11-" + i + "' />";
    tblHtml += "</td>";
   
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity12' value='0' id='textSize_Quantity_12-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_12-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id12' id='hdnSize_Id_12-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount12' id='hdnAmount_12-" + i + "' />";
    tblHtml += "</td>";
    
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity13' value='0' id='textSize_Quantity_13-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_13-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id13' id='hdnSize_Id_13-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount13' id='hdnAmount_13-" + i + "' />";
    tblHtml += "</td>";
    
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity14' value='0' id='textSize_Quantity_14-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_14-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id14' id='hdnSize_Id_14-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount14' id='hdnAmount_14-" + i + "' />";
    tblHtml += "</td>";
  
    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control read-only' name='PurchaseOrder.Sizes[" + i + "].Quantity15' value='0' id='textSize_Quantity_15-" + i + "' onfocusout='CalculateRowQuantity(" + i + ")' readonly />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + $("#hdnSize_Id_15-" + (i - 1)).val() + "' name='PurchaseOrder.Sizes[" + i + "].Size_Id15' id='hdnSize_Id_15-" + i + "' />";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='0' name='PurchaseOrder.Sizes[" + i + "].Amount15' id='hdnAmount_15-" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textTotal_Quantity_" + i + "'>0</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Item_Quantity' id='hdnTotal_Quantity_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textCenter_Size_" + i + "'>" + center_size + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + center_size + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Center_Size' id='hdnCenter_Size_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textPurchase_Price_" + i + "'>" + purchase_price + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + purchase_price + "'  name='PurchaseOrder.PurchaseOrders[" + i + "].Purchase_Price' id='hdnPurchase_Price_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textSize_Difference_" + i + "'>" + size_difference + "</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='" + size_difference + "' name='PurchaseOrder.PurchaseOrders[" + i + "].Size_Difference' id='hdnSize_Difference_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<span class='label label-primary label-form' style='margin-bottom: 1px;' id='textTotal_Amount_" + i + "'>0</span>";
    tblHtml += "<input type='hidden' class='form-control input-sm' value='' name='PurchaseOrder.PurchaseOrders[" + i + "].Total_Amount' id='hdnTotal_Amount_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<input type='text' class='form-control' name='PurchaseOrder.PurchaseOrders[" + i + "].Comment' value='' id='textComment_" + i + "' />";
    tblHtml += "</td>";

    tblHtml += "<td>";
    tblHtml += "<div class='btn-group'>";
    tblHtml += "<button type='button' id='continue-order-details" + i + "' disabled class='btn btn-success active' onclick='ContinuePurchaseOrderDetailsData(" + i + ")'>Continue</button>";
    tblHtml += "<button type='button' id='delete-order-details' class='btn btn-danger active' onclick='DeletePurchaseOrderDetailsData(" + i + ")'>Delete</button>";
    tblHtml += "</div>";
    tblHtml += "</td>";


    tblHtml += "</tr>";

    var newRow = $(tblHtml);

    myTable.append(newRow);

    $("#PurchaseOrderItemRow_" + i).addClass("POI_Row_" + x);

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

    index = index + 1;

    //var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderSizeRow_"]').size();

    var x = parseInt(i);

    var size_id = $("#drpCenter_Size").val();

    var center_size = $("#textCenter_Size_" + x).text();

    var purchase_price = $("#textPurchase_Price_" + x).text();

    var size_difference = $("#textSize_Difference_" + x).text();

    //if(parseInt()

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

    for (var j = index + 1; j <= count; j++) {

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
        if (j < 15) {

            var Qty = parseFloat($("#tblPurchaseOrderItems").find('[id="textSize_Quantity_' + (j + 1) + '-' + i + '"]').val());

            var WSR = parseFloat($("#tblPurchaseOrderItems").find('[id="hdnAmount_' + (j + 1) + '-' + i + '"]').val());

            var Amount = parseFloat(WSR * Qty);

            $("#tblPurchaseOrderItems").find('[id="textAmount_' + i + '"]').val(Amount);

            sum_row_quantity = sum_row_quantity + Qty;

            sum_row_amount = sum_row_amount + Amount;

            document.getElementById('textTotal_Quantity_' + i).innerText = sum_row_quantity;

            document.getElementById('textTotal_Amount_' + i).innerText = sum_row_amount;

            $("#tblPurchaseOrderItems").find('[id="hdnTotal_Quantity_' + i + '"]').val(sum_row_quantity);

            $("#tblPurchaseOrderItems").find('[id="hdnTotal_Amount_' + i + '"]').val(sum_row_amount);
        }

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

    $("#tblPurchaseOrderCalculation").find('[id="hdnTotalQuantity"]').val(sumQuantity);

    $("#tblPurchaseOrderCalculation").find('[id="hdnNetAmount"]').val(sumWSRAmount);
       
    //Added by aditya [10102016] Start
    if ($("#hdnTotalQuantity").val() != 0) {
        document.getElementById("continue-order-details" + i).disabled = false;
    }
    //Added by aditya [10102016] Start
       
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

            $("#textSize_Quantity_" + j + "-" + i).rules("add", { required: true, digits: true, messages: { required: "Quantity is required.", digits: "Enter only digits.", } });
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

        document.getElementById("btnAddSizesPurchaseOrder").disabled = false;
    }
    else {
        document.getElementById("btnAddSizesPurchaseOrder").disabled = true;
    }
}

function Reset_Details() {

    debugger;

    $("#textPurchase_Price").val(0);

    $("#textSize_Difference").val(0);
    //document.getElementById("drpCenter_Size").selectedIndex = 0;
}

function Disable_AddDetalis_Button() {

    var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderItemRow_"]').size();

    j = temptablecount;
    
    for (var i = 0; i < j; i++) {

       // $("#continue-order-details" + i).parents('tr').find(".POI_Row_" + k).attr("disabled", true);

        document.getElementById("continue-order-details" + i).disabled = true;
    }  
   
}

function Delete_Size_Row() {

    var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderSizeRow_"]').size();

    k = temptablecount;

    if (k != 0) {
        k = k - 1;
    }

    var count = $("#tblPurchaseOrderItems").find(".POI_Row_" + k).size();

    if (count == 0) {
        $("#tblPurchaseOrderItems").find("[id='PurchaseOrderSizeRow_" + k + "']").remove();
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

        $("#tblPurchaseOrderCalculation").find('[id="hdnTotalQuantity"]').val(total_qty);

        $("#tblPurchaseOrderCalculation").find('[id="hdnNetAmount"]').val(total_amt);
    }

    if (j == 0) {

        document.getElementById('tdTotalQuantity').innerText = 0;

        document.getElementById('tdNetAmount').innerText = 0;

        $("#tblPurchaseOrderCalculation").find('[id="hdnTotalQuantity"]').val(0);

        $("#tblPurchaseOrderCalculation").find('[id="hdnNetAmount"]').val(0);
    }
}

function DeletePurchaseOrderDetailsData(i) {

    debugger;

    //*************//

    var id = $("#hdnItem_Ids_" + i).val();

    if (id != 0 || id != '')
    {
        $("#tblPurchaseOrderItems").find("[id='PurchaseOrderSizeRow_" + i + "']").remove();
    }

    $("#tblPurchaseOrderItems").find("[id='PurchaseOrderItemRow_" + i + "']").remove();


    //*************//

           
    ReArrangePurchaseOrderSizeData();

    ReArrangePurchaseOrderDetailsData();


    //*************//


    //var temptablecount = $("#tblPurchaseOrderItems").find('[id^="PurchaseOrderSizeRow_"]').size();

    //k = temptablecount;

    //for (var x = 0; x < k; x++) {

    //    var count = $("#PurchaseOrderItemRow_" + i).find(".POI_Row_" + x).size();

    //    if (count == 0) {
    //        $("#tblPurchaseOrderItems").find("[id='PurchaseOrderSizeRow_" + x + "']").remove();
    //    }
    //}

    //*************//
    
    Reset_Detalis_After_Delete();

   
    
}

function ReArrangePurchaseOrderDetailsData() {

    debugger;

    $("#tblPurchaseOrderItems").find("[id^='PurchaseOrderItemRow_']").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'PurchaseOrderItemRow_' + i

            var newTR = "#" + $(row)[0].id + " td";
               
            if ($(newTR).find("[id^='textArticle_No_']").length > 0) {
                $(newTR).find("[id^='textArticle_No_']")[0].id = "textArticle_No_" + i;
                $(newTR).find("[id^='hdnArticle_No_']")[0].id = "hdnArticle_No_" + i;
                $(newTR).find("[id^='hdnArticle_No_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Article_No");
                $(newTR).find("[id^='hdnItem_Ids_']")[0].id = "hdnItem_Ids_" + i;
                $(newTR).find("[id^='hdnItem_Ids_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Item_Ids");

                $(newTR).find("[id^='hdnBranch_Ids_']")[0].id = "hdnBranch_Ids_" + i;
                $(newTR).find("[id^='hdnBranch_Ids_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Branch_Ids");
                $(newTR).find("[id^='hdnRequest_Ids_']")[0].id = "hdnRequest_Ids_" + i;
                $(newTR).find("[id^='hdnRequest_Ids_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Request_Ids");
                $(newTR).find("[id^='hdnRequest_Dates_']")[0].id = "hdnRequest_Dates_" + i;
                $(newTR).find("[id^='hdnRequest_Dates_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Request_Dates");
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
                $(newTR).find("[id^='textStart_Size_']").attr("onchange", "Enable_Size_Quantity(" + i + ")");
            }

            if ($(newTR).find("[id^='textEnd_Size_']").length > 0) {
                $(newTR).find("[id^='textEnd_Size_']")[0].id = "textEnd_Size_" + i;
                $(newTR).find("[id^='textEnd_Size_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].End_Size");
                $(newTR).find("[id^='textEnd_Size_']").attr("onchange", "Enable_Size_Quantity(" + i + ")");
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            debugger;

            if ($(newTR).find("[id^='textSize_Quantity_1-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_1-']")[0].id = "textSize_Quantity_1-" +  i ;
                $(newTR).find("[id^='textSize_Quantity_1-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity1");
                $(newTR).find("[id^='textSize_Quantity_1-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_1-']")[0].id = "hdnSize_Id_1-" + i;
                $(newTR).find("[id^='hdnSize_Id_1-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id1");
                $(newTR).find("[id^='hdnSize_Id_1-']").attr("value", $("#hdnSize_Id_1-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_1-']")[0].id = "hdnAmount_1-" + i;
                $(newTR).find("[id^='hdnAmount_1-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount1");

            }

            if ($(newTR).find("[id^='textSize_Quantity_2-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_2-']")[0].id = "textSize_Quantity_2-" + i;
                $(newTR).find("[id^='textSize_Quantity_2-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity2");
                $(newTR).find("[id^='textSize_Quantity_2-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_2-']")[0].id = "hdnSize_Id_2-" + i;
                $(newTR).find("[id^='hdnSize_Id_2-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id2");
                $(newTR).find("[id^='hdnSize_Id_2-']").attr("value", $("#hdnSize_Id_2-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_2-']")[0].id = "hdnAmount_2-" + i;
                $(newTR).find("[id^='hdnAmount_2-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount2");
            }

            if ($(newTR).find("[id^='textSize_Quantity_3-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_3-']")[0].id = "textSize_Quantity_3-" + i;
                $(newTR).find("[id^='textSize_Quantity_3-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity3");
                $(newTR).find("[id^='textSize_Quantity_3-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_3-']")[0].id = "hdnSize_Id_3-" + i;
                $(newTR).find("[id^='hdnSize_Id_3-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id3");
                $(newTR).find("[id^='hdnSize_Id_3-']").attr("value", $("#hdnSize_Id_3-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_3-']")[0].id = "hdnAmount_3-" + i;
                $(newTR).find("[id^='hdnAmount_3-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount3");
            }

            if ($(newTR).find("[id^='textSize_Quantity_4-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_4-']")[0].id = "textSize_Quantity_4-" + i;
                $(newTR).find("[id^='textSize_Quantity_4-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity4");
                $(newTR).find("[id^='textSize_Quantity_4-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_4-']")[0].id = "hdnSize_Id_4-" + i;
                $(newTR).find("[id^='hdnSize_Id_4-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id4");
                $(newTR).find("[id^='hdnSize_Id_4-']").attr("value", $("#hdnSize_Id_4-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_4-']")[0].id = "hdnAmount_4-" + i;
                $(newTR).find("[id^='hdnAmount_4-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount4");
            }

            if ($(newTR).find("[id^='textSize_Quantity_5-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_5-']")[0].id = "textSize_Quantity_5-" + i;
                $(newTR).find("[id^='textSize_Quantity_5-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity5");
                $(newTR).find("[id^='textSize_Quantity_5-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_5-']")[0].id = "hdnSize_Id_5-" + i;
                $(newTR).find("[id^='hdnSize_Id_5-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id5");
                $(newTR).find("[id^='hdnSize_Id_5-']").attr("value", $("#hdnSize_Id_5-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_5-']")[0].id = "hdnAmount_5-" + i;
                $(newTR).find("[id^='hdnAmount_5-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount5");
            }

            if ($(newTR).find("[id^='textSize_Quantity_6']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_6-']")[0].id = "textSize_Quantity_6-" + i;
                $(newTR).find("[id^='textSize_Quantity_6-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity6");
                $(newTR).find("[id^='textSize_Quantity_6-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_6-']")[0].id = "hdnSize_Id_6-" + i;
                $(newTR).find("[id^='hdnSize_Id_6-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id6");
                $(newTR).find("[id^='hdnSize_Id_6-']").attr("value", $("#hdnSize_Id_6-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_6-']")[0].id = "hdnAmount_6-" + i;
                $(newTR).find("[id^='hdnAmount_6-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount6");
            }

            if ($(newTR).find("[id^='textSize_Quantity_7-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_7-']")[0].id = "textSize_Quantity_7-" + i;
                $(newTR).find("[id^='textSize_Quantity_7-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity7");
                $(newTR).find("[id^='textSize_Quantity_7-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_7-']")[0].id = "hdnSize_Id_7-" + i;
                $(newTR).find("[id^='hdnSize_Id_7-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id7");
                $(newTR).find("[id^='hdnSize_Id_7-']").attr("value", $("#hdnSize_Id_7-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_7-']")[0].id = "hdnAmount_7-" + i;
                $(newTR).find("[id^='hdnAmount_7-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount7");
            }

            if ($(newTR).find("[id^='textSize_Quantity_8-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_8-']")[0].id = "textSize_Quantity_8-" + i;
                $(newTR).find("[id^='textSize_Quantity_8-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity8");
                $(newTR).find("[id^='textSize_Quantity_8-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_8-']")[0].id = "hdnSize_Id_8-" + i;
                $(newTR).find("[id^='hdnSize_Id_8-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id8");
                $(newTR).find("[id^='hdnSize_Id_8-']").attr("value", $("#hdnSize_Id_8-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_8-']")[0].id = "hdnAmount_8-" + i;
                $(newTR).find("[id^='hdnAmount_8-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount8");
            }

            if ($(newTR).find("[id^='textSize_Quantity_9-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_9-']")[0].id = "textSize_Quantity_9-" + i;
                $(newTR).find("[id^='textSize_Quantity_9-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity9");
                $(newTR).find("[id^='textSize_Quantity_9-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_9-']")[0].id = "hdnSize_Id_9-" + i;
                $(newTR).find("[id^='hdnSize_Id_9-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id9");
                $(newTR).find("[id^='hdnSize_Id_9-']").attr("value", $("#hdnSize_Id_9-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_9-']")[0].id = "hdnAmount_9-" + i;
                $(newTR).find("[id^='hdnAmount_9-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount9");
            }

            if ($(newTR).find("[id^='textSize_Quantity_10-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_10-']")[0].id = "textSize_Quantity_10-" + i;
                $(newTR).find("[id^='textSize_Quantity_10-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity10");
                $(newTR).find("[id^='textSize_Quantity_10-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_10-']")[0].id = "hdnSize_Id_10-" + i;
                $(newTR).find("[id^='hdnSize_Id_10-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id10");
                $(newTR).find("[id^='hdnSize_Id_10-']").attr("value", $("#hdnSize_Id_10-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_10-']")[0].id = "hdnAmount_10-" + i;
                $(newTR).find("[id^='hdnAmount_10-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount10");
            }

            if ($(newTR).find("[id^='textSize_Quantity_11-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_11-']")[0].id = "textSize_Quantity_11-" + i;
                $(newTR).find("[id^='textSize_Quantity_11-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity11");
                $(newTR).find("[id^='textSize_Quantity_11-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_11-']")[0].id = "hdnSize_Id_11-" + i;
                $(newTR).find("[id^='hdnSize_Id_11-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id11");
                $(newTR).find("[id^='hdnSize_Id_11-']").attr("value", $("#hdnSize_Id_11-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_11-']")[0].id = "hdnAmount_11-" + i;
                $(newTR).find("[id^='hdnAmount_11-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount11");
            }

            if ($(newTR).find("[id^='textSize_Quantity_12-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_12-']")[0].id = "textSize_Quantity_12-" + i;
                $(newTR).find("[id^='textSize_Quantity_12-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity12");
                $(newTR).find("[id^='textSize_Quantity_12-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_12-']")[0].id = "hdnSize_Id_12-" + i;
                $(newTR).find("[id^='hdnSize_Id_12-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id12");
                $(newTR).find("[id^='hdnSize_Id_12-']").attr("value", $("#hdnSize_Id_12-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_12-']")[0].id = "hdnAmount_12-" + i;
                $(newTR).find("[id^='hdnAmount_12-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount12");
            }

            if ($(newTR).find("[id^='textSize_Quantity_13-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_13-']")[0].id = "textSize_Quantity_13-" + i;
                $(newTR).find("[id^='textSize_Quantity_13-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity13");
                $(newTR).find("[id^='textSize_Quantity_13-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_13-']")[0].id = "hdnSize_Id_13-" + i;
                $(newTR).find("[id^='hdnSize_Id_13-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id13");
                $(newTR).find("[id^='hdnSize_Id_13-']").attr("value", $("#hdnSize_Id_13-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_13-']")[0].id = "hdnAmount_13-" + i;
                $(newTR).find("[id^='hdnAmount_13-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount13");
            }

            if ($(newTR).find("[id^='textSize_Quantity_14-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_14-']")[0].id = "textSize_Quantity_14-" + i;
                $(newTR).find("[id^='textSize_Quantity_14-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity14");
                $(newTR).find("[id^='textSize_Quantity_14-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_14-']")[0].id = "hdnSize_Id_14-" + i;
                $(newTR).find("[id^='hdnSize_Id_14-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id14");
                $(newTR).find("[id^='hdnSize_Id_14-']").attr("value", $("#hdnSize_Id_14-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_14-']")[0].id = "hdnAmount_14-" + i;
                $(newTR).find("[id^='hdnAmount_14-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount14");
            }

            if ($(newTR).find("[id^='textSize_Quantity_15-']").length > 0) {
                $(newTR).find("[id^='textSize_Quantity_15-']")[0].id = "textSize_Quantity_15-" + i;
                $(newTR).find("[id^='textSize_Quantity_15-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Quantity15");
                $(newTR).find("[id^='textSize_Quantity_15-']").attr("onfocusout", "CalculateRowQuantity(" + i + ")");

                $(newTR).find("[id^='hdnSize_Id_15-']")[0].id = "hdnSize_Id_15-" + i;
                $(newTR).find("[id^='hdnSize_Id_15-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id15");
                $(newTR).find("[id^='hdnSize_Id_15-']").attr("value", $("#hdnSize_Id_15-" + (i - 1)).val());

                $(newTR).find("[id^='hdnAmount_15-']")[0].id = "hdnAmount_15-" + i;
                $(newTR).find("[id^='hdnAmount_15-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Amount15");
            }

            debugger;


            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            
            if ($(newTR).find("[id^='textTotal_Quantity_']").length > 0) {
                $(newTR).find("[id^='textTotal_Quantity_']")[0].id = "textTotal_Quantity_" + i;
                $(newTR).find("[id^='hdnTotal_Quantity_']")[0].id = "hdnTotal_Quantity_" + i;
                $(newTR).find("[id^='hdnTotal_Quantity_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Item_Quantity");
            }

            if ($(newTR).find("[id^='textCenter_Size_']").length > 0) {
                $(newTR).find("[id^='textCenter_Size_']")[0].id = "textCenter_Size_" + i;
                $(newTR).find("[id^='hdnCenter_Size_']")[0].id = "hdnCenter_Size_" + i;
                $(newTR).find("[id^='hdnCenter_Size_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Center_Size");
            }

            if ($(newTR).find("[id^='textPurchase_Price_']").length > 0) {
                $(newTR).find("[id^='textPurchase_Price_']")[0].id = "textPurchase_Price_" + i;
                $(newTR).find("[id^='hdnPurchase_Price_']")[0].id = "hdnPurchase_Price_" + i;
                $(newTR).find("[id^='hdnPurchase_Price_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Purchase_Price");
            }

            if ($(newTR).find("[id^='textSize_Difference_']").length > 0) {
                $(newTR).find("[id^='textSize_Difference_']")[0].id = "textSize_Difference_" + i;
                $(newTR).find("[id^='hdnSize_Difference_']")[0].id = "hdnSize_Difference_" + i;
                $(newTR).find("[id^='hdnSize_Difference_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Size_Difference");
            }

            if ($(newTR).find("[id^='textTotal_Amount_']").length > 0) {
                $(newTR).find("[id^='textTotal_Amount_']")[0].id = "textTotal_Amount_" + i;
                $(newTR).find("[id^='hdnTotal_Amount_']")[0].id = "hdnTotal_Amount_" + i;
                $(newTR).find("[id^='hdnTotal_Amount_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Total_Amount");
            }

            if ($(newTR).find("[id^='textComment_']").length > 0) {
                $(newTR).find("[id^='textComment_']")[0].id = "textComment_" + i;
                $(newTR).find("[id^='textComment_']").attr("name", "PurchaseOrder.PurchaseOrders[" + i + "].Comment");
            }

                      
            if ($(newTR).find("[id^='continue-order-details']").length > 0) {
                $(newTR).find("[id^='continue-order-details']").attr("onclick", "ContinuePurchaseOrderDetailsData(" + i + ")");
            }
           
            if ($(newTR).find("[id='delete-order-details']").length > 0) {
                $(newTR).find("[id='delete-order-details']").attr("onclick", "DeletePurchaseOrderDetailsData(" + i + ")");
            }
        }
    });

}

function ReArrangePurchaseOrderSizeData() {

    debugger;

    $("#tblPurchaseOrderItems").find("[id^='PurchaseOrderSizeRow_']").each(function (i, row) {
        if ($(row)[0].id != 'tblHeading') {

            $(row)[0].id = 'PurchaseOrderSizeRow_' + i

            var newTR = "#" + $(row)[0].id + " td";           

            if ($(newTR).find("[id^='hdnSize1-']").length > 0) {
                $(newTR).find("[id^='hdnSize1-']")[0].id = "hdnSize1-" + i;
                $(newTR).find("[id^='hdnSize1-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id1");
                $(newTR).find("[id^='Size1-']")[0].id = "Size1-" + i;   
            }

            if ($(newTR).find("[id^='hdnSize2-']").length > 0) {
                $(newTR).find("[id^='hdnSize2-']")[0].id = "hdnSize2-" + i;
                $(newTR).find("[id^='hdnSize2-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id2");
                $(newTR).find("[id^='Size2-']")[0].id = "Size2-" + i;
            }

            if ($(newTR).find("[id^='hdnSize3-']").length > 0) {
                $(newTR).find("[id^='hdnSize3-']")[0].id = "hdnSize3-" + i;
                $(newTR).find("[id^='hdnSize3-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id3");
                $(newTR).find("[id^='Size3-']")[0].id = "Size3-" + i;
            }

            if ($(newTR).find("[id^='hdnSize4-']").length > 0) {
                $(newTR).find("[id^='hdnSize4-']")[0].id = "hdnSize4-" + i;
                $(newTR).find("[id^='hdnSize4-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id4");
                $(newTR).find("[id^='Size4-']")[0].id = "Size4-" + i;
            }

            if ($(newTR).find("[id^='hdnSize5-']").length > 0) {
                $(newTR).find("[id^='hdnSize5-']")[0].id = "hdnSize5-" + i;
                $(newTR).find("[id^='hdnSize5-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id5");
                $(newTR).find("[id^='Size5-']")[0].id = "Size5-" + i;
            }

            if ($(newTR).find("[id^='hdnSize6-']").length > 0) {
                $(newTR).find("[id^='hdnSize6-']")[0].id = "hdnSize6 -" + i;
                $(newTR).find("[id^='hdnSize6-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id6");
                $(newTR).find("[id^='Size6-']")[0].id = "Size6-" + i;
            }

            if ($(newTR).find("[id^='hdnSize7-']").length > 0) {
                $(newTR).find("[id^='hdnSize7-']")[0].id = "hdnSize7-" + i;
                $(newTR).find("[id^='hdnSize7-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id7");
                $(newTR).find("[id^='Size7-']")[0].id = "Size7-" + i;
            }

            if ($(newTR).find("[id^='hdnSize8-']").length > 0) {
                $(newTR).find("[id^='hdnSize8-']")[0].id = "hdnSize8-" + i;
                $(newTR).find("[id^='hdnSize8-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id8");
                $(newTR).find("[id^='Size8-']")[0].id = "Size8-" + i;
            }

            if ($(newTR).find("[id^='hdnSize9-']").length > 0) {
                $(newTR).find("[id^='hdnSize9-']")[0].id = "hdnSize9-" + i;
                $(newTR).find("[id^='hdnSize9-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id9");
                $(newTR).find("[id^='Size9-']")[0].id = "Size9-" + i;
            }

            if ($(newTR).find("[id^='hdnSize10-']").length > 0) {
                $(newTR).find("[id^='hdnSize10-']")[0].id = "hdnSize10-" + i;
                $(newTR).find("[id^='hdnSize10-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id10");
                $(newTR).find("[id^='Size10-']")[0].id = "Size10-" + i;
            }

            if ($(newTR).find("[id^='hdnSize11-']").length > 0) {
                $(newTR).find("[id^='hdnSize11-']")[0].id = "hdnSize11-" + i;
                $(newTR).find("[id^='hdnSize11-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id11");
                $(newTR).find("[id^='Size11-']")[0].id = "Size11-" + i;
            }

            if ($(newTR).find("[id^='hdnSize12-']").length > 0) {
                $(newTR).find("[id^='hdnSize12-']")[0].id = "hdnSize12-" + i;
                $(newTR).find("[id^='hdnSize12-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id12");
                $(newTR).find("[id^='Size12-']")[0].id = "Size12-" + i;
            }

            if ($(newTR).find("[id^='hdnSize13-']").length > 0) {
                $(newTR).find("[id^='hdnSize13-']")[0].id = "hdnSize13-" + i;
                $(newTR).find("[id^='hdnSize13-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id13");
                $(newTR).find("[id^='Size13-']")[0].id = "Size13-" + i;
            }

            if ($(newTR).find("[id^='hdnSize14-']").length > 0) {
                $(newTR).find("[id^='hdnSize14-']")[0].id = "hdnSize14-" + i;
                $(newTR).find("[id^='hdnSize14-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id14");
                $(newTR).find("[id^='Size14-']")[0].id = "Size14-" + i;
            }

            if ($(newTR).find("[id^='hdnSize15-']").length > 0) {
                $(newTR).find("[id^='hdnSize15-']")[0].id = "hdnSize15-" + i;
                $(newTR).find("[id^='hdnSize15-']").attr("name", "PurchaseOrder.Sizes[" + i + "].Size_Id15");
                $(newTR).find("[id^='Size15-']")[0].id = "Size15-" + i;
            }
        }
    });

}

//added by vinod mane on 10/10/2016
function ClearAllDropdownlist()
{
    //$("#drpArticle_No").val('');
    //$("#drpBrand").val('');
    //$("#drpCategory").val('');
    //$("#drpSubCategory").val('');   
    //$("#drpCenter_Size").val('');

    $("#drpArticle_No").html("");
    $("#drpArticle_No").append("<option value=''>Select Article No.</option>");
    $("#drpArticle_No").parents('.form-group').find('ul').html("");

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

}

function Clear_Br_Cat_SubCat() {
   
    $("#drpBrand").val('');
    $("#drpCategory").val('');
    $("#drpSubCategory").val('');  

}
//End
