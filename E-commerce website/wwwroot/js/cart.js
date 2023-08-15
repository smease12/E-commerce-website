document.addEventListener('DOMContentLoaded', function () {
    //Get references to all quantity dropdowns hidden price inputs, and hidden qty inputs
    const quantityDropdowns = document.querySelectorAll('[id^="quantityDropdown_"]');
    const hiddenPrices = document.querySelectorAll('[id^="hiddenPrice_"]');

    //Define a function to update the price based on the selected quantity
    function updatePrice(event) {
        //Find previous total price and count
        const displaySubtotal = document.getElementById('displaySubtotal');
        const productTypeCount = document.getElementById('hiddenProductTypeCount').value;
        const productCount = document.getElementById('hiddenProductCount');

        //get selected quantity, productid, and priceperunit from quantity dropdown
        const selectedQuantity = event.target.value;
        const productId = event.target.dataset.productId;
        const pricePerUnit = parseFloat(event.target.dataset.productPrice);

        //update hidden quantity input
        const hiddenQty = document.getElementById('hiddenQty_' + productId);
        hiddenQty.value = selectedQuantity;


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
        
        for (i = 0; i < productTypeCount; i++) {
            newProductCount = newProductCount + parseInt(quantityDropdowns[i].value);
            console.log(newProductCount);
            totalPriceCombined = totalPriceCombined + parseFloat(hiddenPrices[i].value);
        }

        productCount.value = newProductCount;

        //update display and hidden field of total price before tax and shipping
        displaySubtotal.textContent = "Subtotal(" + productCount.value + " Items): $" + totalPriceCombined.toFixed(2);
        const displaySubtotal2 = document.getElementById('displaySubtotal2');
        displaySubtotal2.textContent = "Subtotal(" + productCount.value + " Items): $" + totalPriceCombined.toFixed(2);


        const hiddenTotalSellPrice = document.getElementById('hiddenTotalPrice');
        hiddenTotalSellPrice.value = totalPriceCombined.toFixed(2);

    }

    //Attach the "change" event listener to each quantity dropdown
    quantityDropdowns.forEach(dropdown => {
        dropdown.addEventListener('change', updatePrice);
    });

    //Call the updatePrice function initially to display the initial prices
    updatePrice();
});