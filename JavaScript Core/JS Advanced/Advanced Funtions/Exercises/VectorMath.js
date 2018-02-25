(()=>{

    let add = (first,second)=>[first[0] + second[0], first[1] + second[1]]
    let multiply = (first, second) => [first[0] * second, first[1] * second];
    let length = (first) => Math.sqrt(Math.pow(first[0],2)+Math.pow(first[1],2));
    let dot = (first, second) => first[0] *  second[0] + first[1] * second[1];
    let cross = (first, second) => first[0] * second[1] - first[1] * (second[0]);

    return {add,multiply,length,dot,cross}
})()