function solve(str) {


    let parsed = JSON.parse(str);
    let keys = Object.keys(parsed[0]);

    let result = '<table>\n';

    result+=`   <tr><th>${keys[0]}</th><th>${keys[1]}</th></tr>\n`;

    for (let obj of parsed) {
        
        result+=`   <tr><td>${escapeChar(obj[keys[0]]+'')}</td><td>${escapeChar(obj[keys[1]]+'')}</td></tr>\n`;

    }

   result += '</table>'

   function escapeChar(str) {
    return str.replace(/&/g,'&amp;')
    .replace(/</g,'&lt;')
    .replace(/>/g,'&gt;')
    .replace(/"/g,'&quot;')
    .replace(/'/g,'&#39;')
 
}
console.log(result);
}
solve('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');