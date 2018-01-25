function radioCristal(input) {
    var target = Number(input[0]);

    function processOperation(cristal, operation) {
        switch (operation) {
            case 'cut':
                cristal = cristal / 4;
                cutCount++;
                break;
            case 'lap':
                cristal *= 0.8;
                lapCount++;
                break;
            case 'grind':
                cristal -= 20;
                grindCount++;
                break;
            case 'etch':
                cristal -= 2;
                etchCount++;
                break;
            case 'xRay':
                cristal += 1;
                xrayCount++;
               return cristal;
        }

        return transportAndWashing(cristal);
    }

    function transportAndWashing(cristal) {
        return Math.floor(cristal);
    }

    for (let i = 1; i < input.length; i++) {
        let currentCristal = input[i];
        var cutCount = 0,
            lapCount = 0,
            grindCount = 0,
            etchCount = 0,
            xrayCount = 0,
            used = false;

       console.log(`Processing chunk ${currentCristal} microns`);
        while (currentCristal != target) {
            while (currentCristal / 4 >= target - 1) {
                currentCristal = processOperation(currentCristal, "cut");
            }
            while (currentCristal / 1.25 >= target - 1) {
                currentCristal = processOperation(currentCristal, "lap");
            }
            while (currentCristal - 20 >= target - 1) {
                currentCristal = processOperation(currentCristal, "grind");
            }
            while (currentCristal - 2 >= target - 1) {
                currentCristal = processOperation(currentCristal, "etch");
            }
            if (currentCristal + 1 == target && used == false) {
                used = true;
                currentCristal = processOperation(currentCristal, "xRay");
            }
        }

        if (cutCount > 0) {
            console.log(`Cut x${cutCount}`)
            console.log("Transporting and washing");
        }

        if (lapCount > 0) {
            console.log(`Lap x${lapCount}`)
            console.log("Transporting and washing");
        }

        if (grindCount > 0) {
            console.log(`Grind x${grindCount}`)
            console.log("Transporting and washing");
        }

        if (etchCount > 0) {
            console.log(`Etch x${etchCount}`)
            console.log("Transporting and washing");
        }

        if (used) {
            console.log(`X-ray x1`)
        }

        console.log(`Finished crystal ${target} microns`);
    }
}