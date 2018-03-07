class Rectangle{
    constructor(width,height,color){
       this.width = width
       this.height= height
       this.color = color
    }

    calcArea(){

        return Number(this.width) * Number(this.height)
    }
}

let rect = new Rectangle('20', '30', '40')

console.log(rect.calcArea());