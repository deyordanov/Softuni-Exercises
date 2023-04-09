function minNum(numbers){
    numbers = numbers.sort((a, b) => a - b);
    console.log(`${numbers[0]} ${numbers[1]}`);
}
