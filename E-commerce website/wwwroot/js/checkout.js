document.addEventListener('DOMContentLoaded', function () {
    //Get references to all quantity dropdowns hidden price inputs
    const quantityDropdowns = document.querySelectorAll('[id^="quantityDropdown_"]');
    const hiddenPrices = document.querySelectorAll('[id^="hiddenPrice_"]');

    //Define a function to update the price based on the selected quantity
    function updatePrice(event) {
        //Find previous total price and count
        const displayTotalSellPrice = document.getElementById('displayTotalSellPrice');
        const count = document.getElementById('productCount').value;

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
        
        //Add together all priceDisplays before tax and shipping
        let totalPriceCombined = 0.00;
        console.log(totalPriceCombined);
        for (i = 0; i < count; i++)
        {
            totalPriceCombined =  totalPriceCombined + parseFloat(hiddenPrices[i].value);
        }

        //update display and hidden field of total price before tax and shipping
        displayTotalSellPrice.textContent = "Items: $" + totalPriceCombined.toFixed(2);
        const hiddenTotalSellPrice = document.getElementById('hiddenTotalSellPrice');
        hiddenTotalSellPrice.value = totalPriceCombined.toFixed(2);

        //calculate shipping cost, update hidden and display for shipping value
        let shipping = (totalPriceCombined * .2).toFixed(2);
        const hiddenShipping = document.getElementById('hiddenShipping');
        const displayShipping = document.getElementById('displayShipping');
        hiddenShipping.value = shipping;
        displayShipping.textContent = "Shipping/Handling: $" + totalPriceCombined;

        //update total price with shipping for total before tax, update hidden and display for total before tax
        totalPriceCombined = (totalPriceCombined + shipping).toFixed(2);
        const hiddenTotalBeforeTax = document.getElementById('hiddenTotalBeforeTax');
        const displayTotalBeforeTax = document.getElementById('displayTotalBeforeTax');
        hiddenTotalBeforeTax.value = totalPriceCombined;
        displayTotalBeforeTax.textContent = "Total Before Tax: $" + totalPriceCombined;

        //calculate tax, update hidden and display for tax
        let tax = (totalPriceCombined * .07).toFixed(2);
        const hiddenTax = document.getElementById('hiddenTax');
        const displayTax = document.getElementById('displayTax');
        hiddenTax.value = tax;
        displayTax.textContent = "Tax: $" + tax;

        //update total price with tax for order total, update hidden and display for order total
        totalPriceCombined = (totalPriceCombined + tax).toFixed(2);
        const hiddenOrderTotal = document.getElementById('hiddenOrderTotal');
        const displayOrderTotal = document.getElementById('displayOrderTotal');
        hiddenOrderTotal.value = totalPriceCombined;
        displayOrderTotal.textContent = "Order Total $" + totalPriceCombined;
    }

    //Attach the "change" event listener to each quantity dropdown
    quantityDropdowns.forEach(dropdown => {
        dropdown.addEventListener('change', updatePrice);
    });

    //Call the updatePrice function initially to display the initial prices
    updatePrice();
});