
    
class Person{
    constructor(name,email) {
        this.name = name
        this.email = email
    }

    toString(){
        let className = this.constructor.name

        return `${className} (name: ${this.name}, email: ${this.email})`
    }
}

class Teacher extends Person {
    constructor (name, email,subject) {
        super(name, email)
        this.subject = subject
    }

    toString(){
        let base = super.toString().slice(0,-1)
        return base+`, subject: ${this.subject})`
    }

}
class Student extends Person {
    constructor (name, email,course) {
        super(name, email)
        this.course = course
  }

  toString(){
    let base = super.toString().slice(0,-1)
    return base+`, course: ${this.course})`
    }
}


let p = new Person('Ivan','i@amv.bg');
let t = new Teacher('Petko',"p@pess.gb",'medicine')
let s = new Student ('Vasko','vasko@yahoo.bg','karate')


function extendClass(baseClass) {
    baseClass.prototype.species = 'Human'
    baseClass.prototype.toSpeciesString = function (){
        return `I am a ${this.species}. ${this.toString()}`
    }
}

extendClass(Person)

console.log(p.toSpeciesString())
console.log(t.toSpeciesString())


