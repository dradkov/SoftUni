function solve(args) {
    

    let parsed = [];
    [...args].forEach(e => parsed.push(JSON.parse(e)));

    let result = '<table>\n';

        for (let obj of parsed) {
            result+='   <tr>\n';

            Object.keys(obj).forEach(k =>result += `       <td>${(String(obj[k]))}</td>\n`);
 
            result+='   <tr>\n';          

        }

        result+='</table>';
        
    function escapeChar(str) {
        return str.replace(/&/g,'&amp;')
        .replace(/</g,'&lt;')
        .replace(/>/g,'&gt;')
        .replace(/"/g,'&quot;')
        .replace(/'/g,'&#39;')
       }

       console.log(result);
}

solve([ '{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}' ]);


