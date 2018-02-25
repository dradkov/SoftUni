function solve(arr) {
    
        //return Math.max(...arr)
        //return Math.max.call('',...arr)
       return Math.max.apply('',arr)

}

solve([1, 44, 123, 33])