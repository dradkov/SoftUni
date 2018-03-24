const URL = "https://phonebook-lab-f231c.firebaseio.com/phonebook"

$('#btnLoad').on('click', loadData)
$('#btnCreate').on('click', postData)

function postData() {
    let name = $('#person')
    let phone = $('#phone')
    let dataPost = JSON.stringify({
        name: name.val(),
        phone: phone.val()
    })

    $.ajax({
        url: URL + ".json",
        method: "Post",
        data: dataPost,
        success: addSuccess,
        error: handleError
    })

    function addSuccess() {
        $('#output').text(`Person : ${$('#person').val()} with Phone Number ${$('#phone').val()} was added`)
        name.val('')
        phone.val('')
    }
}

function loadData() {

    $("#phonebook").empty()
    $.ajax({
        url: URL + ".json",
        method: "GET",
        success: handleSuccess,
        error: handleError
    })

    function handleSuccess(data) {

        let phone = $("#phonebook")

        for (const key in data) {

            let li = $(`<li>${data[key].name}: ${data[key].phone} </li>`)
                .append($('<a href="#">[Delete]</a>')
                    .click(function () {

                        $.ajax({
                            url: URL + "/" + ".json",
                            method: "DELETE",
                            success: () => $(li).remove(),
                            error: handleError
                        })
                    }))
            phone.append(li)

        }
    }

}

function handleError(err) {
    console.log(err);
}