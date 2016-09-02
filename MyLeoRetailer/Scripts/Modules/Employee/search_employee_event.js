﻿
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

    $(document).on('change', '[name="Employee_List"]', function (event) {
        if ($(this).prop('checked')) {
            $("#hdf_EmployeeId").val(this.value);
            $("#btnEdit").show();
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
});