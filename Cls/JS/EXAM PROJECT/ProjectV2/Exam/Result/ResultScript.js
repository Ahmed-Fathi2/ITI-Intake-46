// منع المستخدم من العودة للامتحان
window.history.pushState(null, null, window.location.href);

window.onpopstate = function () {
    // أي محاولة للرجوع تعيده لنفس صفحة النتيجة
    window.history.go(1);
};



var score = document.getElementsByTagName("h3")[0];
score.textContent = `${sessionStorage.getItem("Result")}/10`;
var h1= document.querySelector('h1');
h1.textContent += ` ${sessionStorage.getItem("CurrentUser")}!`