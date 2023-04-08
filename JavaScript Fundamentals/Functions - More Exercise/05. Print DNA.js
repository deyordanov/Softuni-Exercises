function DNA(count){
    let sequence = `ATCGTTAGGG`.split('');
    let turn = 1;
    let index = 0;;
    for(let i = 0; i < count; i++){
        if(index >= 9){
            index = 0;
        }
        if(turn === 1){
            console.log(`**${sequence[index++]}${sequence[index++]}**`);
            turn++
        }else if(turn === 2){
            console.log(`*${sequence[index++]}--${sequence[index++]}*`);
            turn++
        }else if(turn === 3){
            console.log(`${sequence[index++]}----${sequence[index++]}`);
            turn++
        }else if(turn === 4){
            console.log(`*${sequence[index++]}--${sequence[index++]}*`);
            turn++;
        }
        if(turn === 5){
            turn = 1;
        }
    }  
}