
$(function () {

    Get_Employees();

    document.getElementById('btnEditEmployee').disabled = true;

    document.getElementById('btnMapBranchEmployee').disabled = true;

    

    $("[name='Filter.Employee']").focusout(function () {
        //Added by vinod mane on 25/10/2016
        document.getElementById('btnEditEmployee').disabled = true;
        document.getElementById('btnMapBranchEmployee').disabled = true;
        //End
        Get_Employees();
    });

    $("#btnEdit").click(function () {
        $("#frmEmployee").attr("action", "/Employee/Get_Employee_By_Id/");
        $("#frmEmployee").attr("method", "post");
        $("#frmEmployee").submit();
    });

    $("#btnMapBranchEmployee").click(function () {
        $("#frmEmployee").attr("action", "/Employee/Employee_Branch_Mapping");
        $("#frmEmployee").attr("method", "post");
        $("#frmEmployee").submit();
    });

    $(document).on('change', '[name="Employee_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdf_EmployeeId").val(this.value);
            //Modification
            //$("#btnEdit").show();   
            //$("#btnEditEmployee").show();
            ////End
            //$("#btnMapBranchEmployee").show();

            document.getElementById('btnEditEmployee').disabled = false;

            document.getElementById('btnMapBranchEmployee').disabled = false;

        }
    });

    $("#btnCreateEmployee").click(function () {

        $("#frmEmployee").attr("action", "/Employee/Index");
        $("#frmEmployee").submit();

    });

    $("#btnEditEmployee").click(function () {
        $("#frmEmployee").attr("action", "/Employee/Get_Employee_By_Id");
        $("#frmEmployee").submit();
    });

    //Addition by swapnali | Date:16/09/2016
    $("#btnSaveBranch").click(function () {
        $("#frmChangeBranch").attr("action", "/Employee/Save_Employee_Branch_Id");
        $("#frmChangeBranch").submit();
    });
    //End
    
    //Added By Vinod Mane on 28/09/2016
    $(document).on("change", "#hdnEmployeeName", function () {
        //Added by vinod mane on 25/10/2016
        document.getElementById('btnEditEmployee').disabled = true;
        document.getElementById('btnMapBranchEmployee').disabled = true;
        //End
        Get_Employees();
    });


});