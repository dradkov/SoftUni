function solve(a,b,c,d,e) {
    
    let minAge = a;
    let name = b;
    let age = c;
    let secondName = d;
    let secondAge = e;

    let objFirst  = {
    name: name,
    age: age
    }

    let objSecod  = {
    name: secondName,
    age: secondAge
    }   
if(objFirst.age>=minAge){

console.log(objFirst);
}

if(objSecod.age>=minAge){

    console.log(objSecod);
    }


}

solve(12, 'Ivan', 15, 'Asen', 9)