
var loadAllBtn = document.getElementById('load-all');
var postscontainer = document.getElementById('posts-container');
var postcount = document.getElementById('post-count');


loadAllBtn.onclick = function () {
    var posts;
    var xhr = new XMLHttpRequest();
    console.log(xhr);
    xhr.open("get", "https://jsonplaceholder.typicode.com/posts");
    xhr.send();
    xhr.addEventListener("readystatechange", function () {
        if (xhr.readyState == 4 && xhr.status === 200) {

            posts = JSON.parse(xhr.response);
            PostUi(posts);

        }
    });
}

function PostUi(post) {
    var PostCard = "";

    post.forEach(function (post) {
        PostCard += `
                    <div class="post-card">
                        <div class="post-title">${post.title}</div>
                        <div class="post-body">${post.body}</div>
                        <div class="post-meta">
                            <span>Post ID: ${post.id}</span>
                            <span>User ID: ${post.userId}</span>
                        </div>
                    </div>
                `;
    });

    postscontainer.innerHTML = PostCard;
    postcount.textContent = post.length;
}