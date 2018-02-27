function carFactory(obj) {
    let engines = {
        Small: { power: 90, volume: 1800 },
        Normal: { power: 120, volume: 2400 },
        Monster: { power: 200, volume: 3500 }
    };
    let requiredEngine = Object.keys(engines).find(k => engines[k].power >= obj.power);
    let wheelSize= obj.wheelsize%2==0?obj.wheelsize-1:obj.wheelsize;
    
    let car = {
        model: obj.model,
        engine: {
            power: engines[requiredEngine].power,
            volume: engines[requiredEngine].volume
        },
        carriage: {
            type: obj.carriage,
            color: obj.color
        },
        wheels: Array(4).fill(wheelSize)
    };

 return car;    

}

carFactory({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }

);