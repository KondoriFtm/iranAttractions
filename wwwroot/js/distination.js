let mainIndex = 0;
const mainSlides = document.querySelectorAll(".main-slide");

function showMainSlide(index) {
    mainSlides.forEach((slide, i) => {
        slide.classList.toggle('active', i === index);
    });
}
function nextSlide() {
    mainIndex = (mainIndex + 1) % mainSlides.length;
    showMainSlide(mainIndex);
}

function prevSlide() {
    mainIndex = (mainIndex - 1 + mainSlides.length) % mainSlides.length;
    showMainSlide(mainIndex);
}

function adjustSliderHeight() {
    const mainSlider = document.querySelector(".main-slider");
    let maxHeight = 0;
    mainSlides.forEach(slide => {
        const img = slide.querySelector("img");
        maxHeight = Math.max(maxHeight, img.naturalHeight);
    });
    mainSlider.style.height = '${maxHeight}px';
}
window.addEventListener("load", () => {
    adjustSliderHeight();
    showMainSlide(mainIndex);
});
window.addEventListener("resize", adjustSliderHeight);

setInterval(nextSlide, 10000);