// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () { 

    document.getElementById('btnSearch').addEventListener('click', function () {
    const inputElement = document.getElementById('inputSearch');
    const inputValue = inputElement.value;

    if (inputValue) {
        const url = `/search?keyword=${encodeURIComponent(inputValue)}`;

        window.location.href = url;
    }

});

});