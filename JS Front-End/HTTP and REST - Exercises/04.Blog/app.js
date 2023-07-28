async function attachEvents() {
  const urls = {
    POSTS_URL: " http://localhost:3030/jsonstore/blog/posts",
    COMMENTS_URL: "http://localhost:3030/jsonstore/blog/comments",
  };

  const loadButton = document.querySelector("#btnLoadPosts");
  const postsDropdownMenu = document.querySelector("#posts");
  const viewButton = document.querySelector("#btnViewPost");
  const postTitle = document.querySelector("#post-title");
  const postBody = document.querySelector("#post-body");
  const postComments = document.querySelector("#post-comments");

  const postsStream = await fetch(urls.POSTS_URL);
  const postsData = await postsStream.json();

  loadButton.addEventListener("click", () => {
    Object.keys(postsData).forEach((key) => {
      const option = document.createElement("option");
      option.value = key;
      option.textContent = postsData[key].title;

      postsDropdownMenu.appendChild(option);
    });
  });

  viewButton.addEventListener("click", fillInPostData);

  async function fillInPostData() {
    const currentPostId = postsDropdownMenu.value;
    const commentsStream = await fetch(urls.COMMENTS_URL);
    const commentsData = await commentsStream.json();
    getComments(commentsData, currentPostId);
    postTitle.textContent = postsData[currentPostId].title;
    postBody.textContent = postsData[currentPostId].body;
  }

  getComments = (commentsData, currentPostId) => {
    postComments.innerHTML = "";
    Object.keys(commentsData).forEach((key) => {
      if (commentsData[key].postId === currentPostId) {
        const li = document.createElement("li");
        li.textContent = commentsData[key].text;
        postComments.appendChild(li);
      }
    });
  };
}

attachEvents();
