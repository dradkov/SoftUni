function algo(a,b){

    if (b == 0){
        return a
    }else{
  return algo(b, a % b)
    }
}

algo(252, 105)