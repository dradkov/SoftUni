const BASE_URL = 'https://baas.kinvey.com/'
const APP_KEY = 'kid_rJ2546cqz'
const APP_SECRET = '0ecbf8817dcc4873809455521c48cddf'
const AUTH_HEADERS = {
    'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)
}


function logIn() {
    let username = $('#formRegister input[name="username"]').val()
    let password = $('#formRegister input[name="passwd"]').val()
    let dataPost = {
        username,
        password
    }

    $.ajax({
        url: BASE_URL + 'user/' + APP_KEY + '/login',
        method: "POST",
        headers: AUTH_HEADERS,
        data: dataPost,
    }).then(function (data) {
        signInUser(data, 'Login Successfull')

    }).catch(errorHandling)
}


function registerUser() {
    let username = $('#formRegister input[name="username"]').val()
    let password = $('#formRegister input[name="passwd"]').val()
    let dataPost = {
        username,
        password
    }

    $.ajax({
        url: BASE_URL + 'user/' + APP_KEY + '/',
        method: "POST",
        headers: AUTH_HEADERS,
        data: dataPost
    }).then(function (data) {
        signInUser(data, "Registration done")

    }).catch(errorHandling)

}

function signInUser(data, msg) {

    sessionStorage.setItem('username', data.username)
    sessionStorage.setItem('authToken', data._kmd.authtoken)
    sessionStorage.setItem('userId', data._id)

    showHideMenuLinks()
    showHomeView()
    showInfo(msg)

}

function logout() {

    sessionStorage.clear()
    showHideMenuLinks()
    showHomeView()

}

function createAdd() {

    let title = $('#formCreateAd input[name="title"]').val()
    let description = $('#formCreateAd textarea[name="description"]').val()
    let dateOfPublish = $('#formCreateAd input[name="datePublished"]').val()
    let price = Number($('#formCreateAd input[name="price"]').val()).toFixed(2)
    let image = $('#formCreateAd input[name="image"]').val()
    let publisher = sessionStorage.getItem('username')

    let dataPost = {
        title,
        dateOfPublish,
        description,
        publisher,
        price,
        image
    }

    let currentHeader = {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    }

    $.ajax({
        url: BASE_URL + 'appdata/' + APP_KEY + '/advers',
        method: "POST",
        headers: currentHeader,
        data: dataPost
    }).then(function (data) {
        listAdds()
        showInfo("Advertisement created")
    }).catch(errorHandling)


}

function listAdds() {


    let currentHeader = {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    }

    $.ajax({
        url: BASE_URL + 'appdata/' + APP_KEY + '/advers',
        method: "GET",
        headers: currentHeader,
    }).then(function (data) {
        showView('viewAds')
        displayAdvers(data.reverse())
    }).catch(errorHandling)
}

function displayAdvers(advers) {


    let table = $('#ads > table')
    table.find('tr').each((i, el) => {
        if (i > 0) {
            $(el).remove()
        }

    })


    for (let i = 0; i < advers.length; i++) {
        let tr = $('<tr>')

        table.append(

            $(tr).append($(`<td>${advers[i].title}</td>`))
            .append($(`<td>${advers[i].description}</td>`))
            .append($(`<td>${advers[i].publisher}</td>`))
            .append($(`<td>${advers[i].dateOfPublish}</td>`))
            .append($(`<td>${advers[i].price}</td>`))
            .append($(`<td><img src="${advers[i].imageUrl}"></td>`))


        )
        if (advers[i]._acl.creator === sessionStorage.getItem('userId')) {

            let lastThElement = table.find('tr').find('th').last().text()

            if (lastThElement != 'Action') {
                table.find('tr').first().append('<th>Action</th>')
            }


            $(tr).append(
                $('<td>').append(
                    $(`<a href="#">[Read More]</a>`).on('click', function () {
                        displaySingleAdv(advers[i])
                    })
                ).append(
                    $(`<a href="#">[Edit]</a>`).on('click', function () {
                        currentAdv(advers[i])
                    })
                ).append(
                    $(`<a href="#">[Delete]</a>`).on('click', function () {
                        deleteAdver(advers[i])
                    })
                )
            )


        }
    }
}

function displaySingleAdv(adv) {
    let ad = adv.title

    let view = $('#detailAdv')
    view.empty()

    let advert = $('<div>').append(
        $('<br>'),
        $(`<img src="${adv.image}" alt="Image"> width="50" height="50"`),
        $('<br>'),
        $('<label>').text('Title: '),
        $('<h1>').text(adv.title),
        $('<label>').text('Description: '),
        $('<p>').text(adv.description),
        $('<label>').text('Publisher: '),
        $('<div>').text(adv.publisher),
        $('<label>').text('Date: '),
        $('<div>').text(adv.dateOfPublish)
    )
    view.append(advert)
    showView('viewDetailedAd')
}


function currentAdv(adv) {

    showView("viewEditAd")

    $('#formEditAd input[name=id]').val(adv._id)
    $('#formEditAd input[name=title]').val(adv.title)
    $('#formEditAd input[name=publisher]').val(adv.publisher)
    $('#formEditAd input[name=datePublished]').val(adv.dateOfPublish)
    $('#formEditAd input[name=price]').val(adv.price)
    $('#formEditAd input[name=image]').val(adv.image)
    $('#formEditAd textarea[name=description]').val(adv.description)


}

function editAdv() {

    let id = $('#formEditAd input[name="id"]').val()
    let title = $('#formEditAd input[name="title"]').val()
    let description = $('#formEditAd textarea[name="description"]').val()
    let dateOfPublish = $('#formEditAd input[name="datePublished"]').val()
    let price = Number($('#formEditAd input[name="price"]').val()).toFixed(2)
    let image = $('#formEditAd input[name=image]').val()
    let publisher = sessionStorage.getItem('username')

    let dataPost = {
        id,
        title,
        dateOfPublish,
        description,
        publisher,
        price,
        image
    }

    let currentHeader = {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    }

    $.ajax({
        url: BASE_URL + 'appdata/' + APP_KEY + '/advers/' + id,
        method: "PUT",
        headers: currentHeader,
        data: dataPost
    }).then(function (data) {
        listAdds()
        showInfo("Edit success")
    }).catch(errorHandling)
}

function deleteAdver(adv) {
    let currentHeader = {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    }

    $.ajax({
        url: BASE_URL + 'appdata/' + APP_KEY + '/advers/' + adv._id,
        method: "DELETE",
        headers: currentHeader
    }).then(function (data) {
        listAdds()
        showInfo("Deleted Advertisement")
    })
}

function errorHandling(response) {

    console.log(response)
    let errorMsg = JSON.stringify(response)
    if (response.readyState === 0)
        errorMsg = "Cannot connect due to network error."
    if (response.responseJSON && response.responseJSON.description)
        errorMsg = response.responseJSON.description
    showError(errorMsg)
}