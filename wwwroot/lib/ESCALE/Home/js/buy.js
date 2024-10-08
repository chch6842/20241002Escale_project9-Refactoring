let currentIndex = 0;
const items = document.querySelectorAll('.carousel-item');
const carousel = document.getElementById('scrollContainer');

function scrollCarousel() {
  currentIndex++;

  if (currentIndex >= items.length) {
    currentIndex = 0;
    carousel.classList.add('reset-animation');
    setTimeout(() => {
      carousel.classList.remove('reset-animation');
      scrollCarousel();
    }, 50);
    return;
  }

  const scrollAmount = -100 * currentIndex;
  carousel.style.transform = `translateX(${scrollAmount}%)`;
}

function autoScroll() {
  scrollCarousel();
}

// 每秒自動滾動一次
setInterval(autoScroll, 2000);
