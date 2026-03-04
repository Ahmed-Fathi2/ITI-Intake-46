
history.pushState(null, null, location.href);
window.onpopstate = function () {
    history.go(1);
};
var tableBody = document.getElementById('tableBody');
var tableBodyHtml = "";

var bookLibrary = JSON.parse(localStorage.getItem("Books"));
console.log(bookLibrary[0].bookName);
var BookName = "";
var Price = "";
var Author = "";
var Email = "";
loadBooks();
var editButtons = document.querySelectorAll('.edit-btn');
var deleteButtons = document.querySelectorAll('.delete-btn');


editButtons.forEach(btn => btn.addEventListener("click", function () {

    var key = parseInt(this.value); // book id
    console.log(key)

    console.log(bookLibrary[0].id)

    for (var i = 0; i < bookLibrary.length; i++) {


        if (bookLibrary[i].id == key) {

            BookName = bookLibrary[i].bookName;
            console.log(BookName)
            Price = bookLibrary[i].price;
            console.log(Price)
            Author = bookLibrary[i].author.authorName;
            console.log(Author)
            Email = bookLibrary[i].author.authorEmail;
            console.log(Email)
            console.log("=====================================")
            break;
        }
    }


    var row = this.closest("tr");
    var cells = row.querySelectorAll('td');


    cells[0].innerHTML = `<input  class="update-inputs" type="text" autofocus value="${BookName}">`
    cells[1].innerHTML = `<input  class="update-inputs" type="number" value="${Price}">`
    cells[2].innerHTML = `<input  class="update-inputs" type="text" value="${Author}">`
    cells[3].innerHTML = `<input  class="update-inputs"type="text" value="${Email}">`
    cells[4].innerHTML = `   <div class ="actions">
                             <button class="save-btn" value="${key}"> Save</button>
                             <button class="cancel-btn" value="${key}">Cancel</button>
                             </div>
            `

    var saveButtons = document.querySelectorAll('.save-btn');
    var cancelButtons = document.querySelectorAll('.cancel-btn');

    saveButtons.forEach(btn => btn.addEventListener("click", function () {

        var bookId = parseInt(this.value);
        console.log("**************************")
        console.log(bookId)

        var rowSaveButtons = this.closest("tr");
        var inputData = rowSaveButtons.querySelectorAll('input');

        console.log(inputData[0].value);
        console.log(inputData[1].value);
        for (var i = 0; i < bookLibrary.length; i++) {

            if (bookLibrary[i].id === bookId) {
                bookLibrary[i].bookName = inputData[0].value;
                bookLibrary[i].price = inputData[1].value;
                bookLibrary[i].author.authorName = inputData[2].value;
                bookLibrary[i].author.authorEmail = inputData[3].value;
                break;
            }
        }


        localStorage.setItem("Books", JSON.stringify(bookLibrary));

        console.log(JSON.parse(localStorage.getItem("Books")))

        window.location.reload();
    }));

    cancelButtons.forEach(btn => btn.addEventListener("click", function () {
        window.location.reload();
    }));



}))


deleteButtons.forEach(btn => btn.addEventListener("click", function () {
    var idToDelete = this.value;
    for (var i = 0; i < bookLibrary.length; i++) {

        if (bookLibrary[i].id == idToDelete) {

            bookLibrary.splice(i, 1);
            break;
        }
    }

    localStorage.setItem("Books", JSON.stringify(bookLibrary));   
    this.closest("tr").remove();

}))

function loadBooks() {
    for (var i = 0; i < bookLibrary.length; i++) {

        BookName = bookLibrary[i].bookName;
        Price = bookLibrary[i].price;
        Author = bookLibrary[i].author.authorName;
        Email = bookLibrary[i].author.authorEmail;


        tableBodyHtml += `<tr>
                <td>${BookName}</td>
                <td>${Price}</td>
                <td>${Author}</td>
                <td>${Email}</td>
                <td> 
                <div class ="actions">
                <button class="edit-btn" value="${bookLibrary[i].id}"> Update</button>
                <button class="delete-btn" value="${bookLibrary[i].id}">Delete</button>
                </div>
                </td>
             </tr>`
        // }
    }
    tableBody.innerHTML = tableBodyHtml;
}


