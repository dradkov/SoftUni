function solve(params) {
   
let result = [params[0]];
let maxNum = result[0];

for (let i = 1; i < params.length; i++) {
   
    if (params[i]>=params[i-1] && params[i]>=maxNum) {
        result.push(params[i]);
        maxNum = params[i];

    }
}
console.log(result.join('\n'));
 }
 
