function solve(a,b,c) {
    

    let s = (a+b+c)/2;
    let calculateA = s*(s-a);
    let calculateB = calculateA*(s-b);
    let calculateC = calculateB*(s-c);
   
    console.log(Math.sqrt(calculateC));
    }
    
    solve(2,3.5,4);