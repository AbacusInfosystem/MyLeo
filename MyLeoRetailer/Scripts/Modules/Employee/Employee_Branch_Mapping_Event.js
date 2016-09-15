$(document).ready(function () {

    $("#btnSave").click(function () {

            $("#frmEmployeeBranchMapping").attr("action", "/Employee/Insert_Employee_Mapping"); //Insert

            $("#frmEmployeeBranchMapping").attr("method", "Post");

            $("#frmEmployeeBranchMapping").submit();

       
    });
});