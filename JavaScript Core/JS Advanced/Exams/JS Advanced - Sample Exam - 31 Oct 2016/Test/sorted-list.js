class SortedList {
    constructor() {
        this.list = [];
    }

    add(element) {
        this.list.push(element);
        this.sort();
    }

    remove(index) {
        this.vrfyRange(index);
        this.list.splice(index, 1);
    }

    get(index) {
        this.vrfyRange(index);
        return this.list[index];
    }

    vrfyRange(index) {
        if (this.list.length == 0) throw new Error("Collection is empty.");
        if (index < 0 || index >= this.list.length) throw new Error("Index was outside the bounds of the collection.");
    }

    sort() {
        this.list.sort((a, b) => a - b);
    }

    get size() {
        return this.list.length;
    }
}

let expect = require('chai').expect

describe('Test Sorted List', function () {

    let collection;

    beforeEach(() => {
        collection = new SortedList()
    })

    describe('Major Test', function () {
        it("should have all of the functions in it's prototype", function () {
            expect(SortedList.prototype.hasOwnProperty('add')).to.equal(true, "Function add() was not found.");
            expect(SortedList.prototype.hasOwnProperty('remove')).to.equal(true, "Function remove() was not found.");
            expect(SortedList.prototype.hasOwnProperty('get')).to.equal(true, "Function get() was not found.");
        });

        it("should have size property getter", function () {
            expect(SortedList.prototype.hasOwnProperty('size')).to.equal(true, "Property size was not found.");
            expect(typeof collection.size).to.not.equal('function', "Property size should not be a function.");
        });
    })

    describe('Add Function', function () {
        it('Add two elements Should return 2', () => {
            collection.add(1)
            collection.add(2)
            expect(collection.list.length).to.equal(2)
        })
    })

    describe('Remove Function', function () {
        it('Remove at index 1 Should not contains 2 ', () => {
            collection.add(1)
            collection.add(2)
            collection.add(3)
            collection.remove(1)
            expect(collection.list).to.not.contains(2)
        })
        it('Remove at outsite index Should throw ex ', () => {
            collection.add(1)
            collection.add(4)
            collection.add(3)
            expect(() => collection.remove(6)).to.throw(Error)
        })
        it('Remove index in empty collection Should throw ex ', () => {
            expect(() => collection.remove(6)).to.throw(Error)
        })
    })
    describe('Get Function', function () {
        it('Get number at index 1 Should return 3', () => {
            collection.add(1)
            collection.add(8)
            collection.add(3)
            expect(collection.get(1)).to.equal(3)
        })
        it('Get number at invalid index -1 Should throw ex', () => {
            collection.add(1)
            collection.add(8)
            collection.add(3)
            expect(() => collection.get(-1)).to.throw(Error)
        })
        it('Get number at in empty collection Should throw ex', () => {
            expect(() => collection.get(1)).to.throw(Error)
        })
    })
    describe('size property', function () {
        it('size  Should be equel to length ', () => {
            collection.add(1)
            collection.add(8)
            collection.add(3)
            expect(collection.size).to.equal(3)
        })

    })

    describe('Sorted at All time', function () {
        it("should be sorted after adding", function () {
            collection.add(5);
            expect(collection.get(0)).to.equal(5);
            collection.add(2);
            expect(collection.get(0)).to.equal(2);
            expect(collection.get(1)).to.equal(5);
        });
        it("should be sorted after removing", function () {
            collection.add(5);
            collection.add(2);
            collection.add(3);
            collection.remove(1)
            expect(collection.get(0)).to.equal(2);
            expect(collection.get(1)).to.equal(5);
        });
    })

})