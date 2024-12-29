


document.getElementById('load-more-resturant').addEventListener('click', function () {
    const hotelList = document.getElementById('resturant-list');

    // بررسی وضعیت دکمه (نمایش بیشتر یا نمایش کمتر)
    if (this.getAttribute('data-expanded') === 'true') {
        // در حالت "نمایش کمتر"، کارت‌های اضافه‌شده حذف می‌شوند
        const additionalCards = document.querySelectorAll('.additional-resturants');
        additionalCards.forEach(card => card.style.display = 'none');

        // تغییر متن دکمه به "نمایش بیشتر"
        this.textContent = 'نمایش بیشتر';
        this.setAttribute('data-expanded', 'false');
    } else {
        // در حالت "نمایش بیشتر"، کارت‌های جدید نمایش داده می‌شوند
        const additionalHotels = document.querySelectorAll('..additional-resturants');
        additionalHotels.forEach(hotel => hotel.style.display = 'block');

        // تغییر متن دکمه به "نمایش کمتر"
        this.textContent = 'نمایش کمتر';
        this.setAttribute('data-expanded', 'true');
    }
});
