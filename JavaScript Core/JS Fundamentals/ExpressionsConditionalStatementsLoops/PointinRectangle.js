function solve(args) {
        let [x, y, xMin, xMax, yMin , yMax ] = args;
   
        if (x <= xMax && x >= xMin && y >= yMin && y <= yMax) {   
         console.log('inside');

        }else{
         console.log('outside');
        }

  }

solve([8, -1, 2, 12, -3,3,]);
           
           
           
           
            
            