function solve(day) {
   
let arr = ['Monday','tuesday','wednesday','thursday','friday','saturday','sunday']

let index = arr.indexOf(day);

return index >-1 ? index+1 : 'error';

// let dayOfweek = day.toLowerCase();

// switch (dayOfweek) {
//     case 'monday':
//         return 1;
//         case 'tuesday':
//         return 2; 
//         case 'wednesday':
//         return 3;
//         case 'thursday':
//         return 4;
//         case 'friday':
//         return 5;
//         case 'saturday':
//         return 6;
//         case 'sunday':
//         return 7;    

//     default:
//         return 'error'; 
//}
}

solve('monday');