function oddNumbers(numbers){
    numbers = numbers.filter((num, i)=>i % 2 !== 0).reverse().map(x => x * 2);
    console.log(numbers.join(` `));
}
