function solve(args) {
    
    let start = Number(args[0]);

for (let i = 1; i < args.length; i++) {
    
    switch (args[i]) {
        case 'chop': start /= 2; console.log(start);break;
        case 'dice': start = Math.sqrt(start); console.log(start);break;
        case 'spice': start +=1; console.log(start);break;
        case 'bake': start *=3; console.log(start);break;
        case 'fillet': start -= ((start*20)/100); console.log(start);break;

    }
}


}




solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);