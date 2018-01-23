function solve(a,b,c){

    let d = Math.pow(b, 2) - 4 * a * c;
    let x1 = 0;
    let x2 = 0;

    if (d > 0) {
        x1 = -(Math.sqrt(d) + b) / (2 * a);
        x2 = (Math.sqrt(d) - b) / (2 * a);

        console.log(x1);
        console.log(x2);
    } else if (d == 0) {
        x1 = (-1) * b / (2 * a);

        console.log(x1);
    } else {
        console.log('No');
    }
}
solve(1,-12,36);
   
