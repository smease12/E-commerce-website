// loader = document.querySelector('.loader'); commented out 4/29/23, didn't use loader

// select inputs 
const submitBtn = document.querySelector('.submit-btn');
const name = document.querySelector('#Name');
const email = document.querySelector('#Email');
const password = document.querySelector('#Password');
const number = document.querySelector('#Number');
const tac = document.querySelector('#TermsAndCond');
const notification = document.querySelector('#Notification');

submitBtn.addEventListener('click', () => {
    if (name.value.length < 3) {
        showAlert('name must be 3 letters long');
    } else if (!email.value.length) {
        showAlert('enter your email');
    } else if (password.value.length < 8) {
        showAlert('password should be 8 letters long');
    } else if (!number.value.length) {
        showAlert('enter your phone number');
    } else if (!Number(number.value) || number.value.length < 10) {
        showAlert('invalid number, please enter valid one');
    } else if (!tac.checked) {
        showAlert('you must agree to our terms and conditions');
    } else {
        // submit form
    }
})

// alert function
const showAlert = (msg) => {
    let alertBox = document.querySelector('.alert-box');
    let alertMsg = document.querySelector('.alert-msg');
    alertMsg.innerHTML = msg;
    alertBox.classList.add('show');
    setTimeout(() => {
        alertBox.classList.remove('show');
    }, 3000);
}

