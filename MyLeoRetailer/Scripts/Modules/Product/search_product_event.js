
$(function () {

    Get_Products();

        $("[name='Filter.Article_No']").focusout(function () {
            Get_Products();
        }); 
         
        $("#btnEdit").click(function () {
            
            $("#frmSearchProduct").attr("action", "/Product/Get_Product_By_Id/");

            $("#frmSearchProduct").attr("method", "post");

            $("#frmSearchProduct").submit();
        });

        $("#btnProductMRP").click(function () {

            $("#frmSearchProduct").attr("action", "/Product/serch-ProductPrizing/");

            $("#frmSearchProduct").attr("method", "post");

            $("#frmSearchProduct").submit();
        });
        

        $(document).on('change','[name="Product_List"]', function (event) { 
            if ($(this).prop('checked')) {
                $("#hdf_ProductId").val(this.value);
                $("#hdf_SizeGroupId").val($('[name="Size_Group_Id"]').val());
                $("#btnProductMRP").show();
                $("#btnEdit").show();
            }
        }); 
});