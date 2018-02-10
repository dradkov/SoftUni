function solve(input) {
    let arr = [];
    let result = [];

    for(let line of input){
        arr.push(line.toLowerCase());
        result.push(Array.from(line));
    }

    for(let row=0; row<arr.length-2; row++){
        for(let col=0; col<arr[row].length; col++){

            let current = arr[row][col];

            let upRight = arr[row][col+2];
            let middle = arr[row+1][col+1];
            let downLeft = arr[row+2][col];
            let downRight =arr[row+2][col+2];

            if(upRight != undefined && middle != undefined && 
               downLeft != undefined && downRight != undefined) {

                if (current == upRight && current == middle 
                    && current == downLeft && current == downRight) {
                    result[row][col] =" ";
                    result[row][col+2] =" ";
                    result[row+1][col+1] =" ";
                    result[row+2][col] =" ";
                    result[row+2][col+2] =" ";
                     
                }
            }
        }
    }

    for(let i=0; i<result.length; i++){
        result[i] = result[i].filter(ch => ch != " ");
    }

    for(let line of result){
        line = line.join("");
        console.log(line);
    }
}

solve(['abnbjs',
   'xoBab',
    'Abmbh',
    'aabab',
    'ababvvvv'
    ])