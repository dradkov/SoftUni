function solve(args) {

    var date = new Date(args[2],args[1]-1,0);
   
    console.log(date.getDate());

    }
    solve([13, 12, 2004]);