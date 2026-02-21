
fetch("https://jsonplaceholder.typicode.com/users")

    .then(function (response) {
        

        console.log(response);
        return response.json();
    })
    
    .then(function (users) {
     
        console.log(users);
        displayUsers(users);
    })

    .catch(function (error) {
     
        console.log("Error:", error);
    });

function displayUsers(users) {
    var container = document.getElementById("usersTabs");
    container.innerHTML = "";

    users.forEach(function (user) {
        var btn = document.createElement("button");
        btn.innerText = user.username;

      
        btn.onclick = function () {
            loadPosts(user.id);
        };

        container.appendChild(btn);
    });
}

async function loadPosts(userId) {
    try {
        var response = await fetch(
            "https://jsonplaceholder.typicode.com/posts?userId=" + userId
        );

        var posts = await response.json();

        displayPosts(posts);

    } catch (error) {
        console.log("Error loading posts", error);
    }
}
function displayPosts(posts) {
    var list = document.getElementById("postsList");
    list.innerHTML = "";

    posts.forEach(function (post) {
        var li = document.createElement("li");
        li.innerText = post.title;
        list.appendChild(li);
    });
}
