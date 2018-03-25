function attachEvents() {
    //Application settings
    const baseUrl = 'https://baas.kinvey.com/appdata/kid_B1La2zrcG/';
    const username = 'mit';
    const password = '123';


    //Attach event listeners
    $('#btnLoadPosts').click(LoadPosts);
    $('#btnViewPost').click(viewPost);

    //DOM elements
    const optionList = $('#posts');
    const postTitle = $('#post-title');
    const postBody = $('#post-body');
    const commentsList = $('#post-comments');

    function request(endpoint) {
       return $.ajax({
            url: baseUrl + endpoint,
            headers: {
                'Authorization': 'Basic ' + btoa(username + ':' + password)
            }
        });

    }

    function LoadPosts() {
        // Request all posts from db and display inside select
        request('posts')
        .then(fillSelect)
        .catch(handleError);
    
        function fillSelect(data) {
            optionList.empty();
            for (let post of data) {
                $('<option>')
                    .text(post.title)
                    .val(post._id)
                    .appendTo(optionList)
            }
        }
    }

    function viewPost() {
        // Request only selected post from db and all associated comments
        let postId = optionList.find('option:selected').val();
        request('posts/' + postId)
            .then(requestComments)
            .then(displayPostAndComments)
            .catch(handleError);


        function requestComments(data) {
            return new Promise(function (resolve, reject) {
               request(`comments/?query={"postId":"${postId}"}`)
               .then((response) => resolve([data, response]));
            });

        }

        //Display post body and commenrs
        function displayPostAndComments([data, comments]) {
            postTitle.text(data.title);
            postBody.text(data.body);
            commentsList.empty();
            for (const com of comments) {
                commentsList.append($('<li>').text(com.text));
            }
            
        }
    }

    function handleError(reason) {
        console.warn(error)
    }
}