function solve(bill) {


    
        bill = bill.replace(/(-?\d+)\s*\*\s*(-?\d+(\.\d+)?)/g, (match, num1, num2) => Number(num1) * Number(num2));
        console.log(bill);
 
   
 
 }
 solve('My bill: 2*2.50 (beer); 2* 1.20 (kepab); -2  * 0.5 (deposit).');