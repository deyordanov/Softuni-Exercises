function sort(numbers){
    let sortedNums = [];
    numbers = numbers.sort((a, b) => b - a);
    while(numbers.length > 0){
        sortedNums.push(numbers.shift());
        sortedNums.push(numbers.pop());
    }
    console.log(sortedNums.join(` `));
}
