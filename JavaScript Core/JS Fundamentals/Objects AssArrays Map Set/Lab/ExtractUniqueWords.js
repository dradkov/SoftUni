function solve(args) {

    let text = args.join('\n');   
    let words = text.split(/[^0-9A-Za-z_]+/).filter(a => a !== '');
     
    let result = new Set();

    for (let w of words) {
        
        w = w.toLowerCase();
        result.add(w);
    }

    console.log([...result].join(', '));
    
}
solve([
    'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui.', 
    'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla. ',
    'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis. ',
    'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut. ',
    'Morbi in ipsum varius, pharetra diam vel, mattis arcu. ',
    'Integer ac turpis commodo, varius nulla sed, elementum lectus. ',
    'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.',    
]);