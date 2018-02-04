function solve(args) {

let text = args.join('\n');

let words = text.split(/[^A-Za-z0-9_]+/).filter(a => a !== '');

let result = {};
    
for (let word of words) {
    result[word] ? result[word]++ : result[word]=1;
}

console.log(JSON.stringify(result));

   
}
solve(['Far too slow, you\'re far too slow.']);