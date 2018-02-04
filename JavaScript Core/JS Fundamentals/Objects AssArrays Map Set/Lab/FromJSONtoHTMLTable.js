function solve(args) {

    let parsed = JSON.parse(args);
    let keys = Object.keys(parsed[0]);

   let result = '<table>\n';
   result+='    <tr>';

  for (let k of keys) {
      result+=`<th>${k}</th>`
  }
  result+='</tr>\n';

  for (let obj of parsed) {
      
    result+='    <tr>';

    for (let i = 0; i < keys.length; i++) {
        result+=`<td>${escapeChar(obj[keys[i]]+'')}</td>`;
        
    }
    result+='</tr>\n';
   

  }
  result+= '</table>';



   function escapeChar(str) {
    return str.replace(/&/g,'&amp;')
    .replace(/</g,'&lt;')
    .replace(/>/g,'&gt;')
    .replace(/"/g,'&quot;')
    .replace(/'/g,'&#39;')
   }

   console.log(result);
}
solve('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');