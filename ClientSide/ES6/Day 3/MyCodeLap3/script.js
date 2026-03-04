const usercontainer = document.getElementById('users')
const Postscontainer = document.getElementById('Posts')
let btn = document.getElementById('btnusers');

let userbody = "";
let postbody = "";


async function getUsers() {

    let response = await fetch("https://jsonplaceholder.typicode.com/users");
    let data = await response.json();
    console.log(data.length);

    data.forEach(element => {
        userbody += `
            <div>
            <button class="userpostbtn" value="${element.id}">${element.name}</button>
            </div>
            `

    });

    usercontainer.innerHTML = userbody;
    let postbtn = document.querySelectorAll('.userpostbtn');
    console.log("test")

    postbtn.forEach(btn => btn.addEventListener("click", function () {
        console.log("btnEvent");
        getUserPosts(parseInt(btn.value));
    }));



}

async function getUserPosts(userId) {


    postbody = "";

    let response = await fetch(`https://jsonplaceholder.typicode.com/posts?userId=${userId}`);
    let data = await response.json();
    console.log("=================");
    console.log(data);
    console.log("================");

    data.forEach(element => {
        postbody += `
            <div class="pooosts">
            <p>${element.body}</p>
            </div>
            `

    });

    Postscontainer.innerHTML = postbody;

}

btn.onclick = (function () {
    getUsers();
});

