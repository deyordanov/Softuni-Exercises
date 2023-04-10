function explode(items, bomb){
    let specialNum = bomb[0];
    let radius = bomb[1];
    for(let i = 0; i < items.length; i++){
        if(items[i] === specialNum){
            let startIndex = i - radius < 0 ? 0 : i - radius;
            let endIndex = i + radius >= items.length ? items.length - 1: i + radius;
            for(let j = startIndex; j <= endIndex; j++){
                items[j] = 0;
            }
        }
    }
    let sum = 0;
    items.forEach(x => sum += x);
    console.log(sum);
}
explode([1, 1, 2, 1, 1, 1, 2, 1, 1, 1],
    [2, 1]
    )