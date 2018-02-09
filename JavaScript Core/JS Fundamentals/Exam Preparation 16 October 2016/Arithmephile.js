function solve(array) {
   
let result = -Infinity;

for (let i = 0; i < array.length; i++) {
    
    let current = parseInt(array[i]);

    if ( !isNaN(current)) {
        
        if (current >= 0 && current < 10 ) {
            
            let tempResult = 1 ;
            let start = i+1;
            let end =  i + current >=array.length ? array.length : current+i;

            for (let j = start; j <= end; j++) {

                let currentJ = parseInt(array[j]);
                
                if (!isNaN(currentJ)) {

                    tempResult *= currentJ;
                }

            }
            if (tempResult >= result ) {
                result = tempResult;
            }
        }
    }
}
console.log(result);
}

//solve(['10','20','2','30','44','3','56','20','3']);
//solve(['100','200','2','3','2','3','2','1','1']);
solve(['-1','3','6']);

//'100','200','2','3','2','3',