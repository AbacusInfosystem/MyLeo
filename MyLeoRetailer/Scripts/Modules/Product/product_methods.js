
 
 
function UploadImage() {

    var preview1 = document.getElementById("img_0"); //selects the query named img 

    var file = document.getElementById('myFile').files[0]; //sames as here

    var reader = new FileReader();

    reader.onload = function (e) {
        //if (preview1.src == "~/UploadedFiles/")
        preview1.src = reader.result;

    }

    if (file) {
        reader.readAsDataURL(file); //reads the data as a URL

    } else {
        preview1.src = "";
    }
}


