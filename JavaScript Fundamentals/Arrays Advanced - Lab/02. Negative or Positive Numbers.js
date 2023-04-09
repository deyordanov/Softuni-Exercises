function solve(array){
    array = array.map(Number);
    let result = [];
    for(let item of array){
        if(item >= 0){
            result.push(item);
        }else{
            result.unshift(item);
        }
    }
    console.log(result.join(`\n`));
}
