function solve(text) {
    
    let result = [];

    let startIndex = text.indexOf('(');
    let endIndex = 0;

while (startIndex>-1) {

    endIndex = text.indexOf(')',startIndex);

    if (endIndex == -1) {
        break;
    }

    let sub = text.substring(startIndex+1,endIndex);
    startIndex = text.indexOf('(', endIndex);
    result.push(sub);

}

console.log(result.join(', '));

}
solve('Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)');