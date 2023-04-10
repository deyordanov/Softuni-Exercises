function sort(strings){
    strings = strings.sort((a, b) => a.length - b.length || a.localeCompare(b));
    console.log(strings.join(`\n`));
}