function extract(content) {
  const element = document.querySelector(`#${content}`);
  const words = Array.from(element.innerText.matchAll(/\((?<match>.+?)\)/g));
  return words.map((word) => word.groups.match).join("; ");
}
