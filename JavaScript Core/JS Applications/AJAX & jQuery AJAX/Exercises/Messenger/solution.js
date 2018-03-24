function attachEvents() {

    $('#submit').on('click', submit)
    $('#refresh').on('click', refresh)

    function submit() {

        let author = $('#author')//.val()
        let content =  $('#content')//.val()

        let dataPost = JSON.stringify({
            author: author.val(),
            content: content.val(),
            timestamp : Date.now()
        })

        $.ajax({
            url: "https://messenger-exercise-a3f54.firebaseio.com/messenger/.json",
            method: "POST",
            data: dataPost,
            error: NotFound

        })
        author.val('')
        content.val('')
    }

    function refresh() {
        $.ajax({
            url: "https://messenger-exercise-a3f54.firebaseio.com/messenger/.json",
            method: "GET",
            success: displayInfo,
            error: NotFound

        })

        function displayInfo(data) {

            let messages = $('#messages')

            for (const key in data) {
                let info = data[key]
                messages.append(`${info.author}: ${info.content}\n`)
            }
        }
    }
    function NotFound(err) {
        console.log(err)
    }

}