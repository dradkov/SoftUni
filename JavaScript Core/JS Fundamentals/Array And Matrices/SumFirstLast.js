function solve(params) {
   params = params.map(Number);

   let result = params[0]+ params[params.length - 1];
   console.log(result);
}

solve(['20', '30', '40']);