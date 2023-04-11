function build(wall){
    let totalCement = 0;
    let concrete = [];
    while(wall.filter(x => x != 30).length > 0){
        let currCount = 0;
        for(let i = 0; i < wall.length; i++){
            if(wall[i] + 1<= 30){
                wall[i]++;
                currCount++;
            }
        }
        concrete.push(195 * currCount);
        totalCement += 195 * currCount;
    }
    console.log(concrete.join(`, `));
    console.log(`${totalCement*1900} pesos`);
}
build([21, 25, 28])