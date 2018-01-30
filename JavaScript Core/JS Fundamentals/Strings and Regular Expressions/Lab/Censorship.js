function solve(text , listWords) {
    

for (let i = 0; i < listWords.length; i++) {
    
let word = listWords[i];

let regex = new RegExp(word,'g');
let daches = "-".repeat(word.length);
    
text = text.replace(regex,daches)
}

console.log(text);
}


solve('roses are red, violets are blue', [', violets are', 'red']);