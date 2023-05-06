function validatePassword(password) {
  const symbols = password.match(/[^A-Za-z0-9]/g);
  const digits = password.match(/[0-9]/g);

  const validateLength = password.length >= 6 && password.length <= 10;
  const validateLetterAndDigits = symbols === null ? true : false;
  const validateTwoDigits = digits === null || digits.length < 2 ? false : true;

  if (validateLength && validateLetterAndDigits && validateTwoDigits) {
    console.log(" Password is valid");
    return;
  }

  if (!validateLength) {
    console.log("Password must be between 6 and 10 characters");
  }

  if (!validateLetterAndDigits) {
    console.log("Password must consist only of letters and digits");
  }

  if (!validateTwoDigits) {
    console.log("Password must have at least 2 digits");
  }
}
