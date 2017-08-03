$(function() {
    getPosts();
    $("#sendPost").click(function() {
        var data = $("#newPostForm").serializeArray();
        var username = data[0].value;
        var userTag = data[1].value;
        var postText = data[2].value;

        postPost(username, userTag, postText);
    });
});


function getPosts() {
   var settings = {
        method: "get",
        url:"http://localhost:5000/api/posts",
        dataType: "json"
    };

    $.ajax(settings)
        .done(function(data) {
            showPosts(data);
        });
}

function postPost(username, userTag, postText) {
   var settings = {
        method: "post",
        url:"http://localhost:5000/api/posts",
        data: { username: username, userTag: userTag, postText: postText }
    };

    $.ajax(settings)
        .done(function() {
            $("#newPostForm").trigger("reset");
            getPosts();
        });
}


function showPosts(posts) {
    $("#posts").empty();
    posts.forEach(function(post) {
        var template = `
            <div class="post">
                    <img src="http://lorempixel.com/90/90/people" />
                    <div class="content">
                        <span><b>${post.username}</b></span><span class="user-tag"> @${post.userTag}</span><span class="time">at ${post.createdAt}</span>
                        <p>
                            ${post.postText}
                        </p>
                    </div>
                </div>`;
        $("#posts").append(template);
    });
}