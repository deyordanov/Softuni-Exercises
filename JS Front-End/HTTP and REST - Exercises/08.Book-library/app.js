function attachEvents() {
  const urls = {
    BASE_URL: "http://localhost:3030/jsonstore/collections/books",
  };

  const loadAllBooksButton = document.querySelector("#loadBooks");
  const formTitle = document.querySelector("#form > h3");
  const titleField = document.querySelector('input[name="title"]');
  const authorField = document.querySelector('input[name="author"]');
  const submitButton = document.querySelector("#form > button");
  let currentBookId = null;

  loadAllBooksButton.addEventListener("click", loadAllBooks);

  submitButton.addEventListener("click", handleForm);

  async function loadAllBooks() {
    document.querySelector("tbody").innerHTML = "";
    const bookStream = await fetch(urls.BASE_URL);
    const bookData = await bookStream.json();
    Object.keys(bookData).forEach((book) => {
      const row = document.createElement("tr");

      const titleCell = document.createElement("td");
      titleCell.textContent = bookData[book].title;

      const authorCell = document.createElement("td");
      authorCell.textContent = bookData[book].author;

      const buttonsCell = document.createElement("td");

      const editButton = document.createElement("button");
      editButton.textContent = "Edit";
      editButton.addEventListener("click", editBook);

      const deleteButton = document.createElement("button");
      deleteButton.textContent = "Delete";
      deleteButton.addEventListener("click", deleteBook);

      buttonsCell.appendChild(editButton);
      buttonsCell.appendChild(deleteButton);

      row.appendChild(titleCell);
      row.appendChild(authorCell);
      row.appendChild(buttonsCell);
      row.id = book;

      document.querySelector("tbody").appendChild(row);
    });
  }

  function editBook(e) {
    currentBookId = e.currentTarget.parentElement.parentElement.id;
    const bookTitle =
      e.currentTarget.parentElement.parentElement.querySelector(
        ":nth-child(1)"
      ).textContent;
    const bookAuthor =
      e.currentTarget.parentElement.parentElement.querySelector(
        ":nth-child(2)"
      ).textContent;

    titleField.value = bookTitle;
    authorField.value = bookAuthor;
    formTitle.textContent = "Edit FORM";
    submitButton.textContent = "Save";
  }

  async function deleteBook(e) {
    const row = e.currentTarget.parentElement.parentElement;
    await fetch(`${urls.BASE_URL}/${row.id}`, { method: "DELETE" });
    loadAllBooks();
  }

  async function handleForm() {
    const title = titleField.value;
    const author = authorField.value;
    if (formTitle.textContent === "Edit FORM") {
      await fetch(`${urls.BASE_URL}/${currentBookId}`, {
        method: "PUT",
        body: JSON.stringify({ title, author }),
      });
      formTitle.textContent = "FORM";
      submitButton.textContent = "Submit";
    } else {
      await fetch(urls.BASE_URL, {
        method: "POST",
        body: JSON.stringify({ title, author }),
      });
    }

    titleField.value = "";
    authorField.value = "";
    loadAllBooks();
  }
}

attachEvents();
