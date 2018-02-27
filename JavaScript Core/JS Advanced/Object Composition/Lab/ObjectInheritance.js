function commandParser(commands) {
   


   let logigCmd = (() => {
    let cmdCollection = new Map();

    function create(name,param,parent) {
        if (param) {
            inherit(name,parent)
        }else{
            cmdCollection.set(name,{}) 
        }
        
    }

    function inherit(name,parent) {    
     cmdCollection.set(name,Object.create(cmdCollection.get(parent)))
    }

    function set(objName,propName,value) {
        cmdCollection.get(objName)[propName]= value
    }

    function print(name) { 
    let current = cmdCollection.get(name)
    let allprops = []
    for (const key in current) {
        allprops.push(`${key}:${current[key]}`)
    }
        console.log(allprops.join(', ')); 
    }
    return {create,inherit,set,print}
   })()

   for (const cmd of commands) {
        let [command,name,parent,value] = cmd.split(' ')
        logigCmd[command](name,parent,value)
    }
}

commandParser(['create c1',
'create c2 inherit c1',
'set c1 color red',
'set c2 model new',
'print c1',
'print c2']
)

// create('c1')
// inherit('c2','c1')
// set('c1','color','red')
// set('c2','model','new')

// print('c2')

//console.log(cmdCollection);
//console.log(Object.getPrototypeOf(cmdCollection.get('c2')));
