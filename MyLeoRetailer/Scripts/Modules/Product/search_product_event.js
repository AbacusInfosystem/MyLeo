
$(function () {
   

    document.getElementById('btnEdit').disabled = true;

    document.getElementById('btnProductMRP').disabled = true;

    Get_Products();

    $("[name='Filter.Article_No']").focusout(function () {

        document.getElementById('btnEdit').disabled = true;//Added by vinod mane on 25/10/2016
        document.getElementById('btnProductMRP').disabled = true;//Added by vinod mane on 25/10/2016
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
                //$("#btnProductMRP").show();
                //$("#btnEdit").show();


                document.getElementById('btnEdit').disabled = false;

                document.getElementById('btnProductMRP').disabled = false;
            }
        });

    //Added By Vinod Mane on 14/10/2016
        $(document).on("change", "#hdnArticle_No", function () {

            document.getElementById('btnEdit').disabled = true;//Added by vinod mane on 25/10/2016
            document.getElementById('btnProductMRP').disabled = true;//Added by vinod mane on 25/10/2016
            Get_Products();
        });
});