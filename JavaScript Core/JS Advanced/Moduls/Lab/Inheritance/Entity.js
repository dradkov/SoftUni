class Entity{
    constructor(name) {
        if (new.target === Entity) {
            throw new TypeError("This is an abstaract class")
        }
        this.name = name
    }
     saySomething(){
         return `${this.name} `
     }
}

module.exports = Entity