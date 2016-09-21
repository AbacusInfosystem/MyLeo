
 
 
function UploadImage() {

    var preview1 = document.getElementById("img_0"); //selects the query named img 
    var preview2 = document.getElementById("img_1");
    var preview3 = document.getElementById("img_2");
    var preview4 = document.getElementById("img_3");

    var file = document.getElementById('productImage').files[0]; //sames as here 

    var reader = new FileReader();

    reader.onload = function () {
        if ($("#hdn_Img_0").val() == "")
        {
            preview1.src = reader.result;
            $("#hdn_ImgSrc_0").val(reader.result);
            $("#hdn_Img_0").val(file.name);
          
        }
        else if ($("#hdn_Img_1").val() == "")
        {
            preview2.src = reader.result;
            $("#hdn_ImgSrc_1").val(reader.result);
            $("#hdn_Img_1").val(file.name);
           
        }
        else if ($("#hdn_Img_2").val() == "") {

            preview3.src = reader.result;
            $("#hdn_Img_2").val(file.name);
            $("#hdn_ImgSrc_2").val(reader.result);

        }
        else if ($("#hdn_Img_3").val() == "") {

            preview4.src = reader.result;
            $("#hdn_Img_3").val(file.name);
            $("#hdn_ImgSrc_3").val(reader.result);

        }
    }

    if (file) {
        reader.readAsDataURL(file); //reads the data as a URL

    } else {
        preview1.src = "";
    } 
}  
