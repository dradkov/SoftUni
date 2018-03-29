function attachEvents() {

    $('#submit').on('click', loadData)

    let degrees = '&#176;'

    function loadData() {
        $.ajax({
            url: "https://judgetests.firebaseio.com/locations.json",
            method: "GET",
            success: display,
            error: errorHandling
        })

        function display(data) {

            let location = $('#location').val()

            var currentData = data.filter(function (obj) {
                return obj.name === location;
            })

            let code = currentData[0].code

            $.ajax({
                url: `https://judgetests.firebaseio.com/forecast/today/${code}.json`,
                method: "GET",
                success: todayForcast,
                error: errorHandling
            })

            function todayForcast(data) {
                let current = $('#current')
                let conditionName = data['forecast'].condition
                let high = data['forecast'].high
                let low = data['forecast'].low
                let degrees = '&#176;'
                let conditionSymbol = findSymbol(conditionName)
                let cityName = data['name']

                current.append($(`<span class="condition symbol">${conditionSymbol}</span>`))
                let span = $(`<span class="condition">
                                     <span class="forecast-data">${cityName}</span>
                                     <span class="forecast-data">${low}${degrees}/${high}${degrees}</span>
                                     <span class="forecast-data">${conditionName}</span>
                                     </span>`)
                current.append(span)
            }

            $.ajax({
                url: `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`,
                method: "GET",
                success: upcoming,
                error: errorHandling
            })

            function upcoming(data) {

                let locName = data['name']


                for (const d of data['forecast']) {

                    let low = d.low

                    let high = d.high
                    let conditionName = d.condition
                    let conditionSymbol = findSymbol(conditionName)
                    console.log(data);


                    let upcoming = $('#upcoming')

                    let span = $(`<span class="upcoming">
                                    <span class="symbol">${conditionSymbol}</span>
                                    <span class="forecast-data">${low}${degrees}/${high}${degrees}</span>
                                    <span class="symbol">${conditionName}</span>
                                 </span>`)

                    upcoming.append(span)


                }
                $('#forecast').show()
            }
        }

    }

    function errorHandling(err) {
        console.log(err);
    }

    function findSymbol(symbol) {

        switch (symbol) {
            case 'Sunny':
                return '&#x2600;'
            case 'Partly sunny':
                return '&#x26C5;'
            case 'Overcast':
                return '&#x2601;'
            case 'Rain':
                return '&#x2614;'
            case 'Degrees':
                return '&#176;'
            default:
                break;
        }

    }


}