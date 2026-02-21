// if (!sessionStorage.getItem("LoginState")) {
//     document.body.style.display = "none";
//     window.location.replace("http://127.0.0.1:5500/Login/login.html?");

// }

// else {

    window.history.pushState(null, null, window.location.href);
    window.onpopstate = function () {
        // أي محاولة للرجوع تنقل المستخدم لنفس الصفحة
        window.history.go(1);
    };

    var quizQuestions = [
        {
            question: "What is the language used to query databases?",
            options: ["HTML", "CSS", "SQL", "JavaScript"],
            answer: "SQL"
        },
        {
            question: "Which keyword is used to create a new table in SQL?",
            options: ["CREATE", "INSERT", "UPDATE", "DELETE"],
            answer: "CREATE"
        },
        {
            question: "Which query is used to retrieve all data from a table?",
            options: ["SELECT * FROM TableName", "GET * FROM TableName", "FETCH ALL TableName", "SHOW TableName"],
            answer: "SELECT * FROM TableName"
        },
        {
            question: "Which keyword is used to modify existing data in SQL?",
            options: ["UPDATE", "MODIFY", "CHANGE", "SET"],
            answer: "UPDATE"
        },
        {
            question: "Which keyword is used to delete a table or data?",
            options: ["DROP", "DELETE", "REMOVE", "CLEAR"],
            answer: "DROP"
        },
        {
            question: "Which query deletes specific rows from a table?",
            options: ["DELETE FROM TableName WHERE condition", "DROP TableName", "REMOVE FROM TableName", "CLEAR TableName"],
            answer: "DELETE FROM TableName WHERE condition"
        },
        {
            question: "Which keyword is used to add a new row into a table?",
            options: ["INSERT INTO", "ADD ROW", "CREATE ROW", "NEW ENTRY"],
            answer: "INSERT INTO"
        },
        {
            question: "Which keyword is used to create a relationship between two tables?",
            options: ["FOREIGN KEY", "JOIN", "RELATE", "LINK"],
            answer: "FOREIGN KEY"
        },
        {
            question: "Which query displays rows sorted by a specific column?",
            options: ["SELECT * FROM TableName ORDER BY ColumnName", "SORT TableName BY ColumnName", "ARRANGE TableName", "GROUP TableName"],
            answer: "SELECT * FROM TableName ORDER BY ColumnName"
        },
        {
            question: "Which query filters results based on a condition?",
            options: ["SELECT * FROM TableName WHERE condition", "FILTER TableName WHERE condition", "SHOW TableName WHERE condition", "GET TableName IF condition"],
            answer: "SELECT * FROM TableName WHERE condition"
        }
    ];


    var totalSeconds = .5 * 60;

    var timerDisplay = document.getElementById("timerDisplay");

    const timerInterval = setInterval(function () {
        var minutes = Math.floor(totalSeconds / 60);
        var seconds = totalSeconds % 60;

        timerDisplay.textContent =
            `${String(minutes).padStart(2, "0")}:${String(seconds).padStart(2, "0")}`;

        if (minutes === 5) {
            timerDisplay.style.color = 'red'
        }

        if (totalSeconds <= 0) {
            clearInterval(timerInterval);
            showTimeUpMessage();

            for (var i = 0; i < answer.length; i++) {

                if (answer[i] == quizQuestions[numbers[i]].answer.valueOf())
                    result++;
            }
            sessionStorage.setItem("Result", result);
        }

        totalSeconds--;
    }, 1000);


    function showTimeUpMessage() {
        var overlay = document.createElement("div");
        overlay.className = "time-up-overlay";

        overlay.innerHTML = `
    <div class="time-up-card">
      <h2>Time’s Up,${sessionStorage.getItem("CurrentUser")}</h2>
      <p>The exam time has ended. Your answers have been submitted automatically.</p>
      <button onclick="goToResult()">View Result</button>
    </div>
  `;

        document.body.appendChild(overlay);
    }

    // raplce url to result page 
    function goToResult() {

        window.location.replace("http://127.0.0.1:5500/Result/result.html");
    }

    var numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

    function shuffleArray(arr) {
        for (let i = arr.length - 1; i > 0; i--) {
            const randomIndex = Math.floor(Math.random() * (i + 1));
            [arr[i], arr[randomIndex]] = [arr[randomIndex], arr[i]];
        }
        return arr;
    }
    shuffleArray(numbers);

    // console.log(numbers);

    var questionNum = 0
    var answer = [];
    var result = 0;
    sessionStorage.setItem("Result", result);
    var markedbtn = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    var answeredbtn = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    // var arr = new Array(10).fill(0);



    var optionsText = document.querySelectorAll('.optionText');
    var optionsInput = document.querySelectorAll('.optionInput');
    var question = document.querySelector(".question-text");
    var nextbtn = document.getElementsByClassName('btnNext')[0];
    var prevbtn = document.getElementsByClassName('Prevbtn')[0];
    var questionbtn = document.getElementById('currentQ');
    var submitbtn = document.getElementById('submitbtn');
    var markbtn = document.getElementById("mark");
    var header = document.getElementsByClassName("header")[0];




    // ==============================================================================================
    // 1- load first random question
    question.textContent = quizQuestions[numbers[questionNum]].question;
    document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "white"
    document.getElementsByClassName("markbtn")[questionNum].style.color = "#667eea";
    for (i = 0; i < optionsText.length; i++) {
        optionsText[i].textContent = quizQuestions[numbers[questionNum]].options[i]
        optionsInput[i].value = quizQuestions[numbers[questionNum]].options[i]
    }


    // ==============================================================================================


    optionsInput.forEach(option => {
        option.addEventListener('change', function () {
            answer[questionNum] = this.value;

            // if (answer[questionNum] == quizQuestions[numbers[questionNum]].answer.valueOf()) {
            //     result++;
            //     sessionStorage.setItem("Result", result);
            // }
            console.log('current answer array', answer);
            // if (document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor != 'yellow') {
            //     document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "lightgreen";
            // }
            answeredbtn[questionNum] = 1;

            console.log(result);


        });
    });



    // ==============================================================================================

    nextbtn.onclick = function () {
        if (!answer[questionNum]) {
            answer[questionNum] = null;
            // document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor="rgba(255, 255, 255, 0.3)";
            // document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor="red";
            document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "rgba(255, 255, 255, 0.3)"; // unanswerd

        }
        else {
            document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "lightgreen";

        }

        if (markedbtn[questionNum] === 1) {
            document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "#FDB927";
            // markbtn.textContent="UnMark"
        }
        document.getElementsByClassName("markbtn")[questionNum].style.color = "white";
        questionNum++;

        if (markedbtn[questionNum] === 1) {
            markbtn.textContent = "UnMark";
        }
        else {
            markbtn.textContent = "🏴 Mark for Review";
        }

        prevbtn.style.display = "inline-block"
        prevbtn.disabled = false;

        if (questionNum === quizQuestions.length - 1) {
            nextbtn.disabled = true;
            nextbtn.style.display = "none"

            submitbtn.style.display = "block";

            submitbtn.disabled = false;



        }

        questionbtn.textContent = questionNum + 1;
        document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "white"
        document.getElementsByClassName("markbtn")[questionNum].style.color = "#667eea";


        question.textContent = quizQuestions[numbers[questionNum]].question;

        for (i = 0; i < optionsText.length; i++) {

            optionsText[i].textContent = quizQuestions[numbers[questionNum]].options[i]

            optionsInput[i].value = quizQuestions[numbers[questionNum]].options[i]

        }

        if (answer[questionNum]) {

            for (i = 0; i < optionsInput.length; i++) {

                if (answer[questionNum] === optionsInput[i].value) {
                    optionsInput[i].checked = true;
                }

            }

        }
        else {
            var radios = document.querySelectorAll('input[name="answers"]')
            radios.forEach(radio => {
                radio.checked = false;
            });
        }

        // if (document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor == "rgb(229, 168, 32)") {
        //     markbtn.textContent = 'Unmark';
        // }
        // else {
        //     markbtn.textContent = 'Mark';
        // }
    }



    prevbtn.onclick = function () {

        // document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "rgba(255, 255, 255, 0.3)";

        if (!answer[questionNum]) {
            answer[questionNum] = null;
            // document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor="rgba(255, 255, 255, 0.3)";
            // document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor="red";
            document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "rgba(255, 255, 255, 0.3)"; // unanswerd

        }
        else {
            document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "lightgreen";

        }

        if (markedbtn[questionNum] === 1) {
            document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "#FDB927";
        }

        document.getElementsByClassName("markbtn")[questionNum].style.color = "white";
        questionNum--;


        if (markedbtn[questionNum] === 1) {
            markbtn.textContent = "UnMark";
        }
        else {
            markbtn.textContent = "🏴 Mark for Review";
        }

        if (questionNum === 0) {
            this.disabled = true;
            // this.style.display = 'none';
        }

        if (questionNum === quizQuestions.length - 2) {
            nextbtn.disabled = false;
            nextbtn.style.display = 'inline-block'

            submitbtn.style.display = "none";

            submitbtn.disabled = true;



        }

        questionbtn.textContent = questionNum + 1;
        document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "white"
        document.getElementsByClassName("markbtn")[questionNum].style.color = "#667eea";

        question.textContent = quizQuestions[numbers[questionNum]].question;
        for (i = 0; i < optionsText.length; i++) {

            optionsText[i].textContent = quizQuestions[numbers[questionNum]].options[i]

            optionsInput[i].value = quizQuestions[numbers[questionNum]].options[i]
            optionsInput[i].checked = false;
            if (answer[questionNum] === optionsInput[i].value) {
                optionsInput[i].checked = true;
            }
        }
        // if (document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor == "rgb(229, 168, 32)") {
        //     markbtn.textContent = 'Unmark';
        // }
        // else {
        //     markbtn.textContent = 'Mark';
        // }

    }

    function Mark() {
        var newBtn = document.getElementsByClassName("markbtn")[questionNum];
        // console.log(document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor);

        // if (document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor == "rgb(229, 168, 32)") {

        //     newBtn.style.backgroundColor = 'rgba(255, 255, 255, 0.2)';
        //     markbtn.textContent = 'Mark';
        //     if (answer[questionNum])
        //         newBtn.style.color = 'lightgreen';
        //     else
        //         newBtn.style.color = 'white';
        //     return;
        // }
        // newBtn.style.backgroundColor = "#e5a820";


        if (markedbtn[questionNum] === 1) {

            markedbtn[questionNum] = 0;
            markbtn.textContent = "🏴 Mark for Review";
        }
        else {

            markedbtn[questionNum] = 1;
            markbtn.textContent = "UnMark";

        }


    }

    function GoToQuestion(e) {
        if (e.target.textContent != quizQuestions.length) {
            nextbtn.disabled = false;
            nextbtn.style.display = "inline-block";
            submitbtn.disabled = true;
            submitbtn.style.display = "none"
        }

        else {
            nextbtn.disabled = true;
            nextbtn.style.display = "none"
            submitbtn.disabled = false;
            submitbtn.style.display = "inline-block"
        }


        if (e.target.textContent != '1') {
            prevbtn.style.display = "inline-block";
            prevbtn.disabled = false;
        }
        else {
            // prevbtn.style.display = "none";
            prevbtn.disabled = true;
        }


        if (!answer[questionNum]) {
            answer[questionNum] = null;
            // document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor="rgba(255, 255, 255, 0.3)";
            // document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor="red";
            document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "rgba(255, 255, 255, 0.3)"; // unanswerd

        }
        else {
            document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "lightgreen";

        }

        if (markedbtn[questionNum] === 1) {
            document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "#FDB927";
        }
        document.getElementsByClassName("markbtn")[questionNum].style.color = "white";

        questionNum = e.target.textContent - 1;


        if (markedbtn[questionNum] === 1) {
            markbtn.textContent = "UnMark";
        }
        else {
            markbtn.textContent = "🏴 Mark for Review";
        }




        document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor = "white"
        document.getElementsByClassName("markbtn")[questionNum].style.color = "#667eea";

        questionbtn.textContent = questionNum + 1;

        question.textContent = quizQuestions[numbers[questionNum]].question;

        for (i = 0; i < optionsText.length; i++) {

            optionsText[i].textContent = quizQuestions[numbers[questionNum]].options[i]

            optionsInput[i].value = quizQuestions[numbers[questionNum]].options[i]

        }


        if (answer[questionNum]) {

            for (i = 0; i < optionsInput.length; i++) {

                if (answer[questionNum] === optionsInput[i].value) {
                    optionsInput[i].checked = true;
                }

            }

        }
        else {

            var radios = document.querySelectorAll('input[name="answers"]')
            radios.forEach(radio => {
                radio.checked = false;
            });
        }


        // if (document.getElementsByClassName("markbtn")[questionNum].style.backgroundColor == "rgb(229, 168, 32)") {
        //     markbtn.textContent = 'Unmark';
        // }
        // else {
        //     markbtn.textContent = 'Mark';
        // }
    }

    function Submit() {
        var flag = true;
        // result = 0;
        for (var i = 0; i < numbers.length; i++) {
            if (answer[i] == undefined) {
                // var newBtn = document.getElementsByClassName("markbtn")[i];
                // newBtn.style.color = "red";
                flag = false;
                break;
            }
            else {
                try {
                    console.log(answer[i], '==', quizQuestions[numbers[i]].answer.valueOf(), (answer[i] == quizQuestions[numbers[i]].answer.valueOf()));

                    if (answer[i] == quizQuestions[numbers[i]].answer.valueOf()) {
                        result++;
                    }
                }
                catch (e) {
                    console.log('error');
                }
            }
        }
        if (flag) {
            sessionStorage.setItem("Result", result);
            console.log("Congrats You've finished the exam");
            window.location.replace('http://127.0.0.1:5500/Result/result.html')
        }
        else {
            console.log('Exam not finished');
            showMessage();

        }
    }



    var overlay = document.createElement("div");
    overlay.style.display = "none";
    overlay.className = "time-up-overlay";

    overlay.innerHTML = `
    <div class="time-up-card">
    <h2>Exam Not Finished</h2>
    <p>You still have unanswered questions. Please complete the exam before submission.</p>
    <button class="continueExam" >Continue Exam</button>
    </div>
    `;
    document.body.appendChild(overlay);

    var ContinueExam = document.getElementsByClassName('continueExam')[0];
    // console.log(ContinueExam);
    var containerDiv = document.getElementsByClassName('time-up-overlay')[0];

    ContinueExam.onclick = function () {

        containerDiv.style.display = "none";

    }

    function showMessage() {

        overlay.style.display = "flex";
    }

// }
