class SortedList{
    constructor() {
        this.storage = []
        this.size = 0
    }
	add(elemenent) {
        this.storage.push(elemenent)
        this.size++

        this.storage.sort((a,b)=>a-b)
    }
    remove(index){
        if (index>=0 && index< this.storage.length) {
             this.storage.splice(index,1)
             this.size--
        }   
    }
    get(index){
        if (index>=0 && index< this.storage.length) {
            return this.storage[index]
        }
    }

}


let test = new SortedList()
test.add(10)
test.add(20)
test.add(8)
test.add(14)
test.remove(3)

console.log(test);
console.log(test.get(1));
console.log(test);
