function solve(array) {
    
    let regex = /[0-9]+/g;
    
    console.log(array.join(' ').match(regex).join(' '));
}

solve(['The300','What is that?','I think it’s the 3rd movie.','Lets watch it at 22:45']);



