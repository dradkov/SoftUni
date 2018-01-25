function solve(args) {
    
let xmlResult = createXml();

console.log(xmlResult);


function createXml() {
    let xmlReult = '';

    xmlReult +='<?xml version="1.0" encoding="UTF-8"?>\n';
    xmlReult +='<quiz>\n';

for (let i = 1; i <= args.length; i+=2) {
   
    let quest = args[i-1];
    let answer = args[i];
    
    xmlReult +='  <question>\n';
    xmlReult +=`    ${quest}\n`;
    xmlReult +='  </question>\n';
    xmlReult +='  <answer>\n';
    xmlReult +=`    ${answer}\n`;
    xmlReult +='  </answer>\n';
}
xmlReult +='</quiz>';

return xmlReult;
    }   
}

solve(["Dry ice is a frozen form of which gas?",
"Carbon Dioxide",
"What is the brightest star in the night sky?",
"Sirius"]
);