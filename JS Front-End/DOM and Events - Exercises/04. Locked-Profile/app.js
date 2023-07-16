function lockedProfile() {
  const buttons = Array.from(document.querySelectorAll("button"));
  buttons.forEach((button) => {
    button.addEventListener("click", (e) => {
      const parent = e.currentTarget.parentElement;
      const radioLocked = parent.querySelector('input[type="radio"]');

      if (radioLocked.checked) return;

      const isHidden = button.textContent;
      const data = parent.querySelector("div");

      data.style.display = isHidden === "Show more" ? "block" : "none";
      button.textContent =
        button.textContent === "Hide it" ? "Show more" : "Hide it";
    });
  });
}
