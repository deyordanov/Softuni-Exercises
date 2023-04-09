function sequence(n, k){
    let result = [1];
    for(let i = 0; i < n - 1; i++){
        let subsequenceSum = 0;
        for(let j = 0; j < k; j++){
            if(j >= 0 && j < result.length){
                subsequenceSum += result[result.length - 1 - j];
            }
        }
        result.push(subsequenceSum);
    }
    console.log(result.join(` `));
}