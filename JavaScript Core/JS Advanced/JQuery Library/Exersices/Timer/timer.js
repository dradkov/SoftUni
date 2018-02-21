function timer() {

    let interval

    let hours = $('#hours')
    let minutes = $('#minutes')
    let seconds = $('#seconds')

    let sec = 0;
    let min = 0;
    let h = 0;

    let isStarted = false;


    $('#start-timer').on('click', onStartClick )

    $('#stop-timer').on('click',onPauseClick)


    function onStartClick() {

        if (!isStarted) {

            isStarted = true
            interval = setInterval(function(){
             
                sec++;
                if (sec>=60) {
                    min++
                    sec = 0
                    if (min>=60) {
                        min=0;
                        h++
                    }
                }
    
                seconds.text (sec < 10 ? '0' + sec : sec) 
                minutes.text(min < 10 ? '0' + min : min)
                hours.text(h < 10 ? '0' + h : h)
    
                }, 1000)
        }
       
    }

    function onPauseClick() {

        clearInterval(interval)
        isStarted = false
    }
}
