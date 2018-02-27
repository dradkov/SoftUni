function solve(args) {

    let processor = (() => {

        let list = []

        function add(str) {
            list.push(str)
        }
        function remove(str) {
            list = list.filter(s=>s !== str)
        }
        function print() {
            console.log(list.toString()); // 
        }

        return {add,remove,print}

    })()

    for (const cmd of args) {
        let tokens = cmd.split(' ')

        processor[tokens[0]](tokens[1])
    }
}
solve(['add hello', 'add again', 'remove hello', 'add again', 'print'])