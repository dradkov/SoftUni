function solve() {
    class Balloon {
        constructor(c,gw) {
            this.color = c
            this.gasWeight = gw 
        }
    }
    
    class PartyBalloon extends Balloon {
        constructor (c,gw,rc,rl) {
            super(c,gw)
             this.ribbonColor = rc
             this.ribbonLength = rl
    
            this.ribbon = {
                color : this.ribbonColor,
                length: this.ribbonLength
            }
        }
        get ribbon () {
            return this._ribbon
        }
    
        set ribbon (value) {
            this._ribbon = value
        }
    }
    
    class BirthdayBalloon extends PartyBalloon {
        constructor (c,gw,rc,rl,text) {
            super(c,gw,rc,rl)
            this.text = text
        }
    
        get text () {
            return this._text
        }
        set text (value) {
             this._text = value
        }
    }

    return {
        Balloon: Balloon,
        PartyBalloon: PartyBalloon,
        BirthdayBalloon: BirthdayBalloon
    }
}



let pb  =new PartyBalloon("red",10,'white',14)

console.log(pb.ribbon);
