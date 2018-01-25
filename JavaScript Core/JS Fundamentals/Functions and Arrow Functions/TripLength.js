function solve([x1, y1, x2, y2, x3, y3]) {

    let distance12 = distance(x1, y1, x2, y2);
    let distance23 = distance(x2, y2, x3, y3);
    let distance13 = distance(x1, y1, x3, y3);
    let maxDistance = Math.max(distance12, distance13, distance23);

    if (distance13 == maxDistance) {
        let a = distance12 + distance23;
        console.log('1->2->3: ' + a);
    } else if (distance12 == maxDistance) {
        let c = distance23 + distance13;
        console.log('1->3->2: ' + c);
    }
    else if (distance23 == maxDistance) {
        let b = distance13 + distance12;
        console.log('2->1->3: ' + b);
    }


    function distance(x1, y1, x2, y2) {
        return Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
    }
}
