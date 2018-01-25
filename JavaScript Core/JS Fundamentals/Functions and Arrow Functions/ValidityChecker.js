function solve(args) {
    
    let x1 = args[0];
    let y1 = args[1];
    let x2 = args[2];
    let y2 = args[3];

    checkCoordinates(x1,y1,0,0);
    checkCoordinates(x2,y2,0,0);
    checkCoordinates(x1,y1,x2,y2);

function checkCoordinates(x1,y1,x2,y2) {
    
    let result = 'invalid';

    if (Number.isInteger(distansce(x1,y1,x2,y2))) {
        result = 'valid';
    }

    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${result}`);

}

function distansce(x1,y1,x2,y2) {
    return Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
}
}
solve([2, 1, 1, 1]);