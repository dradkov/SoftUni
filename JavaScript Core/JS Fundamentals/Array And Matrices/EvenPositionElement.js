function solve(params) {
    
    let result = [];
    

  for (let i = 0; i < params.length; i++) {

     if (i%2===0) {
         
         result.push(params[i]);
     }
      
  }

    console.log(result.join(' '));
 }
 
 solve(['20', '30', '40']);