function nextDay(y, m, d) {

    let date=new Date(y, m-1,d);

    let tomorrow=new Date(y,m-1,date.getDate()+1);

    console.log(`${tomorrow.getFullYear()}-${tomorrow.getMonth()+1}-${tomorrow.getDate()}`);
}


solve(2016, 9, 30);