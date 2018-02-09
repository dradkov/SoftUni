function solve(params) {
 
    let log = new Map();
    let subscribers = new Map();


    for (const cmd of params) {
       
        let splitCmd = cmd.split('-');

        if (splitCmd.length===1) {
            
            let person = splitCmd[0];
            if (!log.has(person)) {
                log.set(person,new Set())
                subscribers.set(person,new Set())
                
            }

        }else{

            let currentPerson = splitCmd[0];
            let subscriber = splitCmd[1];

            if (log.has(currentPerson) && log.has(subscriber)) {

                log.get(subscriber).add(currentPerson);            
                subscribers.get(subscriber).add(currentPerson);
            }

        }
    }


                                                    //a             //b
let sortBySubNum = new Map([...log.entries()].sort((firstEntity,secondEntity)=>{
                            
    let currentPerson = firstEntity[0];//a 
    let currentPersonSubs = firstEntity[1].size; //a

    let nextPerson = secondEntity[0];//b
    let nextPersonSubs = secondEntity[1].size;

    let result = nextPersonSubs- currentPersonSubs;

    if (result ===0) {
        let firstEntrySubscriptions = subscribers.get(currentPerson).size;
        let secondEntrySubscriptions = subscribers.get(nextPerson).size;

        result = secondEntrySubscriptions - firstEntrySubscriptions;
    }
     return result; 
}));


let mostImprtMan = [...sortBySubNum.entries()][0];

console.log(mostImprtMan[0]);

let count  =1; 
for (const iterator of mostImprtMan[1]) {
    console.log(`${count}. ${iterator}`);
    count++;
}

}
solve(['A','B','C','D','A-B','B-A','C-A','D-A']);
