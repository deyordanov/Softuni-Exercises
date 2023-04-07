function sign(a, b, c){
    let nums = [a, b, c];
    let counter = nums.filter(x => x < 0).length;
    if(counter % 2 == 0){
        console.log(`Positive`);
    }
    else{
        console.log(`Negative`);
    }
}
