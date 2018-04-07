$(() => {
    let details
    let data

    async function loadFiles() {
        let contacts = await $.get('templates/contacts.hbs')
        let contactsTemplate = Handlebars.compile(contacts)

        details = await $.get('templates/details.hbs')
        data = await $.get('data.json')

        let obj = {
            contacts: data
        }
        let html = contactsTemplate(obj)
        $('#list').append(html)
        attachEvents()
    }
    loadFiles()
    function attachEvents() {
        $('.contact').on('click', function () {
            loadDetails($(this).attr('data-id'))
        })
    }
    function loadDetails(index) {
        let detailsTemplate = Handlebars.compile(details)
        let htmlD = detailsTemplate(data[index])
        $('#details').empty()
        $('#details').append(htmlD)
    }
});