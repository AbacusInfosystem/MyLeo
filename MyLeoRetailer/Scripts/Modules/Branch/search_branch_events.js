$(function () {
   
    document.getElementById("btnEditBranch").disabled = true;

    Get_Branchs();

    $(document).on('change', '[name="Branch_List"]', function (event) {        
        if ($(this).prop('checked')) {
            $("#hdnBranch_ID").val(this.value);
            document.getElementById("btnEditBranch").disabled = false;
        }
    });


    $("[name='Filter.Branch_Name']").focusout(function () {
        Get_Branchs();
    });
       
    $("#btnCreateBranch").click(function () {

        $("#frmBranch").attr("action", "/Branch/Index");
        $("#frmBranch").submit();

    });

    $("#btnEditBranch").click(function () {
        $("#frmBranch").attr("action", "/Branch/Get_Branch_By_Id");
        $("#frmBranch").submit();
    });
});