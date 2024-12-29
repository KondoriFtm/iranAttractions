const toggleNavbar = document.querySelector(".navbar-toggle"); // دکمه منو
const navbar = document.querySelector(".navbar");

toggleNavbar.addEventListener("click", () => {
  navbar.classList.toggle("active");
});