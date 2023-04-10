function train(array){
    let wagons = array.shift().split(' ').map(Number);
    let maxCap = Number(array.shift());
    for(let item of array){
        if(item.includes(`Add`)){
            item = item.split(' ');
            let passengers = Number(item[1]);
            wagons.push(passengers);
        }else{
            let passengers = Number(item);
            for(let i = 0; i < wagons.length; i++){
                if(wagons[i] + passengers <= maxCap){
                    wagons[i] += passengers;
                    break;
                } 
            }
        }
    }
    console.log(wagons.join(` `));
}
