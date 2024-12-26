document.addEventListener("DOMContentLoaded",()=>{
    const sliderContainer = document.querySelector('.slider-comments');
    const prevBtn = document.getElementById('prevBtn');
    const nextBtn = document.getElementById('nextBtn');

    let currentSlide = 0;

  
    const totalSlides =document.querySelectorAll('.com-slide').length;

   
    function showSlide(index) {
        if (index >= totalSlides) currentSlide = 0; 
        else if (index < 0) currentSlide = totalSlides - 1; 
        else currentSlide = index;

        const offset = currentSlide * 100; 
        sliderContainer.style.transform = `translateX(${offset}%)`;
    }

    
    prevBtn.addEventListener('click', () => showSlide(currentSlide - 1));
    nextBtn.addEventListener('click', () => showSlide(currentSlide + 1));

   
    showSlide(currentSlide);
});