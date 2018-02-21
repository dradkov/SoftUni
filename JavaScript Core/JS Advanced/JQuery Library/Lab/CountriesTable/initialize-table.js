function initializeTable(){
    $('#createLink').click(createCountry);
    addCountryToTable('Bulgaria','Sofia');
    addCountryToTable('Germany','Berlin');
    addCountryToTable('Russia','Moscow');
    fixRowLink();


    function createCountry() {
        let country =$('#newCountryText');
        let capital =$('#newCapitalText');

        addCountryToTable(country.val(),capital.val());
        country.val('');
        capital.val('');
        fixRowLink();
    }
    function addCountryToTable(country,capital) {
      let tr =  $('<tr>')
        .append($('<td>').text(country))
        .append($('<td>').text(capital))
        .append($('<td>')
            .append($('<a href="#">[Up] </a>').click(moveRowUp))
            .append($('<a href="#">[Down] </a>').click(moveRowDown))
            .append($('<a href="#">[Delete]</a>').click(deleteRow)));

            $(tr).css('display','none');
       $('#countriesTable').append(tr);  
       tr.fadeIn(1000);   
 
    }

    function moveRowUp() {
      let row =  $(this).parent().parent();
      if (row.index() > 2) {
        row.fadeOut(function () {
            row.insertBefore(row.prev()); 
            row.fadeIn();
            fixRowLink();
        });
      }

     

    }
    function moveRowDown() {
        let row =  $(this).parent().parent();

        if (!row.is(':last-child')) {
          row.fadeOut(function () {
              row.insertAfter(row.next()); 
              row.fadeIn();
              fixRowLink();
          });
        }
       
    }
    function deleteRow() {
      let element =   $(this).parent().parent();
      element.fadeOut(function () {
          element.remove();
            fixRowLink();
    });
        
    }

    function  fixRowLink(){
        $('#countriesTable').find('tr')
            .find('a:contains("Up")').css('display','inline');

            $('#countriesTable').find('tr')
            .find('a:contains("Down")').css('display','inline');

       let firstRow = $('#countriesTable tr')[2];
       $(firstRow).find('a:contains("Up")').css('display','none');
       
       let lastRow = $('tr');
       $(lastRow.last()).find('a:contains("Down")').css('display','none');
    }
}