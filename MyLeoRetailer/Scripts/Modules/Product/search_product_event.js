
$(function () {

    Get_Products();

        //$("[name='Filter.Product']").focusout(function () {
        //    Get_Products();
        //}); 
         
        $("#btnEdit").click(function () {
            
            $("#frmSearchProduct").attr("action", "/Product/Get_Product_By_Id/");

            $("#frmSearchProduct").attr("method", "post");

            $("#frmSearchProduct").submit();
        });

        $(document).on('change','[name="Product_List"]', function (event) {
           
            if ($(this).prop('checked')) {
                $("#hdf_ProductId").val(this.value);
                $("#btnEdit").show();
            }
        });
});