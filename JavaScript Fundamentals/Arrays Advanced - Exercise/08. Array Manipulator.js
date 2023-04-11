function manipulate(numbers, commands){
    for(let command of commands){
        command = command.split(' ');
        if(command[0] === `add`){
            numbers.splice(Number(command[1]), 0, Number(command[2]));
        }else if(command[0] === `addMany`){
            let numbersToAdd = command.slice(2).map(Number);
            numbers.splice(Number(command[1]), 0, ...numbersToAdd);
        }else if(command[0] === `contains`){
            console.log(numbers.includes(Number(command[1])) ? `${numbers.indexOf(Number(command[1]))}` : `-1`);
        }else if(command[0] === `remove`){
            numbers.splice(Number(command[1]), 1);
        }else if(command[0] === `shift`){
            for(let i = 0; i < Number(command[1]); i++){
                let element = numbers.shift();
                numbers.push(element);
            }
        }else if(command[0] === `sumPairs`){
            let array = [];
            let index = 0;
            for(let i = 0; i < numbers.length; i+=0){
                array[index++] = !(i + 1 >= numbers.length) ? numbers[i++] + numbers[i++] : numbers[i++];
            }
            numbers = array.slice(0);
        }else if(command[0] === `print`){
            console.log(`[ ${numbers.join(`, `)} ]`);
            return;
        }
    }
}