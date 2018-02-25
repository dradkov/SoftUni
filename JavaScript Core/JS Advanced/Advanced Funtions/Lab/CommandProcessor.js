function solve(arr) {
    
    let colser  = (function () {
        
        let result = '';

        return {
            append: (st)=> result += st,
            removeStart: (n) =>result = result.substring(n),
            removeEnd:(n)=> result = result.substring(0,result.length-n),
            print:()=>console.log(result)
        }
    })()

    for (let cmd of arr) {
        
        let [command,value] = cmd.split(' ')


        colser[command](value)
    }


}


solve(['append 123',
'append 45',
'removeStart 2',
'removeEnd 1',
'print'])
