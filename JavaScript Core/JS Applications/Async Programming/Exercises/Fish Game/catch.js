function attachEvents() {

    $('.add').on('click', addData)
    $('.load').on('click', loadData)
    $('.update').on('click', updateData)
    $('.delete').on('click', deleteData)


    let baseUrl = "https://baas.kinvey.com/appdata/kid_rkdtrTw9M/biggestCatches"
    const username = 'mik'
    const password = '123'
    const autorization = {
        'Authorization': 'Basic ' + btoa(username + ':' + password)
    }

    let addForm = $('#addForm')
    let angler = addForm.find('.angler') //.val()
    let weight = addForm.find('.weight') //.val()
    let species = addForm.find('.species') //.val()
    let location = addForm.find('.location') //.val()
    let bait = addForm.find('.bait') //.val()
    let captureTime = addForm.find('.captureTime') //.val()

    let catches = $('#catches')


    function addData() {

        let dataCatch = JSON.stringify({
            angler: angler.val(),
            weight: Number(weight.val()),
            species: species.val(),
            location: location.val(),
            bait: bait.val(),
            captureTime: Number(captureTime.val())
        })


        $.ajax({
            url: baseUrl,
            method: "Post",
            data: dataCatch,
            contentType: "application/json",
            dataType: "json",
            headers: autorization,
            success: loadData,
            error: handleError
        })

    }

    function loadData() {

        $.ajax({
            url: baseUrl,
            method: "GET",
            headers: autorization,
            success: display,
            error: handleError
        })

        function display(data) {

            catches.empty();

            for (const el of data) {

                let newCatch = $(`<div class="catch" data-id="${el._id}"> </div>`)
                newCatch.append($('<label>Angler</label>'))
                    .append($(`<input type="text" class="angler" value="${el.angler}"/>`))
                    .append($('<label>Weight</label>'))
                    .append($(`<input type="number" class="weight" value="${el.weight}"/>`))
                    .append($('<label>Species</label>'))
                    .append($(`<input type="text" class="species" value="${el.species}"/>`))
                    .append($('<label>Location</label>'))
                    .append($(`<input type="text" class="location" value="${el.location}"/>`))
                    .append($('<label>Bait</label>'))
                    .append($(`<input type="text" class="bait" value="${el.bait}"/>`))
                    .append($('<label>Capture Time</label>'))
                    .append($(`<input type="number" class="captureTime" value="${el.captureTime}"/>`))
                    .append($('<button class="update">Update</button>').click(updateData))
                    .append($('<button class="delete">Delete</button>').click(deleteData))
                catches.append(newCatch);
            }
        }
    }

    function updateData() { 

        let catchId = $(this).parent().attr('data-id');
        let catchEl = $(this).parent();
        let newData = createNewCatch(catchEl)

        $.ajax({
            url:baseUrl+`/${catchId}`,
            method: "PUT",
            data: newData,
            contentType: "application/json",
            dataType: "json",
            headers: autorization,
            success: loadData,
            error: handleError
        })
    }

    function deleteData() {
        let catchId = $(this).parent().attr('data-id');
        $.ajax({
            url:baseUrl+`/${catchId}`,
            method: "DELETE",
            headers: autorization,
            success: loadData,
            error: handleError
        })
    }

    function handleError(err) {
        console.log(err)
    }

    function createNewCatch(data) {

        return JSON.stringify({
            angler: data.find('.angler').val(),
            weight: Number(data.find('.weight').val()),
            species: data.find('.species').val(),
            location: data.find('.location').val(),
            bait: data.find('.bait').val(),
            captureTime: Number(data.find('.captureTime').val())
        })
    }

    function request(method, endpoint, data) {
        return $.ajax({
            method: method,
            url: baseUrl + endpoint,
            headers: authHeader,
            data: JSON.stringify(data)
        })
    }

}