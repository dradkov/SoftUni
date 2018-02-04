function solve(args) {

    let text = args.join('\n');

    let allWords = text.split(/[^A-Za-z0-9_]+/).filter(w =>w !=="");

    let result = new Map();

    for (let word of allWords) {
        
        word = word.toLowerCase();

        if (result.has(word)) {
           
            result.set(word,result.get(word)+1);

        }else{
            result.set(word,1);
        }

       // result.has(word) ? result.set(word,result.get(word)+1) : result.set(word,1);

    }

    let order = Array.from(result.keys()).sort((a,b)=>a.localeCompare(b));

   // order.forEach(w=>console.log(`'${w}' -> ${result.get(w)} times`));

    for (let keys of order) {

        console.log(`'${keys}' -> ${result.get(keys)} times`);
    }


}
solve(['Far too slow, you\'re far too slow.']);