$(document).ready(function () {

    $("#btnUpdatePurchaseReturn").click(function (event) {

        var PurchaeReturnId = $('#hdnPurchaseReturnId').val();
        $("#div_Parent_Modal_Fade").find(".modal-body").load("/PurchaseReturn/Update_GR_No", { Id: PurchaeReturnId }, call_back);

        document.getElementById('btnUpdatePurchaseReturn').disabled = true;
        
    });


    document.getElementById('btnEditPurchaseReturn').disabled = true;

    document.getElementById('btnUpdatePurchaseReturn').disabled = true;
   
    Get_Purchase_Returns();

    $(document).on('change', '[name="Purchase_Return_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdnPurchaseReturnId").val(this.value);
            document.getElementById('btnEditPurchaseReturn').disabled = false;
            document.getElementById('btnCreatePurchaseReturn').disabled = true;
            document.getElementById('btnUpdatePurchaseReturn').disabled = false;
        }
    });

    $("[name='Filter.Debit_Note_No']").focusout(function () {
        Get_Purchase_Returns();
    });


    $("#btnCreatePurchaseReturn").click(function () {
        $("#frmPurchaseReturn").attr("action", "/PurchaseReturn/Index");
        $("#frmPurchaseReturn").submit();
    });

    $("#btnEditPurchaseReturn").click(function () {
       // Get_Purchase_Returns_Details_View();
        $("#frmPurchaseReturn").attr("action", "/PurchaseReturn/Get_Purchase_Return_Details_By_Id/");      

        $('#frmPurchaseReturn').submit();

    });
       

});

