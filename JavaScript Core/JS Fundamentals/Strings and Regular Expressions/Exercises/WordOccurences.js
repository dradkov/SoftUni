function solve(text, word) {
    let count = 0;
    let regex = new RegExp("\\b" + word + "\\b", "gi");
    // let match = regex.exec(text);

    // while(match) {
    //     count++;
    //     match = regex.exec(text);
    // }
    count = text.match(regex) == null ? 0 : text.match(regex).length;

    console.log(count);

}
    solve('How do you plan on achieving that? How? How can you even think of that? ','how');
  
   