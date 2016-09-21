

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
        $("#btnCancel").attr('disabled', true);
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

    //$("#btnProductMRP").click(function () {

    //    var Product_Id = $("#hdn_ProductId").val();
    //    if(Product_Id != 0)
    //    saveProductMRP(Product_Id);
    //    //$("#frmProduct").attr("action", "/Product/serch-ProductPrizing/");

    //    //$("#frmProduct").attr("method", "post");

    //    //$("#frmProduct").submit();
    //});

    $("#btnUploadImage").click(function () {
        //if ($('#frmProduct').valid()) {
        UploadImage();
    });

    $('#productImage').change(function () {

        //if ($("#hdnFirst_Img").val() == "") {
        //    $("#hdnFirst_Img").val(this.files[0].name);
        //}
        //else if ($("#hdnSecond_Img").val() == "") {
        //    $("#hdnSecond_Img").val(this.files[0].name);

        //}
        //else if ($("#hdnThird_Img").val() == "") {
        //    $("#hdnThird_Img").val(this.files[0].name);

        //}
        //else if ($("#hdnFour_Img").val() == "") {
        //    $("#hdnFour_Img").val(this.files[0].name);

        //}


        //alert(this.files.length);
        //var reader = new FileReader();

        //var html_Text = "";

        //for (i = 0; i < this.files.length; i++) {

        //    var file = document.getElementById('productImage').files[i]; 

        //    html_Text += "<div id='DivImages' class='col-md-3' style='margin-top: 20px;'>";

        //    html_Text += "<div class='thumbnail panel'>";

        //    html_Text += "<input type='text' name='ProductImage.ProductName[" + i + "]' value=" + this.files[i].name + " >"; 

        //    html_Text += "<img style='width:150px; height: 125px;border: 1px solid;margin-left: auto;margin-right: auto;display: block;max-width: 100%;max-height: 100%;' src='" + reader.result + "'>";

        //    html_Text += "</div>";

        //    html_Text += "</div>";

        //    $('#ImgPreview').append(html_Text);

        //    if (file) {
        //        reader.readAsDataURL(file);
        //    }
        //}


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
        alert($(this).val());
    });

});