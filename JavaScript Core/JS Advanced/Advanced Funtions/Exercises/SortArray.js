function solve(arr,cmd) {
    

    if (cmd === 'asc') {
        return arr.sort((a,b)=>a-b)
    }
    return arr.sort((a,b)=>b-a)

//     let ascOrder = function (a,b) {
//         return a-b
//     }

//     let descOrder = function (a,b) {
//         return b-a
//     }

//    let paramObj = {
//       'asc' : ascOrder,
//       'desc' : descOrder
//    }

//   return arr.sort(paramObj[cmd]) 

}

solve([14, 7, 17, 6, 8], 'asc')