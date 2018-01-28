function solve(params) {
   
    let k = params.shift(0);
 
    let first =params.slice(0,k);
    let second =params.slice((params.length-k),params.length);

    console.log(first.join(' '));
    console.log(second.join(' '));

 }
 
 solve([3,6, 7, 8, 9]);
    
    
   
  