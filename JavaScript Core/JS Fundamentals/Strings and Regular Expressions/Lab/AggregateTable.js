function solve(word) {


    let info = word.join('').split('|');

    let sum = 0;
    let towns = [];
    
   for (let i = 1; i < info.length; i+=2) {
       
    let town = info[i].trim();
    let sumTown = Number(info[i+1].trim());

    sum+=sumTown;
    towns.push(town);
  
   }

   console.log(towns.join(', '));
    console.log(sum);
 
 }
 solve(['| Sofia           | 300',
        '| Veliko Tarnovo  | 500',
        '| Yambol          | 275']
);