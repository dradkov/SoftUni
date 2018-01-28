function solve(params) {
   
 
    let result = [];
    let lastElement = Number(params.pop());

    for (let i = 0; i < params.length; i+=lastElement) {
        
        result.push(params[i]);
    }
console.log(result.join('\n'));

 }
 
 solve(['5','20', '31', '4','20','2']);