$(()=>{


    const app  = Sammy('#main',function () {
        this.use('Handlebars','hbs')

        this.get('#/hello/:name',function () {
            this.title = "Hello Man"
            this.name = this.params.name
            this.loadPartials({
                header:'./Templates/commons/header.hbs',
                footer:'./Templates/commons/footer.hbs'
            }).then(function (){
                this.partial('./Templates/greetings.hbs')
            })
            
           // this.partial('./Templates/greetings.hbs')
        })

        this.get('#/index.html',(ctx)=>{
            ctx.swap('<h1>Hello from Sammy.js</h1>')
        })
        this.get('#/about',function () { 
            this.swap('<h1>About Page</h1>')
        })
        this.get('#/contact',function () {
            this.swap('<h1>Contact Page</h1>')
        })
        this.get('#/books/:bookId',function () {
            let bookId = this.params.bookId
           //console.log(bookId) => 22
           //console.log(this.path) => /index.html#/books/22
        })
        this.get('#/login',function () {
           this.swap('<form action="#/login" method="post">\n'+
           '    User: <input name="user" type="text">\n'+    
           '    Pass: <input name="pass" type="password">\n'+
           '    <input type="submit" value="Login">\n'+
           '</form>\n')
        })
        this.post('#/login',function () {
            //console.log(this.params.user) => pap 
            //console.log(this.params.pass)=> 123

            //this.redirect('#/contact') => Contact Page
        })
    })

    app.run()
})