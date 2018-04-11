$(() => {
    const app = Sammy('#main', function () {
        this.use('Handlebars', 'hbs')

        this.get('index.html', displayHome)
        this.get('#/home', displayHome)

        this.get('#/about', (ctx) => {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
            ctx.username = sessionStorage.getItem('username')
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
            }).then(function () {
                this.partial('./templates/about/about.hbs')
            })
        })

        this.get('#/login', (ctx) => {

            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
            ctx.username = sessionStorage.getItem('username')
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                loginForm: './templates/login/loginForm.hbs'
            }).then(function () {
                this.partial('./templates/login/loginPage.hbs')
            })
        })

        this.post('#/login', (ctx) => {

            let u = ctx.params.username
            let p = ctx.params.password
            //console.log([u, p])
            auth.login(u, p)
                .then((data) => {
                    auth.saveSession(data)
                    auth.showInfo('You are logged in')
                    displayHome(ctx)
                }).catch(auth.handleError)
        })

        this.get('#/logout', (ctx) => {
            auth.logout()
                .then(() => {
                    sessionStorage.clear()
                    auth.showInfo('You are logged out')
                    displayHome(ctx)
                }).catch(auth.handleError)
        })

        this.get('#/register', (ctx) => {

            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
            ctx.username = sessionStorage.getItem('username')
            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                registerForm: './templates/register/registerForm.hbs'
            }).then(function () {
                this.partial('./templates/register/registerPage.hbs')
            }).catch(auth.handleError)

        })
        this.post('#/register', (ctx) => {

            let u = ctx.params.username
            let p = ctx.params.password
            let rp = ctx.params.repeatPassword
            //console.log([u,p,rp])
            if (p != rp) {
                auth.showError('Repeat Pass is different then Pass')
            } else {
                auth.register(u, p).then((data) => {
                    auth.saveSession(data)
                    auth.showInfo('You have been registered successfuly')
                    displayHome(ctx)
                }).catch(auth.handleError)
            }
        })

        this.get('#/catalog', displayCatalog)

        this.get('#/create', (ctx) => {

            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
            ctx.username = sessionStorage.getItem('username')

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
                createForm: './templates/create/createForm.hbs'
            }).then(function () {
                this.partial('./templates/create/createPage.hbs')
            })

        })

        this.post('#/create', (ctx) => {

            let teamName = ctx.params.name
            let comment = ctx.params.comment

            teamsService.createTeam(teamName, comment)
                .then((data) => {
                    teamsService.joinTeam(data._id)
                        .then((newData) => {
                            auth.saveSession(newData)
                            auth.showInfo(`${teamName} was created`)
                            displayCatalog(ctx)
                        }).catch(auth.handleError)
                }).catch(auth.handleError)
        })


        this.get('#/catalog/:id', (ctx) => {

            let teamId = ctx.params.id.substr(1)

            teamsService.loadTeamDetails(teamId)
                .then((info) => {
                    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
                    ctx.username = sessionStorage.getItem('username')      
                    ctx.teamId = teamId
                    ctx.name = info.name
                    ctx.comment = info.comment
                    ctx.isOnTeam = info._id === sessionStorage.getItem('teamId')
                    ctx.isAuthor = info._acl.creator === sessionStorage.getItem('userId')

                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        teamControls: './templates/catalog/teamControls.hbs'
                    }).then(function () {
                        this.partial('./templates/catalog/details.hbs')
                    })
                }).catch(auth.handleError)
           
        })

        this.get('#/join/:id', (ctx)=>{
            let teamId = ctx.params.id.substr(1)

            teamsService.joinTeam(teamId)
                .then((userInfo)=>{
                    auth.saveSession(userInfo)
                    auth.showInfo('Joined Team')
                    displayCatalog(ctx)
                }).catch(auth.handleError)
        })

        this.get('#/leave', (ctx) =>{
            teamsService.leaveTeam()
                .then((userInfo)=>{
                    auth.saveSession(userInfo)
                    auth.showInfo('You just left the team')
                    displayCatalog(ctx)
                })
        })

        this.get('#/edit/:id',(ctx)=>{

            let teamId = ctx.params.id.substr(1)

            teamsService.loadTeamDetails(teamId)
                .then((teamInfo)=>{
                    ctx.teamId = teamId
                    ctx.name = teamInfo.name
                    ctx.comment = teamInfo.comment
                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        editForm: './templates/edit/editForm.hbs'
                    }).then(function () {
                        this.partial('./templates/edit/editPage.hbs')
                    })
                    
                }).catch(auth.handleError)
        })

        this.post('#/edit/:id',(ctx)=>{

            let teamId = ctx.params.id.substr(1)
            let teamName  = ctx.params.name
            let teamComment = ctx.params.comment
            teamsService.edit(teamId,teamName,teamComment)
                .then(()=>{
                    auth.showInfo(`Team ${teamName} was updated`)
                    displayCatalog(ctx)
                }).catch(auth.handleError)
        })

        function displayCatalog(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
            ctx.username = sessionStorage.getItem('username')

            teamsService.loadTeams()
                .then((teams) => {
                    ctx.hasNoTeam = sessionStorage.getItem('teamId') === null ||
                        sessionStorage.getItem('teamId') === 'undefined'
                    ctx.teams = teams
                    ctx.loadPartials({
                        header: './templates/common/header.hbs',
                        footer: './templates/common/footer.hbs',
                        team: './templates/catalog/team.hbs'
                    }).then(function () {
                        this.partial('./templates/catalog/teamCatalog.hbs')
                    })

                })
        }

        function displayHome(ctx) {
            ctx.loggedIn = sessionStorage.getItem('authtoken') !== null
            ctx.username = sessionStorage.getItem('username')

            ctx.loadPartials({
                header: './templates/common/header.hbs',
                footer: './templates/common/footer.hbs',
            }).then(function () {
                this.partial('./templates/home/home.hbs')
            })
        }

    })

    app.run()
});