function solve(params) {
    for (let index = 0; index < params.length; index += 2) {
        let x = params[index];
        let y = params[index + 1];

        if (isInside(1, 3, 1, 3, x, y)) {
            console.log('Tuvalu');
        } else if (isInside(8, 9, 0, 1, x, y)) {
            console.log('Tokelau');
        } else if (isInside(5, 7, 3, 6, x, y)) {
            console.log('Samoa');
        } else if (isInside(0, 2, 6, 8, x, y)) {
            console.log('Tonga');
        } else if (isInside(4, 9, 7, 8, x, y)) {
            console.log('Cook');
        } else {
            console.log('On the bottom of the ocean');
        }
    }


    function isInside(xMin, xMax, yMin, yMax, x, y) {
        return (x >= xMin && x <= xMax && y >= yMin && y <= yMax);
    }
}

solve([4, 2, 1.5, 6.5, 1, 3]);