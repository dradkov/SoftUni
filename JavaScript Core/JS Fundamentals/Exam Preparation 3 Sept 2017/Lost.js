function solve(keyword,text) {

let regex = /(north|east)\D*(\d{2})[^\,]*\D*(,{1})\D*(\d{6})/gi;

let message =  text.substring(text.indexOf(keyword),text.lastIndexOf(keyword));

let latitude;
let longtitude;
    
let match = regex.exec(text);

while (match) {
    
if (match[1].toLowerCase() === 'east') {
    latitude = `${match[2]}.${match[4]} E`;
}else if (match[1].toLowerCase() === 'north') {
    longtitude = `${match[2]}.${match[4]} N`;
}
    match = regex.exec(text);
}

console.log(longtitude);
console.log(latitude);
console.log(`Message: ${message.substring(keyword.length,message.length)}`);
}
solve('4ds'
,'eaSt 19,432567noRt north east 53,123456north 43,3213454dsNot all those who wander are lost.4dsnorth 47,874532');

