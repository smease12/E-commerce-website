document.addEventListener('DOMContentLoaded', function () {
    //Get references to all quantity dropdowns hidden price inputs
    const quantityDropdowns = document.querySelectorAll('[id^="quantityDropdown_"]');
    const hiddenPrices = document.querySelectorAll('[id^="hiddenPrice_"]');

    const deleteButtons = document.querySelectorAll('.delete-button');
    const form = document.getElementById('productListForm');

    deleteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            event.preventDefault();

            const productId = button.getAttribute('data-product-id');
            deleteProduct(productId);
        });
    });

    async function deleteProduct(productId) {
        const token = $(`input[name='__RequestVerificationToken']`).val(); //Get the token in the value
        try {
            const response = await fetch(`/Checkout?handler=Delete&productId=${productId}`, {
                method: "POST",
                headers: {
                    'X-Requested-Width': 'XMLHttpRequest', //to identify AJAX request
                    'RequestVerificationToken': token //Include the token in the headers
                }
            });

            if (response.ok) {
                //Delete was successful, refresh the page
                window.location.reload();
            }
            else {
                //Handle error
                console.error('Failed to delete product');
            }

            //debugging response
            //  const responseData = await response.text(); //get the response as text
            ////  console.log(response);
            //  if (responseData) {
            //      console.log(responseData);
            //      const parsedData = JSON.parse(responseData);
            //     // console.log(parsedData);
            //  }
            //  else {
            //      console.log('Empty or unexpected response');
            //  }
        }
        catch (error) {
            console.error(error);
        }
    }

    //Define a function to update the price based on the selected quantity
    function updatePrice(event) {
        //Find previous total price and count
        const displayTotalSellPrice = document.getElementById('displayTotalSellPrice');
        const hiddenProductTypeCount = document.getElementById('hiddenProductTypeCount').value;
        const hiddenProductCount = document.getElementById('hiddenProductCount');


        //get selected quantity, productid, and priceperunit from quantity dropdown
        const selectedQuantity = event.target.value;
        const productId = event.target.dataset.productId;
        const pricePerUnit = parseFloat(event.target.dataset.productPrice);
        //Calculate the total price based on the quantity and price per unit
        const totalPrice = selectedQuantity * pricePerUnit;

        //Find the corresponding price display and update it
        const priceDisplay = document.getElementById('priceDisplay_' + productId);
        priceDisplay.textContent = '$' + totalPrice.toFixed(2); //Display price with 2 decimal places

        //Find corresponding hidden input for price and update it
        const hiddenPrice = document.getElementById('hiddenPrice_' + productId);
        hiddenPrice.value = totalPrice.toFixed(2);
        
        //Add together all priceDisplays and get new total product count
        let totalPriceCombined = 0.00;
        let newProductCount = 0;

        for (i = 0; i < hiddenProductTypeCount; i++) {
            newProductCount = newProductCount + parseInt(quantityDropdowns[i].value);
            console.log(newProductCount);
            totalPriceCombined = totalPriceCombined + parseFloat(hiddenPrices[i].value);
        }

        hiddenProductCount.value = newProductCount;

        //update display and hidden field of total price before tax and shipping
        const displayCheckoutCount = document.getElementById('displayCheckoutCount');
        displayCheckoutCount.textContent = "Checkout (" + hiddenProductCount.value + " Items)";

        //update display and hidden field of total price before tax and shipping
        displayTotalSellPrice.textContent = "Items: $" + totalPriceCombined.toFixed(2);
        const hiddenTotalSellPrice = document.getElementById('hiddenTotalSellPrice');
        hiddenTotalSellPrice.value = totalPriceCombined.toFixed(2);

        //calculate shipping cost, update hidden and display for shipping value
        let shipping = totalPriceCombined * .2;
        console.log("shipping =" + shipping);
        const hiddenShipping = document.getElementById('hiddenShipping');
        const displayShipping = document.getElementById('displayShipping');
        hiddenShipping.value = shipping.toFixed(2);
        displayShipping.textContent = "Shipping/Handling: $" + shipping.toFixed(2);

        //update total price with shipping for total before tax, update hidden and display for total before tax
        totalPriceCombined = (totalPriceCombined + shipping);
        const hiddenTotalBeforeTax = document.getElementById('hiddenTotalBeforeTax');
        const displayTotalBeforeTax = document.getElementById('displayTotalBeforeTax');
        hiddenTotalBeforeTax.value = totalPriceCombined.toFixed(2);
        displayTotalBeforeTax.textContent = "Total Before Tax: $" + totalPriceCombined.toFixed(2);

        //calculate tax, update hidden and display for tax
        let tax = (totalPriceCombined * .07);
        const hiddenTax = document.getElementById('hiddenTax');
        const displayTax = document.getElementById('displayTax');
        hiddenTax.value = tax.toFixed(2);
        displayTax.textContent = "Tax: $" + tax.toFixed(2);

        //update total price with tax for order total, update hidden and display for order total
        totalPriceCombined = (totalPriceCombined + tax);
        const hiddenOrderTotal = document.getElementById('hiddenOrderTotal');
        const displayOrderTotal = document.getElementById('displayOrderTotal');
        hiddenOrderTotal.value = totalPriceCombined.toFixed(2);
        displayOrderTotal.textContent = "Order Total $" + totalPriceCombined.toFixed(2);
    }

    //Attach the "change" event listener to each quantity dropdown
    quantityDropdowns.forEach(dropdown => {
        dropdown.addEventListener('change', updatePrice);
    });

    //Call the updatePrice function initially to display the initial prices
    updatePrice();
});

$(document).ready(function () {
    //Open the popup when the "open popup" button is clicked
    $("#openAddressPopupButton").click(function () {
        $("#popupAddressForm").fadeIn();
    });

    //Close the popup button when the "Close" button or outside the popup is clicked
    $("#closeAddressPopupButton, .popup").click(function () {
        $("#popupAddressForm").fadeOut();
    });

    //Prevent the popup from closing when the form inside it is clicked
    $("#popupAddressForm .popup-content").click(function (e) {
        e.stopPropagation();
    });
});