function printAsciiSymbols(smb1, smb2) {
  let first = smb1.charCodeAt(0);
  let second = smb2.charCodeAt(0);
  let symbols = [];

  for (let i = Math.min(first, second) + 1; i < Math.max(first, second); i++) {
    symbols.push(String.fromCharCode(i));
  }

  console.log(symbols.join(" "));
}
