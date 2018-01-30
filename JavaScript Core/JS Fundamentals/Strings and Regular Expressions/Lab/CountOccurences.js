function solve(target,text) {

let count = 0;
let index = text.indexOf(target);
while (index > -1) {
    count++;
    index = text.indexOf(target, index + 1);

} 
    console.log(count);
 
 }
