function solve() {
  const text = document.querySelector("#input").value;
  const sentences = Array.from(
    text.split(".").filter((snt) => snt.match(/[A-Za-z]+/))
  );
  const output = document.querySelector("#output");
  let p = document.createElement("p");
  for (let i = 0; i < sentences.length; i++) {
    if ((i + 1) % 3 === 0) {
      output.appendChild(p);
      p = document.createElement("p");
    } else {
      p.textContent += `${sentences[i]}.`;
    }
  }

  if (p.textContent !== "") output.appendChild(p);
}
