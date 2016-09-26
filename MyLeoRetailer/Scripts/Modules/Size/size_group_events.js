

$(function () {

    Get_SizeGroups();

    $("#btnSaveSizeGroup").click(function () {

        if ($("#frmSizeGroup").valid()) {

            Save_SizeGroup();
        }
    });

    $(document).on("click", "[name='Size_Group_List']", function () {

        //Get_Size_Group_Name_By_Id(this);

        Get_SizeGroup_By_Id(this);

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

    //Added By Vinod Mane on 22/09/2016
    $(document).on("change", "#hdnSize_Group_Name", function () {
        Get_SizeGroups();
    });



});


