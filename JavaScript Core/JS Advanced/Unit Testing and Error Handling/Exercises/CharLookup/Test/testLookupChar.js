let lookupChar = require('../lookupChar').lookupChar
let expect = require('chai').expect


describe('Test LookupChar', () => {
    it('Should return s for gosho',  ()=>{
        expect(lookupChar('gosho',2)).to.equal('s')
    })
    it('Should return Incorrect index for (gosho,-2)',  ()=>{
        expect(lookupChar('gosho',-2)).to.equal('Incorrect index')
    })
    it('Should return Incorrect index for (gosho,6)',  ()=>{
        expect(lookupChar('gosho',5)).to.equal('Incorrect index')
    })
    it('Should return undefined for (1,2)',  ()=>{
        expect(lookupChar(1,2)).to.be.undefined
    })
    it('Should return undefined for (1,sd)',  ()=>{
        expect(lookupChar('gosho','sd')).to.be.undefined
    })
    it('Should return undefined for (1,sd)',  ()=>{
        expect(lookupChar('gosho','sd')).to.be.undefined
    })
    it('Should return undefined for (1,3.2)',  ()=>{
        expect(lookupChar('gosho',3.2)).to.be.undefined
    })
	
	
})
