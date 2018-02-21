(function createBook() {
    let id = 1;
    return function(selector, title, author, ISBN) {
 
        let container = $(selector)
        let fragment = document.createDocumentFragment()

    

    let div =  $('<div>').attr('id', `book${id}`)
    id++

    let pTitle = $('<p>').addClass('title').append(title)
    let pAuthor = $('<p>').addClass('author').append(author)
    let pISBN = $('<p>').addClass('isbn').append(ISBN)
    let selectBtn = $('<button>Select</button>')
    let deselectBtn = $('<button>Deselect</button>')

    pTitle.appendTo(div)
    pAuthor.appendTo(div)
    pISBN.appendTo(div)
    selectBtn.appendTo(div)
    deselectBtn.appendTo(div)
    div.appendTo(fragment)

    container.append(fragment)

    selectBtn.on("click", function () {
        div.css("border", "solid blue 2px")
    })

    deselectBtn.on("click", function () {
        div.css("border", "none")
    })
}
}());