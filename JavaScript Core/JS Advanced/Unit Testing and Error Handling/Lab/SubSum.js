function subsum(arr,startIndex,endIndex) {

    if (!Array.isArray(arr)) {
        return NaN
    }
    let sum = 0
    startIndex = startIndex<0 ? 0: startIndex 
    endIndex = endIndex >= arr.length ? arr.length-1 : endIndex

    for (let i = startIndex; i <= endIndex; i++) {
         sum+= Number(arr[i])
    
    }
    return sum
}

// subsum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1)
//  subsum([10, 20, 30, 40, 50, 60], 3, 300)
//  subsum([10, 'twenty', 30, 40], 0, 2)
// subsum([], 1, 2)
//  subsum('text', 0, 2)