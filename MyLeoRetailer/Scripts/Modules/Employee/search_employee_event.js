
$(function () {

    Get_Employees();

    

    $("[name='Filter.Employee']").focusout(function () {
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
            $("#btnEdit").show();
            $("#btnMapBranchEmployee").show();

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


});