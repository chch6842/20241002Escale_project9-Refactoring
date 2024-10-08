


function scrollCarousel(direction) {
    const carousel = document.querySelector('.carousel');
    const containerWidth = carousel.clientWidth;
    const scrollAmount = 600;
/*    const scrollPercentage = 600; // 设置滚动的移动量为容器宽度的20%

    // 计算百分比对应的滚动距离
    const scrollAmount = (scrollPercentage / 100) * containerWidth;
*/
    carousel.scrollBy({
        left: direction * scrollAmount,
        behavior: 'smooth'
    });
}

// 设置初始位置
document.getElementById('scrollContainer').scrollLeft = 1000; // 设置初始位置为 200px
/*
window.onload = function() {
    const scrollContainer = document.getElementById('scrollContainer');
    const containerWidth = scrollContainer.clientWidth; /* 获取容器宽度
    const scrollAmount = containerWidth * (55 / 100); // 将滚动条位置设置为容器宽度的一半

    scrollContainer.scrollLeft = scrollAmount;
}
*/
