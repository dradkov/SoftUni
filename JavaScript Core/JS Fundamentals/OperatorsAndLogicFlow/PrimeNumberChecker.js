function solve(num) {

    if (num<=0) {
         return false;
    }


    for(let i = 2; i < num; i++)
    if(num % i === 0) return false;
  return num !== 1;
 
}

solve(81);