function solve(args) {

let speed = args[0];
let area = args[1];

let drivingArea = getDrivingArea(area);


let speedCheck = checker(speed,drivingArea);

console.log(speedCheck);


function checker(speed,limit) {
    
    let driverSpeed = speed - limit;

    
if (driverSpeed>=1 && driverSpeed<=20) {
    return 'speeding';
}
else if (driverSpeed>20 && driverSpeed<=40) {
    return 'excessive speeding';
} 
else if (driverSpeed>40) {
    return 'reckless driving';
} else {
    return ' ';
}

}


function getDrivingArea(area) {
    
    switch (area) {
        case 'city': return 50;
        case 'residential': return 20;
        case 'interstate': return 90;
        case 'motorway': return 130;   
    }
}

}
solve([200, 'motorway']);