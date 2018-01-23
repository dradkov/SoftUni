function solve(num) {
   let grad = num % 400;
    let degree = grad * 0.9;
    let result = degree < 0 ? 360 + degree : degree;
    console.log(result);
}

solve(100);