function solve(input){

    let result = '<table border="1">\n<thead>\n<tr><th colspan="3">Blades</th></tr>\n'
    result+='<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>\n</thead>\n<tbody>\n';
        
        for (let num of input) {
            num =  Math.floor(num);
            if (num<= 10) {
            continue;
            }
            var weapon = num>10 && num<=40 ? 'dagger': 'sword';
            var blade = '';
           
            if ((num - 1) % 5 === 0) {
                blade = 'blade';
            } else if ((num - 2) % 5 === 0) {
                blade = 'quite a blade';
            } else if ((num - 3) % 5 === 0) {
                blade = 'pants-scraper';
            } else if ((num - 4) % 5 === 0) {
                blade = 'frog-butcher';
            } else if ((num - 5) % 5 === 0) {
                blade = '*rap-poker';
            }
            
                result+=`<tr><td>${num}</td><td>${weapon}</td><td>${blade}</td></tr>\n`;
            
        }
        result+='</tbody>\n</table>\n';
        console.log(result);
    }


solve(['17.8',
'19.4',
'13',
'55.8',
'126.96541651',
'3']);
