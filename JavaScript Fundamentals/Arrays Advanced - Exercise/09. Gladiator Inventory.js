function gladiator(commands){
    let inventory = commands.shift().split(` `);
    for(let command of commands){
        command = command.split(` `);
        if(command[0] === `Buy`){
            if(!inventory.includes(command[1])){
                inventory.push(command[1]);
            }
        }else if(command[0] === `Trash`){
            if(inventory.includes(command[1])){
                let index = inventory.indexOf(command[1]);
                inventory.splice(index, 1);
            }
        }else if(command[0] === 'Repair'){
            if(inventory.includes(command[1])){
                let index = inventory.indexOf(command[1]);
                let element = inventory[index];
                inventory.splice(index, 1);
                inventory.push(element);
            }
        }else if(command[0] === `Upgrade`){
            let upgrade = command[1].split(`-`);
            if(inventory.includes(upgrade[0])){
                let equipment = `${upgrade[0]}:${upgrade[1]}`;
                let index = inventory.indexOf(upgrade[0]);
                inventory.splice(index + 1, 0, equipment);
            }
        }
    }
    console.log(inventory.join(` `));
}