function solve(array) {

    let result = [];

   for (let i = 0; i < array.length; i++) {
       
    let currentEmail = array[i];

        let userName = currentEmail.substring(0,currentEmail.indexOf('@'))+'.';
        let split = currentEmail.split('@');
        let domain = split[1];

     
        for (let j = 0; j < domain.length; j++) {
           
                if (j===0) {
                  userName+=domain[j];
                  continue;
                }

                if (domain[j]==='.') {
                    userName+=domain[j+1];
                }                       
        }

        result.push(userName);
   }

   console.log(result.join(', '));
 
 }
 solve(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);