function solve(args) {
   
    let sumAi = 0;
    let sum1Ai = 0;
    let concat = '';
    
    
    for (let i = 0; i < args.length; i++) {
        sumAi += args[i];
        sum1Ai+=1/args[i];
        concat+=args[i]
        
    }
    
    
    console.log(sumAi);
    console.log(sum1Ai);
    console.log(concat);
        
    }
    
    
    solve([1, 2, 3]);