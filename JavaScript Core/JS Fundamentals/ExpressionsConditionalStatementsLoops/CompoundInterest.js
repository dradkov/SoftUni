function solve(param) {
    let principalSum = param[0];
    let interestRateInPersent = param[1];
    let compondingPeriodInMonths = param[2];
    let totalTimespanInYears = param[3];

    let compondingFrequence = 12 / compondingPeriodInMonths;
    let nominalInterestRate = interestRateInPersent / 100;

    let f = principalSum * Math.pow
    ((1 + (nominalInterestRate / compondingFrequence)), compondingFrequence * totalTimespanInYears);
    console.log(f.toFixed(2));
}

solve([1500, 4.3, 3, 6]);