function search() {
    let target = $('#searchText').val();

    let count = 0;
    $('#towns li').each((index,element)=>{
        
        let current = $(element).val();
      if (element.textContent.includes(target)) {
        $(element).css("font-weight", "bold");
        count++;
      }
        
    })

   $('#result').text(count + " matches found.");
}
