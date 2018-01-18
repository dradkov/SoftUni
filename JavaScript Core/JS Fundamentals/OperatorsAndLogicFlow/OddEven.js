function solve(n) {


    if(  n % 2 === 0 ){
        console.log('even');
    }
   else if(Math.abs(n % 2 ) === 1){
    console.log('odd');
     
   }else{
       console.log('invalid');
   }
   
}

solve(-3);