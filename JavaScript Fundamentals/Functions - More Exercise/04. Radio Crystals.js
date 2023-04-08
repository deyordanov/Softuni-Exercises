function crystal(array){
    let desiredThickness = array.shift();
    for(let i = 0; i < array.length; i++){
        let cutCounter = 0;
        let lapCounter = 0;
        let grindCounter = 0;
        let etchCounter = 0;
        let xrayCounter = 0;
        let xRay = true;
        let thickness = array[i];
        console.log(`Processing chunk ${thickness} microns`)
        while(thickness > desiredThickness){
            if(thickness * 0.25 >= desiredThickness){
                thickness = thickness * 0.25;
                cutCounter++;
                thickness = Math.floor(thickness);
            }else if(thickness - thickness * 0.2 >= desiredThickness){
                thickness -= thickness * 0.2;
                lapCounter++;
                thickness = Math.floor(thickness);
            }else if(thickness - 20 >= desiredThickness){
                thickness -= 20;
                grindCounter++;
                thickness = Math.floor(thickness);
            }else if(thickness - 2 >= desiredThickness - 1){
                thickness -= 2;
                etchCounter++;
                thickness = Math.floor(thickness);
            }

            if(xRay === true && thickness === desiredThickness - 1){
                xrayCounter++;
                xRay = false;
                thickness += 1;
            }
        }
        if(thickness === desiredThickness - 1){
            xrayCounter++;
            thickness+=1;
        }
        if(cutCounter > 0){
            console.log(`Cut x${cutCounter}`);
            console.log(`Transporting and washing`);
        }
        if(lapCounter > 0){
            console.log(`Lap x${lapCounter}`);
            console.log(`Transporting and washing`);
        }
        if(grindCounter > 0){
            console.log(`Grind x${grindCounter}`);
            console.log(`Transporting and washing`);
        }
        if(etchCounter > 0){
            console.log(`Etch x${etchCounter}`);
            console.log(`Transporting and washing`);
        }
        if(xrayCounter > 0){
            console.log(`X-ray x${xrayCounter}`);
        }
        console.log(`Finished crystal ${thickness} microns`)
    }
}
