function solve(a,b) {

    let radius = a;
    let height = b;

    let volume = 1/3 * Math.PI*Math.pow(radius,2)*height;


    let l2 = Math.pow(height,2) +  Math.pow(radius,2)

    let l = Math.sqrt(l2);

    let area = Math.PI * radius * (radius+l);

  console.log(volume.toFixed(4));
  console.log(area.toFixed(4));
    }
    
    solve(3,5);