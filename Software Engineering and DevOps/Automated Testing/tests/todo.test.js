const { test, expect } = require("@playwright/test");

test("User can add a task", async ({ page }) => {
  await addTask(page);

  const taskText = await page.textContent(".task");
  expect(taskText).toContain("Test Task");
});

test("User can delete a task", async ({ page }) => {
  await addTask(page);

  await page.click(".task .delete-task");

  const tasks = await page.$$eval(".task", (tasks) =>
    tasks.map((task) => task.textContent)
  );
  expect(tasks).not.toContain("Test Task");
});

test("User can complete a task", async ({ page }) => {
  await addTask(page);

  await page.click(".task .task-complete");

  const completedTask = await page.$(".task.completed");
  expect(completedTask).not.toBeNull();
});

test("Use can filter tasks", async ({ page }) => {
  await addTask(page);

  await page.click(".task .task-complete");

  await page.selectOption("#filter", "Completed");

  const incompleteTask = await page.$(".task:not(.completed)");
  expect(incompleteTask).toBeNull();
});

async function addTask(page) {
  await page.goto("http://localhost:5500/");
  await page.fill("#task-input", "Test Task");
  await page.click("#add-task");
}
