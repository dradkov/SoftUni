 mathEnforcer = require('../MathEnforcer').mathEnforcer
let expect= require('chai').expect

describe('Test MathEnforcer',  ()=> {
    
    describe('Test Addfive',  ()=> {

        it("Should return undefined for 'test'", function () {
            expect(mathEnforcer.addFive('test')).to.be.undefined
         })
         it("Should return 15 for 10+5", function () {
            expect(mathEnforcer.addFive(10)).to.equal(15)
         })
         it("Should return 2 for -3", function () {
            expect(mathEnforcer.addFive(-3)).to.equal(2)
         })
         it("Should return 8.5 for 3.5", function () {
            expect(mathEnforcer.addFive(3.5)).to.be.closeTo(8.5,0.01)
         })
    })
    describe('Test SubtractTen',  ()=> {

        it("Should return undefined for 'test'", function () {
            expect(mathEnforcer.subtractTen('test')).to.be.undefined
         })
         it("Should return 8 for 18-10", function () {
            expect(mathEnforcer.subtractTen(18)).to.equal(8)
         })
         it("Should return -11 for -1-10", function () {
            expect(mathEnforcer.subtractTen(-1)).to.equal(-11)
         })
         it("Should return -7.9 for 2.1 -10", function () {
            expect(mathEnforcer.subtractTen(2.1)).to.be.closeTo(-7.9,0.01)
         })
        
    })
    describe('Test Sum',  ()=> {

        it("Should return undefined for ('test',10)", function () {
            expect(mathEnforcer.sum('test',10)).to.be.undefined
         })
         it("Should return undefined for (10'test')", function () {
            expect(mathEnforcer.sum(10,'test')).to.be.undefined
         })
         it("Should return 13 for (10,3)", function () {
            expect(mathEnforcer.sum(10,3)).to.equal(13)
         })
         it("Should return 4.6 for (2.3,2.3)", function () {
            expect(mathEnforcer.sum(2.3,2.3)).to.be.closeTo(4.6,0.01)
         })
         it("Should return 0 for (-2.3,2.3)", function () {
            expect(mathEnforcer.sum(-2.3,2.3)).to.be.closeTo(0,0.01)
         })
        
    })

})
