function repeat(arrayOne, arrayTwo){
    arrayOne = arrayOne.slice(0, arrayTwo[0]);
    arrayOne.splice(0, arrayTwo[1]);
    arrayOne = arrayOne.filter(x => x === arrayTwo[2]);
    console.log(`Number ${arrayTwo[2]} occurs ${arrayOne.length} times.`)
    
}
repeat([7, 1, 5, 8, 2, 7],
    [3, 1, 5]
    )