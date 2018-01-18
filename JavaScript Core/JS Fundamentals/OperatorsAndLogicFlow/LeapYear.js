function solve(year) {
    
   let x = (year % 100 === 0) ? (year % 400 === 0) : (year % 4 === 0);

   if(x===true){
     return  'yes';
   }else {
           return 'no';
        }

 
}

name(2000)