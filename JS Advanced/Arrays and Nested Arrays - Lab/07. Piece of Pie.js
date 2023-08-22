function solve(arr, pie1, pie2) {
  const idx1 = arr.indexOf(pie1);
  const idx2 = arr.indexOf(pie2);

  return arr.slice(idx1, idx2 + 1);
}
