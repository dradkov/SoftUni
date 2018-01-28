function solve(params) {
    let delimetrer = params[params.length-1];
    
params.pop();
    console.log(params.join(delimetrer))
 }
 
 solve(['One','Two', 'Three',' Four', 'Five','-' ]);
   
   
   
   
    
   