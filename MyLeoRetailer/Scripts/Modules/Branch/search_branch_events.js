$(function () {

   
    document.getElementById('btnEditBranch').disabled = true; 

    Get_Branchs();

    $(document).on('change', '[name="Branch_List"]', function (event) {        
        if ($(this).prop('checked')) {
            $("#hdnBranch_ID").val(this.value);
            document.getElementById('btnEditBranch').disabled = false;
            //$("#btnEditBranch").show();
        }
    });


    $("[name='Filter.Branch_Name']").focusout(function () {
        Get_Branchs();
    });
       
    $("#btnCreateBranch").click(function () {

       
            $("#frmBranch").attr("action", "/Branch/Index");
            $("#frmBranch").submit();
       
    });

    //$('#frmBranch').on('keyup keypress', function (e) {
    //    var keyCode = e.keyCode || e.which;
    //    if (keyCode === 13) {
    //        e.preventDefault();
    //        return false;
    //    }
    //});

    $("#btnEditBranch").click(function () {
        $("#frmBranch").attr("action", "/Branch/Get_Branch_By_Id");
        $("#frmBranch").submit();
    });

    //Added By Vinod Mane on 23/09/2016
    $(document).on("change", "#hdnBranchID", function () {
        Get_Branchs();
    });
});