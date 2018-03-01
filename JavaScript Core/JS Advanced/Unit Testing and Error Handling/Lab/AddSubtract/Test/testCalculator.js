const createCalculator = require('../createCalculator.js').createCalculator
let expect = require('chai').expect

describe('Calculator', ()=> {
    let calc
    beforeEach(()=>{
     calc = createCalculator()
    })

    it('Should return an object', () =>{
     expect(typeof calc).to.equal('object')
    })
    it('Should have zero value when created', () =>{
        expect(calc.get()).to.equal(0)
    })
    it('Should add value', () =>{
        calc.add(3)
        calc.add(5)
        expect(calc.get()).to.equal(8)
    })
    it('Should subtract value', () =>{
        calc.subtract(3)
        calc.subtract(5)
        expect(calc.get()).to.equal(-8)
    })
    it('Should work with fractions', () =>{
        calc.add(3.14)
        calc.subtract(1.13)
        expect(calc.get()).to.be.closeTo(2.01,0.0001)
    })
    it('Should work with negative Nums', () =>{
        calc.add(-4)
        calc.subtract(-3)
        expect(calc.get()).to.equal(-1)
    })
    it('Should not add NaN', () =>{
        calc.add('ivane')
        expect(calc.get()).to.be.NaN
    })
    it('Should not subtract NaN', () =>{
        calc.subtract('stoyaneee')
        expect(calc.get()).to.be.NaN
    })
    it('Should with nums as string', () =>{
        calc.add('7')
        expect(calc.get()).to.equal(7)
    })
})