 function intPalindrome(array){
    array.forEach(x => x == Number(x.toString().split('').reverse().join('')) ? console.log(`true`) : console.log(`false`));
 }
