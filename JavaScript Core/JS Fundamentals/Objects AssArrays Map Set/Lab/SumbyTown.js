function solve(args) {
    
    let obj = {}

    for (let i = 0; i < args.length; i+=2) {
       
        if (obj.hasOwnProperty(args[i])) {

            obj[args[i]]+= Number(args[i+1]);


        }else{
            obj[args[i]] = Number(args[i+1]);
        }      
    }

    console.log(JSON.stringify(obj));

}
solve(['Sofia','20','Varna','3','Sofia','5','Varna','4']);

function assArraySolve(args) {
    
    let result = {};
    
    for (let i = 0; i < args.length; i+=2) {
        
        let [town,population] = [args[i],Number(args[i+1])] ;
    
        if (result[town]=== undefined) {
            result[town] = population;
        }else{
            result[town] += population;
        }
    }

    console.log(JSON.stringify(result));
}
assArraySolve(['Sofia','20','Varna','3','Sofia','5','Varna','4']);
    
   