function solve(text) {

    let regex= /\w+/g;

    let result = text.match(regex);

    console.log(result.join('|'));
 
 }
 solve('A Regular Expression needs to have the global flag in order to match all occurrences in the text');