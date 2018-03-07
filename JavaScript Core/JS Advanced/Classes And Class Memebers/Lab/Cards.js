let result = (()=>{

    let Suits = {
        SPADES: "\u2660",
        HEARTS: "\u2665",
        DIAMONDS:"\u2666",
        CLUBS:"\u2663"
    }

    let Faces = ['2', '3', '4', '5', '6', '7', '8','9', '10', 'J', 'Q', 'K', 'A']

    class Card{
        constructor(face,suit) {
            this.face = face
            this.suit = suit
        }
    
        get face(){
            return this._face
        }
        set face(value){
           if (!Faces.includes(value)){
             throw new Error('Invalid card face '+ value)       
           }
            
            this._face = value
        }
    
        get suit(){
            return this._suit
        }
        set suit(value){
            if (!Object.keys(Suits).map(k=>Suits[k]).includes(value)) {
                throw new Error("Invalid card suite: " + value)
            }
            this._suit = value
        }
    
        toString(){
            return this.face + this.suit
        }
      
    }

    return {Suits,Card}

})()
 
 //let Card = result.Card
 //let Suits = result.Suits

// let card = new Card('Q',Suits.CLUBS)

// console.log(card);
// card.face = 'A'
// card.suit = Suits.DIAMONDS

// console.log(card);

 //let card2 = new Card('1',Suits.DIAMONDS)

//console.log(card2);