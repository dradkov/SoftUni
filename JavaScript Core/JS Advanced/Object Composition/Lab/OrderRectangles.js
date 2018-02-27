function solve(args) {
    
let result = []

        for (let param of args) {
    
           let rect = createRect(param[0],param[1])

         result.push(rect)
        }

        function createRect(w, h) {

          let rect = {  
          width: w,
          height: h, 
          area: () => rect.width * rect.height,
          compareTo: function(other) {
         let result = other.area() - rect.area()
         return result || (other.width - rect.width)
            }
        };
    

            return rect;
    }

  return  result.sort((a,b)=>a.compareTo(b))

}



solve([[10,5], [3,20], [5,12]])