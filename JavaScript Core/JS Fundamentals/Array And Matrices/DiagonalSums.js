function solve(matrix) {
    
    let leftDiagonal = 0;
    let rightDiagonal = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            
            if (row===col) {
                leftDiagonal+=matrix[row][col];
            }
            if (matrix.length - row - 1 === col) {
                rightDiagonal+=matrix[row][col];
            }
        }
        
    }
    console.log(leftDiagonal+' '+ rightDiagonal);
}

solve(
	[[3, 5, 17],
 [-1, 7, 14],
 [1, -8, 89]]
);