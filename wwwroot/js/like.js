const likeButtons = document.querySelectorAll(".like-button");


likeButtons.forEach((button) => {
  button.addEventListener("click", (e) => {
    e.stopPropagation();
  
    button.classList.toggle("liked");
  });
});