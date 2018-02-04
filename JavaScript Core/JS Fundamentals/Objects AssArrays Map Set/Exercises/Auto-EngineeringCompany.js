function solve(params) {

    let result = new Map();

    for (let info of params) {
        
    let [brand,model,prodused] = info.split(/\s*\|\s*/).filter(b=> b !== '');

    if (!result.has(brand)) {
        result.set(brand,new Map());
    }
    if (!result.get(brand).has(model)) {
    result.get(brand).set(model,0);
    }

    let oldValue = result.get(brand).get(model);

    result.get(brand).set(model,Number(prodused)+oldValue);   

    }


    for (let [brand,model] of result) {
        

        console.log(brand);
        for (let [m,p] of model) {
            console.log(`###${m} -> ${p}`);
        }
    }


}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']);
