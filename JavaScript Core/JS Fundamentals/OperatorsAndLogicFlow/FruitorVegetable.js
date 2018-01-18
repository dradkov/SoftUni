function solve(zarzavat) {


   switch(zarzavat){
    case'banana': return 'fruit';
    case'apple': return 'fruit';
    case'kiwi': return 'fruit';
    case'cherry': return 'fruit';
    case'lemon': return 'fruit';
    case'grapes': return 'fruit';
    case'peach': return 'fruit';
    case'tomato': return 'vegetable';
    case'cucumber': return 'vegetable';
    case'pepper': return 'vegetable';
    case'onion': return 'vegetable';
    case'garlic': return 'vegetable';
    case'parsley': return 'vegetable';
    default:
    return 'unknown';
   }
   
}

solve('pizza');