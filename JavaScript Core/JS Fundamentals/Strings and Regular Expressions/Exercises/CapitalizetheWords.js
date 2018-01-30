function solve(text) {
     
   
    let result = text.toLowerCase()
    .split(' ')
    .map(w => w[0].toUpperCase() + w.substr(1));
    console.log(result.join(' '));


}

solve('Was that Easy? tRY thIs onE for SiZe!');

