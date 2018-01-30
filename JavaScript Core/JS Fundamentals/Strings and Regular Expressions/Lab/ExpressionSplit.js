function solve(word) {

   let regex = /[,;().\s]+/;

   word.split(regex).forEach(element => console.log(element));
 
 }
 solve('let sum = 4 * 4,b = "wow";');