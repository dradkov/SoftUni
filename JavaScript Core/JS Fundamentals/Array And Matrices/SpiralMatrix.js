function solve(rows,cols) {
   
    let matrix = [];
    let number = 1;

    for (let rowIndex = 0; rowIndex < rows; rowIndex++) {
        
        matrix.push([]);    
    }

    let startRow = 0;
    let startCol = 0;
    let endRow = rows-1;
    let endCol = cols-1;


    while (startRow<=endRow || startCol<=endCol) {
        
        for (let i = startCol; i <= endCol; i++) {
            matrix[startRow][i] = number++;

        }

        for (let i = startRow + 1; i <= endRow; i++) {
            matrix[i][endCol] = number++;
        }

        for (let i = endCol - 1; i >= startCol; i--) {
            matrix[endRow][i] = number++;
        }

        for (let i = endRow - 1; i > startRow; i--) {
            matrix[i][startCol] = number++;
        }

        startRow++;
        startCol++;
        endRow--;
        endCol--;

    }


    console.log(
        matrix.map(row => row.join(' '))
            .join('\n'));
 }
 
 solve(5,5);