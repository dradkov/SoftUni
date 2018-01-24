function calculator(a,b,op) {

let add = function (c,d){return c+d };
let substract = function (c,d){return c-d };
let multiply = function (c,d){return c*d };
let devide = function (c,d){return c/d };

switch (op) {
    case '*': return multiply(a,b);
    case '/': return devide(a,b);
    case '-': return substract(a,b);
    case '+': return add(a,b);
}

}


console.log(calculator(5,7,'+')) ;