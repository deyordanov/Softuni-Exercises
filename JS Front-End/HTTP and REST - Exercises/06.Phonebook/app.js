function attachEvents() {
  const urls = {
    BASE_URl: "http://localhost:3030/jsonstore/phonebook",
  };

  const phonebook = document.querySelector("#phonebook");
  const loadButton = document.querySelector("#btnLoad");
  const person = document.querySelector("#person");
  const phone = document.querySelector("#phone");
  const createButton = document.querySelector("#btnCreate");

  loadButton.addEventListener("click", getPhonebookEntries);

  createButton.addEventListener("click", createPhonebookEntry);

  async function getPhonebookEntries() {
    phonebook.innerHTML = "";
    const stream = await fetch(urls.BASE_URl);
    const data = await stream.json();

    Object.keys(data).forEach((key) => {
      const li = document.createElement("li");
      li.textContent = `${data[key].person}: ${data[key].phone}`;

      console.log(data[key]._id);

      const button = document.createElement("button");
      button.textContent = "Delete";
      button.addEventListener("click", () => {
        fetch(`${urls.BASE_URl}/${data[key]._id}`, {
          method: "DELETE",
        }).then(getPhonebookEntries());
      });

      li.appendChild(button);

      phonebook.appendChild(li);
    });
  }

  async function createPhonebookEntry() {
    fetch(urls.BASE_URl, {
      method: "POST",
      body: JSON.stringify({ person: person.value, phone: phone.value }),
    }).then((person.value = ""), (phone.value = ""));
  }
}

attachEvents();
