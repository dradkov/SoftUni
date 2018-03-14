class Record {
    constructor(temperature, humidity, pressure, windSpeed) {
        this.id = Record.incrementId()
        this.temperature = temperature
        this.humidity = humidity
        this.pressure = pressure
        this.windSpeed = windSpeed
    }

    toString() {
        let weather = 'Not stormy'
        if (this.temperature < 20 && (this.pressure < 700 || this.pressure > 900) && this.windSpeed > 25) {
            weather = 'Stormy';
        }

        return `Reading ID: ${this.id}\nTemperature: ${this.temperature}*C\nRelative Humidity: ${this.humidity}%\nPressure: ${this.pressure}hpa\nWind Speed: ${this.windSpeed}m/s\nWeather: ${weather}`
    }
    static incrementId() {
        if (Record.nextId === undefined) {
            Record.nextId = 0;
        }
        return Record.nextId++;
    }
}

let record1 = new Record(32, 66, 760, 12);
console.log(record1.toString());
console.log("");
let record2 = new Record(32, 66, 760, 12);
console.log(record2.toString());