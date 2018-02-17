function attachEventsListeners() {
    
    let daysBtn = document.getElementById('daysBtn');
    let hoursBtn = document.getElementById('hoursBtn');
    let minutesBtn = document.getElementById('minutesBtn');
    let secondsBtn = document.getElementById('secondsBtn');

    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    daysBtn.addEventListener('click',function () { converter(days.value,'days');});
    hoursBtn.addEventListener('click',function () { converter(hours.value,'hours');});
    minutesBtn.addEventListener('click',function () { converter(minutes.value,'minutes');});
    secondsBtn.addEventListener('click',function () { converter(seconds.value,'seconds');});

    function converter(value,type) {
        
        value = Number(value);
        let seconds = 0;
        switch (type) {
            case 'days': seconds = value *60*60*24; break;
            case 'hours': seconds = value *60*60; break;
            case 'minutes': seconds = value *60; break;
            case 'seconds': seconds = value; break;
            default:
                break;
        }

        document.getElementById('days').value=seconds/86400;
                    document.getElementById('hours').value=seconds/3600;
                    document.getElementById('minutes').value=seconds/60;
                    document.getElementById('seconds').value=seconds;
    }
    
}
  