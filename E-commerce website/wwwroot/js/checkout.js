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
        
        //Add together all priceDisplays and update total price before tax and shipping
        let totalPriceCombined = 0.00;
        console.log(totalPriceCombined);
        for (i = 0; i < count; i++)
        {
            totalPriceCombined =  totalPriceCombined + parseFloat(hiddenPrices[i].value);
        }
        
        displayTotalSellPrice.textContent = "Items $" + totalPriceCombined.toFixed(2);


        
    }

    //Attach the "change" event listener to each quantity dropdown
    quantityDropdowns.forEach(dropdown => {
        dropdown.addEventListener('change', updatePrice);
    });

    //Call the updatePrice function initially to display the initial prices
    updatePrice();
});