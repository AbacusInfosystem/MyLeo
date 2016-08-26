
$(function () {

    Get_Employees();

        $("[name='Filter.Employee']").focusout(function () {
            Get_Employees();
        }); 
         
        $("#btnEdit").click(function () {
            
            $("#frmSearchEmployee").attr("action", "/Employee/Get_Employee_By_Id/");

            $("#frmSearchEmployee").attr("method", "post");

            $("#frmSearchEmployee").submit();
        });

        $(document).on('change','[name="Employee_List"]', function (event) {
           
            if ($(this).prop('checked')) {
                $("#hdf_EmployeeId").val(this.value);
                $("#btnEdit").show();
            }
        });
});