var btnAdd = document.getElementById('add-btn')
var btnReset = document.getElementById('reset-btn')
var tableBody = document.getElementById('table-body')
var _name = document.getElementById('inName')
var _age = document.getElementById('inAge')
var _email = document.getElementById('inMail')

btnAdd.onclick = function (event) {
    event.preventDefault();
    if (!validateForm()) return; 

    var newRow = document.createElement('tr')

    var tdName = document.createElement('td')
    var tdAge = document.createElement('td')
    var tdEmail = document.createElement('td')

    tdName.textContent = _name.value
    tdAge.textContent = _age.value
    tdEmail.textContent = _email.value

    
    newRow.appendChild(tdName)
    newRow.appendChild(tdAge)
    newRow.appendChild(tdEmail)
    
    tableBody.appendChild(newRow)



    _name.value = ""
    _age.value = ""
    _email.value = ""

}

function validateForm() {

    
    var name = document.getElementById("inName");
    var age = document.getElementById("inAge");
    var email = document.getElementById("inMail");

    
    var nameError = document.getElementById("nameError");
    var ageError = document.getElementById("ageError");
    var emailError = document.getElementById("emailError");

   
    var isValid = true;

  
    if (name.value.trim() === "") {
        nameError.textContent = "Name is required";
        isValid = false;
    } else {
        nameError.textContent = "";
    }


    if (age.value.trim() === "") {
        ageError.textContent = "Age is required";
        isValid = false;
    } 
    else if (!isFinite(age.value)) {
        ageError.textContent = "Age must be a number";
        isValid = false;
    } 
    else if (age.value <= 0) {
        ageError.textContent = "Age must be greater than 0";
        isValid = false;
    } 
    else {
        ageError.textContent = "";
    }


    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (email.value.trim() === "") {
        emailError.textContent = "Email is required";
        isValid = false;
    } 
    else if (!emailPattern.test(email.value)) {
        emailError.textContent = "Invalid email format";
        isValid = false;
    } 
    else {
        emailError.textContent = "";
    }

    return isValid; 
}


btnReset.onclick = function() {
    _name.value = "";
    _age.value = "";
    _email.value = "";
    document.getElementById("nameError").textContent = "";
    document.getElementById("ageError").textContent = "";
    document.getElementById("emailError").textContent = "";
};
