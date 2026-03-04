var fName = document.getElementById('firstName');
var lName = document.getElementById('lastName');
var email = document.getElementById('email');
var pass = document.getElementById('password');
var confirmPass = document.getElementById('confirmPassword');
var form = document.getElementById('form');
var submitbtn = document.getElementById('submit');


var fNameError = document.getElementById("firstNameError");
var lNameError = document.getElementById("lastNameError");
var emailError = document.getElementById("emailError");
var passError = document.getElementById("passwordError");
var confirmPassError = document.getElementById("confirmPasswordError");

// console.log(fName);
// console.log(lName);
// console.log(email);
// console.log(pass);
// console.log(confirmPass);
var isValidate = true;

form.onsubmit = function (e) {

    e.preventDefault()
    if (!validate()) {
        // console.log("prevent");
        return;
    }

    
     

  
    localStorage.setItem(user.email, JSON.stringify(user));


    sessionStorage.setItem("Registerkey", true);

    window.location.replace("http://127.0.0.1:5500/Login/login.html");





}

function validate() {
    isValidate = true;
    var nameRegex = /^[A-Za-z\u0621-\u064A]+$/;
    var emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    // ==============================================================================================
    if (fName.value.trim() === "") {
        fNameError.textContent = "First name is required";
        isValidate = false;
    }
    else if (!nameRegex.test(fName.value)) {

        fNameError.textContent = "First name must contain only alphabetical characters";
        isValidate = false;

    }
    else if (fName.value.length < 3) {
        fNameError.textContent = "First name must greater than or equal 3 chars";
        isValidate = false;
    }
    else {

        fNameError.textContent = ""
    }

    // ==============================================================================================

    if (lName.value.trim() === "") {
        lNameError.textContent = "Last name is required";
        isValidate = false;
    }
    else if (!nameRegex.test(lName.value)) {

        lNameError.textContent = "Last name must contain only alphabetical characters";
        isValidate = false;

    }
    else if (lName.value.length < 3) {
        lNameError.textContent = "Last name must greater than or equal 3 chars";
        isValidate = false;
    }
    else {

        lNameError.textContent = ""
    }
    // ==============================================================================================

    if (email.value.trim() === "") {
        emailError.textContent = "Email is required";
        isValidate = false;
    }
    else if (!emailRegex.test(email.value)) {

        emailError.textContent = "Invalid email format";
        isValidate = false;

    }

    else if (localStorage.getItem(email.value)) {
        emailError.textContent = "Email is alreaady exists"
        isValidate = false;
    }
    else {

        emailError.textContent = ""
    }

    // ==============================================================================================

    if (pass.value.trim() === "") {
        passError.textContent = "Password is required";
        isValidate = false;
    }
    else if (pass.value.length <= 8) {

        passError.textContent = "Password must be at least 8 characters long."
        isValidate = false;
    }
    else {

        passError.textContent = ""
    }

    // ==============================================================================================
    if (confirmPass.value.trim() === "") {
        confirmPassError.textContent = "Passwords don't match"
        isValidate = false;
    }

    else if (confirmPass.value !== pass.value) {
        confirmPassError.textContent = "Passwords don't match";
        isValidate = false;

    }
    else {
        confirmPassError.textContent = "";

    }
    // ==============================================================================================





    return isValidate;

}






