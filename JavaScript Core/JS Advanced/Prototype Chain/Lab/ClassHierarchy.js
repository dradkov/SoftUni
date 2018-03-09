function solve() {  
    class Figure{
        constructor() {
            if (new.target === Figure) {
              throw new TypeError('This is abstact class')
            }
        }
        get area(){
            switch (this.constructor) {
                case Circle:
                    return Math.PI * this.radius * this.radius
                    break;
                case Rectangle:
                    return this.width * this.height
                    break;
        
                default:
                    break;
                }
        }
        toString(){
        let type = this.constructor.name
        let props = Object.getOwnPropertyNames(this)
        return `${type} - ${props.map(p=>`${p}: ${this[p]}`).join(', ')}`

        }
    }
    class Circle extends Figure{
        constructor(r) {
            super()
            this.radius = r
        }
    }
    class Rectangle extends Figure{
        constructor(w,h) {
            super()
            this.width = w
            this.height = h
        }
    }
    return {Figure,Circle,Rectangle}
 }

//let f = new Figure();       //Error
let c = new Circle(5);
console.log(c.area);        //78.53981633974483
console.log(c.toString());  //Circle - radius: 5
let r = new Rectangle(3,4);
console.log(r.area);        //12
console.log(r.toString());  //Rectangle - width: 3, height: 4
