function solve(args) {

let result = new Map();

for (let info of args) {
    
let spliter = info.split(/\s*<->\s*/).filter(s => s !=='');

let [town,pop] = [spliter[0],Number(spliter[1])]
    
result.has(town) ? result.set(town,result.get(town)+pop) : result.set(town,pop);

}

for (let [k,v] of result) { 

    console.log(`${k} : ${v}`);
}


   
}
solve(['Sofia <-> 1200000','Montana <-> 20000','New York <-> 10000000','Washington <-> 2345000','Las Vegas <-> 1000000']);
    
   
   
   
    