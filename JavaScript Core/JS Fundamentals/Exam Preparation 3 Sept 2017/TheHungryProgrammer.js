function solve(products,commands) {
    
    let mealsEaten = 0;

for (let i = 0; i < commands.length; i++) {

            let cmd = commands[i].split(' ');

            if (cmd[0] === 'End') {
                break;
            }

            switch (cmd[0]) {
                case 'Serve': if (products.length>=1) {
                    console.log(`${products[products.length-1]} served!`); 
                    products.pop();
                }   break;            
                   
                case 'Add': if (cmd[1] !== undefined) {
                    products.unshift(cmd[1]);
                }  break;
                case 'Consume':mealsEaten += consumeMeals(cmd[1],cmd[2],products); break;
                case 'Shift':  shiftPlates(cmd[1],cmd[2],products); break;
                case 'Eat':  if (products.length<1) {
                    break;
                }; 
                    console.log(`${products.shift()} eaten`);
                     mealsEaten++;
                    break;
            
                default:
                    break;
            }
        }

        function shiftPlates(first,second,products) {
            
            let firstIndex = Number(first);
            let lastIndex = Number(second);
        
            if (products[firstIndex] !== undefined && products[lastIndex] !== undefined) {
               
                 let temp = products[firstIndex];
                products[firstIndex] = products[lastIndex];
                products[lastIndex] = temp;
            }
        }
        function consumeMeals(start,end,products) {

            let startIndex = Number(start);
            let endIndex = Number(end);
            let range = (endIndex-startIndex)+1;

            if (products[startIndex]!== undefined && products[endIndex]!== undefined){
                products.splice(startIndex,range);
                mealsEaten+=range;
        
                console.log("Burp!");
                return range;

            }
            return 0;
        }

    if (products.length === 0) {
        console.log('The food is gone');      
    }else{
        console.log(`Meals left: ${products.join(', ')}`);
        
    }
    console.log(`Meals eaten: ${mealsEaten}`);
}

solve(['fries', 'fish', 'beer', 'chicken', 'beer', 'eggs'],
['Add spaghetti',
 'Shift 0 1',
 'Consume 1 4',
 'End']

);