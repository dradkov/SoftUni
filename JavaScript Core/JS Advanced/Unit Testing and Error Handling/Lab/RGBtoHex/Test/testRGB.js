let rgbToHexColor = require('../rgb.js').rgbToHexColor
let expect = require('chai').expect

describe('RGB to Hex Color', ()=> {

    it('Should return #FF9EAA for (255,158,170)', () =>{
     expect(rgbToHexColor(255,158,170)).to.equal('#FF9EAA')
    })
    it('Should pad values with zeroes #FF9EAA for (255,158,170)', () =>{
        expect(rgbToHexColor(12,13,14)).to.equal('#0C0D0E')
    })
    it('Should work at lower limit', () =>{
        expect(rgbToHexColor(0,0,0)).to.equal('#000000')
    })
    it('Should work at upper limit', () =>{
        expect(rgbToHexColor(255,255,255)).to.equal('#FFFFFF')
    })
    it('Should return undefined for negative', () =>{
        expect(rgbToHexColor(-1,5,18)).to.be.undefined
    })
    it('Should return undefined for values grater than 255', () =>{
        expect(rgbToHexColor(256,17,18)).to.be.undefined
    })
    it('Should return undefined for values grater than 255', () =>{
        expect(rgbToHexColor(10,256,18)).to.be.undefined
    })
    it('Should return undefined for values grater than 255', () =>{
        expect(rgbToHexColor(10,18,256)).to.be.undefined
    })
    it('Should return undefined for fractions', () =>{
        expect(rgbToHexColor(3.14,2.11,18)).to.be.undefined
    })
    it('Should return undefined for fractions', () =>{
        expect(rgbToHexColor('pesho',{name:'ivane'},[])).to.be.undefined
    })
   
})