function solve(params) {

let v1 = params[0];
let v2 = params[1];
let t = (params[2]/60)/60;

    let s1 =v1*t;
    let s2 = v2*t;

    let result = Math.abs(s1-s2);
   
    console.log(result*1000);
}

solve([0, 60, 3600]);