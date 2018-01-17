function solve(a,b) {

let stringWord = a;
let word = b;

let result = 0;

  for(let i = 0; i < stringWord.length; i++){

    if(stringWord[i]=== b ){
        result++;
    }

  }


    console.log(result)


    
}

solve('panther', 'n');

