// var result = prompt("Enter your name:");

// for(var i = 1 ; i < 6; i++) {

//     document.write(`<h${i}> ${result}</h${i}>`)
// }


// ---------------------------------------------------------------------------------

// var sum = 0;
// var input;
// var num;

// do {
//     input = prompt("Enter a number :");
    
    
// //   if (input === "") {
// //         alert("Input cancelled. Current sum: " + sum);
// //         break;
// //     }

//     if (input === null) {
//         alert("Input cancelled. Current sum: " + sum);
//         break;
//     }
    
//     num = Number(input);
    
    
//     if (isNaN(num) ) {
//         alert("Please enter a valid number.");
//         continue;
//     }
    
    
//     if (num === 0) {
//         alert("You entered 0. Stopping...");
//         break;
//     }
    
    
//     sum += num;
    
    
//     if (sum > 100) {
//         alert("Sum exceeded 100. Stopping...");
//         break;
//     }
    

//     alert("Current sum: " + sum);
    
// } while (sum <= 100);

// // sum-= num;

// document.write("Total sum of entered values: " + sum);

// ----------------------------------------------------------------------------------


var name1 ;


do {
    name1 = prompt("Enter your name:");

    while(!isNaN(name1) || !name1 ) 
    {

        name1 = prompt("invalid name : Enter your name again:");        
    }

} while (!name1);


var birthyear = null;

do {
    var input = prompt("Enter your birth year:");

    if (input === null) {
        alert("You cancelled. Please enter your birth year.");
        continue;
    }

    
    birthyear = Number(input);

    while( !birthyear || isNaN(birthyear)  ) 
    {

        birthyear = prompt("invalid birthyear : Enter your birthyear again:");        
    }


    if (isNaN(birthyear) ||  birthyear >= 2010) {
        alert("Please enter a valid year ");
        birthyear = null;
    }

} while (birthyear === null);



var age = 2025 - birthyear;


document.write("Name: " + name1 + "<br>");
document.write("Birth year: " + birthyear + "<br>");
document.write("Age: " + age);
