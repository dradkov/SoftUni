function modifyAvg(input) {
    let digits = input.toString();

    while (true) {
        let result = getAvg(digits);
        if (result > 5) {
            console.log(digits);
            break;
        }
        digits += '9';
    }

    function getAvg(arr) {
        var total = 0;
        for (const element of arr) {
            total += Number(element);
        }
        return total / arr.length;
    }

}