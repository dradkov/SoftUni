function solve(args) {

let number  = -10000000000;


    for (let i = 0; i < args.length; i++) {
         if (args[i]>number) {
                 number = args[i];
     }
    
    }
   return number;
     }
    solve([5,-2,7]);
        
        
       