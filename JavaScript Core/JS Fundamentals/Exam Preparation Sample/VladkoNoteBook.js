function solve(arr) {

    let result = {};

for (let line of arr) {
    
    let spliter = line.split('|');

    let collor = spliter[0];

    if (!result.hasOwnProperty(collor)) {
        result[collor] = {
              wins: 1,
              losses:1,
              opponents: []  
        }
    }

        switch (spliter[1]) {
            case 'age': result[collor]['age'] = spliter[2] ; break;
            case 'name': result[collor]['name'] = spliter[2] ; break;
            case 'win':
            result[collor]['wins']++
            result[collor]['opponents'].push(spliter[2])
            break;
            case 'loss':
            result[collor]['losses']++
            result[collor]['opponents'].push(spliter[2])
            break;
            default:
                break;
        }



    }

    for (const color of Object.keys(result)) {
        result[color]['opponents']=  result[color]['opponents'].sort();
    }
    
    
    
    let final = {};

    for (let collor of Object.keys(result).sort()) {

        if (result[collor]['name']!==undefined && result[collor]['age'] !== undefined) {
    
            final[collor] = {
                age: result[collor]['age'],
                name: result[collor]['name'],
                opponents: result[collor]['opponents'],
                rank: (result[collor]['wins'] / result[collor]['losses']).toFixed(2)
            }

        }


    }

    console.log(JSON.stringify(final));

}



//console.log(JSON.stringify(final));



solve(['purple|age|99',
'red|age|44',
'blue|win|pesho',
'blue|win|mariya',
'purple|loss|Kiko',
'purple|loss|Kiko',
'purple|loss|Kiko',
'purple|loss|Yana',
'purple|loss|Yana',
'purple|loss|Manov',
'purple|loss|Manov',
'red|name|gosho',
'blue|win|Vladko',
'purple|loss|Yana',
'purple|name|VladoKaramfilov ',
'blue|age|21',
'blue|loss|Pesho', ]);
   
