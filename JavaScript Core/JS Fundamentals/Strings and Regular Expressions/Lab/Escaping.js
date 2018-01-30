function solve(params) {
    
    let result = '<ul>\n';

    for (let i = 0; i < params.length; i++) {
       
        result+='  <li>'+escapeChar(params[i])+'</li>\n';
        
    }
    result+='</ul> \n'

    function escapeChar(str) {
        return str.replace(/&/g,'&amp;')
        .replace(/</g,'&lt;')
        .replace(/>/g,'&gt;')
        .replace(/"/g,'&quot;')
        .replace(/'/g,'&#39;')
    }


console.log(result);
}
solve(['<b>unescaped text</b>', 'normal text']);