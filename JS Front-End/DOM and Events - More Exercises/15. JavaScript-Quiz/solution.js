function solve() {
  const correctAnswers = [
    "onclick",
    "JSON.stringify()",
    "A programming API for HTML and XML documents",
  ];
  let incorrectAnswers = 0;
  const questions = Array.from(document.querySelectorAll("section ul"));

  const sections = Array.from(document.querySelectorAll("section"));

  sections.forEach((section, i) => {
    Array.from(section.querySelectorAll(".answer-wrap")).forEach((question) =>
      question.addEventListener("click", () => {
        if (!correctAnswers.includes(question.querySelector("p").textContent))
          incorrectAnswers++;
        sections[i].style.display = "none";
        if (i + 1 < sections.length) {
          sections[i + 1].style.display = "block";
        } else {
          document.querySelector("#results").style.display = "block";
          const result = document.querySelectorAll("h1")[1];
          result.innerText =
            incorrectAnswers === 0
              ? "You are recognized as top JavaScript fan!"
              : `You have ${questions.length - incorrectAnswers} right answers`;
        }
      })
    );
  });
}
