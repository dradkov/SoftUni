function solve(obj) {
    
        if (obj.handsShaking) {
            let bloodAlc = 0.1*obj.weight * obj.experience
            obj.bloodAlcoholLevel += bloodAlc
            obj.handsShaking = false
        }
        
        return obj
}

solve( { weight: 120,
    experience: 20,
    bloodAlcoholLevel: 200,
    handsShaking: true })



