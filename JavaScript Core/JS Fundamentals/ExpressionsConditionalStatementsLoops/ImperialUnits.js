function solve(number) {
    var feet = Math.floor(number/12);
    var inches = number%12;


    return `${feet}'-${inches}"`;

//console.log(`${(inches / 12) | 0}'-${inches % 12}"`);

}
solve(11);