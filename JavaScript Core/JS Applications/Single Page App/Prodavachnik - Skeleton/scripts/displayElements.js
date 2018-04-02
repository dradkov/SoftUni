function showView(viewName) {
    $('main > section').hide() // Hide all views
    $('#' + viewName).show() // Show the selected view only
}

function showHideMenuLinks() {
    $('#linkHome').show()
    if (sessionStorage.getItem('authToken') === null) {

        $('#linkLogin').show()
        $('#linkRegister').show()
        $('#linkListAds').hide()
        $('#linkCreateAd').hide()
        $('#linkLogout').hide()
        $('#loggedInUser').text('')
       
    } else {
        
        $('#linkLogin').hide()
        $('#linkRegister').hide()
        $('#linkListAds').show()
        $('#linkCreateAd').show()
        $('#linkLogout').show()
        $('#loggedInUser').text(`Welcom ${sessionStorage.getItem('username')} !`)
    }

}

function showHomeView() {
    showView('viewHome')
}

function showLoginView() {

    showView('viewLogin')
    $('#formLogin').trigger('reset')
}

function showRegisterView() {

    showView('viewRegister')
    $('#formRegister').trigger('reset')
}
function showInfo(message) {
    let infoBox = $('#infoBox')
    infoBox.text(message)
    infoBox.show()
    setTimeout(function() {
        $('#infoBox').fadeOut()
    }, 3000)
}

function showError(errorMsg) {
    let errorBox = $('#errorBox')
    errorBox.text("Error: " + errorMsg)
    errorBox.show()
}
function showCreateView() {
    showView('viewCreateAd')
}

function showEditView() {
    showView('viewEditAd')
}
