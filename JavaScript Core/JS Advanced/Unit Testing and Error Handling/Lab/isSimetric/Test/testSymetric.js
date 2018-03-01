let isSymmetric = require('../rgb-to-hex.js').isSymmetric

let expect = require('chai').expect;

describe('Test Symetriy', () => {
    describe('General tests',()=>{
        it('Should be a function',  ()=> {
            expect(typeof isSymmetric).to.equal('function')
         })
    })
    describe('Value tests',()=>{
        it('Should return true [1,2,3,3,2,1]', ()=> {
            expect(isSymmetric([1,2,3,3,2,1])).to.be.true
         })
         it('Should return false [1,2,3,4,2,1]', ()=> {
            expect(isSymmetric([1,2,4,3,2,1])).to.be.false
         })
         it('Should return true [-1,2,-1]', ()=> {
            expect(isSymmetric([-1,2,-1])).to.be.true
         })
         it('Should return false [-1,2,1]', ()=> {
            expect(isSymmetric([-1,2,1])).to.be.false
         })
         it('Should return false [1,2]', ()=> {
            expect(isSymmetric([1,2])).to.be.false
         })
         it('Should return true [1]', ()=> {
            expect(isSymmetric([1])).to.be.true
         })
         it('Should return true [5,....]', ()=> {
            expect(isSymmetric([5,'hi',{a:5},new Date(),{a:5},'hi',5])).to.be.true
         })
         it('Should return false [5,..]', ()=> {
            expect(isSymmetric([5,'hi',{X:5},new Date(),{a:5},'hi',5])).to.be.false
         })
 
         it('Should return false(is not a array)', ()=> {
            expect(isSymmetric('pesho')).to.be.false
         })
    })
})