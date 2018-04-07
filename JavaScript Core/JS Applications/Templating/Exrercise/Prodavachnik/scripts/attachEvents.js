function attachEvents() {
    $("#linkHome").on('click', showHomeView)

    $("#linkLogin").on('click', showLoginView)
    $("#buttonLoginUser").on('click', logIn)

    $('#linkRegister').on('click',showRegisterView)
    $("#buttonRegisterUser").on('click', registerUser)

    $('#linkLogout').on('click',logout)

    $('#linkListAds').on('click',listAdds)

    $('#linkCreateAd').on('click',showCreateView)
    $('#buttonCreateAd').on('click',createAdd)


    $('#buttonEditAd').on('click',editAdv)

}