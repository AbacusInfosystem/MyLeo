

$(function () {

    Get_SizeGroups();

    $("#btnSaveSizeGroup").click(function () {

        if ($("#frmSizeGroup").valid()) {

            Save_SizeGroup();
        }
    });

    $(document).on("click", "[name='Size_Group_List']", function () {

        Get_Size_Group_Name_By_Id(this);

        Get_Sizes();

    });


    $("#btnSaveSize").click(function () {

            if ($("#frmSize").valid()) {

                Save_Size();
            }
        
    });



    $("[name='Filter.Size_Group_Name']").focusout(function () {

        Get_SizeGroups();

    });
});


