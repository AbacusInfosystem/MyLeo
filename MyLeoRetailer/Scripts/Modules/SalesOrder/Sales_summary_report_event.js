
$(document).ready(function () {

    Get_Sales_Summary_Report();

    $("#btnSearchSalesSummary").click(function () {
        
        Get_Sales_Summary_Report();
    });

    $("#btnResetSalesSummary").click(function () {

        Reset_Sales_Summary_Report();

        Get_Sales_Summary_Report();

    });

});