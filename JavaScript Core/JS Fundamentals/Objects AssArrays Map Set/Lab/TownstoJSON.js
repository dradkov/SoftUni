function solve(args) {

    let result = [];
    let keys = args[0].split(/\s*\|\s*/).filter(st=> st !== '');
    
    for (let iterator of args.slice(1)) {

        let obj = {};

       let [town,lat,long] = iterator.split(/\s*\|\s*/).filter(st=> st !== '');

       obj[keys[0]] = town;
       obj[keys[1]] = Number(lat);
       obj[keys[2]] = Number(long);

       result.push(obj);
    }
    console.log(JSON.stringify(result));
}
solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);