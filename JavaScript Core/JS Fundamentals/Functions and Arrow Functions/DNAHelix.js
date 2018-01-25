function printDNAHelix(num) {
    var sequence='ATCGTTAGGG';
    var round = 0;
    for (let i = 0; i < num; i++) {
        let row = i%4;
        switch (row) {
            case 0:
                console.log('**'+sequence[(i+round)%10]+sequence[(i+1+round)%10]+'**');
                break;
            case 1:
                console.log('*'+sequence[(i+1+round)%10]+'--'+sequence[(i+2+round)%10]+'*');
                break;
            case 2:
                console.log(sequence[(i+2+round)%10]+'----'+sequence[(i+3+round)%10]);
                break;
            case 3:
                console.log('*'+sequence[(i+3+round)%10]+'--'+sequence[(i+4+round)%10]+'*');
                round+=4;
                break;
            default:
                break;
        }
       
       
    }
}