function slove(n) {
    
if (n%2==0) {
    
for (let row = 0; row < n-1 ; row++) {

       if (row===0 || row===n-2 || row === Math.floor((n/2)-1)) {

           console.log('+'+"-".repeat(n-2)+'+'+'-'.repeat(n-2)+'+');
       }
       else{
        console.log('|'+' '.repeat(n-2)+'|'+' '.repeat(n-2)+'|');
       }
       
   
    
    }

}else{

for (let row = 0; row < n ; row++) {

       if (row===0 || row===n-1 || row === Math.floor((n/2))) {
               
           console.log('+'+"-".repeat(n-2)+'+'+'-'.repeat(n-2)+'+');
       }
       else{
        console.log('|'+' '.repeat(n-2)+'|'+' '.repeat(n-2)+'|');
       }
       
   
    
}
}


}

slove(7);