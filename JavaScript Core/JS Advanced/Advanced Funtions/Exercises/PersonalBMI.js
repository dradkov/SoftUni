function solve(name, age, weight, height) {

    let bmi = weight/((height/100)*(height/100))
    let status 

    if (bmi < 18.5) {
        status = 'underweight'
    }else if (bmi < 25) {
        status = 'normal'
    }else if (bmi < 30) {  
        status = 'overweight'
    } else if (bmi >= 30) {
        status = 'obese'
    }

    let obj = {}

    obj.name=name
    obj.personalInfo = {}
    obj.personalInfo.age = age
    obj.personalInfo.weight = weight
    obj.personalInfo.height = height
    obj.BMI = Math.round(bmi)
    obj.status=status

    if(status=='obese'){
        obj.recommendation='admission required';
    }    
        return obj

}
solve('Peter', 29, 75, 182)
solve('Honey Boo Boo', 9, 57, 137)