function factoialCalc(numOne, numTwo){
    let sumOne = calculateFactorial(numOne);
    let sumTwo = calculateFactorial(numTwo);
    console.log((sumOne / sumTwo).toFixed(2));

    function calculateFactorial(number){
        let factorial = 1;
        for(let i = 1; i <= number; i++){
            factorial = factorial * i;
        }
        return factorial;
    }
}