function solve(args) {
    
        let result = new Map();

        for (let info of args) {
            
        let [town,product,price] = info.split(/\s*\|\s*/).filter(a => a !=='');
            
        if (!result.has(product)) {
            result.set(product,new Map());
        }
        if (!result.get(product).has(town)) {
            result.get(product).set(town,0);
        }

        result.get(product).set(town,Number(price));    
        }


        for (let [product,price] of result) {
           
          let lowestPrice = Math.min(...price.values());
          let town = getKeyByValue(price,lowestPrice);

          console.log(`${product} -> ${lowestPrice} (${town})`);

        }
        
        //Find the lowest price for every product and the town it is sold at for that price
    function getKeyByValue(mymap, value) {
        return [...mymap.keys()].find(key => mymap.get(key) === value);
    }
    
}
solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'
    ]);
