function solve(params) {
   
let counter = 1;

let result = [];

   for (const commmand of params) {
      if (commmand === 'add') {
          result.push(counter++)
      }else if (commmand === 'remove') {
          result.pop();
          counter++;
      }
   }
    if (result.length === 0) {
        console.log('Empty');
    }
    else{     
        console.log(result.join('\n'));
    }
 }
 
 solve(['add','add', 'remove','add','add']);