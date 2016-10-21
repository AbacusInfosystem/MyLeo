

$(function () {
    //alert();
    $(document).on('click', '#btnProductSave', function () {

        if ($('#Color_Grid').find("a").length > 0) {
            $("#lblColorError").hide();
            if ($('#common_Product_MRP').find(".Product").length > 0) {
                $("#lblColorPriceError").hide();
                if (CheckExist()) {
                    $("#lblAddPriceError").hide();

                    if ($("#frmProductMRP").valid()) { 
                        $("#frmProductMRP").attr("action", "/Product/Insert_ProductMRP/");
                        $('#frmProductMRP').attr("method", "POST");
                        $('#frmProductMRP').submit();

                    }
                }
                else {
                    $("#lblAddPriceError").show();
                }
            }
            else {
                $("#lblColorPriceError").show();
            }
        }
        else {
            $("#lblColorError").show();
        }

    });



    if ($("#hdnColorIds").val() != null && $("#hdnColors").val() != null && $("#hdn_ProductId").val() != 0 && $("#hdnVendorCodes").val() != null) {
        var ColorId = $("#hdnColorIds").val().split(",");
        var Color = $("#hdnColors").val().split(",");
        var ProductId = $("#hdn_ProductId").val();
        var Vendor_Code = $("#hdnVendorCodes").val().split(",");

        for (i = 0; i < ColorId.length; i++) {
            showMRPByProductColor_Exist(ColorId[i], Color[i], ProductId, i, Vendor_Code[i])
        }
    }


    $('#btnAddColour').click(function () {
        if ($("#frmProductColor").valid()) {

            var ColourId = $("#hdnColourId").val();
            var Colour_Name = $("#hdnColourName").val();
            var Vendor_Color_Code = $("#txtVendorColorCode").val();
            Bind_Colour_Grid(ColourId, Colour_Name, Vendor_Color_Code);
        }
    });


    $(document).on("click", "[name='Color_List']", function () {
        if ($("#common_Product_MRP").find(".Product:visible").length > 0) { 
                if (CheckExist()) {
                    var Product_Id = $("#hdn_ProductId").val();
                    if (Product_Id != 0) { 
                        showMRPByProductColor_New(Product_Id, this);
                        $("#lblAddPriceError").hide();
                    }
                } else {
                    $("#lblAddPriceError").show();
                } 
        } else {
            var Product_Id = $("#hdn_ProductId").val();
            if (Product_Id != 0)
                showMRPByProductColor_New(Product_Id, this);
        } 
    });

    function CheckExist() {

        var result = true;

        $(".Product:visible").find(".AllWSRPricesRequired").each(function () {  
            if (this.value == "")
                result = false; 
        });

        $(".Product:visible").find(".AllMRPPricesRequired").each(function () {
            if (this.value == "")
                result = false;
        });

        $(".Product:visible").find(".AllMRPSalePricesRequired").each(function () {
            if (this.value == "")
                result = false;
        });

        $(".Product:visible").find(".Description").each(function () {
            if (this.value == "")
                result = false;
        });

        return result;
    }

    $(document).on("click", "#btnSale", function () {
        var Product_Id = $("#hdn_ProductId").val();
        var arr = "", Color_Index = "", Color_Id = "", Color_Name = "", Vendor_Color_Code = "";

        $(".Product:visible").find(".ColorId").each(function () {
            Color_Id = this.id.split('_');
            //alert(Color_Id[1]);
        });
        $(".Product:visible").find(".ColorName").each(function () {
            Color_Name = this.id.split('_');
            //alert(Color_Name[1]);
        });
        $(".Product:visible").find(".VendorCode").each(function () {
            Vendor_Color_Code = this.id.split('_');
            //alert(Vendor_Color_Code[1]);
        });
        $(".Product:visible").find(".ColorIndex").each(function () {
            Color_Index = this.id.split('_');
            //alert(Color_Index[1]);
        });
        $(".Product:visible").find(".Description").each(function () {
            arr = this.id.split('_');
            //alert(arr[1]);
        });

        Bind_MRP_Sale_Grid(Color_Id[1], Color_Name[1], Vendor_Color_Code[1], Product_Id, Color_Index[1], arr[1]);

    });

    $(document).on('change', '[name="MRP_Status"]', function (event) {
        $("#frmProductMRP").find(".Product:visible").find("[id^='hdnMrpStatus']").val(false);
        if ($(this).prop('checked')) {
            $(this).val(true);
            var parentRow = $(this).closest('table');
            //alert($(parentRow).html());
            var hiddenField = $(parentRow).find("[id^='hdnMrpStatus']");
            $(hiddenField).val(this.value);
            //alert($(hiddenField).val(this.value));
        }
    });

    $(document).on("click", "#btnPrintAllBarCodes", function () {
        //if ($("#hdn_ProductId").val() != 0)
        //    PrintAllBarCodes($("#hdn_ProductId").val()); 
        if ($("#frmProductMRP").valid()) {
            if ($("#hdn_ProductId").val() != 0) {
                $("#frmProductMRP").attr("action", "/product/get-all-barcodes/");
                $('#frmProductMRP').attr("method", "POST");
                $('#frmProductMRP').submit();
            }
        }
    });
    

});