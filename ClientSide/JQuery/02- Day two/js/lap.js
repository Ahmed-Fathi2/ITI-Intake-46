$(document).ready(function () {

    $("#load-all").click(function () {


        $.get("https://jsonplaceholder.typicode.com/posts", function (data) {

            var PostCard = "";

            data.forEach(function (post) {
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

            $("#posts-container").html(PostCard);
            $("#post-count").text(data.length);
        });

    });


    $("#load-user1").click(function () {

        $.get("https://jsonplaceholder.typicode.com/user/1/posts", function (data) {

            var PostCard = "";

            data.forEach(function (post) {
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

            $("#posts-container").html(PostCard);
            $("#post-count").text(data.length);
        });




    });



    $("#load-user2").click(function () {


        $.get("https://jsonplaceholder.typicode.com/user/2/posts", function (data) {

            var PostCard = "";

            data.forEach(function (post) {
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

            $("#posts-container").html(PostCard);
            $("#post-count").text(data.length);
        });




    });



});



