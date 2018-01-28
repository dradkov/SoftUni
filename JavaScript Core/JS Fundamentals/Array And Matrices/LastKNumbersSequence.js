function solve(n,k) {
   
    let result = [1];

    for (let i = 1; i < n; i++) {
       let sum = result.slice(Math.max(0,result.length-k),i+k)
       .reduce((total, num)=>{return total + num})

         result[i] = sum;
  
        
    }

    console.log(result.join(' '))
 }

 solve(8, 2);