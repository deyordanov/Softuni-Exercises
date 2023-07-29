function attachEvents() {
  const urls = {
    BASE_URL: "http://localhost:3030/jsonstore/collections/students",
  };

  const firstName = document.querySelector('input[name="firstName"]');
  const lastName = document.querySelector('input[name="lastName"]');
  const facultyNumber = document.querySelector('input[name="facultyNumber"]');
  const grade = document.querySelector('input[name="grade"]');

  const submitButton = document.querySelector("#submit");

  submitButton.addEventListener("click", createStudent);

  extractStudents();

  async function createStudent() {
    await fetch(urls.BASE_URL, {
      method: "POST",
      body: JSON.stringify({
        firstName: firstName.value,
        lastName: lastName.value,
        facultyNumber: facultyNumber.value,
        grade: grade.value,
      }),
    });

    resetValues();
  }

  function resetValues() {
    firstName.value = "";
    lastName.value = "";
    facultyNumber.value = "";
    grade.value = "";
  }

  async function extractStudents() {
    const studentsStream = await fetch(urls.BASE_URL);
    const studentsData = await studentsStream.json();
    Object.keys(studentsData).forEach((key) => {
      const row = document.createElement("tr");

      const firstNameCell = document.createElement("td");
      firstNameCell.textContent = studentsData[key].firstName;

      const lastNameCell = document.createElement("td");
      lastNameCell.textContent = studentsData[key].lastName;

      const facultyNumberCell = document.createElement("td");
      facultyNumberCell.textContent = studentsData[key].facultyNumber;

      const gradeCell = document.createElement("td");
      gradeCell.textContent = studentsData[key].grade;

      row.appendChild(firstNameCell);
      row.appendChild(lastNameCell);
      row.appendChild(facultyNumberCell);
      row.appendChild(gradeCell);

      document.querySelector("tbody").appendChild(row);
    });
  }
}

attachEvents();
