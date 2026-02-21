var users = JSON.parse(localStorage.getItem("users"));
var errorMessage = document.getElementById("Invalid");

// if (sessionStorage.getItem("LoginState") == 'true') {
//     window.location.replace("http://127.0.0.1:5500/Quiz/Quiz.html");
// }

function ValidateLogin(e) {
    var mail = document.querySelectorAll("input")[0].value;
    var pass = document.querySelectorAll("input")[1].value;
    var user = JSON.parse(localStorage.getItem(mail));
    if (user) {
        if (user.password === pass) {
            sessionStorage.setItem("LoginState", true);
            sessionStorage.setItem("CurrentUser", user.firstName+" "+user.lastName);

            sessionStorage.setItem("")
            errorMessage.innerText = "";
            return;
        }
    }
        e.preventDefault();
        errorMessage.innerText = "Email or password are invalid";
}
