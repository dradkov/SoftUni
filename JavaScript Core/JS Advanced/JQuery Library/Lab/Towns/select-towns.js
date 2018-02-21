function attachEvents() {
          $('#items li').on('click',onListClick)
          
          function onListClick() {
              if ( !$(this).attr('data-selected')) {
                $(this).attr('data-selected',true)
                $(this).css('background-color','#DDD')
              }else{
                $(this).removeAttr('data-selected')
                $(this).css('background-color','')
              }
              
          }

          $('#showTownsButton').on('click',showButtonClick)

          function showButtonClick() {
             let towns = $('#items > li[data-selected]').toArray().map(a =>a.textContent).join(', ')
                  
              //console.log(`Selected towns: ${towns}`);

              $('#selectedTowns').text('Selected towns: '+ towns) 
          }
}