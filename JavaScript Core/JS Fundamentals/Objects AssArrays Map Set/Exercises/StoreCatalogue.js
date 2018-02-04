function solve(params) {
    
    let result = new Map();

    let startLetter = new Set();

    for (let info of params) {
    
    let [product,price] = info.split(/\s*:\s*/);

        result.set(product,price);
        startLetter.add(product[0]);
    }

    let sortedLetters = [...startLetter].sort(); 
  
    for (let letter of sortedLetters) {

        console.log(letter);

        let product = [...result.keys()].filter(x=>x[0]===letter).sort();
        product.forEach(x=>console.log(`  ${x}: ${result.get(x)}`))

    }
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10'
]);