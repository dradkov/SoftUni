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

let card =  createCard('A','H')

console.log(card.toString());