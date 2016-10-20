  
$(function () {
    if ($("#hdnVendorId").val() != 0) {
        $("#dvVendor").find(".autocomplete-text").trigger("focusout");
    }
    if ($("#hdnBrandId").val() != 0) {
        $("#dvBrand").find(".autocomplete-text").trigger("focusout");
    }
    if ($("#hdnCategoryId").val() != 0) {
        $("#dvCatergory").find(".autocomplete-text").trigger("focusout");
    }
    if ($("#hdnSubcategoryId").val() != 0) {
        $("#dvSubC").find(".autocomplete-text").trigger("focusout");
    }
    if ($("#hdnSizeGroupId").val() != 0) {
        $("#dvSizeG").find(".autocomplete-text").trigger("focusout");
    }
    if ($("#hdn_ProductId").val() != 0) {
        $("#txtArticle_No").attr('readonly', true);
        //$("#btnCancel").attr('disabled', true);
        $("#btnProductMRP").show(); 
    }

    $("#btnProductSave").click(function () {
        if ($("#frmProduct").valid()) {
            if ($("#hdn_ProductId").val() == 0) {
                $("#frmProduct").attr("action", "/Product/Insert_Product/");
            }
            else { 
                $("#frmProduct").attr("action", "/Product/Update_Product/");
            }
            $('#frmProduct').attr("method", "POST");
            $('#frmProduct').submit();
        }
    });

    $("#btnProductMRP").click(function () {
        //var Product_Id = $("#hdn_ProductId").val();
        //if(Product_Id != 0) 
        $("#frmProduct").attr("action", "/Product/serch-ProductPrizing/");

        $("#frmProduct").attr("method", "post");

        $("#frmProduct").submit();
    });

    $("#btnUploadImage").click(function () {
        //if ($('#frmProduct').valid()) {
        UploadImage();
    }); 


    $("input[type='radio']").on("ifChanged", function () {
        if ($(this).prop('checked')) {
            var tObj = document.getElementsByClassName('Is_Default');
            for (var i = 0; i < tObj.length; i++) {
                tObj[i].value = 'false';
            }
            $(this).closest(".image").find(".Is_Default").val('true');
        }
        else {
            $(this).val('false');
        }
        //alert($(this).val());
    });

    $('.remove-image-attachment').click(function (event) {

        var Product_Id = $('#hdn_ProductId').val();
        var Product_Image_Id = $(this).closest(".image").find('.prod_img_id').val();
        var Product_Image_Name = $(this).closest(".image").find('.prod_img_name').val();

        var param = { Product_Image_Id: Product_Image_Id, Product_Id: Product_Id, Product_Image_Name: Product_Image_Name }

        $.ajax({
            url: '/Product/Delete_Product_Image',
            type: "Post",
            datatype: 'json',
            contentType: 'application/json',
            data: JSON.stringify(param),
            success: function (response) {
                var data = $.parseJSON(response);
                for (var i = 0; i < data.Product.ProductImage.Product_Image.length; i++) {
                    if (data.Product.ProductImage.Product_Image[i] != null) {
                        $("#img_" + i).attr("src", "/UploadedFiles/" + data.Product.ProductImage.Product_Image[i]);
                        if (data.Product.ProductImage.Is_Default[i] == 'True') 
                            $('#rd_' + i).iCheck('check');
                        else
                            $('#rd_' + i).iCheck('uncheck');
                        $("#hdn_Img_" + i).attr("value", data.Product.ProductImage.Product_Image[i]);
                        $("#hdn_Img_Id_" + i).attr("value", data.Product.ProductImage.Product_Image_Id[i]); 
                    } else {
                        $("#img_" + i).attr("src", "/UploadedFiles/");
                        $('#rd_' + i).iCheck('uncheck');
                    } 
                } 
            }
        });
    });

    $('.remove-image-src').click(function (event) {
        $(this).closest(".image").find(".ImgSrc").attr("src", "/UploadFiles/");
        $(this).closest(".image").find(".prod_img_src").val('');
        $(this).closest(".image").find(".prod_img_name").val('');
        //$("#img_" + i).attr("src", "/UploadedFiles/");
    });

});