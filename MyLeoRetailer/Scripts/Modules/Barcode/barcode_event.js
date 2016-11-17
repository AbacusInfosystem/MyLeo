
$(function () {

    Get_Employees();


    $(document).on('change', '[name="Employee_List"]', function (event) {

        if ($(this).prop('checked')) {

            $("#hdf_EmployeeId").val(this.value);

            document.getElementById('btnEditEmployee').disabled = false;

            document.getElementById('btnMapBranchEmployee').disabled = false;

        }
    });

    $("#btnCreateEmployee").click(function () {

        $("#frmEmployee").attr("action", "/Employee/Index");
        $("#frmEmployee").submit();

    });

});