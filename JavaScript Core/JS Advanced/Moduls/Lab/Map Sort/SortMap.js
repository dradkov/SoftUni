function mapSort(map, sortBy) {
    if (!sortBy) {
        sortBy = function (a, b) {
            return a[0].toString().localeCompare(b[0].toString());
        };
    }

    let newMap = new Map();
    Array.from(map.entries()).sort(sortBy).forEach(e=>newMap.set(e[0],map.get(e[0])));

    return newMap;
}

module.exports = mapSort;
