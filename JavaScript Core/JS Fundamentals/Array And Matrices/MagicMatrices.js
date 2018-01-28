function solve(matrix) {
  
    
    let  rowSum = matrix[0].reduce((total,num)=> total+num);
    let isMagic = true;

    for (let row = 1; row < matrix.length; row++) {

        if (rowSum !== matrix[row].reduce((total,num)=> total+num)) {
            isMagic = false;
        }
     
    }

    for (let col = 0; col < matrix[0].length; col++) {

        let colSum = 0;
        for (let row = 0; row < matrix.length; row++) {
            
            colSum+=matrix[row][col];
        }
        if (colSum!== rowSum) {
            isMagic = false;
        }
        
    }
    console.log(isMagic);

 }
 
 solve([[4, 5, 6,5],
    [6, 5, 4,7],
    [5, 5, 5,3],
    [5, 5, 5,5]]
   
   );