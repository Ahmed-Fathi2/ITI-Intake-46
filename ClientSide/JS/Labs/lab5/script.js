// function GetDayName(_date) {

//     var daysOfWeek = [
//         "Sunday",
//         "Monday",
//         "Tuesday",
//         "Wednesday",
//         "Thursday",
//         "Friday",
//         "Saturday"

//     ];

//     dayIndex = _date.getDay()

//     return daysOfWeek[dayIndex];



// }



//   var input;
//   var date;

// do {
//     input = prompt("Enter date");

//     if (!input || input.trim() === "") {
//         alert("Input cannot be empty");
//         continue;
//     }

//     date = new Date(input);

//     if (isNaN(date.getTime())) {
//         alert("Invalid date, try again!");
//         continue;
//     }


//    console.log( GetDayName(date));

// } while ( !input || input.trim() === ""||isNaN(date.getTime()));








// function Add(x, y) {


//     if (arguments.length !== 2)
//         throw "must pass only 2 parameters"

//     return x + y

// }

// document.writeln(Add(2, 3, 5))


// function AddGroup() {

//     var sum = 0;
//     for (i = 0; i < arguments.length; i++) {
//         sum += arguments[i];

//     }
//     return sum;
// }

// document.writeln(AddGroup(2, 5, 6, 4, 8))


function Reverse() {


    for (i = arguments.length - 1; i >= 0; i--) {

        console.log(arguments[i]);
    }

}
Reverse(2, 5, 6, 4, 8);





