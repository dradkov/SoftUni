function makeList() {
    let data = [];
    return {
        addLeft: function (item) {
            data.unshift(item);
        },
        addRight: function (item) {
            data.push(item);
        },
        clear: function () {
            data = [];
        },
        toString: function () {
            return data.join(", ");
        }
    };
}

let expect = require('chai').expect

describe('Test List', function () {

    let test;
    beforeEach(function () {

        test = makeList()
    })

    describe('General Tests', function () {
        it('test has all properties', function () {
            expect(test.hasOwnProperty('addLeft')).to.be.true
            expect(test.hasOwnProperty('addRight')).to.be.true
            expect(test.hasOwnProperty('clear')).to.be.true
            expect(test.hasOwnProperty('toString')).to.be.true
        })
        it('test data[] initialization', function () {
            expect(`[${test}]`).to.equal('[]')
            expect(test.data).to.be.undefined

        })
    })
    describe('addLeft func', function () {
        it('test add In front', function () {
            test.addLeft(1)
            test.addLeft(2)
            test.addLeft('bg')
            expect(test.toString()).to.equal('bg, 2, 1')

        })
    })
    describe('addRight func', function () {
        it('test add back', function () {
            test.addRight(1)
            test.addRight(2)
            test.addRight('bg')
            expect(test.toString()).to.equal('1, 2, bg')

        })
    })
    describe('clear func', function () {
        it('clear should be empty', function () {
            test.addRight(1)
            test.addRight(2)
            test.addRight('bg')
            test.clear()
            expect(`[${test}]`).to.equal('[]')

        })
        it('clear should return 8', function () {
            test.addRight(1)
            test.addRight(2)
            test.addRight('bg')
            test.clear()
            test.addLeft(8)
            expect(test.toString()).to.equal('8')

        })
    })
    describe('toString func', function () {
        it('test with []', function () {
            let array = [5, "gosho", true, false, 3.15];
            array.forEach(el => test.addRight(el));
            expect(test.toString()).to.equal(array.join(", "));
        })
    })
})