//var posts = [];

function PostModel(id, username, userTag, postedAt, text) {
    this.id = id;
    this.username = username;
    this.userTag = userTag;
    this.postedAt = postedAt;
    this.text = text;
}

function PostCreateModel(username, userTag, text) {
    this.username = username;
    this.userTag = userTag;
    this.text = text;
}

$(function() {
    /*
    posts.push(new Post("Marius", "mar_ius", "14.05.2017 15.31", "Test-Text (jo)"));
    posts.push(new Post("Klaus", "lausklaus01", "16.03.2016 09.15", "I bims, 1 Klaus"));
    posts.push(new Post("Hansi", "hansi35", "08.10.2016 20:16", "Langer Text Text Langer Text Langer Text Text Langer Text Langer Text Text Langer Text Langer Text Text Langer Text Langer Text Text Langer Text Langer Text Text Langer Text"));
    */
    
    $("#sendPost").click(processForm);

   getListOfPosts();
});

function getListOfPosts() {

    var settings = {
        method: "get",
        url:"http://localhost:5000/api/posts",
        dataType: "json"
    };

    $.ajax(settings)
    .done(function(data) {
        reloadPosts(data);
    });
}

function postNewPost(post) {
    

    var settings = {
        headers: { 
            'Accept': 'application/json',
            'Content-Type': 'application/json' 
        },
        method: "post",
        url:"http://localhost:5000/api/posts",
        dataType: "json",
        data: JSON.stringify(post)
    };

    $.ajax(settings)
    .done(function() {
        getListOfPosts();
        $("#newPostForm").trigger("reset");
    });
}

function reloadPosts(posts) {
    var $postsContainer = $("#posts");

    $postsContainer.empty();

    posts.forEach(function(element) {
        if (element.text.length > 100) {
            element.text = element.text.substring(0, 100) + "...";
        }
        var template = `
            <div class="post">
                <img src="http://lorempixel.com/90/90/people" />
                <div class="content">
                    <span><b>${element.username}</b></span><span class="user-tag"> @${element.userTag}</span><span class="time">at ${element.postedAt}</span>
                    <p>
                    ${element.text}
                    </p>
                </div>
            </div>
            `;
        $postsContainer.append(template);
    }, this);
}

function processForm() {
    var fields = $("#newPostForm").serializeArray();
    
    var username = fields[0].value;
    var userTag = fields[1].value;
    var text = fields[2].value;

    var date = new Date();
    var dateString = `${date.getDate()}.${date.getMonth()}.${date.getFullYear()}, ${date.getHours()}:${date.getMinutes()}`;

    postNewPost(new PostCreateModel(username, userTag, text));
}