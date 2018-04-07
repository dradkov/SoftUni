function attachEvents() {

    $('#btnLoadTowns').on('click', townInfo)

    function townInfo() {

        let townsData = $('#towns').val().split(',')
            .map(t => ({
                name: t.trim()
            }))
            .filter(t => t.name != "")

        loadTowns(townsData)

    }

    async function loadTowns(towns) {

        let source = await $.get('listTemplate.hbs')
        let compile = Handlebars.compile(source)
        let data = compile({
            towns
        })

        $('#root').empty()
        $('#root').append(data)

    }
}