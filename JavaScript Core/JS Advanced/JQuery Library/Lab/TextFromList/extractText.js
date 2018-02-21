function extractText() {
    let result =  $('#items li').toArray().map((item) => $(item).text()).join(', ');
       
    $('#result').text(result);
}