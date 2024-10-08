document.addEventListener("DOMContentLoaded", function () {
  const swiper = new Swiper(".swiper", {
    freeMode: true, // 自由滑動

    pagination: {
      el: ".swiper-pagination",
      clickable: true,
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
    loop: true, // 啟用循環播放
    autoplay: {
      delay: 300, // 設置自動播放延遲時間，單位為毫秒
      disableOnInteraction: true, // 使用者交互後是否停止自動播放
    },
    grid: {
      rows: 3,
    },
    breakpoints: {
      768: {
        grid: {
          rows: 1,
        },
        slidesPerView: 3,
        spaceBetween: 24,
      },

      375: {
        grid: {
          rows: 1,
        },
        slidesPerView: 1,
        spaceBetween: 24,
      },
    },
  });

  // 獲取所有購買按鈕，這些按鈕具有類名為 .btn-primary 和 data-toggle="modal"
  const purchaseButtons = document.querySelectorAll(
    '.btn-primary[data-toggle="modal"]'
  );

  // 遍歷處理每個購買按鈕
  purchaseButtons.forEach((button) => {
    // 為每個按鈕添加點擊事件監聽器
    button.addEventListener("click", function () {
      // 獲取購買按鈕上的商品名稱
      const itemName = button.getAttribute("data-item");

      // 彈出確認對話框
      const result = confirm(`您確定要購買 ${itemName} 嗎？`);

      // 根據使用者的選擇執行相應的操作
      if (result) {
        alert(`您已成功購買 ${itemName}！`);
        // 這裡可以添加購買成功後的其他操作，比如跳轉到購物車頁面
      } else {
        alert(`您已取消購買 ${itemName}。`);
        // 這裡可以添加使用者取消購買時的操作
      }
    });
  });
});

// 切換商品收藏狀態的函數
function toggleFavorite(button) {
  // 獲取商品名稱
  const itemName = button.parentElement
    .querySelector(".btn-primary")
    .getAttribute("data-item");

  // 切換按鈕樣式和文本
  if (button.classList.contains("btn-danger")) {
    button.classList.remove("btn-danger");
    button.classList.add("btn-secondary");
    button.textContent = "收藏";
    alert(`您已取消收藏 ${itemName}。`);
  } else {
    button.classList.remove("btn-secondary");
    button.classList.add("btn-danger");
    button.textContent = "取消收藏";
    alert(`您已成功收藏 ${itemName}！`);
  }
}
