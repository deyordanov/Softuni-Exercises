function oddAndEven(numbers){
    numbers = numbers.toString();
    let evenSum = 0;
    let oddSum = 0;
    for(let i = 0;i < numbers.length; i++){
        if(Number(numbers[i]) % 2 == 0){
            evenSum += Number(numbers[i]);
        }else{
            oddSum += Number(numbers[i]);
        }
    } 
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}