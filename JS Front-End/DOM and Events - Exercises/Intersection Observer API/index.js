const cards = document.querySelectorAll(".card");
const observer = new IntersectionObserver(
  (entries) => {
    entries.forEach((entry) => {
      entry.target.classList.toggle("show", entry.isIntersecting);
    });
  },
  { threshold: 0.99, rootMargin: "50px" }
);

const lastCardObserver = new IntersectionObserver((entries) => {
  let lastCard = entries[0];
  if (!lastCard.isIntersecting) return;
  loadNewCards();
  lastCardObserver.unobserve(lastCard.target);
  lastCardObserver.observe(document.querySelector(".card:last-child"));
});

lastCardObserver.observe(document.querySelector(".card:last-child"));

cards.forEach((card) => {
  observer.observe(card);
});

const cardContainer = document.querySelector(".cards-container");

function loadNewCards() {
  for (let i = 0; i < 10; i++) {
    const card = document.createElement("div");
    card.textContent = "New Card";
    card.classList.add("card");
    observer.observe(card);
    cardContainer.appendChild(card);
  }
}
