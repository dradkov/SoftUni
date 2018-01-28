function solve(params) {
    
 
    let result = params.map(arr=>arr.sort((a,b)=>a<b)[0])
    .sort((a,b)=>a<b)[0];
    console.log(result);
 }
 
 solve([[20, 50, 10],
    [8, 33, 145]]
   );