function solve(number){
    let average = 0;
    number = number.toString().split('');
    while(true){
        let numbers = number.map(x => parseInt(x));
        average = numbers.reduce((a, b) => a + b, 0) / numbers.length;
        if(average < 5){
            number.push(`9`);
        }else{
            break;
        }
    }
    console.log(number.join(''));
}