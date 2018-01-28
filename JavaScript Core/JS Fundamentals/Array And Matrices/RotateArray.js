function solve(params) {
    
 
    let rotation = Number(params[params.length-1]);

     params.pop();

    for (let i = 0; i < rotation % params.length; i++) {
       
        let currentEl = params.pop();

        params.unshift(currentEl);   
        
    }
    console.log(params.join(' '));
 }
 
 solve(['1', '2', '3','4','2']);