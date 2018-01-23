function solve(args) {

let name = args[0];
let nameProp = args[1];
let age = args[2];
let ageProp = args[3];
let gender = args[4];
let genderProp = args[5];

   let obj = {
   }

   obj[name] = `${nameProp}`;
   obj[age] = `${ageProp}`;
   obj[gender] = `${genderProp}`;

return obj;
}
solve(['ssid', 'Pesho', 'status', '23', 'gender', 'male']);