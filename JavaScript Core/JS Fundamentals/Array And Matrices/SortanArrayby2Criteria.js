function sortArrayByCriteria(arr) {

    function compareByLength(a, b) {
        let lengthA = a.length;
        let lengthB = b.length;

        if (lengthA > lengthB) {
            return 1;
        } else if (lengthA < lengthB) {
            return -1;
        } else {
            return compareByAlphabetOrder(a, b);
        }
    }

    function compareByAlphabetOrder(a, b) {
        let aToLower = a.toLowerCase();
        let bToLower = b.toLowerCase();
        if (aToLower > bToLower) {
            return 1;
        }
        if (aToLower < bToLower) {
            return -1;
        }
        return 0;
    }
    let ordered = arr.sort(function (a, b) { return compareByLength(a, b); });
    return console.log(ordered.join('\n'));

}

    
   
    