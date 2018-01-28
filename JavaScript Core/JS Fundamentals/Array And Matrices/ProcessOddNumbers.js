function solve(params) {
   
 
    let result = params.filter((e,i)=>i % 2 ===1)
    .map(el => el * 2)
    .reverse();
    
    console.log(result.join(' '));
 }
 
 solve([3, 0, 10, 4, 7, 3]);