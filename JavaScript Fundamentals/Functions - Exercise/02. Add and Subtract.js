function solve(numOne, numTwo, numThree){
    let sum = add(numOne, numTwo);
    let result = subtract(sum, numThree);
    console.log(result);
    
    function add(numOne, numTwo){
        return numOne + numTwo;
    }

    function subtract(sumOfTwo, numThree){
        return sumOfTwo - numThree;
    }
}
