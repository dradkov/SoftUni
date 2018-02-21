function increment(selector) {

   let container = $(selector);
   let fragment = document.createDocumentFragment();
   let textArea = $('<textarea>');
   let incrementBtn = $('<button>Increment</button>');
   let addBtn = $('<button>Add</button>');
   let ul = $('<ul>');


   textArea.val(0);
   textArea.addClass('counter');
   textArea.attr('disabled',true);

    incrementBtn.addClass('btn');
    incrementBtn.attr('id','incrementBtn');

    addBtn.addClass('btn');
    addBtn.attr('id','addBtn');

    ul.addClass('results');


    $(incrementBtn).on('click',clickIncrement);

    $(addBtn).on('click',clickAdd);


    function clickIncrement() {
        textArea.val(+textArea.val()+1)
    }

    function clickAdd() {
        let li =$(`<li>${textArea.val()}</li>`)

        li.appendTo(ul)
    }

    textArea.appendTo(fragment); 
    incrementBtn.appendTo(fragment);
    addBtn.appendTo(fragment);
    ul.appendTo(fragment);

    container.append(fragment);
}
