function orders(item, count){
    switch(item){
        case `coffee`:
            console.log((1.5 * count).toFixed(2));
            break;
        case `water`:
            console.log((1 * count).toFixed(2));
            break;
        case `coke`:
            console.log((1.4 * count).toFixed(2));
            break;
        case `snacks`:
            console.log((2 * count).toFixed(2));
            break;
    }
}