function solve(args) {
 
    args = args.map(Number)


    let sum = 0;

    for(let i = 0; i < args.length; i++){


        let current = args[i];

        sum+=args[i];

    }

    let VAT = (sum* 20)/100;

    let total = VAT + sum;

    console.log(`sum = ${sum}`);
    console.log(`VAT = ${VAT}`);
    console.log(`total = ${total}`);

}


solve([3.12, 5, 18, 19.24, 1953.2262, 0.001564, 1.1445])