function points(array){
    let firstPointToCenter = Math.sqrt(Math.pow(0 - array[0], 2) + Math.pow(0 - array[1], 2));
    let secondPointToCenter = Math.sqrt(Math.pow(0 - array[2], 2) + Math.pow(0 - array[3], 2));
    let firstPointToSecondPoint = Math.sqrt(Math.pow(array[0] - array[2], 2) + Math.pow(array[1] - array[3], 2));
    //first point to center
    console.log(firstPointToCenter % 1 == 0 ? `{${array[0]}, ${array[1]}} to {0, 0} is valid`:
    `{${array[0]}, ${array[1]}} to {0, 0} is invalid`);
    //second point to center
    console.log(secondPointToCenter % 1 == 0 ? `{${array[2]}, ${array[3]}} to {0, 0} is valid`:
    `{${array[2]}, ${array[3]}} to {0, 0} is invalid`);
    //first point to second point
    console.log(firstPointToSecondPoint % 1 == 0 ? `{${array[0]}, ${array[1]}} to {${array[2]}, ${array[3]}} is valid`:
    `{${array[0]}, ${array[1]}} to {${array[2]}, ${array[3]}} is invalid`);
}