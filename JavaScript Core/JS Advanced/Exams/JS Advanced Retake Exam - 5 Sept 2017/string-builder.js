class StringBuilder {
    constructor(string) {
        if (string !== undefined) {
            StringBuilder._vrfyParam(string);
            this._stringArray = Array.from(string);
        } else {
            this._stringArray = [];
        }
    }

    append(string) {
        StringBuilder._vrfyParam(string);
        for (let i = 0; i < string.length; i++) {
            this._stringArray.push(string[i]);
        }
    }

    prepend(string) {
        StringBuilder._vrfyParam(string);
        for (let i = string.length - 1; i >= 0; i--) {
            this._stringArray.unshift(string[i]);
        }
    }

    insertAt(string, startIndex) {
        StringBuilder._vrfyParam(string);
        this._stringArray.splice(startIndex, 0, ...string);
    }

    remove(startIndex, length) {
        this._stringArray.splice(startIndex, length);
    }

    static _vrfyParam(param) {
        if (typeof param !== 'string') throw new TypeError('Argument must be string');
    }

    toString() {
        return this._stringArray.join('');
    }
}

let expect = require('chai').expect

describe('Test StringBuilder', function () {

    let sb;

    beforeEach(function () {
        sb = new StringBuilder()
    })

    describe('Main Test', function () {

        it('has functions attached to prototype', function () {
            expect(Object.getPrototypeOf(sb).hasOwnProperty('append')).to.equal(true);
            expect(Object.getPrototypeOf(sb).hasOwnProperty('prepend')).to.equal(true);
            expect(Object.getPrototypeOf(sb).hasOwnProperty('insertAt')).to.equal(true);
            expect(Object.getPrototypeOf(sb).hasOwnProperty('toString')).to.equal(true);
            expect(Object.getPrototypeOf(sb).hasOwnProperty('remove')).to.equal(true);
        })
        it('has all properties', function () {
            expect(builder.hasOwnProperty('_stringArray')).to.equal(true, "Missing _stringArray property");
        });

        it('must initialize data to an empty array', function () {
            expect(sb._stringArray instanceof Array).to.equal(true);
            expect(sb._stringArray.length).to.equal(0);
        });
    })
    describe('instantiated Test ', function () {
        it('initialized without parametar', function () {
            let inst = new StringBuilder()

            expect(inst).to.not.throw
        })
        it('initialized with parametar', function () {
            let inst = new StringBuilder('pesho')

            expect(inst).to.not.throw
        })
        it('initialized with parametar different than string', function () {

            expect(() => innst = new StringBuilder(1)).to.throw()
        })

    })
   
    describe('_vrfyParam func', function () {
        it('with incorrect param', function () {
            expect(() => StringBuilder._vrfyParam(5)).to.throw()
        })
        it('with correct param', function () {
            expect(() => StringBuilder._vrfyParam('test')).to.not.throw()
        })
    })

    describe('append func', function () {
        it('check for invalid param after append', function () {
            
            expect(()=> sb.append(100)).to.throw(Error)
        })
        it('check the last char after append', function () {
            sb.append('ivan')
            expect(sb._stringArray[3]).to.equal('n')
        })
        it('check the array len after append', function () {
            sb.append('ivan')
            sb.append('dragan')
            sb.append('koko')
            expect(sb._stringArray.length).to.equal(14)
        })
    })
    describe('prepend func', function () {
        it('check for invalid param after prepend', function () {
            
            expect(()=> sb.prepend(100)).to.throw(Error)
        })
        it('check the first char after prepend', function () {
            sb.append('ivan')
            sb.append('drago')
            sb.prepend('kolio')
            expect(sb._stringArray[0]).to.equal('k')
        })
        it('check the array len after prepend', function () {
            sb.prepend('ivan')
            sb.prepend('dragan')
            sb.prepend('koko')
            expect(sb._stringArray.length).to.equal(14)
        })
    })

    describe('insert At func', function () {

        it('check for invalid first param after prepend', function () {
            sb.append('jojo')
            sb.append('ivo')
            expect(()=> sb.insertAt(100,0)).to.throw(Error)
        })
        it('inserts correctly', function () {
            sb.append('jojo')
            sb.append('tita')
            sb.insertAt('st',0)
            expect(sb.toString()).to.equal('stjojotita')
        });
    })
    describe('remove At func', function () {

        it('remove correctly', function () {
            sb.append('jojo')
            sb.append('tita')
            sb.remove(1,3)
            expect(sb.toString()).to.equal('jtita')
        });
        
    })
    describe('toString  func', function () {

        it('toString correctly', function () {
            sb.append('jojo')
            sb.append('tita')
            expect(sb.toString()).to.equal('jojotita')
        });
        
    })
})