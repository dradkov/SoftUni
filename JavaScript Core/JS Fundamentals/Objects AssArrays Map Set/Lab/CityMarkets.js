function solve(args) {

    let result = new Map();


    for (let info of args) {
        
    let [town,product,sum] = info.split(/\s*->\s*/).filter(s =>s !==''); 

    let totalSum = sum.split(/\s*:\s*/).filter(s =>s !=='').reduce((a,b)=> a*b);
    
    if (!result.has(town)) {
        result.set(town,new Map());
    }

    if (!result.get(town).has(product)) {
        result.get(town).set(product,0);
    }

    let oldSales = result.get(town).get(product);
    
    result.get(town).set(product,oldSales+totalSum);

    }

    for (let [town,products] of result) {

        console.log(`Town - ${town}`);

        for (const [name,sales] of products) {
            console.log(`$$$${name} : ${sales}`);
        }
    }
  
}
solve(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3'
    ]);