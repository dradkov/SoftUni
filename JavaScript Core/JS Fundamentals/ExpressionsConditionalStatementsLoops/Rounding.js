function solve(params) {
    
let number = params[0];
let round = params[1];

if (round>15) {
    round = 15;
}

let powNum = Math.pow(10, round);
    number = Math.round(number * powNum) / powNum;
    console.log(number);

}

solve([10.5, 3]);