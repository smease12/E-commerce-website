discount.addEventListener('input', () => {
    if (discount.value > 100) {
        discount.value = 90;
    } else {
        let d = (actualprice.value * discount.value) / 100;
        sellprice.value = actualprice.value - d;
        
    }
})

sellprice.addEventListener('input', () => {
    let d = (sellprice.value / actualprice.value) * 100;
    discount.value = d;
})

let uploadImages = document.querySelectorAll('.fileupload');
let imagePaths = []; // will store all uploaded images paths;

uploadImages.forEach((fileupload, index) => {
    fileupload.addEventListener('change', () => {
        const file = fileupload.files[0];
        let imageUrl;

        if (file.type.includes('image')) {
            // Create a FileReader object
            var reader = new FileReader();

            // Set up the FileReader onload event
            reader.onload = function (e) {
                let label = document.querySelector(`label[for=${fileupload.id}]`);
                label.style.backgroundImage = `url(${e.target.result})`;
                let productImage = document.querySelector('.product-image');
                productImage.style.backgroundImage = `url(${e.target.result})`;
            };

            // Read the uploaded file as a data URL
            reader.readAsDataURL(file);
            
        } else {
            showAlert('upload image only');
        }
    })
})

//function to clear all textboxes in the form
function clearTextboxes()
{
    var textboxes = document.querySelectorAll('input[type="text"]');
    var numTextBoxes = document.querySelectorAll('input[type="number"]');
    var desTextArea = document.getElementById("des");
    var tagsTextArea = document.getElementById("tags");

    desTextArea.value = '';
    tagsTextArea.value = '';
    textboxes.forEach(function (textbox) {
        textbox.value = '';
    });
    numTextBoxes.forEach(function (textarea) {
        textarea.value = '';
    });
}


if (isOperationSuccessful)
{
    var successBanner = document.getElementById('notification-banner');
    successBanner.style.display = 'block';
    clearTextboxes();
}

