let Person=require('./Person');
let Dog = require('./Dog');

class Student extends Person{
    constructor (name,phrase,dog,id) {
        super(name,phrase,dog);
        this.id=id;
    }

    saySomething(){
        let baseStr=super.saySomething();
        return `Id: ${this.id} `+ baseStr;
    }
}

// let s = new Student('PEsho','test',new Dog('Zeus'),23)
// console.log(s.saySomething());

module.exports = Student

