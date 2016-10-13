$(document).ready(function () {
    Get_Product_Dispatch();

    var is_Check = 0;

    $("#btnAccept").click(function () {

      var length= document.getElementsByClassName("rd-list").length;

      for (var i = 0; i < length; i++)
      {
          if (document.getElementsByName("List_product_Dispatch[" + i + "].Is_Checked")[0].value == 1)
          {
              is_Check = 1;

              i = length;
          }
      }

        if (document.getElementsByClassName("table")[0].rows.length > 1 && is_Check==1) {

            $("#frmInwardProduct").attr("action", "/ProductDispatch/Accept_Product_Dispatch");

            $("#frmInwardProduct").attr("Method", "POST");

            $("#frmInwardProduct").submit();
        }
    });
});
