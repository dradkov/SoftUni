function solve(array) {
 
    let products = [];
    let sum = 0;

    for (let i = 0; i < array.length; i+=2) {
        
        products.push(array[i]);

        sum+=Number(array[i+1]);
    }
    console.log(`You purchased ${products.join(', ')} for a total sum of ${sum}`);
 
 }
 solve(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']);