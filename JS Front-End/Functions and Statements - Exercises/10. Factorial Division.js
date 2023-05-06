function factorialDivision(fac1, fac2) {
  //calculating factorial recursively =>
  function calculateFactorial(fac) {
    if (fac === 0 || fac === 1) {
      return 1;
    }

    return fac * calculateFactorial(fac - 1);
  }

  const firstFactorial = calculateFactorial(fac1);
  const secondFactorial = calculateFactorial(fac2);

  console.log((firstFactorial / secondFactorial).toFixed(2));
}
