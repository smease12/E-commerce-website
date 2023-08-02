document.addEventListener('DOMContentLoaded', function () {
    //Get references to all quantity dropdowns and price displays
    const quantityDropdowns = document.querySelectorAll('[id^="quantityDropdown_"]');
    const priceDisplays = document.querySelectorAll('[id^="priceDisplay_"]');

    //Define a function to update the price based on the selected quantity
    function updatePrice(event) {
        const selectedQuantity = event.target.value;
        console.log(event.target.dataset);
        console.log(selectedQuantity);

        const productId = event.target.dataset.productId;

        const pricePerUnit = parseFloat(event.target.dataset.productPrice);
        console.log(event.target);
        console.log(pricePerUnit);
        //Calculate the total price based on the quantity and price per unit
        const totalPrice = selectedQuantity * pricePerUnit;
        console.log(totalPrice);
        //Find the corresponding price display and update it
        const priceDisplay = document.getElementById('priceDisplay_' + productId);

        priceDisplay.textContent = '$' + totalPrice.toFixed(2); //Display price with 2 decimal places
    }

    //Attach the "change" event listener to each quantity dropdown
    quantityDropdowns.forEach(dropdown => {
        dropdown.addEventListener('change', updatePrice);
    });

    //Call the updatePrice function initially to display the initial prices
    updatePrice();
});