function attachEventsListeners() {
  const myTime = {
    buttons: Array.from(document.querySelectorAll('input[type="button"]')),
  };

  const converter = {
    seconds: (convert = (value) => value),
    minutes: (convert = (value, type) =>
      type === "toSecs" ? value * 60 : value / 60),
    hours: (convert = (value, type) =>
      type === "toSecs" ? value * 3600 : value / 3600),
    days: (convert = (value, type) =>
      type === "toSecs" ? value * 86400 : value / 86400),
  };

  myTime.buttons.forEach((button) => {
    button.addEventListener("click", handle);
  });

  function handle(e) {
    const activeInputField =
      e.currentTarget.parentElement.querySelector('input[type="text"]');

    const inactiveInputFields = Array.from(
      document.querySelectorAll('input[type="text"]')
    ).filter((ipt) => ipt != activeInputField);

    const activeInputType = activeInputField.getAttribute("id");
    const activeInputValue = converter[activeInputType](
      Number(activeInputField.value),
      "toSecs"
    );

    inactiveInputFields.forEach((inactiveInputField) => {
      const type = inactiveInputField.getAttribute("id");
      inactiveInputField.value = converter[type](activeInputValue, "notSecs");
    });
  }
}
