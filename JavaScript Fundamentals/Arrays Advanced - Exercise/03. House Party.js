function party(array){
    let people = [];
    for(let person of array){
        person = person.split(' ');
        if(person.length === 3){
            if(people.every(x => x != person[0])){
                people.push(person[0]);
            }else{
                console.log(`${person[0]} is already in the list!`)
            }
        }else{
            if(people.includes(person[0])){
                let index = people.indexOf(person[0]);
                people.splice(index, 1);
            }else{
                console.log(`${person[0]} is not in the list!`)
            }
        }
    }
    console.log(people.join(`\n`));
}
