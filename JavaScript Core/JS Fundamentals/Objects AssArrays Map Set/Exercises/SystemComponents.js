function solve(args) {
    

    let dataBase = new Map();

   for (let info of args) {

    let [systemName,compName,subCompName] = info.split(/\s*\|\s*/).filter(a =>a !=='');

    if (!dataBase.has(systemName)) {
        dataBase.set(systemName,new Map());
    }
    if (!dataBase.get(systemName).has(compName)) {
        dataBase.get(systemName).set(compName, new Set());
    }

    dataBase.get(systemName).get(compName).add(subCompName);
       
   

   }

   let orderedKeys = [...dataBase.keys()].sort((a,b)=> {
    let result = [...dataBase.get(b).keys()].length - [...dataBase.get(a).keys()].length;

    if (result==0) {
        return a.toLowerCase().localeCompare(b.toLowerCase());
    }
    return result;

   })

   


   for (let sysName of orderedKeys) {
       
    console.log(sysName);

    let orderdComponents = [...dataBase.get(sysName).keys()].sort((a,b)=>{
        let aLen = dataBase.get(sysName).get(a).size;
        let bLen = dataBase.get(sysName).get(b).size;
        return bLen - aLen;

    });

    for (let comps of orderdComponents) {
        console.log(`|||${comps}`);
        [...dataBase.get(sysName).get(comps)].forEach(a=> console.log(`||||||${a}`));


    }



   }

}

solve(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security',
]);