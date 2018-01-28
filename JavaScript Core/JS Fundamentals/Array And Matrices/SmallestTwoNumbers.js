function solve(params) {
    
    let result = params.sort((a,b)=>a-b);

    console.log(result.slice(0,2).join(' '));
 }
 
 solve([3, 0, 10, 4, 7, 3]);