function create(words) {
  words.forEach((word) => {
    const element = document.createElement("div");
    const paragraph = document.createElement("p");
    paragraph.style.display = "none";
    paragraph.textContent = word;
    element.appendChild(paragraph);
    element.addEventListener("click", (e) => {
      const hiddenParagraph = e.currentTarget.querySelector("p");
      hiddenParagraph.style.display = "block";
    });
    document.querySelector("#content").appendChild(element);
  });
}
