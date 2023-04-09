function manipulate(array){
    let numbers = array.shift().split(' ').map(Number);
    for(let command of array){
        command = command.split(' ');
        switch(command[0]){
            case `Add`:
                Add(Number(command[1]))
                break;
            case `Remove`:
                Remove(Number(command[1]));
                break;
            case `RemoveAt`:
                RemoveAt(Number(command[1]));
                break;
            case `Insert`:
                Insert(Number(command[1]), Number(command[2]));
                break;
        }
    }
    console.log(numbers.join(` `));
    function Insert(element, index){
        numbers.splice(index, 0, element);
    }

    function RemoveAt(index){
        numbers.splice(index, 1);
    }

    function Remove(element){
        numbers = numbers.filter(x => x != element);
    }

    function Add(element){
        numbers.push(element);
    }
}
manipulate(['6 12 2 65 6 42',
'Add 8',
'Remove 12',
'RemoveAt 3',
'Insert 6 2']
)