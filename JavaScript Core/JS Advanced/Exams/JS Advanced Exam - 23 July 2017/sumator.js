class Sumator {
  constructor() {
    this.data = [];
  }
  add(item) {
    this.data.push(item);
  }
  sumNums() {
    let sum = 0;
    for (let item of this.data)
      if (typeof (item) === 'number')
        sum += item;
    return sum;
  }
  removeByFilter(filterFunc) {
    this.data = this.data.filter(x => !filterFunc(x));
  }
  toString() {
    if (this.data.length > 0)
      return this.data.join(", ");
    else
      return '(empty)';
  }
}

let expect = require('chai').expect

describe('test Sumator', function () {

  let t;

  beforeEach(function () {
    t = new Sumator();
  });

  describe('Major check', function () {
    it('has all properties', function () {
      expect(t.hasOwnProperty('data')).to.equal(true);
    })

    it('has functions attached to prototype', function () {
      expect(Object.getPrototypeOf(t).hasOwnProperty('add')).to.equal(true);
      expect(Object.getPrototypeOf(t).hasOwnProperty('sumNums')).to.equal(true);
      expect(Object.getPrototypeOf(t).hasOwnProperty('removeByFilter')).to.equal(true);
      expect(Object.getPrototypeOf(t).hasOwnProperty('toString')).to.equal(true);
    })
  })


  describe('Contains a property data ', function () {
    it('Initialize empty collection Should return 0', () => {
      expect(t.data instanceof Array).to.equal(true);
      expect(t.data.length).to.equal(0)
    })
  })

  describe('Function add(item) ', function () {
    it('Add number Should return 1', () => {
      t.add(3)
      expect(t.data.length).to.equal(1)
    })
    it('Add number and string Should return 2', () => {
      t.add(3)
      t.add('Pesho')
      expect(t.data.length).to.equal(2)
    })
  })
  describe('Function sumNums() ', function () {
    it('Check for Int Nums Should return 4', () => {
      let t = new Sumator()
      t.add(3)
      t.add('ivan')
      t.add(1)
      t.add({
        name: 'pesho'
      })

      expect(t.sumNums()).to.equal(4)
    })
    it('Check Double Nums Should return 3.3', () => {
      let t = new Sumator()
      t.add(1.1)
      t.add('ivan')
      t.add(1.1)
      t.add({
        name: 'pesho'
      })
      t.add(1.1)
      expect(t.sumNums()).to.be.closeTo(3.3, 0.01)
    })
    it('Check Negative Nums Should return -3.1', () => {
      let t = new Sumator()
      t.add(-2)
      t.add('ivan')
      t.add(-2.2)
      t.add({
        name: 'pesho'
      })
      t.add(1.1)
      expect(t.sumNums()).to.be.closeTo(-3.1, 0.01)
    })
    it('Check for No Nums Should return 0', () => {
      let t = new Sumator()
      t.add('unit')
      t.add('ivan')
      t.add([])
      t.add({
        name: 'pesho'
      })

      expect(t.sumNums()).to.equal(0)
    })
  })
  describe('Function removeByFilter(filterFunc) ', function () {
    it('Add number Should return 1', () => {
      t.add(1)
      t.add('ivan')
      t.add(1)
      t.add('ivsan')
      t.add(1)
      t.removeByFilter((e) => e === 1)
      expect(t.data).to.not.contains(1)
    })
  })

  describe('Function toString()', function () {
    it('Check for empty collection Should return (empty)', () => {
      expect(t.toString()).to.equal('(empty)')
    })

    it('Check for join Should return 1,pesho,test', () => {
      t.add(1)
      t.add('pesho')
      t.add('test')

      expect(t.toString()).to.equal(`1, pesho, test`)
    })
  })
})