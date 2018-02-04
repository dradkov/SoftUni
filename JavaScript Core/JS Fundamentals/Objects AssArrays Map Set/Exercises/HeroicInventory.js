function solve(params) {

    let result = [];

    for (const heroInfo of params) {
        
    let [heroname,herolevel,items] = heroInfo.split(/\s*\/\s*/);
    
    let heroObj = {};
    heroObj.name = heroname;
    heroObj.level = Number(herolevel);
    heroObj.items = [];

   if (items!= undefined) {
    heroObj.items = items.split(', ');
   }
   result.push(heroObj);
   }
   console.log(JSON.stringify(result));
}

solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']);
