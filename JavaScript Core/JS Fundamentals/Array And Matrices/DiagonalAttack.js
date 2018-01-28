function solve(params) {
    let matrix = params.map(row => row.split(" ").map(Number));
 
let left = 0;
let right = 0;

    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col <  matrix[0].length; col++) {
           
            if (row===col) {
                left+=matrix[row][col];
            }
            if (matrix.length-row-1 === col) {
                right+=matrix[row][col];
            }
        }
        
    }

    if (left !==right ) {
        return
            matrix.map(row => row.join(' '))
                .join('\n');
            
    }

    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col <  matrix[0].length; col++) {
           
            if (row!==col && matrix.length-row-1 !== col ) {
                matrix[row][col]= left;
            }
           
        }
        
    }
   

    console.log(
        matrix.map(row => row.join(' '))
            .join('\n'));


 }
 
 solve(['5 3 12 3 1',
 '11 4 23 2 5',
 '101 12 3 21 10',
 '1 4 5 2 2',
 '5 22 33 11 1']
 );