function print(array){
    let k = array.shift();
    let firstK = array.slice(0, k);
    let secondK = array.slice(-k);
    console.log(firstK.join(` `));
    console.log(secondK.join(` `));
}
