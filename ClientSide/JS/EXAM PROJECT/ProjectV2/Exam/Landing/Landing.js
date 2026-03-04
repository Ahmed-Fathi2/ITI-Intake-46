






var btnStart = document.querySelector('.btn-start');
var btnLogin = document.querySelector('.btn-login-header');
var btnSignUp = document.querySelector('.btn-signup-header');

// var Registerkey = user.email + user.firstName + user.lastName;
// localStorage.setItem(user.email, JSON.stringify(user));
// localStorage.setItem(Registerkey, true);

if(sessionStorage.getItem("Registerkey")){

    btnSignUp.style.display="none";
    btnLogin.style.display="none";

}

// btnStart.addEventListener("click", function () {



//     // window.location.assign("http://127.0.0.1:5500/project/Quiz.html")
//     window.location.replace("/Quiz/Quiz.html")

// })


btnStart.addEventListener("click", function () {
    // أضف حالة في الـ sessionStorage لتأكيد دخول الامتحان
    sessionStorage.setItem("ExamStarted", "true");

    // استبدل الصفحة للامتحان
    window.location.replace("/Quiz/Quiz.html");
});

btnLogin.addEventListener("click", function () {

    window.location.assign("http://127.0.0.1:5500/Login/login.html")
})

btnSignUp.addEventListener("click", function () {

    window.location.assign("http://127.0.0.1:5500/Register/Register.html")

})