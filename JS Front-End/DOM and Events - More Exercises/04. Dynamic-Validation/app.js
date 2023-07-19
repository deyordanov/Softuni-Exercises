function validate() {
  const inputField = document.querySelector("#email");
  inputField.addEventListener("change", validateEmail);

  const regex = /[a-z]+\@[a-z]+\.[a-z]+/g;

  function validateEmail() {
    const email = inputField.value;
    if (isInputEmpty(email)) {
      if (email.match(regex)) {
        inputField.classList.remove("error");
      } else {
        inputField.classList.add("error");
      }
    }
  }

  isInputEmpty = (email) => email != "";
}
