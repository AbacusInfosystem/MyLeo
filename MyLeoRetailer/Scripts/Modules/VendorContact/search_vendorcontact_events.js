

$(function () {

    document.getElementById('btnVendorContact').disabled = true;

    Get_Vendor_Contacts();

    $("[name='Filter.Vendor_Contact_Name']").focusout(function () {
        document.getElementById('btnVendorContact').disabled = true;//Added by vinod mane on 25/10/2016
        Get_Vendor_Contacts();
    });


    $("#btnVendorContact").click(function () {
        $("#frmVendorContact").attr("action", "/VendorContact/Get_Vendor_Contact_By_Id");
        $("#frmVendorContact").attr("method", "post");
        $("#frmVendorContact").submit();
    });


    $(document).on('change', '[name="Vendor_Contact_List"]', function (event) {
        //alert(); Commented by Vinod Mane on 19/09/2016
        if ($(this).prop('checked')) {
            $("#hdnVendorContact_Id").val(this.value);
            //$("#btnVendorContact").show();
            document.getElementById('btnVendorContact').disabled = false;
        }
    });


    $("#btncreateVC").click(function () {

        $("#frmVendorContact").attr("action", "/VendorContact/Index");
        $("#frmVendorContact").submit();

    });


    $("#btnVendorContact").click(function () {
        $("#frmVendorContact").attr("action", "/VendorContact/Get_Vendor_Contact_By_Id");
        $("#frmVendorContact").submit();
    });

    //Added By Vinod Mane on 22/09/2016
    $(document).on("change", "#hdnVendorContactId", function () {
        document.getElementById('btnVendorContact').disabled = true;//Added by vinod mane on 25/10/2016
        Get_Vendor_Contacts();
    });
    //End

    //$(document).on("click", "[name='Vendor_Contact_List']", function () {

    //    Get_Vendor_Contact_By_Id(this);

    //});

   

   
        
  


   

});






