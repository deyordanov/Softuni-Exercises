async function attachEvents() {
  const urls = {
    BASE_URL: "http://localhost:3030/jsonstore/messenger",
  };

  const author = document.querySelector('input[name="author"]');
  const content = document.querySelector('input[name="content"]');
  const sendButton = document.querySelector("#submit");
  const refreshButton = document.querySelector("#refresh");
  const output = document.querySelector("#messages");

  sendButton.addEventListener("click", createObject);

  refreshButton.addEventListener("click", displayAllMessages);

  async function createObject() {
    fetch(urls.BASE_URL, {
      method: "POST",
      body: JSON.stringify({ author: author.value, content: content.value }),
    });
  }

  async function displayAllMessages() {
    const stream = await fetch(urls.BASE_URL);
    const data = await stream.json();

    output.textContent = Array.from(Object.values(data))
      .map((value) => `${value.author}: ${value.content}`)
      .join("\n");
  }
}

attachEvents();
