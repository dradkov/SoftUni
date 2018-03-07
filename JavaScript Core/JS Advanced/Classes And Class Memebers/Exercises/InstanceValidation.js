class CheckingAccount{
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId
        this.email = email
        this.firstName = firstName
        this.lastName  = lastName

        this.products = []
    }

    get clientId () {
        return this._clientId
    }
    set clientId (value){
        let regex = /^\d{6}$/g

        if (typeof value !== 'string' ||  !regex.test(value)) {
            throw new TypeError('Client ID must be a 6-digit number')
        }
            this._clientId = value           
    }

    get email () {
        return this._email
    }
    set email (value) {
    let regex = /^[A-Za-z0-9]+@[A-Za-z.]+$/g
        if (!regex.test(value)) {
            throw new TypeError('Invalid e-mail')
        }
        this._email = value
    }

    get firstName () {
        return  this._firstName
    }
    set firstName (value) {
        let regex = /^[A-Za-z]{3,20}$/g

        if (value.length<3 || value.length>20) {
            throw new TypeError('First name must be between 3 and 20 characters long')
        }

        if (!regex.test(value)) {
            throw new TypeError('First name must contain only Latin characters')
        }
        this._firstName = value
    }
    get lastName () {
        return  this._lastName
    }
    set lastName (value) {
        let regex = /^[A-Za-z]{3,20}$/g

        if (value.length<3 || value.length>20) {
            throw new TypeError('Last name must be between 3 and 20 characters long')
        }

        if (!regex.test(value)) {
            throw new TypeError('Last name must contain only Latin characters')
        }
        this._lastName = value
    }

    
}

//let acc = new CheckingAccount('13141D', 'ivan@some.com', 'Ivan', 'Petrov')
//TypeError: Client ID must be a 6-digit number

//let acc = new CheckingAccount('131455', 'ivan@', 'Ivan', 'Petrov')
//TypeError: Invalid e-mail

//let acc = new CheckingAccount('131455', 'ivan@some.com', 'I', 'Petrov')
//TypeError: First name must be between 3 and 20 characters long

//let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov')
//TypeError: "First name must contain only Latin characters