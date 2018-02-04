function solve(arrStr) {
    
    let juices = new Map();
    let produsedBottles = new Map();
    
    for (let data of arrStr) {
        let [name, quantity] = data.split(' => ')
            .filter(e => e != '');
        //check if juice exist
        if (!juices.has(name)) {
            juices.set(name, 0);
        }

        //check for producing bootle
        let oldQuantity = juices.get(name);
        let newQuantity = oldQuantity + Number(quantity);
        let bottles = Math.floor(newQuantity / 1000);
        if (bottles >= 1) {
            //check if bottles exists for this juice
            if (!produsedBottles.has(name)) {
                produsedBottles.set(name, 0);
            }
            //set new quantity of bottles and juice
            let oldBottles = produsedBottles.get(name);
            produsedBottles.set(name, oldBottles + bottles);
            newQuantity = newQuantity % 1000;
        }

        //set remaining juice
        juices.set(name, newQuantity);

    }

    //print prodused bottles
    [...produsedBottles].forEach(([name, bottles]) => console.log(`${name} => ${bottles}`));



}

solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']);