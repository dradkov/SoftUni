
function solve(describtion,orderBy) {

    class Ticket {

        constructor(destination,price,status) {

        this.destination = destination
        this.price = price
        this.status = status
        }
    }

    let storage = []

    for (const t of describtion) {

        let tokens = t.split('|')
        
        storage.push(new Ticket(tokens[0],Number(tokens[1]),tokens[2]))
    }

   
    let sorted = storage.sort((a,b)=>{
        let aValue=a[orderBy];
        let bValue=b[orderBy];
       
        if(aValue>bValue)return 1;
        if(aValue<bValue)return -1;
        if(aValue==bValue)return 0;
    });

      return storage

}




solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination')




