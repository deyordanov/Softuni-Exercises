function logIn(words) {
  const username = words.shift();
  for (let i = 0; i <= 3; i++) {
    if (words[i].split("").reverse().join("") === username) {
      console.log(`User ${username} logged in.`);
      return;
    } else if (i < 3) {
      console.log("Incorrect password. Try again.");
    }
  }

  console.log(`User ${username} blocked!`);
}
