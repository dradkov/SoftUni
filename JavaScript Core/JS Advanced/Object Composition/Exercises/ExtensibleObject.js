function solve(temp) {
    
    let obj = {
        extend: function (temp) {

            for (let parentProp of Object.keys(temp)) {

                if (typeof (temp[parentProp]) == "function") {

                    Object.getPrototypeOf(obj)[parentProp] = temp[parentProp];

                } else {
                    obj[parentProp] = temp[parentProp];
                }
            }
        }
    };
    return obj
}