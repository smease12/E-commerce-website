// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.getElementById('inputSearch');
    const searchButton = document.getElementById('btnSearch');

    searchInput.addEventListener('keydown', function (event) {
        //check if the pressed key is Enter (key code 13)
        if (event.key == 'Enter') {
            //Prevent the default form submission behavior
            event.preventDefault();

            //check if the search input has text
            if (searchInput.value.trim() !== '') {
                //trigger a click event on the search button
                searchButton.click();
            }
        }
    });

    searchButton.addEventListener('click', function () {
        const inputValue = searchInput.value; 
        if (inputValue) {
            const url = `/search?keyword=${encodeURIComponent(inputValue)}`;
            window.location.href = url;
        }
    });

});