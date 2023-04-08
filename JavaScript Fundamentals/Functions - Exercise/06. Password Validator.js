function password(pass){
    pass = [...pass];
    let numbersCount = pass.filter(x => /\d/.test(x)).length;
    let lettersCount = pass.filter(x => /[A-Za-z]/.test(x)).length;
    let symbolCount = pass.filter(x => /[^A-Za-z0-9]/.test(x)).length;
    if(symbolCount == 0 && numbersCount > 0 && lettersCount > 0 && pass.length >= 6 && pass.length <= 10){
        console.log(`Password is valid`);
    }else{
        if(pass.length < 6 || pass.length > 10){
            console.log(`Password must be between 6 and 10 characters`);
        }
        if(symbolCount > 0){
            console.log(`Password must consist only of letters and digits`);
        }
        if(numbersCount < 2){
            console.log(`Password must have at least 2 digits`);
        }
    }
}