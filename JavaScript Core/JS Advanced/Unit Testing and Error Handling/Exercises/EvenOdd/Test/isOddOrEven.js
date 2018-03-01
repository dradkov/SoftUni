let isOddOrEven = require('../isOdd').isOddOrEven
let expect = require('chai').expect

describe('Test isOddOrEven', () => {

    it('Should return even]',  ()=>{
      expect(isOddOrEven('pepi')).to.equal('even')
    })
    it('Should return odd]',  ()=>{
      expect(isOddOrEven('mitko')).to.equal('odd')
     })	
     it('Should return undefined,check with int]',  ()=>{
      expect(isOddOrEven(10)).to.be.undefined
     })	
     it('Should return undefined,checked with obj]',  ()=>{
        expect(isOddOrEven({age:122})).to.be.undefined
     })
      		 
})