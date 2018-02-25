function result() {
    
let obj = {};
   
    for (const element of arguments) {
        
        let currentType = typeof(element)

        if (!obj[currentType]) {
            obj[currentType] = 1;
        }else{
            obj[currentType]++
        }
        console.log(`${currentType}: ${element}`);
    }
    
    Object.keys(obj).sort((a, b) => {return obj[b] - obj[a]}).forEach(k => console.log(`${k} = ${obj[k]}`));
}

result(['cat', 42, function () { console.log('Hello world!'); }]);