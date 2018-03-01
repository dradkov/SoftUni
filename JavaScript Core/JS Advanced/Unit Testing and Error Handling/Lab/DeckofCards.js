function cardsdeck(cardsCollection) {
    
    function createCard(face,suit) {
    
        const validFace = ['2','3','4','5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']
        const validSuits = ['S','H','D','C']
    
        if (!validFace.includes(face)) {
            throw new Error ("Invalid face")
        }
        if (!validSuits.includes(suit)) {
            throw new Error ("Invalid suit")
        }
    
        let card = {
            face: face,
            suit: suit,
            toString:()=>{
                let specialChars = {
                    S: "\u2660",
                    H: "\u2665",
                    D: "\u2666",
                    C: "\u2663",
                }
    
                return `${card.face}${specialChars[card.suit]}`
            }
        }  
        return card  
    }   
    let deck = []
    for (let card of cardsCollection) {
        
        let face = card.substring(0,card.length-1)
        let suit = card[card.length-1]

        try {
             deck.push(createCard(face,suit))
            } catch (err) {
                console.log(`Invalid card: ${card}`);
                return
            }
        

    }
    console.log(deck.join(' ')); 
}

cardsdeck(['AS', '10D', 'KH','2C']) //A♠ 10♦ K♥ 2♣


cardsdeck(['5S', '3D', 'QD', '1C']) //Invalid card: 1C
