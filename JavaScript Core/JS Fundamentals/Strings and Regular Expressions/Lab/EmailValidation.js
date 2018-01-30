function solve(text) {

    let regex= /^[A-Za-z0-9]+@[a-z]+\.[a-z]+$/gm;

   if (regex.test(text)) {
       return 'Valid';
   }
 return 'Invalid';
 }
 solve('valid@email.bg');
 solve('invalid@emai1.bg');