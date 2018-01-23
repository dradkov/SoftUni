function solve(args){

    let x0 = args[0];
    let y0 = args[1];
    let z0 = args[2];
    let x1 = args[3];
    let y1 = args[4];
    let z1 = args[5];

    deltaX = x1 - x0;
    deltaY = y1 - y0;
    deltaZ = z1 - z0;
    
    distance = Math.sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
    
    console.log(distance);
    }

solve([3.5, 0, 1, 0, 2, -1]);