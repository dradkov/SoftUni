$(() => {
    renderCatTemplate();

     function renderCatTemplate() {

        let source =  $('#cat-template').html()
        let compiled = Handlebars.compile(source);
        let context = compiled({
            cats: window.cats
        })
        $('#allCats').html(context);
    }
   

    $('.btn.btn-primary').on('click', function (event) {
        let element = $($(event.target).parent()).find('div').toggle();

        if(element.css('display') == 'none'){
            $(element.parent()).find('button').text("Show status code");
        } else {
            $(element.parent()).find('button').text("Hide status code");
        }
        
    });
})