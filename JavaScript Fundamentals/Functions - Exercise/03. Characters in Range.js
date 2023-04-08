function sequence(charA, charB){
    let lowerLimit = Math.min(charA.charCodeAt(), charB.charCodeAt()) + 1;
    let upperLimit = Math.max(charA.charCodeAt(), charB.charCodeAt());
    let chars = [];
    for(let i = lowerLimit; i < upperLimit; i++){
        chars.push(String.fromCharCode(i));
    }
    console.log(chars.join(` `));
}