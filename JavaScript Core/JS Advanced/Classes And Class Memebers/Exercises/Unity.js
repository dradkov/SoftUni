class Rat{
    constructor(name) {
        this.name = name
        this.unitRats = []
    }

    unite(otherRat){       
        if (otherRat instanceof Rat) {
            this.unitRats.push(otherRat)
        }
    }
    getRats(){
        return this.unitRats
    }
    toString(){
        return `${this.name}\n${this.unitRats.map(r=>`##${r.name}`).join('\n')}`
    }
}



let test = new Rat("Pesho");
console.log(test.toString()); //Pesho

console.log(test.getRats()); //[]

test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));
console.log(test.getRats());
//[ Rat { name: 'Gosho', unitedRats: [] },
//  Rat { name: 'Sasho', unitedRats: [] } ]

console.log(test.toString());
// Pesho
// ##Gosho
// ##Sasho
