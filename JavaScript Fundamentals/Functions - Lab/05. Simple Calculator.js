function calculator(numberOne, numberTwo, operation){
    let multiply = (a, b) => a * b;
    let divide = (a, b) => a / b;
    let add = (a, b) => a + b;
    let subtract = (a, b) => a - b;
    switch(operation){
        case `multiply`:
            console.log(multiply(numberOne, numberTwo));
            break;
        case `divide`:
            console.log(divide(numberOne, numberTwo));
            break;
        case `add`:
            console.log(add(numberOne, numberTwo));
            break;
        case `subtract`:
            console.log(subtract(numberOne, numberTwo));
            break; 
    }
}
