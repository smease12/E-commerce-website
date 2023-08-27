const productContainers1 = [...document.querySelectorAll('.product-container')];
const nxtBtn = [...document.querySelectorAll('.nxt-btn')];
const preBtn = [...document.querySelectorAll('.pre-btn')];

productContainers1.forEach((item, i) => {
    let containerDimenstions = item.getBoundingClientRect();
    let containerWidth = containerDimenstions.width;

    nxtBtn[i].addEventListener('click', () => {
        item.scrollLeft += containerWidth;
    })

    preBtn[i].addEventListener('click', () => {
        item.scrollLeft -= containerWidth;
    })
})


// When the user clicks on div, open the popup
function openPopup() {
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
}

function openPopup2() {
    var popup = document.getElementById("myPopup2");
    popup.classList.toggle("show");
}