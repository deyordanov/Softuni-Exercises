function load(number){
    let count = number / 10;
    if(number != 100){
        console.log(`${number}% [${'%'.repeat(count)}${'.'.repeat(10 - count)}]`);
        console.log(`Still loading...`);
    }else{
        console.log(`100% Complete!`);
        console.log(`[${'%'.repeat(count)}${'.'.repeat(10 - count)}]`);
    }
}