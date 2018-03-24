function attachEvents() {

    const mainURL = "https://phonebook-exercise-2d7a0.firebaseio.com/phonebook/"
    $('#btnLoad').on('click', load)
    $('#btnCreate').on('click', create)

    function load() {
        $("#phonebook").empty()
        $.ajax({
            url: mainURL + ".json",
            method: "GET",
            success: displayData,
            error: NotFound

        })

        function displayData(data) {
            let phonebook = $('#phonebook')

            for (const key in data) {
                let info = data[key]

                let li = $(`<li>${info.person}: ${info.phone}</li>`).append($('<button>[Delete]</button>').click(() => {

                    $.ajax({
                        url: mainURL + `${key}.json`,
                        method: "DELETE",
                        success: () => $(li).remove(),
                        error: NotFound
                    })
                }))
                phonebook.append(li)

            }
        }
    }

    function create() {

        let person = $('#person') //.val()
        let phone = $('#phone') //.val()

        $('#btnCreate').prop('disabled', true);
        let dataPost = JSON.stringify({
            person: person.val(),
            phone: phone.val()
        })

        $.ajax({
            url: mainURL + ".json",
            method: "POST",
            data: dataPost,
            success: load,
            error: NotFound

        })
        person.val('')
        phone.val('')
    }

    function NotFound(err) {
        console.log(err);
    }
}