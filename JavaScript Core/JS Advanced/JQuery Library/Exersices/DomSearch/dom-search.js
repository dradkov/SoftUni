function domSearch(selector, isCaseSensitive) {
 
    function addItem() {
        let li = $('<li>').addClass('list-item')
            .append($('<strong>')
                .append($('<a>').text('X').click(removeItem).addClass('button'))
                .append($(this).closest('div').find('input').val())
            )
        $('.items-list').append(li)
        $(this).closest('div').find('input').val('')
    }

    function showResults(e) {
        let keyword = $(this).val()
        $('li').css('display', 'none')
        if (isCaseSensitive) {
            $('li:contains(' + keyword + ')').css('display', '')
        }
        else {
            $('li').each((i, li) => {
                if ($(li).text().toLowerCase().indexOf(keyword.toLowerCase()) > 0) {
                    $(li).css('display', '')
                }
            })
        }
    }
    function removeItem() {
        $(this).closest('li').remove()
    }

    let newItem = $('<div>').addClass('add-controls')
        .append($('<label>').text('Enter text:')
            .append($('<input>'))
        )
        .append($('<a>').text('Add').addClass('button').click(addItem))

    let searchItem = $('<div>').addClass('search-controls')
        .append($('<label>').text('Search:')
            .append($('<input>').on('input', showResults))
        )
    let results = $('<div>').addClass('result-controls')
        .append($('<ul>').addClass('items-list'))

    $(selector).append(newItem, searchItem, results)
}