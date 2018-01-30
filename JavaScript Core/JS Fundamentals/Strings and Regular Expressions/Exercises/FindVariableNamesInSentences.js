function solve(text,subs) {
     let regex = /\b_[a-zA-Z0-9]+\b/g

     console.log(text.match(regex).map(s=>s.substr(1)).join(','))

}
 solve('The _id and _age variables are both integers.');