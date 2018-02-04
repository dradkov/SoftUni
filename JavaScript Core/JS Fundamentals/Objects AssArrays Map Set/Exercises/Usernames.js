function solve(params) {
    
    let storage = new Set();

    for (let name of params) {
        
        storage.add(name);

    }

let ordered = [...storage.keys()].sort((a,b)=>{
    let result = a.length - b.length;
    if (result == 0) {
        return a.localeCompare(b);
    }
    return result;
});

    console.log(ordered.join('\n'));

}

solve(['Ashton',
'Kutcher',
'Ariel',
'Lilly',
'Keyden',
'Aizen',
'Billy',
'Braston']);
