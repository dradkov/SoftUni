 function findFib() {
    
    let f1 = 0
    let f2 = 1

    return function () {
        let f3 = f1+f2;
        [f1,f2]= [f2,f3]

        return f1
    }

}

let f = findFib()

f() // 1
f() // 1
f() // 2
f() // 3
f() // 5
f() // 8

// let test =  (() =>{
    
//      let f1 = 0
//      let f2 = 1

//    return () => {
//         let f3 = f1+f2;
//         [f1,f2]= [f2,f3]

//         console.log(f1); 
//     }

// })()

// test() //1
// test() //1
// test() //2
// test() //3
// test() //5