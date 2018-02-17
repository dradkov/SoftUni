function attachEventsListeners() {
   
    let convertBtn = document.getElementById('convert');

    convertBtn.addEventListener('click',function () {
        let from  = document.getElementById('inputUnits').value;
        let to = document.getElementById('outputUnits').value;
        convert(from,to);
    });

    function convert(fromStr, toStr) {
        let meters = 0;
        let result = 0;
        let value = Number(document.getElementById('inputDistance').value);
        switch (fromStr) {
            case 'km':
                meters = value * 1000;
                break;
            case 'm':
                meters = value;
                break;
            case 'cm':
                meters = value * 0.01;
                break;
            case 'mm':
                meters = value * 0.001;
                break;
            case 'mi':
                meters = value * 1609.34;
                break;
            case 'yrd':
                meters = value * 0.9144;
                break;
            case 'ft':
                meters = value * 0.3048;
                break;
            case 'in':
                meters = value * 0.0254;
                break;
        }

        switch (toStr) {
            case 'km':
                result = meters / 1000;
                break;
            case 'm':
                result = meters;
                break;
            case 'cm':
                result = meters / 0.01;
                break;
            case 'mm':
                result = meters / 0.001;
                break;
            case 'mi':
                result = meters / 1609.34;
                break;
            case 'yrd':
                result = meters / 0.9144;
                break;
            case 'ft':
                result = meters / 0.3048;
                break;
            case 'in':
                result = meters / 0.0254;
                break;
        }
        document.getElementById('outputDistance').value=result;
    }
}
  