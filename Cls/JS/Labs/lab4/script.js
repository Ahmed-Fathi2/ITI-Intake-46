// do {

//     var flag = 0;
//     var test=0;
//     do {
//         var caseState = prompt("Do You  consider case of the entered string or not ? yes / no ");
//         if (caseState === null) {

//             var res = confirm("are yor sure to cancelle ? ")

//             if (res) {
//                 flag = 1;
//                 break;
//             }
//             else {
//                 caseState = "test";
//                 continue;
//             }
//         }


//     } while (caseState.trim() === "" || (caseState !== "yes" && caseState !== "no"))

//     if (flag === 1)
//         break;

//     do {
//         var word = prompt("enter the word :");
//         if (word === null) {
//             var res = confirm("are yor sure to cancelle ? ")
//             if (res) {
//                 flag = 1;
//                 break;
//             }
//         }


//     } while (word.trim() === "" || !isNaN(Number(word)) || /\d/.test(word))

//     if (flag === 1)
//         break;



//     if (caseState === "no") {
//         var splited = word.toUpperCase().split(" ");
        
//         for(i = 0 ; i<splited.length ; i++){

//            var reversed = splited[i].split("").reverse().join("");
           
//            if (reversed !== splited[i]) {
//                test=1;
//                break;
        
       
//         }
//     }
//        if (test===0) {
//                document.writeln("palindrome.");
//            }
//            else {
//             test=1;
//                document.writeln("Not palindrome.");
//            }
        
//     }

//     else {

    
//         var splited2 = word.split(" ");
        
//         for(i = 0 ; i<splited2.length ; i++){

//              var reversed = splited2[i].split("").reverse().join("");

//                 if (reversed !== splited2[i]) {
//                     test=1;
//                     break;
//                 }
//             }
//        if (test===0) {
//                      document.writeln("palindrome.");
//            }
//            else {
//             test=1;
//                document.writeln("Not palindrome.");
//            }

//     }


//     break;

// } while (true)


// ==================================================================================================================
// ==================================================================================================================


//  var flag = 0;
//     do {

//         do{
//       var str = prompt("enter string :");
//         if (str === null) {

//             var res = confirm("are yor sure to cancelle ? ")

//             if (res) {
//                 flag = 1;
//                 break;
//             }
//             else {
//                 str = "123";
//                 continue;
//             }
//         }
//     }while( str.trim() === "" || !isNaN(str) || /\d/.test(str))

        
//         if (flag === 1)
//             break;
        
//         var newstr= str.toLowerCase(); 
//         var count = 0;
//         for (i = 0; i < newstr.length; i++) {

//             if (newstr[i] === "e") {
//                 count++;
//             }
//         }
//         document.writeln(str + "<br/>");

//         document.write("number of letter e = " + count);

//         break;
//     } while(true)




// ==================================================================================================================
// ==================================================================================================================

// var flag = 0;

// do{
// do{

//     var raduis = prompt("enter the circule raduis :")
//         if (raduis === null) {

//             var res = confirm("are yor sure to cancelle ? ")

//             if (res) {
//                 flag = 1;
//                 break;
//             }
//             else {
//                 raduis = "test";
//                 continue;
//             }
//         }
//           if (Number(raduis) < 0) {
//             alert("cant enter negative");
//             raduis = "test";
//             continue;

//         }
//     }while( raduis.trim() === "" || isNaN(raduis) )


//       if (flag === 1)
//          break;


// var area = Math.pow(parseFloat(raduis), 2) * Math.PI

// alert("Total area of the circle is " + area);

// break;
// }while(true)

// ==================================================================================================================
// ==================================================================================================================

// var flag = 0;

// do {
//     do {

//         var num = prompt("enter the number :")
//         if (num === null) {

//             var res = confirm("are yor sure to cancelle ? ")

//             if (res) {
//                 flag = 1;
//                 break;
//             }
//             else {
//                 num = "test";
//                 continue;
//             }
//         }

//         if (Number(num) < 0) {
//             alert("cant enter negative");
//             num = "test";
//             continue;

//         }
//     } while (num.trim() === "" || isNaN(num))


//     if (flag === 1)
//         break;


//     var sqrtValue = Math.sqrt(parseFloat(num))

//     alert(`the squar root of ${num} is ${sqrtValue}`);

//     break;
// } while (true)




// ==================================================================================================================
// ==================================================================================================================
// do{
//     var arrsize = prompt("enter array size :");
//     if(arrsize<0)
//         alert("cant enter negative size for array")
// }while(arrsize<0);

// var arr = [];
// for (i = 0; i < parseInt(arrsize); i++) {

//     arr[i] = parseFloat(prompt(`enter the item of [${i}]`));
// }

// var addResult = arr[0];
// var multiResult = arr[0];
// var divResult = arr[0];


// for (i = 1; i < parseInt(arrsize); i++) {

//     addResult += arr[i]
//     multiResult *= arr[i]

//        if (arr[i] === 0) {
//         alert(` You cannot divide by zero at index [${i}]`);
//         divResult = "Undefined (division by zero)";
//         break;
//     }
//     divResult /= arr[i]

// }


// document.write(`additon answer is ${addResult} <br/>`);
// document.write(`multiply answer is ${multiResult} <br/>`);
// document.write(`division answer is ${divResult} <br/>`);


// ==================================================================================================================
// ==================================================================================================================

// var arr = [];

// for (i = 0; i < 5; i++) {
    
//     arr[i] = parseFloat(prompt(`enter the item of [${i}]`));
// }

// console.log("asc order is " + arr.sort((a, b) => a - b))
// console.log("desc order is " + arr.sort((a, b) => b - a))



// ==================================================================================================================
// ==================================================================================================================



// Evil olive
// Yo banana boy
// Taco cat
// Never odd or even


// do {

//     var flag = 0;
//     do {
//         var caseState = prompt("Do You  consider case of the entered string or not ? yes / no ");
//         if (caseState === null) {

//             var res = confirm("are yor sure to cancelle ? ")

//             if (res) {
//                 flag = 1;
//                 break;
//             }
//             else {
//                 caseState = "test";
//                 continue;
//             }
//         }


//     } while (caseState.trim() === "" || (caseState !== "yes" && caseState !== "no"))

//     if (flag === 1)
//         break;

//     do {
//         var word = prompt("enter the word :");
//         if (word === null) {
//             var res = confirm("are yor sure to cancelle ? ")
//             if (res) {
//                 flag = 1;
//                 break;
//             }
//         }


//     } while (word.trim() === "" || !isNaN(Number(word)) || /\d/.test(word))

//     if (flag === 1)
//         break;



//     if (caseState === "no") {
//         // var result = word.toUpperCase().split(" ").reverse().join(" ");
//         word = word.toLowerCase();

//         var cleaned = word.replace(/\s+/g, "");
//         var reversed = cleaned.split("").reverse().join("");

//         if (reversed === cleaned) {
//             document.writeln("palindrome.");
//         }
//         else {

//             document.writeln("Not palindrome.");
//         }

//     }

//     else {

//          var cleaned2 = word.replace(/\s+/g, "");
//         var reversed2 = cleaned2.split("").reverse().join("");
//         if (reversed2 === cleaned2) {
//             document.writeln("palindrome.");
//         }
//         else {

//             document.writeln("Not palindrome.");
//         }


//     }


//     break;

// } while (true)