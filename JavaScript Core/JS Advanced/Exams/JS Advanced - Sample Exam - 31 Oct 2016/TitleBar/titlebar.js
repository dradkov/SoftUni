class TitleBar {
    constructor(title) {
        this.title = title
        this.links = []
    }

    addLink(href, name) {
        let link = $('<a>')
            .addClass('menu-link ')
            .attr('href', href)
            .text(name)
        this.links.push(link)
    }

    appendTo(selector) {
        //Create elenments
        let header = $('<header>').addClass('header')
        let headerRow = $('<div>').addClass('header-row')
        let aTagButton = $('<a>')
            .addClass('button')
            .html('&#9776;')
            .click(() => $('div.drawer').toggle())
        let span = $('<span>')
            .addClass('title')
            .text(this.title) 
        let naviDrawer = $('<div>').addClass('drawer')
        let navMenu = $('<nav>').addClass('menu')

        //Appending elements
        this.links.forEach(link=>navMenu.append(link))
        headerRow.append(aTagButton)
        headerRow.append(span)
        naviDrawer.append(navMenu)
        header.append(headerRow)
        header.append(naviDrawer)

        $(selector).append(header)
    }
    // appendTo(selector) {
    //     let navMenu = $('<nav>').addClass('menu')
    //     for (const link of this.links) {
    //         navMenu.append(link)
    //     }

    //     let headerHTML = $('<header>').addClass('header')
    //         .append($('<div>')
    //             .addClass('header-row')
    //             .append($('<a>')
    //                 .addClass('button')
    //                 .html('&#9776;')
    //                 .click(() => $('.drawer').toggle()))
    //             .append($('<span>')
    //                 .addClass('title')
    //                 .text(this.title)))
    //         .append($('<div>')
    //             .addClass('drawer')
    //             .append(navMenu))


    //     $(selector).append(headerHTML)
    // }
}
